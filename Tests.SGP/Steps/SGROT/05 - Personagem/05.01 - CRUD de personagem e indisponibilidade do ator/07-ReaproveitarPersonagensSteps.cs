using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class ReaproveitarPersonagensSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }
		public CapitulosCenasPage TelaCapituloCena { get; private set; }
		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }

		public ReaproveitarPersonagensSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CapituloCenaURL"],
			   ConfigurationManager.AppSettings["IncluirCapituloURL"],
			   ConfigurationManager.AppSettings["IncluirAdendoURL"]);

			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);


			TelaPersonagem = new PersonagemPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu reaproveitar um personagem")]
		public void QuandoEuReaproveitarUmPersonagem()
		{
			TelaDecupagemBasica.ReaproveitarPersonagem("0400");
			TelaDecupagemBasica.DecuparCenaPersonagem("INMETRICS LOCACAO", "INMETRICS AMBIENTE");
			TelaDecupagemBasica.SalvarCena();
		}

		[Then(@"eu visualizo personagem reaproveitado com sucesso")]
		public void EntaoEuVisualizoPersonagemReaproveitadoComSucesso()
		{
			TelaCapituloCena.VerificarCenaReaproveitarPersonagem("capituloDe", "0400", "002", "INMETRICS PERSONAGEM");
		}
	}
}