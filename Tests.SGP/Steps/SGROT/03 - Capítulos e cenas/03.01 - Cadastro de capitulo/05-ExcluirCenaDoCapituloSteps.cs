using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
    [Binding]
    public sealed class ExcluirCenaDoCapituloSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }

        public ExcluirCenaDoCapituloSteps()
        {
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
                ConfigurationManager.AppSettings["DecupagemBascaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
                ConfigurationManager.AppSettings["CapituloCenaURL"],
                ConfigurationManager.AppSettings["IncluirCapituloURL"],
                ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [When(@"excluir cena")]
        public void QuandoExcluirCena()
        {
            TelaCapituloCena.ExcluirCena("0400");
        }

        [Then(@"visualizo cena excluida com sucesso")]
        public void EntaoVisualisoCenaExcluidaComSucesso()
        {
            TelaCapituloCena.VerificarCenaExcluida("0400");
        }
    }
}
