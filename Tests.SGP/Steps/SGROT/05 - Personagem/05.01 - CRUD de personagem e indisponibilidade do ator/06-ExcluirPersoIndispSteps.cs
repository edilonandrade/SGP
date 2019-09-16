using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ExcluirPersonagemeIndisponibilidadeSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public ExcluirPersonagemeIndisponibilidadeSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu excluir novo personagem")]
		public void QuandoEuExcluirNovoPersonagem()
		{
			TelaPersonagem.ExcluirNovoPersonagem("INM PERSONAGEM");
		}

		[When(@"eu excluir nova indisponibilidade")]
		public void QuandoEuExcluirNovaIndisponibilidade()
		{
			TelaPersonagem.ExcluirNovaIndisponibilidade("INM PERSONAGEM");
		}

		[When(@"eu excluir novo personagem cadastrado")]
		public void QuandoEuExcluirNovoPersonagemCadastrado()
		{
			TelaPersonagem.ExcluirPersonagemCadastrado("INMETRICS PERSONAGEM");
		}

		[Then(@"eu visualizo novo personagem excluido com sucesso")]
		public void EntaoEuVisualizoNovoPersonagemExcluidoComSucesso()
		{
			TelaPersonagem.VerificarNovoPersonagemExcluido();
		}

		[Then(@"eu visualizo nova indisponibilidade excluida com sucesso")]
		public void EntaoEuVisualizoNovaIndisponibilidadeExcluidaComSucesso()
		{
			TelaPersonagem.VerificarNovaIndisponibilidadeExcluida();
		}

		[Then(@"eu visualizo nova crítica de personagem alocado com sucesso")]
		public void EntaoEuVisualizoNovaCriticaDePersonagemAlocadoComSucesso()
		{
			TelaPersonagem.VerificarCriticaPersonagem();
		}
	}
}
