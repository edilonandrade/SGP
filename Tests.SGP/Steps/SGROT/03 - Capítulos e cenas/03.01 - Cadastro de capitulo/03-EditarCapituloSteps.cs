using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
    [Binding]
    public sealed class EditarCapituloSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }

        public EditarCapituloSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
                ConfigurationManager.AppSettings["CapituloCenaURL"],
                ConfigurationManager.AppSettings["IncluirCapituloURL"],
                ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        //[Given(@"que eu esteja com o capitulo o criado")]
        //public void DadoQueEuEstejaComOCapituloOCriado()
        //{
        //    // pré-condição executado pelo contexto
        //}

        [When(@"editar um capitulo criado")]
        public void QuandoEditarUmCapituloCriado()
        {
          TelaCapituloCena.EditarCapitulos("0400");
        }

        [Then(@"eu visualizo um Capitulo editado com sucesso")]
        public void EntaoEuVisualizoUmCapituloEditadoComSucesso()
        {
            TelaCapituloCena.VerificarCapituloEditado("capituloDe", "0400");
        }
    }
}
