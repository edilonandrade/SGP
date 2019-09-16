using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class DecupagemBasicaGROTSteps
    {
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public PersonagemPage TelaPersonagem { get; private set; }
        public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
        public CenarioPage TelaCenario { get; private set; }
        public ConsultaDeLogPage TelaConsultaDeLog { get; private set; }
        public HomePage TelaHome { get; private set; }
        public ParametrosPage TelaParametros { get; private set; }

        public DecupagemBasicaGROTSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["CenarioURL"]);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
                ConfigurationManager.AppSettings["CapituloCenaURL"],
                ConfigurationManager.AppSettings["IncluirAdendoURL"],
                ConfigurationManager.AppSettings["IncluirCapituloURL"]);

            TelaCenario = new CenarioPage((IBrowser)browser,
                ConfigurationManager.AppSettings["CenarioURL"]);

            TelaPersonagem = new PersonagemPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PersonagemURL"]);

            TelaConsultaDeLog = new ConsultaDeLogPage((IBrowser)browser,
               ConfigurationManager.AppSettings["ConsultaLogUrl"]);

            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaParametros = new ParametrosPage((IBrowser)browser,
               ConfigurationManager.AppSettings["ParametrosURL"]);
        }

        [Given(@"que eu navegue para a Tela de Decupagem Basica atraves de atalho")]
        public void DadoQueEuNavegueParaATelaDeDecupagemBasicaAtravesDeAtalho()
        {
            TelaCapituloCena.Navegar();
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0400");
            TelaDecupagemBasica.AcessarDecupagemBasica();
        }

        [Given(@"que eu tenha uma cena decupada")]
        public void DadoQueEuTenhaUmaCenaDecupada()
        {
            QuandoEuFacoUmaDecupagemBasicaComPerfilGROT();
        }

        [Given(@"visualizo os novos campos de decupagem basica")]
        public void DadoVisualizoOsNovosCamposDeDecupagemBasica()
        {
            TelaDecupagemBasica.ValidarValoresCamposGROT("", "3", "", "");
        }

        [Given(@"que eu acesse a tela de parametros de producao apos criar um capitulo")]
        public void DadoQueEuAcesseATelaDeParametrosDeProducaoAposCriarUmCapitulo()
        {
            TelaCapituloCena.Navegar();
            TelaHome.AcessarMenuList("Parâmetros de Produção");
        }

        [When(@"eu acesso a tela de parametros")]
        public void QuandoEuAcessoATelaDeParametros()
        {
            TelaHome.Navegar();
            TelaHome.AcessarMenuList("Parâmetros de Produção");
        }

        [When(@"altero os valores padroes desses campos")]
        public void QuandoAlteroOsValoresPadroesDessesCampos()
        {
            TelaParametros.PreencherDiasAntecedencia("10");
        }

        [When(@"eu realizo uma alteracao na decupagem basica")]
        public void QuandoEuRealizoUmaAlteracaoNaDecupagemBasica()
        {
            TelaCapituloCena.Navegar();
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0400");
            TelaDecupagemBasica.AcessarEdicaoDecupagemBasica();
            TelaDecupagemBasica.EditarDecuparCenaCompletaGROT("0400", "", "", "", "",
                "50", "10", "06:00", "13:00");
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu faco uma decupagem basica preenchendo os novos campos GROT")]
        public void QuandoEuFacoUmaDecupagemBasicaPreenchendoOsNovosCamposGROT()
        {
            TelaDecupagemBasica.DecuparCenaCompletaGROT("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES",
                "4", "5", "08:00", "12:00");
        }

        [When(@"eu faco uma decupagem basica com perfil GROT")]
        public void QuandoEuFacoUmaDecupagemBasicaComPerfilGROT()
        {
            QuandoEuFacoUmaDecupagemBasicaPreenchendoOsNovosCamposGROT();
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu faco uma decupagem basica preenchendo o campo duracao com caracteres invalidos")]
        public void QuandoEuFacoUmaDecupagemBasicaPreenchendoOCampoDuracaoComCaracteresInvalidos()
        {
            TelaDecupagemBasica.DecuparCenaCompletaGROT("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES",
                "INM", "5", "08:00", "12:00");
            TelaDecupagemBasica.PreencherDuracao("12345");
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu crio um novo local durante a decupagem basica")]
        public void QuandoEuCrioUmNovoLocalDuranteADecupagemBasica()
        {
            TelaDecupagemBasica.DecuparCenaCompletaGROT("0400", "", "", "INMETRICS PERSONAGEM", "FIGURANTES",
                "4", "5", "08:00", "12:00");
            TelaCenario.CriarNovoCenarioGROT("LOCACAO", "INM ESTUDIO", "INM LOCAL", "INM NOVA VIAGEM", "INM NOVA REGIAO");
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu faco uma decupagem basica para o periodo Dia")]
        public void QuandoEuFacoUmaDecupagemBasicaParaOPeriodoDia()
        {
            QuandoEuFacoUmaDecupagemBasicaComPerfilGROT();
        }

        [When(@"eu faco uma decupagem basica para o periodo Tarde")]
        public void QuandoEuFacoUmaDecupagemBasicaParaOPeriodoTarde()
        {
            QuandoEuFacoUmaDecupagemBasicaPreenchendoOsNovosCamposGROT();
            TelaDecupagemBasica.EscolherTempo("1");
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu faco uma decupagem basica para o periodo Noite")]
        public void QuandoEuFacoUmaDecupagemBasicaParaOPeriodoNoite()
        {
            QuandoEuFacoUmaDecupagemBasicaPreenchendoOsNovosCamposGROT();
            TelaDecupagemBasica.EscolherTempo("2");
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu edito a cena decupada limpando os campos GROT")]
        public void QuandoEuEditoACenaDecupadaLimpandoOsCamposGROT()
        {
            TelaCapituloCena.Navegar();
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0400");
            TelaDecupagemBasica.AcessarEdicaoDecupagemBasica();
            TelaDecupagemBasica.EditarDecuparCenaCompletaGROT("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES",
                "0", "0", "0", "0");
            TelaDecupagemBasica.SalvarCena();
        }

        [When(@"eu altero os valores de periodo noturno")]
        public void QuandoEuAlteroOsValoresDePeriodoNoturno()
        {
            TelaParametros.AlterarParametrosDePeriodoNoturno("19:00", "22:00");
        }

        [Then(@"eu visualizo que a alteracao feita nao foi refletida na tela de decupagem basica com sucesso")]
        public void EntaoEuVisualizoQueAAlteracaoFeitaNaoFoiRefletidaNaTelaDeDecupagemBasicaComSucesso()
        {
            TelaDecupagemBasica.Navegar();
            TelaDecupagemBasica.ValidarValoresCamposGROT("", "", "", "");
            TelaCapituloCena.Navegar();
            TelaHome.AcessarMenuList("Parâmetros de Produção");
            TelaParametros.AlterarParametrosDePeriodoNoturno("18:00", "23:59");
        }

        [Then(@"eu visualizo a Cena criada com periodo dia com sucesso")]
        public void EntaoEuVisualizoACenaCriadaComPeriodoDiaComSucesso()
        {
            TelaCapituloCena.VerificarCena("capituloDe", "0400", "001");
            TelaCapituloCena.VerificarDetalhesCena("Periodo", "Dia");
        }

        [Then(@"eu visualizo a Cena criada com periodo tarde com sucesso")]
        public void EntaoEuVisualizoACenaCriadaComPeriodoTardeComSucesso()
        {
            TelaCapituloCena.VerificarCena("capituloDe", "0400", "001");
            TelaCapituloCena.VerificarDetalhesCena("Periodo", "Tarde");
        }

        [Then(@"eu visualizo a Cena criada com periodo noite com sucesso")]
        public void EntaoEuVisualizoACenaCriadaComPeriodoNoiteComSucesso()
        {
            TelaCapituloCena.VerificarCena("capituloDe", "0400", "001");
            TelaCapituloCena.VerificarDetalhesCena("Periodo", "Noite");
        }

        [Then(@"eu visualizo a Cena criada com sucesso com o campo duracao exibindo o ultimo caracter valido")]
        public void EntaoEuVisualizoACenaCriadaComSucessoComOCampoDuracaoExibindoOUltimoCaracterValido()
        {
            TelaCapituloCena.VerificarCena("capituloDe", "0400", "001");
        }

        [Then(@"eu visualizo os novos campos de decupagem basica com sucesso")]
        public void EntaoEuVisualizoOsNovosCamposDeDecupagemBasicaComSucesso()
        {
            TelaDecupagemBasica.ValidarNovosCamposDecupagemBasica("Duração(minuto)");
            TelaDecupagemBasica.ValidarNovosCamposDecupagemBasica("Limite de Gravação em relação à exibição(dias)");
            TelaDecupagemBasica.ValidarNovosCamposDecupagemBasica("Faixa prevista Gravação (hh:mm)");
        }

        [Then(@"eu visualizo a alteracao feita no log com sucesso")]
        public void EntaoEuVisualizoAAlteracaoFeitaNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBusca("Edição");
            TelaConsultaDeLog.ValidarBusca("Duração(minuto)");
            TelaConsultaDeLog.ValidarBusca("Limite de Gravação em relação à exibição(dias)");
            TelaConsultaDeLog.ValidarBusca("Faixa Prevista Gravação: Inicial, Faixa Prevista Gravação: Final");
        }

        [Then(@"eu visualizo os valores atualizados na tela de decupagem basica")]
        public void EntaoEuVisualizoOsValoresAtualizadosNaTelaDeDecupagemBasica()
        {
            TelaCapituloCena.Navegar();
            TelaCapituloCena.FiltrarCapitulos("capituloDe", "0400");
            TelaDecupagemBasica.AcessarDecupagemBasica();
            TelaDecupagemBasica.ValidarValoresCamposGROT("10", "10", "", "");
        }

    }
}
