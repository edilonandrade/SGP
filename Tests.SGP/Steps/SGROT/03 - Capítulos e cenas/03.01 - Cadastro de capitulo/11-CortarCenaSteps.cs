using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{

	[Binding]
	public sealed class CortarCenaSteps
	{

		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
		public CapitulosCenasPage TelaCapituloCena { get; private set; }

		public CortarCenaSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["CenarioURL"]);

			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CapituloCenaURL"],
			   ConfigurationManager.AppSettings["IncluirCapituloURL"],
			   ConfigurationManager.AppSettings["IncluirAdendoURL"]);
		}

		[Given(@"que eu selecione um capitulo e cena para cortar")]
		public void DadoQueEuSelecioneUmCapituloECenaParaCortar()
		{
			TelaDecupagemBasica.SelecionarCapituloCenaCortar("0400", "001");
		}

		[When(@"cortar capitulo ou cena decupada")]
		public void QuandoCortarCapituloOuCenaDecupada()
		{
			TelaDecupagemBasica.CortarCena();
			TelaDecupagemBasica.SalvarCena();
		}

		[Then(@"eu visualizo capitulo ou cena cortada com sucesso")]
		public void EntaoEuVisualizoCapituloOuCenaCortadaComSucesso()
		{
			TelaCapituloCena.VerificarCenaCortada("capituloDe", "0400", "Cortada");
		}
	}
}
