using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class EditarNovaIndisponibilidadeSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public EditarNovaIndisponibilidadeSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu editar nova indisponibilidade")]
		public void QuandoEuEditarNovaIndisponibilidade()
		{
			TelaPersonagem.EditarIndisponibilidade("INM PERSONAGEM");
		}

		[Then(@"eu visualizo nova indisponibilidade editada com sucesso")]
		public void EntaoEuVisualizoNovaIndisponibilidadeEditadaComSucesso()
		{
			TelaPersonagem.VerificarIndisponibilidade();
			TelaPersonagem.ExcluirIndisponibilidade();
		}
	}
}
