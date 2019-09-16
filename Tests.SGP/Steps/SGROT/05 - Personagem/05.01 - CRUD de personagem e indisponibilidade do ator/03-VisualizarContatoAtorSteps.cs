using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class VisualizarContatoAtorSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public VisualizarContatoAtorSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu filtrar personagem e acessar a tela de contato do ator")]
		public void QuandoEuFiltrarPersonagemEAcessarATelaDeContatoDoAtor()
		{
			TelaPersonagem.EscolherPersonagem("INMETRICS PERSONAGEM");
			TelaPersonagem.SelecionarContatoAtor();
		}

		[Then(@"eu visualizo novo contato do ator com sucesso")]
		public void EntaoEuVisualizoNovoContatoDoAtorComSucesso()
		{
			TelaPersonagem.VerificarContatoAtor();
		}
	}
}
