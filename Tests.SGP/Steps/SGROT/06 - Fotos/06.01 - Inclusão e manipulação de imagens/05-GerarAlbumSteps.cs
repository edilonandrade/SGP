using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class GerarAlbumSteps
    {
        public FotosPage TelaFotos { get; private set; }

        public GerarAlbumSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaFotos = new FotosPage((IBrowser)browser,
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["RoteiroURL"]);
        }

        [When(@"incluir duas imagens")]
        public void QuandoIncluirDuasImagens()
        {
            //TelaFotos.IncluirDuasFotos("SGP - Teste Automatizado", "", "0400/001", "INMETRICS PERSONAGEM", "0A (1º Bloco) - MARCIO", "INMETRICS LOCACAO", "INMETRICS AMBIENTE", "Teste");
            TelaFotos.IncluirDuasFotos("GROT", "", "0400/001", "INMETRICS PERSONAGEM", "0A (1º Bloco) - MARCIO", "INMETRICS LOCACAO", "INMETRICS AMBIENTE", "Teste");
            TelaFotos.IncluirImagens();

		}

		[When(@"gerar album duas por pagina")]
        public void QuandoGerarAlbumDuasPorPagina()
        {
            TelaFotos.GerarAlbumPorPagina("2");
        }

        [Then(@"visualizo album gerado com sucesso")]
        public void EntaoVisualizoAlbumGeradoComSucesso()
        {
            TelaFotos.VerificarDownloadImagens();
        }

        [When(@"incluir quatro imagens")]
        public void QuandoIncluirQuatroImagens()
        {
            TelaFotos.IncluirQuatroFotos("GROT", "", "0400/001", "INMETRICS PERSONAGEM", "0A (1º Bloco) - MARCIO", "INMETRICS LOCACAO", "INMETRICS AMBIENTE", "Teste");
            TelaFotos.IncluirImagens();
        }

        [When(@"gerar album quatro por pagina")]
        public void QuandoGerarAlbumQuatroPorPagina()
        {
            TelaFotos.GerarAlbumPorPagina("4");
        }

        [When(@"incluir dez imagens")]
        public void QuandoIncluirDezImagens()
        {
            TelaFotos.IncluirDezFotos("GROT", "", "0400/001", "INMETRICS PERSONAGEM", "0A (1º Bloco) - MARCIO", "INMETRICS LOCACAO", "INMETRICS AMBIENTE", "Teste");
            TelaFotos.IncluirImagens();
        }

        [When(@"gerar album nove por pagina")]
        public void QuandoGerarAlbumNovePorPagina()
        {
            TelaFotos.GerarAlbumPorPagina("9");
        }

    }
}
