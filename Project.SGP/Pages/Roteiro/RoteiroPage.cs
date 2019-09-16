using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.SGP.Pages
{
	public class RoteiroPage : PageBase
	{
		private string RoteiroUrl { get; }
		private string CapituloCenaUrl { get; }

		public string numeroRoteiro { get; set; }

		//Others
		private Element NumeroRoteiro { get; }
		private Element DropNumeroRoteiro { get; }
		private Element LinkDetails { get; }
		private Element PopUpCenaDet { get; }
		private Element PopUpStatusDetCena { get; }
		private Element Filtros { get; }
		private Element CheckIntervaloNumeroRoteiro { get; }
		private Element ChkIntervaloDataGravacao { get; }
		private Element ChkIntervaloRoteiro { get; }
		private Element DropListTipo { get; }
		private Element DropListCenario { get; }
		private Element DropListStatus { get; }

		//Button
		private Element BtnEspelho { get; }
		private Element BtnPlanejamento { get; }
		private Element BtnFiltrar { get; }
		private Element BtnEscolherFiltro { get; }
		private Element BtnFiltrarRoteiros { get; }
		private Element BtnEscolherFiltroSGP { get; }

		//Input
		private Element InputInicioDataGravacao { get; }
		private Element InputFimDataGravacao { get; }
		private Element InputNumeroRoteiro { get; }
		private Element InputListTipo { get; }
		private Element InputCenarioRoteiro { get; }
		private Element InputStatusRoteiro { get; }



		public RoteiroPage(IBrowser browser,
			string roteiroUrl,
			string capituloCenaUrl) : base(browser)
		{
			RoteiroUrl = roteiroUrl;
			CapituloCenaUrl = capituloCenaUrl;

			//Others
			//NumeroRoteiro = Element.Id("numeroRoteiro");
			NumeroRoteiro = Element.Css("div[class='rnumber numeroRoteiroVermelho']");
			LinkDetails = Element.Link("Detalhes");
			DropNumeroRoteiro = Element.Css("div[id='dropMenuRoteiro'] li");
			PopUpCenaDet = Element.Id("popDetCena");
			PopUpStatusDetCena = Element.Id("statusDetCena");
			Filtros = Element.Id("btnToggleFilter");
			CheckIntervaloNumeroRoteiro = Element.Id("intervaloRoteiro");
			ChkIntervaloDataGravacao = Element.Css("#filtroDataIntervalo");
			ChkIntervaloRoteiro = Element.Css("#filtroRoteiroIntervalo");
			DropListTipo = Element.Css("#filtroTipo_chzn a");
			DropListCenario = Element.Css("#filtroCenario_chzn");
			DropListStatus = Element.Css("#filtroStatus_chzn a");

			//Button
			BtnEspelho = Element.Css("div[class='rDetailButtons'] input[value='Espelho ']");
			BtnPlanejamento = Element.Css("div[class='rDetailButtons'] input[value='Planejamento '] ");
			BtnFiltrar = Element.Id("filtrarBtn");
			BtnEscolherFiltro = Element.Id("visualizarFiltros");
			BtnEscolherFiltroSGP = Element.Id("btnToggleFilter");
			BtnFiltrarRoteiros = Element.Id("filtroBuscar");

			//Input
			InputInicioDataGravacao = Element.Id("filtroDataDe");
			InputFimDataGravacao = Element.Id("filtroDataAte");
			InputNumeroRoteiro = Element.Id("filtroRoteiroDe");
			InputListTipo = Element.Css("#filtroTipo_chzn a span");
			InputCenarioRoteiro = Element.Css("#filtroCenario_chzn input");
			InputStatusRoteiro = Element.Css("#filtroStatus_chzn input");
		}


		//-------------------METODOS-------------------\\
		public void AbrirEspelhoGravacao()
		{
			SelecionarRoteiro();
			SelecionarEspelho();
		}

		public void AbrirPlanejamentoRoteiro()
		{
			SelecionarRoteiro();
			SelecionarPlanejamentoRoteiro();
		}

		public void SelecionarRoteiro()
		{
			Browser.Abrir(RoteiroUrl);

			var ElementoLinhaRoteiro = Element.Xpath("//*[@id='roteirosEncontrados']/tbody/tr[contains(.,'" + numeroRoteiro + "')]");
			ElementoLinhaRoteiro.EsperarElemento(Browser);

			MouseActions.ClickATM(Browser, ElementoLinhaRoteiro);
		}

		private void DetalhesRoteiro(string ordemPosicaoDetalhes)
		{
			//Legenda: ORDEM DE POSICAO DO BOTAO DETALHES -1(primeiro) | 2(segundo).

			var RoteiroDetalhes = Element.Xpath("//*[@id='mCSB_1']//table[" + ordemPosicaoDetalhes + "]//tr[6]//a[text()='Detalhes']");

			RoteiroDetalhes.EsperarElemento(Browser);
			if (RoteiroDetalhes.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, RoteiroDetalhes);
			}

			RoteiroDetalhes.Esperar(Browser, 1000);
		}

		private string PegarNumeroRoteiroFiltroCapitulo()
		{
			NumeroRoteiro.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, NumeroRoteiro);

			if (DropNumeroRoteiro.IsElementVisible(Browser))
			{
				numeroRoteiro = DropNumeroRoteiro.GetTexto(Browser);
			}
			return numeroRoteiro;
		}

		private string PegarNumeroRoteiroFiltro()
		{
			NumeroRoteiro.EsperarElemento(Browser);
			//MouseActions.ClickATM(Browser, NumeroRoteiro);

			string numeroRoteiro = NumeroRoteiro.GetTexto(Browser).Trim();
			return numeroRoteiro;
		}

		public void PegarNumeroRoteiroAndFiltrarCapitulo(string campoNumeroRoteiro)
		{
			Browser.Abrir(RoteiroUrl);
			var Roteiro = Element.Css(".codigoRoteiro");
			Roteiro.EsperarElemento(Browser);
			if (Roteiro.IsElementVisible(Browser))
			{
				string numeroRoteiro = Roteiro.GetTexto(Browser);
				FiltrarRoteiroCapitulo(campoNumeroRoteiro, numeroRoteiro);
			}
		}

		private void FiltrarRoteiroCapitulo(string campo, string filtro)
		{
			Browser.Abrir(CapituloCenaUrl);
			ClicarFiltros();
			FlegarIntervaloNumeroRoteiro();
			FiltrarNumeroRoteiro(campo, filtro);
			ClicarBtnFiltrar();
		}

		private void FiltrarNumeroRoteiro(string campo, string filtro)
		{
			var Form = Element.Id("formbusca");
			if (Form.IsElementVisible(Browser))
			{
				//Legenda: capituloDe, capiutloAte, cenaDe, cenaAte
				var InputCapitulo = Element.Xpath("//input[@id='" + campo + "']");
				InputCapitulo.EsperarElemento(Browser);
				AutomatedActions.SendDataATM(Browser, InputCapitulo, filtro);
			}
		}

		private void FlegarIntervaloNumeroRoteiro()
		{
			CheckIntervaloNumeroRoteiro.EsperarElemento(Browser);
			if (CheckIntervaloNumeroRoteiro.IsElementSelected(Browser))
			{
				MouseActions.ClickATM(Browser, CheckIntervaloNumeroRoteiro);
			}
		}

		//private void ClicarFiltros()
		//{
		//	Filtros.EsperarElemento(Browser);
		//	if (Filtros.IsElementVisible(Browser))
		//	{
		//		MouseActions.ClickATM(Browser, Filtros);
		//	}
		//}

		private void ClicarBtnFiltrar()
		{
			MouseActions.ClickATM(Browser, BtnFiltrar);
		}

		private void SelecionarEspelho()
		{
			BtnEspelho.EsperarElemento(Browser);
			if (BtnEspelho.IsClickable(Browser))
			{
				MouseActions.ClickATM(Browser, BtnEspelho);
			}
		}

		private void SelecionarPlanejamentoRoteiro()
		{
			BtnPlanejamento.EsperarElemento(Browser);
			if (BtnPlanejamento.IsClickable(Browser))
			{
				MouseActions.ClickATM(Browser, BtnPlanejamento);
			}
		}

		//-------------------FILTRAR ROTEIROS-------------------\\
		public void FiltrarDataGravacao()
		{
			Browser.Abrir(RoteiroUrl);
			ClicarFiltrosRoteiro();
			DesflegarIntervaloDataGravacao();
			PreencherDataGravacao(CalendarioHelper.ObterDataAtual());
			ClicarBtnFiltrarRoteiros();
		}

		public void FiltrarIntervaloDataGravacao()
		{
			Browser.Abrir(RoteiroUrl);
			ClicarFiltrosRoteiro();
			FlegarIntervaloDataGravacao();
			PreencherIntervaloDataGravacao(CalendarioHelper.ObterDataAtual(), CalendarioHelper.ObterMesFuturo(1));
			ClicarBtnFiltrarRoteiros();
		}

		public void PegarNumeroRoteiroAndFiltrarRoteiro()
		{
			var Roteiro = Element.Css(".codigoRoteiro");
			Roteiro.EsperarElemento(Browser);
			if (Roteiro.IsElementVisible(Browser))
			{
				string numeroRoteiro = Roteiro.GetTexto(Browser);
				FiltrarRoteiro(numeroRoteiro);
			}
		}

		public void FiltrarIntervaloRoteiro()
		{
			var Roteiro = Element.Css(".codigoRoteiro");
			Roteiro.EsperarElemento(Browser);
			if (Roteiro.IsElementVisible(Browser))
			{
				string numeroRoteiro = Roteiro.GetTexto(Browser);
				FiltrarIntervaloRoteiro(numeroRoteiro);
			}
		}

		public void FiltrarPorTipo(string numeroTipo)
		{
			Browser.Abrir(RoteiroUrl);
			ClicarFiltrosRoteiro();
			PreencherFiltroTipo(numeroTipo);
			ClicarBtnFiltrarRoteiros();
		}

		public void FiltrarPorCenario(string nomeCenario)
		{
			Browser.Abrir(RoteiroUrl);
			ClicarFiltrosRoteiro();
			PreencherFiltroCenario(nomeCenario);
			ClicarBtnFiltrarRoteiros();
		}

		public void FiltrarPorStatus(string status)
		{
			Browser.Abrir(RoteiroUrl);
			ClicarFiltrosRoteiro();
			PreencherFiltroStatus(status);
			ClicarBtnFiltrarRoteiros();
		}

		private void PreencherFiltroStatus(string status)
		{
			DropListStatus.EsperarElemento(Browser);
			if (DropListStatus.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListStatus, InputStatusRoteiro, status);
		}

		private void PreencherFiltroCenario(string nomeCenario)
		{
			DropListCenario.EsperarElemento(Browser);
			if (DropListCenario.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListCenario, InputCenarioRoteiro, nomeCenario);
		}

		private void PreencherFiltroTipo(string numeroTipo)
		{
			//Legenda: li#filtroTipo_chzn_o_0 = TODOS | li#filtroTipo_chzn_o_1 = ESTÚDIO | li#filtroTipo_chzn_o_2 = EXTERNA | li#filtroTipo_chzn_o_3 = CIDADE
			var FiltroTipo = Element.Xpath("//li[@id='filtroTipo_chzn_o_" + numeroTipo + "']");
			DropListTipo.EsperarElemento(Browser);
			if (DropListTipo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, DropListTipo);
			FiltroTipo.IsClickable(Browser);
			MouseActions.ClickATM(Browser, FiltroTipo);
		}

		private void FiltrarIntervaloRoteiro(string filtro)
		{
			ClicarFiltrosRoteiro();
			FlegarIntervaloRoteiro();
			PreencherFiltroRoteiro(filtro);
			ClicarBtnFiltrarRoteiros();
		}

		private void FiltrarRoteiro(string filtro)
		{
			ClicarFiltrosRoteiro();
			PreencherFiltroRoteiro(filtro);
			ClicarBtnFiltrarRoteiros();
		}

		private void ClicarBtnFiltrarRoteiros()
		{
			BtnFiltrarRoteiros.EsperarElemento(Browser);
			if (BtnFiltrarRoteiros.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnFiltrarRoteiros);
		}

		private void PreencherDataGravacao(string dataInicioGravacao)
		{
			var Form = Element.Id("filtros");

			Form.EsperarElemento(Browser);
			if (Form.IsElementVisible(Browser))
			{
				InputInicioDataGravacao.EsperarElemento(Browser);
				AutomatedActions.SendDataATM(Browser, InputInicioDataGravacao, dataInicioGravacao);
				KeyboardActions.Tab(Browser, InputInicioDataGravacao);
			}
		}

		private void PreencherIntervaloDataGravacao(string dataInicioGravacao, string dataFimGravacao)
		{
			var Form = Element.Id("filtros");

			Form.EsperarElemento(Browser);
			if (Form.IsElementVisible(Browser))
			{
				InputInicioDataGravacao.EsperarElemento(Browser);
				AutomatedActions.SendDataATM(Browser, InputInicioDataGravacao, dataInicioGravacao);
				KeyboardActions.Tab(Browser, InputInicioDataGravacao);

				AutomatedActions.SendDataATM(Browser, InputFimDataGravacao, dataFimGravacao);
				KeyboardActions.Tab(Browser, InputFimDataGravacao);
			}
		}

		private void PreencherFiltroRoteiro(string filtro)
		{
			InputNumeroRoteiro.EsperarElemento(Browser);
			if (InputNumeroRoteiro.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNumeroRoteiro, filtro);
		}

		private void FiltrarRoteiros()
		{
			var Form = Element.Id("filtros");

			Form.EsperarElemento(Browser);
			if (Form.IsElementVisible(Browser))
			{
				InputInicioDataGravacao.EsperarElemento(Browser);
				AutomatedActions.SendDataATM(Browser, InputNumeroRoteiro, numeroRoteiro);
			}
		}

		private void AcessarRoteiro()
		{
			var Menu = Element.Css("a.dropmenuPDown");
			var Roteiro = Element.Link("Roteiro");

			if (Menu.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, Menu);
			Roteiro.EsperarElemento(Browser);
			if (Roteiro.IsClickable(Browser))
				MouseActions.ClickATM(Browser, Roteiro);
		}

		private void DesflegarIntervaloDataGravacao()
		{
			ChkIntervaloDataGravacao.EsperarElemento(Browser);
			if (!ChkIntervaloDataGravacao.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkIntervaloDataGravacao);
		}

		private void FlegarIntervaloDataGravacao()
		{
			ChkIntervaloDataGravacao.EsperarElemento(Browser);
			if (ChkIntervaloDataGravacao.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkIntervaloDataGravacao);
		}

		private void FlegarIntervaloRoteiro()
		{
			ChkIntervaloRoteiro.EsperarElemento(Browser);
			if (ChkIntervaloRoteiro.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkIntervaloRoteiro);
		}

		private void ClicarFiltros()
		{
			Filtros.EsperarElemento(Browser);
			var Form = Element.Id("formbusca");

			if (Form.IsElementVisible(Browser) && Form.IsClickable(Browser))
			{
				Form.Esperar(Browser, 100);
			}
			else
			{
				Filtros.IsElementVisible(Browser);
				MouseActions.ClickATM(Browser, Filtros);
				Form.EsperarElemento(Browser);
			}
		}

		private void ClicarFiltrosRoteiro()
		{
			BtnEscolherFiltro.EsperarElemento(Browser);
			var Form = Element.Id("filtros");

			if (Form.IsElementVisible(Browser) && Form.IsClickable(Browser))
			{
				Form.Esperar(Browser, 100);
			}
			else
			{
				BtnEscolherFiltro.IsElementVisible(Browser);
				MouseActions.ClickATM(Browser, BtnEscolherFiltro);
				Form.EsperarElemento(Browser);
			}
		}

		public override void Navegar()
		{
			Browser.Abrir(RoteiroUrl);
			Browser.PageLoad();
		}




		//-------------------VERIFICACOES-------------------\\
		public void VerificarPaginaRoteiro(string validacao)
		{
			var divEspelho = Element.Css("div[class='div1']");
			string pegarText = divEspelho.GetTexto(Browser).Trim();

			divEspelho.EsperarElemento(Browser);
			Assert.AreEqual(pegarText, validacao);

			divEspelho.Esperar(Browser, 500);
		}

		public void VerificarStatusRoteiro(string statusRoteiro, string validacao)
		{
			SelecionarRoteiro();
			DetalhesRoteiro("1");

			PopUpCenaDet.EsperarElemento(Browser);
			if (PopUpCenaDet.IsElementVisible(Browser))
			{
				string statusPopUp = PopUpStatusDetCena.GetTexto(Browser);
				Assert.AreEqual(statusPopUp, validacao);
			}
		}

		public void VerificarStatusRoteiroCenaUm(string statusRoteiro, string validacao)
		{
			SelecionarRoteiro();
			DetalhesRoteiro("1");

			PopUpCenaDet.EsperarElemento(Browser);
			if (PopUpCenaDet.IsElementVisible(Browser))
			{
				string statusPopUp = PopUpStatusDetCena.GetTexto(Browser);
				Assert.AreEqual("Gravada Parte", validacao);
			}
		}

		public void VerificarStatusRoteiroCenaDois(string statusRoteiro, string validacao)
		{
			SelecionarRoteiro();
			DetalhesRoteiro("2");

			PopUpCenaDet.EsperarElemento(Browser);
			if (PopUpCenaDet.IsElementVisible(Browser))
			{
				string statusPopUp = PopUpStatusDetCena.GetTexto(Browser);
				Assert.AreEqual("Roteirizada", validacao);
			}
		}

		public void VerificarFiltroDataGravacao(string dataAtual)
		{
			var tabela = Element.Css("tr[class='roteiroEncontrado roteiro']");
			var textoValidar = Element.Css("td.dataRoteiro span[data-bind='text: DataExibicaoCompleta']");

			tabela.EsperarElemento(Browser);
			if (tabela.IsElementVisible(Browser))
			{
				string pegarData = textoValidar.GetTexto(Browser).Trim();
				Assert.AreEqual(pegarData, dataAtual);
			}
		}

		public void VerificarNumeroRoteiro()
		{
			var tabela = Element.Css("tr[class='roteiroEncontrado roteiro']");
			var numeroValidar = Element.Css("td.codigoRoteiro");

			tabela.EsperarElemento(Browser);
			if (tabela.IsElementVisible(Browser))
			{
				string validarRoteiro = numeroValidar.GetTexto(Browser).Trim();
				Assert.IsTrue(true, validarRoteiro);
			}
		}

		public void VerificarTipoRoteiro(string tipoRoteiro)
		{
			var tabela = Element.Css("tr[class='roteiroEncontrado roteiro']");
			var tipoValidar = Element.Css("td.tipoRoteiro");

			tabela.EsperarElemento(Browser);
			if (tabela.IsElementVisible(Browser))
			{
				string validarRoteiro = tipoValidar.GetTexto(Browser).Trim();
				Assert.AreEqual(validarRoteiro, tipoRoteiro);
			}
		}

		public void VerificarCenarioRoteiro(string nomeCenario)
		{
			var tabela = Element.Css("tr[class='roteiroEncontrado roteiro']");
			var cenarioValidar = Element.Css("td[class='localRoteiro left']");

			tabela.EsperarElemento(Browser);
			if (tabela.IsElementVisible(Browser))
			{
				string validarRoteiro = cenarioValidar.GetTexto(Browser).Trim();
				Assert.AreEqual(validarRoteiro, nomeCenario);
			}
		}

		public void VerificarStatusRoteiro(string status)
		{
			var tabela = Element.Css("tr[class='roteiroEncontrado roteiro']");
			var statusValidar = Element.Css("td[class='statusRoteiro liberado']");

			tabela.EsperarElemento(Browser);
			if (tabela.IsElementVisible(Browser))
			{
				string validarRoteiro = statusValidar.GetTexto(Browser).Trim();
				Assert.AreEqual(validarRoteiro, status);
			}
		}
	}
}
