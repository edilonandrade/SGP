using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.PageObjects;
using Framework.Core.Interfaces;
using Framework.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Project.SGP.Pages
{
	public class DecupagemBasicaPage : PageBase
	{
		private string DecupagemBasicaUrl { get; }
		private string CenarioUrl { get; }

		//DropList
		private Element DropListCena { get; }
		private Element DropListCenario { get; }
		private Element DropListCapitulo { get; }
		private Element DropListAmbiente { get; }
		private Element DropListTipoPersonagem { get; }

		//Input
		private Element InputObsCena { get; }
		private Element InputListCena { get; }
		private Element InputFigurante { get; }
		private Element InputResumoCena { get; }
		private Element InputListCenario { get; }
		private Element InputListCapitulo { get; }
		private Element InputListAmbiente { get; }
		private Element InputNomeNovoCenario { get; }
		private Element InputCampoLetra { get; }
		private Element InputQTLetra { get; }
		private Element InputCenaSecreta { get; }
		private Element InputNomeAmbiente { get; }
		private Element InputNomeAdicionarAmbiente { get; }
		private Element InputObsAdicionais { get; }
		private Element InputNomeCenario { get; }
		private Element InputNome { get; }
		private Element InputCampoAtor { get; }
		private Element InputPersonagem { get; }
		private Element InputTipoPersonagem { get; }
		private Element InputCampoNovoPersonagem { get; }
		private Element InputPeriodoInicioIndisp { get; }
		private Element InputPeriodoFimIndisp { get; }
		private Element InputJustificativaIndisp { get; }
		private Element InputReaproveitarPersonagemCapituloDe { get; }
		private Element InputReaproveitarPersonagemCapituloAte { get; }

		//Button
		private Element BtnFiltrarReaproveitarPersonagem { get; }
		private Element BtnReaproveitar { get; }
		private Element BtnSalvarCena { get; }
		private Element BtnReaproveitarPersonagem { get; }
		private Element BtnSalvarPersonagem { get; }
		private Element AbaPersonagem { get; }
		private Element BtnNovoCenario { get; }
		private Element BtnNovoAmbiente { get; }
		private Element BtnAdicionarMaisAmbientes { get; }
		private Element BtnSalvarNovoCenario { get; }
		private Element BtnCriarLetra { get; }
		private Element BtnAberturaLetraSIM { get; }
		private Element BtnAbrirLetraSimCopiarTxt { get; }
		private Element BtnSalvarCenario { get; }
		private Element BtnSalvarIndisp { get; }
		private Element BtnCriarNovoPersonagem { get; }
		private Element BtnAlterarCapitulo { get; }
		private Element BtnSalvarDecuparProximaCena { get; }
		private Element BtnCadastrarIndisponibilidade { get; }

		//Others
		private Element SelectCategoria { get; }
		private Element LinkNovoCenario { get; }
		private Element LinkAdicionarMaisAmbiente { get; }

		//Check Box
		private Element ChkCenaSecreta { get; }



        //-----------------------------------------------GROT---------------------------------------------------\\
        //Input
        private Element InputDuracao { get; }
        public Element InputLimiteGravacao { get; private set; }
        public Element InputFaixaPrevistaInicio { get; private set; }
        public Element InputFaixaPrevistaFinal { get; private set; }



        public DecupagemBasicaPage(IBrowser browser,
			string decupagemBasicaUrl,
			string cenarioUrl) : base(browser)
		{
			DecupagemBasicaUrl = decupagemBasicaUrl;
			CenarioUrl = cenarioUrl;

			//DropList
			DropListCena = Element.Css("#selectAllCenas_chosen a span");
			DropListCapitulo = Element.Css("#selectAllCapitulosPacotes_chosen a span");
			DropListCenario = Element.Xpath("//*[@id='selectCenarios_chosen']/a/span");
			DropListTipoPersonagem = Element.Css("div #selCargo_chosen > a > span");
			DropListAmbiente = Element.Xpath("//*[@id='selectAmbientes_chosen']/a/span");

			//Others
			SelectCategoria = Element.Id("selCategoria");

			//Input
			InputResumoCena = Element.Id("txtResumo");
			InputObsCena = Element.Id("txtObservacaoCena");
			InputListCena = Element.Css("#selectAllCenas_chosen input");
			InputPersonagem = Element.Css("#selectPersonagens_chosen input");
			InputFigurante = Element.Css("#divBodyFig.panel-body input.tt-input");
			InputNome = Element.Id("nome");
			InputNomeCenario = Element.Id("nomeNucleoPDS");
			InputListCapitulo = Element.Css("#selectAllCapitulosPacotes_chosen input");
			InputListCenario = Element.Xpath("//*[@id='selectCenarios_chosen']//input");
			InputNomeAmbiente = Element.Css("input.nomeDoAmbiente");
			InputCampoNovoPersonagem = Element.Id("txtNomePersonagem");
			InputTipoPersonagem = Element.Xpath("//*[@id='selCargo_chosen']//input");
			InputCampoAtor = Element.Id("txtNomeAtorTOP");
			InputPeriodoInicioIndisp = Element.Id("txtDataInicioInd");
			InputPeriodoFimIndisp = Element.Id("txtDataFimInd");
			InputJustificativaIndisp = Element.Id("txtJustificativaInd");
			InputNomeNovoCenario = Element.Css("input[id=nome]");
			InputNomeAdicionarAmbiente = Element.Css("input[name='nomeDoAmbiente']");
			InputListAmbiente = Element.Xpath("//*[@id='selectAmbientes_chosen']//input");
			InputCampoLetra = Element.Id("txtLetraNumero");
			InputQTLetra = Element.Id("txtQtdLetra");
			InputCenaSecreta = Element.Css("#selMembrosProducao_chosen input");
			InputReaproveitarPersonagemCapituloDe = Element.Id("filtroCapituloDe");
			InputReaproveitarPersonagemCapituloAte = Element.Id("filtroCapituloAte");

			//Button
			BtnFiltrarReaproveitarPersonagem = Element.Id("btnFiltrarCapitulo");
			BtnReaproveitarPersonagem = Element.Id("btnReaproveitarPersonagem");
			BtnReaproveitar = Element.Xpath("//button[text()='Reaproveitar']");
			BtnSalvarCena = Element.Id("btnSave");
			BtnSalvarCenario = Element.Xpath("//*[@id='pagina-capitulo-cena-decupagem']//button[contains(.,'Salvar Cenário')]");
			BtnCriarNovoPersonagem = Element.Css("#btnNovoPersonagem");
			BtnSalvarPersonagem = Element.Css("button[data-bb-handler='b1']");
			BtnCadastrarIndisponibilidade = Element.Link("Cadastrar nova indisponibilidade");
			BtnSalvarIndisp = Element.Xpath("//*[@id='pagina-capitulo-cena-decupagem']//button[text()='Salvar indisponibilidade']");
			BtnSalvarDecuparProximaCena = Element.Id("btnSaveAndNext");
			BtnNovoCenario = Element.Id("NovoCenario");
			BtnNovoAmbiente = Element.Id("NovoAmbiente");
			BtnAdicionarMaisAmbientes = Element.Link("+ Adicionar mais ambientes");
			BtnSalvarNovoCenario = Element.Css("button[class='btn btn btn-default salvarCenario']");
			BtnCriarLetra = Element.Css("#btnAbrirLetra");
			BtnAberturaLetraSIM = Element.Css("button[data-bb-handler='confirm']");
			BtnAbrirLetraSimCopiarTxt = Element.Css("button[data-bb-handler='b2']");
			BtnAlterarCapitulo = Element.Id("lnkAlterarCapitulo");

			//CheckBox
			ChkCenaSecreta = Element.Css("label[for='chkCenaSecreta']");

            //-----------------------------------------------GROT---------------------------------------------------\\
            //Input
            InputDuracao = Element.Css("input[id='txtDuracao']");
            InputLimiteGravacao = Element.Css("input[id='txtLimiteGravacaoExibicao']");
            InputFaixaPrevistaInicio = Element.Css("input[id='txtFaixaPrevisaoInicial']");
            InputFaixaPrevistaFinal = Element.Css("input[id='txtFaixaPrevisaoFinal']");

        }

        //-------------------METODOS-------------------\\
        public void DecuparCenaCompleta(string numeroCapitulo, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			SelecionarCapitulo(numeroCapitulo);
			PreencherCenario(nomeCenario);
			PreencherAmbiente(nomeAmbiente);
			EscolherTempo("0");
			EscolherLocacao("1");
			EscolherClassificacao("Ação");
			PreencherDados(nomePersonagem, nomeFigurantes);
		}

		public void DecuparCenaPersonagem(string nomeCenario, string nomeAmbiente)
		{
			PreencherCenario(nomeCenario);
			PreencherAmbiente(nomeAmbiente);
			EscolherTempo("0");
			EscolherLocacao("1");
			EscolherClassificacao("Ação");
		}

		public void CriarNovoCenarioAmbiente(string numeroCapitulo, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			DecuparCenaParaCenarioAmbiente(numeroCapitulo, nomePersonagem, nomeFigurantes);
			DropListCenario.EsperarElemento(Browser);
			PreencherCenario(nomeCenario);
			PreencherAmbiente(nomeAmbiente);
		}

		public void PreencherCenario(string numeroCapitulo, string nomeCenario, string nomeAmbiente)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			SelecionarCapitulo(numeroCapitulo);
			PreencherCenario(nomeCenario);
			PreencherAmbiente(nomeAmbiente);
		}

		public void AberturaLetra(string numeroCapitulo, string nomeLetra)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			DropListCapitulo.EsperarElemento(Browser);
			SelecionarCapitulo(numeroCapitulo);
			PreencherCampoLetra(nomeLetra);
			PopUpAlterarNumeroCenaConfirmar();
		}

		public void DecuparAberturaLetra(string nomeCenario, string nomePersonagem, string nomeFigurantes)
		{
			DecuparCenaParaAberturaLetra(nomeCenario, nomePersonagem, nomeFigurantes);
		}

		private void PreencherCampoLetra(string nomeLetra)
		{
			InputCampoLetra.EsperarElemento(Browser);
			if (InputCampoLetra.IsElementVisible(Browser))
				InputCampoLetra.IsClickable(Browser);
				AutomatedActions.SendDataATM(Browser, InputCampoLetra, nomeLetra);
				KeyboardActions.Tab(Browser, InputCampoLetra);
		}

		private void PopUpAlterarNumeroCenaConfirmar()
		{
			BtnAberturaLetraSIM.EsperarElemento(Browser);
			if (Browser.PageSource("Deseja alterar o número da cena? Dados editados não salvos serão perdidos."))
				MouseActions.ClickATM(Browser, BtnAberturaLetraSIM);
		}

		public void CriarLetraCenaDecupada(string numeroCapitulo, string numeroCena, string textoLetra, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes)
		{
			DecuparCenaCompleta(numeroCapitulo, nomeCenario, nomeAmbiente, nomePersonagem, nomeFigurantes);
			SalvarCena();

			DropListCena.Esperar(Browser, 500);
			Browser.Abrir(DecupagemBasicaUrl);

			DropListCena.EsperarElemento(Browser);
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);

			if (BtnCriarLetra.IsClickable(Browser))
				BtnCriarLetra.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, BtnCriarLetra);
				AbrirLetraPopUp(textoLetra);
		}

		public void SelecionarCenaSecreta(string numeroCapitulo, string email, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes)
		{
			DecuparCenaCompleta(numeroCapitulo, nomeCenario, nomeAmbiente, nomePersonagem, nomeFigurantes);
			ChkCenaSecreta.IsElementVisible(Browser);
			MouseActions.ClickATM(Browser, ChkCenaSecreta);

			if (InputCenaSecreta.IsElementVisible(Browser))
				AutomatedActions.SendDataEnterATM(Browser, InputCenaSecreta, email);
		}

		public void CriarPersonagem(string numeroCapitulo, string numeroCena, string nomeCenario, string nomePersonagem, string nomeFigurantes)
		{
			DecuparCenaParaPersonagem(numeroCapitulo, nomeFigurantes, nomeCenario);
			if (BtnCriarNovoPersonagem.IsClickable(Browser))
				MouseActions.ClickATM(Browser, BtnCriarNovoPersonagem);
				PreencherCampoNovoPersonagem(nomePersonagem);
		}

		public void CriarNovoPersonagemNovaIndisponibilidade(string numeroCapitulo, string numeroCena, string nomeCenario, string nomePersonagem, string nomeFigurantes)
		{
			CriarNovoPersonagem(numeroCapitulo, numeroCena, nomeCenario, nomePersonagem, nomeFigurantes);
		}

		public void DecuparProximaCena(string numeroCapiutlo, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes)
		{
			DecuparCenaCompleta(numeroCapiutlo, nomeCenario, nomeAmbiente, nomePersonagem, nomeFigurantes);
			SalvarDecuparProximaCena();
			DecuparCenaCompleta(numeroCapiutlo, nomeCenario, nomeAmbiente, nomePersonagem, nomeFigurantes);
		}

		public void SalvarCena()
		{

			BtnSalvarCena.Esperar(Browser, 1000);
			BtnSalvarCena.EsperarElemento(Browser);
			if (BtnSalvarCena.IsElementVisible(Browser))
			{
				BtnSalvarCena.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnSalvarCena);
			}

			ElementExtensions.WaitLoader(Browser);
		}

		public void SalvarDecuparProximaCena()
		{
			BtnSalvarDecuparProximaCena.EsperarElemento(Browser);
			if(BtnSalvarDecuparProximaCena.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarDecuparProximaCena);
		}

		//-------------------MOVIMENTAR CENA-------------------------\\

		public void SelecionarCapituloCenaMovimentar(string numeroCapitulo, string numeroCena)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
		}

		public void MovimentarCapituloCena(string numeroCapitulo, string numeroCena)
		{
			ClicarAlterarCapitulo();
			SelecionarCapituloMovimentar(numeroCapitulo);
			PreencherNovaCenaMovimentar(numeroCena);
			ClicarOK();

			ConfirmarPopUpMovimentarCena(numeroCapitulo, numeroCena);
		}

		private void ClicarAlterarCapitulo()
		{
			BtnAlterarCapitulo.EsperarElemento(Browser);
			if (BtnAlterarCapitulo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnAlterarCapitulo);
		}

		private void SelecionarCapituloMovimentar(string numeroCapitulo)
		{
			var DropListCapituloAlterar = Element.Xpath("//*[@id='dlgTrocaCapitulo']//a[contains(.,'Capítulo " + numeroCapitulo + "')]");
			var InputListCapituloAlterar = Element.Xpath("//*[@id='dlgTrocaCapitulo']//input");

			DropListCapituloAlterar.EsperarElemento(Browser);
			if (DropListCapituloAlterar.IsClickable(Browser))
				AutomatedActions.TypingListATM(Browser, DropListCapituloAlterar, InputListCapituloAlterar, numeroCapitulo);
		}

		private void PreencherNovaCenaMovimentar(string numeroCena)
		{
			var InputNovaCenaMovimentar = Element.Id("novoNumCap");

			InputNovaCenaMovimentar.EsperarElemento(Browser);
			if (InputNovaCenaMovimentar.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNovaCenaMovimentar, numeroCena);
		}

		private void ClicarOK()
		{
			var ButtonOK = Element.Css("button[data-bb-handler='b1']");

			ButtonOK.EsperarElemento(Browser);
			if (ButtonOK.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, ButtonOK);
		}

		private void ConfirmarPopUpMovimentarCena(string numeroCena, string numeroCapitulo)
		{
			var ButtonConfirmar = Element.Css("button[data-bb-handler='confirm']");

			ButtonConfirmar.EsperarElemento(Browser);
			if (Browser.PageSource("Confirma a transferência da cena "))
				MouseActions.ClickATM(Browser, ButtonConfirmar);
		}

		//-----------------CORTAR CENA-----------------------------------\\
		public void SelecionarCapituloCenaCortar(string numeroCapitulo, string numeroCena)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
		}

		public void CortarCena()
		{
			var ChkCortarCena = Element.Css("label[for='chkCortarCena']");

			ChkCortarCena.EsperarElemento(Browser);
			if (ChkCortarCena.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, ChkCortarCena);
		}

		//------------------VERIFICAR MOVIMENTAR CENA--------------------\\
		public void VerificarMovimentarCena(string numeroCena)
		{
			SelecionarCapitulo("0400");
			SelecionarCena(numeroCena);

			Assert.IsTrue(true, numeroCena);
		}

		public void VerificarAlertaMovimentarCena(string alerta)
		{
			var Alerta = Element.Css("div[class='alert alert-danger alert-dismissable alert-util']");
			string txtAlerta = Alerta.GetTexto(Browser).Substring(3);

			Assert.AreEqual(txtAlerta, alerta);
		}

		private void CriarNovoPersonagem(string numeroCapitulo, string numeroCena, string nomeCenario, string nomePersonagem, string nomeFigurantes)
		{
			DecuparCenaParaPersonagem(numeroCapitulo, nomeFigurantes, nomeCenario);
			ClicarBtnNovoPersonagem();
			PreencherCampoNovoPersonagem(nomePersonagem);
		}

		private void ClicarBtnNovoPersonagem()
		{
			BtnCriarNovoPersonagem.EsperarElemento(Browser);
			if (BtnCriarNovoPersonagem.IsElementVisible(Browser))
				BtnCriarNovoPersonagem.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnCriarNovoPersonagem);

		}

		private void AbrirLetraPopUp(string textoLetra)
		{
			InputQTLetra.EsperarElemento(Browser);
			if (Browser.PageSource("Deseja abrir letra da cena selecionada?"))
				AutomatedActions.SendDataATM(Browser, InputQTLetra, textoLetra);

			MouseActions.ClickATM(Browser, BtnAbrirLetraSimCopiarTxt);
		}

		private void PreencherCampoNovoPersonagem(string nomePersonagem)
		{
			InputCampoNovoPersonagem.EsperarElemento(Browser);
			if (InputCampoNovoPersonagem.IsElementVisible(Browser))
				InputCampoNovoPersonagem.IsClickable(Browser);
				AutomatedActions.SendDataATM(Browser, InputCampoNovoPersonagem, nomePersonagem);
				AutomatedActions.SendDataATM(Browser, InputCampoAtor, "LUCAS ALVES");
				KeyboardActions.Tab(Browser, InputCampoAtor);
				AutomatedActions.TypingListATM(Browser, DropListTipoPersonagem, InputTipoPersonagem, "Principal");

			SalvarNovoPersonagem(nomePersonagem);
		}

		private void SalvarNovoPersonagem(string nomePersonagem)
		{
			BtnSalvarPersonagem.EsperarElemento(Browser);
			if (BtnSalvarPersonagem.IsElementVisible(Browser))
				BtnSalvarPersonagem.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnSalvarPersonagem);

			UsarPersonagem(nomePersonagem);
		}

		private void UsarPersonagem(string nomePersonagem)
		{
			InputPersonagem.EsperarElemento(Browser);
			if (InputPersonagem.IsElementVisible(Browser))
				KeyboardActions.Backspace(Browser, InputPersonagem);
				AutomatedActions.SendDataEnterATM(Browser, InputPersonagem, nomePersonagem);
		}

		private void DecuparCenaParaCenarioAmbiente(string numeroCapitulo, string nomePersonagem, string nomeFigurantes)
		{
			DropListCapitulo.EsperarElemento(Browser);
			SelecionarCapitulo(numeroCapitulo);
			EscolherTempo("0");
			EscolherLocacao("1");
			EscolherClassificacao("Ação");
			PreencherDados(nomePersonagem, nomeFigurantes);
		}

		private void DecuparCenaParaAberturaLetra(string nomeCenario, string nomePersonagem, string nomeFigurantes)
		{
			EscolherTempo("0");
			EscolherLocacao("1");
			PreencherCenario(nomeCenario);
			EscolherClassificacao("Ação");
			PreencherDados(nomePersonagem, nomeFigurantes);
		}

		private void AdicionarNovoCenario(string nomeCenario)
		{
			BtnNovoCenario.Esperar(Browser, 1000);
			BtnNovoCenario.EsperarElemento(Browser);
			if (BtnNovoCenario.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnNovoCenario);
				BrowserHelpers.EliminarAlertasChrome(Browser);
				AutomatedActions.SendDataATM(Browser, InputNomeNovoCenario, nomeCenario);
			
		}

		private void DecuparCenaParaPersonagem(string numeroCapitulo, string nomeFigurantes, string nomeCenario)
		{
			Browser.Abrir(DecupagemBasicaUrl);
			DropListCapitulo.EsperarElemento(Browser);
			SelecionarCapitulo(numeroCapitulo);
			DropListCenario.IsClickable(Browser);
			PreencherCenario(nomeCenario);
			EscolherTempo("0");
			EscolherLocacao("1");
			EscolherClassificacao("Ação");
			PreencherResumoCena();
			PreencherCampoOBS();
			PreencherFigurantes(nomeFigurantes);
		}

		private void AdicionarMaisAmbientes(string nomeAmbiente)
		{
			BtnAdicionarMaisAmbientes.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, BtnAdicionarMaisAmbientes);
			BrowserHelpers.EliminarAlertasChrome(Browser);

			if (InputNomeAdicionarAmbiente.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNomeAdicionarAmbiente, nomeAmbiente);
		}

		private void PreencherCenario(string nomeCenario)
		{
			//DropListCenario.Esperar(Browser, 500);
			DropListCenario.EsperarElemento(Browser);
			if (DropListCenario.IsElementVisible(Browser))
			{
				DropListCenario.IsClickable(Browser);
				AutomatedActions.TypingListATM(Browser, DropListCenario, InputListCenario, nomeCenario);
			}
		}

		private void PreencherAmbiente(string nomeAmbiente)
		{
			DropListAmbiente.EsperarElemento(Browser);
			if (DropListAmbiente.IsElementVisible(Browser))
			{
				DropListAmbiente.IsClickable(Browser);
				AutomatedActions.TypingListATM(Browser, DropListAmbiente, InputListAmbiente, nomeAmbiente);
			}
		}

		private void SalvarNovoCenario()
		{
			BtnSalvarNovoCenario.EsperarElemento(Browser);
			if(BtnSalvarNovoCenario.IsNotElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarNovoCenario);
		}



		public void EscolherTempo(string radioTempo)
		{
			//Legenda: 0 - DIA | 1 - TARDE | 2 - NOITE
			var RadioButtonTempo = Element.Xpath("//label[contains(@for,'rdbDiaNoite-" + radioTempo + "')]");

			RadioButtonTempo.EsperarElemento(Browser);
			if (RadioButtonTempo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, RadioButtonTempo);
		}

		private void EscolherLocacao(string locacao)
		{
			//Legenda: 0 - INTERIOR | 1 - EXTERIOR
			var RadioButtonLocacao = Element.Xpath("//label[contains(@for,'rdbInteriorExterior-" + locacao + "')]");

			RadioButtonLocacao.EsperarElemento(Browser);
			if (RadioButtonLocacao.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, RadioButtonLocacao);
		}

		private void EscolherClassificacao(string classificao)
		{
			var ChkClassificacao = Element.Xpath("//*[@id='areaComun']//label[contains(.,'" + classificao + "')]");

			ChkClassificacao.EsperarElemento(Browser);
			if (ChkClassificacao.IsElementVisible(Browser))
				MouseActions.SelectCheckBoxATM(Browser, ChkClassificacao);
		}

		private void PreencherDados(string nomePersonagem, string nomeFigurantes)
		{
			PreencherResumoCena();
			PreencherCampoOBS();
			PreencherPersonagem(nomePersonagem);
			PreencherFigurantes(nomeFigurantes);
		}

		private void PreencherResumoCena()
		{
			InputResumoCena.EsperarElemento(Browser);
			if (InputResumoCena.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputResumoCena, FakeHelpers.FullName());
		}

		private void PreencherCampoOBS()
		{
			InputObsCena.EsperarElemento(Browser);
			if (InputObsCena.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputObsCena, FakeHelpers.FullName());
		}

		private void PreencherPersonagem(string personagem)
		{
			InputPersonagem.EsperarElemento(Browser);
			if (InputPersonagem.IsElementVisible(Browser))
				AutomatedActions.SendDataEnterATM(Browser, InputPersonagem, personagem);
		}

		private void PreencherFigurantes(string figurantes)
		{
			InputFigurante.EsperarElemento(Browser);
			if (InputFigurante.IsElementVisible(Browser))
				AutomatedActions.SendDataEnterATM(Browser, InputFigurante, figurantes);
				KeyboardActions.Escape(Browser, InputFigurante);
		}

		private void SelecionarCapitulo(string numeroCapitulo)
		{
			DropListCapitulo.EsperarElemento(Browser);
			if (DropListCapitulo.IsElementVisible(Browser))
				DropListCapitulo.IsClickable(Browser);
				AutomatedActions.TypingListATM(Browser, DropListCapitulo, InputListCapitulo, numeroCapitulo);
		}

		private void SelecionarCena(string numeroCena)
		{
			DropListCena.EsperarElemento(Browser);
			if (DropListCena.IsElementVisible(Browser))
				DropListCena.IsClickable(Browser);
				AutomatedActions.TypingListATM(Browser, DropListCena, InputListCena, numeroCena);
		}

		//----------REAPROVEITAR PERSONAGEM-------------\\
		public void ReaproveitarPersonagem(string numeroCapitulo)
		{
			SelecionarCapitulo(numeroCapitulo);
			ClicarBtnReaproveitarPersonagem();
			PreencherCapituloReaproveitarPersonagem(numeroCapitulo);
			ClicarBtnFiltrarReaproveitarPersonagem();
			SelecionarReaproveitarPersonagem();
			ClicarBtnReaproveitar();
		}

		private void PreencherCapituloReaproveitarPersonagem(string numeroCapitulo)
		{
			InputReaproveitarPersonagemCapituloDe.EsperarElemento(Browser);
			if (InputReaproveitarPersonagemCapituloDe.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputReaproveitarPersonagemCapituloDe, numeroCapitulo);
				AutomatedActions.SendDataATM(Browser, InputReaproveitarPersonagemCapituloAte, numeroCapitulo);
		}

		private void ClicarBtnReaproveitarPersonagem()
		{
			BtnReaproveitarPersonagem.EsperarElemento(Browser);
			if (BtnReaproveitarPersonagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnReaproveitarPersonagem);
		}

		private void SelecionarReaproveitarPersonagem()
		{
			var SelectPersonagem = Element.Xpath("//tr[@class='tstRoupaDeCena']//td[@class='left'][1]");

			SelectPersonagem.EsperarElemento(Browser);
			if (!SelectPersonagem.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, SelectPersonagem);
		}

		private void ClicarBtnFiltrarReaproveitarPersonagem()
		{
			BtnFiltrarReaproveitarPersonagem.EsperarElemento(Browser);
			if (BtnFiltrarReaproveitarPersonagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnFiltrarReaproveitarPersonagem);
		}

		private void ClicarBtnReaproveitar()
		{
			BtnReaproveitar.EsperarElemento(Browser);
			if (BtnReaproveitar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnReaproveitar);
		}

		public override void Navegar()
		{
			Browser.Abrir(DecupagemBasicaUrl);
			Browser.PageLoad();
		}


        //------------------------------------------GROT-----------------------------------------------\\
        public void AcessarDecupagemBasica()
        {
            var opcoes = Element.Css("a[class='icon-button icon-more-options']");
            //var editarPath = Element.Css("span[class='editSc redirDecup icon-button icon-edit-2']");
            var linkDecupagemBasica = Element.Xpath("//div[@class='links-edicao-cap']//a[text()='Decupar Capítulo']");

            opcoes.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, opcoes);
            //editarPath.EsperarElemento(Browser);
            //MouseActions.ClickATM(Browser, editarPath);
            linkDecupagemBasica.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, linkDecupagemBasica);
        }

        public void AcessarEdicaoDecupagemBasica()
        {
            var dropdownCapitulo = Element.Css("div[class=' form accordion divCapitulo expandirCenas']");
            var editarPath = Element.Css("span[class='editSc redirDecup icon-button icon-edit-2']");
            var linkDecupagemBasica = Element.Xpath("//div[@class='cenaAdiv']//a[text()='Decupagem Básica']");

            dropdownCapitulo.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, dropdownCapitulo);
            editarPath.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, editarPath);
            linkDecupagemBasica.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, linkDecupagemBasica);
        }

        public void DecuparCenaCompletaGROT(string numeroCapitulo, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes, 
            string duracao, string limiteGravacao, string faixaInicio, string faixaFinal)
        {
            Browser.Abrir(DecupagemBasicaUrl);
            SelecionarCapitulo(numeroCapitulo);
            if(nomeCenario != "")
            {
                PreencherCenario(nomeCenario);
                PreencherAmbiente(nomeAmbiente);
            }
            EscolherTempo("0");
            EscolherLocacao("1");
            EscolherClassificacao("Ação");
            PreencherDuracao(duracao);
            PreencherLimiteDeGravacao(limiteGravacao);
            PreencherFaixaPrevistaGravacao(faixaInicio, faixaFinal);
            PreencherDados(nomePersonagem, nomeFigurantes);
        }

        public void EditarDecuparCenaCompletaGROT(string numeroCapitulo, string nomeCenario, string nomeAmbiente, string nomePersonagem, string nomeFigurantes,
            string duracao, string limiteGravacao, string faixaInicio, string faixaFinal)
        {
            //Browser.Abrir(DecupagemBasicaUrl);
            //SelecionarCapitulo(numeroCapitulo);
            if (nomeCenario != "")
            {
                PreencherCenario(nomeCenario);
                PreencherAmbiente(nomeAmbiente);
            }
            //EscolherTempo("0");
            //EscolherLocacao("1");
            //EscolherClassificacao("Ação");
            PreencherDuracao(duracao);
            PreencherLimiteDeGravacao(limiteGravacao);
            PreencherFaixaPrevistaGravacao(faixaInicio, faixaFinal);
            if(nomePersonagem != "")
            {
                PreencherDados(nomePersonagem, nomeFigurantes);
            }
        }

        public void PreencherDuracao(string duracao)
        {
            InputDuracao.EsperarElemento(Browser);
            InputDuracao.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputDuracao, duracao);
        }

        private void PreencherLimiteDeGravacao(string limiteGravacao)
        {
            InputLimiteGravacao.EsperarElemento(Browser);
            InputLimiteGravacao.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputLimiteGravacao, limiteGravacao);
        }

        private void PreencherFaixaPrevistaGravacao(string faixaInicio, string faixaFinal)
        {
            InputFaixaPrevistaInicio.EsperarElemento(Browser);
            InputFaixaPrevistaInicio.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputFaixaPrevistaInicio, faixaInicio);

            InputFaixaPrevistaFinal.EsperarElemento(Browser);
            InputFaixaPrevistaFinal.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputFaixaPrevistaFinal, faixaFinal);

        }

        public void ValidarNovosCamposDecupagemBasica(string campo)
        {
            var campoPath = Element.Xpath("//label[text()='" + campo + "']");
            campoPath.EsperarElemento(Browser);
            campoPath.IsElementVisible(Browser);
        }

        public void ValidarValoresCamposGROT(string duracao, string limiteGravacao, string faixaInicio, string faixaFinal)
        {
            if(duracao != "")
            {
                string duracaoText = InputDuracao.GetValorAtributo("value", Browser);
                Assert.AreEqual(duracaoText, duracao);
            }
            if(limiteGravacao != "")
            {
                string limiteGravacaoText = InputLimiteGravacao.GetValorAtributo("value", Browser);
                Assert.AreEqual(limiteGravacaoText, limiteGravacao);
            }      
            if(faixaInicio != "")
            {
                string faixaInicialText = InputFaixaPrevistaInicio.GetValorAtributo("value", Browser);
                Assert.AreEqual(faixaInicialText, faixaInicio);
            }
            if (faixaFinal != "")
            {
                string faixaFinalText = InputFaixaPrevistaFinal.GetValorAtributo("value", Browser);
                Assert.AreEqual(faixaFinalText, faixaFinal);
            }
        }
    }
}
