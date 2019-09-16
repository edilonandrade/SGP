
using System;
using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Project.SGP.Pages
{
	public class CenarioPage : PageBase
	{
		private string CenarioUrl { get; }

		//Button
		private Element BtnNovoCenario { get; }
		private Element DivNovoCenario { get; }
		private Element InputNomeCenario { get; }
		private Element BtnSalvarCenario { get; }
		private Element BtnSalvarAndCriarNovoCenario { get; }
		private Element InputPDSCenario { get; }
		private Element BtnOK { get; }
		private Element BtnFiltrar { get; }
		private Element BtnSalvarMateriais { get; }
		private Element BtnSalvarMateriaisFixos { get; }

		//Input
		private Element LinkNovoAmbiente { get; }
		private Element InputNomeAmbiente { get; }
		private Element InputCenario { get; }
		private Element InputAmbiente { get; }
		private Element InputTipo { get; }
        private Element InputViagem { get; }
        private Element InputGrupoLocalGravacao { get; }

        //Link
        private Element FiltrarCenarios { get; }

		//Others
		private Element TelaFiltrar { get; }
		private Element SelectCenario { get; }
		private Element SelectAmbiente { get; }
		private Element SelectPorTipo { get; }
        private Element SlctGrupoLocalGravacao { get; }
        private Element SlctPorViagem { get; }
        private Element IFrameDescricao { get; }

        //------------------------------------------------GROT-----------------------------------------------------\\
        //Button
        private Element BtnNovoLocal { get; }
        private Element BtnNovaRegiao { get; }
        private Element BtnSalvarNovaRegiao { get; }
        private Element BtnSalvarNovoLocal { get; }

        //Input
        private Element InputNomeLocal { get; }
        private Element InputViagemGROT { get; }
        private Element InputNomeRegiao { get; }

        public CenarioPage(IBrowser browser,
		   string cenarioUrl) : base(browser)
		{
			CenarioUrl = cenarioUrl;

			//Button
			BtnNovoCenario = Element.Id("NovoCenario");
			DivNovoCenario = Element.Id("radioCenario");
			InputNomeCenario = Element.Css("input[id='nome']");
			BtnSalvarCenario = Element.Css("button[data-bb-handler='b1']");
			BtnSalvarAndCriarNovoCenario = Element.Css("button[data-bb-handler='b2']");
			InputPDSCenario = Element.Id("nomeNucleoPDS");
			BtnSalvarMateriais = Element.Id("tstSalvarMaterialFixo");
			BtnFiltrar = Element.Css("#filtrarbtn");
			BtnOK = Element.Xpath("//button[@data-bb-handler='b1'][text()='Ok']");
			BtnSalvarMateriaisFixos = Element.Css("#tstSalvarMaterialFixo");

			//Link
			LinkNovoAmbiente = Element.Css("a[class='adicionaAmbiente']");
			InputNomeAmbiente = Element.Css("input[name='nomeDoAmbiente']");
			FiltrarCenarios = Element.Css("label[class='filter-text']");

			//Input
			InputCenario = Element.Css("div[id='cenariofiltro_chosen'] input[value='Digite para selecionar...']");
			InputAmbiente = Element.Css("#ambientefiltro_chosen input");
			InputTipo = Element.Css("#selectTipo_chosen input");
            InputViagem = Element.Css("#viagemfiltro_chosen input");
            InputGrupoLocalGravacao = Element.Css("#grupoLocalGravacao_chosen input");

			//Others
			TelaFiltrar = Element.Css(".col-xs-12");
			SelectCenario = Element.Css("#cenariofiltro_chosen ul li");
			SelectAmbiente = Element.Css("#ambientefiltro_chosen");
			SelectPorTipo = Element.Css("#selectTipo_chosen span");
            SlctPorViagem = Element.Css("#viagemfiltro_chosen span");
            SlctGrupoLocalGravacao = Element.Css("#grupoLocalGravacao_chosen span");
			IFrameDescricao = Element.Css("iframe[name='tstmaterial0']");

            //------------------------------------------------GROT-----------------------------------------------------\\
            //Button
            BtnNovoLocal = Element.Css("button[id='NovoLocalGravacao']");
            BtnNovaRegiao = Element.Css("button[id='NovoGrupoLocalGravacao']");
            BtnSalvarNovaRegiao = Element.Css("button[class='btn btn btn-default salvarGrupoLocalGravacao']");
            BtnSalvarNovoLocal = Element.Css("button[class='btn btn btn-default salvarLocalGravacao']");

            //Input
            InputNomeLocal = Element.Css("input[id='Endereco']");
            InputViagemGROT = Element.Css("input[id='Viagem']");
            InputNomeRegiao = Element.Css("input[id='Nome']");
        }


        //-------------------METODOS-------------------\\
        public void ExcluirCenario(string nomeCenario)
		{
			BtnFiltrar.Esperar(Browser, 500);
			Browser.Abrir(CenarioUrl);

			TelaFiltrar.Esperar(Browser, 1000);
			ClicarBuscarFiltrosCenario();

			if (TelaFiltrar.IsElementVisible(Browser))
			{
				EscolherCenario(nomeCenario);
				ClicarFiltrarCenario();
				ApagarCenario();
			}

			AlertaExclusao();
		}

		public void ExcluirAmbiente(string nomeCenario)
		{
			Browser.Abrir(CenarioUrl);
			ClicarBuscarFiltrosCenario();

			if (TelaFiltrar.IsElementVisible(Browser))
			{
				EscolherCenario(nomeCenario);
				ClicarFiltrarCenario();
				ExibirAmbientes();
				ApagarAmbiente();
				ExcluirAmbientePopUp();
			}

			AlertaExclusao();
		}

		public void ExcluirCenarioEditado(string nomeCenario)
		{
			Browser.Abrir(CenarioUrl);
			ClicarBuscarFiltrosCenario();

			if (TelaFiltrar.IsElementVisible(Browser))
			{
				EscolherCenario(nomeCenario);
				ClicarFiltrarCenario();
				ApagarCenario();
			}

			AlertaExclusao();
		}

		public void AlertaExclusao()
		{
			var Alerta = Element.Css("div[class='alert alert-success alert-dismissable alert-util alert-fixed']");
			string AlertaStg = Alerta.GetTexto(Browser);
			Alerta.EsperarElemento(Browser);
			if (Alerta.IsElementVisible(Browser))
			{
				Assert.IsTrue(true, AlertaStg);
			}
		}

		public void CriarNovoCenario(string tipoCenario, string nomeCenario)
		{
			Browser.Abrir(CenarioUrl);
			ClicarNovoCenario();
			SelecionarTipoCenario(tipoCenario);
			PreencherNovoCenario(nomeCenario);
		}

        public void CriarNovoCenarioGROT(string tipoCenario, string nomeCenario, string nomeLocal, string nomeViagem, string nomeRegiao)
        {
            ClicarNovoCenarioGROT();
            SelecionarTipoCenario(tipoCenario);
            PreencherNovoCenario(nomeCenario);
            CriarNovoLocal(nomeLocal, nomeViagem, nomeRegiao);
            SalvarNovoCenario();
        }

        private void ClicarNovoCenarioGROT()
        {
            BtnNovoCenario.EsperarElemento(Browser);
            BtnNovoCenario.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovoCenario);
        }

        private void CriarNovoLocal(string nomeLocal, string nomeViagem, string nomeRegiao)
        {
            BtnNovoLocal.EsperarElemento(Browser);
            BtnNovoLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovoLocal);

            InputNomeLocal.EsperarElemento(Browser);
            InputNomeLocal.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputNomeLocal, nomeLocal);

            InputViagemGROT.EsperarElemento(Browser);
            InputViagemGROT.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputViagemGROT, nomeViagem);

            if(nomeRegiao != "")
            {
                IncluirNovaRegiao(nomeRegiao);
            }

            BtnSalvarNovoLocal.EsperarElemento(Browser);
            BtnSalvarNovoLocal.Esperar(Browser, 2000);
            BtnSalvarNovoLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarNovoLocal);
            VerificarInclusaoLocal("Inserido com sucesso");
        }

        private void IncluirNovaRegiao(string nomeRegiao)
        {
            BtnNovaRegiao.EsperarElemento(Browser);
            BtnNovaRegiao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovaRegiao);

            InputNomeRegiao.EsperarElemento(Browser);
            InputNomeRegiao.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputNomeRegiao, nomeRegiao);

            BtnSalvarNovaRegiao.EsperarElemento(Browser);
            BtnSalvarNovaRegiao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarNovaRegiao);

            VerificarInclusaoRegiao("Inserido com sucesso");
        }

        public void CriarOutroCenario(string tipoCenario, string nomeCenario)
		{
			SalvarAndCriarNovoCenario();
			SelecionarTipoCenario(tipoCenario);
			PreencherNovoCenario(nomeCenario);
		}

		public void CriarMaterialFixoCenario(string nomeCenario)
		{
			ClicarBuscarFiltrosCenario();
			EscolherCenario(nomeCenario);
			ClicarFiltrarCenario();
			ClicarEditarMaterialFixo();
		}

		public void SalvarMateriaisFixos()
		{
			var IFrame = Element.Css("iframe[src]");
			IFrame.EsperarIFrame(Browser);
			BtnSalvarMateriaisFixos.EsperarElemento(Browser);
			if (BtnSalvarMateriaisFixos.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarMateriaisFixos);
		}

		public void CriarNovoAmbiente(string nomeAmbiente)
		{
			ClicarNovoAmbiente();
			PreencherNovoAmbiente(nomeAmbiente);
		}

		public void EditarCenario(string tipoCenario, string editarCenario)
		{
			ClicarBtnEditarCenario();
			EditarNovoCenario(tipoCenario, editarCenario);
		}

        public void EditarCenarioGROT(string regiao)
        {
            ClicarBtnEditarCenario();
            EditarNovoCenarioGROTRegiao(regiao);
        }

        public void EditarAmbiente(string editarAmbiente)
		{
			ClicarBtnEditarCenario();
			BrowserHelpers.EliminarAlertasChrome(Browser);
			EditarNovoAmbiente(editarAmbiente);
		}

		public void FiltrarCenario(string nomeCenario)
		{
			ClicarBuscarFiltrosCenario();
			EscolherCenario(nomeCenario);
			ClicarFiltrarCenario();
		}

		public void FiltrarDoisCenarios(string primeiroCenario, string segundoCenario)
		{
			ClicarBuscarFiltrosCenario();
			EscolherCenario(primeiroCenario);
			EscolherCenario(segundoCenario);
			ClicarFiltrarCenario();
		}

		public void FiltrarAmbiente(string nomeAmbiente)
		{
			ClicarBuscarFiltrosCenario();
			EscolherAmbiente(nomeAmbiente);
			ClicarFiltrarCenario();
		}

		public void FiltrarPorTipo(string tipoCenario)
		{
			ClicarBuscarFiltrosCenario();
			EscolherTipoCenario(tipoCenario);
		}

        public void FiltrarPorViagem(string viagem)
        {
            ClicarBuscarFiltrosCenario();
            EscolherViagem(viagem);
        }

        public void FiltroDeViagem()
        {
            ClicarBuscarFiltrosCenario();
            SugestoesViagem();
        }

        private void EditarNovoCenario(string tipoCenario, string editarCenario)
		{
			SelecionarTipoCenario(tipoCenario);
			BrowserHelpers.EliminarAlertasChrome(Browser);
			PreencherNovoCenario(editarCenario);
		}

        private void EditarNovoCenarioGROTRegiao(string regiao)
        {
            BrowserHelpers.EliminarAlertasChrome(Browser);
            PreencherNovaRegiao(regiao);
        }

        private void EditarNovoAmbiente(string editarAmbiente)
		{
			PreencherNovoAmbiente(editarAmbiente);
		}

		private void ClicarBuscarFiltrosCenario()
		{
			var divFiltros = Element.Css("label[for='cenariofiltro']");

			FiltrarCenarios.Esperar(Browser, 2000);
			FiltrarCenarios.EsperarElemento(Browser);

			if (!divFiltros.IsElementVisible(Browser))
			{
				FiltrarCenarios.IsClickable(Browser);
				MouseActions.ClickATM(Browser, FiltrarCenarios);
			}
			else divFiltros.Esperar(Browser, 100);
		}

		private void ClicarBtnEditarCenario()
		{
			var DivPainel = Element.Css(".panel-group");
			var BtnEditar = Element.Css("td a[title='Editar este cenário']");

			DivPainel.Esperar(Browser, 2000);
			DivPainel.EsperarElemento(Browser);
			BtnEditar.EsperarElemento(Browser);
			if (BtnEditar.IsElementVisible(Browser))
			{
				BtnEditar.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnEditar);
			}
		}

		private void ClicarNovoCenario()
		{
			var painelGroup = Element.Css("a[class='btn btn-default btn-next-page']");
			painelGroup.Esperar(Browser, 1000);
			Browser.RefreshPage();
			painelGroup.EsperarElemento(Browser);
			BtnNovoCenario.EsperarElemento(Browser);
            BtnNovoCenario.Esperar(Browser, 2000);
            BtnNovoCenario.IsClickable(Browser);
            if (BtnNovoCenario.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnNovoCenario);
			}
		}

		private void SelecionarTipoCenario(string tipoCenario)
		{
			//Legenda: CENARIO = ESTUDIO, LOCACAO, CIDADE
			var TipoCenario = Element.Xpath("//label[@for='radioCenario-" + tipoCenario + "']");

			DivNovoCenario.Esperar(Browser, 1000);
			DivNovoCenario.EsperarElemento(Browser);
			if (TipoCenario.IsElementVisible(Browser))
				TipoCenario.IsClickable(Browser);
			MouseActions.ClickATM(Browser, TipoCenario);
		}

        private void PreencherNovaRegiao(string regiao)
        {
            SlctGrupoLocalGravacao.EsperarElemento(Browser);
            SlctGrupoLocalGravacao.Esperar(Browser, 500);
            if(SlctGrupoLocalGravacao.IsElementVisible(Browser))
            {
                AutomatedActions.TypingListATM(Browser, SlctGrupoLocalGravacao, InputGrupoLocalGravacao, regiao);
            }
        }

        private void PreencherNovoCenario(string nomeCenario)
		{
			InputNomeCenario.EsperarElemento(Browser);
			if (InputNomeCenario.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNomeCenario, nomeCenario);
		}

		private void ClicarNovoAmbiente()
		{
			LinkNovoAmbiente.EsperarElemento(Browser);
			if (LinkNovoAmbiente.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, LinkNovoAmbiente);
			BrowserHelpers.EliminarAlertasChrome(Browser);
		}

		private void PreencherNovoAmbiente(string nomeAmbiente)
		{
			InputNomeAmbiente.EsperarElemento(Browser);
			if (InputNomeAmbiente.IsElementVisible(Browser))
				InputNomeAmbiente.Esperar(Browser, 300);
			AutomatedActions.SendDataATM(Browser, InputNomeAmbiente, nomeAmbiente);
		}

		public void SalvarNovoCenario()
		{
            BtnSalvarCenario.Esperar(Browser, 2000);
            BtnSalvarCenario.EsperarElemento(Browser);
			if (BtnSalvarCenario.IsElementVisible(Browser))
			{
                BtnSalvarCenario.IsClickable(Browser);
                BtnSalvarCenario.Esperar(Browser, 2000);
                MouseActions.ClickATM(Browser, BtnSalvarCenario);
			}
		}

		private void CenarioInseridoSucesso()
		{
			var mensagem = Element.Css("div[class='alert alert-info alert-dismissable alert-util']");
			mensagem.EsperarElemento(Browser);
			mensagem.IsElementVisible(Browser);

			string texto = mensagem.GetTexto(Browser);
			Assert.IsTrue(true, texto);
		}

		public void AssociarPDS(string nomePDS)
		{
			InputPDSCenario.EsperarElemento(Browser);
			if (InputPDSCenario.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputPDSCenario, nomePDS);
			KeyboardActions.ArrowDonw(Browser, InputPDSCenario);
			KeyboardActions.Enter(Browser, InputPDSCenario);
		}

		private void SalvarAndCriarNovoCenario()
		{
			BtnSalvarAndCriarNovoCenario.EsperarElemento(Browser);
			if (BtnSalvarAndCriarNovoCenario.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarAndCriarNovoCenario);
		}

		private void EscolherCenario(string nomeCenario)
		{
			var DivFiltro = Element.Css("div[class='col-xs-12'] fieldset");

			DivFiltro.EsperarElemento(Browser);
			SelectCenario.EsperarElemento(Browser);
			if (SelectCenario.IsElementVisible(Browser))
			{
				SelectCenario.IsClickable(Browser);
				AutomatedActions.TypingListATM(Browser, SelectCenario, InputCenario, nomeCenario);

				InputCenario.Esperar(Browser, 1000);
				InputCenario.IsClickable(Browser);
				KeyboardActions.Enter(Browser, InputCenario);
			}
		}

		private void EscolherAmbiente(string nomeAmbiente)
		{
			var DivFiltro = Element.Css("div[class='col-xs-12'] fieldset");

			DivFiltro.EsperarElemento(Browser);
			SelectAmbiente.EsperarElemento(Browser);
			if (SelectAmbiente.IsElementVisible(Browser))
				//DivFiltro.Esperar(Browser, 500);
				AutomatedActions.TypingListATM(Browser, SelectAmbiente, InputAmbiente, nomeAmbiente);
			KeyboardActions.Enter(Browser, InputAmbiente);
		}

		private void EscolherTipoCenario(string tipoCenario)
		{
			var DivFiltro = Element.Css("div[class='col-xs-12'] fieldset");

			DivFiltro.EsperarElemento(Browser);
			SelectPorTipo.EsperarElemento(Browser);
			if (SelectPorTipo.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, SelectPorTipo, InputTipo, tipoCenario);
		}

        private void SugestoesViagem()
        {
            var DivFiltro = Element.Css("div[class='col-xs-12'] fieldset");

            DivFiltro.EsperarElemento(Browser);
            SlctPorViagem.EsperarElemento(Browser);
            SlctPorViagem.Esperar(Browser, 2000);
            if (SlctPorViagem.IsElementVisible(Browser))
                MouseActions.ClickATM(Browser, SlctPorViagem);
        }

        private void EscolherViagem(string viagem)
        {
            var DivFiltro = Element.Css("div[class='col-xs-12'] fieldset");

            DivFiltro.EsperarElemento(Browser);
            SlctPorViagem.EsperarElemento(Browser);
            SlctPorViagem.Esperar(Browser, 2000);
            if (SlctPorViagem.IsElementVisible(Browser))
                AutomatedActions.TypingListATM(Browser, SlctPorViagem, InputViagem, viagem);
        }

        private void ClicarFiltrarCenario()
		{
			BtnFiltrar.EsperarElemento(Browser);
			if (BtnFiltrar.IsElementVisible(Browser))
			{
				BtnFiltrar.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnFiltrar);
			}
		}

		private void ApagarCenario()
		{
			var BtnExcluirCenario = Element.Xpath("//a[@title='Excluir este cenário']");
			var Cenario = Element.Css(".panel-header");

			Cenario.Esperar(Browser, 1000);
			Cenario.EsperarElemento(Browser);
			if (BtnExcluirCenario.IsElementVisible(Browser))
			{
                BtnExcluirCenario.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, BtnExcluirCenario);
			}

			ExcluirCenarioPopUp();
		}

		private void ExcluirCenarioPopUp()
		{
			BtnOK.EsperarElemento(Browser);
			if (Browser.PageSource("O cenário e todos os ambientes associados serão excluídos e não poderão ser recuperados. Tem certeza que deseja excluir este cenário?"))
				MouseActions.ClickATM(Browser, BtnOK);
		}

		private void ApagarAmbiente()
		{
			var ExcluirAmbiente = Element.Css("a[title='Excluir ambiente']");

			ExcluirAmbiente.Esperar(Browser, 1000);
			ExcluirAmbiente.EsperarElemento(Browser);
			if (ExcluirAmbiente.IsElementVisible(Browser))
				ExcluirAmbiente.IsClickable(Browser);
			MouseActions.ClickATM(Browser, ExcluirAmbiente);
		}

		private void ExibirAmbientes()
		{
			var ExpandirAmbiente = Element.Css("a[class='icon-button icon-down collapse-down'][title='Exibir ambientes']");

			ExpandirAmbiente.Esperar(Browser, 500);
			ExpandirAmbiente.EsperarElemento(Browser);
			if (ExpandirAmbiente.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, ExpandirAmbiente);
		}

		private void ExcluirAmbientePopUp()
		{
			var PopUp = Element.Css("div[class='modal-content']");

			PopUp.EsperarElemento(Browser);
			if (Browser.PageSource("Tem certeza que deseja excluir este ambiente?"))
				MouseActions.ClickATM(Browser, BtnOK);
		}

		private void ClicarEditarMaterialFixo()
		{
			var BtnEditarMateriais = Element.Css("a[title='Editar materiais fixos']");

			BtnEditarMateriais.Esperar(Browser, 1000);
			BtnEditarMateriais.EsperarElemento(Browser);
			if (BtnEditarMateriais.IsElementVisible(Browser))
				BtnEditarMateriais.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnEditarMateriais);
		}

		public void AbrirTelaCenario()
		{
			ClicarMenuList();
			ClicarCenarioList();
		}

		private void ClicarCenarioList()
		{
			var CenarioList = Element.Xpath("//a[text()='Cenários']");

			CenarioList.EsperarElemento(Browser);
			if (CenarioList.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, CenarioList);
		}

		private void ClicarMenuList()
		{
			var MenuList = Element.Css("a[class='dropmenuPDown']");

			MenuList.EsperarElemento(Browser);
			if (MenuList.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, MenuList);
		}

		public override void Navegar()
		{
			Browser.Abrir(CenarioUrl);
			Browser.PageLoad();
		}


		//-------------------VERIFICACOES-------------------\\
		public void VerificarExclusaoAmbiente(string exclusaoAmbiente)
		{
			var TableExclusao = Element.Css("div[id='0']");
			TableExclusao.EsperarElemento(Browser);
			string textoExclusao = TableExclusao.GetTexto(Browser).Trim();

			Assert.AreEqual(textoExclusao, exclusaoAmbiente);
		}

		public void VerificarInclusaoCenario(string mensagem)
		{
			var InclusaoSucesso = Element.Css("div[class='container']");
			string Alerta = InclusaoSucesso.GetTexto(Browser).Trim();
			string newAlert = Alerta.Substring(3);

			Assert.AreEqual(mensagem, newAlert);
		}


        public void VerificarInclusaoLocal(string mensagem)
        {
            var InclusaoSucesso = Element.Css("div[class='container']");
            string Alerta = InclusaoSucesso.GetTexto(Browser).Trim();
            string newAlert = Alerta.Substring(3);

            Assert.AreEqual(mensagem, newAlert);
            Thread.Sleep(2000);
        }


        public void VerificarInclusaoRegiao(string mensagem)
        {
            var InclusaoSucesso = Element.Css("div[class='container']");
            string Alerta = InclusaoSucesso.GetTexto(Browser).Trim();
            string newAlert = Alerta.Substring(3);

            Assert.AreEqual(mensagem, newAlert);
        }

        public void VerificarAtualizacaoCenario(string mensagem)
		{
			var AtualizacaoSucesso = Element.Css("div[class='container']");
			string Alerta = AtualizacaoSucesso.GetTexto(Browser).Trim();
			string newAlert = Alerta.Substring(3);

			Assert.AreEqual(mensagem, newAlert);
		}

		public void VerificarExclusaoCenario(string mensagem)
		{
			AlertaExclusao();
		}

		public void VerificarCriticaPDS()
		{
			SalvarNovoCenario();
			CenarioInseridoSucesso();
		}

		public void VerificarFiltroCenario(string nomeCenario)
		{
			var Painel = Element.Css(".panel-body");
			var FiltroCenario = Element.Css("table[class='panel-header'] td strong");

			Painel.EsperarElemento(Browser);
			Painel.Esperar(Browser, 1000);
			string textoCenario = FiltroCenario.GetTexto(Browser).Trim();

			FiltroCenario.EsperarElemento(Browser);
			if (FiltroCenario.IsElementVisible(Browser))
			{
				Assert.AreEqual(textoCenario, nomeCenario);
			}
		}

        public void ValidarRegioesCadastradas(string regiao)
        {
            var grupoLocalGravacao = Element.Xpath("//select[@id='grupoLocalGravacao']/option[text()='" + regiao + "']");
            grupoLocalGravacao.IsElementVisible(Browser);
            grupoLocalGravacao.Esperar(Browser, 1000);
        }

        public void ValidarViagensCadastradas(string viagem)
        {
            var viagemPath = Element.Xpath("//select[@id='viagemfiltro']/option[text()='" + viagem + "']");
            viagemPath.IsElementVisible(Browser);
            viagemPath.Esperar(Browser, 1000);
        }
    }
}
