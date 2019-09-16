using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class FiltrosCenariosSteps
	{
		public CenarioPage TelaCenario { get; private set; }

		public FiltrosCenariosSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);
		}

		[Given(@"que eu criar dois cenarios")]
		public void DadoQueEuCriarDoisCenarios()
		{
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
			TelaCenario.SalvarNovoCenario();
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO DOIS");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"filtrar por cenario")]
		public void QuandoFiltrarPorCenario()
		{
			TelaCenario.FiltrarCenario("INM ESTUDIO");
		}

		[When(@"filtrar dois cenarios")]
		public void QuandoFiltrarDoisCenarios()
		{
			TelaCenario.FiltrarDoisCenarios("INM ESTUDIO", "INM ESTUDIO DOIS");
		}

		[When(@"filtrar por ambiente")]
		public void QuandoFiltrarPorAmbiente()
		{
			TelaCenario.FiltrarAmbiente("INM AMBIENTE");
		}

		[Given(@"que eu criar um novo cenario cidade cenografica")]
		public void DadoQueEuCriarUmNovoCenarioCidadeCenografica()
		{
			TelaCenario.CriarNovoCenario("CIDADE", "INM ESTUDIO");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"filtrar por tipo - cidade cenografica")]
		public void QuandoFiltrarPorTipo_CidadeCenografica()
		{
			TelaCenario.FiltrarPorTipo("Cidade Cenográfica");
			TelaCenario.FiltrarCenario("INM ESTUDIO");
		}

		[Given(@"que eu criar um novo cenario estudio")]
		public void DadoQueEuCriarUmNovoCenarioEstudio()
		{
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"filtrar por tipo - estudio")]
		public void QuandoFiltrarPorTipo_Estudio()
		{
			TelaCenario.FiltrarPorTipo("Estúdio");
			TelaCenario.FiltrarCenario("INM ESTUDIO");
		}

		[Given(@"que eu criar um novo cenario tipo externo")]
		public void DadoQueEuCriarUmNovoCenarioTipoExterno()
		{
			TelaCenario.CriarNovoCenario("LOCACAO", "INM ESTUDIO");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"filtrar por tipo - externa")]
		public void QuandoFiltrarPorTipo_Externa()
		{
			TelaCenario.FiltrarPorTipo("Externa");
			TelaCenario.FiltrarCenario("INM ESTUDIO");
		}

		[Then(@"visualizo cenario filtrado com sucesso")]
		public void EntaoVisualizoCenarioFiltradoComSucesso()
		{
			TelaCenario.VerificarFiltroCenario("INM ESTUDIO");
		}

		[Then(@"visualizo os dois cenario filtrados com sucesso")]
		public void EntaoVisualizoOsDoisCenarioFiltradosComSucesso()
		{
			TelaCenario.VerificarFiltroCenario("INM ESTUDIO");
			TelaCenario.ExcluirCenario("INM ESTUDIO DOIS");
		}
	}
}
