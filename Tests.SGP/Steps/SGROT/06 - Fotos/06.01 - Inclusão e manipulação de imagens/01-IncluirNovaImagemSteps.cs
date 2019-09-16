using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class IncluirNovaImagemSteps
	{
		public FotosPage TelaFotos { get; private set; }

		public IncluirNovaImagemSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaFotos = new FotosPage((IBrowser)browser,
				ConfigurationManager.AppSettings["FotosURL"],
				ConfigurationManager.AppSettings["RoteiroURL"]);
		}

		[When(@"incluir uma imagem")]
		public void QuandoIncluirUmaImagem()
		{
            //TelaFotos.IncluirUmaFoto("Consulta", "Consulta", "0400/001", "INMETRICS PERSONAGEM", "R=05 (1º Bloco) - LUCAS ", "INMETRICS", "AMBIENTE QA", "Teste");
            TelaFotos.IncluirUmaFoto("GROT", "", "0400/001", "INMETRICS PERSONAGEM", "0A (1º Bloco) - MARCIO", "INMETRICS LOCACAO", "INMETRICS AMBIENTE", "Teste");
            TelaFotos.IncluirImagens();
		}

		[When(@"incluir mais de uma imagem")]
		public void QuandoIncluirMaisDeUmaImagem()
		{
			TelaFotos.IncluirQuatroFotos("GROT", "", "0400/001", "INMETRICS PERSONAGEM", "0A (1º Bloco) - MARCIO", "INMETRICS LOCACAO", "INMETRICS AMBIENTE", "Teste");
			TelaFotos.IncluirImagens();
		}

		[Then(@"visualizo que a imagem foi incluida com sucesso")]
		public void EntaoVisualizoQueAImagemFoiIncluidaComSucesso()
		{
			TelaFotos.VerificarFoto("1", "INMETRICS AMBIENTE");
		}
	}
}
