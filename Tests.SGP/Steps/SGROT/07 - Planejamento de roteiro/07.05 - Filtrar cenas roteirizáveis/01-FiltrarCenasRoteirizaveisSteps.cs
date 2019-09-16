using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class FiltrarCenasRoteirizaveisSteps
    {
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
        public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }
		public CapitulosCenasPage TelaCapituloCena { get; private set; }

		public FiltrarCenasRoteirizaveisSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
                ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);

			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
			  ConfigurationManager.AppSettings["CapituloCenaURL"],
			  ConfigurationManager.AppSettings["IncluirCapituloURL"],
			  ConfigurationManager.AppSettings["IncluirAdendoURL"]);
		}

        [When(@"filtrar cenas disponiveis para roteirizacao por tipo")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorTipo()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisTipo("Externa");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por  cenario ou locacao")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorCenarioOuLocacao()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisCenarioLocacao("INMETRICS EXTERNA");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por personagem")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorPersonagem()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisPersonagem("INMETRICS PERSONAGEM");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por status")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorStatus()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisStatus("Decupada");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por classificacoes")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorClassificacoes()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisClassificacao("Ação");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por categorias")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorCategorias()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisCategoria("Normal");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por periodo do dia")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorPeriodoDoDia()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisPeriodoDia("Dia");
        }

        [When(@"filtrar cenas disponiveis para roteirizacao por intervalo de capitulo")]
        public void QuandoFiltrarCenasDisponiveisParaRoteirizacaoPorIntervaloDeCapitulo()
        {
            TelaPlanejamentoRoteiro.FiltrarCenasRoteirizaveisCapitulo("0400");
        }

		[Then(@"visualizo filtro escolhido com sucesso")]
		public void EntaoVisualizoFiltroEscolhidoComSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarFiltroCenas("0400/001");
			TelaPlanejamentoRoteiro.FecharDetalhesCena();
		}
	}
}
