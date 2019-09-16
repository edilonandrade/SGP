using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class IndisponibilidadeElencoSteps
    {
        public IndisponibilidadeElencoPage TelaIndisponibilidadeElenco { get; private set; }

        public IndisponibilidadeElencoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaIndisponibilidadeElenco = new IndisponibilidadeElencoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["indisponibilidadeElencoUrl"]);
        }

        [Given(@"que eu acesse a tela de indisponibilidade de elenco")]
        public void DadoQueEuAcesseATelaDeIndisponibilidadeDeElenco()
        {
            TelaIndisponibilidadeElenco.Navegar();
        }

        [Given(@"que eu tenho uma indisponibilidade de elenco cadastrada")]
        public void DadoQueEuTenhoUmaIndisponibilidadeDeElencoCadastrada()
        {
            TelaIndisponibilidadeElenco.CadastrarNovaIndisponibilidadeElenco("LUCA AYRES", "06:00", "12:00");
            TelaIndisponibilidadeElenco.SalvarIndisponibilidade();
        }

        [When(@"eu faco busca por nome de elenco indisponivel")]
        public void QuandoEuFacoBuscaPorNomeDeElencoIndisponivel()
        {
            TelaIndisponibilidadeElenco.FiltrarIndisponibilidadeElenco("LUCA AYRES", "", "", "");
        }

        [When(@"eu faco busca por dia da semana de elenco indisponivel")]
        public void QuandoEuFacoBuscaPorDiaDaSemanaDeElencoIndisponivel()
        {
            TelaIndisponibilidadeElenco.FiltrarIndisponibilidadeElenco("LUCA AYRES", "", "", "Segunda");
        }

        [When(@"eu altero uma indisponibilidade de elenco cadastrada")]
        public void QuandoEuAlteroUmaIndisponibilidadeDeElencoCadastrada()
        {
            EntaoEuVisualizoAListagemDeIndisponibilidadeDeElencoComSucesso();
            TelaIndisponibilidadeElenco.EditarIndisponibilidadeElenco("15:00", "22:00");
            TelaIndisponibilidadeElenco.SalvarEdicaoIndisponinilidadeElenco();
        }

        [When(@"eu cadastro uma nova indisponibilidade de elenco")]
        public void QuandoEuCadastroUmaNovaIndisponibilidadeDeElenco()
        {
            DadoQueEuTenhoUmaIndisponibilidadeDeElencoCadastrada();
            QuandoEuFacoBuscaPorNomeDeElencoIndisponivel();
        }

        [Then(@"eu visualizo a indisponibilidade de elenco alterada com sucesso")]
        public void EntaoEuVisualizoAIndisponibilidadeDeElencoAlteradaComSucesso()
        {
            TelaIndisponibilidadeElenco.ValidarNovaIndisponibilidade("LUCA AYRES", "", "", "", "15:00", "22:00", "Teste INM");
        }

        [Then(@"eu visualizo a listagem de indisponibilidade de elenco com sucesso")]
        public void EntaoEuVisualizoAListagemDeIndisponibilidadeDeElencoComSucesso()
        {
            DadoQueEuTenhoUmaIndisponibilidadeDeElencoCadastrada();
            QuandoEuFacoBuscaPorNomeDeElencoIndisponivel();
            EntaoEuVisualizoAIndisponibilidadeDeElencoCadastradaComSucesso();
        }

        [Then(@"eu visualizo a indisponibilidade de elenco cadastrada com sucesso")]
        public void EntaoEuVisualizoAIndisponibilidadeDeElencoCadastradaComSucesso()
        {
            TelaIndisponibilidadeElenco.ValidarNovaIndisponibilidade("LUCA AYRES", "", "", "Segunda", "06:00", "12:00", "Teste INM");
        }

    }
}
