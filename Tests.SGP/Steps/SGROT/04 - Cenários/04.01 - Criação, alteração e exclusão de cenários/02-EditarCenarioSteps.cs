using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class EditarCenarioSteps
	{
		public CenarioPage TelaCenario { get; private set; }

		public EditarCenarioSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);

		}

		[When(@"editar cenario - tipo cenario")]
		public void QuandoEditarCenario_TipoCenario()
		{
			TelaCenario.FiltrarCenario("INM ESTUDIO");
			TelaCenario.EditarCenario("CENARIO", "INM CENARIO EDIT");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"editar cenario - tipo locacao")]
		public void QuandoEditarCenario_TipoLocacao()
		{
			TelaCenario.FiltrarCenario("INM ESTUDIO");
			TelaCenario.EditarCenario("LOCACAO", "INM CENARIO EDIT");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"editar cenario - tipo cidade cenografica")]
		public void QuandoEditarCenario_TipoCidadeCenografica()
		{
			TelaCenario.FiltrarCenario("INM ESTUDIO");
			TelaCenario.EditarCenario("CIDADE", "INM CENARIO EDIT");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"editar cenario - adicionar ambiente")]
		public void QuandoEditarCenario_AdicionarAmbiente()
		{
			TelaCenario.FiltrarCenario("INM ESTUDIO");
			TelaCenario.EditarCenario("CENARIO", "INM CENARIO EDIT");
			TelaCenario.CriarNovoAmbiente("INM AMBIENTE");
			TelaCenario.SalvarNovoCenario();
		}


		[Then(@"visualizo cenario atualizado com sucesso")]
		public void EntaoVisualizoCenarioAtualizadoComSucesso()
		{
			TelaCenario.VerificarAtualizacaoCenario("Cenário atualizado com Sucesso");
			TelaCenario.ExcluirCenarioEditado("INM CENARIO EDIT");
		}
	}
}
