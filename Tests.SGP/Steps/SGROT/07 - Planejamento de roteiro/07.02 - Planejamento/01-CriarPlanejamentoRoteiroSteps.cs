using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP
{
	[Binding]
	public sealed class CriarPlanejamentoRoteiroSteps
	{
		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
		public CriarPlanejamentoRoteiroSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
		}

		[When(@"criar um planejamento de roteiro")]
		public void QuandoCriarUmPlanejamentoDeRoteiro()
		{
			TelaPlanejamentoRoteiro.Navegar();
			TelaPlanejamentoRoteiro.CriarPlanejamentoRoteiro(CalendarioHelper.ObterDataAtual(), "0400/001", "2");
		}

		[When(@"salvar versao de planejamento")]
		public void QuandoSalvarVersaoDePlanejamento()
		{
			TelaPlanejamentoRoteiro.SalvarPlanejamento();
		}

		[When(@"criar um planejamento de roteiro com duas frentes")]
		public void QuandoCriarUmPlanejamentoDeRoteiroComDuasFrentes()
		{
			TelaPlanejamentoRoteiro.Navegar();
			//TelaPlanejamentoRoteiro.CriarFrenteExterna(CalendarioHelper.ObterDataAtual(), "0400/001", "2");
            TelaPlanejamentoRoteiro.CriarFrenteEstudio(CalendarioHelper.ObterDataAtual(), "0400/002", "2");
            //TelaPlanejamentoRoteiro.LiberarRoteiroDuasFrentes();
            TelaPlanejamentoRoteiro.LiberarRoteiro();
		}

		[When(@"eu incluir recurso de roteiro")]
		public void QuandoEuIncluirRecursoDeRoteiro()
		{
			TelaPlanejamentoRoteiro.IncluirRecursoRoteiro(CalendarioHelper.ObterDataAtual(), "Recursos", "INMETRICS TESTE");
		}

		[When(@"eu incluir frequencia de elenco")]
		public void QuandoEuIncluirFrequenciaDeElenco()
		{
			TelaPlanejamentoRoteiro.IncluirFrequenciaElenco(CalendarioHelper.ObterDataAtual(), "Frequência do Elenco", "08:00", "13:00", "14:00", "17:00");
		}

		[Then(@"visualizo frequencia de elenco com sucesso")]
		public void EntaoVisualizoFrequenciaDeElencoComSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarFrequenciaElenco("Frequência do Elenco salva com sucesso.");
		}

		[Then(@"visualizo recurso de roteiro com sucesso")]
		public void EntaoVisualizoRecursoDeRoteiroComSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarRecursosRoteiro("Recursos", "INMETRICS TESTE");
		}

		[Then(@"visualizo as duas frentes criadas com sucesso")]
		public void EntaoVisualizoAsDuasFrentesCriadasComSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarCriacaoFrente();
		}

		[Then(@"visualizo roteiro criado com sucesso")]
		public void EntaoVisualizoRoteiroCriadoComSucesso()
		{
			TelaPlanejamentoRoteiro.ValidarPlanejamentoRoteiro("0400/001");
			//TelaPlanejamentoRoteiro.ExcluirVersaoPlanejamento();
		}
	}
}
