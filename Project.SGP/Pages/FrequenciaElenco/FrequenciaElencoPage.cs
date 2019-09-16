using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.SGP.Pages
{
	public class FrequenciaElencoPage : PageBase
	{
		private string FrequenciaElencoUrl { get; }
		private string numeroRoteiro { get; set; }

		//Input
		private Element InputInicioJornada { get; }
		private Element InputInicioRefeicao { get; }
		private Element InputTerminoRefeicao { get; }
		private Element InputTerminoJornada { get; }
		private Element InputListRoteiro { get; }

		//Others
		private Element DivNumeroRoteiro { get; }
		private Element DropListRoteiro { get; }


		public FrequenciaElencoPage(IBrowser browser,
			string frequenciaElencoUrl) : base(browser)
		{
			FrequenciaElencoUrl = frequenciaElencoUrl;

			//Input
			InputInicioJornada = Element.Nome("IniJor");
			InputInicioRefeicao = Element.Nome("IniRef");
			InputTerminoRefeicao = Element.Nome("TermRef");
			InputTerminoJornada = Element.Nome("TermJor");
			InputListRoteiro = Element.Css("#selectRoteiro_chzn input");

			//Others
			DivNumeroRoteiro = Element.Css(".rnumber");
			DropListRoteiro = Element.Css("#selectRoteiro_chzn a span");

		}


		//-------------------METODOS-------------------\\
		public void IncluirFrequenciaElenco(string inicioJornada, string inicioRefeicao, string terminoRefeicao, string terminoJornada)
		{
			EscolherRoteiroFrequenciaElenco();
			PreencherHorarioElenco(inicioJornada, inicioRefeicao, terminoRefeicao, terminoJornada);
			ClicarBtnSalvarFrequenciaElenco();
		}

		public void AlterarFrequenciaElenco(string inicioJornada, string inicioRefeicao, string terminoRefeicao, string terminoJornada)
		{
			EscolherRoteiroFrequenciaElenco();
			PreencherHorarioElenco(inicioJornada, inicioRefeicao, terminoRefeicao, terminoJornada);
			ClicarBtnSalvarFrequenciaElenco();
		}

		public void PegarNumeroRoteiro()
		{
			DivNumeroRoteiro.EsperarElemento(Browser);
			if (DivNumeroRoteiro.IsElementVisible(Browser))
			{
				numeroRoteiro = DivNumeroRoteiro.GetTexto(Browser);
			}
		}

		private void EscolherRoteiroFrequenciaElenco()
		{
			DropListRoteiro.EsperarElemento(Browser);
			if (DropListRoteiro.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListRoteiro, InputListRoteiro, numeroRoteiro);
		}

		private void PreencherHorarioElenco(string inicioJornada, string inicioRefeicao, string terminoRefeicao, string terminoJornada)
		{
			InputInicioJornada.EsperarElemento(Browser);
			if (InputInicioJornada.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputInicioJornada, inicioJornada);
				AutomatedActions.SendDataATM(Browser, InputInicioRefeicao, inicioRefeicao);
				AutomatedActions.SendDataATM(Browser, InputTerminoRefeicao, terminoRefeicao);
				AutomatedActions.SendDataATM(Browser, InputTerminoJornada, terminoJornada);
		}

		private void ClicarBtnSalvarFrequenciaElenco()
		{
			var BtnSalvar = Element.Xpath("//div[@aria-labelledby='ui-id-6']//button//span[text()='Salvar']");
			BtnSalvar.EsperarElemento(Browser);
			if (BtnSalvar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvar);
		}

		public override void Navegar()
		{
			Browser.Abrir(FrequenciaElencoUrl);
			Browser.PageLoad();
		}


		//-------------------VERIFICACOES-------------------\\
		public void VerificarFrequenciaElenco(string mensagem)
		{
			var Alerta = Element.Css("div[class='toast toast-success']");
			Alerta.EsperarElemento(Browser);
			if (Alerta.IsElementVisible(Browser))
			{
				string validation = Alerta.GetTexto(Browser).Trim();
				Assert.AreEqual(validation, mensagem);
			}
		}

		public void VerificarAlteracaoFrequenciaElenco(string mensagem)
		{
			var Alerta = Element.Css("div[class='toast toast-success']");
			Alerta.EsperarElemento(Browser);
			if (Alerta.IsElementVisible(Browser))
			{
				string validation = Alerta.GetTexto(Browser).Trim();
				Assert.AreEqual(validation, mensagem);
			}
		}
	}
}