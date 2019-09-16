using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class GrupoDeGravacaoSteps
    {
        public GrupoLocalGravacaoPage TelaGrupoLocalGravacao { get; private set; }

        public GrupoDeGravacaoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaGrupoLocalGravacao = new GrupoLocalGravacaoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["GrupoLocalGravacaoUrl"]);
        }

        [Given(@"que eu acesse a tela de grupo local de gravacao")]
        public void DadoQueEuAcesseATelaDeGrupoLocalDeGravacao()
        {
            TelaGrupoLocalGravacao.Navegar();
        }

        [When(@"eu criar um novo local")]
        public void QuandoEuCriarUmNovoLocal()
        {
            TelaGrupoLocalGravacao.CriarGrupoLocalGravacao("INM LOCAL", "60", "60");
        }

        [When(@"eu excluo um local com capitulo associado")]
        public void QuandoEuExcluoUmLocalComCapituloAssociado()
        {
            TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("", "", "INMETRICS REGIAO 2");
        }

        [When(@"eu faco um filtro por local de gravacao A")]
        public void QuandoEuFacoUmFiltroPorLocalDeGravacaoA()
        {
            TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("INMETRICS REGIAO 2", "", "");
        }

        [When(@"eu faco um filtro por local de gravacao B")]
        public void QuandoEuFacoUmFiltroPorLocalDeGravacaoB()
        {
            TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("", "INMETRICS REGIAO", "");
        }

        [When(@"eu faco um filtro por grupo local de gravacao")]
        public void QuandoEuFacoUmFiltroPorGrupoLocalDeGravacao()
        {
            TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("", "", "INMETRICS REGIAO 2");
        }

        [When(@"faca uma alteracao")]
        public void QuandoFacaUmaAlteracao()
        {
            TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("INMETRICS REGIAO 2", "", "");
            TelaGrupoLocalGravacao.AlterarGrupoLocalGravacao("INMETRICS REGIAO 3", "60", "60");
        }

        [When(@"eu criar um novo local realizando o seu detalhamento")]
        public void QuandoEuCriarUmNovoLocalRealizandoOSeuDetalhamento()
        {
            QuandoEuCriarUmNovoLocal();
        }

        [Then(@"eu visualizo a mensagem de com sucesso")]
        public void EntaoEuVisualizoAMensagemDeComSucesso()
        {
            TelaGrupoLocalGravacao.ValidarMensagemDeAlteracao("0501", "007");
            TelaGrupoLocalGravacao.ValidarMensagemDeAlteracao("0501", "008");
        }

        [Then(@"eu visualizo o resultado do filtro por grupo local de gravacao com sucesso")]
        public void EntaoEuVisualizoOResultadoDoFiltroPorGrupoLocalDeGravacaoComSucesso()
        {
            TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INMETRICS REGIAO 2", "EQUIPE: 120   MINUTOS", "ELENCO: 120  MINUTOS");
            TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INMETRICS REGIAO", "EQUIPE: 120   MINUTOS", "ELENCO: 120  MINUTOS");
        }

        [Then(@"eu visualizo o resultado do filtro por local de gravacao B com sucesso")]
        public void EntaoEuVisualizoOResultadoDoFiltroPorLocalDeGravacaoBComSucesso()
        {
            TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INMETRICS REGIAO", "EQUIPE: 120   MINUTOS", "ELENCO: 120  MINUTOS");
        }

        [Then(@"eu visualizo o resultado do filtro por local de gravacao A com sucesso")]
        public void EntaoEuVisualizoOResultadoDoFiltroPorLocalDeGravacaoAComSucesso()
        {
            TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INMETRICS REGIAO 2", "EQUIPE: 120   MINUTOS", "ELENCO: 120  MINUTOS");
        }

        [Then(@"eu visualizo a mensagem de critica com sucesso")]
        public void EntaoEuVisualizoAMensagemDeCriticaComSucesso()
        {
            TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INMETRICS REGIAO 2", "EQUIPE: 120   MINUTOS", "ELENCO: 120  MINUTOS");
            TelaGrupoLocalGravacao.ExcluirGrupoLocalGravacaoComCapituloAssociadoText();
        }

        [Then(@"eu visualizo o novo local criado com sucesso")]
        public void EntaoEuVisualizoONovoLocalCriadoComSucesso()
        {
            TelaGrupoLocalGravacao.Navegar();
            TelaGrupoLocalGravacao.FiltroGrupoLocalGravacao("", "", "INM LOCAL");
            TelaGrupoLocalGravacao.ValidarGrupoLocalGravacao("INM LOCAL", "EQUIPE: 60   MINUTOS", "ELENCO: 60  MINUTOS");
            TelaGrupoLocalGravacao.ExcluirGrupoLocalGravacao();
        }

    }
}
