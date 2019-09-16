using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public class ValidacoesSemGrotSteps
    {
        public DecupagemContinuidadePage TelaDecupagemContinuidade { get; private set; }

        public ValidacoesSemGrotSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaDecupagemContinuidade = new DecupagemContinuidadePage((IBrowser)browser,
            ConfigurationManager.AppSettings["DecupagemContinuidadeURL"]);
        }

        [Then(@"eu nao visualizo o campo tempo preparacao com sucesso")]
        public void EntaoEuNaoVisualizoOCampoTempoPreparacaoComSucesso()
        {
            TelaDecupagemContinuidade.ValidacaoSemGrot();
        }

    }
}
