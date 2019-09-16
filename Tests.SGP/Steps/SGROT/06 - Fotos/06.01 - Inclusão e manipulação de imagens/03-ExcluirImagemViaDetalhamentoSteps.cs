using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class ExcluirImagemViaDetalhamentoSteps
    {
        public FotosPage TelaFotos { get; private set; }

        public ExcluirImagemViaDetalhamentoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaFotos = new FotosPage((IBrowser)browser,
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["RoteiroURL"]);
        }

        [When(@"escolho uma imagem via janela de detalhamento e excluo")]
        public void QuandoEscolhoUmaImagemViaJanelaDeDetalhamentoEExcluo()
        {
            TelaFotos.ExcluirImagemViaDetalhamento("1");
        }

        [Then(@"visualizo imagem excluida com sucesso")]
        public void EntaoVisualizoImagemExcluidaComSucesso()
        {
            TelaFotos.VerificarExclusaoFoto();
        }
    }
}





