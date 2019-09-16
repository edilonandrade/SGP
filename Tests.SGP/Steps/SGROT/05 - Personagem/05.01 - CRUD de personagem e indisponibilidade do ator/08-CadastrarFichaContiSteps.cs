using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CadastrarFichaContinuidadeSteps
	{
			public PersonagemPage TelaPersonagem { get; private set; }

			public CadastrarFichaContinuidadeSteps()
			{
				var browser = ScenarioContext.Current["browser"];
				TelaPersonagem = new PersonagemPage((IBrowser)browser,
					ConfigurationManager.AppSettings["PersonagemURL"]);
			}

		[When(@"eu cadastrar nova ficha de continuidade")]
		public void QuandoEuCadastrarNovaFichaDeContinuidade()
		{
			TelaPersonagem.CadastrarNovaRoupaFichaContinuidade("INM PERSONAGEM", "0400");
		}

		[When(@"eu cadastrar roupa existente")]
		public void QuandoEuCadastrarRoupaExistente()
		{
			TelaPersonagem.FichaContinuidadeJaCadastrada("0400");
		}

		[Then(@"eu visualizo nova ficha de continuidade com sucesso")]
		public void EntaoEuVisualizoNovaFichaDeContinuidadeComSucesso()
		{
			TelaPersonagem.VerificarFichaContinuidade();
		}

		[Then(@"eu visualizo critica de roupa cadastrada com sucesso")]
		public void EntaoEuVisualizoCriticaDeRoupaCadastradaComSucesso()
		{
			TelaPersonagem.VerificarFichaContinuidadeCadastrada();
		}
	}
}
