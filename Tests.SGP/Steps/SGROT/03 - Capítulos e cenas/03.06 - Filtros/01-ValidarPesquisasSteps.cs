using TechTalk.SpecFlow;
using Project.SGP.Pages;
using System.Configuration;
using Framework.Core.Interfaces;
using Framework.Core.Helpers;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ValidarPesquisasSteps
	{
		public CapitulosCenasPage TelaCapituloCena { get; private set; }
		public PersonagemPage TelaPersonagem { get; private set; }
		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
		public CenarioPage TelaCenario { get; private set; }
		public RoteiroPage TelaRoteiro { get; private set; }

		public ValidarPesquisasSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);

			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
				ConfigurationManager.AppSettings["CapituloCenaURL"],
				ConfigurationManager.AppSettings["IncluirAdendoURL"],
				ConfigurationManager.AppSettings["IncluirCapituloURL"]);

			TelaCenario = new CenarioPage((IBrowser)browser,
				ConfigurationManager.AppSettings["CenarioURL"]);

			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);

			TelaRoteiro = new RoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["RoteiroURL"],
				ConfigurationManager.AppSettings["CapituloCenaURL"]);
		}

		[When(@"filtrar por capitulos")]
		public void QuandoFiltrarPorCapitulos()
		{
			TelaCapituloCena.FiltrarCapitulos("capituloDe", "0400");
		}

		[When(@"filtrar por capitulos com intervalo")]
		public void QuandoFiltrarPorCapitulosComIntervalo()
		{
			TelaCapituloCena.FiltrarIntervaloCapitulos("capituloDe", "0400");
		}

		[When(@"filtrar por capitulos e cenas")]
		public void QuandoFiltrarPorCapitulosECenas()
		{
			TelaCapituloCena.FiltrarCapitulosIntervaloCenas("capituloDe", "cenaDe", "0400", "001");
		}

		[When(@"filtrar por capitulos e intervalo de cenas")]
		public void QuandoFiltrarPorCapitulosEIntervaloDeCenas()
		{
			TelaCapituloCena.FiltrarCapitulosIntervaloCenas("capituloDe", "cenaDe", "0400", "001");
		}

		[Given(@"filtrar capitulo por datas de roteitros")]
		public void DadoFiltrarCapituloPorDatasDeRoteitros()
		{
			//TelaCapituloCena.FiltrarCapitulosDatasRoteiros("dataRoteiroDe", CalendarioHelper.ObterDataFutura(1));

			TelaCapituloCena.FiltrarCapitulosDatasRoteiros("dataRoteiroDe", CalendarioHelper.ObterDataAtual());

		}

		[When(@"filtrar capitulos por categoria")]
		public void QuandoFiltrarCapitulosPorCategoria()
		{
			TelaCapituloCena.FiltrarCapitulosCategoria("Normal");
		}

		[When(@"filtrar capitulos por cenario")]
		public void QuandoFiltrarCapitulosPorCenario()
		{
			TelaCapituloCena.FiltrarCapitulosCenario("INMETRICS ESTUDIO");
		}

		[When(@"filtrar capitulos por cenario e ambiente")]
		public void QuandoFiltrarCapitulosPorCenarioEAmbiente()
		{
			TelaCapituloCena.FiltrarCapitulosCenarioAmbiente("INMETRICS ESTUDIO", "INMETRICS AMBIENTE");
		}

		[Given(@"filtrar capitulos por numeros de roteiros")]
		public void DadoFiltrarCapitulosPorNumerosDeRoteiros()
		{
			TelaRoteiro.PegarNumeroRoteiroAndFiltrarCapitulo("roteiroDe");
		}

		[When(@"filtrar capitulos por status")]
		public void QuandoFiltrarCapitulosPorStatus()
		{
			TelaCapituloCena.FiltrarCapitulosStatus("Decupada");
		}

		[When(@"filtrar capitulos por tipo")]
		public void QuandoFiltrarCapitulosPorTipo()
		{
			TelaCapituloCena.FiltrarCapitulosTipo("Externa");
		}

		[When(@"filtrar capitulos com dois campos")]
		public void QuandoFiltrarCapitulosComDoisCampos()
		{
			TelaCapituloCena.FiltrarCapitulosDoisCampos("capituloDe", "0400", "Normal");
		}

		[When(@"filtrar capitulos com tres campos")]
		public void QuandoFiltrarCapitulosComTresCampos()
		{
			TelaCapituloCena.FiltrarCapitulosTresCampos("capituloDe", "0400", "cenaDe", "001", "Normal");
		}

		[When(@"filtrar capitulos com materias e marcacao de cena")]
		public void QuandoFiltrarCapitulosComMateriasEMarcacaoDeCena()
		{
			TelaCapituloCena.FiltrarCapitulos("capituloDe", "6666");
			TelaCapituloCena.FiltrarCapitulosMatMarcCena("Sim");
		
		}

		[When(@"filtrar capitulos por capitulo secreto")]
		public void QuandoFiltrarCapitulosPorCapituloSecreto()
		{
			TelaCapituloCena.FiltrarCapitulosCenasSecretas("Apenas capítulos secretos");
		}

		[When(@"filtrar capitulos por cena secreta")]
		public void QuandoFiltrarCapitulosPorCenaSecreta()
		{
			TelaCapituloCena.FiltrarCapitulosCenasSecretas("Apenas cenas secretas");
		}

		[When(@"filtrar capitulos por capitulo e cena opcao todos")]
		public void QuandoFiltrarCapitulosPorCapituloECenaOpcaoTodos()
		{
			TelaCapituloCena.FiltrarCapitulosCenasSecretas("Todos os capítulos");
		}

		[When(@"filtrar capitulos por material prioritario")]
		public void QuandoFiltrarCapitulosPorMaterialPrioritario()
		{
			TelaCapituloCena.FiltrarCapitulosMatPrioritario("Sim");
		}

		[When(@"filtrar capitulos por classificacao")]
		public void QuandoFiltrarCapitulosPorClassificacao()
		{
			TelaCapituloCena.FiltrarCapitulosClassificacao("Ação");
		}

		[When(@"filtrar capitulos por personagem")]
		public void QuandoFiltrarCapitulosPorPersonagem()
		{
			TelaCapituloCena.FiltrarCapitulosPersonagem("INMETRICS PERSONAGEM");
		}

		[When(@"filtrar capitulos por figurante")]
		public void QuandoFiltrarCapitulosPorFigurante()
		{
			TelaCapituloCena.FiltrarCapitulosFigurante("FIGURANTES");
		}

		[When(@"filtrar capitulos por periodo do dia")]
		public void QuandoFiltrarCapitulosPorPeriodoDoDia()
		{
			TelaCapituloCena.FiltrarCapitulosPeriodoDoDia("Dia");
		}

		[When(@"filtrar capitulos por tipo do cenario")]
		public void QuandoFiltrarCapitulosPorTipoDoCenario()
		{
			TelaCapituloCena.FiltrarCapitulosTipoCenario("Todos");
		}

		[Then(@"visualizo a pesquisa escolhida com sucesso")]
		public void EntaoVisualizoAPesquisaEscolhidaComSucesso()
		{
			TelaCapituloCena.VerificarFiltro("capituloDe", "0400");
		}

		[Then(@"visualizo a pesquisa de materias de cena escolhido com sucesso")]
		public void EntaoVisualizoAPesquisaDeMateriasDeCenaEscolhidoComSucesso()
		{
			TelaCapituloCena.VerificarFiltro("capituloDe","6666");
		}
	}
}
