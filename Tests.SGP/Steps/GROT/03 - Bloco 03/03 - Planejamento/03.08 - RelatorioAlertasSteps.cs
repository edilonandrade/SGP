using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class RelatorioAlertasSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }


        public RelatorioAlertasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [When(@"que eu crio um roteiro com uma cena externa")]
        public void QuandoQueEuCrioUmRoteiroComUmaCenaExterna()
        {
            VisualizacoesAlertasSteps.QuandoEuEditarDataDeExibicaoDoCapituloECriarUmRoteiro();
        }

        [When(@"faco download do relatorio de alertas")]
        public void QuandoFacoDownloadDoRelatorioDeAlertas()
        {
            TelaPlanejamentoGROT.ImprimirRelatorio();
        }

        [Then(@"eu visualizo relatorio de alertas com sucesso")]
        public void EntaoEuVisualizoRelatorioDeAlertasComSucesso()
        {
            TelaPlanejamentoGROT.VisualizarRelatorioDeAlertas("RELATÓRIO DE ALERTAS", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"eu visualizo a opcao de relatorio de alertas por periodo com sucesso")]
        public void EntaoEuVisualizoAOpcaoDeRelatorioDeAlertasPorPeriodoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertasPorPeriodo("Cena 0500/001 viola antecedência mínima de gravação.", "1", 0);
        }

        [Then(@"eu visualizo a opcao de relatorio de alertas por alertas com sucesso")]
        public void EntaoEuVisualizoAOpcaoDeRelatorioDeAlertasPorAlertasComSucesso()
        {
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Cena 0500/001 viola antecedência mínima de gravação.", "1", 0);
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Horário de início da cena 0500/001 fora da faixa de horário estipulada na cena.", "1", 0);
            TelaPlanejamentoGROT.ValidarRelatorioRoteiroRefeicaoDaEquipe(" com mais de 2 horas de trabalho sem intervalo para refeição da equipe.");
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Jornada máxima diária da frente de gravação FRENTE 1 - EXT violada em 02:40 horas no dia ", "2", 0);
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("FRENTE 1 - EXT  está indisponível no(a) QUARTA, dia ", "2", 0);
            TelaPlanejamentoGROT.ValidarRelatorioAlertas("Frente FRENTE 1 - EXT viola o número máximo de dias que pode gravar na semana.", "1", 0);
        }

        [Then(@"eu visualizo a opcao de relatorio de alertas com sucesso")]
        public void EntaoEuVisualizoAOpcaoDeRelatorioDeAlertasComSucesso()
        {
            TelaPlanejamentoGROT.ClicarRelatorioAlertas();
        }

    }
}
