using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class VisualizaçãoRoteiroSteps
    {
        public RoteiroPage TelaRoteiro { get; private set; }
        public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
      
        public VisualizaçãoRoteiroSteps()
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

        [When(@"navego para roteiro")]
        public void QuandoNavegoParaRoteiro()
        {
            TelaRoteiro.Navegar();
        }

        [Given(@"atualizo status das cenas para gravado")]
        public void DadoAtualizoStatusDasCenasParaGravado()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Gravada");
        }

        [Given(@"atualizo status das cenas para fechado a parte")]
        public void DadoAtualizoStatusDasCenasParaFechadoAParte()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Gravada Parte");
        }

        [Then(@"visualizo status do roteiro roteirizada")]
        public void EntaoVisualizoStatusDoRoteiroRoteirizada()
        {
            TelaRoteiro.VerificarStatusRoteiro("Liberado", "Roteirizada");
        }
    }
}
