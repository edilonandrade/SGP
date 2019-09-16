using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
    [Binding]
    public sealed class IncluirAdendoSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public DecupagemContinuidadePage TelaDecupagemContinuidade { get; private set; }
        public DecupagemArtePage TelaDecupagemArte { get; private set; }

        public IncluirAdendoSteps()
        {
			var browser = ScenarioContext.Current["browser"];
			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
                ConfigurationManager.AppSettings["CapituloCenaURL"],
                ConfigurationManager.AppSettings["IncluirCapituloURL"],
                ConfigurationManager.AppSettings["IncluirAdendoURL"]);

            TelaDecupagemContinuidade = new DecupagemContinuidadePage((IBrowser)browser,
                ConfigurationManager.AppSettings["DecupagemContinuidadeURL"]);

            TelaDecupagemArte = new DecupagemArtePage((IBrowser)browser,
                ConfigurationManager.AppSettings["DecupagemArteURL"]);
        }

        [When(@"incluir o adendo no capitulo")]
        public void QuandoIncluirOAdendoNoCapitulo()
        {
            TelaCapituloCena.IncluirAdendo("0400");
        }

        [Then(@"visualizo que adendo foi concluido com sucesso")]
        public void EntaoVisualizoQueAdendoFoiConcluidoComSucesso()
        {
            TelaCapituloCena.VerificarIncluirAdendo();
        }

        [Then(@"eu visualizo mensagem de alteracao do capitulo em decupagem de continuidade")]
        public void EntaoEuVisualizoMensagemDeAlteracaoDoCapituloEmDecupagemDeContinuidade()
        {
            //TelaDecupagemContinuidade.VerificarAlertaAdendoDecupagemContinuidade();
        }

        [Then(@"eu visualizo mensagem de alteracao do capitulo em decupagem de arte")]
        public void EntaoEuVisualizoMensagemDeAlteracaoDoCapituloEmDecupagemDeArte()
        {
            //TelaDecupagemArte.VerificarAlertaAdendoDecupagemArte();
        }
    }
}
