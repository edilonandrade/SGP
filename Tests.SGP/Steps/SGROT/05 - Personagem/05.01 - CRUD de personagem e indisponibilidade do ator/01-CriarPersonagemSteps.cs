using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CriarPersonagemSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public CriarPersonagemSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[Given(@"que eu navegue para a Tela Personagem")]
		public void DadoQueEuNavegueParaaTelaPersonagem()
		{
			TelaPersonagem.Navegar();
		}

		[When(@"eu criar um novo personagem")]
		public void QuandoEuCriarUmNovoPersonagem()
		{
			TelaPersonagem.CriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Principal");
		}

		[When(@"eu salvar e criar um novo personagem")]
		public void QuandoEuSalvarECriarUmNovoPersonagem()
		{
			TelaPersonagem.SalvarECriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Principal");
		}

		[Then(@"eu visualizo novo personagem criado com sucesso")]
		public void EntaoEuVisualizoNovoPersonagemCriadoComSucesso()
		{
			TelaPersonagem.VerificarNovoPersonagem("INM PERSONAGEM");
			//TelaPersonagem.ExcluirNovoPersonagem("INM PERSONAGEM");
		}
	}
}
