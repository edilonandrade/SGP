using System;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core.Helpers;
using System.Threading;
using Framework.Core.Exceptions;

namespace Project.SGP.Pages
{
	public class PlanejamentoRoteiroPage : PageBase
	{
		private string PlanejamentoRoteiroUrl { get; }
		private string nomePlanejamento { get; set; }

		//Input
		private Element InputNomeUsuario { get; }
		private Element InputCargo { get; }
		private Element InputEmail { get; }
		private Element InputPopUpCancelamento { get; }
		private Element InputDirecaoPrograma { get; }
		private Element InputCapitulosBaixos { get; }
		private Element InputInicioCalendarioRoteiro { get; }
		private Element InputCampoTipo { get; }
		private Element InputCampoCenarioLocacao { get; }
		private Element InputCampoPersonagem { get; }
		private Element InputCampoStatus { get; }
		private Element InputCampoClassificacoes { get; }
		private Element InputCampoCategorias { get; }
		private Element InputCampoPeriodoDia { get; }
		private Element InputCampoIntervaloCapitulo { get; }
		private Element InputRecursosRoteiro { get; }
		private Element InputInicioJornada { get; }
		private Element InputInicioRefeicao { get; }
		private Element InputFimRefeicao { get; }
		private Element InputFimJornada { get; }

		//Button
		private Element BtnDestacar { get; }
		private Element BtnEditarOrBloquear { get; }
		private Element BtnSalvarCapitulosBaixos { get; }
		private Element BtnSalvarDirecaoPrograma { get; }
		private Element BtnExlcuirNomeNotificacao { get; }
		private Element BtnSalvarGrupoNotificacao { get; }
		private Element BtnConfirmarRoteiro { get; }
		private Element BtnExpandirCenas { get; }
		private Element BtnGerarRelatorio { get; }
		private Element BtnGerarRelatorioCenas { get; }
		private Element BtnPopUpSIM { get; }
		private Element BtnFiltrarCenas { get; }
		private Element BtnBuscar { get; }
		private Element BtnSIMpopUpAtencaoPDS { get; }
		private Element BtnRoldanaRoteiro { get; }

		//Others
		private Element SubListCancelar { get; }
		private Element SubListLiberado { get; }
		private Element SubListNaoLiberado { get; }
		private Element ListPlanejamento { get; }
		private Element SubListCompartilhar { get; }
		private Element SubListSalvar { get; }
		private Element SubListDestacarCenas { get; }
		private Element SubListConfiguracoes { get; }
		private Element SubListCapitulosBaixos { get; }
		private Element SubListDirecaoPrograma { get; }
		private Element SubListGrupoNotificacao { get; }
		private Element ListGerarRelatorio { get; }
		private Element ListSelecionarRoteiro { get; }
		private Element CheckBoxCapaSemana { get; }
		private Element CheckBoxRelatorioBasico { get; }
		private Element CheckBoxRelatorioRoupas { get; }
		private Element CheckBoxRecursoRoteiros { get; }
		private Element TableName { get; }
		private Element LiberarAll { get; }
		private Element LiberarPrimeiroRoteiro { get; }
		private Element PopDirProg { get; }
		private Element PopCapBaixo { get; }
		private Element TableElement { get; }
		private Element PaginaRoetiro { get; }
		private Element PopUpDestacarCenas { get; }
		private Element SubListSelecionarRoteiro { get; }
		private Element ChkCapaSemana { get; }
		private Element ChkRelatorioBasico { get; }
		private Element ChkRecursosRoteiro { get; }
		private Element ChkRelatorioRoupas { get; }
		private Element LiberarUmRoteiro { get; }
		private Element PopUpRecursosRoteiro { get; }
		private Element PopUpFrequenciaElenco { get; }
		private Element ListAbrirPlanejamento { get; }
		private Element DropListFrenteMoverRoteiro { get; }


		public PlanejamentoRoteiroPage(IBrowser browser,
			string planejamentoRoteiroUrl) : base(browser)
		{
			PlanejamentoRoteiroUrl = planejamentoRoteiroUrl;

			//Input
			InputNomeUsuario = Element.Id("nomeNovoUsuario");
			InputCargo = Element.Id("cargoNovoUsuario");
			InputEmail = Element.Id("emailNovoUsuario");
			InputPopUpCancelamento = Element.Css("#popCancelamento textarea");
			InputDirecaoPrograma = Element.Css("#popDiretorPrograma input");
			InputCapitulosBaixos = Element.Xpath("//*[@id='popCapBaixos']//input");
			InputInicioCalendarioRoteiro = Element.Css("div > input[class='field data hasDatepicker']");
			InputCampoTipo = Element.Xpath("//*[@id='filtroTipos_chzn']//input");
			InputCampoCenarioLocacao = Element.Xpath("//*[@id='filtroCenarios_chzn']//input");
			InputCampoPersonagem = Element.Xpath("//*[contains(@id,'sel')]/ul/li/input");
			InputCampoStatus = Element.Xpath("//*[@id='filtroStatus_chzn']//input");
			InputCampoClassificacoes = Element.Xpath("//*[@id='filtroClassificacoes_chzn']//input");
			InputCampoCategorias = Element.Xpath("//*[@id='filtroCategorias_chzn']//input");
			InputCampoPeriodoDia = Element.Xpath("//*[@id='filtroPeriodoDoDia_chzn']//input");
			InputCampoIntervaloCapitulo = Element.Xpath("//*[@id='filtroCapitulos_chzn']//input");
			InputRecursosRoteiro = Element.Id("recursos-roteiro");
			InputInicioJornada = Element.Css("input[name='IniJor']");
			InputInicioRefeicao = Element.Css("input[name='IniRef']");
			InputFimRefeicao = Element.Css("input[name='TermRef']");
			InputFimJornada = Element.Css("input[name='TermJor']");

			//Button
			BtnExlcuirNomeNotificacao = Element.Css(".excluir img");
			BtnConfirmarRoteiro = Element.Css("input[value='Confirmar']");
			BtnDestacar = Element.Xpath("//button//span[text()='Destacar']");
			BtnSalvarGrupoNotificacao = Element.Xpath("//div[27]//span[text()='Salvar']");
			BtnSalvarCapitulosBaixos = Element.Xpath("//div[12]//span[text()='Salvar']");
			BtnSalvarDirecaoPrograma = Element.Xpath("//div[22]//span[text()='Salvar']");
			BtnExpandirCenas = Element.Css("img[data-bind='click: $root.CenasVM.ExpandirTodosAmbientes']");
			BtnEditarOrBloquear = Element.Xpath("//div[@id='tstDesbloquearProducao' or @id='tstBloquearProducao']");
			BtnGerarRelatorio = Element.Css("input[value='Gerar Relatório']");
			BtnGerarRelatorioCenas = Element.Link("Relatório de Cenas");
			BtnPopUpSIM = Element.Css("#ButtonSim");
			BtnFiltrarCenas = Element.Id("tstFiltroCenasRoteirizaveis");
			BtnBuscar = Element.Id("btnBuscarCenas");
			BtnRoldanaRoteiro = Element.Css("img.ractions");

			//Others
			SubListSalvar = Element.Id("tstSalvarMapa");
			SubListCancelar = Element.Id("tstCancelar");
			SubListLiberado = Element.Id("tstLiberado");
			SubListNaoLiberado = Element.Id("tstNaoLiberado");
			ListPlanejamento = Element.Id("botRoteiroMenu");
			SubListCompartilhar = Element.Id("tstCompartilhar");
			SubListCapitulosBaixos = Element.Id("tstCapBaixos");
			SubListConfiguracoes = Element.Id("tstConfiguracoes");
			SubListDirecaoPrograma = Element.Id("tstDirecaoPrograma");
			SubListGrupoNotificacao = Element.Id("tstGrupoNotificacao");
			SubListDestacarCenas = Element.Id("AbrirPopFiltroCenasRoteirizaveis");
			ListSelecionarRoteiro = Element.Css("#tstSelecionarRoteirosGerarRelatorio");
			CheckBoxCapaSemana = Element.Css("#CbCapa");
			CheckBoxRelatorioBasico = Element.Css("#CbRelaBasi");
			CheckBoxRelatorioRoupas = Element.Css("#CbRelaRoup");
			CheckBoxRecursoRoteiros = Element.Css("#CbRelaRecurRotei");
			LiberarAll = Element.Css(".selectAll");
			LiberarPrimeiroRoteiro = Element.Css(".selectOne");
			PopCapBaixo = Element.Id("popCapBaixos");
			TableElement = Element.Id("tabelaGrupoNot");
			PopDirProg = Element.Id("popDiretorPrograma");
			PaginaRoetiro = Element.Id("div-roteiro-planejamento");
			TableName = Element.Css(".usuario td[class='left nome']");
			PopUpDestacarCenas = Element.Css("#popFiltroCenasRoteirizadas");
			ListGerarRelatorio = Element.Id("tstGerarRelatorio");
			SubListSelecionarRoteiro = Element.Id("tstSelecionarRoteirosGerarRelatorio");
			ChkCapaSemana = Element.Id("CbCapa");
			ChkRelatorioBasico = Element.Id("CbRelaBasi");
			ChkRecursosRoteiro = Element.Id("CbRelaRecurRotei");
			ChkRelatorioRoupas = Element.Id("CbRelaRoup");
			LiberarUmRoteiro = Element.Css(".selectVertical");
			PopUpRecursosRoteiro = Element.Id("popRecursosDoRoteiro");
			PopUpFrequenciaElenco = Element.Id("popFrequenciaElenco");
			ListAbrirPlanejamento = Element.Id("tstAbrirMapas");
			DropListFrenteMoverRoteiro = Element.Id("filtroFrente_chzn");
		}
		
		//-------------------METODOS-------------------\\
		private void ClickEditarBloquear()
		{
			BtnEditarOrBloquear.EsperarElemento(Browser);
			BtnEditarOrBloquear.Esperar(Browser, 1000);
			BtnEditarOrBloquear.IsElementVisible(Browser);
			if (BtnEditarOrBloquear.GetTexto(Browser).ToLower().Equals("editar"))
			{
				MouseActions.ClickATM(Browser, BtnEditarOrBloquear);
			}
		}

		public void CancelarRoteiro(string data)
		{
            Browser.Abrir(PlanejamentoRoteiroUrl);
            ClickEditarBloquear();
            Browser.Abrir(PlanejamentoRoteiroUrl);
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            //EscolherVisao("Diaria");
            EscolherVisao("Semanal");
			SelecionarPlanejamento();
			SelecionarListCancelar();
			SelecionarRoteirosTodosRoteiros();
			ClicarBtnConfirmarRoteiro();
			PopUpCancelarRoteiro();
			ConfirmarCancelarRoteiro();
		}

		private void ConfirmarCancelarRoteiro()
		{
			var BtnSim = Element.Id("ButtonSim");
			var AlertaPopUp = Element.Id("div-alert-free-html0");

			AlertaPopUp.EsperarElemento(Browser);
			if (Browser.PageSource("Deseja continuar editando os roteiros da produção?"))
				MouseActions.ClickATM(Browser, BtnSim);
			else throw new Exception("elemento não encontrado");
		}

		private void SelecionarListCancelar()
		{
			SubListCancelar.Esperar(Browser, 3000);
			if (SubListCancelar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, SubListCancelar);
		}

		public void AcessarListGrupoNotificacao()
		{
			SelecionarPlanejamento();

			SubListConfiguracoes.EsperarElemento(Browser);
			if (SubListConfiguracoes.IsElementVisible(Browser))
				MouseActions.MouseMoveToElementSML(Browser, SubListConfiguracoes);
				MouseActions.MouseMoveToElementSML(Browser, SubListGrupoNotificacao);
				MouseActions.ClickATM(Browser, SubListGrupoNotificacao);
		}

		public void AcessarListCapitulosBaixos()
		{
			SelecionarPlanejamento();

			SubListConfiguracoes.EsperarElemento(Browser);
			if (SubListConfiguracoes.IsElementVisible(Browser))
				MouseActions.MouseMoveToElementSML(Browser, SubListConfiguracoes);
				MouseActions.MouseMoveToElementSML(Browser, SubListCapitulosBaixos);
				MouseActions.ClickATM(Browser, SubListCapitulosBaixos);
		}

		public void AcessarListDirecaoPrograma()
		{
			SelecionarPlanejamento();

			SubListConfiguracoes.EsperarElemento(Browser);
			if (SubListConfiguracoes.IsElementVisible(Browser))
				MouseActions.MouseMoveToElementSML(Browser, SubListConfiguracoes);
				MouseActions.MouseMoveToElementSML(Browser, SubListDirecaoPrograma);
				MouseActions.ClickATM(Browser, SubListDirecaoPrograma);
		}

		public void ConfigurarNotificacao(string nome, string cargo, string email)
		{
			ClickEditarBloquear();
			AcessarListGrupoNotificacao();
			PreencherGrupoNotificacao(nome, cargo, email);
			SalvarGrupoNotificacao();
		}

		public void ConfigurarCapitulosBaixos(string numeroCapitulo)
		{
			ClickEditarBloquear();
			AcessarListCapitulosBaixos();

			PopCapBaixo.EsperarElemento(Browser);
			if (PopCapBaixo.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputCapitulosBaixos, numeroCapitulo);
				MouseActions.ClickATM(Browser, BtnSalvarCapitulosBaixos);
			}
			else
			{
				throw new Exception("Elemento não está disponível.");
			}
		}

		public void ConfigurarDiretorPrograma(string nomeDiretor)
		{
			ClickEditarBloquear();
			AcessarListDirecaoPrograma();

			PopDirProg.EsperarElemento(Browser);
			if (PopDirProg.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputDirecaoPrograma, nomeDiretor);
				MouseActions.ClickATM(Browser, BtnSalvarDirecaoPrograma);
			}
			else
			{
				throw new Exception("Elemento não está disponível.");
			}
		}

		public void ExcluirNomeGrupoNotificacao(string nome)
		{
			ClickEditarBloquear();
			AcessarListGrupoNotificacao();
			ApagarGrupoNotificacao(nome);
			SalvarGrupoNotificacao();
		}

		private void ApagarGrupoNotificacao(string nome)
		{
			TableElement.EsperarElemento(Browser);
			string textoTable = TableName.GetTexto(Browser);

			BtnExlcuirNomeNotificacao.EsperarElemento(Browser);
			if (textoTable.Equals(nome))
			{
				MouseActions.ClickATM(Browser, BtnExlcuirNomeNotificacao);
			}
		}

		public void CriarPlanejamentoRoteiro(string data, string numeroCapituloCena, string frente)
		{
			//Browser.Abrir(PlanejamentoRoteiroUrl);
			ClickEditarBloquear();
			PreencherDataRoteiro(data);
			EscolherVisao("Diaria");
			ExpandirTodasCenas();
			DragAndDropPrimeiraCenaExterna(numeroCapituloCena, frente);
			LiberarRoteiro();
		}

		public void SalvarPlanejamento()
		{
			//ClickEditarBloquear();
			ClicarConfigPlanejamentoRoteiro();
			EditarPlanejamentoRoteiro();
			PreencherDetalhesPlanejamentoRoteiro();
			ClicarBtnOK();
			PopUpAtencaoPlanejamentoRoteiroSIM();
			MenuSalvarPlanejamento();
		}

		private void PreencherGrupoNotificacao(string nome, string cargo, string email)
		{
			TableElement.EsperarElemento(Browser);
			if (TableElement.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNomeUsuario, nome);
			AutomatedActions.SendDataATM(Browser, InputCargo, cargo);
			AutomatedActions.SendDataATM(Browser, InputEmail, email);
		}

		private void SalvarGrupoNotificacao()
		{
			BtnSalvarGrupoNotificacao.EsperarElemento(Browser);
			if (BtnSalvarGrupoNotificacao.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarGrupoNotificacao);
		}

		//private void PopUpAtencaoRoteiro()
		//{
		//	var BtnSimPopUpRoteiro = Element.Css("#ButtonSim");
		//	BtnSimPopUpRoteiro.EsperarElemento(Browser);
		//	if (Browser.PageSource("Este roteiro está com o status Liberado no sistema."))
		//	{
		//		MouseActions.ClickATM(Browser, BtnSimPopUpRoteiro);
		//	}
		//}

		private void ExpandirTodasCenas()
		{
			BtnExpandirCenas.EsperarElemento(Browser);
            BtnExpandirCenas.Esperar(Browser, 2000);
            if (BtnExpandirCenas.IsElementVisible(Browser))
            {
                BtnExpandirCenas.IsClickable(Browser);
                MouseActions.ClickATM(Browser, BtnExpandirCenas);
            }
		}

		private void MenuSalvarPlanejamento()
		{
			SelecionarPlanejamentoListSalvar();
			AtencaoPopUpSalvar(nomePlanejamento);
			AtencaoPopUpConfirmacao();
		}

		private void ClicarConfigPlanejamentoRoteiro()
		{
			var Config = Element.Css("img[class='ractions']");
			Config.EsperarElemento(Browser);
			if (Config.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, Config);
			}
		}

		private void EditarPlanejamentoRoteiro()
		{
			var TelaEdit = Element.Css(".roteiroAdiv");
			TelaEdit.EsperarElemento(Browser);
			if (TelaEdit.IsElementVisible(Browser))
			{
				var EditarRoteiro = Element.Xpath("//a[text()='Editar']");
				MouseActions.ClickATM(Browser, EditarRoteiro);
			}
		}

		private void PreencherDetalhesPlanejamentoRoteiro()
		{
			var HoraSaida = Element.Css("input[class='tstSaidaDetalhe field']");
			var HoraInicio = Element.Css("input[class='tstInicioGravacaoDetalhe field']");
			var HoraRefeicao = Element.Css("input[class='tstLimiteRefeicaoDetalhe field']");
			var InputDirecaoFrente = Element.Css(".odd td[colspan='7'] input");
			var RecadoGerente = Element.Css("td[colspan='7'] textarea");
			HoraSaida.EsperarElemento(Browser);
			if (HoraSaida.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, HoraSaida, "09:00");
				AutomatedActions.SendDataATM(Browser, HoraInicio, "10:00");
				AutomatedActions.SendDataATM(Browser, HoraRefeicao, "13:00");
				AutomatedActions.SendDataATM(Browser, InputDirecaoFrente, FakeHelpers.FirstName());
				AutomatedActions.SendDataATM(Browser, RecadoGerente, FakeHelpers.FullName());
			}
		}

		private void ClicarBtnOK()
		{
			var BtnOk = Element.Xpath("//div[15]//button[1]/span[text()='OK']");
			BtnOk.EsperarElemento(Browser);
			if (BtnOk.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnOk);
			}
		}

		public void CriarPlanejamentoRoteiroDuasCenas(string data, string numeroCapituloCena1, string numeroCapituloCena2, string frente)

		{
			Browser.Abrir(PlanejamentoRoteiroUrl);
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
            ExpandirCenasDeRoteiro();
			DragAndDropPrimeiraCenaExterna(numeroCapituloCena1, frente);
			PaginaRoetiro.Esperar(Browser, 1500);
            DragAndDropSegundaCena(numeroCapituloCena2);
            PaginaRoetiro.Esperar(Browser, 700);
            LiberarRoteiro();
		}

		//----------------------------------------DESTACAR CENA------------------------------------\\
		public void DestacarCena(string data, string tipoDestacar, string texto)
		{
			//Browser.RefreshPage();
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
			SelecionarPlanejamentoDestacarCena();
			PreencherCampoDestacarCena(tipoDestacar, texto);
			SelecionarDestacarCena();
		}

		public void DestacarPersonagem(string data, string texto)
		{
			Browser.RefreshPage();
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
			SelecionarPlanejamentoDestacarCena();
			PreencherCampoPersonagem(texto);
			SelecionarDestacarCena();
		}

		private void PreencherCampoPersonagem(string texto)
		{
			PopUpDestacarCenas.EsperarElemento(Browser);
			if (PopUpDestacarCenas.IsElementVisible(Browser))
			{
				var InputDestacarPersonagem = Element.Xpath("//*[contains(.,'Personagem')]/div[contains(@id,'sel')]//input");
				AutomatedActions.SendDataATM(Browser, InputDestacarPersonagem, texto);
				KeyboardActions.Enter(Browser, InputDestacarPersonagem);
			}
		}

		private void PreencherCampoDestacarCena(string tipoDestacar, string texto)
		{
			//Legenda: filtroCenas | filtroTipos | filtroCenarios | ID DINAMICO - PERSONAGEM | filtroStatus | filtroPeriodoDoDia
			PopUpDestacarCenas.EsperarElemento(Browser);
			if (PopUpDestacarCenas.IsElementVisible(Browser))
			{
				var InputDestacarCenas = Element.Css("div[id='" + tipoDestacar + "_chzn'] input");
				AutomatedActions.SendDataATM(Browser, InputDestacarCenas, texto);
				KeyboardActions.Enter(Browser, InputDestacarCenas);
			}
		}

		private void SelecionarDestacarCena()
		{
			if (BtnDestacar.IsClickable(Browser))
			{
				MouseActions.ClickATM(Browser, BtnDestacar);
			}
		}
		private void SelecionarPlanejamentoDestacarCena()
		{
			ListPlanejamento.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, ListPlanejamento);

			if (SubListDestacarCenas.IsElementVisible(Browser))
			{
				MouseActions.MouseMoveToElementSML(Browser, SubListDestacarCenas);
				MouseActions.ClickATM(Browser, SubListDestacarCenas);
			}
			else
			{
				throw new Exception("Elemento não está disponível.");
			}
		}

		public void LiberarRoteiro()
		{
			SelecionarPlanejamentoListLiberado();
			SelecionarRoteirosTodosRoteiros();
			ClicarBtnConfirmarRoteiro();
			CancelarNotificacao();
		}

		public void LiberarRoteiroNaoLiberado()
		{
			SelecionarPlanejamentoListLiberado();
			SelecionarRoteirosPrimeiroRoteiro();
			ClicarBtnConfirmarRoteiro();
			CancelarNotificacao();
		}

		private void NaoLiberarRoteiro()
		{
			SelecionarPlanejamentoListNaoLiberado();
			SelecionarRoteirosTodosRoteiros();
			ClicarBtnConfirmarRoteiro();
		}

		private void PopUpAtencaoPlanejamentoRoteiroSIM()
		{
			var PopUpAtencao = Element.Id("div-alert-free-html0");
			PopUpAtencao.EsperarElemento(Browser);
            BtnPopUpSIM.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnPopUpSIM);

            //if (Browser.PageSource("Editando ele você estará reabrindo-o, deseja confirmar esta ação?") || Browser.PageSource("Deseja continuar editando os roteiros da produção?"))
			//{
			//	MouseActions.ClickATM(Browser, BtnPopUpSIM);
			//}
			//else throw new Exception("Elemento não encontrado");
		}
		public void LiberarRoteiroDuasFrentes()
		{
			SelecionarPlanejamentoListLiberado();
			SelecionarRoteirosTodosRoteiros();
			ClicarBtnConfirmarRoteiro();
			CancelarNotificacaoAlertaPDS();
		}

		private void SelecionarRoteirosTodosRoteiros()
		{
			LiberarAll.EsperarElemento(Browser);
			LiberarAll.Esperar(Browser, 2000);
			if (LiberarAll.IsElementVisible(Browser))
			{
				LiberarAll.IsClickable(Browser);
				MouseActions.ClickATM(Browser, LiberarAll);
			}
			else throw new ElementoNaoEncontrado("Elemento " + LiberarAll + " não encontrado");
		}

		private void SelecionarRoteirosPrimeiroRoteiro()
		{
			LiberarPrimeiroRoteiro.EsperarElemento(Browser);
			LiberarPrimeiroRoteiro.Esperar(Browser, 500);
			if (LiberarPrimeiroRoteiro.IsElementVisible(Browser))
			{
				LiberarPrimeiroRoteiro.IsClickable(Browser);
				MouseActions.ClickATM(Browser, LiberarPrimeiroRoteiro);
			}
			else throw new ElementoNaoEncontrado("Elemento " + LiberarPrimeiroRoteiro + " não encontrado");
		}

		private void ClicarBtnConfirmarRoteiro()
		{
			BtnConfirmarRoteiro.EsperarElemento(Browser);
			if (BtnConfirmarRoteiro.IsElementVisible(Browser))
			{
				BtnConfirmarRoteiro.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnConfirmarRoteiro);
			}
			else throw new ElementoNaoEncontrado("Elemento " + BtnConfirmarRoteiro + " não encontrado");		
		}

		private void CancelarNotificacaoAlertaPDS()
		{
			var Popup = Element.Css("#popNotificacao");
			var BtnCancelarEmail = Element.Xpath("//div[13]//button[2]/span[text()='Cancelar']");

			BtnPopUpSIM.EsperarElemento(Browser);
			if (Browser.PageSource("As seguintes cenas possuem cenários não associados ao PDS. "))
			{
				MouseActions.ClickATM(Browser, BtnPopUpSIM);
			}

			else BtnCancelarEmail.IsElementVisible(Browser);
			{
				BtnCancelarEmail.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, BtnCancelarEmail);
			}
		}

		private void CancelarNotificacao()
		{
			var Popup = Element.Css("#popNotificacao");
			var BtnCancelarEmail = Element.Xpath("//div[13]//button[2]/span[text()='Cancelar']");

            Popup.EsperarElemento(Browser);
            Popup.Esperar(Browser, 2000);
			if (BtnCancelarEmail.IsElementVisible(Browser))
			{
				BtnCancelarEmail.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnCancelarEmail);
			}
			else throw new Exception("Elemento de Cancelar não encontrado");
		}

		private void SelecionarPlanejamentoListLiberado()
		{
			SelecionarPlanejamento();
			SubListCompartilhar.EsperarElemento(Browser);
			if (SubListCompartilhar.IsElementVisible(Browser))
			{
				SubListCompartilhar.IsClickable(Browser);
				MouseActions.MouseMoveToElementSML(Browser, SubListCompartilhar);

				SubListLiberado.IsElementVisible(Browser);
				MouseActions.MouseMoveToElementSML(Browser, SubListLiberado);
				MouseActions.ClickATM(Browser, SubListLiberado);
			}
			else throw new Exception("elemento Selecionar Planejamento Liberado não encontrado");
		}

		private void SelecionarPlanejamentoListNaoLiberado()
		{
			SelecionarPlanejamento();
			SubListCompartilhar.EsperarElemento(Browser);
			if (SubListCompartilhar.IsElementVisible(Browser))
			{
				SubListCompartilhar.IsClickable(Browser);
				MouseActions.MouseMoveToElementSML(Browser, SubListCompartilhar);

				SubListNaoLiberado.IsElementVisible(Browser);
				MouseActions.MouseMoveToElementSML(Browser, SubListNaoLiberado);
				MouseActions.ClickATM(Browser, SubListNaoLiberado);
			}
			else throw new Exception("elemento Selecionar Planejamento Não Liberado não encontrado");
		}

		private void SelecionarPlanejamentoListSalvar()
		{
			SelecionarPlanejamento();
			SubListSalvar.EsperarElemento(Browser);
			if (SubListSalvar.IsElementVisible(Browser))
			{
				SubListSalvar.IsClickable(Browser);
				MouseActions.ClickATM(Browser, SubListSalvar);
			}
			else throw new Exception("elemento Selecionar Planejamento Salvar não encontrado");
		}

		private void AtencaoPopUpSalvar(string nomePlanejamento)
		{
			var InputPopUpAtencao = Element.Id("txtDialogNomeMapa");
			InputPopUpAtencao.EsperarElemento(Browser);
			if (Browser.PageSource("Digite um nome para esta versão do planejamento:"))
			{
				AutomatedActions.SendDataATM(Browser, InputPopUpAtencao, nomePlanejamento = FakeHelpers.FirstName());
			}

			var BtnOkPopupAtencao = Element.Xpath("//div[29]//button[1]//span[text()='Ok']");
			MouseActions.ClickATM(Browser, BtnOkPopupAtencao);
		}

		private void AtencaoPopUpConfirmacao()
		{
			var BtnNaoPopupConfirmacao = Element.Css("#ButtonNao");
			BtnNaoPopupConfirmacao.EsperarElemento(Browser);
			if (Browser.PageSource("Deseja continuar editando os roteiros da produção?"))
			{
				MouseActions.ClickATM(Browser, BtnNaoPopupConfirmacao);
			}
			else throw new Exception("elemento Popup Confirmação não encontrado");
		}

		private void PopUpCancelarRoteiro()
		{
			//var BtnOk = Element.Xpath("//div[24]//button[1]//span[text()='OK']");
            var BtnOk = Element.Xpath("//div[@aria-labelledby='ui-id-23']//button/span[text()='OK']");

            if (Browser.PageSource("Justifique o cancelamento do roteiro"))
			{
				AutomatedActions.SendDataATM(Browser, InputPopUpCancelamento, "cancelar");
				MouseActions.ClickATM(Browser, BtnOk);
			}
			else throw new Exception("elemento Popup Cancelar não encontrado");
		}

		public void EscolherVisao(string tempoVisao)
		{
			//Legenda: Diaria | Semanal | Mensal
			var RadioButtonVisao = Element.Css("#tstTrocaVisao" + tempoVisao + "");

			RadioButtonVisao.EsperarElemento(Browser);
            RadioButtonVisao.Esperar(Browser, 2000);
            RadioButtonVisao.IsClickable(Browser);
            if (RadioButtonVisao.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, RadioButtonVisao);
			}
			else throw new Exception("elemento Escolher Visão não encontrado");
		}

		public void PreencherDataRoteiro(string data)
		{
			InputInicioCalendarioRoteiro.EsperarElemento(Browser);
			if (InputInicioCalendarioRoteiro.IsElementVisible(Browser))
			{
				InputInicioCalendarioRoteiro.IsClickable(Browser);
				AutomatedActions.SendDataATM(Browser, InputInicioCalendarioRoteiro, data);
				//AutomatedActions.SendDataATM(Browser, InputInicioCalendarioRoteiro, CalendarioHelper.ObterDataFutura(1));
				KeyboardActions.Tab(Browser, InputInicioCalendarioRoteiro);
			}
			else throw new Exception("elemento Preencher Data Roteiro não encontrado");
		}

		private void DragAndDropPrimeiraCenaExterna(string numeroCapituloCena, string frente)
		{
			//Legenda¹: Colocar o número cap/cena para pega-lo.
			//Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
			var CapituloCenaExterna = Element.Xpath("//div[@class='cena ui-draggable ttooltip amarelo claro'][contains(.,'" + numeroCapituloCena + "')]");
			var Frente = Element.Xpath("//td[@class='tstRoteiroOuSlot frenteslot ui-droppable'][" + frente + "]");

			CapituloCenaExterna.EsperarElemento(Browser);
			CapituloCenaExterna.IsElementVisible(Browser);
			if (CapituloCenaExterna.IsClickable(Browser))
			{
				Frente.IsElementVisible(Browser);
			Frente.IsClickable(Browser);
			MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
			}
			else throw new Exception("elemento DragAndDrop Primeira cena Externa não encontrado");
		}

		private void DragAndDropPrimeiraCenaEstudio(string numeroCapituloCena, string frente)
		{
			//Legenda¹: Colocar o número cap/cena para pega-lo.
			//Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
			var CapituloCenaEstudio = Element.Xpath("//div[@class='cena ui-draggable ttooltip azul claro'][contains(.,'" + numeroCapituloCena + "')]");
			var Frente = Element.Xpath("//td[@class='tstRoteiroOuSlot frenteslot ui-droppable'][" + frente + "]");

			CapituloCenaEstudio.EsperarElemento(Browser);
			CapituloCenaEstudio.IsElementVisible(Browser);
			if (CapituloCenaEstudio.IsClickable(Browser))
			{
				Frente.IsElementVisible(Browser);
				Frente.IsClickable(Browser);

				MouseActions.MouseDragAndDropSML(Browser, CapituloCenaEstudio, Frente);

				//EsperarRoteiroHabilitar();
			}
			else throw new Exception("elemento DragAndDrop Primeira cena Estudio não encontrado");
		}

		private void EsperarRoteiroHabilitar()
		{
			var roteiroHabilitado = Element.Css("div[class='rnumber numeroRoteiroVermelho']");
			if (roteiroHabilitado.IsElementVisible(Browser))
			{
				roteiroHabilitado.EsperarElemento(Browser);
				roteiroHabilitado.IsClickable(Browser);
			}
			else throw new Exception("elemento Roteiro Habilitar não encontrado");
		}

		private void DragAndDropSegundaCena(string numeroCapituloCena)
		{
			var CapituloCena = Element.Xpath("//div//span[@class='textoCena'][text()='" + numeroCapituloCena + "']");
			var SegundoCampoAlvo = Element.Css("div[class='rscenes']");

			CapituloCena.Esperar(Browser, 1000);
			CapituloCena.EsperarElemento(Browser);
			CapituloCena.IsClickable(Browser);
			if (SegundoCampoAlvo.IsClickable(Browser))
			{
				SegundoCampoAlvo.IsClickable(Browser);
				MouseActions.MouseDragAndDropSML(Browser, CapituloCena, SegundoCampoAlvo);
			}
			else throw new Exception("elemento não encontrado");
		}

		public void ExcluirRoteiro()
		{
			Browser.Abrir(PlanejamentoRoteiroUrl);

			ClickEditarBloquear();
			AcessarListGrupoNotificacao();
		}

		//----------------------------------------GERAR RELATORIO DE CENA------------------------------------\\
		public void GerarRelatorioCenas()
		{
			ClickEditarBloquear();
			ClicarBtnGerarRelatorioCenas();
		}

		public void GerarRelatorioCapaSemanaGravacao()
		{
			ClickEditarBloquear();
			EscolherVisao("Semanal");
			AcessarListSelecionarRoteiro();
			SelecionarRoteirosAll();
			SelecionarChkCapaSemana();
			ClicarBtnGerarRelatorio();
		}

		public void GerarRelatorioBasico()
		{
			ClickEditarBloquear();
			EscolherVisao("Semanal");
			AcessarListSelecionarRoteiro();
			SelecionarRoteirosAll();
			SelecionarChkRelatorioBasico();
			ClicarBtnGerarRelatorio();
		}

		public void GerarRecursosRoteiro()
		{
			ClickEditarBloquear();
			EscolherVisao("Semanal");
			AcessarListSelecionarRoteiro();
			SelecionarRoteirosAll();
			SelecionarChkRecursosRoteiro();
			ClicarBtnGerarRelatorio();
		}

		public void GerarRelatorioRoupa()
		{
			ClickEditarBloquear();
			EscolherVisao("Semanal");
			AcessarListGeracaoRelatorio();
			PopUpCheckRelatorioRoupas();
			PopUpGerar();
		}

		public void GerarRelatorioAll()
		{
			ClickEditarBloquear();
			EscolherVisao("Semanal");
			AcessarListGeracaoRelatorio();
			PopUpGeracaoRelatorioAll();
			PopUpGerar();
		}

		public void SelecionarUmRoteiro()
		{
			EscolherVisao("Semanal");
			AcessarListSelecionarRoteiro();
			SelecionarApenasUmRoteiro();
			SelecionarChkCapaSemana();
			ClicarBtnGerarRelatorio();
		}

		public void SelecionarTodosRoteiros()
		{
			EscolherVisao("Semanal");
			AcessarListSelecionarRoteiro();
			SelecionarRoteirosAll();
			SelecionarChkCapaSemana();
			ClicarBtnGerarRelatorio();
		}

		private void ClicarBtnGerarRelatorioCenas()
		{
			BtnGerarRelatorioCenas.EsperarElemento(Browser);
			if (BtnGerarRelatorioCenas.IsClickable(Browser))
				MouseActions.ClickATM(Browser, BtnGerarRelatorioCenas);
		}

		private void PopUpGeracaoRelatorioAll()
		{
			PopUpCheckCapaSemana();
			PopUpCheckRelatorioBasico();
			PopUpCheckRelatorioRoupas();
		}

		private void PopUpCheckCapaSemana()
		{
			ChkCapaSemana.EsperarElemento(Browser);
			if (!ChkCapaSemana.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkCapaSemana);
		}

		private void PopUpCheckRelatorioBasico()
		{
			ChkRelatorioBasico.EsperarElemento(Browser);
			if (!ChkRelatorioBasico.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkRelatorioBasico);
		}

		private void PopUpCheckRelatorioRoupas()
		{
			ChkRelatorioRoupas.EsperarElemento(Browser);
			if (!ChkRelatorioRoupas.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkRelatorioRoupas);
		}

		private void PopUpGerar()
		{
			var BtnGerar = Element.Xpath("//button//span[text()='Gerar']");
			BtnGerar.EsperarElemento(Browser);
			if (BtnGerar.IsClickable(Browser))
				MouseActions.ClickATM(Browser, BtnGerar);
		}

		private void SelecionarPlanejamento()
		{
			ListPlanejamento.EsperarElemento(Browser);
			if (ListPlanejamento.IsElementVisible(Browser))
			{
				ListPlanejamento.IsClickable(Browser);
				MouseActions.ClickATM(Browser, ListPlanejamento);
			}
		}

		private void AcessarListSelecionarRoteiro()
		{
			SelecionarPlanejamento();
			if (ListGerarRelatorio.IsClickable(Browser))
			{
				MouseActions.MouseMoveToElementSML(Browser, ListGerarRelatorio);
				MouseActions.ClickATM(Browser, SubListSelecionarRoteiro);
			}
		}

		private void AcessarListGeracaoRelatorio()
		{
			SelecionarPlanejamento();
			if (ListGerarRelatorio.IsClickable(Browser))
				MouseActions.ClickATM(Browser, ListGerarRelatorio);
		}

		private void SelecionarRoteirosAll()
		{
			LiberarAll.EsperarElemento(Browser);
			if (LiberarAll.IsClickable(Browser))
				MouseActions.ClickATM(Browser, LiberarAll);
		}

		private void SelecionarApenasUmRoteiro()
		{
			LiberarUmRoteiro.EsperarElemento(Browser);
			if (LiberarUmRoteiro.IsClickable(Browser))
				MouseActions.ClickATM(Browser, LiberarUmRoteiro);
		}

		private void SelecionarChkCapaSemana()
		{
			ChkCapaSemana.EsperarElemento(Browser);
			if (!ChkCapaSemana.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkCapaSemana);
		}

		private void SelecionarChkRelatorioBasico()
		{
			ChkRelatorioBasico.EsperarElemento(Browser);
			if (!ChkRelatorioBasico.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkRelatorioBasico);
		}

		private void SelecionarChkRecursosRoteiro()
		{
			ChkRecursosRoteiro.EsperarElemento(Browser);
			if (!ChkRecursosRoteiro.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkRecursosRoteiro);
		}

		private void ClicarBtnGerarRelatorio()
		{
			BtnGerarRelatorio.EsperarElemento(Browser);
			if (BtnGerarRelatorio.IsClickable(Browser))
				MouseActions.ClickATM(Browser, BtnGerarRelatorio);
		}

		public void FecharDetalhesCena()
		{
			var BtnFechar = Element.Xpath("//div[@class='ui-dialog-buttonset']//button[1]//span[text()='Fechar']");
			BtnFechar.EsperarElemento(Browser);
			if (BtnFechar.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnFechar);
			}
		}

		public override void Navegar()
		{
			Browser.Abrir(PlanejamentoRoteiroUrl);
			Browser.PageLoad();
		}

        private void ExpandirCenasDeRoteiro()
        {
            var expandirPath = Element.Css("img[src='/SGP/Images/seta_expandir.png']");
            expandirPath.EsperarElemento(Browser);
            expandirPath.Esperar(Browser, 2000);
            expandirPath.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, expandirPath);
        }

        private void EsperarLoadPage()
        {
            var espera = Element.Css("<div class='loader'>");
            espera.IsNotElementVisible(Browser);
        }

        private void Filtrar(string campo, string filtro)
		{
			if (BtnFiltrarCenas.IsElementVisible(Browser))
			{
				//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
				var CampoTipo = Element.Xpath("//*[@id='filtro" + campo + "_chzn']//input");
                EsperarLoadPage();

                BtnFiltrarCenas.EsperarElemento(Browser);
                BtnFiltrarCenas.Esperar(Browser, 2000);
                BtnFiltrarCenas.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, BtnFiltrarCenas);
				CampoTipo.EsperarElemento(Browser);
                CampoTipo.Esperar(Browser, 2000);
                CampoTipo.IsElementVisible(Browser);
                AutomatedActions.SendDataEnterATM(Browser, CampoTipo, filtro);
				ClicarBtnBuscarFiltro();

                ExpandirCenasDeRoteiro();
            }
		}

		public void FiltrarCenasRoteirizaveisPersonagem(string filtro)
		{
			ClickEditarBloquear();
			BtnFiltrarCenas.EsperarElemento(Browser);
			if (BtnFiltrarCenas.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnFiltrarCenas);
				InputCampoPersonagem.IsElementVisible(Browser);
				AutomatedActions.SendDataEnterATM(Browser, InputCampoPersonagem, filtro);
				ClicarBtnBuscarFiltro();
			}
		}

		private void ClicarBtnBuscarFiltro()
		{
			BtnBuscar.EsperarElemento(Browser);
			if (BtnBuscar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnBuscar);
		}

		public void FiltrarCenasRoteirizaveisTipo(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("Tipos", filtro);
		}

		public void FiltrarCenasRoteirizaveisCenarioLocacao(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("Cenarios", filtro);

		}

		public void FiltrarCenasRoteirizaveisCapitulo(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("Capitulos", filtro);
		}

		public void FiltrarCenasRoteirizaveisStatus(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("Status", filtro);
		}

		public void FiltrarCenasRoteirizaveisClassificacao(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("Classificacoes", filtro);
		}

		public void FiltrarCenasRoteirizaveisCategoria(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("Categorias", filtro);
		}

		public void FiltrarCenasRoteirizaveisPeriodoDia(string filtro)
		{
			//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
			ClickEditarBloquear();
			Filtrar("PeriodoDoDia", filtro);
		}

		public void VisualizarRelatorioCenas(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioComCenaRoteirizar(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioCapaDaSemanaDeGravacao(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioBasicoRoteiroDeGravacao(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioDeRoupas(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRecursosDosRoteiros(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioComTodasAsOpcoes(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioComApenasUmRoteiroSelecionado(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void VisualizarRelatorioComTodosOsRoteirosSelecionados(string texto, string caminho)
		{
			PDFHelpers.GetTextPDF(Browser, texto, caminho);
			DeletePDF.DeletarPDF(Browser, caminho);
		}

		public void ValidarPlanejamentoRoteiro(string planejamentoRoteiro)
		{
			var RoteiroCompartilhado =
				Element.Xpath("//div[@class='unselectable roteiro semanal ui-droppable compartilhado' or @class='unselectable roteiro semanal ui-droppable liberado']");
			RoteiroCompartilhado.EsperarElemento(Browser);
			Assert.IsTrue(RoteiroCompartilhado.IsElementVisible(Browser));
			Thread.Sleep(2000);
		}


		//---------------CRIAR FRENTE EXTERNA---------------\\
		public void CriarFrenteExterna(string data, string numeroCapituloCena, string frente)
		{
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaExterna(numeroCapituloCena, frente);
		}

		//---------------CRIAR FRENTE ESTUDIO---------------\\
		public void CriarFrenteEstudio(string data, string numeroCapituloCena, string frente)
		{
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaEstudio(numeroCapituloCena, frente);
        }

		//---------------INCLUIR RECURSOS ROTEIRO--------------\\
		public void IncluirRecursoRoteiro(string data, string opcao, string texto)
		{
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);

			ClicarBtnRoldanaRoteiro();
			OpcaoRoldana(opcao);
			PreencherRercusosRoteiro(texto);
			ClicarBtnOKRercursosRoteiro();
			PopUpAtencaoLiberarRoteiro();
			LiberarRoteiro();
		}

		private void ClicarBtnRoldanaRoteiro()
		{
			BtnRoldanaRoteiro.EsperarElemento(Browser);
			if (BtnRoldanaRoteiro.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnRoldanaRoteiro);
		}

		private void OpcaoRoldana(string opcao)
		{
			//Legenda: Botão LINK: "Editar" | "Documentos"...
			var Opcao = Element.Link(opcao);

			Opcao.IsElementVisible(Browser);
			if (Opcao.IsClickable(Browser))
				MouseActions.ClickATM(Browser, Opcao);
		}

		private void PreencherRercusosRoteiro(string texto)
		{
			PopUpRecursosRoteiro.EsperarElemento(Browser);
			if (PopUpRecursosRoteiro.IsElementVisible(Browser))
				JsActions.JavaScript(Browser, "$('div[contenteditable]').text('"+texto+"');");
		}

		private void ClicarBtnOKRercursosRoteiro()
		{
			var BtnOK = Element.Xpath("//div[16]//button//span[text()='OK']");

			BtnOK.EsperarElemento(Browser);
			if (BtnOK.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnOK);
		}

		private void PopUpAtencaoLiberarRoteiro()
		{
			var BtnSIMPopUpAtencao = Element.Id("ButtonSim");

			BtnSIMPopUpAtencao.EsperarElemento(Browser);
			if (Browser.PageSource("Editando ele você estará reabrindo-o, deseja confirmar esta ação?"))
				MouseActions.ClickATM(Browser, BtnSIMPopUpAtencao);
		}

		//---------------MOVER ROTEIRO PARA OUTRO DIA--------------\\
		public void MoverRoteiroParaOutroDia(string data,  string opcao, string numeroFrente, string dataFutura)
		{
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
			
			ClicarBtnRoldanaRoteiro();
			OpcaoRoldana(opcao);

			EscolherFrenteMoverRoteiro(numeroFrente);
			EscolherDataMoverRoteiro(dataFutura);
			SelecionarMousePopUpRoteiro();
			ClicarBtnConfirmarEsperarDataAtiva();
            EscolherVisao("Semanal");
            //ClicarBtnConfirmarMoverRoteiro();
        }

		public void VoltarDataAtualRoteiro(string data, string opcao, string numeroFrente, string dataAtual)
		{
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);

			ClicarBtnRoldanaRoteiro();
			OpcaoRoldana(opcao);

			EscolherFrenteMoverRoteiro(numeroFrente);
			EscolherDataMoverRoteiro(dataAtual);
			SelecionarMousePopUpRoteiro();
			ClicarBtnConfirmarEsperarVoltarDataAtual();
		}

		private void EscolherFrenteMoverRoteiro(string numeroFrente)
		{
			//legenda: FRENTE 1 = 0 | FRENTE 2 = 1..
			var TipoFrente = Element.Xpath("//li[@id='filtroFrente_chzn_o_" + numeroFrente + "']");

			DropListFrenteMoverRoteiro.EsperarElemento(Browser);
			if (DropListFrenteMoverRoteiro.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, DropListFrenteMoverRoteiro);
			TipoFrente.IsElementVisible(Browser);
			MouseActions.ClickATM(Browser, TipoFrente);

			DropListFrenteMoverRoteiro.EsperarElemento(Browser);
		}

		private void EscolherDataMoverRoteiro(string dataFutura)
		{
			//legenda: colocar apenas o número da data.
			var EscolherData = Element.Xpath("//div[@id='popSelecaoDataRoteiro']//td[@data-handler='selectDay']//a[text()='"+ dataFutura + "']");
			EscolherData.EsperarElemento(Browser);
			if (EscolherData.IsElementVisible(Browser))
			{
				MouseActions.ClickMouseMoveToElementSML(Browser, EscolherData);
			}
		}

		private void ClicarBtnConfirmarEsperarVoltarDataAtual()
		{
			var FicarAtivo = Element.Xpath("//a[@class='ui-state-default ui-state-highlight ui-state-active' or @class='ui-state-default ui-state-highlight ui-state-active ui-state-hover']");

			FicarAtivo.Esperar(Browser, 1500);
			if (FicarAtivo.IsElementVisible(Browser))
			{
				ClicarBtnConfirmarMoverRoteiro();
			}
		}
		private void SelecionarMousePopUpRoteiro()
		{
			var Mover = Element.Id("popSelecaoDataRoteiro");

			Mover.Esperar(Browser, 2000);
			Mover.EsperarElemento(Browser);
			if (Mover.IsElementVisible(Browser))
			{
				MouseActions.MouseMoveToElementSML(Browser, Mover);
			}
			else throw new Exception("Elemento não está visível");
		}

		private void ClicarBtnConfirmarEsperarDataAtiva()
		{
			var FicarAtivo = Element.Xpath("//a[@class='ui-state-default ui-state-active' or @class='ui-state-default ui-state-active ui-state-hover']");

			FicarAtivo.Esperar(Browser, 1500);
			if (FicarAtivo.IsElementVisible(Browser))
			{
				ClicarBtnConfirmarMoverRoteiro();
			}
			else throw new Exception("elemento não é visível");
		}


		private void ClicarBtnConfirmarMoverRoteiro()
		{
			var BtnConfirmarMoverRoteiro = Element.Xpath("//div[@aria-labelledby='ui-id-20']//button//span[text()='Confirmar']");

			BtnConfirmarMoverRoteiro.EsperarElemento(Browser);
			if (BtnConfirmarMoverRoteiro.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnConfirmarMoverRoteiro);
			}

			else throw new Exception("elemento não visível");
		}

		//-----------COMPARTILHAR PLANEJAMENTO NAO LIBERADO-------------\\
		public void CriarPlanejamentoRoteiroNaoLiberado(string data, string numeroCapituloCena, string frente)
		{
			ClickEditarBloquear();
			PreencherDataRoteiro(data);
			EscolherVisao("Diaria");
			ExpandirTodasCenas();
			DragAndDropPrimeiraCenaExterna(numeroCapituloCena, frente);
			NaoLiberarRoteiro();
			PopUpAtencaoPlanejamentoRoteiroSIM();
		}

		//---------------INCLUIR FREQUENCIA ELENCO--------------\\
		public void IncluirFrequenciaElenco(string data, string opcao, string inicioJornada, string inicioRefeicao, string terminoRefeicao, string terminoJornada)
		{
			ClickEditarBloquear();
			EscolherVisao("Semanal");
			PreencherDataRoteiro(data);
			ClicarBtnRoldanaRoteiro();
			OpcaoRoldana(opcao);
			PreencherFrequenciaElenco(inicioJornada, inicioRefeicao, terminoRefeicao, terminoJornada);
			ClicarBtnSalvarFrequenciaElenco();
		}

		private void PreencherFrequenciaElenco(string inicioJornada, string inicioRefeicao, string terminoRefeicao, string terminoJornada)
		{
			PopUpFrequenciaElenco.EsperarElemento(Browser);
			if (InputInicioJornada.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputInicioJornada, inicioJornada);
				AutomatedActions.SendDataATM(Browser, InputInicioRefeicao, inicioRefeicao);
				AutomatedActions.SendDataATM(Browser, InputFimRefeicao, terminoRefeicao);
				AutomatedActions.SendDataATM(Browser, InputFimJornada, terminoJornada);
			}
		}

		private void ClicarBtnSalvarFrequenciaElenco()
		{
			var BtnOk = Element.Xpath("//div[6]//button//span[text()='Salvar']");
			BtnOk.EsperarElemento(Browser);
			if (BtnOk.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnOk);
		}

		//-------------------EXCLUIR VERSAO PLANEJAMENTO------------------\\
		public void ExcluirVersaoPlanejamento()
		{
			ClickEditarBloquear();
			SelecionarPlanejamento();
			SelecionarAbrirPlanejamento();
			ClicarBtnExcluirCarregamentoPlanejamento();
			PopUpAtencaoPlanejamentoRoteiroSIM();
		}

		//private void PopUpAtencaoVersaoPlanejamento()
		//{
		//	var BtnSIM = Element.Css("#ButtonSim span");
		//	if (Browser.PageSource("Confirma a exclusão desta versão do planejamento?"))
		//		MouseActions.ClickATM(Browser, BtnSIM);
		//}

		private void ClicarBtnExcluirCarregamentoPlanejamento()
		{
			var BtnLixeira = Element.Xpath("//*[@id='tabelaMapasCarregados']//img");
			BtnLixeira.EsperarElemento(Browser);
			if (BtnLixeira.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnLixeira);
		}

		private void SelecionarAbrirPlanejamento()
		{
			ListAbrirPlanejamento.EsperarElemento(Browser);
			if (ListAbrirPlanejamento.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, ListAbrirPlanejamento);
		}

		//---------------VERIFICAÇÕES---------------\\
		public void VerificarCriacaoFrente()
		{
			var CampoFrente = Element.Css("td[class='frenteHeader frenteAzul']");

			CampoFrente.EsperarElemento(Browser);
			CampoFrente.IsElementVisible(Browser);
		}

		public void VerificarRecursosRoteiro(string opcao, string texto)
		{
			ClicarBtnRoldanaRoteiro();
			OpcaoRoldana(opcao);

			var CampoValidar = Element.Css("div[contenteditable]");

			CampoValidar.EsperarElemento(Browser);
			string validation = CampoValidar.GetTexto(Browser).Trim();

			Assert.AreEqual(validation, texto);
		}

		public void VerificarFrequenciaElenco(string mensagem)
		{
			var alerta = Element.Css("div[class='toast-message']");
			alerta.EsperarElemento(Browser);

			string validation = alerta.GetTexto(Browser).Trim();
			Assert.AreEqual(validation, mensagem);
		}

		//-------------------VERIFICACOES-------------------\\
		public void VerificarPaginaPlanejamento(string validacao)
		{
			var divPlanejamento = Element.Css("div[class='div1']");
			string pegarText = divPlanejamento.GetTexto(Browser).Trim();

			divPlanejamento.EsperarElemento(Browser);
			Assert.AreEqual(pegarText, validacao);

			divPlanejamento.Esperar(Browser, 500);
		}
		public void VerificarFiltroCenas(string numeroCapituloCena)
		{
			var CampoCenas = Element.Xpath("//span[@class='textoCena'][text()='" + numeroCapituloCena + "']");
            EsperarLoadPage();
            CampoCenas.EsperarElemento(Browser);
			if (CampoCenas.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, CampoCenas);
			}
		}

		public void VerificarMensagem(string mensagem)
		{
			PaginaRoetiro.Esperar(Browser, 500);
			var Mensagem = Element.Css(".toast-message");
			string pegaTextoMensagem = Mensagem.GetTexto(Browser);
			Assert.AreEqual(pegaTextoMensagem, mensagem);
		}

		public void VerificarCancelarRoteiro()
		{
			var PainelVazio = Element.Xpath("//*[@id='div-roteiro-planejamento']//tr[2]/td[2]");
			if (PainelVazio.IsElementVisible(Browser))
			{
				Assert.IsTrue(true);
			}
		}

		public void VerificarDestaqueCena(string numeroCapituloCena)
		{
			var ElementoAtualCor = Element.Xpath
				("//*[@class='cena ttooltip amarelo claro encontradaclaro'][contains(.,'" + numeroCapituloCena + "')]");

			var corElementoFundo = ElementoAtualCor.GetCssValue(Browser, "background-color");

			ConvertColors.ConvertRgbaToHex(corElementoFundo);
			string colorHex = ConvertColors.ConvertRgbaToHex(corElementoFundo).ToLower();

			ElementoAtualCor.EsperarElemento(Browser);
			Assert.AreEqual("#8c6de8", colorHex);
		}
		public void VerificarDestaqueCenaStatus(string numeroCapituloCena)
		{
			var ElementoAtualCor = Element.Xpath
				("//*[@class='cena ttooltip amarelo claro posRoteirizadaNaoGravada encontradaclaro'][contains(.,'" + numeroCapituloCena + "')]");

			var corElementoFundo = ElementoAtualCor.GetCssValue(Browser, "background-color");

			ConvertColors.ConvertRgbaToHex(corElementoFundo);
			string colorHex = ConvertColors.ConvertRgbaToHex(corElementoFundo).ToLower();

			Assert.AreEqual("#8c6de8", colorHex);
		}
		public void VerificarExclusãoCarregamentoPlanejamento(string mensagem)
		{
			ClicarBtnCancelarCarregarversaoPlanejamento();
			SelecionarPlanejamento();
			SelecionarAbrirPlanejamento();

			var Alerta = Element.Css("#div-alert-free-html0");
			Alerta.EsperarElemento(Browser);
			string validation = Alerta.GetTexto(Browser).Trim();
			Assert.AreEqual(validation, mensagem);
		}

		private void ClicarBtnCancelarCarregarversaoPlanejamento()
		{
			var BtnCancelar = Element.Css("div[aria-labelledby='ui-id-24'] button span");
			BtnCancelar.EsperarElemento(Browser);
			if (BtnCancelar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnCancelar);
		}

		public void ValidarMoverRoteiro(string data)
		{
			var VerificarRoteiro = Element.Css(".rTop");
			var Week = Element.Css("td[class='week']");

			Week.EsperarElemento(Browser);
			PreencherDataRoteiro(data);

			VerificarRoteiro.EsperarElemento(Browser);
			if (VerificarRoteiro.IsElementVisible(Browser))
			{
				string validation = VerificarRoteiro.GetTexto(Browser);
				Assert.IsTrue(true, validation);
			}
		}

		public void VerificarPlanejamentoNaoLiberado()
		{
			var NumeroRoteiroNaoLiberado = Element.Css(".rnumber");
			NumeroRoteiroNaoLiberado.EsperarElemento(Browser);
			if (NumeroRoteiroNaoLiberado.IsElementVisible(Browser))
			{
				string validation = NumeroRoteiroNaoLiberado.GetCssValue(Browser, "color");
				string convert = ConvertColors.ConvertRgbaToHex(validation);
				Assert.AreEqual(convert, "#626262");
			}
		}
	}
}