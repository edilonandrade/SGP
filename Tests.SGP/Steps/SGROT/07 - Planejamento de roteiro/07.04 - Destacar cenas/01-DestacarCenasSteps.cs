using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class DestacarCenasSteps
	{

		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
		public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }

		public DestacarCenasSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
				ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);
		}


		[When(@"destacar cenas por cena")]
		public void QuandoDestacarCenasPorCena()
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			TelaPlanejamentoRoteiro.DestacarCena(CalendarioHelper.ObterDataAtual().ToString(), "filtroCenas", "0400/001");
		}

		[When(@"destacar cenas por tipo")]
		public void QuandoDestacarCenasPorTipo()
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			TelaPlanejamentoRoteiro.DestacarCena(CalendarioHelper.ObterDataAtual().ToString(), "filtroTipos", "Externa");
		}

		[When(@"destacar cenas por cenario ou locacao")]
		public void QuandoDestacarCenasPorCenarioOuLocacao()
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			TelaPlanejamentoRoteiro.DestacarCena(CalendarioHelper.ObterDataAtual().ToString(), "filtroCenarios", "INMETRICS LOCACAO");
		}

		[When(@"destacar cenas por personagem")]
		public void QuandoDestacarCenasPorPersonagem()
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			TelaPlanejamentoRoteiro.DestacarPersonagem(CalendarioHelper.ObterDataAtual().ToString(), "INMETRICS PERSONAGEM");
		}

		[Given(@"modificar o status da cena")]
		public void DadoModificarOStatusDaCena()
		{
			TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Gravada Parte");
		}

		[When(@"destacar cenas por status")]
		public void QuandoDestacarCenasPorStatus()
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			TelaPlanejamentoRoteiro.Navegar();
			TelaPlanejamentoRoteiro.DestacarCena(CalendarioHelper.ObterDataAtual().ToString(), "filtroStatus", "Gravada Parte");
		}

		[When(@"destacar cenas por periodo do dia")]
		public void QuandoDestacarCenasPorPeriodoDoDia()
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			TelaPlanejamentoRoteiro.DestacarCena(CalendarioHelper.ObterDataAtual().ToString(), "filtroPeriodoDoDia", "DIA");
		}

		[Then(@"visualizo cena destacada")]
		public void EntaoVisualizoCenaDestacada()
		{
			TelaPlanejamentoRoteiro.VerificarDestaqueCena("0400/001");
		}

		[Then(@"visualizo cena destacada por status")]
		public void EntaoVisualizoCenaDestacadaPorStatus()
		{
			TelaPlanejamentoRoteiro.VerificarDestaqueCenaStatus("0400/001");
		}
	}
}
