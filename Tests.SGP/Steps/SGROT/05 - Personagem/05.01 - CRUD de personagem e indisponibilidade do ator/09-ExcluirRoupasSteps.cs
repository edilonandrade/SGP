using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ExcluirRoupasSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public ExcluirRoupasSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu excluir roupa nao utilizada")]
		public void QuandoEuExcluirRoupaNaoUtilizada()
		{
			TelaPersonagem.ExcluirNovaRoupaFichaContinuidade();
		}

		[When(@"eu excluir roupa que ja esteja utilizada")]
		public void QuandoEuExcluirRoupaQueJaEstejaUtilizada()
		{
			TelaPersonagem.ExcluirRoupaCadastradaEmOutraCenaFichaContinuidade("INMETRICS PERSONAGEM");
		}

		[Then(@"eu visualizo exclusao de roupa com sucesso")]
		public void EntaoEuVisualizoExclusaoDeRoupaComSucesso()
		{
			TelaPersonagem.VerificarExclusaoRoupaFichaContinuidade();
		}


		[Then(@"eu visualizo critica de roupa ja ultilziada com sucesso")]
		public void EntaoEuVisualizoCriticaDeRoupaJaUltilziadaComSucesso()
		{
			TelaPersonagem.VerificarBtnExcluirRoupaCadastrada();
		}
	}
}
