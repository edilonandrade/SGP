using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class ValidarPesquisaSteps
    {
        public FotosPage TelaFotos { get; private set; }
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
        public RoteiroPage TelaRoteiro { get; private set; }

        public ValidarPesquisaSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaFotos = new FotosPage((IBrowser)browser,
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["RoteiroURL"]);

            TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
        }

        [When(@"filtrar por ID")]
        public void QuandoFiltrarPorID()
        {
            TelaFotos.PesquisarCampoID();
        }

        [Then(@"visualizo a imagem filtrada")]
        public void EntaoVisualizoAImagemFiltrada()
        {
            TelaFotos.VerificarImagemFiltrada(); //MODIFICAR NOME DO CAMPO SE NECESSARIO - VERIFICAR FILTRO
        }

        [When(@"filtrar por Inserido Por")]
        public void QuandoFiltrarPorInseridoPor()
        {
			//HML - SEM GROT
            TelaFotos.PesquisarCampoInseridoPor("GROT"); //MODIFICAR NOME DO CAMPO SE NECESSARIO

			//GROT
			//TelaFotos.PesquisarCampoInseridoPor("Consulta"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
		}

        [When(@"filtrar por Tema")]
        public void QuandoFiltrarPorTema()
        {
            TelaFotos.PesquisarCampoTema("GROT"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Personagem")]
        public void QuandoFiltrarPorPersonagem()
        {
            TelaFotos.PesquisarCampoPersonagem("INMETRICS PERSONAGEM"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Roupa e Bloco")]
        public void QuandoFiltrarPorRoupaEBloco()
        {
            TelaFotos.PesquisarCampoRoupaBloco("0A", "1"); //MODIFICAR NUMERO DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Cenarios")]
        public void QuandoFiltrarPorCenarios()
        {
            TelaFotos.PesquisarCampoCenario("INMETRICS LOCACAO"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Capitulo ou Pacote")]
        public void QuandoFiltrarPorCapituloOuPacote()
        {
            TelaFotos.PesquisarCampoCapitulo("0400"); //MODIFICAR NUMERO DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Intervalo de Capitulo ou Pacote")]
        public void QuandoFiltrarPorIntervaloDeCapituloOuPacote()
        {
            TelaFotos.PesquisarCampoCapitulo("0400"); //MODIFICAR NUMERO DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Roteiro")]
        public void QuandoFiltrarPorRoteiro()
        {
            TelaFotos.PesquisarCampoRoteiro(); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [When(@"filtrar por Data de Gravacao")]
        public void QuandoFiltrarPorDataDeGravacao()
        {
            TelaFotos.PesquisarCampoDataGravacao(CalendarioHelper.ObterDataAtual()); //MODIFICAR NUMERO DO CAMPO SE NECESSARIO - PEGANDO DATA ATUAL
        }

        [When(@"filtrar por Classificacao")]
        public void QuandoFiltrarPorClassificacao()
        {
            TelaFotos.PesquisarCampoClassificacao("Teste"); //MODIFICAR NOME DO CAMPO SE NECESSARIO
        }

        [Given(@"que eu esteja com planejamento de roteiro realizado")]
        public void DadoQueEuEstejaComPlanejamentoDeRoteiroRealizado()
        {
			//HML
			TelaPlanejamentoRoteiro.Navegar();
			TelaPlanejamentoRoteiro.CriarPlanejamentoRoteiro(CalendarioHelper.ObterDataAtual(), "0400/001", "2");
		}

		[When(@"que eu esteja com planejamento de roteiro nao liberado")]
		public void QuandoQueEuEstejaComPlanejamentoDeRoteiroNaoLiberado()
		{
			TelaPlanejamentoRoteiro.CriarPlanejamentoRoteiroNaoLiberado(CalendarioHelper.ObterDataAtual().ToString(), "0400/001", "2");
		}

		[When(@"eu libero o roteiro")]
		public void QuandoEuLiberoORoteiro()
		{
			TelaPlanejamentoRoteiro.LiberarRoteiroNaoLiberado();
		}


		[Then(@"visualizo roteiro nao liberado om sucesso")]
		public void EntaoVisualizoRoteiroNaoLiberadoOmSucesso()
		{
			TelaPlanejamentoRoteiro.VerificarPlanejamentoNaoLiberado();
		}

		[Given(@"que eu esteja com planejamento de roteiro realizado com duas cenas")]
        public void DadoQueEuEstejaComPlanejamentoDeRoteiroRealizadoComDuasCenas()
        {
            TelaPlanejamentoRoteiro.CriarPlanejamentoRoteiroDuasCenas(CalendarioHelper.ObterDataAtual().ToString(), "0400/001", "0400/002", "2");
        }
    }
}
