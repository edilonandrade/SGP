using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CancelarPlanejamentoSteps
	{
		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
		public CancelarPlanejamentoSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
		}

		[When(@"cancelar planejamento de roteiro")]
		public void QuandoCancelarPlanejamentoDeRoteiro()
		{
			TelaPlanejamentoRoteiro.CancelarRoteiro(CalendarioHelper.ObterDataAtual());
		}

		[When(@"excluir versao de planejamento")]
		public void QuandoExcluirVersaoDePlanejamento()
		{
			TelaPlanejamentoRoteiro.ExcluirVersaoPlanejamento();
		}

		[Then(@"visualizo versao de planejamento excluida com sucesso")]
		public void EntaoVisualizoVersaoDePlanejamentoExcluidaComSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarExclusãoCarregamentoPlanejamento("Não existe nenhuma versão do planejamento para este programa.");
		}

		[Then(@"visualizo roteiro cancelado com sucesso")]
		public void EntaoVisualizoRoteiroCanceladoComSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarCancelarRoteiro();
		}
	}
}
