using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class FrequenciaElencoSteps
	{
			public FrequenciaElencoPage TelaFrequenciaElenco { get; private set; }

			public FrequenciaElencoSteps()
			{
				var browser = ScenarioContext.Current["browser"];

				TelaFrequenciaElenco = new FrequenciaElencoPage((IBrowser)browser,
					ConfigurationManager.AppSettings["FrequenciaElencoURL"]);
			}

		[Given(@"que eu navegue para a Tela Frequencia de Elenco")]
		public void DadoQueEuNavegueParaATelaFrequenciaDeElenco()
		{
			TelaFrequenciaElenco.PegarNumeroRoteiro();
			TelaFrequenciaElenco.Navegar();
		}

		[When(@"incluir frequencia de elenco")]
		public void QuandoIncluirFrequenciaDeElenco()
		{
			TelaFrequenciaElenco.IncluirFrequenciaElenco("08:00", "12:00", "13:00", "17:00");
		}

		[When(@"alterar frequencia de elenco")]
		public void QuandoAlterarFrequenciaDeElenco()
		{
			TelaFrequenciaElenco.AlterarFrequenciaElenco("09:00", "13:00", "14:00", "18:00");
		}

		[Then(@"visualizo mensagem de frequencia de elenco salva com sucesso")]
		public void EntaoVisualizoMensagemDeFrequenciaDeElencoSalvaComSucesso()
		{
			TelaFrequenciaElenco.VerificarFrequenciaElenco("Frequência do Elenco salva com sucesso.");
		}
	}
}
