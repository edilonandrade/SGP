using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class CenariosGrotSteps
    {
        public CenarioPage TelaCenario { get; private set; }

        public CenariosGrotSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaCenario = new CenarioPage((IBrowser)browser,
            ConfigurationManager.AppSettings["CenarioURL"]);
        }

        [When(@"eu filtrar por viagem em cenarios")]
        public void QuandoEuFiltrarPorViagemEmCenarios()
        {
            TelaCenario.FiltrarPorViagem("INMETRICS VIAGEM");
            TelaCenario.FiltrarCenario("INMETRICS LOCACAO - EXT");
        }

        [When(@"clicar em editar")]
        public void QuandoClicarEmEditar()
        {
            TelaCenario.EditarCenarioGROT("INMETRICS REGIAO 2");
        }
        
        [When(@"eu clico no filtro de viagem")]
        public void QuandoEuClicoNoFiltroDeViagem()
        {
            TelaCenario.FiltroDeViagem();
        }

        [Then(@"eu visualizo a lista de sugestoes com sucesso")]
        public void EntaoEuVisualizoAListaDeSugestoesComSucesso()
        {
            TelaCenario.ValidarViagensCadastradas("INMETRICS VIAGEM");
            TelaCenario.ValidarViagensCadastradas("INMETRICS VIAGEM 2");
        }

        [Then(@"eu visualizo a lista de regioes cadastradas na opcao regiao")]
        public void EntaoEuVisualizoAListaDeRegioesCadastradasNaOpcaoRegiao()
        {
            TelaCenario.ValidarRegioesCadastradas("INMETRICS REGIAO");
            TelaCenario.ValidarRegioesCadastradas("INMETRICS REGIAO 2");
        }

        [Then(@"eu visualizo cenario filtrado com sucesso")]
        public void EntaoEuVisualizoCenarioFiltradoComSucesso()
        {
            TelaCenario.VerificarFiltroCenario("INMETRICS LOCACAO");
        }

    }
}
