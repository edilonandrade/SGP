using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class RefinarMarcacoesSteps
    {
        public FotosPage TelaFotos { get; private set; }

        public RefinarMarcacoesSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaFotos = new FotosPage((IBrowser)browser,
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["RoteiroURL"]);
        }

        [When(@"refinar a marcacao por cenas")]
        public void QuandoRefinarAMarcacaoPorCenas()
        {
            TelaFotos.RefinarMarcacaoCena("0400/001"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [Then(@"visualizo a imagem refinada por marcacao de cena")]
        public void EntaoVisualizoAImagemRefinadaPorMarcacaoDeCena()
        {
            TelaFotos.VerificarMarcacaoCena("0400/001"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [When(@"refinar a marcacao por cenarios")]
        public void QuandoRefinarAMarcacaoPorCenarios()
        {
            TelaFotos.RefinarMarcacaoCenario("INMETRICS LOCACAO - EXT"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [Then(@"visualizo a imagem refinada por marcacao de cenario")]
        public void EntaoVisualizoAImagemRefinadaPorMarcacaoDeCenario()
        {
            TelaFotos.VerificarMarcacaoCenario("INMETRICS LOCACAO - EXT"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [When(@"refinar a marcacao por roupas")]
        public void QuandoRefinarAMarcacaoPorRoupas()
        {
            TelaFotos.RefinarMarcacaoRoupa("MARCIO - 0A (1º BLOCO)"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [Then(@"visualizo a imagem refinada por marcacao de roupa")]
        public void EntaoVisualizoAImagemRefinadaPorMarcacaoDeRoupa()
        {
            TelaFotos.VerificarMarcacaoRoupa("MARCIO - 0A (1º BLOCO)");
        }

        [When(@"refinar a marcacao por ambientes")]
        public void QuandoRefinarAMarcacaoPorAmbientes()
        {
            TelaFotos.RefinarMarcacaoAmbiente("INMETRICS AMBIENTE"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [Then(@"visualizo a imagem refinada por marcacao de ambiente")]
        public void EntaoVisualizoAImagemRefinadaPorMarcacaoDeAmbiente()
        {
            TelaFotos.VerificarMarcacaoAmbiente("INMETRICS AMBIENTE");
        }
    }
}
