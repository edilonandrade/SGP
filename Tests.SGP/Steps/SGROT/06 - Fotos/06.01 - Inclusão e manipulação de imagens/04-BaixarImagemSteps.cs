
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class BaixarImagemSteps
    {
        public FotosPage TelaFotos { get; private set; }

        public BaixarImagemSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaFotos = new FotosPage((IBrowser)browser,
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["RoteiroURL"]);
        }


        [When(@"escolho uma imagem via janela de detalhamento e baixo uma imagem")]
        public void QuandoEscolhoUmaImagemViaJanelaDeDetalhamentoEBaixoUmaImagem()
        {
            TelaFotos.EscolherImagem("1");
            TelaFotos.BaixarUmaImagem();
        }

        [When(@"escolho todas as imagens e as baixo")]
        public void QuandoEscolhoTodasAsImagensEAsBaixo()
        {
            TelaFotos.BaixarTotalImagens();
        }

        [Then(@"visualizo imagem baixada com sucesso")]
        public void EntaoVisualizoImagemBaixadaComSucesso()
        {
            TelaFotos.VerificarDownloadUmaImagem();
        }

        [Then(@"visualizo zip das imagens baixadas com sucesso")]
        public void EntaoVisualizoZipDasImagensBaixadasComSucesso()
        {
			TelaFotos.VerificarDownloadImagens();
        }
    }
}
