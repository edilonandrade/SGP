using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class CarregamentoDasFrentesPadraoSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public CarregamentoDasFrentesPadraoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);
            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [When(@"eu desbloqueio a tela de planejamento")]
        public void QuandoEuDesbloqueioATelaDePlanejamento()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
        }

        [When(@"eu clico em editar a frente tendo um roteiro criado")]
        public void QuandoEuClicoEmEditarAFrenteTendoUmRoteiroCriado()
        {
            VisualizacoesAlertasSteps.QuandoEuEditarDataDeExibicaoDoCapituloECriarUmRoteiro();
        }

        [Then(@"eu visualizo os parametros da frente disponiveis com sucesso")]
        public void EntaoEuVisualizoOsParametrosDaFrenteDisponiveisComSucesso()
        {
            TelaPlanejamentoGROT.EditarCargaHorariaEProdutivMediaFrente("2", "40");
        }

        [Then(@"eu visualizo os botoes de edicao e exclusao de frente com sucesso")]
        public void EntaoEuVisualizoOsBotoesDeEdicaoEExclusaoDeFrenteComSucesso()
        {
            TelaPlanejamentoGROT.ValidarBotoesEditarExcluirFrenteGrot("1");
            TelaPlanejamentoGROT.ValidarBotoesEditarExcluirFrenteGrot("2");
        }

    }
}
