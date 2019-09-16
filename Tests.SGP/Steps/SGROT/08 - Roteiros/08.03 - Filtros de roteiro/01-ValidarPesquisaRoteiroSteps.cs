using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ValidarPesquisaRoteiroSteps
	{

		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
		public RoteiroPage TelaRoteiro { get; private set; }

		public ValidarPesquisaRoteiroSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaRoteiro = new RoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["RoteiroURL"],
				ConfigurationManager.AppSettings["CapituloCenaURL"]);
		}

		[When(@"filtrar por data de inicio de gravacao")]
		public void QuandoFiltrarPorDataDeInicioDeGravacao()
		{
			TelaRoteiro.FiltrarDataGravacao();
		}

		[When(@"filtrar por intervalo de data de gravacao")]
		public void QuandoFiltrarPorIntervaloDeDataDeGravacao()
		{
			TelaRoteiro.FiltrarIntervaloDataGravacao();
		}

		[When(@"filtrar por numero do roteiro")]
		public void QuandoFiltrarPorNumeroDoRoteiro()
		{
			TelaRoteiro.Navegar();
			TelaRoteiro.PegarNumeroRoteiroAndFiltrarRoteiro();
		}

		[When(@"filtrar por intervalo de roteiro")]
		public void QuandoFiltrarPorIntervaloDeRoteiro()
		{
			TelaRoteiro.Navegar();
			TelaRoteiro.FiltrarIntervaloRoteiro();
		}

		[When(@"filtrar por tipo")]
		public void QuandoFiltrarPorTipo()
		{
			TelaRoteiro.FiltrarPorTipo("2"); //Externa
		}

		[When(@"filtrar por cenario do roteiro")]
		public void QuandoFiltrarPorCenarioDoRoteiro()
		{
			TelaRoteiro.FiltrarPorCenario("INMETRICS EXTERNA - EXT");
		}

		[When(@"filtrar por status do roteiro")]
		public void QuandoFiltrarPorStatusDoRoteiro()
		{
			TelaRoteiro.FiltrarPorStatus("Liberado");
		}

		[Then(@"visualizo filtro por status do roteiro com sucesso")]
		public void EntaoVisualizoFiltroPorStatusDoRoteiroComSucesso()
		{
			TelaRoteiro.VerificarStatusRoteiro("Liberado");
		}


		[Then(@"visualizo filtro por cenario do roteiro com sucesso")]
		public void EntaoVisualizoFiltroPorCenarioDoRoteiroComSucesso()
		{
			TelaRoteiro.VerificarCenarioRoteiro("INMETRICS EXTERNA");
		}

		[Then(@"visualizo filtro por tipo do roteiro com sucesso")]
		public void EntaoVisualizoFiltroPorTipoDoRoteiroComSucesso()
		{
			TelaRoteiro.VerificarTipoRoteiro("Externa");
		}

		[Then(@"visualizo filtro por numero do roteiro com sucesso")]
		public void EntaoVisualizoFiltroPorNumeroDoRoteiroComSucesso()
		{
			TelaRoteiro.VerificarNumeroRoteiro();
		}

		[Then(@"visualizo filtro de intervalo de gravacao realizado com sucesso")]
		public void EntaoVisualizoFiltroDeIntervaloDeGravacaoRealizadoComSucesso()
		{
			TelaRoteiro.VerificarFiltroDataGravacao(CalendarioHelper.ObterMesFuturo(0));
		}

		[Then(@"visualizo filtro de data inicio de gravacao realizado com sucesso")]
		public void EntaoVisualizoFiltroDeDataInicioDeGravacaoRealizadoComSucesso()
		{
			TelaRoteiro.VerificarFiltroDataGravacao(CalendarioHelper.ObterDataAtual());
		}
	}
}
