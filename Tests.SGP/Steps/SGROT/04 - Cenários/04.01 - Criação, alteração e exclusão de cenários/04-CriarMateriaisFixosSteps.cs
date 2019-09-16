using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CriarMateriaisFixosSteps
	{
		public CenarioPage TelaCenario { get; private set; }
		public DecupagemArtePage TelaDecupagemArte { get; private set; }

		public CriarMateriaisFixosSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenario = new CenarioPage((IBrowser)browser,
			ConfigurationManager.AppSettings["CenarioURL"]);

			TelaDecupagemArte = new DecupagemArtePage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemArteURL"]);

		}

		[When(@"criar novo material fixo para o cenario")]
		public void QuandoCriarNovoMaterialFixoParaOCenario()
		{
			TelaCenario.CriarMaterialFixoCenario("INM ESTUDIO");
			TelaCenario.SalvarMateriaisFixos();
		}

		[Then(@"visualizo material fixo salvo com sucesso")]
		public void EntaoVisualizoMaterialFixoSalvoComSucesso()
		{
			TelaDecupagemArte.VerificarMateriaisDecupagemArte("Lista de Materiais Salva com sucesso");
		}
	}
}
