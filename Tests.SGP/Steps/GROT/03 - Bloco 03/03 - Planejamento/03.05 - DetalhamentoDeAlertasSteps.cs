using System;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;
using Framework.Core.Helpers;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class DetalhamentoDeAlertasSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public DetalhamentoDeAlertasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [When(@"clico no icone de alerta de roteiro do planejamento")]
        public void QuandoClicoNoIconeDeAlertaDeRoteiroDoPlanejamento()
        {
            TelaPlanejamentoGROT.ClicarAlertaRoteiro();
        }

        [When(@"clico no icone de alerta de cena do planejamento")]
        public void QuandoClicoNoIconeDeAlertaDeCenaDoPlanejamento()
        {
            TelaPlanejamentoGROT.ClicarAlertaCena();
        }

        [When(@"clico no icone de alerta de dia do planejamento")]
        public void QuandoClicoNoIconeDeAlertaDeDiaDoPlanejamento()
        {
            TelaPlanejamentoGROT.PreencherDataRoteiro(CalendarioHelper.ObterDataFutura(1));
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
            TelaPlanejamentoGROT.ClicarAlertaDia();
        }

        [When(@"clico no icone de alerta de semana do planejamento")]
        public void QuandoClicoNoIconeDeAlertaDeSemanaDoPlanejamento()
        {
            TelaPlanejamentoGROT.PreencherDataRoteiro(CalendarioHelper.ObterDataFutura(1));
            TelaPlanejamentoGROT.CalcularPlanejamentoGROT();
            TelaPlanejamentoGROT.ClicarAlertaSemana();
        }

        [When(@"clico no icone de alerta de semana do planejamento e oculto o alerta")]
        public void QuandoClicoNoIconeDeAlertaDeSemanaDoPlanejamentoEOcultoOAlerta()
        {
            QuandoClicoNoIconeDeAlertaDeSemanaDoPlanejamento();
            EntaoEuVisualizoOPopupDeAlertaDeSemanaComSucesso();
            TelaPlanejamentoGROT.ClicarChckOcultarAlertaPopup("5");
        }

        [Then(@"eu nao visualizo o alerta ocultado com sucesso")]
        public void EntaoEuNaoVisualizoOAlertaOcultadoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarAlertaOcultadoPopup("Indisponibilidade de frente");
        }

        [Then(@"eu visualizo o popup de alerta de semana com sucesso")]
        public void EntaoEuVisualizoOPopupDeAlertaDeSemanaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarDetalhamentoAlertaSemana("1", 1, "FRENTE 1 - EXT  está indisponível no(a) ", "5");
        }

        [Then(@"eu visualizo o popup de alerta de dia com sucesso")]
        public void EntaoEuVisualizoOPopupDeAlertaDeDiaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarDetalhamentoAlertaDia("1", 1, "Jornada máxima diária da frente de gravação FRENTE 1 - EXT violada em ", "4");
        }

        [Then(@"eu visualizo o popup de alerta de cena com sucesso")]
        public void EntaoEuVisualizoOPopupDeAlertaDeCenaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarDetalhamentoRoteiroECena("Cena", "Frente 1", 1, "Cena 0501/004 viola antecedência mínima de gravação.", "0");
        }

        [Then(@"eu visualizo o popup de alerta de roteiro com sucesso")]
        public void EntaoEuVisualizoOPopupDeAlertaDeRoteiroComSucesso()
        {
            TelaPlanejamentoGROT.ValidarDetalhamentoRoteiroECena("Roteiro", "Frente 1", 1, ": A cena 0501/004 não pode ser gravada depois de sua exibição.", "2");
        }
    }
}
