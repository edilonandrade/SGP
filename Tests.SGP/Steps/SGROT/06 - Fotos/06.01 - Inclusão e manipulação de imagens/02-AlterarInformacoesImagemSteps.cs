using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class AlterarInformacoesImagemSteps
	{
		public FotosPage TelaFotos { get; private set; }

		public AlterarInformacoesImagemSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaFotos = new FotosPage((IBrowser)browser,
				ConfigurationManager.AppSettings["FotosURL"],
				ConfigurationManager.AppSettings["RoteiroURL"]);
		}

        [When(@"escolho uma imagem da lista e altero alguma informacao")]
        public void QuandoEscolhoUmaImagemDaListaEAlteroAlgumaInformacao()
        {
            TelaFotos.EscolherImagem("1");
            TelaFotos.AlterarDadosImagem("0400/001", "INMETRICS PERSONAGEM", "I (1º Bloco) - ANITA", "INMETRICS CENARIO", "INMETRICS AMBIENTE");
            TelaFotos.SalvarFoto();
        }

        [When(@"seleciono uma segunda imagem pelo carrosel")]
        public void QuandoSelecionoUmaSegundaImagemPeloCarrosel()
        {
            TelaFotos.EscolherImagem("1");
            TelaFotos.SelecionarImagemCarrosel("2");
            TelaFotos.AlterarDadosImagem("0400/001", "INMETRICS PERSONAGEM", "I (1º Bloco) - ANITA", "INMETRICS CENARIO", "INMETRICS AMBIENTE");
			TelaFotos.SalvarFoto();
        }

		[Then(@"visualizo o texto editado com sucesso")]
		public void EntaoVisualizoOTextoEditadoComSucesso()
		{
			TelaFotos.VerificarImagemEditada("1");
		}
	}
}