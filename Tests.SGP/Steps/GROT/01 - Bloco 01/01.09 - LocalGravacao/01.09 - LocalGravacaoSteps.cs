using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class LocalGravacaoSteps
    {
        public LocalGravacaoPage TelaLocalGravacao { get; private set; }

        public LocalGravacaoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaLocalGravacao = new LocalGravacaoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["LocalGravacaoUrl"]);
        }

        [Given(@"que eu acesse a tela de local de gravacao")]
        public void DadoQueEuAcesseATelaDeLocalDeGravacao()
        {
            TelaLocalGravacao.Navegar();
        }

        [Given(@"tenha um local de gravacao cadastrado")]
        public void DadoTenhaUmLocalDeGravacaoCadastrado()
        {
            QuandoEuCrioUmNovoLocalDeGravacao();
        }

        [When(@"eu faco busca por local de gravacao")]
        public void QuandoEuFacoBuscaPorLocalDeGravacao()
        {
            TelaLocalGravacao.FiltrarLocalGravacao("INM LOCAL", "", "");
        }

        [When(@"eu crio um novo local de gravacao")]
        public void QuandoEuCrioUmNovoLocalDeGravacao()
        {
            TelaLocalGravacao.CriarNovoLocal("INM LOCAL", "INM VIAGEM", "INMETRICS REGIAO 2");
        }

        [When(@"eu faco busca por tipo de local de gravacao")]
        public void QuandoEuFacoBuscaPorTipoDeLocalDeGravacao()
        {
            TelaLocalGravacao.FiltrarLocalGravacao("INM LOCAL", "Externa", "");
        }

        [When(@"eu editar um local de gravacao")]
        public void QuandoEuEditarUmLocalDeGravacao()
        {
            QuandoEuFacoBuscaPorTipoDeLocalDeGravacao();
            TelaLocalGravacao.EditarLocal("INM LOCAL 2");
        }

        [When(@"eu faco busca por local de gravacao com cenas associadas")]
        public void QuandoEuFacoBuscaPorLocalDeGravacaoComCenasAssociadas()
        {
            TelaLocalGravacao.FiltrarLocalGravacao("INMETRICS LOCAL 2", "", "");
        }

        [Then(@"eu visualizo o alerta de exclusao com sucesso")]
        public void EntaoEuVisualizoOAlertaDeExclusaoComSucesso()
        {
            TelaLocalGravacao.ExcluirLocalComCenasAssociadas();
            TelaLocalGravacao.ValidarLocal("INMETRICS LOCAL 2", "Externa", "", "", "", "INMETRICS REGIAO 2");
        }

        [Then(@"eu visualizo o local de gravacao editado com sucesso")]
        public void EntaoEuVisualizoOLocalDeGravacaoEditadoComSucesso()
        {
            QuandoEuFacoBuscaPorTipoDeLocalDeGravacao();
            TelaLocalGravacao.ValidarLocal("INM LOCAL 2", "Externa", "", "", "INM VIAGEM", "INMETRICS REGIAO 2");
        }

        [Then(@"eu visualizo o local de gravacao criado com sucesso")]
        public void EntaoEuVisualizoOLocalDeGravacaoCriadoComSucesso()
        {
            QuandoEuFacoBuscaPorLocalDeGravacao();
            EntaoEuVisualizoOLocalDeGravacaoComSucesso();
        }

        [Then(@"eu visualizo o local de gravacao com sucesso")]
        public void EntaoEuVisualizoOLocalDeGravacaoComSucesso()
        {
            TelaLocalGravacao.ValidarLocal("INM LOCAL", "Externa", "", "", "INM VIAGEM", "INMETRICS REGIAO 2");
        }

    }
}
