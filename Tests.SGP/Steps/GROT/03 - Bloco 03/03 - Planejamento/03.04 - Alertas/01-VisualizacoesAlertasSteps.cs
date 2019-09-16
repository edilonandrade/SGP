using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
	[Binding]
	public sealed class VisualizacoesAlertasSteps
	{
		public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
		public ParametrosPage TelaParametros { get; private set; }
		public CapitulosCenasPage TelaCapituloCena { get; private set; }

		public HomePage TelaHome { get; private set; }
        public IndisponibilidadeLocaisPage TelaIndisponibilidadeLocais { get; private set; }


        public VisualizacoesAlertasSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

			TelaParametros = new ParametrosPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["ParametrosURL"]);

			TelaHome = new HomePage((IBrowser)browser,
				ConfigurationManager.AppSettings["HomeURL"],
				ConfigurationManager.AppSettings["FotosURL"],
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CapituloCenaURL"],
			   ConfigurationManager.AppSettings["IncluirCapituloURL"],
			   ConfigurationManager.AppSettings["IncluirAdendoURL"]);

            TelaIndisponibilidadeLocais = new IndisponibilidadeLocaisPage((IBrowser)browser,
                ConfigurationManager.AppSettings["IndisponibilidadeLocal"]);
		}

		[Given(@"que eu preencha o dia de antecedencia na tela de parametro")]
		public void DadoQueEuPreenchaODiaDeAntecedenciaNaTelaDeParametro()
		{
			TelaHome.AcessarMenuList("Parâmetros de Produção");
			TelaParametros.PreencherDiasAntecedencia("2");
		}

		[Given(@"que eu esteja com um novo planejamento de roteiro realizado")]
		public void DadoQueEuEstejaComUmNovoPlanejamentoDeRoteiroRealizado()
		{
			TelaPlanejamentoGROT.Navegar();
			TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/003", "2");
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

        [Given(@"que eu tenha uma indisponibilidade de local")]
        public void DadoQueEuTenhaUmaIndisponibilidadeDeLocal()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaIndisponibilidadeLocais.Navegar();
            //TelaLocal.CadastrarIndisponibilidadeLocal("INMETRICS LOCAL");
            //TelaLocal.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL");
        }

        [Given(@"que eu salvo um rascunho de roteiro com tres cenas")]
        public void DadoQueEuSalvoUmRascunhoDeRoteiroComTresCenas()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0500/003", "1");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0500/004", "1");
            TelaPlanejamentoGROT.SalvarRascunhoRoteiro("RASCUNHO 1");
        }

        [Given(@"que eu altero a data de exibicao do capitulo")]
        public void DadoQueEuAlteroADataDeExibicaoDoCapitulo()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");
        }

        [When(@"criar um planejamento de roteiro GROT")]
        public void QuandoCriarUmPlanejamentoDeRoteiroGROT()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu abro o rascunho e arrasto uma cena para outro dia da frente e salvo como outro rascunho")]
        public void QuandoEuAbroORascunhoEArrastoUmaCenaParaOutroDiaDaFrenteESalvoComoOutroRascunho()
        {
            TelaPlanejamentoGROT.ExpandirCenasDeRoteiro();
            TelaPlanejamentoGROT.DragAndDropCenaExterna("0500/004", "1");
            TelaPlanejamentoGROT.SalvarRascunhoRoteiro("RASCUNHO 2");
        }

        [When(@"eu abro o primeiro rascunho e libero o roteiro")]
        public void QuandoEuAbroOPrimeiroRascunhoELiberoORoteiro()
        {
            TelaPlanejamentoGROT.AbrirRascunho("RASCUNHO 1");
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu abro o segundo rascunho e libero o roteiro")]
        public void QuandoEuAbroOSegundoRascunhoELiberoORoteiro()
        {
            TelaPlanejamentoGROT.AbrirRascunho("RASCUNHO 2");
        }

        [When(@"eu editar data de exibicao do capitulo e criar um roteiro com cena de capitulo baixo")]
        public void QuandoEuEditarDataDeExibicaoDoCapituloECriarUmRoteiroComCenaDeCapituloBaixo()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.ExpandirTodasCenas();
            TelaPlanejamentoGROT.ValidarCenaCapituloBaixo("0500/001");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro no local que tem indisponibilidade")]
        public void QuandoEuCriarUmRoteiroNoLocalQueTemIndisponibilidade()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

		[When(@"eu editar data de exibicao do capitulo e criar um roteiro")]
		public void QuandoEuEditarDataDeExibicaoDoCapituloECriarUmRoteiro()
		{
			//TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
			//TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");

			TelaPlanejamentoGROT.Navegar();
			TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

		[When(@"eu criar dois roteiros na mesma frente")]
		public void QuandoEuCriarDoisRoteirosNaMesmaFrente()
		{
			TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
			TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/005", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/006", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

		[When(@"eu preencher os horarios de um roteiro e o horario de chegada do personagem")]
		public void QuandoEuPreencherOsHorariosDeUmRoteiroEOHorarioDeChegadaDoPersonagem()
		{
			TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "12:00", "14:00", "10:00", 1);
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

		[When(@"eu criar um roteiro um dia depois da exibicao do capitulo")]
		public void QuandoEuCriarUmRoteiroUmDiaDepoisDaExibicaoDoCapitulo()
		{
			TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
			TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

			TelaPlanejamentoGROT.Navegar();
			TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataFutura(1), "0501/004", "2");
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

		[When(@"eu preencher os horarios de um roteiro para alerta de iluminacao")]
		public void QuandoEuPreencherOsHorariosDeUmRoteiroParaAlertaDeIluminacao()
		{
			TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "13:00", "14:00", "16:00", "18:00", "13:00", 1);
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

		[When(@"eu preencher os horarios de um roteiro para alerta de tempo de caracterizacao de elenco")]
		public void QuandoEuPreencherOsHorariosDeUmRoteiroParaAlertaDeTempoDeCaracterizacaoDeElenco()
		{
			TelaPlanejamentoGROT.Navegar();
			TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/003", "2");
			
			TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "00:00", "12:00", "08:30", 1);
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

		[When(@"eu preencher os horarios de um roteiro para nao alertar o tempo de caracterizacao de elenco")]
		public void QuandoEuPreencherOsHorariosDeUmRoteiroParaNaoAlertarOTempoDeCaracterizacaoDeElenco()
		{
			TelaPlanejamentoGROT.Navegar();
			TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/006", "2");

			TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "00:00", "12:00", "08:00", 1);
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

        [When(@"eu criar tres roteiros na mesma frente")]
        public void QuandoEuCriarTresRoteirosNaMesmaFrente()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/005", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/006", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

		[When(@"eu preencher a carga horaria diaria de uma frente para alertar a jornada da frente")]
		public void QuandoEuPreencherACargaHorariaDiariaDeUmaFrenteParaAlertarAJornadaDaFrente()
		{
			TelaPlanejamentoGROT.Navegar();
			TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/007", "2");

			TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "07:00", "08:00", "00:00", "12:00", "07:00", 1);
			//TelaPlanejamentoGROT.EditarCargaHorariaFrente("2");
			TelaPlanejamentoGROT.LiberarRoteiro();
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
		}

        [When(@"eu criar um roteiro com duas cenas longas sem horario de refeicao")]
        public void QuandoEuCriarUmRoteiroComDuasCenasLongasSemHorarioDeRefeicao()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/005", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com mais de dez horas sem refeicao de elenco")]
        public void QuandoEuCriarUmRoteiroComMaisDeDezHorasSemRefeicaoDeElenco()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/005", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/006", "1");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "22:00", "22:00", "08:00", 1);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro em cada frente no mesmo dia")]
        public void QuandoEuCriarUmRoteiroEmCadaFrenteNoMesmoDia()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanalFrente2(CalendarioHelper.ObterDataAtual(), "0501/005", "2", "Externa");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }
        
        [When(@"eu alterar o tempo minimo de interjoranda na frente")]
        public void QuandoEuAlterarOTempoMinimoDeInterjorandaNaFrente()
        {
            TelaPlanejamentoGROT.EditarFrenteDePlanejamento("20", "", "");
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com duas cenas de estudio")]
        public void QuandoEuCriarUmRoteiroComDuasCenasDeEstudio()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0502");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0502");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteEstudio(CalendarioHelper.ObterDataAtual(), "0502/003", "2");
            TelaPlanejamentoGROT.CriarFrenteEstudioDiario(CalendarioHelper.ObterDataAtual(), "0502/004", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu crio dois roteiros na mesma frente e altero o limite de dias de gravacao da frente")]
        public void QuandoEuCrioDoisRoteirosNaMesmaFrenteEAlteroOLimiteDeDiasDeGravacaoDaFrente()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/005", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.EditarFrenteDePlanejamento("", "1", "Sim");
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu crio um roteiro e altero o limite de dias de gravacao da frente para zero")]
        public void QuandoEuCrioUmRoteiroEAlteroOLimiteDeDiasDeGravacaoDaFrenteParaZero()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.EditarFrenteDePlanejamento("", "0", "Sim");
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu crio dois roteiros na mesma frente e altero o tempo minimo de interjoranda na frente")]
        public void QuandoEuCrioDoisRoteirosNaMesmaFrenteEAlteroOTempoMinimoDeInterjorandaNaFrente()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/005", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.EditarFrenteDePlanejamento("20", "", "");
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com duas cenas de locais diferentes")]
        public void QuandoEuCriarUmRoteiroComDuasCenasDeLocaisDiferentes()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/003", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0500/004", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com cena de estudio")]
        public void QuandoEuCriarUmRoteiroComCenaDeEstudio()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0502");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0502");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteEstudioDiario(CalendarioHelper.ObterDataAtual(), "0502/003", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com tres cenas curtas sem horario de refeicao")]
        public void QuandoEuCriarUmRoteiroComTresCenasCurtasSemHorarioDeRefeicao()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0500/002", "1");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0500/004", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com duas cenas de estudio que ultrapasse a jornada da frente")]
        public void QuandoEuCriarUmRoteiroComDuasCenasDeEstudioQueUltrapasseAJornadaDaFrente()
        {
            QuandoEuCriarUmRoteiroComDuasCenasDeEstudio();
        }

        [When(@"eu criar um roteiro com cenas de estudio e com chegada do ator apos o inicio da gravacao")]
        public void QuandoEuCriarUmRoteiroComCenasDeEstudioEComChegadaDoAtorAposOInicioDaGravacao()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0502");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0502");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteEstudioDiario(CalendarioHelper.ObterDataAtual(), "0502/001", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "12:00", "14:00", "10:00", 1);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com cena de cidade cenografica e com chegada do ator apos o inicio da gravacao")]
        public void QuandoEuCriarUmRoteiroComCenaDeCidadeCenograficaEComChegadaDoAtorAposOInicioDaGravacao()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "12:00", "14:00", "10:00", 4);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com cena externa e com chegada do ator apos o inicio da gravacao")]
        public void QuandoEuCriarUmRoteiroComCenaExternaEComChegadaDoAtorAposOInicioDaGravacao()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "12:00", "14:00", "10:00", 1);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com cena de estudio noturna fora da faixa de horario")]
        public void QuandoEuCriarUmRoteiroComCenaDeEstudioNoturnaForaDaFaixaDeHorario()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteEstudioDiarioNoturno(CalendarioHelper.ObterDataAtual(), "1000/024A", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "12:00", "14:00", "08:00", 2);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com cena diurna fora da faixa de horario")]
        public void QuandoEuCriarUmRoteiroComCenaDiurnaForaDaFaixaDeHorario()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0500/001", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "18:00", "19:00", "22:00", "23:59", "18:00", 1);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"eu criar um roteiro com cena noturna fora da faixa de horario")]
        public void QuandoEuCriarUmRoteiroComCenaNoturnaForaDaFaixaDeHorario()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0500");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0500");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiarioNoturno(CalendarioHelper.ObterDataAtual(), "0500/008", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "12:00", "14:00", "08:00", 1);
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"filtrar a frente por TODAS")]
        public void QuandoFiltrarAFrentePorTODAS()
        {
            TelaPlanejamentoGROT.FiltrarAlertasPorFrente("TODAS");
            TelaPlanejamentoGROT.ExpandirAlertas();
        }

        [When(@"alterar o filtro entre uma frente e outra")]
        public void QuandoAlterarOFiltroEntreUmaFrenteEOutra()
        {
            TelaPlanejamentoGROT.FiltrarAlertasPorFrente("FRENTE 1 - EXT");
            TelaPlanejamentoGROT.ExpandirAlertas();
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("REFEICAO_EQUIPE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("ANTECEDENCIA_MINIMA_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("FAIXA_HORARIO_CENA", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("JORNADA_FRENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("CAPITULO_BAIXO_DIA", "1");

            TelaPlanejamentoGROT.FiltrarAlertasPorFrente("FRENTE 2 - EXT");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("FAIXA_HORARIO_CENA", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("ANTECEDENCIA_MINIMA_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("REFEICAO_EQUIPE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("CAPITULO_BAIXO_DIA", "1");

            TelaPlanejamentoGROT.FiltrarAlertasPorFrente("TODAS");
        }

        [When(@"eu acessar a tela de planejamento do GROT")]
        public void QuandoEuAcessarATelaDePlanejamentoDoGROT()
        {
            TelaPlanejamentoGROT.Navegar();
        }

        [When(@"eu criar dois roteiros na mesma frente com interjornada de elenco")]
        public void QuandoEuCriarDoisRoteirosNaMesmaFrenteComInterjornadaDeElenco()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0501");
            TelaCapituloCena.EditarCapituloPreenchendoDataAtualExibicao("0501");

            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/005", "2");
            TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "01:00", "02:00", "00:00", "23:59", "01:00", 1);
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/006", "2");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [When(@"clicar no icone vai e vem dos dois roteiros")]
        public void QuandoClicarNoIconeVaiEVemDosDoisRoteiros()
        {
            TelaPlanejamentoGROT.ClicarIconeVaiEVem("2");
            TelaPlanejamentoGROT.ClicarIconeVaiEVem("5");
        }

        [Then(@"eu visualizo o pop up com as informacoes de cada roteiro com sucesso")]
        public void EntaoEuVisualizoOPopUpComAsInformacoesDeCadaRoteiroComSucesso()
        {
            TelaPlanejamentoGROT.ValidarIconeVaiEVem("2");
            TelaPlanejamentoGROT.ValidarIconeVaiEVem("5");
        }

        [Then(@"eu visualizo o campo historico com sucesso")]
        public void EntaoEuVisualizoOCampoHistoricoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarCampoHistorico();
        }

        [Then(@"eu visualizo alerta de cena com capitulo baixo com sucesso")]
        public void EntaoEuVisualizoAlertaDeCenaComCapituloBaixoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Esta cena está em um capítulo baixo em relação ao seu dia de gravação.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Esta cena está em um capítulo baixo em relação ao seu dia de gravação.", "1", 0);
        }

        [Then(@"eu visualizo o total de alertas gerados com sucesso")]
        public void EntaoEuVisualizoOTotalDeAlertasGeradosComSucesso()
        {
            TelaPlanejamentoGROT.ExpandirAlertas();
            TelaPlanejamentoGROT.ValidarTotalAlertas("14");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("REFEICAO_EQUIPE", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("ANTECEDENCIA_MINIMA_GRAVACAO", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("FAIXA_HORARIO_CENA", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("CAPITULO_BAIXO_DIA", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("MULTIPLA_ALOCACAO_AMBIENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("JORNADA_FRENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_CONFLITO_HORARIO_ELENCO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_NUMERO_MAX_DIAS", "1");
        }

        [Then(@"eu visualizo a sumarizacao de alertas de todas as frentes com sucesso")]
        public void EntaoEuVisualizoASumarizacaoDeAlertasDeTodasAsFrentesComSucesso()
        {
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("REFEICAO_EQUIPE", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("ANTECEDENCIA_MINIMA_GRAVACAO", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("FAIXA_HORARIO_CENA", "2");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("MULTIPLA_ALOCACAO_AMBIENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("JORNADA_FRENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_CONFLITO_HORARIO_ELENCO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_GRAVACAO", "1");
            //TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_NUMERO_MAX_DIAS", "1");
        }

        [Then(@"eu visualizo os tres alertas com maior incidencia com sucesso")]
        public void EntaoEuVisualizoOsTresAlertasComMaiorIncidenciaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("ANTECEDENCIA_MINIMA_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("FAIXA_HORARIO_CENA", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("REFEICAO_EQUIPE", "1");
        }

        [Then(@"eu visualizo os demais alertas com maior incidencia com sucesso")]
        public void EntaoEuVisualizoOsDemaisAlertasComMaiorIncidenciaComSucesso()
        {
            TelaPlanejamentoGROT.ExpandirAlertas();
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("JORNADA_FRENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_NUMERO_MAX_DIAS", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("CAPITULO_BAIXO_DIA", "1");
        }

        [Then(@"eu visualizo a sumarizacao de alertas por tipo com sucesso")]
        public void EntaoEuVisualizoASumarizacaoDeAlertasPorTipoComSucesso()
        {
            TelaPlanejamentoGROT.ExpandirAlertas();
            TelaPlanejamentoGROT.ValidarTotalAlertas("7");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("ANTECEDENCIA_MINIMA_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("FAIXA_HORARIO_CENA", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("CAPITULO_BAIXO_DIA", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("REFEICAO_EQUIPE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("JORNADA_FRENTE", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_GRAVACAO", "1");
            TelaPlanejamentoGROT.ValidarSumarizacaoAlerta("INDISPONIBILIDADE_FRENTE_NUMERO_MAX_DIAS", "1");
        }

        [Then(@"eu visualizo alerta de faixa de horario de gravacao com sucesso - diurno")]
        public void EntaoEuVisualizoAlertaDeFaixaDeHorarioDeGravacaoComSucesso_Diurno()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Horário de início da cena 0500/001 fora da faixa de horário estipulada na cena.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0500/001 fora da faixa de horário estipulada na cena.", "1", 0);
        }

        [Then(@"eu visualizo alerta de faixa de horario de gravacao com sucesso - noturno")]
        public void EntaoEuVisualizoAlertaDeFaixaDeHorarioDeGravacaoComSucesso_Noturno()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Horário de início da cena 0500/008 fora da faixa de horário estipulada na cena.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0500/008 fora da faixa de horário estipulada na cena.", "1", 0);
        }

        [Then(@"eu nao visualizo alerta de faixa de horario de gravacao com sucesso - estudio noturno")]
        public void EntaoEuNaoVisualizoAlertaDeFaixaDeHorarioDeGravacaoComSucesso_EstudioNoturno()
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertasNegativo("Horário de início da cena 0500/001 fora da faixa de horário estipulada na cena.", "1", 0);
        }

        [Then(@"eu visualizo alerta de tempo de preparacao de elenco com sucesso - estudio")]
        public void EntaoEuVisualizoAlertaDeTempoDePreparacaoDeElencoComSucesso_Estudio()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0502/001.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0502/001.", "1", 0);
        }

        [Then(@"eu visualizo alerta de tempo de preparacao de elenco com sucesso - externa")]
        public void EntaoEuVisualizoAlertaDeTempoDePreparacaoDeElencoComSucesso_Externa()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0500/001.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0500/001.", "1", 0);
        }

        [Then(@"eu visualizo alerta de tempo de preparacao de elenco com sucesso - cidade cenografica")]
        public void EntaoEuVisualizoAlertaDeTempoDePreparacaoDeElencoComSucesso_CidadeCenografica()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de preparação de GUILHERME PIVA violado para a cena 1000/025.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de preparação de GUILHERME PIVA violado para a cena 1000/025.", "1", 0);
        }

        [Then(@"eu visualizo alerta de jornada da frente com sucesso - estudio")]
        public void EntaoEuVisualizoAlertaDeJornadaDaFrenteComSucesso_Estudio()
        {
            TelaPlanejamentoGROT.ValidarAlertaJornadaMaxima("Jornada máxima diária da frente de gravação FRENTE 1 - EST violada em 01:30 horas no dia ", "1", 0);
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada máxima diária da frente de gravação FRENTE 1 - EST violada em 01:30 horas no dia ", "2", 0);
        }

        [Then(@"eu nao visualizo alerta de iluminacao com sucesso")]
        public void EntaoEuNaoVisualizoAlertaDeIluminacaoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaCenaNegativo("Horário da cena 0502/003 deve ser roteirizada no período de 06:00 às 12:00.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertasNegativo("Horário da cena 0502/003 deve ser roteirizada no período de 06:00 às 12:00.", "1", 0);
        }

        [Then(@"eu visualizo alerta de tempo de deslocamento com sucesso")]
        public void EntaoEuVisualizoAlertaDeTempoDeDeslocamentoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de deslocamento de INMETRICS LOCAL 2 para INMETRICS LOCAL violado no dia ", "9", 0);
        }

        [Then(@"eu visualizo alerta de interjornada de elenco com sucesso")]
        public void EntaoEuVisualizoAlertaDeInterjornadaDeElencoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaDia("Interjornada de LUCAS ALMEIDA violada do dia ", "8");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Interjornada de LUCAS ALMEIDA violada do dia ", "8", 0);
        }

        [Then(@"eu visualizo alerta de incompatibilidade de cenarios e ambientes com sucesso")]
        public void EntaoEuVisualizoAlertaDeIncompatibilidadeDeCenariosEAmbientesComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiro("Ambiente INMETRICS AMBIENTE do cenário INMETRICS ESTUDIO  (cena 0502/003) não pode ser montado com o ambiente INMETRICS AMBIENTEPENSÃO DA DA do cenário INMETRICS LISTA INCOMP ALT (cena 0502/004), logo, cenários/ambientes incompatíveis com o conjunto de cenários do dia ", "2", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Ambiente INMETRICS AMBIENTE do cenário INMETRICS ESTUDIO  (cena 0502/003) não pode ser montado com o ambiente INMETRICS AMBIENTEPENSÃO DA DA do cenário INMETRICS LISTA INCOMP ALT (cena 0502/004), logo, cenários/ambientes incompatíveis com o conjunto de cenários do dia ", "2", 0);
        }

        [Then(@"eu visualizo alerta de MQE com sucesso")]
        public void EntaoEuVisualizoAlertaDeMQEComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiro("MQE máxima de BASE violada no dia ", "7", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("MQE máxima de BASE violada no dia ", "7", 0);
        }

        [Then(@"eu visualizo alerta de metragem de estudio com sucesso")]
        public void EntaoEuVisualizoAlertaDeMetragemDeEstudioComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiro("Metragem máxima de FRENTE 1 - EST violada no dia ", "6", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Metragem máxima de FRENTE 1 - EST violada no dia ", "6", 0);
        }

        [Then(@"eu visualizo alerta de interjornada de frente com sucesso")]
        public void EntaoEuVisualizoAlertaDeInterjornadaDeFrenteComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("Interjornada de FRENTE 1 - EXT violada do dia ", "5");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Interjornada de FRENTE 1 - EXT violada do dia ", "5", 0);
        }

        [Then(@"eu visualizo alerta de indisponibilidade de frente de gravacao com sucesso")]
        public void EntaoEuVisualizoAlertaDeIndisponibilidadeDeFrenteDeGravacaoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("FRENTE 1 - EXT  está indisponível no(a) QUARTA, dia ", "2");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("FRENTE 1 - EXT  está indisponível no(a) QUARTA, dia ", "2", 0);
        }

        [Then(@"eu visualizo alerta de limite de dias de gravacao na semana da frente com sucesso")]
        public void EntaoEuVisualizoAlertaDeLimiteDeDiasDeGravacaoNaSemanaDaFrenteComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("Frente FRENTE 1 - EXT viola o número máximo de dias que pode gravar na semana.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Frente FRENTE 1 - EXT viola o número máximo de dias que pode gravar na semana.", "1", 0);
        }

        [Then(@"eu visualizo alerta de conflito de horario de elenco com sucesso")]
        public void EntaoEuVisualizoAlertaDeConflitoDeHorarioDeElencoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiroConflitoDeHorario("3", "LUCAS ALMEIDA está em envolvido(a) em cenas dos roteiros: ", " na mesma faixa de horário.");
            TelaPlanejamentoGROT.ValidarRelatorioRoteiroConflitoDeHorario("LUCAS ALMEIDA está em envolvido(a) em cenas dos roteiros: ", " na mesma faixa de horário.");
        }

        [Then(@"eu visualizo alerta de multipla alocacao de ambiente com sucesso")]
        public void EntaoEuVisualizoAlertaDeMultiplaAlocacaoDeAmbienteComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRelatorioDia("O ambiente INMETRICS AMBIENTE não pode ser usado em mais de um local no mesmo dia. Verifique as alocações do dia ", "1", 0);
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("O ambiente INMETRICS AMBIENTE não pode ser usado em mais de um local no mesmo dia. Verifique as alocações do dia ", "2", 0);
        }

        [Then(@"eu visualizo alerta de refeicao de elenco com sucesso")]
        public void EntaoEuVisualizoAlertaDeRefeicaoDeElencoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Refeição de LUCAS ALMEIDA violada no dia ", "2", 0);
        }

        [Then(@"eu visualizo alerta de refeicao da equipe com sucesso")]
        public void EntaoEuVisualizoAlertaDeRefeicaoDaEquipeComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiro(" com mais de 2 horas de trabalho sem intervalo para refeição da equipe.", "1", "1");
            TelaPlanejamentoGROT.ValidarRelatorioRoteiroRefeicaoDaEquipe(" com mais de 2 horas de trabalho sem intervalo para refeição da equipe.");
        }

        [Then(@"eu visualizo alerta de jornada da frente com sucesso")]
		public void EntaoEuVisualizoAlertaDeJornadaDaFrenteComSucesso()
		{
			TelaPlanejamentoGROT.ValidarAlertaJornadaMaxima("Jornada máxima diária da frente de gravação FRENTE 1 - EXT violada em 01:00 horas no dia ", "1", 0);
			TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada máxima diária da frente de gravação FRENTE 1 - EXT violada em 01:00 horas no dia ", "2", 0);
		}

		[Then(@"eu visualizo alerta de limite de dias de gravacao na semana do elenco com sucesso")]
        public void EntaoEuVisualizoAlertaDeLimiteDeDiasDeGravacaoNaSemanaDoElencoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("LUCAS ALMEIDA violada máximo de dias de gravação na semana em 1 dia(s).", "1", 0);
        }

        [Then(@"eu visualizo alerta de inconsistencia com sucesso")]
        public void EntaoEuVisualizoAlertaDeInconsistenciaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaRoteiroInconsitencia(": A cena 0501/004 não pode ser gravada depois de sua exibição.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioRoteiroInconsitencia(": A cena 0501/004 não pode ser gravada depois de sua exibição.");
        }
        
        [Then(@"eu visualizo alerta de faixa de horario de gravacao com sucesso")]
        public void EntaoEuVisualizoAlertaDeFaixaDeHorarioDeGravacaoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaCena("Horário de início da cena 0501/005 fora da faixa de horário estipulada na cena.", "1");
            TelaPlanejamentoGROT.ValidarAlertaCena("Horário de início da cena 0501/006 fora da faixa de horário estipulada na cena.", "2");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0501/005 fora da faixa de horário estipulada na cena.", "1", 0);
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0501/006 fora da faixa de horário estipulada na cena.", "1", 0);
        }

        [Then(@"eu visualizo alerta de jornada de elenco com sucesso")]
        public void EntaoEuVisualizoAlertaDeJornadaDeElencoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaDia("Jornada máxima diária de LUCAS ALMEIDA violada em 00:10 horas no dia ", "2");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada máxima diária de LUCAS ALMEIDA violada em 00:10 horas no dia ", "2", 0);
        }

		[Then(@"eu visualizo alerta de tempo de caracterizacao do elenco com sucesso")]
		public void EntaoEuVisualizoAlertaDeTempoDeCaracterizacaoDoElencoComSucesso()
		{
			TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de caracterização de LUCAS ALMEIDA violado para a cena 0500/003.", "1");
			TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de caracterização de LUCAS ALMEIDA violado para a cena 0500/003.", "1", 0);
		}

		[Then(@"eu visualizo alerta de indisponibilidade de elenco com sucesso")]
		public void EntaoEuVisualizoAlertaDeIndisponibilidadeDeElencoComSucesso()
		{
			TelaPlanejamentoGROT.ValidarAlertaIndisponibilidadeElenco("Artista LUCA AYRES com indisponibilidade no dia ", "1", 0);
			TelaPlanejamentoGROT.ValidarRelatorioAlertas("Artista LUCA AYRES com indisponibilidade no dia ", "3", 0);
		}

        [Then(@"eu visualizo alerta de jornada semanal de elenco com sucesso")]
        public void EntaoEuVisualizoAlertaDeJornadaSemanalDeElencoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("Jornada semanal máxima de LUCAS ALMEIDA violada", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada semanal máxima de LUCAS ALMEIDA violada", "1", 0);
        }

		[Then(@"eu visualizo alerta de tempo de preparacao de elenco com sucesso")]
		public void EntaoEuVisualizoAlertaDeTempoDePreparacaoDeElencoComSucesso()
		{
			TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0500/003.", "1");
			TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0500/003.", "1", 0);
		}

		[Then(@"eu visualizo alerta de antecedencia minima com sucesso")]
		public void EntaoEuVisualizoAlertaDeAntecedenciaMinimaComSucesso()
		{
            TelaPlanejamentoGROT.ValidarAlertaCena("Cena 0500/001 viola antecedência mínima de gravação.", "1");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Cena 0500/001 viola antecedência mínima de gravação.", "1", 0);
        }

		[Then(@"eu visualizo alerta de iluminacao com sucesso")]
		public void EntaoEuVisualizoAlertaDeIluminacaoComSucesso()
		{
			TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
			TelaPlanejamentoGROT.ValidarAlertaCena("Horário da cena 0500/003 deve ser roteirizada no período de 06:00 às 12:00.", "1");
			TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário da cena 0500/003 deve ser roteirizada no período de 06:00 às 12:00.", "1", 0);
		}

		[Then(@"eu visualizo alerta de indisponibilidade do local com sucesso")]
		public void EntaoEuVisualizoAlertaDeIndisponibilidadeDoLocalComSucesso()
		{
			TelaPlanejamentoGROT.ValidarRelatorioAlertas("O local INMETRICS LOCAL 2 está indisponível no dia ", "4", 0);
		}

        [Then(@"eu visualizo o alerta de conflito de roteiros")]
        public void EntaoEuVisualizoOAlertaDeConflitoDeRoteiros()
        {
            TelaPlanejamentoGROT.ValidarConflitoRoteiro("A versão do planejamento possui conflitos.");
            TelaPlanejamentoGROT.DeletarRascunho();
        }

        [Then(@"eu visualizo o planejamento criado no campo de historico com sucesso")]
        public void EntaoEuVisualizoOPlanejamentoCriadoNoCampoDeHistoricoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarHistorico(0, "1");
        }

        //-------------------------------------------------------Esquemas de cenario---------------------------------------------------------------//
        [Given(@"que crie um planejamento de roteiro com as cenas ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void DadoQueCrieUmPlanejamentoDeRoteiroComAsCenas(string cena1, string cena2, string cena3, string cena4, string cena5, string cena6)
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), cena1, "2");
            if (cena2 != "")
            {
                //arrasta a cena para o dia seguinte ao atual
                TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), cena2, "2");
            }
            if (cena3 != "")
            {
                //arrasta a cena para dois dias depois do atual
                TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), cena3, "2");
            }
            if (cena4 != "")
            {
                //arrasta a cena para o dia atual
                TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), cena4, "1");
            }
            if (cena5 != "")
            {
                //arrasta a cena para o dia atual
                TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), cena5, "1");
            }
            if (cena6 != "")
            {
                //cria uma nova frente e arrasta a cena para o dia atual da nova cena
                TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanalFrente2(CalendarioHelper.ObterDataAtual(), cena6, "2", "Externa");
            }
        }

        [Given(@"que crie um planejamento de roteiro com as cenas ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" de estudio")]
        public void DadoQueCrieUmPlanejamentoDeRoteiroComAsCenasDeEstudio(string cena1, string cena2, string cena3, string cena4, string cena5)
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteEstudio(CalendarioHelper.ObterDataAtual(), cena1, "2");
            if(cena2 != "")
            {
                TelaPlanejamentoGROT.CriarFrenteEstudioDiario(CalendarioHelper.ObterDataAtual(), cena2, "1");
            }
            
        }

        [When(@"editar o horario do roteiro para o ""(.*)""")]
        public void QuandoEditarOHorarioDoRoteiroParaO(string alerta)
        {
            switch (alerta)
            {
                case "Caracterização de elenco":
                case "Tempo preparação de elenco":
                    {
                        TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "00:00", "12:00", "08:30", 1);
                        break;
                    }
                case "Jornada semanal do elenco (SEMANAL)":
                case "Refeição da equipe":
                    {
                        TelaPlanejamentoGROT.PreencherHorarioPersonagemRoteiro("Editar", "08:00", "09:00", "22:00", "22:00", "08:00", 1);
                        break;
                    }
            }
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }

        [Then(@"visualizo a mensagem ""(.*)""")]
        public void EntaoVisualizoAMensagem(string alerta)
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertasGeral(alerta);

            //switch (alerta)
            //{
            //    case "Antecedência mínima de gravação":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaCena("Cena 0500/001 viola antecedência mínima de gravação.", "1");
            //            //TelaPlanejamentoGROT.ValidarRelatorioAlertas("Cena 0500/001 viola antecedência mínima de gravação.", "1", 0);
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertasGeral(alerta);
            //            break;
            //        }
            //    case "Faixa de horário de gravação":
            //        {
            //            TelaPlanejamentoGROT.ValidarAlertaCena("Horário de início da cena 0500/001 fora da faixa de horário estipulada na cena.", "1");
            //            //TelaPlanejamentoGROT.ValidarAlertaCena("Horário de início da cena 0501/006 fora da faixa de horário estipulada na cena.", "2");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0500/001 fora da faixa de horário estipulada na cena.", "1", 0);
            //            //TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0501/006 fora da faixa de horário estipulada na cena.", "1", 0);
            //            break;
            //        }
            //    case "Inconsistência":
            //        {
            //            TelaPlanejamentoGROT.ValidarAlertaRoteiroInconsitencia(": A cena 0500/001 não pode ser gravada depois de sua exibição.", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioRoteiroInconsitencia(": A cena 0500/001 não pode ser gravada depois de sua exibição.");
            //            break;
            //        }
            //    case "Refeição da equipe":
            //        {
            //            TelaPlanejamentoGROT.ValidarAlertaRoteiro(" com mais de 6 horas de trabalho sem intervalo para refeição da equipe.", "1", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioRoteiroRefeicaoDaEquipe(" com mais de 6 horas de trabalho sem intervalo para refeição da equipe.");
            //            break;
            //        }
            //    case "Jornada da frente":
            //        {
            //            TelaPlanejamentoGROT.ValidarAlertaJornadaMaxima("Jornada máxima diária da frente de gravação FRENTE 1 - EXT violada em 04:40 horas no dia ", "1", 0);
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada máxima diária da frente de gravação FRENTE 1 - EXT violada em 04:40 horas no dia ", "2", 0);
            //            break;
            //        }
            //    case "Indisponibilidade de frente de gravação (SEMANAL)":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("FRENTE 1 - EXT  está indisponível no(a) QUINTA, dia ", "2");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("FRENTE 1 - EXT  está indisponível no(a) ", "Indisponibilidade de frente de gravacao", 0);
            //            break;
            //        }
            //    case "Indisponibilidade do local (SEMANAL)":
            //        {
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("O local INMETRICS LOCAL está indisponível no dia ", "4", 0);
            //            break;
            //        }
            //    case "Jornada de elenco":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaDia("Jornada máxima diária de LUCAS ALMEIDA violada em 00:10 horas no dia ", "2");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada máxima diária de LUCAS ALMEIDA violada em 00:10 horas no dia ", "2", 0);
            //            break;
            //        }
            //    case "Indisponibilidade de elenco":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaIndisponibilidadeElenco("Artista LUCAS ALMEIDA com indisponibilidade no dia ", "1", 0);
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Artista LUCAS ALMEIDA com indisponibilidade no dia ", "3", 0);
            //            break;
            //        }
            //    case "Caracterização de elenco":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de caracterização de LUCAS ALMEIDA violado para a cena 0500/003.", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de caracterização de LUCAS ALMEIDA violado para a cena 0500/003.", "1", 0);
            //            break;
            //        }
            //    case "Tempo preparação de elenco":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaCena("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0500/003.", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de preparação de LUCAS ALMEIDA violado para a cena 0500/003.", "1", 0);
            //            break;
            //        }
            //    case "Limite de Dias de Gravação na Semana da Frente (SEMANAL)":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("Frente FRENTE 1 - EXT viola o número máximo de dias que pode gravar na semana.", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Frente FRENTE 1 - EXT viola o número máximo de dias que pode gravar na semana.", "1", 0);
            //            break;
            //        }
            //    case "Refeição de Elenco":
            //        {
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Refeição de LUCAS ALMEIDA violada no dia ", "2", 0);
            //            break;
            //        }
            //    case "Jornada semanal do elenco (SEMANAL)":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("Jornada semanal máxima de LUCAS ALMEIDA violada", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada semanal máxima de LUCAS ALMEIDA violada", "1", 0);
            //            break;
            //        }
            //    case "Limite de Dias de Gravação na Semana do Elenco (SEMANAL)":
            //        {
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("LUCAS ALMEIDA violada máximo de dias de gravação na semana em 2 dia(s).", "1", 0);
            //            break;
            //        }
            //    case "Interjornada de frente (SEMANAL)":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaGeralSemanal("Interjornada de FRENTE 1 - EXT violada do dia ", "5");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Interjornada de FRENTE 1 - EXT violada do dia ", "5", 0);
            //            break;
            //        }
            //    case "Interjornada de elenco":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaDia("Interjornada de LUCAS ALMEIDA violada do dia ", "8");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Interjornada de LUCAS ALMEIDA violada do dia ", "8", 0);
            //            break;
            //        }
            //    case "Iluminação":
            //        {
            //            TelaPlanejamentoGROT.ValidarAlertaCena("Horário da cena 0500/001 deve ser roteirizada no período de 06:00 às 12:00.", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário da cena 0500/001 deve ser roteirizada no período de 06:00 às 12:00.", "1", 0);
            //            break;
            //        }
            //    case "Tempo de deslocamento":
            //        {
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Tempo de deslocamento de INMETRICS LOCAL 2 para INMETRICS LOCAL violado no dia ", "9", 0);
            //            break;
            //        }
            //    case "Conflito de horário de elenco":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaRoteiroConflitoDeHorario("3", "LUCAS ALMEIDA está em envolvido(a) em cenas dos roteiros: ", " na mesma faixa de horário.");
            //            TelaPlanejamentoGROT.ValidarRelatorioRoteiroConflitoDeHorario("LUCAS ALMEIDA está em envolvido(a) em cenas dos roteiros: ", " na mesma faixa de horário.");
            //            break;
            //        }
            //    case "Múltipla alocação do ambiente":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaRelatorioDia("O ambiente INMETRICS AMBIENTE não pode ser usado em mais de um local no mesmo dia. Verifique as alocações do dia ", "1", 0);
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("O ambiente INMETRICS AMBIENTE não pode ser usado em mais de um local no mesmo dia. Verifique as alocações do dia ", "2", 0);
            //            break;
            //        }
            //    case "Metragem de estúdio":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaRoteiro("Metragem máxima de FRENTE 1 - EST violada no dia ", "6", "1");
            //            //TelaPlanejamentoGROT.ValidarRelatorioAlertas("Metragem máxima de FRENTE 1 - EST violada no dia ", "Metragem", 0);
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertasGeral(alerta);
            //            break;
            //        }
            //    case "Incompatibilidade de Cenarios e Ambientes":
            //        {
            //            //TelaPlanejamentoGROT.ValidarAlertaRoteiro("Ambiente INMETRICS AMBIENTE do cenário INMETRICS ESTUDIO  (cena 0502/003) não pode ser montado com o ambiente INMETRICS AMBIENTEPENSÃO DA DA do cenário INMETRICS LISTA INCOMP ALT (cena 0502/004), logo, cenários/ambientes incompatíveis com o conjunto de cenários do dia ", "2", "1");
            //            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Ambiente INMETRICS AMBIENTE do cenário INMETRICS ESTUDIO  (cena 0502/003) não pode ser montado com o ambiente INMETRICS AMBIENTEPENSÃO DA DA do cenário INMETRICS LISTA INCOMP ALT (cena 0502/004), logo, cenários/ambientes incompatíveis com o conjunto de cenários do dia ", "2", 0);
            //            break;
            //        }
                    
        }

    }
}
