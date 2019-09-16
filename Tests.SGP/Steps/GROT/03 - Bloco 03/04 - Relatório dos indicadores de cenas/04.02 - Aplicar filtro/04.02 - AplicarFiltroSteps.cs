using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class AplicarFiltroRelatorioCenasSteps
    {
        public RelatoriosDeIndicadoresDeCenasPage TelaRelatoriosDeIndicadoresDeCenas { get; private set; }
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }
        public AcionamentoNovasTelasPage TelaAcionamentoNovasTelas { get; private set; }
        public CapitulosCenasPage TelaCapituloCena { get; private set; }

        public AplicarFiltroRelatorioCenasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaRelatoriosDeIndicadoresDeCenas = new RelatoriosDeIndicadoresDeCenasPage((IBrowser)browser);
            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
            TelaAcionamentoNovasTelas = new AcionamentoNovasTelasPage((IBrowser)browser);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CapituloCenaURL"],
               ConfigurationManager.AppSettings["IncluirCapituloURL"],
               ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [Given(@"que eu crio um roteiro com uma cena externa")]
        public void DadoQueEuCrioUmRoteiroComUmaCenaExterna()
        {
            VisualizacoesAlertasSteps.QuandoEuEditarDataDeExibicaoDoCapituloECriarUmRoteiro();
        }

        [Given(@"acesso o relatorio dos indicadores de cenas")]
        public void DadoAcessoORelatorioDosIndicadoresDeCenas()
        {
            TelaAcionamentoNovasTelas.AcessarRelatorioIndicadoresCenas();
        }

        [Given(@"que eu crio um roteiro com tres cenas externas")]
        public void DadoQueEuCrioUmRoteiroComTresCenasExternas()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiarioNoturno(CalendarioHelper.ObterDataAtual(), "0500/008", "2");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0500/001", "1");
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "0501/004", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
        }
        
        [Given(@"que eu crio um roteiro com duas cenas de estudio")]
        public void DadoQueEuCrioUmRoteiroComDuasCenasDeEstudio()
        {
            VisualizacoesAlertasSteps.QuandoEuCriarUmRoteiroComDuasCenasDeEstudio();
        }

        [When(@"eu faco filtro por capitulo em cenas roteirizadas")]
        public void QuandoEuFacoFiltroPorCapituloEmCenasRoteirizadas()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarAbaCenasRoteirizadas("", "", "0500", "");
        }

        [When(@"eu faco filtro por frente em cenas roteirizadas")]
        public void QuandoEuFacoFiltroPorFrenteEmCenasRoteirizadas()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarAbaCenasRoteirizadas("", "", "", "FRENTE 1 - EXT");
        }

        [When(@"eu faco filtro por data da cena e frente em cenas roteirizadas")]
        public void QuandoEuFacoFiltroPorDataDaCenaEFrenteEmCenasRoteirizadas()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarAbaCenasRoteirizadas("0", "", "", "FRENTE 1 - EXT");
        }
        
        [When(@"eu faco filtro por todos os filtros em cenas roteirizadas")]
        public void QuandoEuFacoFiltroPorTodosOsFiltrosEmCenasRoteirizadas()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarAbaCenasRoteirizadas("0", "Roteiro", "0500", "FRENTE 1 - EXT");
        }

        [When(@"clico em limpar os filtros")]
        public void QuandoClicoEmLimparOsFiltros()
        {
            TelaRelatoriosDeIndicadoresDeCenas.LimparFiltrosCenasRoteirizadas();
        }

        [When(@"eu faco filtro por frente e dias em frente de gravacao")]
        public void QuandoEuFacoFiltroPorFrenteEDiasEmFrenteDeGravacao()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarFrenteGravacao("FRENTE 1 - EXT", "", "0");
        }

        [When(@"eu acesso a quebra de sequencia cenica")]
        public void QuandoEuAcessoAQuebraDeSequenciaCenica()
        {
            TelaRelatoriosDeIndicadoresDeCenas.AcessarQuebraDeSequenciaCenica();
        }

        [When(@"eu faco filtro por frente em troca de ambiente e iluminacao")]
        public void QuandoEuFacoFiltroPorFrenteEmTrocaDeAmbienteEIluminacao()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltroTrocaAmbienteIluminacao("Troca de Ambiente e Iluminação", "", "", "FRENTE 1 - EXT", "");
        }

        [When(@"eu faco filtro por Roteiro em troca de ambiente e iluminacao")]
        public void QuandoEuFacoFiltroPorRoteiroEmTrocaDeAmbienteEIluminacao()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltroTrocaAmbienteIluminacao("Troca de Ambiente e Iluminação", "Roteiro", "", "", "");
        }

        [When(@"eu faco filtro por artista em elenco")]
        public void QuandoEuFacoFiltroPorArtistaEmElenco()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarElenco("Elenco", "LUCAS ALMEIDA", "", "");
        }

        [When(@"eu faco filtro por data e artista em elenco")]
        public void QuandoEuFacoFiltroPorDataEArtistaEmElenco()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarElenco("Elenco", "LUCAS ALMEIDA", "", "0");
        }

        [When(@"eu faco filtro por todos os campos em montagem")]
        public void QuandoEuFacoFiltroPorTodosOsCamposEmMontagem()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarMontagem("Montagem", "0", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "FRENTE 1 - EST");
        }

        [When(@"eu faco filtro por data em capitulos fechados e equivalentes")]
        public void QuandoEuFacoFiltroPorDataEmCapitulosFechadosEEquivalentes()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarCapitulosFechadosEquivalentes("Capítulos Fechados e Equivalentes", "0");
        }

        [When(@"eu acesso a aba de indicadores das ultimas solucoes")]
        public void QuandoEuAcessoAAbaDeIndicadoresDasUltimasSolucoes()
        {
            TelaRelatoriosDeIndicadoresDeCenas.AcessarIndicadoresUltimasSolucoes("Indicadores das Últimas Soluções");
        }
        
        [When(@"eu faco filtro por artista em cenas roteirizadas por artista")]
        public void QuandoEuFacoFiltroPorArtistaEmCenasRoteirizadasPorArtista()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarCenasRoteirizadasArtista("Cenas Roteirizadas por Artista", "LUCAS ALMEIDA", "");
        }

        [When(@"eu faco filtro por frente e artista em cenas roteirizadas por artista")]
        public void QuandoEuFacoFiltroPorFrenteEArtistaEmCenasRoteirizadasPorArtista()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarCenasRoteirizadasArtista("Cenas Roteirizadas por Artista", "LUCAS ALMEIDA", "FRENTE 1 - EXT");
        }

        [When(@"eu faco filtro por tipo do local em locacoes externas")]
        public void QuandoEuFacoFiltroPorTipoDoLocalEmLocacoesExternas()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarLocacoesExternas("Locações Externas", "", "Externa");
        }

        [When(@"eu faco filtro por tipo do local em numero de roteiros")]
        public void QuandoEuFacoFiltroPorTipoDoLocalEmNumeroDeRoteiros()
        {
            TelaRelatoriosDeIndicadoresDeCenas.FiltrarNumRoteiros("Nº de Roteiros", "", "Externa");
        }

        [Then(@"eu visualizo o numero de roteios existentes em numero de roteiros com sucesso")]
        public void EntaoEuVisualizoONumeroDeRoteiosExistentesEmNumeroDeRoteirosComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarNumRoteiros("1");
        }

        [Then(@"eu visualizo o numero de locais existentes com sucesso")]
        public void EntaoEuVisualizoONumeroDeLocaisExistentesComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarLocacoesExternas("1");
        }

        [Then(@"eu visualizo o relatorio de cenas roteirizadas por artista com sucesso")]
        public void EntaoEuVisualizoORelatorioDeCenasRoteirizadasPorArtistaComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° Cenas", "1");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° Cenas", "17");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° Cenas", "18");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° Páginas", "3/4");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° Páginas", "12 1/4");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° Páginas", "13 1/4");
        }

        [Then(@"eu visualizo os indicadores das ultimas solucoes com sucesso")]
        public void EntaoEuVisualizoOsIndicadoresDasUltimasSolucoesComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de Cenas Roteirizadas", "1.00", "0", "");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("Total de horas roteirizadas", "1.17", "0", "");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de páginas roteirizadas", "3/4", "0", "");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de Montagens", "0.00", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("Tempo Útil de Equipe (%)", "100.00", "0", "");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de Capítulos equivalentes", "0.04", "0", "");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("Tempo ocioso médio do elenco (h)", "0.00", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de deslocamentos do elenco", "0.00", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de quebras de ordem dramatúrgica", "0.00", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("N° de violações", "", "0", "");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("Tempo total deslocamentos - Elenco", "", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarIndicadoresUltimasSolucoes("Tempo total deslocamentos - Frente", "", "0", "");
        }

        [Then(@"eu visualizo o relatorio de capitulos fechados e equivalentes com sucesso")]
        public void EntaoEuVisualizoORelatorioDeCapitulosFechadosEEquivalentesComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Nº de capítulos equivalentes", "0.035");
        }

        [Then(@"eu visualizo o relatorio de montagem com sucesso")]
        public void EntaoEuVisualizoORelatorioDeMontagemComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("MQE - Montada", "157.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Metragem Montada (m²)", "200.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Montagens", "1.00");
        }

        [Then(@"eu visualizo o relatorio de elenco por data com sucesso")]
        public void EntaoEuVisualizoORelatorioDeElencoPorDataComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Jornada realizada (h)", "2.17");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Media de Utilização (%)", "54.17");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de tempo ocioso", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Tempo de Deslocamento", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Deslocamento", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Troca de Total de Figurino", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Deslocamentos para externas", "0.00");
        }

        [Then(@"eu visualizo o relatorio de elenco com sucesso")]
        public void EntaoEuVisualizoORelatorioDeElencoComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Jornada realizada (h)", "2.17");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Media de Utilização (%)", "7.74");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de tempo ocioso", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Tempo de Deslocamento", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Deslocamento", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Troca de Total de Figurino", "0.00");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Deslocamentos para externas", "0.00");
        }

        [Then(@"eu visualizo o relatorio de troca de ambiente e iluminacao com sucesso")]
        public void EntaoEuVisualizoORelatorioDeTrocaDeAmbienteEIluminacaoComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° de trocas de ambientes", "2");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("N° de trocas de período", "1");
        }

        [Then(@"eu visualizo o numero de sequencias cenicas existentes com sucesso")]
        public void EntaoEuVisualizoONumeroDeSequenciasCenicasExistentesComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarQuebraSequenciaCenica("0");
        }

        [Then(@"eu visualizo o relatorio de frente de gravacao com sucesso")]
        public void EntaoEuVisualizoORelatorioDeFrenteDeGravacaoComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Total de Jornada Realizada", "6.666666666666666");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarRelatorio("Média Utilização (%)", "333.3333333333333");
        }

        [Then(@"eu visualizo o relatorio de cenas roteirizadas com sucesso")]
        public void EntaoEuVisualizoORelatorioDeCenasRoteirizadasComSucesso()
        {
            TelaRelatoriosDeIndicadoresDeCenas.ValidarAbaCenasRoteirizadas("Dentro - Roteirizadas", "1", "3/4");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarAbaCenasRoteirizadas("Dentro - Não Roteirizadas", "7", "6.375");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarAbaCenasRoteirizadas("Fora - Roteirizadas", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarAbaCenasRoteirizadas("Fora - Não Roteirizadas", "0", "0");
            TelaRelatoriosDeIndicadoresDeCenas.ValidarAbaCenasRoteirizadas("Total", "8", "7 1/4");
        }

    }
}
