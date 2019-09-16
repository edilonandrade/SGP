using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class EditarPersonagemSteps
	{

		public PersonagemPage TelaPersonagem { get; private set; }

		public EditarPersonagemSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu editar um novo personagem")]
		public void QuandoEuEditarUmNovoPersonagem()
		{
			TelaPersonagem.EditarPersonagem("INM PERSONAGEM", "INM PERSONAGEM EDIT");
		}

		[Then(@"eu visualizo novo personagem editado com sucesso")]
		public void EntaoEuVisualizoNovoPersonagemEditadoComSucesso()
		{
			TelaPersonagem.VerificarPersonagemEditado("INM PERSONAGEM EDIT");
			TelaPersonagem.ExcluirNovoPersonagem("INM PERSONAGEM EDIT");
		}
	}
}
