using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
	[Binding]
	public sealed class MovimentarCenaSteps
	{
		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
		public CapitulosCenasPage TelaCapituloCena { get; private set; }

		public MovimentarCenaSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);

			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CapituloCenaURL"],
			   ConfigurationManager.AppSettings["IncluirCapituloURL"],
			   ConfigurationManager.AppSettings["IncluirAdendoURL"]);
		}

		[Given(@"que eu selecione um capitulo e cena")]
		public void DadoQueEuSelecioneUmCapituloECena()
		{
			TelaDecupagemBasica.SelecionarCapituloCenaMovimentar("0400", "002");
		}

		[When(@"movimentar ou alterar capitulo ou cena existente")]
		public void QuandoMovimentarOuAlterarCapituloOuCenaExistente()
		{
			TelaDecupagemBasica.MovimentarCapituloCena("0400", "002");
		}

		[When(@"movimentar ou alterar capitulo ou cena nao existente")]
		public void QuandoMovimentarOuAlterarCapituloOuCenaNaoExistente()
		{
			TelaDecupagemBasica.MovimentarCapituloCena("0400", "050");
		}

		[Then(@"eu visualizo cena existente movimentada com sucesso")]
		public void EntaoEuVisualizoCenaExistenteMovimentadaComSucesso()
		{
			TelaDecupagemBasica.VerificarAlertaMovimentarCena("Já existe uma cena com esse número no capítulo/pacote destino");
			TelaCapituloCena.Navegar();
		}

		[Then(@"eu visualizo cena nao existente movimentada com sucesso")]
		public void EntaoEuVisualizoCenaNaoExistenteMovimentadoComSucesso()
		{
			TelaDecupagemBasica.VerificarMovimentarCena("050");
			TelaCapituloCena.Navegar();
		}
	}
}
