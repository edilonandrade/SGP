using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{

	[Binding]
	public sealed class CriarNovoCenarioSteps
	{
		public CenarioPage TelaCenario { get; private set; }

		public CriarNovoCenarioSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);

		}

		[Given(@"que eu navegue para a Tela de Cenario")]
		public void DadoQueEuNavegueParaaTelaCenario()
		{
			TelaCenario.Navegar();
		}

		[Given(@"que eu criar um novo cenario com ambiente")]
		public void DadoQueEuCriarUmNovoCenarioComAmbiente()
		{
			//TelaCenario.AbrirTelaCenario();
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
			TelaCenario.CriarNovoAmbiente("INM AMBIENTE");
			TelaCenario.SalvarNovoCenario();
		}

		[Given(@"que eu criar um novo cenario")]
		public void DadoQueEuCriarUmNovoCenario()
		{
			//TelaCenario.AbrirTelaCenario();
			TelaCenario.Navegar();
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"criar um novo cenario - tipo cenario")]
		public void QuandoCriarUmNovoCenario_TipoCenario()
		{
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
		}

		[When(@"criar um novo cenario - tipo locacao")]
		public void QuandoCriarUmNovoCenario_TipoLocacao()
		{
			TelaCenario.CriarNovoCenario("LOCACAO", "INM ESTUDIO");
		}

		[When(@"criar um novo cenario - tipo cidade cenografica")]
		public void QuandoCriarUmNovoCenario_TipoCidadeCenografica()
		{
			TelaCenario.CriarNovoCenario("CIDADE", "INM ESTUDIO");
		}

		[When(@"adicionar novo ambiente")]
		public void QuandoAdicionarNovoAmbiente()
		{
			TelaCenario.CriarNovoAmbiente("INM AMBIENTE");
			TelaCenario.SalvarNovoCenario();
		}

		[When(@"criar um novo cenario e salvar para criar outro cenario")]
		public void QuandoCriarUmNovoCenarioESalvarParaCriarOutroCenario()
		{
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
			TelaCenario.CriarOutroCenario("LOCACAO", "INM LOCACAO");
			TelaCenario.SalvarNovoCenario();
			TelaCenario.ExcluirCenario("INM LOCACAO");
		}

		[When(@"associar ao PDS")]
		public void QuandoAssociarAoPDS()
		{
			TelaCenario.AssociarPDS("NUCLEO POLICIAL");
		}

		[When(@"associar ao PDS existente")]
		public void QuandoAssociarAoPDSExistente()
		{
			TelaCenario.AssociarPDS("NÚCLEO POBRE");
		}

		[Then(@"visualizo cenario salvo com sucesso")]
		public void EntaoVisualizoCenarioSalvoComSucesso()
		{
			TelaCenario.VerificarInclusaoCenario("Inserido com sucesso");
		}

		[Then(@"visualizo cenarios sao incluidos com sucesso")]
		public void EntaoVisualizoCenariosSaoIncluidosComSucesso()
		{
			TelaCenario.VerificarExclusaoCenario("Cenário excluido com sucesso");
		}

		[Then(@"visualizo critica do PDS com sucesso")]
		public void EntaoVisualizoCriticaDoPDSComSucesso()
		{
			TelaCenario.VerificarCriticaPDS();
		}
	}
}

