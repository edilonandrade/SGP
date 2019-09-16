using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;


namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class OcultarListagemCenasSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public OcultarListagemCenasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [Given(@"eu crio um roteiro um dia depois da exibicao do capitulo")]
        public void DadoEuCrioUmRoteiroUmDiaDepoisDaExibicaoDoCapitulo()
        {
            VisualizacoesAlertasSteps.QuandoEuCriarUmRoteiroUmDiaDepoisDaExibicaoDoCapitulo();
        }

        [When(@"clico no icone de alerta de roteiro")]
        public void QuandoClicoNoIconeDeAlertaDeRoteiro()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiroInconsitencia(": A cena 0501/004 não pode ser gravada depois de sua exibição.", "1");
        }

        [When(@"clico no icone de ocultar listagem de cenas")]
        public void QuandoClicoNoIconeDeOcultarListagemDeCenas()
        {
            TelaPlanejamentoGROT.ClicarOcultarListagemCenas();
        }

        [Then(@"eu não visualizo a listagem de cenas com sucesso")]
        public void EntaoEuNaoVisualizoAListagemDeCenasComSucesso()
        {
            TelaPlanejamentoGROT.ValidarOcultarListagemCenas();
        }

    }
}
