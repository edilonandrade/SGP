using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class AbrirAtravesTelaRoteiroSteps
    {
        public RoteiroPage TelaRoteiro { get; private set; }
        public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }

        public AbrirAtravesTelaRoteiroSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaRoteiro = new RoteiroPage((IBrowser)browser,
               ConfigurationManager.AppSettings["RoteiroURL"],
			   ConfigurationManager.AppSettings["CapituloCenaURL"]);

            TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);
        }

        [When(@"eu abrir espelho de gravacao pela tela roteiro")]
        public void QuandoEuAbrirEspelhoDeGravacaoPelaTelaRoteiro()
        {
            TelaRoteiro.AbrirEspelhoGravacao();
        }

        [When(@"eu abrir planejamento roteiro pela tela roteiro")]
        public void QuandoEuAbrirPlanejamentoRoteiroPelaTelaRoteiro()
        {
            TelaRoteiro.AbrirPlanejamentoRoteiro();
        }

        [Then(@"visualizo tela espelho de gravacao")]
        public void EntaoVisualizoTelaEspelhoDeGravacao()
        {
            TelaRoteiro.VerificarPaginaRoteiro("Espelho de Gravação");
        }

        [Then(@"visualizo tela planejamento roteiro")]
        public void EntaoVisualizoTelaPlanejamentoRoteiro()
        {
            TelaPlanejamentoRoteiro.VerificarPaginaPlanejamento("Planejamento de Roteiros");
        }
    }
}
