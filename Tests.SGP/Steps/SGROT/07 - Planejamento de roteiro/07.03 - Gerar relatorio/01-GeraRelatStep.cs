using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class GeraRelatStep
    {
        public PlanejamentoRoteiroPage TelaPlanejamento { get; private set; }

        public GeraRelatStep()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamento = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
        }

        [When(@"gerar relatorio de cenas")]
        public void QuandoGerarRelatorioDeCenas()
        {
            TelaPlanejamento.GerarRelatorioCenas();
        }

        [When(@"gerar o relatorio selecionando a Capa de Gravacao")]
        public void QuandoGerarORelatorioSelecionandoACapaDeGravacao()
        {
            TelaPlanejamento.GerarRelatorioCapaSemanaGravacao();
        }

        [When(@"gerar relatorio basico roteiro de gravacao")]
        public void QuandoGerarRelatorioBasicoRoteiroDeGravacao()
        {
			TelaPlanejamento.GerarRelatorioBasico();
		}

		[When(@"gerar relatorio de Roupas")]
        public void QuandoGerarRelatorioDeRoupas()
        {
            TelaPlanejamento.GerarRelatorioRoupa();
        }

        [When(@"gerar relatorio de recursos de roteiros")]
        public void QuandoGerarRelatorioDeRecursosDeRoteiros()
        {
            TelaPlanejamento.GerarRecursosRoteiro();
        }

        [When(@"gerar relatorio - Todas as opcoes")]
        public void QuandoGerarRelatorio_TodasAsOpcoes()
        {
            TelaPlanejamento.GerarRelatorioAll();
        }

        [When(@"gerar relatorio - Selecionar apenas um roteiro")]
        public void QuandoGerarRelatorio_SelecionarApenasUmRoteiros()
        {
            TelaPlanejamento.SelecionarUmRoteiro();
        }

        [When(@"gerar relatorio - Selecionar todos os roteiros")]
        public void QuandoGerarRelatorio_SelecionarTodosOsRoteiros()
        {
            TelaPlanejamento.SelecionarTodosRoteiros();
        }

        [Then(@"visualizo o relatorio com a cena a roteirizar")]
        public void EntaoVisualizoORelatorioComACenaARoteirizar()
        {
			TelaPlanejamento.VisualizarRelatorioCenas("0400 001", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o relatorio com a Capa da semana de gravacao")]
        public void EntaoVisualizoORelatorioComACapaDaSemanaDeGravacao()
        {
            TelaPlanejamento.VisualizarRelatorioCapaDaSemanaDeGravacao("INMETRICS LOCACAO", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o relatorio basico roteiro de gravacao")]
        public void EntaoVisualizoORelatorioBasicoRoteiroDeGravacao()
        {
            TelaPlanejamento.VisualizarRelatorioBasicoRoteiroDeGravacao("INMETRICS LOCACAO", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o relatorio de roupas")]
        public void EntaoVisualizoORelatorioDeRoupas()
        {
            TelaPlanejamento.VisualizarRelatorioDeRoupas("0400/001", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o de recursos dos roteiros")]
        public void EntaoVisualizoODeRecursosDosRoteiros()
        {
            TelaPlanejamento.VisualizarRecursosDosRoteiros("RECURSOS DO ROTEIRO", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o relatorio com todas as opcoes")]
        public void EntaoVisualizoORelatorioComTodasAsOpcoes()
        {
            TelaPlanejamento.VisualizarRelatorioComTodasAsOpcoes("INMETRICS LOCACAO", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o relatorio com apenas um Roteiro selecionado")]
        public void EntaoVisualizoORelatorioComApenasUmRoteiroSelecionado()
        {
            TelaPlanejamento.VisualizarRelatorioComApenasUmRoteiroSelecionado("ROTEIRO DE GRAVAÇÃO", ConfigurationManager.AppSettings["downloadPath"]);
        }

        [Then(@"visualizo o relatorio com todos os roteiros selecionados")]
        public void EntaoVisualizoORelatorioComTodosOsRoteirosSelecionados()
        {
            TelaPlanejamento.VisualizarRelatorioComTodosOsRoteirosSelecionados("ROTEIRO DE GRAVAÇÃO", ConfigurationManager.AppSettings["downloadPath"]);
        }
    }
}
