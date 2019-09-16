using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
    [Binding]
    public sealed class CriarCapituloComDecupagemSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }

        public CriarCapituloComDecupagemSteps()
        {
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
                ConfigurationManager.AppSettings["CapituloCenaURL"],
                ConfigurationManager.AppSettings["IncluirCapituloURL"],
                ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [Given(@"que eu esteja com a programacao selecionada")]
        public void DadoQueEuEstejaComAProgramacaoSelecionada()
        {
            // pré-condição executado pelo contexto
        }

        [When(@"eu criar um novo capitulo com decupagem")]
        public void QuandoEuCriarUmNovoCapituloComDecupagem()
        {
			TelaCapituloCena.CriarNovoCapituloComDecupagem("0400");
			TelaDecupagemBasica.DecuparCenaCompleta("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
        }

		[Given(@"que eu decupe uma cena do tipo estudio")]
		public void DadoQueEuDecupeUmaCenaDoTipoEstudio()
		{
			TelaDecupagemBasica.DecuparCenaCompleta("0400", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
		}

		[When(@"eu criar um Novo Capitulo secreto")]
		public void QuandoEuCriarUmNovoCapituloSecreto()
		{
			TelaCapituloCena.CriarNovoCapituloSecreto("0400", "lucas.fraga_inmetrics@tvglobo.com.br");
			TelaDecupagemBasica.DecuparCenaCompleta("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
		}
	}
}