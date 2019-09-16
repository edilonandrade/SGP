using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class IndisponibLocaisSteps
    {
        public IndisponibilidadeLocaisPage TelaIndisponibilidadeLocais { get; private set; }

        public IndisponibLocaisSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaIndisponibilidadeLocais = new IndisponibilidadeLocaisPage((IBrowser)browser,
               ConfigurationManager.AppSettings["indisponibilidadeLocal"]);
        }

        [Given(@"que eu acesse a tela de indisponibilidade de locais")]
        public void DadoQueEuAcesseATelaDeIndisponibilidadeDeLocais()
        {
            TelaIndisponibilidadeLocais.Navegar();
        }

        [Given(@"que eu tenho uma indisponibilidade de local cadastrada")]
        public void DadoQueEuTenhoUmaIndisponibilidadeDeLocalCadastrada()
        {
            TelaIndisponibilidadeLocais.CadastrarIndisponibilidadeLocal("INMETRICS LOCAL 2");
            TelaIndisponibilidadeLocais.SalvarIndisponibilidadeLocal();
        }

        [When(@"eu cadastro uma nova indisponibilidade")]
        public void QuandoEuCadastroUmaNovaInndisponibilidade()
        {
            DadoQueEuTenhoUmaIndisponibilidadeDeLocalCadastrada();
            QuandoEuFacoBuscaPorNomeDeLocalIndisponivel();
        }

        [When(@"eu faco busca por nome de local indisponivel")]
        public void QuandoEuFacoBuscaPorNomeDeLocalIndisponivel()
        {
            TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL 2", "", "");
        }

        [When(@"eu faco busca por dia da semana na tela de indisponibilidade de locais")]
        public void QuandoEuFacoBuscaPorDiaDaSemanaNaTelaDeIndisponibilidadeDeLocais()
        {
            TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL 2", "", "segunda");
        }

        [When(@"eu faco busca por periodo na tela de indisponibilidade de locais")]
        public void QuandoEuFacoBuscaPorPeriodoNaTelaDeIndisponibilidadeDeLocais()
        {
            TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL 2", "Atual", "");
        }

        [When(@"eu excluo uma indisponibilidade de local")]
        public void QuandoEuExcluoUmaIndisponibilidadeDeLocal()
        {
            TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL 2", "Atual", "");
            TelaIndisponibilidadeLocais.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL 2");
            TelaIndisponibilidadeLocais.ExcluirIndisponibilidadeLocais();
        }

        [When(@"eu cadastro duas indisponibilidade de local")]
        public void QuandoEuCadastroDuasIndisponibilidadeDeLocal()
        {
            TelaIndisponibilidadeLocais.CadastrarIndisponibilidadeLocal("INMETRICS LOCAL 2");
            TelaIndisponibilidadeLocais.SalvarECriarNovaIndisponibilidadeLocal();
            TelaIndisponibilidadeLocais.CadastrarIndisponibilidadeLocal2("INMETRICS LOCAL");
            TelaIndisponibilidadeLocais.SalvarIndisponibilidadeLocal();
            TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL", "", "");
        }

        [Then(@"eu visualizo as duas indisponibilidades de local cadastrada com sucesso")]
        public void EntaoEuVisualizoAsDuasIndisponibilidadesDeLocalCadastradaComSucesso()
        {
            TelaIndisponibilidadeLocais.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL");
            TelaIndisponibilidadeLocais.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL 2");
            TelaIndisponibilidadeLocais.FiltrarIndisponibilidadeLocais("INMETRICS LOCAL 2", "Atual", "");
            TelaIndisponibilidadeLocais.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL 2");
            TelaIndisponibilidadeLocais.ExcluirIndisponibilidadeLocais();
        }

        [Then(@"eu nao visualizo mais a indisponibilidade de local cadastrada com sucesso")]
        public void EntaoEuNaoVisualizoMaisAIndisponibilidadeDeLocalCadastradaComSucesso()
        {
            TelaIndisponibilidadeLocais.ValidarIndisponibilidadeExcluida("INMETRICS LOCAL 2");
        }

        [Then(@"eu visualizo a indisponibilidade de local cadastrada com sucesso")]
        public void EntaoEuVisualizoAIndisponibilidadeDeLocalCadastradaComSucesso()
        {
            TelaIndisponibilidadeLocais.ValidarIndisponibilidadeCadastrada("INMETRICS LOCAL 2");
        }

    }
}
