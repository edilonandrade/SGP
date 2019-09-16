using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class CriacaoNovaFrenteGravacaoSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public HomePage TelaHome { get; private set; }
        public VisualizacoesAlertasSteps VisualizacoesAlertasSteps { get; private set; }

        public CriacaoNovaFrenteGravacaoSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            VisualizacoesAlertasSteps = new VisualizacoesAlertasSteps();
        }

        [Given(@"eu criar um roteiro em cada frente no mesmo dia")]
        public void DadoEuCriarUmRoteiroEmCadaFrenteNoMesmoDia()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "0501/004", "2");
            //TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanalFrente2(CalendarioHelper.ObterDataFutura(1), "0501/005", "2", "Externa");
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"movimento uma cena do roteiro para outra frente")]
        public void QuandoMovimentoUmaCenaDoRoteiroParaOutraFrente()
        {
            TelaPlanejamentoGROT.MoverRoteiroParaOutroDia(CalendarioHelper.ObterDataAtual(), "Mover", "0", CalendarioHelper.ObterDiaFuturo(1));
        }

        [Then(@"eu visualizo o alerta na nova frente com sucesso")]
        public void EntaoEuVisualizoOAlertaNaNovaFrenteComSucesso()
        {
            TelaPlanejamentoGROT.ValidarMoverRoteiro(CalendarioHelper.ObterDataFutura(1).ToString());
            TelaPlanejamentoGROT.VoltarDataAtualRoteiro(CalendarioHelper.ObterDataFutura(1), "Mover", "0", CalendarioHelper.ObterDiaAtual());
        }

        [When(@"eu criar uma nova frente de gravacao")]
        public void QuandoEuCriarUmaNovaFrenteDeGravacao()
        {
            TelaPlanejamentoGROT.CriarNovaFrente("Externa");
        }

        [When(@"eu criar uma nova frente de gravacao tipo estudio")]
        public void QuandoEuCriarUmaNovaFrenteDeGravacaoTipoEstudio()
        {
            TelaPlanejamentoGROT.CriarNovaFrente("Estudio");
        }

        [When(@"seleciono apenas segunda-feira no dia da semana")]
        public void QuandoSelecionoApenasSegunda_FeiraNoDiaDaSemana()
        {
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(1, "3");
            EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(1, "3");
        }

        [When(@"seleciono mais de um dia da semana")]
        public void QuandoSelecionoMaisDeUmDiaDaSemana()
        {
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(2, "3");
            EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(2, "3");
        }

        [When(@"seleciono todos os dias da semana")]
        public void QuandoSelecionoTodosOsDiasDaSemana()
        {
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(7, "3");
            EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
            TelaPlanejamentoGROT.EditarNovaFrenteDePlanejamento(7, "3");
        }

        [When(@"seleciono apenas um checkbox dias da semana")]
        public void QuandoSelecionoApenasUmCheckboxDiasDaSemana()
        {
            QuandoSelecionoApenasSegunda_FeiraNoDiaDaSemana();
        }

        [When(@"seleciono todos os checkbox dias da semana")]
        public void QuandoSelecionoTodosOsCheckboxDiasDaSemana()
        {
            QuandoSelecionoTodosOsDiasDaSemana();
        }

        [Then(@"eu visualizo a nova frente de gravacao criada com sucesso")]
        public void EntaoEuVisualizoANovaFrenteDeGravacaoCriadaComSucesso()
        {
            EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
        }

        [Then(@"eu visualizo a frente de gravacao tipo estudio criada com sucesso")]
        public void EntaoEuVisualizoAFrenteDeGravacaoTipoEstudioCriadaComSucesso()
        {
            EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
        }

        [Then(@"eu visualizo a frente de gravacao criada com sucesso")]
        public void EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso()
        {
            TelaPlanejamentoGROT.ValidarNovaFrente("FRENTE 3");
        }

    }
}
