using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class EditarAmbienteSteps
	{
		public CenarioPage TelaCenario { get; private set; }

		public EditarAmbienteSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);

		}

		[When(@"editar o ambiente")]
		public void QuandoEditarOAmbiente()
		{
			TelaCenario.FiltrarCenario("INM ESTUDIO");
			TelaCenario.EditarAmbiente("INM AMBIENTE EDIT");
			TelaCenario.SalvarNovoCenario();
		}

		[Then(@"visualizo ambiente editado com sucesso")]
		public void EntaoVisualizoAmbienteEditadoComSucesso()
		{
			TelaCenario.VerificarAtualizacaoCenario("Cenário atualizado com Sucesso");
			//TelaCenario.ExcluirCenario("INM CENARIO");
		}
	}
}
