using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class DecupagemContinuidadeSteps
    {
        public DecupagemContinuidadePage TelaDecupagemContinuidade { get; private set; }
        public DecupagemArtePage TelaDecupagemArte { get; private set; }
        public CriarDecupagemContinuidade StepsCriarDecupagemContinuidade { get; private set; }
        public ConsultaDeLogPage TelaConsultaDeLog { get; private set; }
        public CapitulosCenasPage TelaCapituloCena { get; private set; }

        public DecupagemContinuidadeSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaDecupagemContinuidade = new DecupagemContinuidadePage((IBrowser)browser,
            ConfigurationManager.AppSettings["DecupagemContinuidadeURL"]);

            TelaDecupagemArte = new DecupagemArtePage((IBrowser)browser,
            ConfigurationManager.AppSettings["DecupagemArteURL"]);

            StepsCriarDecupagemContinuidade = new CriarDecupagemContinuidade();

            TelaConsultaDeLog = new ConsultaDeLogPage((IBrowser)browser,
               ConfigurationManager.AppSettings["ConsultaLogUrl"]);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CapituloCenaURL"],
               ConfigurationManager.AppSettings["IncluirCapituloURL"],
               ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [Given(@"que eu crie uma decupagem de continuidade com perfil grot")]
        public void DadoQueEuCrieUmaDecupagemDeContinuidadeComPerfilGrot()
        {
            TelaDecupagemContinuidade.Navegar();
            QuandoCriarUmaDecupagemDeContinuidadeGrot();
            TelaDecupagemContinuidade.VerificarMensagemDecupagemContinuidade("Decupagem salva com sucesso.");
        }

        [Given(@"que eu crie uma decupagem de continuidade com perfil grot sem preencher o novo campo")]
        public void DadoQueEuCrieUmaDecupagemDeContinuidadeComPerfilGrotSemPreencherONovoCampo()
        {
            TelaDecupagemContinuidade.Navegar();
            TelaDecupagemContinuidade.CriarDecupagemContinuidadeGROT("0400", "001", "09:00", "60", "");
            TelaDecupagemContinuidade.ClicarBtnSalvarContinuidade();
            TelaDecupagemContinuidade.VerificarMensagemDecupagemContinuidade("Decupagem salva com sucesso.");
        }

        [Given(@"que eu crie uma decupagem de continuidade com perfil grot atraves do atalho na tela de capitulos e cenas")]
        public void DadoQueEuCrieUmaDecupagemDeContinuidadeComPerfilGrotAtravesDoAtalhoNaTelaDeCapitulosECenas()
        {
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0400");
            TelaDecupagemContinuidade.AcessarDecupagemDeContinuidade();
            QuandoCriarUmaDecupagemDeContinuidadeGrot();
        }

        [When(@"eu faco busca por cena em consulta de log")]
        public void QuandoEuFacoBuscaPorCenaEmConsultaDeLog()
        {
            TelaConsultaDeLog.Navegar();
            TelaConsultaDeLog.FiltroConsultaLog("Cena", "0");
        }

        [When(@"criar uma decupagem de continuidade grot")]
        public void QuandoCriarUmaDecupagemDeContinuidadeGrot()
        {
            TelaDecupagemContinuidade.CriarDecupagemContinuidadeGROT("0400", "001", "09:00", "60", "45");
            TelaDecupagemContinuidade.ClicarBtnSalvarContinuidade();
        }

        [When(@"eu edito a decupagem de continuidade da cena limpando a informacao do campo de tempo preparacao")]
        public void QuandoEuEditoADecupagemDeContinuidadeDaCenaLimpandoAInformacaoDoCampoDeTempoPreparacao()
        {
            TelaDecupagemContinuidade.Navegar();
            TelaDecupagemContinuidade.CriarDecupagemContinuidadeGROT("0400", "001", "", "60", "0");
            TelaDecupagemContinuidade.ClicarBtnSalvarContinuidade();
            TelaDecupagemContinuidade.VerificarMensagemDecupagemContinuidade("Decupagem salva com sucesso.");
        }

        [When(@"eu edito a decupagem de continuidade da cena alterando a informacao do campo de tempo preparacao")]
        public void QuandoEuEditoADecupagemDeContinuidadeDaCenaAlterandoAInformacaoDoCampoDeTempoPreparacao()
        {
            TelaDecupagemContinuidade.Navegar();
            TelaDecupagemContinuidade.CriarDecupagemContinuidadeGROT("0400", "001", "", "60", "80");
            TelaDecupagemContinuidade.ClicarBtnSalvarContinuidade();
            TelaDecupagemContinuidade.VerificarMensagemDecupagemContinuidade("Decupagem salva com sucesso.");
        }

        [Then(@"eu visualizo as alteracoes de decupagem de continuidade realizada com sucesso no log do sistema")]
        public void EntaoEuVisualizoAsAlteracoesDeDecupagemDeContinuidadeRealizadaComSucessoNoLogDoSistema()
        {
            QuandoEuFacoBuscaPorCenaEmConsultaDeLog();
            EntaoEuVisualizoAEdicaoDeDecupagemDeContinuidadeComSucesso();
        }

        [When(@"criar uma decupagem de continuidade grot alterando os valores de tempo de preparacao")]
        public void QuandoCriarUmaDecupagemDeContinuidadeGrotAlterandoOsValoresDeTempoDePreparacao()
        {
            TelaDecupagemContinuidade.CriarDecupagemContinuidadeGROT("0400", "001", "09:00", "60", "INM");
            TelaDecupagemContinuidade.PreencherDadosPersonagemContinuidadeGROT("", "", "12345");
            TelaDecupagemContinuidade.PreencherDadosPersonagemContinuidadeGROT("", "", "2222");
            TelaDecupagemContinuidade.ClicarBtnSalvarContinuidade();
        }

        [Then(@"eu visualizo a edicao de decupagem de continuidade com sucesso")]
        public void EntaoEuVisualizoAEdicaoDeDecupagemDeContinuidadeComSucesso()
        {
            TelaConsultaDeLog.ValidarBusca("Edição");
            TelaConsultaDeLog.ValidarBusca("Hora Cênica, Observação de Continuidade, Dia Cênico, Sequência, Observação Geral, Observação de Continuidade para Arte");
        }

    }
}
