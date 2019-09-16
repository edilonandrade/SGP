using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CriarDecupagemContinuidade
	{
		public DecupagemContinuidadePage TelaDecupagemContinuidade { get; private set; }
		public DecupagemArtePage TelaDecupagemArte { get; private set; }

		public CriarDecupagemContinuidade()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemContinuidade = new DecupagemContinuidadePage((IBrowser)browser,
			ConfigurationManager.AppSettings["DecupagemContinuidadeURL"]);

			TelaDecupagemArte = new DecupagemArtePage((IBrowser)browser,
			ConfigurationManager.AppSettings["DecupagemArteURL"]);
		}

		[When(@"criar uma decupagem de continuidade")]
		public void QuandoCriarUmaDecupagemDeContinuidade()
		{
			TelaDecupagemContinuidade.CriarDecupagemContinuidade("0400", "001", "09:00", "60");
		}

		[When(@"incluir personagem")]
		public void QuandoIncluirPersonagem()
		{
			TelaDecupagemContinuidade.IncluirPersonagem("INMETRICS PERS REAP");
		}

		[When(@"reaproveitar roupa")]
		public void QuandoReaproveitarRoupa()
		{
			TelaDecupagemContinuidade.ReaproveitarRoupa("002", "0400");
		}

		[When(@"excluir personagem")]
		public void QuandoExcluirPersonagem()
		{
			TelaDecupagemContinuidade.IncluirPersonagem("INMETRICS PERS REAP");
			TelaDecupagemContinuidade.ExcluirPersonagemReaproveitado("001", "INMETRICS PERS REAP");
		}

		[When(@"abrir letra")]
		public void QuandoAbrirLetra()
		{
			TelaDecupagemContinuidade.AbrirLetra("0400", "001");
			TelaDecupagemContinuidade.SalvarDecupagemContinuidadeComLetra("001A");

			TelaDecupagemContinuidade.CriarDecupagemContinuidade("0400", "001A", "09:00", "60");
		}

		[When(@"marcar a mao livre")]
		public void QuandoMarcarAMaoLivre()
		{
			//TelaDecupagemContinuidade.MarcarMaoLivre("0400", "001", "09:00", "60");
		}

		[When(@"consultar roupa")]
		public void QuandoConsultarRoupa()
		{
			TelaDecupagemContinuidade.ConsultarRoupa("0400", "001");
		}

		[When(@"imprimir texto em pdf")]
		public void QuandoImprimirTextoEmPdf()
		{
			TelaDecupagemContinuidade.RealizarImpressaoPDF("0400", "001");
		}

		[Then(@"visualizo impressao do pdf com sucesso")]
		public void EntaoVisualizoImpressaoDoPdfComSucesso()
		{
			TelaDecupagemContinuidade.VerificarImpressaoApagarPDF();
		}

		[Then(@"visualizo roupa selecionada com sucesso")]
		public void EntaoVisualizoRoupaSelecionadaComSucesso()
		{
			TelaDecupagemContinuidade.VerificarConsultaRoupa("400 - Bloco 22- INM TESTE");
		}

		[Then(@"visualizo abertura de letra com sucesso")]
		public void EntaoVisualizoAberturaDeLetraComSucesso()
		{
			TelaDecupagemContinuidade.ClicarBtnSalvarContinuidade();
			TelaDecupagemContinuidade.VerificarMensagemDecupagemContinuidade("Decupagem salva com sucesso.");
		}


		[Then(@"visualizo exclusao de personagem com sucesso")]
		public void EntaoVisualizoExclusaoDePersonagemComSucesso()
		{
			TelaDecupagemContinuidade.VerificarPersonagemExcluido();
		}

		[Then(@"visualizo decupagem de continuidade com roupa reaproveitada com sucesso")]
		public void EntaoVisualizoDecupagemDeContinuidadeComRoupaReaproveitadaComSucesso()
		{
			TelaDecupagemContinuidade.VerificarRoupaReaproveitada();
		}

		[Then(@"visualizo decupagem de continuidade realizada com sucesso")]
		public void EntaoVisualizoDecupagemDeContinuidadeRealizadaComSucesso()
		{
			TelaDecupagemContinuidade.VerificarMensagemDecupagemContinuidade("Decupagem salva com sucesso.");
		}

		[Then(@"visualizo decupagem de continuidade com personagem incluido com sucesso")]
		public void EntaoVisualizoDecupagemDeContinuidadeComPersonagemIncluidoComSucesso()
		{
			TelaDecupagemContinuidade.VerificarPersonagemIncluidoDecupagemContinuidade("INMETRICS PER...");
		}
	}
}
