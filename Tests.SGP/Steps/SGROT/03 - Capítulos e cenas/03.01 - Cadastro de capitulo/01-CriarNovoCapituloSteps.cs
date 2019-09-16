using TechTalk.SpecFlow;
using Project.SGP.Pages;
using System.Configuration;
using Framework.Core.Interfaces;
using System.Linq;

namespace Tests.SGP.Steps.SGROT
{
    [Binding]
    public sealed class CriarNovoCapituloSteps
    {
        public CenarioPage TelaCenario { get; private set; }
		public HomePage TelaHome { get; private set; }
        public PersonagemPage TelaPersonagem { get; private set; }
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }
        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }

        public CriarNovoCapituloSteps()
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

            TelaCenario = new CenarioPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CenarioURL"]);

            TelaPersonagem = new PersonagemPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PersonagemURL"]);

            TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
               ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);
        }

		[Given(@"que eu criar um novo capitulo")]
        public void QuandoEuCriarUmNovoCapitulo()
		{
			TelaCapituloCena.CriarNovoCapitulo("0400");
		}

		[Then(@"eu visualizo um capitulo criado com sucesso")]
        public void EntaoEuVisualizoUmCapituloCriadoComSucesso()
        {
            TelaCapituloCena.VerificarCapitulo("capituloDe", "0400");
        }

		[Given(@"que eu navegue para a Tela Capitulos e Cenas")]
		public void DadoQueEuNavegueParaATelaCapitulosECenas()
		{
			TelaCapituloCena.Navegar();
		}
    }
}
