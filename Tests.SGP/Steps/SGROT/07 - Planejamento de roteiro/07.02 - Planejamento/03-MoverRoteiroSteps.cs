using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class MoverRoteiroSteps
	{
		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
		public MoverRoteiroSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
		}

		[When(@"mover roteiro para outro dia")]
		public void QuandoMoverRoteiroParaOutroDia()
		{
			TelaPlanejamentoRoteiro.MoverRoteiroParaOutroDia(CalendarioHelper.ObterDataAtual(), "Mover", "0", CalendarioHelper.ObterDiaFuturo(1));
		}

		[Then(@"visualizo roteiro movido para outro dia com sucesso")]
		public void EntaoVisualizoRoteiroMovidoParaOutroDiaComSucesso()
		{
			TelaPlanejamentoRoteiro.ValidarMoverRoteiro(CalendarioHelper.ObterDataFutura(1).ToString());
			TelaPlanejamentoRoteiro.VoltarDataAtualRoteiro(CalendarioHelper.ObterDataFutura(1), "Mover", "0", CalendarioHelper.ObterDiaAtual());
		}
	}
}
