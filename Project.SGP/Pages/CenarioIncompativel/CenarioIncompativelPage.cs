using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.SGP.Pages
{
	public class CenarioIncompativelPage : PageBase
	{
		private string CenarioIncompativelUrl { get; }

		//Button
		private Element BtnFiltrarCenarioIncompativel { get; }
		private Element BtnNovaListaIncompatibilidade { get; }
		private Element BtnSalvarListaCenariosIncompativeis { get; }
        private Element BtnSalvarECriarNovaListaCenariosIncompativeis { get; }
        private Element BtnOK { get; }

		//Input
		private Element InputNomeListaIncompativel { get; }
		private Element InputCenarioIncompativel { get; }
		private Element InputListIncompatibilidadeUM { get; }
		private Element InputListIncompatibilidadeDOIS { get; }
        private Element InputListIncompatibilidadeTRES { get; }
        private Element InputAmbienteIncompativelUM { get; }
		private Element InputAmbienteIncompativelDOIS { get; }
        private Element InputAmbienteIncompativelTRES { get; }
        private Element InputAmbienteIncompativel { get; }

        //DropList
        private Element DropListCenarioIncompativel { get; }
        private Element DropListAmbienteFiltro { get; }
        private Element DropListIncompatibilidadeUM { get; }
		private Element DropListIncompatibilidadeDOIS { get; }
        private Element DropListIncompatibilidadeTRES { get; }
        private Element DropListAmbienteIncompativelUM { get; }
		private Element DropListAmbienteIncompativelDOIS { get; }
        private Element DropListAmbienteIncompativelTRES { get; }

        //Others
        private Element TelaFiltrar { get; }
        private Element ChckTodosAmbientesUM { get; }
        private Element ChckTodosAmbientesDOIS { get; }
        private Element LinkAdicionarIncompatibilidade { get; }
        

        public CenarioIncompativelPage(IBrowser browser,
		   string cenarioIncompativelUrl) : base(browser)
		{
			CenarioIncompativelUrl = cenarioIncompativelUrl;

			//Button
			BtnFiltrarCenarioIncompativel = Element.Id("filtrarbtn");
			BtnNovaListaIncompatibilidade = Element.Id("NovaListaIncompatibilidade");
			BtnSalvarListaCenariosIncompativeis = Element.Css("button[data-bb-handler='b1']");
            BtnSalvarECriarNovaListaCenariosIncompativeis = Element.Css("button[data-bb-handler='b4']");          
			BtnOK = Element.Xpath("//button[@data-bb-handler='b1'][text()='Ok']");

			//Input
			InputNomeListaIncompativel = Element.Id("Nome");
			InputCenarioIncompativel = Element.Css("#CenarioFiltro_chosen input");
            InputAmbienteIncompativel = Element.Css("#AmbienteFiltro_chosen input");
            InputListIncompatibilidadeUM = Element.Css("#CenarioPopFiltro_0_chosen input");
			InputListIncompatibilidadeDOIS = Element.Css("#CenarioPopFiltro_1_chosen input");
            InputListIncompatibilidadeTRES = Element.Css("#CenarioPopFiltro_3_chosen input");
            InputAmbienteIncompativelUM = Element.Css("#AmbientePopFiltro_0_chosen input");
			InputAmbienteIncompativelDOIS = Element.Css("#AmbientePopFiltro_1_chosen input");
            InputAmbienteIncompativelTRES = Element.Css("#AmbientePopFiltro_3_chosen input");

            //DropList
            DropListCenarioIncompativel = Element.Css("#CenarioFiltro_chosen a");
            DropListAmbienteFiltro = Element.Css("#AmbienteFiltro_chosen a");
			DropListIncompatibilidadeUM = Element.Css("#CenarioPopFiltro_0_chosen");
			DropListIncompatibilidadeDOIS = Element.Css("#CenarioPopFiltro_1_chosen");
            DropListIncompatibilidadeTRES = Element.Css("#CenarioPopFiltro_3_chosen");
            DropListAmbienteIncompativelUM = Element.Css("#AmbientePopFiltro_0_chosen");
			DropListAmbienteIncompativelDOIS = Element.Css("#AmbientePopFiltro_1_chosen");
            DropListAmbienteIncompativelTRES = Element.Css("#AmbientePopFiltro_3_chosen");

            //Others
            TelaFiltrar = Element.Css(".col-xs-12");
            ChckTodosAmbientesUM = Element.Css("input[id='TodosAmbientes_0']");
            ChckTodosAmbientesDOIS = Element.Css("input[id='TodosAmbientes_1']");
            LinkAdicionarIncompatibilidade = Element.Css("a[id='adicionarIncompatibilidade']");

        }

		//---------------CRIAR LISTAGEM INCOMPATIVEIS-----------------------\\
		public void CriarListaCenarioIncompativel(string nome, string cenarioUM, string cenarioDOIS, string nomeAmbienteUM, string nomeAmbienteDOIS)
		{
			ClicarBtnNovaListaIncompatibilidade();
            if(nome != "")
            {
                PreencherNovaListaIncompatibilidade(nome);
            }
			if(cenarioUM != "")
            {
                SelecionarCenariosIncompativeis(cenarioUM, cenarioDOIS);
            }
			if(nomeAmbienteUM != "")
            {
                SelecionarAmbientesIncompativeis(nomeAmbienteUM, nomeAmbienteDOIS);
            }
		}

        public void CriarSegundaListaCenarioIncompativel(string nome, string cenarioUM, string cenarioDOIS, string cenarioTRES, 
            string nomeAmbienteUM, string nomeAmbienteDOIS, string nomeAmbienteTRES)
        {
            if (nome != "")
            {
                PreencherNovaListaIncompatibilidade(nome);
            }
            if (cenarioUM != "")
            {
                SelecionarCenariosIncompativeis(cenarioUM, cenarioDOIS);
            }
            if (nomeAmbienteUM != "")
            {
                SelecionarAmbientesIncompativeis(nomeAmbienteUM, nomeAmbienteDOIS);
            }
            if(cenarioTRES != "")
            {
                SelecionarCenarioAmbiente3(cenarioTRES, nomeAmbienteTRES);
            }
        }
        
        public void MarcarTodosAmbientes(string chkUm, string chkDois)
        {
            string chkUmPath = "$('input[id=\"TodosAmbientes_0\"]').click();";
            string chkDoisPath = "$('input[id=\"TodosAmbientes_1\"]').click();";

            if(chkUm != "")
            {
                JsActions.JavaScript(Browser, chkUmPath);
            }
            if (chkDois != "")
            {
                JsActions.JavaScript(Browser, chkDoisPath);
            }
        }

        private void SelecionarCenariosIncompativeis(string cenarioUM, string cenarioDOIS)
		{
			DropListIncompatibilidadeUM.EsperarElemento(Browser);
			if (DropListIncompatibilidadeUM.IsElementVisible(Browser))
			{
                if(cenarioUM != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListIncompatibilidadeUM, InputListIncompatibilidadeUM, cenarioUM);
                }
                if(cenarioDOIS != "")
                {
                    DropListIncompatibilidadeDOIS.Esperar(Browser, 2000);
                    AutomatedActions.TypingListATM(Browser, DropListIncompatibilidadeDOIS, InputListIncompatibilidadeDOIS, cenarioDOIS);
                    InputListIncompatibilidadeDOIS.Esperar(Browser, 2000);
                }
			}
		}

        private void SelecionarCenariosIncompativeis3Criacao(string cenarioTRES)
        {
            DropListIncompatibilidadeTRES.EsperarElemento(Browser);
            if (DropListIncompatibilidadeTRES.IsElementVisible(Browser))
            {
                if (cenarioTRES != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListIncompatibilidadeTRES, InputListIncompatibilidadeTRES, cenarioTRES);
                }
            }
        }

        private void SelecionarCenariosIncompativeis3(string cenarioTRES)
        {
            DropListIncompatibilidadeDOIS.EsperarElemento(Browser);
            if (DropListIncompatibilidadeDOIS.IsElementVisible(Browser))
            {
                if (cenarioTRES != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListIncompatibilidadeDOIS, InputListIncompatibilidadeDOIS, cenarioTRES);
                }
            }
        }

        private void SelecionarAmbientesIncompativeis3Criacao(string nomeAmbienteTRES)
        {
            DropListAmbienteIncompativelTRES.EsperarElemento(Browser);
            if (DropListAmbienteIncompativelTRES.IsElementVisible(Browser))
            {
                if (nomeAmbienteTRES != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListAmbienteIncompativelTRES, InputAmbienteIncompativelTRES, nomeAmbienteTRES);
                }
            }
        }

        private void SelecionarAmbientesIncompativeis3(string nomeAmbienteTRES)
        {
            DropListAmbienteIncompativelDOIS.EsperarElemento(Browser);
            if (DropListAmbienteIncompativelDOIS.IsElementVisible(Browser))
            {
                if (nomeAmbienteTRES != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListAmbienteIncompativelDOIS, InputAmbienteIncompativelDOIS, nomeAmbienteTRES);
                }
            }
        }

        private void SelecionarAmbientesIncompativeis(string nomeAmbienteUM, string nomeAmbienteDOIS)
		{
			DropListAmbienteIncompativelUM.EsperarElemento(Browser);
			if (DropListAmbienteIncompativelUM.IsElementVisible(Browser))
			{
                if(nomeAmbienteUM != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListAmbienteIncompativelUM, InputAmbienteIncompativelUM, nomeAmbienteUM);
                }
                if(nomeAmbienteDOIS != "")
                {
                    AutomatedActions.TypingListATM(Browser, DropListAmbienteIncompativelDOIS, InputAmbienteIncompativelDOIS, nomeAmbienteDOIS);
                    InputAmbienteIncompativelDOIS.Esperar(Browser, 1000);
                }
			}
		}

		public void ClicarSalvarListaCenariosIncompativeis()
		{
			BtnSalvarListaCenariosIncompativeis.EsperarElemento(Browser);
			if (BtnSalvarListaCenariosIncompativeis.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarListaCenariosIncompativeis);
			}
		}

        public void SalvarListaCenariosIncompativeis()
        {
            BtnSalvarListaCenariosIncompativeis.EsperarElemento(Browser);
            if (BtnSalvarListaCenariosIncompativeis.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnSalvarListaCenariosIncompativeis);
            }

            ListaInseridaSucesso();
        }

        private void ListaInseridaSucesso()
		{
			var Mensagem = Element.Class("container");
			Mensagem.EsperarElemento(Browser);
			Mensagem.IsElementVisible(Browser);

			string texto = Mensagem.GetTexto(Browser);
			Assert.IsTrue(true, texto);
		}

		public void ClicarBtnNovaListaIncompatibilidade()
		{
			BtnNovaListaIncompatibilidade.Esperar(Browser, 2000);
			BtnNovaListaIncompatibilidade.EsperarElemento(Browser);
			if (BtnNovaListaIncompatibilidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnNovaListaIncompatibilidade);
			}
		}

        public void SalvarECriarNovaListaIncompatibilidade()
        {
            BtnSalvarECriarNovaListaCenariosIncompativeis.Esperar(Browser, 2000);
            BtnSalvarECriarNovaListaCenariosIncompativeis.EsperarElemento(Browser);
            if (BtnSalvarECriarNovaListaCenariosIncompativeis.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnSalvarECriarNovaListaCenariosIncompativeis);
            }
            ListaInseridaSucesso();
        }

        private void PreencherNovaListaIncompatibilidade(string nome)
		{
			InputNomeListaIncompativel.EsperarElemento(Browser);
			InputNomeListaIncompativel.Esperar(Browser, 2000);
			if (InputNomeListaIncompativel.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputNomeListaIncompativel, nome);
                KeyboardActions.Tab(Browser, InputNomeListaIncompativel);
			}
		}

		private void EscolherCenario(string cenario)
		{
			DropListCenarioIncompativel.EsperarElemento(Browser);
            DropListCenarioIncompativel.Esperar(Browser, 2000);
            if (DropListCenarioIncompativel.IsElementVisible(Browser))
			{
				AutomatedActions.TypingListATM(Browser, DropListCenarioIncompativel, InputCenarioIncompativel, cenario);
			}
		}

        private void EscolherAmbiente(string ambiente)
        {
            DropListAmbienteFiltro.EsperarElemento(Browser);
            DropListAmbienteFiltro.Esperar(Browser, 2000);
            if (DropListAmbienteFiltro.IsElementVisible(Browser))
            {
                AutomatedActions.TypingListATM(Browser, DropListAmbienteFiltro, InputAmbienteIncompativel, ambiente);
            }
        }

        private void ClicarBtnFiltrarCenarioIncompativel()
		{
			BtnFiltrarCenarioIncompativel.EsperarElemento(Browser);
			if (BtnFiltrarCenarioIncompativel.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnFiltrarCenarioIncompativel);
			}
		}

        public void EditarListaCenarioIncompativel(string nome, string cenarioUM, string cenarioDOIS, string cenarioTRES, 
            string nomeAmbienteUM, string nomeAmbienteDOIS, string nomeAmbienteTRES, string Num)
        {
            ClicarEditarLista();
            if(nome != "")
            {
                PreencherNovaListaIncompatibilidade(nome);
            }
            PreencherCenarios(cenarioUM, nomeAmbienteUM, Num);
            PreencherCenarios(cenarioDOIS, nomeAmbienteDOIS, Num);
            if(cenarioTRES != "")
            {
                PreencherCenarioAmbiente3(cenarioTRES, nomeAmbienteTRES);
            }
        }

        private void PreencherCenarioAmbiente3(string Cenario, string Ambiente)
        {
            LinkAdicionarIncompatibilidade.EsperarElemento(Browser);
            LinkAdicionarIncompatibilidade.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, LinkAdicionarIncompatibilidade);

            SelecionarCenariosIncompativeis3(Cenario);
            SelecionarAmbientesIncompativeis3(Ambiente);
        }

        private void SelecionarCenarioAmbiente3(string Cenario, string Ambiente)
        {
            LinkAdicionarIncompatibilidade.EsperarElemento(Browser);
            LinkAdicionarIncompatibilidade.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, LinkAdicionarIncompatibilidade);

            SelecionarCenariosIncompativeis3Criacao(Cenario);
            SelecionarAmbientesIncompativeis3Criacao(Ambiente);
        }

        private void PreencherCenarios(string Cenario, string Ambiente, string Num)
        {
            var cenarioDropdown = Element.Css("div[class='row incompatibilidade']:nth-child(" + Num + ") div[class='col-lg-4 col-md-4 col-sm-4 col-xs-12'] a[class='chosen-single']");
            var cenarioInput = Element.Css("div[class='row incompatibilidade']:nth-child(" + Num + ") div[class='col-lg-4 col-md-4 col-sm-4 col-xs-12'] div[class='chosen-drop'] input");
            var ambienteDropdown = Element.Css("div[class='row incompatibilidade']:nth-child(" + Num + ") div[class='col-lg-4 col-md-4 col-sm-4 col-xs-12 '] a");
            var ambienteInput = Element.Css("div[class='row incompatibilidade']:nth-child(" + Num + ") div[class='col-lg-4 col-md-4 col-sm-4 col-xs-12 '] div[class='chosen-drop'] input");

            if(Cenario != "")
            {
                cenarioDropdown.EsperarElemento(Browser);
                AutomatedActions.TypingListATM(Browser, cenarioDropdown, cenarioInput, Cenario);
            }
            if(Ambiente != "")
            {
                ambienteDropdown.EsperarElemento(Browser);
                AutomatedActions.TypingListATM(Browser, ambienteDropdown, ambienteInput, Ambiente);
            }
        }

        private void ClicarEditarLista()
        {
            var BtnEditarLista = Element.Xpath("//a[@title='Editar esta lista de incompatibilidade']");
            var Cenario = Element.Css(".panel-header");

            Cenario.Esperar(Browser, 2000);
            Cenario.EsperarElemento(Browser);
            if (BtnEditarLista.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnEditarLista);
            }                        
        }

        public void ClicarMenuPrincipal()
        {
            var menuPath = Element.Css("a[class='dropmenuPDown']");
            menuPath.EsperarElemento(Browser);
            menuPath.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, menuPath);
        }

        public void ValidarOpcaoCenariosIncompativeisInexistentes()
        {
            var opcaoCenariosIncompativeisPath = Element.Css("nav[id='headerMenu'] li a[href='/SGP/ListaIncompatibilidade']");
            opcaoCenariosIncompativeisPath.IsNotElementVisible(Browser);
        }

        private void ExibirCenarios()
        {
            var btnExibir = Element.Css("table[class='panel-header'] td:nth-child(1) a:nth-child(1)");
            btnExibir.Esperar(Browser, 2000);
            btnExibir.EsperarElemento(Browser);
            btnExibir.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, btnExibir);
        }

        //--------------EXLUIR LISTAGEM CENARIOS INCOMPATIVEIS----------------\\
        public void ApagarListaCenarioIncompativel(string cenario, string ambiente)
		{
			Browser.Abrir(CenarioIncompativelUrl);

			TelaFiltrar.EsperarElemento(Browser);
			if (TelaFiltrar.IsElementVisible(Browser))
			{
				FiltrarCenariosIncompativeis(cenario, ambiente);
				ApagarLista();
			}
		}

		private void ApagarLista()
		{
			var BtnApagarLista = Element.Xpath("//a[@title='Excluir esta lista de incompatibilidade']");
			var Cenario = Element.Css(".panel-header");

			Cenario.Esperar(Browser, 1000);
			Cenario.EsperarElemento(Browser);
			if (BtnApagarLista.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnApagarLista);
			}

			ExcluirListaCenarioIncompativelPopUp();
		}

		private void ExcluirListaCenarioIncompativelPopUp()
		{
			BtnOK.EsperarElemento(Browser);
			if (Browser.PageSource("Todos os cenários incompatíveis da lista selecionada serão excluídos. Deseja continuar?"))
				MouseActions.ClickATM(Browser, BtnOK);
		}

        public void ExcluirCenarioIncompativel(string cenario)
        {
            ExibirCenarios();

            var excluirCenario = Element.Css("div[class='panel-collapse col-md-12 collapse in'] tr:nth-child(" + cenario + ") a");
            excluirCenario.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, excluirCenario);

            var mensagemAlertaExclusao = Element.Xpath("//p[text()='O Cenário Incompatível será excluído e não poderá ser recuperado. Caso exista menos de 2 cenários incompatíveis a lista será excluída. Tem certeza que deseja excluir este Cenário Incompatível?']");

            BtnOK.EsperarElemento(Browser);
            if(mensagemAlertaExclusao.IsElementVisible(Browser))
            {
                mensagemAlertaExclusao.Esperar(Browser, 2000);
                MouseActions.ClickATM(Browser, BtnOK);
            }
        }

		//--------------FILTRAR CENARIOS INCOMPATIVEIS----------------\\
		public void FiltrarCenariosIncompativeis(string cenario, string ambiente)
		{
            if(cenario != "")
            {
                EscolherCenario(cenario);
            }
			if(ambiente != "")
            {
                EscolherAmbiente(ambiente);
            }
			ClicarBtnFiltrarCenarioIncompativel();
		}

		public override void Navegar()
		{
			Browser.Abrir(CenarioIncompativelUrl);
			Browser.PageLoad();
		}

		//----------------------VERIFICAÇÕES-------------------------\\
		public void VerificarNovaListaCriada(string lista)
		{
			var Verificar = Element.Xpath("//div[@id='listaIncompatibilidade']//strong[text()='"+ lista + "']");
			Verificar.EsperarElemento(Browser);
			if (Verificar.IsElementVisible(Browser))
			{
				string validation = Verificar.GetTexto(Browser);
				Assert.AreEqual(lista, validation);
			}
		}

        public void VerificarNovaListaExcluida(string lista)
        {
            var Verificar = Element.Xpath("//div[@id='listaIncompatibilidade']//strong[text()='" + lista + "']");
            Verificar.IsNotElementVisible(Browser);
        }

        public void ValidarListaJaCadastrada(string texto)
        {
            var textPath = Element.Xpath("//p[text()='" + texto + "']");
            textPath.IsElementVisible(Browser);
            textPath.Esperar(Browser, 1000);
        }

        public void ValidarCenarioAmbienteJaCadastrados(string texto)
        {
            var textPath = Element.Xpath("//div[text()='" + texto + "']");
            textPath.IsElementVisible(Browser);
            textPath.Esperar(Browser, 1000);
        }

        public void ValidarAlerta()
        {
            var alertaPath = Element.Css("div[class='container']");
            alertaPath.IsElementVisible(Browser);
            alertaPath.Esperar(Browser, 1000);
        }

        public void ValidarMensagem()
        {
            var alerta = Element.Css("div[class='container']");
            alerta.EsperarElemento(Browser);

            string validation = alerta.GetTexto(Browser).Trim();
            string mensagem = "×\r\nAtenção: Não é permitido realizar o cadastro de uma lista de incompatibilidade com menos de dois cenários/ambiente.";
            Assert.AreEqual(validation, mensagem);
        }
    }
}
