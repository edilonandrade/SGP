using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class SequeciaCenicaSteps
    {
        public SequeciaCenicaPage TelaSequeciaCenica { get; private set; }

        public SequeciaCenicaSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaSequeciaCenica = new SequeciaCenicaPage((IBrowser)browser,
               ConfigurationManager.AppSettings["SequenciaCenicaUrl"]);
        }

        [Given(@"que eu navegue para a tela de sequecia cenica")]
        public void DadoQueEuNavegueParaATelaDeSequeciaCenica()
        {
            TelaSequeciaCenica.Navegar();
        }

        [Given(@"que eu tenho uma sequencia cenica criada")]
        public void DadoQueEuTenhoUmaSequenciaCenicaCriada()
        {
            QuandoEuCriarUmaSequenciaCenica();
        }

        [Given(@"que eu clico no botao de nova sequencia cenica")]
        public void DadoQueEuClicoNoBotaoDeNovaSequenciaCenica()
        {
            QuandoEuClicoNoBotaoDeNovaSequenciaCenica();
        }

        [When(@"eu clico no botao de filtrar cenas")]
        public void QuandoEuClicoNoBotaoDeFiltrarCenas()
        {
            TelaSequeciaCenica.ClicarFiltrarCenas();
        }

        [When(@"eu faco busca pela sequencia cenica")]
        public void QuandoEuFacoBuscaPelaSequenciaCenica()
        {
            TelaSequeciaCenica.FiltrarSequenciaCenica("INM SEQUENCIA");
        }

        [When(@"eu criar uma sequencia cenica")]
        public void QuandoEuCriarUmaSequenciaCenica()
        {
            TelaSequeciaCenica.CriarSequenciaCenica("INM SEQUENCIA", "0159/019A", "0159/019B");
            TelaSequeciaCenica.SalvarSequenciaCenica();
        }

        [When(@"eu clico no botao de nova sequencia cenica")]
        public void QuandoEuClicoNoBotaoDeNovaSequenciaCenica()
        {
            TelaSequeciaCenica.ClicarNovaSequenciaCenica();
        }

        [When(@"eu clico num cena")]
        public void QuandoEuClicoNumCena()
        {
            TelaSequeciaCenica.CriarSequenciaCenica("INM SEQUENCIA", "0159/019A", "0159/019B");
        }

        [When(@"eu faco uma alteracao na sequencia cenica criada")]
        public void QuandoEuFacoUmaAlteracaoNaSequenciaCenicaCriada()
        {
            QuandoEuFacoBuscaPelaSequenciaCenica();
            TelaSequeciaCenica.EditarSequenciaCenica("INM NOVA SEQUENCIA", "", "");
            TelaSequeciaCenica.SalvarSequenciaCenica();
        }

        [When(@"eu altero a ordem da sequemcia")]
        public void QuandoEuAlteroAOrdemDaSequemcia()
        {
            QuandoEuFacoBuscaPelaSequenciaCenica();
            TelaSequeciaCenica.EditarSequenciaCenica("INM NOVA SEQUENCIA", "", "");
            TelaSequeciaCenica.AlterarOrdemDaSequencia("0159/019A");
            TelaSequeciaCenica.SalvarSequenciaCenica();
        }

        [When(@"eu criar uma sequencia cenica na ordem desejada")]
        public void QuandoEuCriarUmaSequenciaCenicaNaOrdemDesejada()
        {
            QuandoEuCriarUmaSequenciaCenica();
        }

        [Then(@"eu visualizo a sequencia cenica criada na ordem desejada com sucesso")]
        public void EntaoEuVisualizoASequenciaCenicaCriadaNaOrdemDesejadaComSucesso()
        {
            TelaSequeciaCenica.FiltrarSequenciaCenica("INM NOVA SEQUENCIA");
            TelaSequeciaCenica.ExibirCenas();
            TelaSequeciaCenica.ValidarNomeSequencia("INM NOVA SEQUENCIA");
            TelaSequeciaCenica.ValidarSequenciaCenica("1", "0159", "019A");
            TelaSequeciaCenica.ValidarSequenciaCenica("2", "0159", "019B");
        }

        [When(@"eu excluo a sequencia cenica")]
        public void QuandoEuExcluoASequenciaCenica()
        {
            TelaSequeciaCenica.ExcluirSequenciaCenica("INM SEQUENCIA");
        }

        [When(@"eu faco busca pela sequencia cenica somente por cenas nao gravadas")]
        public void QuandoEuFacoBuscaPelaSequenciaCenicaSomentePorCenasNaoGravadas()
        {
            TelaSequeciaCenica.FiltrarSequenciaCenica("INM SEQUENCIA");
            TelaSequeciaCenica.ValidarChck();
        }

        [Then(@"eu nao visualizo mas a sequencia cenica com sucesso")]
        public void EntaoEuNaoVisualizoMasASequenciaCenicaComSucesso()
        {
            QuandoEuFacoBuscaPelaSequenciaCenica();
            TelaSequeciaCenica.ValidarExclusaoSequencia("INM SEQUENCIA");
        }

        [Then(@"eu visualizo a altercao feita na sequencia cenica com sucesso")]
        public void EntaoEuVisualizoAAltercaoFeitaNaSequenciaCenicaComSucesso()
        {
            TelaSequeciaCenica.FiltrarSequenciaCenica("INM NOVA SEQUENCIA");
            TelaSequeciaCenica.ValidarNomeSequencia("INM NOVA SEQUENCIA");
            TelaSequeciaCenica.ExibirCenas();
            TelaSequeciaCenica.ValidarSequenciaCenica("1", "0159", "019B");
            TelaSequeciaCenica.ValidarSequenciaCenica("2", "0159", "019A");
        }

        [Then(@"eu visualizo os detalhes da cena com sucesso")]
        public void EntaoEuVisualizoOsDetalhesDaCenaComSucesso()
        {
            TelaSequeciaCenica.ValidarDetalhes();
        }

        [Then(@"eu visualizo as cenas existentes para o produto com sucesso")]
        public void EntaoEuVisualizoAsCenasExistentesParaOProdutoComSucesso()
        {
            TelaSequeciaCenica.ValidarCenario("CASA DE SEBASTIÃO1", "0159/019B");
            TelaSequeciaCenica.ValidarCenario("CASA DE SEBASTIÃO1", "0159/019A");
        }

        [Then(@"eu visualizo as cenas por cenario e capitulos com sucesso")]
        public void EntaoEuVisualizoAsCenasPorCenarioECapitulosComSucesso()
        {
            TelaSequeciaCenica.ValidarCenario("CASA DE SEBASTIÃO1", "0159/019B");
            TelaSequeciaCenica.ValidarCapitulo("CAPÍTULO 0159");
        }

        [Then(@"eu visualizo a sequencia cenica criada com sucesso")]
        public void EntaoEuVisualizoASequenciaCenicaCriadaComSucesso()
        {
            TelaSequeciaCenica.FiltrarSequenciaCenica("INM SEQUENCIA");
            TelaSequeciaCenica.ExibirCenas();
            TelaSequeciaCenica.ValidarNomeSequencia("INM SEQUENCIA");
            TelaSequeciaCenica.ValidarSequenciaCenica("1", "0159", "019B");
            TelaSequeciaCenica.ValidarSequenciaCenica("2", "0159", "019A");
        }

        [Then(@"eu visualizo as opcoes de filtro de cenas disponiveis com sucesso")]
        public void EntaoEuVisualizoAsOpcoesDeFiltroDeCenasDisponiveisComSucesso()
        {
            TelaSequeciaCenica.ValidarFiltroDeCenas("Tipo");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Cenário");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Personagem");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Status");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Classificacões");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Categorias");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Período do dia");
            TelaSequeciaCenica.ValidarFiltroDeCenas("Capítulos");
        }

    }
}
