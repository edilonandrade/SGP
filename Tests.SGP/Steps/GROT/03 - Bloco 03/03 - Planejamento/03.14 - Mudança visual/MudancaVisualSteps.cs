using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class MudancaVisualSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public MudancaVisualSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);
            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [When(@"eu criar um roteiro com GROT")]
        public void QuandoEuCriarUmRoteiroComGROT()
        {
            VisualizacoesAlertasSteps.QuandoEuCriarUmRoteiroComCenaNoturnaForaDaFaixaDeHorario();
        }

        [Then(@"eu visualizo o novo cabecalho GROT com sucesso")]
        public void EntaoEuVisualizoONovoCabecalhoGROTComSucesso()
        {
            TelaPlanejamentoGROT.ValidarCabecalhoGrot();
        }

    }
}
