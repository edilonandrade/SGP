using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ExcluirAmbienteSteps
	{
		public CenarioPage TelaCenario { get; private set; }

		public ExcluirAmbienteSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);

		}


		[When(@"excluir o ambiente")]
		public void QuandoExcluirOAmbiente()
		{
			TelaCenario.ExcluirAmbiente("INM ESTUDIO");
		}

		[Then(@"visualizo ambiente excluido com sucesso")]
		public void EntaoVisualizoAmbienteExcluidoComSucesso()
		{
			TelaCenario.VerificarExclusaoAmbiente("Nenhum ambiente cadastrado");
			//TelaCenario.ExcluirCenario("INM CENARIO");
		}
	}
}
