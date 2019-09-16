using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class AlteracaoExclusaoDeFrenteStpes
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public CriacaoNovaFrenteGravacaoSteps CriacaoNovaFrenteGravacaoSteps { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public AlteracaoExclusaoDeFrenteStpes()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);
            CriacaoNovaFrenteGravacaoSteps = new CriacaoNovaFrenteGravacaoSteps();
            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [When(@"eu excluo uma frente de gravacao sem roteiros associados")]
        public void QuandoEuExcluoUmaFrenteDeGravacaoSemRoteirosAssociados()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaPlanejamentoGROT.ExcluirFrenteDeGravacao("2");
        }

        [When(@"eu altero a frente de planejamento tendo um roteiro associado")]
        public void QuandoEuAlteroAFrenteDePlanejamentoTendoUmRoteiroAssociado()
        {
            VisualizacoesAlertasSteps.QuandoEuCriarUmRoteiroComCenaDeEstudio();
            TelaPlanejamentoGROT.EditarParametrosNovaFrenteDePlanejamento("1", "", "");
        }

        [Then(@"eu visualizo a frente de gravacao alterada com sucesso")]
        public void EntaoEuVisualizoAFrenteDeGravacaoAlteradaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarTrocaDeTipoDeFrente("Externa", "1");
        }

        [Then(@"eu nao visualizo mas a frente de gravacao com sucesso")]
        public void EntaoEuNaoVisualizoMasAFrenteDeGravacaoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarExclusaoFrenteDeGravacao("2");
        }

    }
}
