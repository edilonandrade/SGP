using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class IndicadoresProdutoSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public HomePage TelaHome { get; private set; }
        public IndisponibilidadeLocaisPage TelaLocal { get; private set; }
        public IndicadoresProdutoPage TelaIndicadoresProduto { get; private set; }

        public IndicadoresProdutoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaLocal = new IndisponibilidadeLocaisPage((IBrowser)browser,
                ConfigurationManager.AppSettings["IndisponibilidadeLocal"]);

            TelaIndicadoresProduto = new IndicadoresProdutoPage((IBrowser)browser);
        }

        [Given(@"que eu navegue para a Tela de Planejamento de Roteiros GROT")]
        public void DadoQueEuNavegueParaATelaDePlanejamentoDeRoteirosGROT()
        {
            TelaPlanejamentoGROT.Navegar();
        }

        [When(@"eu acessar a lista de indicadores do produto")]
        public void QuandoEuAcessarAListaDeIndicadoresDoProduto()
        {
            TelaIndicadoresProduto.ClicarIndicadoresDeProduto();
        }

        [When(@"clicar em fechar a tela")]
        public void QuandoClicarEmFecharATela()
        {
            EntaoEuVisualizoOCampoProdutoPorDefaultComSucesso();
        }

        [When(@"alterar o produto")]
        public void QuandoAlterarOProduto()
        {
            TelaIndicadoresProduto.AlterarProduto("A PRINCESA E O VAGABUNDO");
        }

        [When(@"seleciono mais de um produto")]
        public void QuandoSelecionoMaisDeUmProduto()
        {
            TelaIndicadoresProduto.AlterarProduto("100 ANOS DE MUSICA");
            TelaIndicadoresProduto.ValidarIndicadoresProduto("100 ANOS DE MUSICA");
            TelaIndicadoresProduto.AlterarProduto("A PRINCESA E O VAGABUNDO");
        }

        [Then(@"eu visualizo o novo produto com sucesso")]
        public void EntaoEuVisualizoONovoProdutoComSucesso()
        {
            TelaIndicadoresProduto.ValidarIndicadoresProduto("A PRINCESA E O VAGABUNDO");
            TelaIndicadoresProduto.FecharTela();
            EntaoEuVisualizoATelaDePlanejamentoDeRoteirosComSucesso();
        }

        [Then(@"eu visualizo a tela de planejamento de roteiros com sucesso")]
        public void EntaoEuVisualizoATelaDePlanejamentoDeRoteirosComSucesso()
        {
            TelaIndicadoresProduto.ValidarFecharTela();
        }

        [Then(@"eu visualizo o campo produto por default com sucesso")]
        public void EntaoEuVisualizoOCampoProdutoPorDefaultComSucesso()
        {
            TelaIndicadoresProduto.ValidarIndicadoresProduto("A CURA");
            TelaIndicadoresProduto.FecharTela();
            EntaoEuVisualizoATelaDePlanejamentoDeRoteirosComSucesso();
        }

    }
}
