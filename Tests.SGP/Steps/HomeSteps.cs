using Project.SGP.Pages;
using TechTalk.SpecFlow;
using System.Configuration;
using Framework.Core.Interfaces;
using Framework.Core.Extensions.SpecFlowExtensions;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class HomeSteps
    {
        public HomePage TelaHome { get; private set; }
		public FotosPage TelaFotos { get; private set; }
		public PlanejamentoRoteiroPage TelaPlanejamento { get; private set; }
		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
		public DecupagemContinuidadePage TelaDecupagemContinuidade { get; private set; }
        public GestaoAlertasPage TelaGestaoAlertasPage { get; private set; }
        
        public HomeSteps()
        {
			var browser = ScenarioContext.Current["browser"];
			TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaFotos = new FotosPage((IBrowser)browser,
				ConfigurationManager.AppSettings["FotosURL"],
				ConfigurationManager.AppSettings["RoteiroURL"]);

			TelaPlanejamento = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);

			TelaDecupagemContinuidade = new DecupagemContinuidadePage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemContinuidadeURL"]);

            TelaGestaoAlertasPage = new GestaoAlertasPage((IBrowser)browser,
                ConfigurationManager.AppSettings["GestaoAlertaUrl"]);
        }

        [Given(@"que eu navegue para a Tela Home com a programacao selecionada")]
        public void DadoQueEuNavegueParaaTelaHomeComAProgramacaoSelecionada()
        {
			TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produto"]);
		}

        [Given(@"que eu navegue para a Tela de Fotos")]
        public void DadoQueEuNavegueParaaTelaDeFotos()
        {
			TelaFotos.Navegar();
        }

        [Given(@"que eu navegue para a Tela de Planejamento de Roteiros")]
        public void DadoQueEuNavegueParaaTelaDePlanejamentoRoteiros()
        {
			TelaPlanejamento.Navegar();
        }

        [Given(@"que eu navegue para a Tela de Decupagem Basica")]
        public void DadoQueEuNavegueParaATeladeDecupagemBasica()
        {
			TelaDecupagemBasica.Navegar();
        }

		[Given(@"que eu navegue para a Tela de Decupagem Continuidade")]
		public void DadoQueEuNavegueParaATelaDeDecupagemContinuidade()
		{
			TelaDecupagemContinuidade.Navegar();
		}
	}
}
