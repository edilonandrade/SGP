using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class DestaqueNoDiaDaFrenteSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public CriacaoNovaFrenteGravacaoSteps CriacaoNovaFrenteGravacaoSteps { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }
        public CapitulosCenasPage TelaCapituloCena { get; private set; }

        public DestaqueNoDiaDaFrenteSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            CriacaoNovaFrenteGravacaoSteps = new CriacaoNovaFrenteGravacaoSteps();

            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CapituloCenaURL"],
               ConfigurationManager.AppSettings["IncluirCapituloURL"],
               ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [Given(@"que eu crio um roteiro em uma nova frente de gravacao")]
        public void DadoQueEuCrioUmRoteiroEmUmaNovaFrenteDeGravacao()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteExternaFrente3(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu alterar os dias em que a frente de gravacao vai estar disponivel")]
        public void QuandoEuAlterarOsDiasEmQueAFrenteDeGravacaoVaiEstarDisponivel()
        {
            TelaPlanejamentoGROT.IndisponibilizarDiasDaFrenteDePlanejamento3(7, "3");
            CriacaoNovaFrenteGravacaoSteps.EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
        }

        [Then(@"eu visualizo que o dia da frente ficou indisponivel mantendo o planejamento de roteiro com sucesso")]
        public void EntaoEuVisualizoQueODiaDaFrenteFicouIndisponivelMantendoOPlanejamentoDeRoteiroComSucesso()
        {
            TelaPlanejamentoGROT.ValidarFrente3Indisponivel("2");
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(7, "3");
        }

    }

}
