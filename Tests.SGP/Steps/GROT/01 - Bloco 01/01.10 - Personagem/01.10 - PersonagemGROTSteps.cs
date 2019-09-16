using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class PersonagemGROTSteps
    {
        public PersonagemGROTPage TelaPersonagem { get; private set; }
        public ParametrosPage TelaParametros { get; private set; }

        public HomePage TelaHome { get; private set; }

        public ConsultaDeLogPage TelaConsultaDeLog { get; private set; }
        
        public PersonagemGROTSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPersonagem = new PersonagemGROTPage((IBrowser)browser, ConfigurationManager.AppSettings["PersonagemURL"]);
            TelaParametros = new ParametrosPage((IBrowser)browser, ConfigurationManager.AppSettings["ParametrosURL"]);
            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
            TelaConsultaDeLog = new ConsultaDeLogPage((IBrowser)browser, ConfigurationManager.AppSettings["ConsultaLogUrl"]);
        }

        //Given
        [Given(@"que esteja na tela Parametros")]
        public void DadoQueEstejaNaTelaParametros()
        {
            TelaHome.AcessarMenuList("Parâmetros de Produção");
        }
        
        [Given(@"que esteja na tela de Personagem")]
        public void DadoQueEstejaNaTelaDePersonagem()
        {
            TelaPersonagem.Navegar();
        }
        
        //When
        [When(@"cadastrar um novo personagem")]
        public void QuandoCadastrarUmNovoPersonagem()
        {
            TelaPersonagem.CriarPersonagem("INM PERSONAGEM", "DIO FREITAS", "Normal", "40", "6", "30", "12");
        }

        [When(@"eu seleciono um Personagem para edicao")]
        public void QuandoEuSelecionoUmPersonagemParaEdicao()
        {
            QuandoCadastrarUmNovoPersonagem();
            TelaPersonagem.AlterarPersonagem("", "", "INM PERSONAGEM", "20", "8", "40", "5", "2");
        }

        [When(@"valido novos campos criados em Novo Personagem")]
        public void QuandoValidoNovosCamposCriadosEmNovoPersonagem()
        {
            TelaPersonagem.ClicarNovoPersonagem();
            TelaPersonagem.GravarNovosCamposPersonagem("Normal", "4321", "233", "321", "32", "9");
        }

        [When(@"eu altero os valores dos novos campos criados")]
        public void QuandoEuAlteroOsValoresDosNovosCamposCriados()
        {
            TelaParametros.AlterarParametrosPersonagem("4", "4", "4", "4");
        }

        [When(@"cadastrar um novo personagem alterando os valores padroes de paramentro")]
        public void QuandoCadastrarUmNovoPersonagemAlterandoOsValoresPadroesDeParamentro()
        {
            QuandoCadastrarUmNovoPersonagem();
        }

        [When(@"cadastrar um novo personagem sem alterar os valores padroes de paramentro")]
        public void QuandoCadastrarUmNovoPersonagemSemAlterarOsValoresPadroesDeParamentro()
        {
            TelaPersonagem.CriarPersonagem("INM PERSONAGEM", "DIO FREITAS", "Normal", "", "", "", "");
        }

        [When(@"alterar as informacoes do ator")]
        public void QuandoAlterarAsInformacoesDoAtor()
        {
            TelaPersonagem.AlterarPersonagem("", "", "INM PERSONAGEM", "20", "8", "40", "5", "2");
        }

        [When(@"apagar as informacoes cadastradas nos novos campos")]
        public void QuandoApagarAsInformacoesCadastradasNosNovosCampos()
        {
            TelaPersonagem.AlterarPersonagem("", "", "INM PERSONAGEM", "0", "0", "0", "0", "");
        }

        [When(@"eu altero para vazio informacoes do ator pertencente a um cenario")]
        public void QuandoEuAlteroParaVazioInformacoesDoAtorPertencenteAUmCenario()
        {
            QuandoCadastrarUmNovoPersonagem();
            TelaPersonagem.AlterarPersonagem("", "", "INM PERSONAGEM", "0", "0", "0", "0", "");
        }

        //Then
        [Then(@"visualizo o personagem criado com sucesso")]
        public void EntaoVisualizoOPersonagemCriadoComSucesso()
        {
            TelaPersonagem.InputFiltrarPersonagem("", "", "INM PERSONAGEM");
            TelaPersonagem.ClicarFiltrarPersonagem();
            TelaPersonagem.ValidarNomePersonagem("INM PERSONAGEM");
        }

        [Then(@"visualizo Personagem alterado com sucesso")]
        public void EntaoVisualizoPersonagemAlteradoComSucesso()
        {
            TelaPersonagem.InputFiltrarPersonagem("", "", "INM PERSONAGEM");
            TelaPersonagem.ClicarFiltrarPersonagem();
            TelaPersonagem.ClicarEditarPersonagem();
            TelaPersonagem.ValidarNovosCamposPersonagem("20", "8", "40", "5", "2");
        }
        
        [Then(@"visualizo os novos campos com sucesso")]
        public void EntaoVisualizoOsNovosCamposComSucesso()
        {
            TelaPersonagem.ValidarNovosCamposPersonagem("0", "0", "0", "0", "0");
        }

        [Then(@"visualizo os valores alterados com sucesso")]
        public void EntaoVisualizoOsValoresAlteradosComSucesso()
        {
            TelaPersonagem.Navegar();
            TelaPersonagem.ClicarNovoPersonagem();
            TelaPersonagem.ValidaParametrosPersonagem("4", "4", "4", "4");
        }

        [Then(@"visualizo o log do processo executado com sucesso")]
        public void EntaoVisualizoOLogDoProcessoExecutadoComSucesso()
        {
            TelaConsultaDeLog.Navegar();
            TelaConsultaDeLog.FiltroConsultaLog("Personagem", "0");
            TelaConsultaDeLog.ValidarLogPersonagem("INM PERSONAGEM - DIO FREITAS", "Inserção", "");
        }

        [Then(@"visualizo o log da alteracao feita no personagem")]
        public void EntaoVisualizoOLogDaAlteracaoFeitaNoPersonagem()
        {
            TelaConsultaDeLog.Navegar();
            TelaConsultaDeLog.FiltroConsultaLog("Personagem", "0");
            TelaConsultaDeLog.ValidarLogPersonagem("INM PERSONAGEM - DIO FREITAS", "Edição",
                "Carga Horária Máxima Diária (h), Carga Horária Máxima Semanal (h), Interjornada mínima (h), Tempo preparação (min)");
        }

    }
}
