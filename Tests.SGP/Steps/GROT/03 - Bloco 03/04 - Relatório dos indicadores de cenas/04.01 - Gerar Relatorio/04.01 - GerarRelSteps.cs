using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class GerarRelatorioIndicadoresDeCenasSteps
    {
        public RelatoriosDeIndicadoresDeCenasPage TelaRelatoriosDeIndicadoresDeCenas { get; private set; }
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }
        public AcionamentoNovasTelasPage TelaAcionamentoNovasTelas { get; private set; }
        public CapitulosCenasPage TelaCapituloCena { get; private set; }

        public GerarRelatorioIndicadoresDeCenasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaRelatoriosDeIndicadoresDeCenas = new RelatoriosDeIndicadoresDeCenasPage((IBrowser)browser);
            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
            TelaAcionamentoNovasTelas = new AcionamentoNovasTelasPage((IBrowser)browser);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CapituloCenaURL"],
               ConfigurationManager.AppSettings["IncluirCapituloURL"],
               ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [When(@"acesso o relatorio dos indicadores de cenas")]
        public void QuandoAcessoORelatorioDosIndicadoresDeCenas()
        {
            TelaAcionamentoNovasTelas.AcessarRelatorioIndicadoresCenas();
        }

    }
}
