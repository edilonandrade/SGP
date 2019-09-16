using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class CriarDecupagemBasicaSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public PersonagemPage TelaPersonagem { get; private set; }
        public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
        public CenarioPage TelaCenario { get; private set; }

        public CriarDecupagemBasicaSteps()
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
		}

        [When(@"eu decupar uma cena")]
        public void QuandoEuDecuparUmaCena()
        {
            //TelaDecupagemBasica.DecuparCenaCompleta("0400", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
            TelaDecupagemBasica.DecuparCenaCompleta("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
            TelaDecupagemBasica.SalvarCena();
        }

        [Then(@"eu visualizo a Cena criada com sucesso")]
        public void EntaoEuVisualizoACenaCriadaComSucesso()
        {
            TelaCapituloCena.VerificarCena("capituloDe", "0400", "001");
        }

		[Given(@"que eu navegue para a Tela Home")]
		public void DadoQueEuNavegueParaATelaHome()
		{
			ScenarioContext.Current.Pending();
		}

		[When(@"eu criar um novo cenario ambiente")]
        public void QuandoEuCriarUmNovoCenarioAmbiente()
        {
			TelaCenario.CriarNovoCenario("CENARIO", "INM ESTUDIO");
			TelaCenario.CriarNovoAmbiente("INM AMBIENTE");
			TelaCenario.SalvarNovoCenario();
        }

		[When(@"utilizar novo cenario e ambiente")]
		public void QuandoUtilizarNovoCenarioEAmbiente()
		{
			TelaDecupagemBasica.CriarNovoCenarioAmbiente("0400", "INM ESTUDIO", "INM AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
		}

		[Then(@"eu visualizo cenario ambiente criados com sucesso")]
        public void EntaoEuVisualizoCenarioAmbienteCriadosComSucesso()
        {
			TelaCapituloCena.Navegar();
            TelaCapituloCena.VerificarCenarioAmbiente("capituloDe", "0400", "001", "INM ESTUDIO", "INM AMBIENTE");
        }

        [When(@"eu criar abertura de letra")]
        public void QuandoEuCriarAberturaDeLetra()
        {
            TelaDecupagemBasica.AberturaLetra("0400", "A");
			TelaDecupagemBasica.DecuparAberturaLetra("INMETRICS EXTERNA", "INMETRICS PERSONAGEM", "FIGURANTES");

			TelaDecupagemBasica.SalvarCena();
        }

        [Then(@"eu visualizo abertura de letra criada com sucesso")]
        public void EntaoEuVisualizoAberturaDeLetraCriadaComSucesso()
        {
            TelaCapituloCena.VerificarAberturaLetra("capituloDe", "0400", "001", "A");
        }

        [When(@"eu abrir letra com cena decupada")]
        public void QuandoEuAbrirLetraComCenaDecupada()
        {
            TelaDecupagemBasica.CriarLetraCenaDecupada("0400", "001", "A", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGUARNTES");

			TelaDecupagemBasica.SalvarCena();
        }

        [Then(@"eu visualizo abertura de letra realizada com sucesso")]
        public void EntaoEuVisualizoAberturaDeLetraRealizadaComSucesso()
        {
            TelaCapituloCena.VerificarCriacaoLetra("capituloDe", "0400", "001", "A");
        }

        [When(@"eu criar uma cena secreta")]
        public void QuandoEuCriarUmaCenaSecreta()
        {
            TelaDecupagemBasica.SelecionarCenaSecreta("0400", "lucas.fraga_inmetrics@tvglobo.com.br", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
        }

        [Then(@"visualizo cena criada com sucesso")]
        public void EntaoVisualizoCenaCriadaComSucesso()
        {
            TelaCapituloCena.VerificarCenaSecreta("capituloDe", "0400", "001");
        }

        [When(@"eu criar um novo personagem na tela de decupagem")]
        public void QuandoEuCriarUmNovoPersonagemNaTelaDeDecupagem()
        {
            TelaDecupagemBasica.CriarPersonagem("0400", "001", "INMETRICS ESTUDIO", "INM PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
        }

        [Then(@"eu visualizo personagem criado com sucesso")]
        public void EntaoEuVisualizoPersonagemCriadoComSucesso()
        {
            TelaCapituloCena.VerificarNovoPersonagemNoCapitulo("capituloDe", "0400", "001", "INM PERSONAGEM");
		}

        [When(@"eu criar um novo personagem e nova indisponibilidade")]
        public void QuandoEuCriarUmNovoPersonagemENovaIndisponibilidade()
        {
            TelaDecupagemBasica.CriarNovoPersonagemNovaIndisponibilidade("0400", "001", "INMETRICS ESTUDIO", "INM PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
			TelaPersonagem.CriarNovaIndisponibilidade("INM PERSONAGEM");
		}

        [Then(@"eu visualizo personagem e indisponibilidade criados com sucesso")]
        public void EntaoEuVisualizoPersonagemEIndisponibilidadeCriadosComSucesso()
        {
            TelaPersonagem.VerificarIndisponibilidade();
		}

        [When(@"eu decupar a proxima cena")]
        public void QuandoEuDecuparAProximaCena()
        {
            TelaDecupagemBasica.DecuparProximaCena("0400", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
        }

        [Then(@"eu visualizo cena decupada com sucesso")]
        public void EntaoEuVisualizoCenaDecupadaComSucesso()
        {
            TelaCapituloCena.VerificarCena("capituloDe", "0400", "002");
        }

        [Then(@"eu visualizo capitulo anexado com sucesso")]
        public void EntaoEuVisualizoCapituloAnexadoComSucesso()
        {
            TelaCapituloCena.VerificarCapitulo("capituloDe", "0400");
        }
    }
}
