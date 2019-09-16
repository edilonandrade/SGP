using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class AcionamentoNovasTelasSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public AcionamentoNovasTelasPage TelaAcionamentoNovasTelas { get; private set; }

        public AcionamentoNovasTelasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaAcionamentoNovasTelas = new AcionamentoNovasTelasPage((IBrowser)browser);
        }

        [When(@"eu acessar a nova tela de indisponibilidade de elenco")]
        public void QuandoEuAcessarANovaTelaDeIndisponibilidadeDeElenco()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaIndisponibilidadeElenco();
        }

        [When(@"eu acessar a nova tela de local de gravacao")]
        public void QuandoEuAcessarANovaTelaDeLocalDeGravacao()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaLocalGravacao();
        }

        [When(@"eu acessar a nova tela de indisponibilidade de local")]
        public void QuandoEuAcessarANovaTelaDeIndisponibilidadeDeLocal()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaIndisponibilidadeLocal();
        }

        [When(@"eu acessar a nova tela de sequencia cenica")]
        public void QuandoEuAcessarANovaTelaDeSequenciaCenica()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaSequenciaCenica();
        }

        [When(@"eu acessar a nova tela de cenarios incompativeis")]
        public void QuandoEuAcessarANovaTelaDeCenariosIncompativeis()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaCenarioIncompativel();
        }

        [When(@"eu acessar a nova tela de grupo local de gravacao")]
        public void QuandoEuAcessarANovaTelaDeGrupoLocalDeGravacao()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaGrupoLocalGravacao();
        }

        [When(@"eu acessar a nova tela de parametros de producao")]
        public void QuandoEuAcessarANovaTelaDeParametrosDeProducao()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaParametrosDeProducao();
        }

        [When(@"eu acessar a nova tela de gestao de alertas")]
        public void QuandoEuAcessarANovaTelaDeGestaoDeAlertas()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
            TelaAcionamentoNovasTelas.AcessarTelaGestaoDeAlertas();
        }

        [Then(@"eu visualizo a nova tela de gestao de alertas com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeGestaoDeAlertasComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaGestaoDeAlertas();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de parametros de producao com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeParametrosDeProducaoComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaParametrosDeProducao();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de grupo local de gravacao com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeGrupoLocalDeGravacaoComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaGrupoLocalGravacao();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de cenarios incompativeis com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeCenariosIncompativeisComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaCenarioIncompativel();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de sequencia cenica com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeSequenciaCenicaComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaSequenciaCenica();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de indisponibilidade de local com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeIndisponibilidadeDeLocalComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaIndisponibilidadeLocal();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de local de gravacao com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeLocalDeGravacaoComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaLocalGravacao();
            TelaAcionamentoNovasTelas.FecharTela();
        }

        [Then(@"eu visualizo a nova tela de indisponibilidade de elenco com sucesso")]
        public void EntaoEuVisualizoANovaTelaDeIndisponibilidadeDeElencoComSucesso()
        {
            TelaAcionamentoNovasTelas.ValidarTelaIndisponibilidadeElenco();
            TelaAcionamentoNovasTelas.FecharTela();
        }

    }
}
