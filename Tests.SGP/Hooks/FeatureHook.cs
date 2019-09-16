using Framework.IoC;
using TechTalk.SpecFlow;
using Framework.Core.Interfaces;
using System.Linq;
using Project.SGP.Pages;
using System.Configuration;
using System.Threading;
using Framework.Core.Helpers;
using System.Diagnostics;

namespace Tests.SGP.Hooks
{
	[Binding]
	public class FeatureHook
	{
		private static IBrowser Browser;

		public HomePage TelaHome { get; private set; }
        public IndisponibilidadeLocaisPage TelaIndisponibilidadeLocais { get; private set; }
		public FotosPage TelaFotos { get; private set; }
		public CenarioPage TelaCenario { get; private set; }
		public PersonagemPage TelaPersonagem { get; private set; }
		public ParametrosPage TelaParametro { get; private set; }
		public CapitulosCenasPage TelaCapituloCena { get; private set; }
		public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }
		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public LocalGravacaoPage TelaLocalGravacao { get; private set; }
        public CenarioIncompativelPage TelaCenarioIncompativel { get; private set; }
        public IndisponibilidadeElencoPage TelaIndisponibilidadeElenco { get; private set; }
        public GrupoLocalGravacaoPage TelaGrupoLocalGravacao { get; private set; }
        public SequeciaCenicaPage TelaSequeciaCenica { get; private set; }
        public ParametrosPage TelaParametros { get; private set; }
        public GestaoAlertasPage TelaGestaoAlerta { get; private set; }

        public FeatureHook()
		{
			//var browser = FeatureContext.Current["browser"];

			var browser = ScenarioContext.Current["browser"];

			TelaHome = new HomePage((IBrowser)browser,
			ConfigurationManager.AppSettings["HomeURL"],
			ConfigurationManager.AppSettings["FotosURL"],
			ConfigurationManager.AppSettings["DecupagemBasicaURL"],
			ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CapituloCenaURL"],
			   ConfigurationManager.AppSettings["IncluirCapituloURL"],
			   ConfigurationManager.AppSettings["IncluirAdendoURL"]);

			TelaCenario = new CenarioPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CenarioURL"]);

			TelaPersonagem = new PersonagemPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["PersonagemURL"]);

			TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
			  ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);

			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaFotos = new FotosPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["FotosURL"],
			   ConfigurationManager.AppSettings["RoteiroURL"]);

			TelaParametro = new ParametrosPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["ParametroURL"]);

            TelaIndisponibilidadeLocais = new IndisponibilidadeLocaisPage((IBrowser)browser,
                ConfigurationManager.AppSettings["IndisponibilidadeLocal"]);

            TelaLocalGravacao = new LocalGravacaoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["LocalGravacaoUrl"]);

            TelaCenarioIncompativel = new CenarioIncompativelPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CenarioIncompativelURL"]);

            TelaIndisponibilidadeElenco = new IndisponibilidadeElencoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["indisponibilidadeElencoUrl"]);

            TelaGrupoLocalGravacao = new GrupoLocalGravacaoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["GrupoLocalGravacaoUrl"]);

            TelaSequeciaCenica = new SequeciaCenicaPage((IBrowser)browser,
               ConfigurationManager.AppSettings["SequenciaCenicaUrl"]);

            TelaParametros = new ParametrosPage((IBrowser)browser, 
                ConfigurationManager.AppSettings["ParametrosURL"]);

            TelaGestaoAlerta = new GestaoAlertasPage((IBrowser)browser, 
                ConfigurationManager.AppSettings["GestaoAlertaUrl"]);
        }

		[BeforeScenario]
		public static void Before()
		{
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments= "/c taskkill /im chrome.exe /f";
            Process.Start(startInfo);

            startInfo.Arguments = "/c taskkill /im chromedriver.exe /f";
            Process.Start(startInfo);

            Browser = BrowserBuilder.ObterBrowser(
						 ScenarioContext.Current.ScenarioInfo.Tags.FirstOrDefault(f => f == "chrome" || f == "firefox" || f == "ie"));

			Thread.Sleep(1000);
			Browser.Iniciar();

			ScenarioContext.Current.Add("browser", Browser);
		}

		public static void FinalizarDriver()
		{
			Browser.Finalizar();
		}

		public static void FecharDriver()
		{
			Browser.Fechar();
		}

		[AfterScenario]
		public void ExcluirMassas()
		{
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("editarFrenteDePlanejamento"))
            {
                TelaPlanejamentoGROT.EditarFrenteDePlanejamento("", "1", "Sim");
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("selecionarTodosAlertas"))
            {
                TelaGestaoAlerta.Navegar();
                TelaGestaoAlerta.MarcarCheckBoxTodos(true);
                TelaGestaoAlerta.BtnFecharAlertas();
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("alterar_StatusRoteiro"))
			{
				TelaEspelhoGravacao.AlterarStatus("0400/001", "Roteirizada");
			}

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("alterar_NovoStatusRoteiro"))
            {
                TelaEspelhoGravacao.AlterarStatus("1000/014", "Roteirizada");
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_PlanejamentoRoteiro"))
			{
				TelaPlanejamentoRoteiro.CancelarRoteiro(CalendarioHelper.ObterDataAtual());
			}

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_Imagens"))
			{
				TelaFotos.ExcluirTodasImagens();
			}

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_NovoCapitulo"))
			{
                TelaHome.Navegar();
                TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produto"]);
                TelaCapituloCena.ExcluirCapitulo("capituloDe", "0400");
            }

            if(ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_ListaCenarioIncompativel"))
            {
                TelaCenarioIncompativel.ApagarListaCenarioIncompativel("PAÇO IMPERIAL", "");
            }

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_NovoCenario"))
			{
				TelaCenario.ExcluirCenario("INM ESTUDIO");
			}

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_NovoPersonagem"))
			{
				TelaPersonagem.ExcluirNovoPersonagem("INM PERSONAGEM");
			}

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_Roupas"))
			{
				TelaPersonagem.ExcluirRoupa("INMETRICS PERSONAGEM", "0400  1º Bloco");
			}

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_GrupoNotificacao"))
			{
				TelaPlanejamentoRoteiro.ExcluirNomeGrupoNotificacao("Lucas Fraga");
			}

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("alterar_ParametroProducao"))
			{
				TelaHome.Navegar();
				TelaHome.AcessarMenuList("Parâmetros de Produção");
				TelaParametro.PreencherDiasAntecedencia("3");
			}

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("alterar_ParametroProducaoPersonagem"))
            {
                TelaHome.Navegar();
                TelaHome.AcessarMenuList("Parâmetros de Produção");
                TelaParametros.AlterarParametrosPersonagem("3", "3", "3", "3");
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_IndisponibilidadeLocais"))
            {
                TelaIndisponibilidadeLocais.Navegar();
                TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL 2", "Atual", "");
                //TelaIndisponibilidadeLocais.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL");
                TelaIndisponibilidadeLocais.ExcluirIndisponibilidadeLocais();
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_IndisponibilidadeElenco"))
            {
                TelaIndisponibilidadeElenco.Navegar();
                TelaIndisponibilidadeElenco.FiltrarIndisponibilidadeElenco("LUCA AYRES", "", "", "");
                TelaIndisponibilidadeElenco.ValidarNovaIndisponibilidade("LUCA AYRES", "", "", "", "", "", "Teste INM");
                TelaIndisponibilidadeElenco.ExcluirIndisponibilidadeElenco();
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_LocalGravacao"))
            {
                TelaLocalGravacao.Navegar();
                TelaLocalGravacao.FiltrarLocalGravacao("INM LOCAL", "", "");
                TelaLocalGravacao.ExcluirLocalGravacao();
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_Regiao"))
            {
                TelaGrupoLocalGravacao.Navegar();
                TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("", "", "INM NOVA REGIAO");
                TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INM NOVA REGIAO", "", "");
                TelaGrupoLocalGravacao.ExcluirGrupoLocalGravacao();
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("excluir_SequenciaCenica"))
            {
                TelaSequeciaCenica.Navegar();
                TelaSequeciaCenica.ExcluirSequenciaCenica("INM");
            }

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("logout"))
			{
				//TelaCapituloCena.Navegar();
				//TelaCapituloCena.SairSGP();
			}

            FecharDriver();
		}

       
		[AfterFeature("kill_Driver")]
		public static void MatarDriver()
		{
            if (Browser !=  null)
			    Browser.KillDriver();

			//Browser.KillChrome();
   //         Browser.Fechar();
   //         Browser.Dispose();
		}
	}
}
