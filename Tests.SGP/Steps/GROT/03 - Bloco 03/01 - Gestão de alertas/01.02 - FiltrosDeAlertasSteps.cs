using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;
using Tests.SGP.Steps.GROT;

namespace Tests.SGP.Steps
{
    [Binding]
    public class FiltrosDeAlertasSteps
    {
        public HomePage TelaHome { get; private set; }
        public IndisponibilidadeLocaisPage TelaIndisponibilidadeLocais { get; private set; }
        public GestaoAlertasPage TelaGestaoAlerta { get; private set; }
        public VisualizacoesAlertasSteps visualizacoesAlertasSteps { get; private set; }

        public FiltrosDeAlertasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
            TelaIndisponibilidadeLocais = new IndisponibilidadeLocaisPage((IBrowser)browser,
                ConfigurationManager.AppSettings["IndisponibilidadeLocal"]);
            TelaGestaoAlerta = new GestaoAlertasPage((IBrowser)browser, ConfigurationManager.AppSettings["GestaoAlertaUrl"]);
            visualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        //Given
        [Given(@"que esteja na Tela Gestao de Alertas")]
        public void DadoQueEstejaNaTelaGestaoDeAlertas()
        {
            TelaGestaoAlerta.Navegar();
        }

        [Given(@"que desmarco dois alertas")]
        public void DadoQueDesmarcoDoisAlertas()
        {
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.MarcarItemCheckBox("Tempo preparação de elenco");
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        // When
        [When(@"eu seleciono mais de um alerta")]
        public void QuandoEuSelecionoMaisDeUmAlerta()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.MarcarItemCheckBox("Tempo preparação de elenco");
            TelaGestaoAlerta.BtnFecharAlertas();
        }
        
        [When(@"eu seleciono opcao todos os alertas")]
        public void QuandoEuSelecionoOpcaoTodosOsAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(true);
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        [When(@"eu seleciono dois alertas")]
        public void QuandoEuSelecionoDoisAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.MarcarItemCheckBox("Tempo preparação de elenco");
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        [When(@"depois seleciono todos os alertas")]
        public void QuandoDepoisSelecionoTodosOsAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(true);
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        [When(@"que faca um filtro por alerta de antecedencia minima")]
        public void QuandoQueFacaUmFiltroPorAlertaDeAntecedenciaMinima()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.SelecionarListaAlerta();
            TelaGestaoAlerta.SelecionarItemAlertaNaLista("Antecedência mínima de gravação");
            TelaGestaoAlerta.BtnFiltrarAlertas();
        }
        
        [When(@"marco opcao itens selecionados")]
        public void QuandoMarcoOpcaoItensSelecionados()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        [When(@"faco filtro por itens selecionados")]
        public void QuandoFacoFiltroPorItensSelecionados()
        {
            TelaGestaoAlerta.MarcarCheckItensNaoSelecionados(false);
            TelaGestaoAlerta.BtnFiltrarAlertas();
        }

        [When(@"faco filtro por itens nao selecionados")]
        public void QuandoFacoFiltroPorItensNaoSelecionados()
        {
            TelaGestaoAlerta.MarcarCheckItensSelecionados(false);
            TelaGestaoAlerta.BtnFiltrarAlertas();
        }

        [When(@"filtro itens nao selecionados")]
        public void QuandoFiltroItensNaoSelecionados()
        {
            TelaGestaoAlerta.MarcarCheckItensSelecionados(false);
            TelaGestaoAlerta.MarcarCheckItensNaoSelecionados(true);
            TelaGestaoAlerta.BtnFiltrarAlertas();
        }
        
        [When(@"marco opcao itens nao selecionados")]
        public void QuandoMarcoOpcaoItensNaoSelecionados()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(true);
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        //Then
        [Then(@"eu visualizo todos os alertas nao selecionados")]
        public void EntaoEuVisualizoTodosOsAlertasNaoSelecionados()
        {
            EntaoEuVisualizoAlertasSelecionadosComSucesso();
        }

        [Then(@"eu desmarco opcao selecionar todos os alertas")]
        public void EntaoEuDesmarcoOpcaoSelecionarTodosOsAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
        }

        [Then(@"eu visualizo alertas selecionados com sucesso")]
        public void EntaoEuVisualizoAlertasSelecionadosComSucesso()
        {
            TelaGestaoAlerta.ValidarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.ValidarItemCheckBox("Tempo preparação de elenco");
        }
        
        [Then(@"eu visualizo todos os alertas selecionados")]
        public void EntaoEuVisualizoTodosOsAlertasSelecionados()
        {
            TelaGestaoAlerta.ValidarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.ValidarItemCheckBox("Tempo preparação de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Iluminação");
            TelaGestaoAlerta.ValidarItemCheckBox("Faixa de horário de gravação");
            TelaGestaoAlerta.ValidarItemCheckBox("Caracterização de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Indisponibilidade de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Jornada da frente");
            TelaGestaoAlerta.ValidarItemCheckBox("Refeição de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Tempo de deslocamento");
            TelaGestaoAlerta.ValidarItemCheckBox("Interjornada de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Conflito de horário de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Múltipla alocação do ambiente");
            TelaGestaoAlerta.ValidarItemCheckBox("Jornada de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Metragem de estúdio");
            TelaGestaoAlerta.ValidarItemCheckBox("Incompatibilidade de cenários e ambientes");
            TelaGestaoAlerta.ValidarItemCheckBox("MQE");
            TelaGestaoAlerta.ValidarItemCheckBox("Inconsistência");
            TelaGestaoAlerta.ValidarItemCheckBox("Refeição da equipe");
            TelaGestaoAlerta.ValidarItemCheckBox("Frente de gravação incompatível");
            TelaGestaoAlerta.ValidarItemCheckBox("Jornada semanal do elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Limite de Dias de Gravação na Semana da Frente");
            TelaGestaoAlerta.ValidarItemCheckBox("Indisponibilidade do local");
            TelaGestaoAlerta.ValidarItemCheckBox("Indisponibilidade de frente de gravação");
            TelaGestaoAlerta.ValidarItemCheckBox("Interjornada de frente");
            TelaGestaoAlerta.ValidarItemCheckBox("Limite de Dias de Gravação na Semana do Elenco");
        }

        [Then(@"eu visualizo todos os alertas marcados com sucesso")]
        public void EntaoEuVisualizoTodosOsAlertasMarcadosComSucesso()
        {
            EntaoEuVisualizoTodosOsAlertasSelecionados();
        }

        [Then(@"visualizo o filtro por antecedencia minima com sucesso")]
        public void EntaoVisualizoOFiltroPorAntecedenciaMinimaComSucesso()
        {
            TelaGestaoAlerta.ValidarItemCheckBox("Antecedência mínima de gravação");
        }

        [Then(@"resultado e validado com sucesso")]
        public void EntaoResultadoEValidadoComSucesso()
        {
            TelaGestaoAlerta.ValidarTexto("Antecedência mínima de gravação");
        }

        //--------------------------------------------------------------------------------

        [When(@"eu navego para a Tela Gestao de Alertas")]
        public void QuandoEuNavegoParaATelaGestaoDeAlertas()
        {
            TelaGestaoAlerta.Navegar();
        }
        
        [When(@"desmarco opcao selecionar todos os alertas")]
        public void QuandoDesmarcoOpcaoSelecionarTodosOsAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
        }
        
        [When(@"clico na lista de alertas")]
        public void QuandoClicoNaListaDeAlertas()
        {
            TelaGestaoAlerta.SelecionarListaAlerta();
        }
        
        [Then(@"escrevo nome pausadamente para exibir lista de sugestao")]
        public void EntaoEscrevoNomePausadamenteParaExibirListaDeSugestao()
        {
            TelaGestaoAlerta.FiltrarItensAlertasNaListaPorNome("gravação");
        }

        [Then(@"escrevo nome com numeros na lista de sugestao")]
        public void EntaoEscrevoNomeComNumerosNaListaDeSugestao()
        {
            TelaGestaoAlerta.FiltrarItensAlertasNaListaPorNome("123 gravação");
            TelaGestaoAlerta.FiltrarItensAlertasNaListaPorNome("-1-234gravação");
            TelaGestaoAlerta.FiltrarItensAlertasNaListaPorNome("gravação -1-2-3");
        }

        [When(@"filtro nome valido")]
        public void QuandoFiltroNomeValido()
        {
            TelaGestaoAlerta.SelecionarItemAlertaNaLista("Iluminação");
            TelaGestaoAlerta.BtnFiltrarAlertas();
            TelaGestaoAlerta.MarcarItemCheckBox("Iluminação");
        }

        [Then(@"clico no botao fechar")]
        public void EntaoClicoNoBotaoFechar()
        {
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        // 21 - Filtrar alertas semanais - Jornada e Indisponibilidade

        [When(@"desmarco todos os alertas")]
        public void QuandoDesmarcoTodosOsAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
        }

        [When(@"seleciono alertas Jornada e Indisponibilidade")]
        public void QuandoSelecionoAlertasJornadaEIndisponibilidade()
        {
            TelaGestaoAlerta.MarcarItemCheckBox("Jornada semanal do elenco");
            TelaGestaoAlerta.MarcarItemCheckBox("Interjornada de frente");
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        [When(@"seleciono alertas Iluminacao e JornadaFrete")]
        public void QuandoSelecionoAlertasIluminacaoEJornadaFrete()
        {
            TelaGestaoAlerta.MarcarItemCheckBox("Iluminação");
            TelaGestaoAlerta.MarcarItemCheckBox("Jornada da frente");
            TelaGestaoAlerta.BtnFecharAlertas();
        }
        
        //[When(@"clico na opcao fechar")]
        //public void QuandoClicoNaOpcaoFechar()
        //{
        //    TelaGestaoAlerta.BtnFecharAlertas();
        //}

        [When(@"acesso planejamento de roteiro semanal")]
        public void QuandoAcessoPlanejamentoDeRoteiroSemanal()
        {
            TelaGestaoAlerta.NavegarTela(ConfigurationManager.AppSettings["CapituloCenaURL"]);
            visualizacoesAlertasSteps.QuandoEuCriarDoisRoteirosNaMesmaFrente();
        }

        [Then(@"visualizo alertas semanal com sucesso")]
        public void EntaoVisualizoAlertasSemanalComSucesso()
        {
            visualizacoesAlertasSteps.EntaoEuVisualizoAlertaDeJornadaSemanalDeElencoComSucesso();
        }

        //

        [When(@"acesso planejamento de roteiro diario")]
        public void QuandoAcessoPlanejamentoDeRoteiroDiario()
        {
            TelaGestaoAlerta.NavegarTela(ConfigurationManager.AppSettings["CapituloCenaURL"]);
            visualizacoesAlertasSteps.DadoQueEuEstejaComUmNovoPlanejamentoDeRoteiroRealizado();
            visualizacoesAlertasSteps.QuandoEuPreencherOsHorariosDeUmRoteiroParaAlertaDeIluminacao();
        }

        [Then(@"visualizado alertas diarios com sucesso")]
        public void EntaoVisualizadoAlertasDiariosComSucesso()
        {
            visualizacoesAlertasSteps.EntaoEuVisualizoAlertaDeIluminacaoComSucesso();
        }

        //

        [When(@"seleciono todos os alertas")]
        public void QuandoSelecionoTodosOsAlertas()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(true);
        }
        
        [When(@"acesso planejamento de roteiro")]
        public void QuandoAcessoPlanejamentoDeRoteiro()
        {
            TelaGestaoAlerta.NavegarTela(ConfigurationManager.AppSettings["CapituloCenaURL"]);
            visualizacoesAlertasSteps.QuandoEuCriarUmRoteiroEmCadaFrenteNoMesmoDia();
            visualizacoesAlertasSteps.QuandoFiltrarAFrentePorTODAS();
        }

        [Then(@"visualizado alertas selecionados")]
        public void EntaoVisualizadoAlertasSelecionados()
        {
            visualizacoesAlertasSteps.EntaoEuVisualizoASumarizacaoDeAlertasDeTodasAsFrentesComSucesso();
        }

        //

        [Then(@"modifico a programacao")]
        public void EntaoModificoAProgramacao()
        {
            TelaGestaoAlerta.NavegarTela(ConfigurationManager.AppSettings["HomeURL"]);
            TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produtoCopiar"]);
            TelaGestaoAlerta.Navegar();
        }
        
        // Cenario: 29 - Exibir campos selecionados alterando programacao

        [When(@"seleciono uma programacao")]
        public void QuandoSelecionoUmaProgramacao()
        {
            TelaGestaoAlerta.NavegarTela(ConfigurationManager.AppSettings["HomeURL"]);
            TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produto"]);
            TelaGestaoAlerta.Navegar();
        }
        
        [When(@"seleciono um alerta")]
        public void QuandoSelecionoUmAlerta()
        {
            TelaGestaoAlerta.MarcarCheckBoxTodos(false);
            TelaGestaoAlerta.MarcarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.BtnFecharAlertas();
        }

        [When(@"valido se alertas selecionados")]
        public void QuandoValidoSeAlertasSelecionados()
        {
            TelaGestaoAlerta.ValidarItemCheckBox("Antecedência mínima de gravação");
            TelaGestaoAlerta.ValidarItemCheckBox("Tempo preparação de elenco");
            TelaGestaoAlerta.ValidarItemCheckBox("Iluminação");
        }

        [When(@"seleciono outra programacao")]
        public void QuandoSelecionoOutraProgramacao()
        {
            TelaGestaoAlerta.NavegarTela(ConfigurationManager.AppSettings["HomeURL"]);
            TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produtoCopiar"]);
            TelaGestaoAlerta.Navegar();
        }

        [Then(@"valido se alerta selecionado")]
        public void EntaoValidoSeAlertaSelecionado()
        {
            TelaGestaoAlerta.ValidarItemCheckBox("Antecedência mínima de gravação");
        }
    }
}
