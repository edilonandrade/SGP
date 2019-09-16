using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.SGROT
{
	[Binding]
	public sealed class CopiarCapituloSteps
	{
		public CapitulosCenasPage TelaCapituloCena { get; private set; }
		public DecupagemBasicaPage TelaDecupagemBasica { get; private set; }
		public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
		public HomePage TelaHome { get; private set; }

		public CopiarCapituloSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
				ConfigurationManager.AppSettings["CapituloCenaURL"],
				ConfigurationManager.AppSettings["IncluirCapituloURL"],
				ConfigurationManager.AppSettings["IncluirAdendoURL"]);

			TelaHome = new HomePage((IBrowser)browser,
				ConfigurationManager.AppSettings["HomeURL"],
				ConfigurationManager.AppSettings["FotosURL"],
				ConfigurationManager.AppSettings["DecupagemBasicaURL"],
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

			TelaDecupagemBasica = new DecupagemBasicaPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["DecupagemBasicaURL"],
			   ConfigurationManager.AppSettings["CenarioURL"]);
		}

		[Given(@"que eu criar um capitulo com decupagem")]
		public void DadoQueEuCriarUmCapituloComDecupagem()
		{
			TelaCapituloCena.CriarNovoCapituloComDecupagem("0400");
			TelaDecupagemBasica.DecuparCenaCompleta("0400", "INMETRICS EXTERNA", "INMETRICS AMBIENTE", "INMETRICS PERSONAGEM", "FIGURANTES");
			TelaDecupagemBasica.SalvarCena();
		}

		[When(@"copiar um capitulo")]
		public void QuandoCopiarUmCapitulo()
		{
			TelaCapituloCena.CopiarCapitulos("0400", ConfigurationManager.AppSettings["produtoCopiar"]);
		}

		[Given(@"que eu crie um capitulo em outra programacao")]
		public void DadoQueEuCrieUmCapituloEmOutraProgramacao()
		{
			TelaHome.Navegar();
			TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produtoCopiar"]);
			TelaCapituloCena.CriarNovoCapitulo("0400");
			TelaCapituloCena.Navegar();
		}

		[When(@"copiar um capitulo existente")]
		public void QuandoCopiarUmCapituloExistente()
		{
			TelaCapituloCena.CopiarCapitulos("0400", ConfigurationManager.AppSettings["produto"]);
		}

		[Then(@"eu visualizo capitulo copiado com sucesso")]
		public void EntaoEuVisualizoCapituloCopiadoComSucesso()
		{
			TelaHome.Navegar();
			TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produtoCopiar"]);
			TelaCapituloCena.VerificarCapituloCopiado("capituloDe", "0400");
			//TelaCapituloCena.ExcluirCapituloCopiado("0400");
		}

		[Then(@"eu visualizo capitulo copiado com cena roteirizada com sucesso")]
		public void EntaoEuVisualizoCapituloCopiadoComCenaRoteirizadaComSucesso()
		{
			TelaHome.Navegar();
			TelaHome.EscolherProgramacao(ConfigurationManager.AppSettings["produtoCopiar"]);
			TelaPlanejamentoRoteiro.CancelarRoteiro(CalendarioHelper.ObterDataAtual());

			TelaCapituloCena.VerificarCapituloCopiado("capituloDe", "0400");
			TelaCapituloCena.ExcluirCapituloCopiado("0400");
		}

		[Then(@"eu visualizo critica de capitulo copiado com sucesso")]
		public void EntaoEuVisualizoCriticaDeCapituloCopiadoComSucesso()
		{
			TelaCapituloCena.VerificarCriticaCapituloCopiado("0400");
			//TelaCapituloCena.ExcluirCapituloCopiado("0400");
		}
	}
}
