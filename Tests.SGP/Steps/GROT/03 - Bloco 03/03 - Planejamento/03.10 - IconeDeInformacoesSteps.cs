using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class IconeDeInformacoesSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public IconeDeInformacoesSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);
            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [Given(@"que eu esteja com um novo planejamento de roteiro liberado")]
        public void DadoQueEuEstejaComUmNovoPlanejamentoDeRoteiroLiberado()
        {
            VisualizacoesAlertasSteps.QuandoEuEditarDataDeExibicaoDoCapituloECriarUmRoteiro();
        }

        [When(@"eu clicar no botao de informacoes")]
        public void QuandoEuClicarNoBotaoDeInformacoes()
        {
            TelaPlanejamentoGROT.ClicarBtnInformacoes();
        }

        [When(@"eu clicar no botao flutuante")]
        public void QuandoEuClicarNoBotaoFlutuante()
        {
            TelaPlanejamentoGROT.ClicarBtnFlutuanteInformacoes("1");
        }

        [When(@"eu clicar no botao flutuante e fixo")]
        public void QuandoEuClicarNoBotaoFlutuanteEFixo()
        {
            TelaPlanejamentoGROT.ClicarBtnFlutuanteInformacoes("1");
            TelaPlanejamentoGROT.ClicarBtnFlutuanteInformacoes("2");
        }

        [Then(@"eu visualizo que a tela de informacoes esta em modo fixo com sucesso")]
        public void EntaoEuVisualizoQueATelaDeInformacoesEstaEmModoFixoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarTelaInformacoesFlutuante("Fixo");
        }

        [Then(@"eu visualizo que a tela de informacoes esta em modo flutuante com sucesso")]
        public void EntaoEuVisualizoQueATelaDeInformacoesEstaEmModoFlutuanteComSucesso()
        {
            TelaPlanejamentoGROT.ValidarTelaInformacoesFlutuante("Flutuante");
        }

    }
}
