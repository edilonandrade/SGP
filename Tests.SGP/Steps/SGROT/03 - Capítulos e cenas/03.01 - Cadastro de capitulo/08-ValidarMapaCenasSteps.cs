using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
    [Binding]
    public sealed class ValidarMapaCenasSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }

        public ValidarMapaCenasSteps()
        {
			var browser = ScenarioContext.Current["browser"];
			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CapituloCenaURL"],
               ConfigurationManager.AppSettings["IncluirCapituloURL"],
               ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [When(@"acessar o mapa de cenas")]
        public void QuandoAcessarOMapaDeCenas()
        {
            TelaCapituloCena.AbrirMapaCenas("0400");
        }

        [Then(@"visualizo mapa de cenas")]
        public void EntaoVisualizoMapaDeCenas()
        {
            TelaCapituloCena.VerificarMapaCenas("Mapa de Cenas");
        }
    }
}
