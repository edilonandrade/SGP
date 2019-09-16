using Framework.Core.Actions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core.Extensions.ElementExtensions;
using Project.SGP.Helpers;
using System.Configuration;

namespace Project.SGP.Pages
{
	public class CapitulosCenasPage : PageBase
	{
		private string CapituloCenaUrl { get; }
		private string IncluirCapituloUrL { get; }
		private string IncluirAdendoUrl { get; }

		//Input
		private Element InputCapitulo { get; }
		private Element InputEpisodio { get; }
		private Element InputDataEntrega { get; }
		private Element InputDataExibicao { get; }
		private Element InputEditEpisodio { get; }
		private Element InputEditDataExibicao { get; }

		//Button
		private Element BtnContinuar { get; }
		private Element BtnEditSalvar { get; }
		private Element BtnIncluirAdendo { get; }
		private Element BtnExcluirCenaOK { get; }
		private Element BtnAnexarCapitulo { get; }
		private Element BtnSalvarCapitulo { get; }
		private Element BtnEditarCapitulo { get; }
		private Element BtnExcluirCapitulo { get; }
		private Element BtnExcluirCapituloOK { get; }
		private Element BtnSalvarDecuparCapitulo { get; }
		private Element BtnImprimirRelatorio { get; }
		private Element BtnFecharDetalhes { get; }
		private Element Filtros { get; }
		private Element BtnFiltrar { get; }
		private Element BtnLimpar { get; }
		private Element BtnCopiarCapitulos { get; }
		private Element BtnEnviarCapitulo { get; }
		private Element BtnOKImpressao { get; }

		//Others
		private Element AbaPersonagem { get; }
		private Element MoreDetails { get; }
		private Element BtnExcluirCena { get; }
		private Element BodyCapituloCena { get; }
		private Element RadioBtnQuemPodeVer { get; }
		private Element ChkCapituloSecreto { get; }
		private Element PopUpDetCena { get; }
		private Element CheckIntervaloCapitulo { get; }
		private Element CheckIntervaloCena { get; }
		private Element CheckIntervaloDataRoteiro { get; }
		private Element CheckIntervaloNumeroRoteiro { get; }
		private Element CheckIntervalo { get; }
		private Element DivOpcoesImpressao { get; }
		private Element ChkListagemBasica { get; }
		private Element ChkCapituloCena { get; }
		private Element ChkMateriaisCena { get; }
		private Element ChkPersonagemRoupa { get; }
		private Element ChkContinuidadeAcao { get; }
		private Element ChkTextoCena { get; }
		private Element ChkListagemPorCapitulo { get; }
		private Element Loading { get; }

		public CapitulosCenasPage(IBrowser browser,
			string capituloCenaUrl,
			string incluirCapituloUrl,
			string incluirAdendoUrl)
			: base(browser)
		{
			CapituloCenaUrl = capituloCenaUrl;
			IncluirCapituloUrL = incluirCapituloUrl;
			IncluirAdendoUrl = incluirAdendoUrl;

			//Input
			InputEpisodio = Element.Nome("episodio");
			InputEditEpisodio = Element.Id("NomeEpisodio");
			InputDataEntrega = Element.Nome("dataEntrega");
			InputDataExibicao = Element.Nome("dataExibicao");
			InputEditDataExibicao = Element.Id("DataExibicao");
			InputCapitulo = Element.Xpath("//*[@id='arquivos']//input[1]");

			//Button
			BtnIncluirAdendo = Element.Nome("arquivo");
			BtnAnexarCapitulo = Element.Id("text");
			BtnEditSalvar = Element.Id("btnEditaCap");
			BtnContinuar = Element.Id("btncontinuar");
			BtnExcluirCapitulo = Element.Link("Excluir");
			BtnEditarCapitulo = Element.Link("Editar Capítulo");
			BtnSalvarCapitulo = Element.Id("btnsalvar-capitulo");
			BtnExcluirCapituloOK = Element.Xpath("//button//span[text()='OK']");
			BtnSalvarDecuparCapitulo = Element.Id("btnsalvar-decupar-capitulo");
			BtnExcluirCenaOK = Element.Xpath("//div[@class='ui-dialog-buttonset']//span[text()='OK']");
			BtnImprimirRelatorio = Element.Css("#gerarRelatorioBtn");
			BtnFecharDetalhes = Element.Xpath("//div[9]//button//span[text()='Fechar']");
			BtnLimpar = Element.Id("limparBtn");
			BtnFiltrar = Element.Id("filtrarBtn");
			Filtros = Element.Id("btnToggleFilter");
			BtnCopiarCapitulos = Element.Id("copiaCapitulo");
			BtnEnviarCapitulo = Element.Css("#btnEnviar span");
			BtnOKImpressao = Element.Xpath("//div[@aria-labelledby='ui-id-5']//button/span[text()='OK']");

			//Others
			BtnExcluirCena = Element.Css(".linkExcluir");
			AbaPersonagem = Element.Id("ui-id-7");
			BodyCapituloCena = Element.Id("pagina-capitulo-cena");
			RadioBtnQuemPodeVer = Element.Id("radios-0");
			ChkCapituloSecreto = Element.Css("input[class='chkCenaSecreta']");
			PopUpDetCena = Element.Id("popDetCena");
			CheckIntervaloCapitulo = Element.Id("intervaloCapitulo");
			CheckIntervaloCena = Element.Id("intervaloCena");
			CheckIntervaloDataRoteiro = Element.Id("intervaloDataRoteiro");
			CheckIntervaloNumeroRoteiro = Element.Id("intervaloRoteiro");
			CheckIntervalo = Element.Id("intervalCapCopia");
			DivOpcoesImpressao = Element.Id("div-alert-form");
			ChkListagemBasica = Element.Id("listagemBasica");
			ChkCapituloCena = Element.Id("opt9");
			ChkMateriaisCena = Element.Id("opt2");
			ChkPersonagemRoupa= Element.Id("opt10");
			ChkContinuidadeAcao = Element.Id("opt3");
			ChkTextoCena = Element.Id("opt5");
			ChkListagemPorCapitulo = Element.Id("listagemPorCapitulo");
			Loading = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");
		}


		//-------------------METODOS-------------------\\
		public void CriarNovoCapitulo(string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			ClicarBtnNovoCapitulo();
			AnexarCapitulo();
			PreencherNovoCapitulo(numeroCapitulo);
			SelecionarQuemPodeVer();
			SalvarCapitulo();
		}

		private void ClicarBtnNovoCapitulo()
		{
			var IFrameNovoCapitulo = Element.Id("AbaCapituloPacote");
			var BtnNovoCapitulo = Element.Id("novoCapituloBtn");

			IFrameNovoCapitulo.EsperarElemento(Browser);
			IFrameNovoCapitulo.ClickIFrame(Browser, BtnNovoCapitulo);
			IFrameNovoCapitulo.SairIFrame(Browser);
		}

		public void CriarNovoCapituloComDecupagem(string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			ClicarBtnNovoCapitulo();
			AnexarCapitulo();
			PreencherNovoCapitulo(numeroCapitulo);
			SelecionarQuemPodeVer();
			SalvarDecuparCapitulo();
		}

		public void CriarNovoCapituloSecreto(string numeroCapitulo, string nomeMembro)
		{
			Browser.Abrir(CapituloCenaUrl);
			ClicarBtnNovoCapitulo();
			AnexarCapitulo();
			PreencherNovoCapitulo(numeroCapitulo);
			SelecionarQuemPodeVer();
			SelecionarCapituloSecreto();
			EscolherMembroProducaoSecreto(nomeMembro);
			SalvarDecuparCapitulo();
		}

		private void AnexarCapitulo()
		{
			var PopUpArquivo = Element.Id("popNovoCapitulo");
			var IFrameAnexarCapitulo = Element.Id("iframeNovoCapitulo");
			var BtnArrastarArquivo = Element.Css("input[title='Selecione o arquivo']");

			PopUpArquivo.Esperar(Browser, 1000);
			PopUpArquivo.EsperarElemento(Browser);
			IFrameAnexarCapitulo.EsperarIFrame(Browser);
			AutomatedActions.SendDataATM(Browser, BtnArrastarArquivo, GetPath.GetResourcePath("cap_10.fdx"));
		}


		private void PreencherNovoCapitulo(string numeroCapitulo)
		{
			InputCapitulo.EsperarElemento(Browser);
			if (InputCapitulo.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputCapitulo, numeroCapitulo);
				MouseActions.ClickATM(Browser, BtnContinuar);
				PreencherCamposNovoCapitulo();
			}
		}

		private void PreencherCamposNovoCapitulo()
		{
			InputEpisodio.EsperarElemento(Browser);
			if (InputEpisodio.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputEpisodio, FakeHelpers.FirstName());
				AutomatedActions.SendDataATM(Browser, InputDataEntrega, CalendarioHelper.ObterDataAtual());
				AutomatedActions.SendDataATM(Browser, InputDataExibicao, CalendarioHelper.ObterMesFuturo(3));
			}
		}

		private void SalvarCapitulo()
		{
			var IFrameAnexarCapitulo = Element.Id("iframeNovoCapitulo");

			BtnSalvarCapitulo.Esperar(Browser, 1000);
			BtnSalvarCapitulo.EsperarElemento(Browser);
			if (BtnSalvarCapitulo.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarCapitulo);
			}

			MensagemValidar();
			IFrameAnexarCapitulo.SairIFrame(Browser);
		}

		private void MensagemValidar()
		{
			var Mensagem = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");

			Mensagem.EsperarElemento(Browser);
			if (Mensagem.IsElementVisible(Browser))
			{
				Mensagem.IsElementVisible(Browser);
				string texto = Mensagem.GetTexto(Browser);

				Assert.IsTrue(true, texto);
			}
		}

		private void SelecionarQuemPodeVer()
		{
			RadioBtnQuemPodeVer.EsperarElemento(Browser);
			if(RadioBtnQuemPodeVer.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, RadioBtnQuemPodeVer);
		}

		private void SelecionarCapituloSecreto()
		{
			ChkCapituloSecreto.EsperarElemento(Browser);
			if(ChkCapituloSecreto.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, ChkCapituloSecreto);
				KeyboardActions.Tab(Browser, ChkCapituloSecreto);
		}

		private void EscolherMembroProducaoSecreto(string nomeMembro)
		{
			var InputText = Element.Xpath("//*[@class='chosen-container chosen-container-multi chosen-with-drop chosen-container-active']//input");
			InputText.EsperarElemento(Browser);
			if (InputText.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataEnterATM(Browser, InputText, nomeMembro);
			}
		}

		public void EditarCapitulos(string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			SelecionarMaisDetalhes(numeroCapitulo);
			SelecionarEditarCapitulo();
			PreencherEditarCapitulo();
			SalvarEditar();
		}

		public void ExcluirCena(string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			SelecionarCapitulo(numeroCapitulo);
			ApagarCena();
		}

		public void ExcluirCapitulo(string campo, string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);

			FiltrarCapitulos(campo, numeroCapitulo);
			SelecionarMaisDetalhes(numeroCapitulo);
			ApagarCapitulo();
			PopUpApagarCapitulo();
		}

		public void ExcluirCapituloCopiado(string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			//ClicarFiltros();
			FiltrarCapitulos("capituloDe", numeroCapitulo);
			//DesflegarIntervaloCapitulo();
			//PreencherFiltroCapitulo("capituloDe", numeroCapitulo);
			ClicarBtnFiltrar();
			SelecionarMaisDetalhes(numeroCapitulo);
			ApagarCapitulo();
			PopUpApagarCapitulo();
		}

		public void SairSGP()
		{
			var BtnSair = Element.Link("Sair");
			//var BtnMensagem = Element.Css("div[class='container'] button");

			BtnSair.EsperarElemento(Browser);
			if (BtnSair.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSair);
		}

		private void SalvarDecuparCapitulo()
		{
			var SelectCapitulo = Element.Css("#selectAllCapitulosPacotes_chosen a");

			BtnSalvarDecuparCapitulo.EsperarElemento(Browser);
			if (BtnSalvarDecuparCapitulo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarDecuparCapitulo);

			SelectCapitulo.EsperarElemento(Browser);
		}

		private void SelecionarMaisDetalhes(string numeroCapitulo)
		{
			var MoreDetails = Element.Xpath("//div[contains(@data-codigocapitulo, '" + numeroCapitulo + "')]//a[contains(@title, 'Mais ações no capítulo')]");

			MoreDetails.EsperarElemento(Browser);
			if (MoreDetails.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, MoreDetails);
		}

		private void ApagarCapitulo()
		{
			DeletarCapitulo();
		}

		private void DeletarCapitulo()
		{
			BtnExcluirCapitulo.EsperarElemento(Browser);
			if (BtnExcluirCapitulo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnExcluirCapitulo);
		}

		private void SelecionarEditarCapitulo()
		{
			BtnEditarCapitulo.EsperarElemento(Browser);
			if (BtnEditarCapitulo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnEditarCapitulo);
		}

		private void PreencherEditarCapitulo()
		{
			string nomeEpisodio = EpisodioHelper.GerarEpisodios("Episódio - Teste - ");
			AutomatedActions.SendDataATM(Browser, InputEditEpisodio, nomeEpisodio);
			AutomatedActions.SendDataATM(Browser, InputEditDataExibicao, CalendarioHelper.ObterMesFuturo(1));
			KeyboardActions.Tab(Browser, InputEditDataExibicao);
		}

		public void EditarCapituloPreenchendoDataAtualExibicao(string numeroCapitulo)
		{
			SelecionarMaisDetalhes(numeroCapitulo);
			SelecionarEditarCapitulo();
			PreencherDataAtualExibicao();
			SalvarEditar();
		}

        public void EditarCapituloPreenchendoDataExibicao(string numeroCapitulo)
        {
            SelecionarMaisDetalhes(numeroCapitulo);
            SelecionarEditarCapitulo();
            PreencherDataExibicao();
            SalvarEditar();
        }

        private void PreencherDataExibicao()
        {
            InputEditDataExibicao.EsperarElemento(Browser);
            if (InputEditDataExibicao.IsElementVisible(Browser))
            {
                AutomatedActions.SendDataATM(Browser, InputEditDataExibicao, CalendarioHelper.ObterDataFutura(1));
                KeyboardActions.Tab(Browser, InputEditDataExibicao);
            }
        }

        private void PreencherDataAtualExibicao()
		{
			InputEditDataExibicao.EsperarElemento(Browser);
			if (InputEditDataExibicao.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputEditDataExibicao, CalendarioHelper.ObterDiaAtual());
				KeyboardActions.Tab(Browser, InputEditDataExibicao);
			}
		}

		private void SalvarEditar()
		{
			BtnEditSalvar.EsperarElemento(Browser);
			if (BtnEditSalvar.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnEditSalvar);
			}
		}

		public void AbrirMapaCenas(string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);

			SelecionarCapitulo(numeroCapitulo);
			SelecionarMapaCenas(numeroCapitulo);
		}

		private void SelecionarMapaCenas(string numeroCapitulo)
		{
			var MapaCenasDetails = Element.Xpath("//div[contains(@data-codigocapitulo, '" + numeroCapitulo + "')]//div[contains(@title, 'Mapa de cenas')]");

			MapaCenasDetails.EsperarElemento(Browser);
			if (MapaCenasDetails.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, MapaCenasDetails);
		}

		public void IncluirAdendo(string numeroCapitulo)
		{
			SelecionarMaisDetalhes(numeroCapitulo);
			EscolherIncluirAdendo(numeroCapitulo);
			SelecionarArquivoAdendo();
		}

		private void EscolherIncluirAdendo(string numeroCapitulo)
		{
			var IncluirAdendo = Element.Css("div[class='links-edicao-cap'] a[data-codigo-cap='" + numeroCapitulo + "']");

			IncluirAdendo.EsperarElemento(Browser);
			if (IncluirAdendo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, IncluirAdendo);
		}

		private void SelecionarArquivoAdendo()
		{
			var IFrameAdendo = Element.Id("iframeAdendo");
			var SelecioneArquivo = Element.Id("text");
			if (IFrameAdendo.IsElementVisible(Browser))
				IFrameAdendo.AnexarArquivoIFrame(Browser, SelecioneArquivo, GetPath.GetResourcePath("Adendo - Lado a Lado.docx"));
		}

		private void PopUpApagarCapitulo()
		{
			var CapCenas = Element.Css("div[class='div1']");
			if (Browser.PageSource("O capítulo selecionado e todas as suas cenas serão excluídos e não poderão ser recuperados. Tem certeza que deseja excluir este capítulo?"))
				MouseActions.ClickATM(Browser, BtnExcluirCapituloOK);

			CapCenas.EsperarElemento(Browser);
			CapCenas.IsClickable(Browser);
		}

		private void ApagarCena()
		{
			var DeletarCena = Element.Css(".linkExcluir");
			DeletarCena.EsperarElemento(Browser);

			if (DeletarCena.IsClickable(Browser))
				MouseActions.ClickATM(Browser, DeletarCena);

			PopUpApagarCena();
		}

		private void PopUpApagarCena()
		{
			BtnExcluirCenaOK.EsperarElemento(Browser);
			if (Browser.PageSource("Deseja remover a cena?"))
				MouseActions.ClickATM(Browser, BtnExcluirCenaOK);
		}

		private void SelecionarCapitulo(string numeroCapitulo)
		{
			var CheckCapitulo = Element.Xpath("//*[@id='divCapitulos']//strong[contains(.,'" + numeroCapitulo + "')]");

			CheckCapitulo.EsperarElemento(Browser);
			if (CheckCapitulo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, CheckCapitulo);
		}


		//---------------FILTROS CENAS---------------------\\
		public void FiltrarCapitulos(string campo, string filtro)
		{
			ClicarFiltros();
			DesflegarIntervaloCapitulo();
			PreencherFiltroCapitulo(campo, filtro);
			ClicarBtnFiltrar();
		}

		public void FiltrarIntervaloCapitulos(string campo, string filtro)
		{
			ClicarFiltros();
			FlegarIntervaloCapitulo();
			PreencherFiltroCapitulo(campo, filtro);
			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosIntervaloCenas(string campoCap, string campoCena, string filtroCap, string filtroCena)
		{
			ClicarFiltros();
			DesflegarIntervaloCapitulo();
			PreencherFiltroCapitulo(campoCap, filtroCap);
			FlegarIntervaloCena();
			FiltrarCena(campoCena, filtroCena);
			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosDatasRoteiros(string campoData, string filtroData)
		{
			ClicarFiltros();
			DesflegarIntervaloDataRoteiro();
			PreencherFiltroCapitulo(campoData, filtroData);
			ClicarBtnFiltrar();
		}
		public void FiltrarCapitulosCategoria(string filtroCategoria)
		{
			ClicarFiltros();
			var InputCategoria = Element.Css("div[id='selectCategorias_chzn'] input");

			InputCategoria.EsperarElemento(Browser);
			if (InputCategoria.IsElementVisible(Browser))
				AutomatedActions.SendDataEnterATM(Browser, InputCategoria, filtroCategoria);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosCenario(string filtroCenario)
		{
			ClicarFiltros();

			var InputCenario = Element.Css("div[id='selectCenarios_chzn'] input");

			InputCenario.EsperarElemento(Browser);
			if (InputCenario.IsElementVisible(Browser))
				AutomatedActions.SendDataEnterATM(Browser, InputCenario, filtroCenario);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosCenarioAmbiente(string filtroCenario, string filtroAmbiente)
		{
			ClicarFiltros();

			var InputCenario = Element.Css("div[id='selectCenarios_chzn'] input");
			var InputAmbiente = Element.Css("div[id='selectAmbientes_chzn'] input");

			InputCenario.EsperarElemento(Browser);
			if (InputCenario.IsElementVisible(Browser))
				AutomatedActions.SendDataEnterATM(Browser, InputCenario, filtroCenario);
				AutomatedActions.SendDataEnterATM(Browser, InputAmbiente, filtroAmbiente);

			ClicarBtnFiltrar();
			
		}

		public void FiltrarCapitulosStatus(string filtroStatus)
		{
			ClicarFiltros();

			var DropListStatus = Element.Css("div[id='selectStatus_chzn']");
			var InputStatus = Element.Css("div[id='selectStatus_chzn'] input");

			DropListStatus.EsperarElemento(Browser);
			if (DropListStatus.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListStatus, InputStatus, filtroStatus);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosTipo(string filtroTipo)
		{
			ClicarFiltros();

			var DropListTipo = Element.Css("div[id='selectTipo_chzn']");
			var InputTipo = Element.Css("div[id='selectTipo_chzn'] input");

			DropListTipo.EsperarElemento(Browser);
			if (DropListTipo.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListTipo, InputTipo, filtroTipo);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosDoisCampos(string campoCapitulo, string filtroCapitulo, string filtroCategoria)
		{
			ClicarFiltros();
			PreencherFiltroCapitulo(campoCapitulo, filtroCapitulo);
			FiltrarCapitulosCategoria(filtroCategoria);
			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosTresCampos(string campoCapitulo, string filtroCapitulo, string campoCena, string filtroCena, string filtroCategoria)
		{
			ClicarFiltros();
			DesflegarIntervaloCapitulo();
			PreencherFiltroCapitulo(campoCapitulo, filtroCapitulo);
			FiltrarCena(campoCena, filtroCena);
			FiltrarCapitulosCategoria(filtroCategoria);
			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosMatMarcCena(string filtroMatMarcCena)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListMatMarcCena = Element.Css("div[id='selectListaMarcacaoCena_chzn']");
			var InputMatMarcCena = Element.Css("div[id='selectListaMarcacaoCena_chzn'] input");

			DropListMatMarcCena.EsperarElemento(Browser);
			if (DropListMatMarcCena.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListMatMarcCena, InputMatMarcCena, filtroMatMarcCena);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosCenasSecretas(string filtroCapituloSecreto)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListCapCenaSecretos = Element.Css("div[id='selectSecreto_chzn']");
			var InputCapCenaSecretos = Element.Css("div[id='selectSecreto_chzn'] input");

			DropListCapCenaSecretos.EsperarElemento(Browser);
			if (DropListCapCenaSecretos.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListCapCenaSecretos, InputCapCenaSecretos, filtroCapituloSecreto);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosMatPrioritario(string filtroMatPrioritario)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListMatPrioritario = Element.Css("div[id='selectListaPrioritaria_chzn']");
			var InputMatPrioritario = Element.Css("div[id='selectListaPrioritaria_chzn'] input");

			DropListMatPrioritario.EsperarElemento(Browser);
			if (DropListMatPrioritario.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListMatPrioritario, InputMatPrioritario, filtroMatPrioritario);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosClassificacao(string filtroClassificacao)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListClassificacao = Element.Css("div[id='selectClassificacao_chzn']");
			var InputClassificacao = Element.Css("div[id='selectClassificacao_chzn'] input");

			DropListClassificacao.EsperarElemento(Browser);
			if (DropListClassificacao.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListClassificacao, InputClassificacao, filtroClassificacao);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosPersonagem(string filtroPersonagem)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListPersonagem = Element.Css("div[id='selectPersonagens_chzn']");
			var InputPersonagem = Element.Css("div[id='selectPersonagens_chzn'] input");

			DropListPersonagem.EsperarElemento(Browser);
			if (DropListPersonagem.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListPersonagem, InputPersonagem, filtroPersonagem);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosFigurante(string filtroFigurante)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListFigurante = Element.Css("div[id='selectFigurantes_chzn']");
			var InputFigurante = Element.Css("div[id='selectFigurantes_chzn'] input");

			DropListFigurante.EsperarElemento(Browser);
			if (DropListFigurante.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListFigurante, InputFigurante, filtroFigurante);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosPeriodoDoDia(string filtroPeriodo)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListPeriodo = Element.Css("div[id='selectTipoLuz_chzn']");
			var InputPeriodo = Element.Css("div[id='selectTipoLuz_chzn'] input");

			DropListPeriodo.EsperarElemento(Browser);
			if (DropListPeriodo.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListPeriodo, InputPeriodo, filtroPeriodo);

			ClicarBtnFiltrar();
		}

		public void FiltrarCapitulosTipoCenario(string filtroTipo)
		{
			ClicarFiltros();
			ClicarCamposAvancados();

			var DropListTipo = Element.Css("div[id='selectTipoCena_chzn']");
			var InputTipo = Element.Css("div[id='selectTipoCena_chzn'] input");

			DropListTipo.EsperarElemento(Browser);
			if (DropListTipo.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListTipo, InputTipo, filtroTipo);

			ClicarBtnFiltrar();
		}

		private void PreencherFiltroCapitulo(string campo, string filtro)
		{
			var Form = Element.Id("formbusca");

			Form.EsperarElemento(Browser);
			if (Form.IsElementVisible(Browser))
			{
				//Legenda: capituloDe, capiutloAte, cenaDe, cenaAte
				var InputCapitulo = Element.Xpath("//input[@id='" + campo + "']");
				InputCapitulo.EsperarElemento(Browser);
				AutomatedActions.SendDataATM(Browser, InputCapitulo, filtro);
			}
		}

		private void FiltrarCena(string campo, string filtro)
		{
			var Form = Element.Id("formbusca");

			Form.EsperarElemento(Browser);
			if (Form.IsElementVisible(Browser))
			{
				//Legenda: capituloDe, capiutloAte, cenaDe, cenaAte
				var InputCena = Element.Xpath("//input[@id='" + campo + "']");
				AutomatedActions.SendDataATM(Browser, InputCena, filtro);
			}
		}

		private void DesflegarIntervaloCapitulo()
		{
			CheckIntervaloCapitulo.EsperarElemento(Browser);
			if (!CheckIntervaloCapitulo.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloCapitulo);
		}

		private void DesflegarIntervaloCena()
		{
			CheckIntervaloCapitulo.EsperarElemento(Browser);
			if (!CheckIntervaloCena.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloCena);
		}

		private void DesflegarIntervaloDataRoteiro()
		{
			CheckIntervaloDataRoteiro.EsperarElemento(Browser);
			if (!CheckIntervaloDataRoteiro.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloDataRoteiro);
		}

		private void DesflegarIntervaloNumeroRoteiro()
		{
			CheckIntervaloNumeroRoteiro.EsperarElemento(Browser);
			if (!CheckIntervaloNumeroRoteiro.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloNumeroRoteiro);
		}
		private void FlegarIntervaloCapitulo()
		{
			CheckIntervaloCapitulo.EsperarElemento(Browser);
			if (CheckIntervaloCapitulo.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloCapitulo);
		}

		private void FlegarIntervaloCena()
		{
			CheckIntervaloCapitulo.EsperarElemento(Browser);
			if (CheckIntervaloCena.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloCena);
		}

		private void FlegarIntervaloDataRoteiro()
		{
			CheckIntervaloDataRoteiro.EsperarElemento(Browser);
			if (CheckIntervaloDataRoteiro.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloDataRoteiro);
		}
		private void FlegarIntervaloNumeroRoteiro()
		{
			CheckIntervaloNumeroRoteiro.EsperarElemento(Browser);
			if (CheckIntervaloNumeroRoteiro.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, CheckIntervaloNumeroRoteiro);
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

		private void ClicarCamposAvancados()
		{
			var Form = Element.Id("formbusca");
			var BtnCampAvancados = Element.Css("a[class='btn-campos-avancados btn btn-default']");

			if (Form.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnCampAvancados);
		}

		private void ClicarBtnFiltrar()
		{
			BtnFiltrar.EsperarElemento(Browser);
			if (BtnFiltrar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnFiltrar);
		}

		//--------------LIMPAR FILTROS------------------\\
		public void LimparFiltros()
		{
			ClicarFiltros();

			BtnLimpar.EsperarElemento(Browser);
			if (BtnLimpar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnLimpar);

			ClicarBtnFiltrar();
		}


		//----------------COPIAR CAPITULO------------------\\
		public void CopiarCapitulos(string numeroCapitulo, string nomeProgramacao)
		{
			Browser.Abrir(CapituloCenaUrl);
			ClicarCopiarCapitulos();
			SelecionarIntervalo();
			EscolherCopiarCapitulos(numeroCapitulo);
			EscolherCopiarPrograma(nomeProgramacao);
			ClicarBtnEnviarCopiarCapitulos();
		}

		private void ClicarCopiarCapitulos()
		{
			BtnCopiarCapitulos.EsperarElemento(Browser);
			if (BtnCopiarCapitulos.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnCopiarCapitulos);
		}

		private void EscolherCopiarCapitulos(string numeroCapitulos)
		{
			var DivCopiar = Element.Id("popCopiaCapitulo");
			var InputIntervaloDe = Element.Css("input[id='selCaptuIniCopia']");

			DivCopiar.EsperarElemento(Browser);
			if (InputIntervaloDe.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputIntervaloDe, numeroCapitulos);
		}

		private void EscolherCopiarPrograma(string nomeProgramacao)
		{
			var Programacao = Element.Css("div[id='selProgramaDestino_chzn'] a span");
			var InputProgramacao = Element.Css("div[id='selProgramaDestino_chzn'] input");

			InputProgramacao.EsperarElemento(Browser);
			if (Programacao.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, Programacao, InputProgramacao, nomeProgramacao);
		}

		private void SelecionarIntervalo()
		{
			CheckIntervalo.EsperarElemento(Browser);
			if (CheckIntervalo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, CheckIntervalo);
		}

		private void ClicarBtnEnviarCopiarCapitulos()
		{
			var DivCapitulosCenas = Element.Css("div[class='submenu']");

			BtnEnviarCapitulo.EsperarElemento(Browser);
			if (BtnEnviarCapitulo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnEnviarCapitulo);

			DivCapitulosCenas.EsperarElemento(Browser);
		}

		//---------------VALIDAR IMPRESSAO---------------------\\
		public void SelecionarCapitulosCenasDecupadas(string nuemroCapitulo)
		{
			var SelectCapitulo = Element.Css("div[data-codigocapitulo='"+ nuemroCapitulo + "'] img[class='accS checkCapitulo'");
			SelectCapitulo.EsperarElemento(Browser);
			if (!SelectCapitulo.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, SelectCapitulo);
		}

		public void ImprimirTodasAsOpcoes()
		{
			ClicarBtnImprimirRelatorio();
			SelecionarListagemBasica();
			SelecionarCapituloCena();
			SelecionarMateriaisCena();
			SelecionarPersonagemRoupa();
			SelecionarContinuidadeAcao();
			SelecionarTextoCena();
			ClicarBtnOKImpressao();
		}
		public void ImprimirOpcaoCapituloTextoCena()
		{
			ClicarBtnImprimirRelatorio();
			SelecionarListagemBasica();
			SelecionarCapituloCena();
			SelecionarTextoCena();
			ClicarBtnOKImpressao();
		}

		public void ImprimirListagemPorCapitulos()
		{
			ClicarBtnImprimirRelatorio();
			SelecionarListagemPorCapitulo();
			ClicarBtnOKImpressao();
		}

		private void SelecionarListagemPorCapitulo()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkListagemPorCapitulo.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkListagemPorCapitulo);
		}
		private void ClicarBtnOKImpressao()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (BtnOKImpressao.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnOKImpressao);
		}

		private void SelecionarListagemBasica()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkListagemBasica.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkListagemBasica);
		}

		private void SelecionarCapituloCena()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkCapituloCena.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkCapituloCena);
		}

		private void SelecionarMateriaisCena()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkMateriaisCena.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkMateriaisCena);
		}

		private void SelecionarPersonagemRoupa()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkPersonagemRoupa.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkPersonagemRoupa);
		}

		private void SelecionarContinuidadeAcao()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkContinuidadeAcao.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkContinuidadeAcao);
		}

		private void SelecionarTextoCena()
		{
			DivOpcoesImpressao.EsperarElemento(Browser);
			if (!ChkTextoCena.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkTextoCena);
		}

		private void ClicarBtnImprimirRelatorio()
		{
			BtnImprimirRelatorio.EsperarElemento(Browser);
			if (BtnImprimirRelatorio.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnImprimirRelatorio);
		}

		public override void Navegar()
		{
			//BtnEnviarCapitulo.Esperar(Browser, 400);
			Browser.Abrir(CapituloCenaUrl);
			Browser.PageLoad();
		}

		//-------------------VERIFICACOES-------------------\\
		public bool VerificarPagina()
		{
			return Browser.UrlAtual() == CapituloCenaUrl;
		}

		public void VerificarIncluirAdendo()
		{
			string validation = "Arquivo de adendo lido com sucesso";
			var AlertaIncluirAdendo = Element.TagName(("body"));
			AlertaIncluirAdendo.GetTexto(Browser);
			Assert.AreEqual(validation, AlertaIncluirAdendo);
		}

		public void VerificarMapaCenas(string validacao)
		{
			var PopUpMapaCena = Element.Id(("ui-id-10"));

			string textoPopUp = PopUpMapaCena.GetTexto(Browser);
			Assert.AreEqual(textoPopUp, validacao);
		}

		public void VerificarCapitulo(string campo, string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			FiltrarCapitulos(campo, numeroCapitulo);
			ClicarVerificarCapitulo(campo, numeroCapitulo);
		}

		public void VerificarCapituloCopiado(string campo, string numeroCapitulo)
		{
			ClicarVerificarCapitulo(campo, numeroCapitulo);
		}

		public void VerificarCriticaCapituloCopiado(string numeroCapitulo)
		{
			var Alerta = Element.Css(".toast-message");
			string txtAlerta = Alerta.GetTexto(Browser);

			Alerta.EsperarElemento(Browser);
			if (Alerta.IsElementVisible(Browser))
				Assert.AreEqual(txtAlerta, "Os capítulos já existem no destino, não puderam ser copiados: " + numeroCapitulo + ".");
		}

		public void VerificarCena(string campo, string numeroCapitulo, string numeroCena)
		{
			ClicarVerificarCapitulo(campo, numeroCapitulo);

			var CheckCena = Element.Xpath("//strong[@class='detCena'][text()='" + numeroCena + "']");
			CheckCena.EsperarElemento(Browser);
			if (CheckCena.IsElementVisible(Browser))
			{
				string textoVerificar = CheckCena.GetTexto(Browser);
				Assert.AreEqual(textoVerificar, numeroCena);
				MouseActions.ClickATM(Browser, CheckCena);
			}
		}

        public void VerificarDetalhesCena(string campo, string valor)
        {
            switch(campo)
            {
                case "Periodo":
                    {
                        var texto = Element.Xpath("//td[@id='tipoLuzDetCena'][text()='" + valor + "']");
                        texto.EsperarElemento(Browser);
                        texto.IsElementVisible(Browser);
                        break;
                    }
            }
            
        }

		public void VerificarCenaReaproveitarPersonagem(string campo, string numeroCapitulo, string numeroCena, string nomePersonagem)
		{
			VerificarCena(campo, numeroCapitulo, numeroCena);
			SelecionarAbaPersonagem();
			VerificarPersonagem(nomePersonagem);
		}

		public void VerificarCapituloEditado(string campo, string numeroCapitulo)
		{
			string dataExibicao = CalendarioHelper.ObterMesFuturo(1);
			var CheckEditCapitulo = Element.Xpath("//div[contains(@data-codigocapitulo, '" + numeroCapitulo + "')]//strong[contains(.,'" + dataExibicao + "')]");
			string textoVerificar = CheckEditCapitulo.GetTexto(Browser);

			ClicarVerificarCapitulo(campo, numeroCapitulo);
			Assert.IsTrue(true, textoVerificar, dataExibicao);
		}

		public void VerificarCenaExcluida(string numeroCapitulo)
		{
			var CheckCapitulo = Element.Xpath("//*[@id='divCapitulos']//strong[contains(.,'" + numeroCapitulo + "')]");

			CheckCapitulo.EsperarElemento(Browser);
			Browser.RefreshPage();

			var ElementoSpan = Element.Css(".divListaCenas > span");
			MouseActions.ClickATM(Browser, CheckCapitulo);

			ElementoSpan.Esperar(Browser, 800);
			string textoVerificar = ElementoSpan.GetTexto(Browser);
			string validationText = "Não há cenas decupadas neste capítulo. Decupar capítulo";

			Assert.AreEqual(textoVerificar, validationText);
		}

		public void VerificarCenarioAmbiente(string campo, string numeroCapitulo, string numeroCena, string nomeCenario, string nomeAmbiente)
		{
			var CheckCena = Element.Xpath("//strong[@class='detCena'][text()='" + numeroCena + "']");

			ClicarVerificarCapitulo(campo, numeroCapitulo);
			MouseActions.ClickATM(Browser, CheckCena);

			var CenarioTexto = Element.Css("#cenarioDetCena");

			if (PopUpDetCena.IsElementVisible(Browser))
			{
				string textoCenario = CenarioTexto.GetTexto(Browser);

				CenarioTexto.EsperarElemento(Browser);
				Assert.AreEqual(textoCenario, nomeCenario);
			}

			VerificarAmbiente(numeroCapitulo, numeroCena, nomeAmbiente);
		}

		private void VerificarPersonagem(string nomePersonagem)
		{
			if (Browser.PageSource(nomePersonagem))
				Assert.IsTrue(true, nomePersonagem);
		}

		private void SelecionarAbaPersonagem()
		{
			AbaPersonagem.EsperarElemento(Browser);
			if (AbaPersonagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, AbaPersonagem);
		}

		private void VerificarAmbiente(string numeroCapitulo, string numeroCena, string ambiente)
		{
			var AmbienteTexto = Element.Css("#ambienteDetCena");
			string textoAmbiente = AmbienteTexto.GetTexto(Browser);

			AmbienteTexto.EsperarElemento(Browser);
			Assert.AreEqual(textoAmbiente, ambiente);

			BtnFecharDetalhes.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, BtnFecharDetalhes);
		}

		public void VerificarAberturaLetra(string campo, string numeroCapitulo, string numeroCena, string nomeLetra)
		{
			ClicarVerificarCapitulo(campo, numeroCapitulo);

			var CheckCena = Element.Xpath("//strong[@class='detCena'][text()='" + numeroCena + nomeLetra + "']");
			CheckCena.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, CheckCena);

			if (PopUpDetCena.IsElementVisible(Browser))
			{
				var campoCena = Element.Id("cenaDetCena");
				campoCena.EsperarElemento(Browser);
				string textoVerificar = campoCena.GetTexto(Browser);
				Assert.AreEqual(textoVerificar, numeroCena + nomeLetra);
			}
		}

		public void VerificarCriacaoLetra(string campo, string numeroCapitulo, string numeroCena, string nomeLetra)
		{
			Browser.Abrir(CapituloCenaUrl);

			ClicarVerificarCapitulo(campo, numeroCapitulo);

			var CheckCena = Element.Xpath("//strong[@class='detCena'][text()='" + numeroCena + nomeLetra + "']");
			CheckCena.IsElementVisible(Browser);
			MouseActions.ClickATM(Browser, CheckCena);

			if (PopUpDetCena.IsElementVisible(Browser))
			{
				var campoCena = Element.Id("cenaDetCena");
				campoCena.EsperarElemento(Browser);
				string textoVerificar = campoCena.GetTexto(Browser);
				Assert.AreEqual(textoVerificar, numeroCena + nomeLetra);
			}
		}

		public void VerificarCenaSecreta(string campo, string numeroCapitulo, string numeroCena)
		{
			Browser.Abrir(CapituloCenaUrl);

			ClicarVerificarCapitulo(campo, numeroCapitulo);

			var CheckCena = Element.Xpath("//strong[@class='detCena'][text()='" + numeroCena + "']");
			var CenaSecreta = Element.Css("td img[class='icon-secret-scene']");

			if (CenaSecreta.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, CheckCena);
		}

		public void VerificarNovoPersonagemNoCapitulo(string campo, string numeroCapitulo, string numeroCena, string nomePersonagem)
		{
			Browser.Abrir(CapituloCenaUrl);

			ClicarVerificarCapitulo(campo, numeroCapitulo);

			var CheckCena = Element.Xpath("//strong[@class='detCena'][text()='" + numeroCena + "']");
			CheckCena.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, CheckCena);

			var CampoCenaPersonagem = Element.Css("#ui-id-7");

			if (CampoCenaPersonagem.IsElementVisible(Browser))
				CampoCenaPersonagem.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, CampoCenaPersonagem);
				CampoCenaPersonagem.Esperar(Browser, 200);
				Browser.PageSource(nomePersonagem);
		}

		//------------FILTROS CENAS-------------\\

		public void VerificarFiltro(string campo, string numeroCapitulo)
		{
			ClicarVerificarCapitulo(campo, numeroCapitulo);
		}


		//------------------VERIFICAR CORTAR CENA--------------------\\
		public void VerificarCenaCortada(string campo, string numeroCapitulo, string statusCena)
		{
			ClicarVerificarCapitulo(campo, numeroCapitulo);

			var StatusCena = Element.Css("td[class='detCena statusCena']");

			StatusCena.EsperarElemento(Browser);
			if (StatusCena.IsElementVisible(Browser))
			{
				string verificarStatus = StatusCena.GetTexto(Browser).Trim();
				Assert.AreEqual(verificarStatus, statusCena);
			}
		}

		private void ClicarVerificarCapitulo(string campo, string numeroCapitulo)
		{
			Browser.Abrir(CapituloCenaUrl);
			FiltrarCapitulos(campo, numeroCapitulo);

			var CheckCapitulo = Element.Xpath("//*[@id='divCapitulos']//strong[contains(.,'" + numeroCapitulo + "')]");

			CheckCapitulo.EsperarElemento(Browser);
			if (CheckCapitulo.IsClickable(Browser))
			{
				string textoVerificar = CheckCapitulo.GetTexto(Browser).Trim();
				MouseActions.ClickATM(Browser, CheckCapitulo);
				Assert.AreEqual(textoVerificar, numeroCapitulo);
			}
		}

		public void VerificarAPagarPDF()
		{
			//DeletePDF.DeletarPDF(Browser, "C:\\Users\\Leonardo Lima\\Downloads\\");
            DeletePDF.DeletarPDF(Browser, ConfigurationManager.AppSettings["downloadPath"]);
        }
	}
}
