using TechTalk.SpecFlow;
using Project.SGP.Pages;
using System.Configuration;
using Framework.Core.Interfaces;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class LimparPesquisasSteps
	{
		public CapitulosCenasPage TelaCapituloCena { get; private set; }
		public PersonagemPage TelaPersonagem { get; private set; }
		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
		public CenarioPage TelaCenario { get; private set; }
		public RoteiroPage TelaRoteiro { get; private set; }

		public LimparPesquisasSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
				ConfigurationManager.AppSettings["CapituloCenaURL"],
				ConfigurationManager.AppSettings["IncluirAdendoURL"],
				ConfigurationManager.AppSettings["IncluirCapituloURL"]);
		}

		[When(@"limpar todos os filtros e pesquisar")]
		public void QuandoLimparTodosOsFiltrosEPesquisar()
		{
			TelaCapituloCena.LimparFiltros();
		}

		[Then(@"visualizo todas as cenas com sucesso")]
		public void EntaoVisualizoTodasAsCenasComSucesso()
		{
			TelaCapituloCena.VerificarFiltro("capituloDe", "0002");
		}
	}
}
