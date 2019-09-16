using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ExcluirCenarioSteps
	{
		public CenarioPage TelaCenario { get; private set; }

		public ExcluirCenarioSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);

		}

		[When(@"eu excluir cenario")]
		public void QuandoEuExcluirCenario()
		{
			TelaCenario.ExcluirCenario("INM ESTUDIO");
		}

		[Then(@"visualizo cenario excluido com sucesso")]
		public void EntaoVisualizoCenarioExcluidoComSucesso()
		{
			TelaCenario.VerificarExclusaoCenario("Cenário excluido com sucesso");
		}
	}
}
