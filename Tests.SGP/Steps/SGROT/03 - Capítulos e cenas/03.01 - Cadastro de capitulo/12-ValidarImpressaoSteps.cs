using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
	[Binding]
	public sealed class ValidarImpressaoSteps
	{
		public CapitulosCenasPage TelaCapituloCena { get; private set; }

		public ValidarImpressaoSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
				ConfigurationManager.AppSettings["CapituloCenaURL"],
				ConfigurationManager.AppSettings["IncluirCapituloURL"],
				ConfigurationManager.AppSettings["IncluirAdendoURL"]);
		}

		[When(@"eu validar impressao listagem basia - todas as opcoes")]
		public void QuandoEuValidarImpressaoListagemBasia_TodasAsOpcoes()
		{
			//TelaCapituloCena.Navegar();
			TelaCapituloCena.SelecionarCapitulosCenasDecupadas("6666");
			TelaCapituloCena.SelecionarCapitulosCenasDecupadas("0400");
			TelaCapituloCena.ImprimirTodasAsOpcoes();
		}

		[When(@"eu validar impressao listagem basia - Opcao capitulo e texto da cena")]
		public void QuandoEuValidarImpressaoListagemBasia_OpcaoCapituloETextoDaCena()
		{
			//TelaCapituloCena.Navegar();
			TelaCapituloCena.SelecionarCapitulosCenasDecupadas("6666");
			TelaCapituloCena.SelecionarCapitulosCenasDecupadas("0400");
			TelaCapituloCena.ImprimirOpcaoCapituloTextoCena();
		}

		[When(@"eu validar impressao listagem basica - Listagem por capitulo")]
		public void QuandoEuValidarImpressaoListagemBasia_ListagemPorCapitulo()
		{
			//TelaCapituloCena.Navegar();
			TelaCapituloCena.SelecionarCapitulosCenasDecupadas("6666");
			TelaCapituloCena.SelecionarCapitulosCenasDecupadas("0400");
			TelaCapituloCena.ImprimirListagemPorCapitulos();
		}


		[Then(@"eu visualizo pdf com as opcoes com sucesso")]
		public void EntaoEuVisualizoPdfComAsOpcoesComSucesso()
		{
			TelaCapituloCena.VerificarAPagarPDF();
		}
	}
}
