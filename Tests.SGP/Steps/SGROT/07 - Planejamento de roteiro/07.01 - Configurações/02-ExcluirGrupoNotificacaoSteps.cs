using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class ExcluirGrupoNotificacaoSteps
    {
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }

        public ExcluirGrupoNotificacaoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
        }

        [When(@"excluir nome grupo de notificacao")]
        public void QuandoExcluirNomeGrupoDeNotificacao()
        {
            TelaPlanejamentoRoteiro.ExcluirNomeGrupoNotificacao("Lucas Fraga");
        }
    }
}
