using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Threading;

namespace Project.SGP.Pages
{
	public class DecupagemContinuidadePage : PageBase
	{
		private string DecupagemContinuidadeUrl { get; }

		//Button
		private Element BtnSalvarContinuidade { get; }
		private Element BtnIncluirPersonagem { get; }
		private Element BtnIncluirPersonagemSelecionado { get; }
		private Element BtnReaproveitarRoupa { get; }
		private Element BtnFiltrarRoupa { get; }
		private Element BtnExcluirPersonagem { get; }
		private Element BtnExcluirPersonagemSelecionado { get; }
		private Element BtnAbrirLetra { get; }
		private Element BtnSIMAbrirLetra { get; }
		private Element BtnSalvarDecupagemContinuidade { get; }
		private Element BtnConsultarRoupa { get; }
		private Element BtnImprimirPDF { get; }

		//Input
		private Element InputCapitulo { get; }
		private Element InputHoraCenica { get; }
		private Element InputDiaCenico { get; }
		private Element InputSequencia { get; }
		private Element InputObsContinuidade { get; }
		private Element InputObsGeral { get; }
		private Element InputObsContArte { get; }
		private Element InputNumeroRoupa { get; }
		private Element InputNumeroBloco { get; }
		private Element InputSituacao { get; }
		private Element InputCaracterizacao { get; }
		private Element InputDescricaoPlanejada { get; }
		private Element InputPersonagemDisponiveis { get; }
		private Element InputCapituloDe { get; }
		private Element InputCapituloAte { get; }
		private Element InputListCenaDecupagem { get; }

		//Others
		private Element DropListCapitulo { get; }
		private Element DropListCena { get; }
		private Element DropListPersonagemDisponiveis { get; }
		private Element ChkReaproveitarRoupa { get; }
		private Element PopUpAbrirLetraMensagem { get; }
		private Element DropListCenaDecupagemBasica { get; }
		private Element ChkVisualizarTexto { get; }

        //-------------------------GROT-------------------------------//
        private Element InputTempoPreparacaoCaracterizacao { get; }


        public DecupagemContinuidadePage(IBrowser browser,
			string decupagemContinuidadeUrl) : base(browser)
		{
			DecupagemContinuidadeUrl = decupagemContinuidadeUrl;

			//Button
			BtnSalvarContinuidade = Element.Id("btSalvar");
			BtnIncluirPersonagem = Element.Css("#incluirPersonagem");
			BtnIncluirPersonagemSelecionado = Element.Css("input[value='Incluir Selecionados']");
			BtnReaproveitarRoupa = Element.Link("Reaproveitar Roupa");
			BtnFiltrarRoupa = Element.Id("btnFiltrar");
			BtnExcluirPersonagem = Element.Id("excluirPersonagem");
			BtnExcluirPersonagemSelecionado = Element.Css("input[value='Excluir Selecionados']");
			BtnAbrirLetra = Element.Link("Abrir Letra");
			BtnSIMAbrirLetra = Element.Xpath("//button[@id='btnOk']//span[text()='Sim']");
			BtnSalvarDecupagemContinuidade = Element.Id("btnSaveAndReturn");
			BtnConsultarRoupa = Element.Css("input[value='Consultar Roupa']");
			BtnImprimirPDF = Element.Id("bt-imprimir");

			//Input
			InputCapitulo = Element.Css("#jumpMenu_chzn input");
			InputHoraCenica = Element.Nome("horaCenica");
			InputDiaCenico = Element.Nome("diaCenico");
			InputSequencia = Element.Nome("sequencia");
			InputObsContinuidade = Element.Css("textarea[name='obsContinuidade']");
			InputObsGeral = Element.Css("textarea[name='obsGeral']");
			InputObsContArte = Element.Css("textarea[name='obsContinuidadeArte']");
			InputNumeroRoupa = Element.Nome("numeroRoupa");
			InputNumeroBloco = Element.Nome("bloco");
			InputSituacao = Element.Nome("situacaoRoupa");
			InputCaracterizacao = Element.Nome("caracterizacao");
			InputDescricaoPlanejada = Element.Nome("descricaoRoupa");
			InputPersonagemDisponiveis = Element.Css("input[id='s2id_autogen1']");
			InputCapituloDe = Element.Id("filtroCapituloDe");
			InputCapituloAte = Element.Id("filtroCapituloAte");
			InputListCenaDecupagem = Element.Css("#selectAllCenas_chosen input");

			//Others
			DropListCapitulo = Element.Id("jumpMenu_chzn");
			DropListCena = Element.Id("cenaSelecionada");
			DropListPersonagemDisponiveis = Element.Css(".select2-choices");
			ChkReaproveitarRoupa = Element.Class("tstCheckRoupaRaproveitar");
			PopUpAbrirLetraMensagem = Element.Id("dlgAbrirLetra");
			DropListCenaDecupagemBasica = Element.Css("#selectAllCenas_chosen a span");
			ChkVisualizarTexto = Element.Id("trocar-visualizacao");

            //-------------------------GROT-------------------------------//
            InputTempoPreparacaoCaracterizacao = Element.Css("input[id='tempoPreparacao']");
		}


		//-------------------METODOS-------------------\\
		//-------------------CRIAR DECUPAGEM CONTINUIDADE-------------------\\
		public void CriarDecupagemContinuidade(string numeroCapitulo, string numeroCena, string horaCenica, string tempoCaracterizacao)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
			PreencherDadosGeraisCenaContinuidade(horaCenica);
			PreencherDadosPersonagemContinuidade(numeroCapitulo, tempoCaracterizacao);
			ClicarBtnSalvarContinuidade();
		}

		public void ClicarBtnSalvarContinuidade()
		{
			BtnSalvarContinuidade.EsperarElemento(Browser);
			BtnSalvarContinuidade.Esperar(Browser, 1000);
			if (BtnSalvarContinuidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarContinuidade);
			}
		}

		private void SelecionarCapitulo(string numeroCapitulo)
		{
			DropListCapitulo.EsperarElemento(Browser);
			if (DropListCapitulo.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListCapitulo, InputCapitulo, numeroCapitulo);
		}

		private void SelecionarCena(string numeroCena)
		{
			DropListCena.EsperarElemento(Browser);
			if (DropListCena.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, DropListCena);

			SelectCena(numeroCena);
		}

		private void PreencherDadosGeraisCenaContinuidade(string horaCenica)
		{
			InputHoraCenica.EsperarElemento(Browser);
			if (InputHoraCenica.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputHoraCenica, horaCenica);
			AutomatedActions.SendDataATM(Browser, InputDiaCenico, FakeHelpers.RandomNumber().ToString());
			AutomatedActions.SendDataATM(Browser, InputSequencia, FakeHelpers.FirstName());
			AutomatedActions.SendDataATM(Browser, InputObsContinuidade, FakeHelpers.FullName());
			AutomatedActions.SendDataATM(Browser, InputObsGeral, FakeHelpers.FullName());
			AutomatedActions.SendDataATM(Browser, InputObsContArte, FakeHelpers.FullName());
		}

		private void PreencherDadosPersonagemContinuidade(string numeroRoupa, string tempoCaracterizacao)
		{
			if (InputNumeroRoupa.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNumeroRoupa, numeroRoupa);
			InputNumeroBloco.Esperar(Browser, 1000);
            InputNumeroBloco.EsperarElemento(Browser);
            KeyboardActions.Backspace(Browser, InputNumeroBloco);
            AutomatedActions.SendDataATM(Browser, InputNumeroBloco, "1");
			AutomatedActions.SendDataATM(Browser, InputSituacao, FakeHelpers.FullName());
			AutomatedActions.SendDataATM(Browser, InputCaracterizacao, tempoCaracterizacao);
			AutomatedActions.SendDataATM(Browser, InputDescricaoPlanejada, FakeHelpers.FullName());
		}

		private void SelectCena(string numeroCena)
		{
			var Select = Element.Xpath("//div[@id='dropMenuCena']//li[text()='" + numeroCena + "']");

			Select.EsperarElemento(Browser);
			if (Select.IsElementVisible(Browser))
				Select.IsClickable(Browser);
			MouseActions.ClickATM(Browser, Select);
		}


		//-------------------INCLUIR PERSONAGEM-------------------\\
		public void IncluirPersonagem(string nomePersonagem)
		{
			ClicarBtnIncluirPersonagem();
			SelecionarPersonagem(nomePersonagem);
			ClicarBtnPersonagemSelecionado();
			ClicarBtnSalvarContinuidade();
		}

		private void ClicarBtnIncluirPersonagem()
		{
			ClicarBtnSalvarContinuidade();

			BtnIncluirPersonagem.Esperar(Browser, 3000);
			BtnIncluirPersonagem.EsperarElemento(Browser);
			if (BtnIncluirPersonagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnIncluirPersonagem);
		}

		private void SelecionarPersonagem(string nomePersonagem)
		{
			DropListPersonagemDisponiveis.Esperar(Browser, 1000);
			DropListPersonagemDisponiveis.EsperarElemento(Browser);
			if (DropListPersonagemDisponiveis.IsElementVisible(Browser))
				DropListPersonagemDisponiveis.IsClickable(Browser);
			AutomatedActions.TypingListATM(Browser, DropListPersonagemDisponiveis, InputPersonagemDisponiveis, nomePersonagem);
		}

		private void ClicarBtnPersonagemSelecionado()
		{
			BtnIncluirPersonagemSelecionado.EsperarElemento(Browser);
			if (BtnIncluirPersonagemSelecionado.IsElementVisible(Browser))
				BtnIncluirPersonagemSelecionado.IsClickable(Browser);
			MouseActions.ClickATM(Browser, BtnIncluirPersonagemSelecionado);
		}


		//-------------------REAPROVEITAR ROUPA-------------------\\
		public void ReaproveitarRoupa(string numeroCena, string numeroCapitulo)
		{
			SelecionarCena(numeroCena);
			ClicarBtnReaproveitarRoupa();
			FiltrarReaproveitarRoupa(numeroCapitulo);
			ClicarBtnFiltrar();
			SelecionarRoupa();
			ClicarBtnReaproveitarRoupaJS();
			ClicarBtnSalvarContinuidade();
		}

		private void ClicarBtnReaproveitarRoupa()
		{
			BtnReaproveitarRoupa.EsperarElemento(Browser);
			if (BtnReaproveitarRoupa.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnReaproveitarRoupa);
		}

		private void FiltrarReaproveitarRoupa(string numeroCapitulo)
		{
			InputCapituloAte.EsperarElemento(Browser);
			if (InputCapituloDe.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputCapituloDe, numeroCapitulo);
			AutomatedActions.SendDataATM(Browser, InputCapituloAte, numeroCapitulo);
		}

		private void ClicarBtnFiltrar()
		{
			BtnFiltrarRoupa.EsperarElemento(Browser);
			if (BtnFiltrarRoupa.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnFiltrarRoupa);
		}

		private void SelecionarRoupa()
		{
			ChkReaproveitarRoupa.EsperarElemento(Browser);
			if (!ChkReaproveitarRoupa.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkReaproveitarRoupa);
		}

		private void ClicarBtnReaproveitarRoupaJS()
		{
			JsActions.JavaScript(Browser, "$('.ui-dialog-buttonset button span:contains(Reaproveitar)').click();");
		}

		//-------------------EXCLUIR PERSONAGEMA-------------------\\
		public void ExcluirPersonagemReaproveitado(string numeroCena, string nomePersonagem)
		{
			SelecionarCena(numeroCena);
			ClicarBtnExcluirPersonagem();
			SelecionarExcluirPersonagem(nomePersonagem);
			ClicarBtnExcluirPersonagemSelecionado();
			ClicarBtnSalvarContinuidade();
		}

		private void ClicarBtnExcluirPersonagem()
		{
			BtnExcluirPersonagem.EsperarElemento(Browser);
			if (BtnExcluirPersonagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnExcluirPersonagem);
		}

		private void SelecionarExcluirPersonagem(string nomePersonagem)
		{
			var select = Element.Id("s2id_buscaPersonagensExclusao");
			var Input = Element.Css("#s2id_buscaPersonagensExclusao input");

			select.EsperarElemento(Browser);
			if (select.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, select, Input, nomePersonagem);
		}

		private void ClicarBtnExcluirPersonagemSelecionado()
		{
			BtnExcluirPersonagemSelecionado.EsperarElemento(Browser);
			if (BtnExcluirPersonagemSelecionado.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnExcluirPersonagemSelecionado);
		}

		//-------------------ABRIR LETRA-------------------\\
		public void AbrirLetra(string numeroCapitulo, string numeroCena)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
			ClicarBtnAbrirLetra();
			PopUpAbrirLetra();
		}

		public void SalvarDecupagemContinuidadeComLetra(string numeroCena)
		{
			EscolherCena(numeroCena);
			ClicarBtnSalvarDecupagemContinuidade();
		}

		public void PreencherDecupagemContinuidade()
		{

		}

		private void EscolherCena(string numeroCena)
		{
			DropListCenaDecupagemBasica.EsperarElemento(Browser);
			if (DropListCenaDecupagemBasica.IsElementVisible(Browser))
				DropListCenaDecupagemBasica.IsClickable(Browser);
			AutomatedActions.TypingListATM(Browser, DropListCenaDecupagemBasica, InputListCenaDecupagem, numeroCena);
		}


		private void ClicarBtnSalvarDecupagemContinuidade()
		{
			BtnSalvarDecupagemContinuidade.EsperarElemento(Browser);
			if (BtnSalvarDecupagemContinuidade.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarDecupagemContinuidade);
		}
		private void ClicarBtnAbrirLetra()
		{
			BtnAbrirLetra.EsperarElemento(Browser);
			if (BtnAbrirLetra.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnAbrirLetra);
		}

		private void PopUpAbrirLetra()
		{
			PopUpAbrirLetraMensagem.EsperarElemento(Browser);
			if (PopUpAbrirLetraMensagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSIMAbrirLetra);
		}

		//-------------------MARCAR A MAO LIVRE-------------------\\
		public void MarcarMaoLivre(string numeroCapitulo, string numeroCena, string horaCenica, string tempoCaracterizacao)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
			SelecionarVisualizacaoTexto();
			EditarTexto(numeroCena);
		}

		private void SelecionarVisualizacaoTexto()
		{
			ChkVisualizarTexto.EsperarElemento(Browser);
			if (!ChkVisualizarTexto.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkVisualizarTexto);
		}

		private void EditarTexto(string numeroCena)
		{
			var LapisEditar = Element.Css("#cena-" + numeroCena + " .toggle-desenho");

			LapisEditar.EsperarElemento(Browser);
			if (LapisEditar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, LapisEditar);
		}

		//-------------------CONSULTAR ROUPA-------------------\\
		public void ConsultarRoupa(string numeroCapitulo, string numeroCena)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
			SelecionarUsarRoupa();
			ClicarBtnConsultarRoupa();
		}

		private void SelecionarUsarRoupa()
		{
			var BtnUsarRoupa = Element.Css("tr.odd a.usar-roupa");

			BtnUsarRoupa.EsperarElemento(Browser);
			if (BtnUsarRoupa.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnUsarRoupa);
		}

		private void ClicarBtnConsultarRoupa()
		{
			BtnConsultarRoupa.EsperarElemento(Browser);
			if (BtnConsultarRoupa.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnConsultarRoupa);
		}

		//-------------------REALIZAR IMPRESSAO PDF-------------------\\
		public void RealizarImpressaoPDF(string numeroCapitulo, string numeroCena)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
			SelecionarVisualizacaoTexto();
			ClicarBtnImprimirPDF();
			ImprimirPDF();
		}

		private void ClicarBtnImprimirPDF()
		{
			BtnImprimirPDF.EsperarElemento(Browser);
			if (BtnImprimirPDF.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnImprimirPDF);
		}

		private void ImprimirPDF()
		{
			var BtnImprimir = Element.Css("#botoes-impressao a.bt-imprimir");

			BtnImprimir.Esperar(Browser, 1000);
			if (BtnImprimir.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnImprimir);

			BtnImprimir.Esperar(Browser, 4000);
		}

		public override void Navegar()
		{
			Browser.Abrir(DecupagemContinuidadeUrl);
			Browser.PageLoad();
		}


		//-------------------VERIFICACOES-------------------\\
		public void VerificarAlertaAdendoDecupagemContinuidade()
		{
			string validation = "Houve uma atualização do texto feito na decupagem básica. Considere atualizar o texto através do botão atualizar";
			var AlertaIncluirAdendo = Element.TagName(("body"));

			Browser.Abrir(DecupagemContinuidadeUrl);
			AlertaIncluirAdendo.GetTexto(Browser);
			Assert.AreEqual(validation, AlertaIncluirAdendo);
		}

		public void VerificarMensagemDecupagemContinuidade(string mensagem)
		{
			var AlertaMensagem = Element.Css(".toast-message");

			AlertaMensagem.EsperarElemento(Browser);
			string validation = AlertaMensagem.GetTexto(Browser).Trim();

			Assert.AreEqual(validation, mensagem);
		}

		public void VerificarPersonagemIncluidoDecupagemContinuidade(string nomePersonagem)
		{
			var PersonagemIncluido = Element.Xpath("//table[@class='grid gridPersonagens']//tr[@id='1']//td[text()='"+nomePersonagem+"']");

			ClicarBtnSalvarContinuidade();
			PersonagemIncluido.EsperarElemento(Browser);
			PersonagemIncluido.IsElementVisible(Browser);
		}
		public void VerificarRoupaReaproveitada()
		{
			var RoupaPersonagem = Element.Css("td[class='left tstSelectPersonagem'] div");
			RoupaPersonagem.EsperarElemento(Browser);
			if (RoupaPersonagem.IsElementVisible(Browser))
			{
				string validation = RoupaPersonagem.GetTexto(Browser).Trim();
				Assert.IsTrue(true, validation);
			}
		}

		public void VerificarPersonagemExcluido()
		{
			//Legenda: 0, 1, 2, 3 - Na ordem do tr
			var ExclusaoPersonagem = Element.Css("#1");

			ExclusaoPersonagem.IsNotElementVisible(Browser);
		}

		public void VerificarConsultaRoupa(string consultaRoupa)
		{
			var ConsultaRoupa = Element.Xpath("//h3[@class='tstTopoCenaConsulta'][contains(.,'" + consultaRoupa + "')]");

			ConsultaRoupa.EsperarElemento(Browser);
			string textoElemento = ConsultaRoupa.GetTexto(Browser).Trim();
			Assert.AreEqual(textoElemento, consultaRoupa);
		}

		public void VerificarImpressaoApagarPDF()
		{
			DeletePDF.DeletarPDF(Browser, "C:\\Users\\Rodrigo2\\Downloads\\");
		}


        //--------------------------------------GROT---------------------------------------//
        public void AcessarDecupagemDeContinuidade()
        {
            var dropdownCapitulo = Element.Css("div[class=' form accordion divCapitulo expandirCenas']");
            var editarPath = Element.Css("span[class='editSc redirDecup icon-button icon-edit-2']");
            var linkDecupagemContinuidade = Element.Xpath("//div[@class='cenaAdiv']//a[text()='Decupagem de Continuidade']");

            dropdownCapitulo.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, dropdownCapitulo);
            editarPath.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, editarPath);
            linkDecupagemContinuidade.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, linkDecupagemContinuidade);
        }

        public void CriarDecupagemContinuidadeGROT(string numeroCapitulo, string numeroCena, string horaCenica, string tempoCaracterizacao, string TempoPreparacao)
        {
            SelecionarCapitulo(numeroCapitulo);
            SelecionarCena(numeroCena);
            if(horaCenica != "")
            {
                PreencherDadosGeraisCenaContinuidade(horaCenica);
            }
            PreencherDadosPersonagemContinuidadeGROT(numeroCapitulo, tempoCaracterizacao, TempoPreparacao);
        }
        
        public void PreencherDadosPersonagemContinuidadeGROT(string numeroRoupa, string tempoCaracterizacao, string TempoPreparacao)
        {
            if(numeroRoupa != "")
            {
                if (InputNumeroRoupa.IsElementVisible(Browser))
                    AutomatedActions.SendDataATM(Browser, InputNumeroRoupa, numeroRoupa);
                InputNumeroBloco.Esperar(Browser, 1000);
                AutomatedActions.SendDataATM(Browser, InputNumeroBloco, "1");
                AutomatedActions.SendDataATM(Browser, InputSituacao, FakeHelpers.FullName());
            }
            if(tempoCaracterizacao != "")
            {
                AutomatedActions.SendDataATM(Browser, InputCaracterizacao, tempoCaracterizacao);
                AutomatedActions.SendDataATM(Browser, InputDescricaoPlanejada, FakeHelpers.FullName());
            }
            if(TempoPreparacao != "")
            {
                AutomatedActions.SendDataATM(Browser, InputTempoPreparacaoCaracterizacao, TempoPreparacao);
            }
        }

        public void ValidacaoSemGrot()
        {
            var paginaPath = Element.Xpath("//div[@class='div1'][contains(., 'Decupagem de Continuidade')]");
            paginaPath.EsperarElemento(Browser);

            var tempoPreparacao = Element.Xpath("//label[text()='Tempo preparação figurino/caracterização (min']");
            tempoPreparacao.IsNotElementVisible(Browser);
        }

    }
}
