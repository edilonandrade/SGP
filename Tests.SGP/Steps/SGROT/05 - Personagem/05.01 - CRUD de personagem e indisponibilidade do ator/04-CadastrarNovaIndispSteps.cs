using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CadastrarNovaIndisponibilidadeSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public CadastrarNovaIndisponibilidadeSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu criar uma nova indisponibilidade")]
		public void QuandoEuCriarUmaNovaIndisponibilidade()
		{
			TelaPersonagem.CriarNovaIndisponibilidade("INM PERSONAGEM");
		}

		[Then(@"eu visualizo nova indisponibilidade criada com sucesso")]
		public void EntaoEuVisualizoNovaIndisponibilidadeCriadaComSucesso()
		{
			TelaPersonagem.VerificarIndisponibilidade();
			TelaPersonagem.ExcluirIndisponibilidade();
		}
	}
}
