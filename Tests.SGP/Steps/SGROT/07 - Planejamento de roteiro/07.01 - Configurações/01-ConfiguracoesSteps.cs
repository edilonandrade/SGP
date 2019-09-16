using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class ConfiguracoesSteps
    {
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }

        public ConfiguracoesSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
        }

        [When(@"configurar o grupo de notificao")]
        public void QuandoConfigurarOGrupoDeNotificao()
        {
            TelaPlanejamentoRoteiro.ConfigurarNotificacao("Lucas Fraga", "Consultor", "lucas.fraga_inmetrics@tvglobo.com.br");
        }

        [When(@"configurar capitulos baixos")]
        public void QuandoConfigurarCapitulosBaixos()
        {
            TelaPlanejamentoRoteiro.ConfigurarCapitulosBaixos("3");
        }

        [When(@"configurar direcao do programa")]
        public void QuandoConfigurarDirecaoDoPrograma()
        {
            TelaPlanejamentoRoteiro.ConfigurarDiretorPrograma("INMETRICS TESTE");
        }

        [Then(@"visualizo mensagem do grupo de notificacao apresentada com sucesso")]
        public void EntaoVisualizoMensagemDoGrupoDeNotificacaoApresentadaComSucesso()
        {
            TelaPlanejamentoRoteiro.VerificarMensagem("Lista de usuários a serem notificados salva com sucesso.");
        }

        [Then(@"visualizo mensagem de capitulos baixos apresentada com sucesso")]
        public void EntaoVisualizoMensagemDeCapitulosBaixosApresentadaComSucesso()
        {
            TelaPlanejamentoRoteiro.VerificarMensagem("Configuração de capítulo baixo salva com sucesso.");
        }

        [Then(@"visualizo mensagem direcao do programa apresentada com sucesso")]
        public void EntaoVisualizoMensagemDirecaoDoProgramaApresentadaComSucesso()
        {
            TelaPlanejamentoRoteiro.VerificarMensagem("Direção do programa salva com sucesso.");
        }
	}
}