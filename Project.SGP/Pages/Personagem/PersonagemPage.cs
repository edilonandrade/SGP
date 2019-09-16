using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Project.SGP.Pages
{
	public class PersonagemPage : PageBase
	{
		private string PersonagemUrl { get; }

		//Input
		private Element InputAtor { get; }
		private Element InputSituacao { get; }
		private Element InputDescricaoPlanejada { get; }
		private Element InputCaracterizacao { get; }
		private Element InputBloco { get; }
		private Element InputDataPeriodo { get; }
		private Element InputNovaRoupa { get; }
		private Element InputPersonagem { get; }
		private Element InputNomePersonagem { get; }
		private Element InputTipoPersonagem { get; }
		private Element InputTempoPreparacaoPersonagem { get; }
		private Element InputNomeAtor { get; }
		private Element InputPeriodoInicial { get; }
		private Element InputPeriodoFinal { get; }
		private Element InputJustificativa { get; }
		private Element InputListRoupa { get; }

		//Button
		private Element BtnConfirmarExclusaoRoupa { get; }
		private Element BtnExcluirRoupa { get; }
		private Element BtnSalvarFichaContinuidade { get; }
		private Element BtnNovaRoupaFichaContinuidade { get; }
		private Element BtnFichaContinuidade { get; }
		private Element BtnFiltrar { get; }
		private Element BtnEditarPersonagem { get; }
		private Element BtnEditarIndisponibilidade { get; }
		private Element BtnSalvarPersonagem { get; }
		private Element BtnExcluirPersonagem { get; }
		private Element BtnNovoPersonagem { get; }
		private Element BtnSalvarIndisponibilidade { get; }
		private Element BtnExcluirIndisponibilidade { get; }
		private Element BtnSalvarPersonagemIndisponibilidade { get; }

		//Others
		private Element SelectTipoPersonagem { get; }
		private Element TelaPersonagem { get; }
		private Element ContatoAtor { get; }
		private Element ModalNovoPersonagem { get; }
		private Element TextoTabelaNomePersonagem { get; }
		private Element BtnPersonagemOk { get; }
		private Element CadastrarIndisponibilidade { get; }
		private Element SelecTipoPersonagem { get; }
		private Element TableIndisponibilidade { get; }
		private Element DropListRoupa { get; }

		//Check box
		private Element ChkPeriodoDia { get; }
		private Element ChkAllDay { get; }
		private Element ChkSegunda { get; }
		private Element ChkTerca { get; }
		private Element ChkQuarta { get; }
		private Element ChkQuinta { get; }
		private Element ChkSexta { get; }
		private Element ChkSabado { get; }
		private Element ChkDomingo { get; }


		public PersonagemPage(IBrowser browser,
			string personagemUrl) : base(browser)
		{
			PersonagemUrl = personagemUrl;

			//Button
			BtnConfirmarExclusaoRoupa = Element.Css("button[data-bb-handler='confirm']");
			BtnExcluirRoupa = Element.Id("lnkExcluirRoupa");
			BtnSalvarFichaContinuidade = Element.Id("btnSave");
			BtnFichaContinuidade = Element.Css("a[title='Ficha']");
			BtnEditarPersonagem = Element.Css("a[title='Editar personagem']");
			BtnSalvarIndisponibilidade = Element.Css("button[data-bb-handler='b2']");
			BtnEditarIndisponibilidade = Element.Css("a[title='Editar indisponibilidade']");
			BtnSalvarPersonagemIndisponibilidade = Element.Css("div[class='modal-footer'] > button[data-bb-handler='1']");
			BtnSalvarPersonagem = Element.Css("button[data-bb-handler='1']");
			BtnExcluirIndisponibilidade = Element.Css("a[title='Excluir indisponibilidade']");
			BtnNovaRoupaFichaContinuidade = Element.Id("lnkNovaRoupa");
			BtnFiltrar = Element.Id("btnSubmit");
			BtnPersonagemOk = Element.Css("button[data-bb-handler='confirm']");
			BtnNovoPersonagem = Element.Id("btnNovoPersonagem");
			BtnExcluirPersonagem = Element.Css("a[title='Excluir personagem']");

			//Others
			SelectTipoPersonagem = Element.Id("ddlTipo");
			CadastrarIndisponibilidade = Element.Id("novaIndisponibilidade");
			TelaPersonagem = Element.Css("a[class='btnEditar lnkNome']");
			ContatoAtor = Element.Css("a[class='link-dados-ator']");
			ModalNovoPersonagem = Element.Css(".modal-body");
			SelecTipoPersonagem = Element.Id("selCargo_chosen");
			TextoTabelaNomePersonagem = Element.Css(".col-md-12 td a[class='btnEditar lnkNome']");
			TableIndisponibilidade = Element.Css("table[class='table table-indisponibilidade']");
			DropListRoupa = Element.Css("#selListaRoupa_chosen a");

			//Input
			InputAtor = Element.Id("inputAtor");
			InputSituacao = Element.Id("txtSituacao");
			InputDescricaoPlanejada = Element.Id("txtDescricao");
			InputCaracterizacao = Element.Id("txtCaracterizacao");
			InputBloco = Element.Id("txtBloco");
			InputDataPeriodo = Element.Id("txtDataPedido");
			InputNovaRoupa = Element.Id("txtNRoupa");
			InputPeriodoInicial = Element.Id("txtDataInicioInd");
			InputNomeAtor = Element.Id("txtNomeAtorTOP");
			InputPeriodoFinal = Element.Id("txtDataFimInd");
			InputTipoPersonagem = Element.Css("#selCargo_chosen input");
			InputJustificativa = Element.Id("txtJustificativaInd");
			InputPersonagem = Element.Id("inputPersonagem");
			InputNomePersonagem = Element.Id("txtNomePersonagem");
			InputTempoPreparacaoPersonagem = Element.Id("txtTempoPreparacao");
			InputListRoupa = Element.Css("#selListaRoupa_chosen input");

			//Check box
			ChkPeriodoDia = Element.Css("label[for='chkTodoDia']");
			ChkAllDay = Element.Css("label[for='chkTodosDiasSemana']");
			ChkSegunda = Element.Css("label[for='chkSegunda']");
			ChkTerca = Element.Css("label[for='chkTerca']");
			ChkQuarta = Element.Css("label[for='chkQuarta']");
			ChkQuinta = Element.Css("label[for='chkQuinta']");
			ChkSexta = Element.Css("label[for='chkSexta']");
			ChkSabado = Element.Css("label[for='chkSabado']");
			ChkDomingo = Element.Css("label[for='chkDomingo']");
		}

		//-------------------METODOS-------------------\\
		public void ExcluirNovoPersonagem(string nomePersonagem)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(nomePersonagem);
			ExcluirPersonagem();
			ClicarPopUpPersonagem();
			VerificarAlertaPersonagem();
		}

		public void ExcluirPersonagemCadastrado(string nomePersonagem)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(nomePersonagem);
			ExcluirPersonagem();
			ClicarPopUpPersonagem();
		}

		public void ExcluirNovaIndisponibilidade(string nomePersonagem)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(nomePersonagem);
			ClicarBtnEditarPersonagem();
			ExcluirIndisponibilidade();
			SalvarPersonagem();
		}

		public void SelecionarContatoAtor()
		{
			ContatoAtor.EsperarElemento(Browser);
			if(ContatoAtor.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, ContatoAtor);
			}
		}

		public void EscolherPersonagem(string nomePersonagem)
		{
			InputPersonagem.EsperarElemento(Browser);
			if (InputPersonagem.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputPersonagem, nomePersonagem);
				KeyboardActions.Tab(Browser, InputPersonagem);
			}

			ClicarBtnFiltrar();
		}

		private void ClicarBtnFiltrar()
		{
			BtnFiltrar.EsperarElemento(Browser);
			if (BtnFiltrar.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnFiltrar);
			}
		}

		private void ExcluirPersonagem()
		{
			BtnExcluirPersonagem.EsperarElemento(Browser);
			if (BtnExcluirPersonagem.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnExcluirPersonagem);
				BtnExcluirPersonagem.Esperar(Browser, 500);
			}
		}

		private void ClicarPopUpPersonagem()
		{
			BtnPersonagemOk.Esperar(Browser, 500);
			BtnPersonagemOk.EsperarElemento(Browser);
			if (Browser.PageSource("Deseja excluir o personagem?"))
			{
				MouseActions.ClickATM(Browser, BtnPersonagemOk);
			}
		}

		public void CriarNovaIndisponibilidade(string nomePersonagem)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(nomePersonagem);
			ClicarBtnEditarPersonagem();
			ClicarNovaIndisponbilidade();
			NovaIndisponibilidade();
			SelecionarCheckBoxDias();
			SalvarIndisponibilidade();
			SalvarPersonagemIndisponibilidade();
		}

		private void ClicarNovaIndisponbilidade()
		{
			CadastrarIndisponibilidade.Esperar(Browser, 500);
			CadastrarIndisponibilidade.EsperarElemento(Browser);
			if (CadastrarIndisponibilidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, CadastrarIndisponibilidade);
			}
		}

		private void AvisoPopup()
		{
			var BtnSalvarAviso = Element.Css("button[data-bb-handler='b1']");
			BtnSalvarAviso.EsperarElemento(Browser);
			if (Browser.PageSource("Existem Roteiros/Rascunhos que utilizam os itens cadastrados/alterados, revisar os seguinte(s) itens:"))
			{
				MouseActions.ClickATM(Browser, BtnSalvarAviso);
			}
		}
		private void SalvarIndisponibilidade()
		{
			BtnSalvarIndisponibilidade.EsperarElemento(Browser);
			if (BtnSalvarIndisponibilidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarIndisponibilidade);
			}
		}

		private void SalvarPersonagemIndisponibilidade()
		{
			BtnSalvarPersonagemIndisponibilidade.EsperarElemento(Browser);
			if (BtnSalvarPersonagemIndisponibilidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarPersonagemIndisponibilidade);
			}
		}
		private void EditarNovaIndisponibilidade()
		{
			InputPeriodoInicial.Esperar(Browser, 200);
			InputPeriodoInicial.EsperarElemento(Browser);
			if (Browser.PageSource("Indisponibilidade de ator"))
			{
				InputPeriodoInicial.IsClickable(Browser);
				AutomatedActions.SendDataATM(Browser, InputPeriodoInicial, CalendarioHelper.ObterDataFutura(1));
				KeyboardActions.Tab(Browser, InputPeriodoInicial);
			}
		}

		private void NovaIndisponibilidade()
		{
			InputPeriodoInicial.Esperar(Browser, 500);
			InputPeriodoInicial.EsperarElemento(Browser);
			if (Browser.PageSource("Indisponibilidade de ator"))
			{
				InputPeriodoInicial.IsClickable(Browser);
				AutomatedActions.SendDataATM(Browser, InputPeriodoInicial, CalendarioHelper.ObterDataAtual());
				KeyboardActions.Tab(Browser, InputPeriodoInicial);

				SelecionarSemData();

				ChkPeriodoDia.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, ChkPeriodoDia);
				AutomatedActions.SendDataATM(Browser, InputJustificativa, "Nova Indisponibilidade");
			}
		}

		private void SelecionarSemData()
		{
			var checkSemDataTermino = Element.Css("label[for='chkIndFim']");

			checkSemDataTermino.EsperarElemento(Browser);
            checkSemDataTermino.Esperar(Browser, 2000);
            if (checkSemDataTermino.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, checkSemDataTermino);
			}
		}

		private void SelecionarCheckBoxDias()
		{
			ChkAllDay.EsperarElemento(Browser);
            ChkAllDay.Esperar(Browser, 2000);
            ChkAllDay.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, ChkAllDay);
			MouseActions.ClickATM(Browser, ChkSegunda);
			MouseActions.ClickATM(Browser, ChkTerca);
			MouseActions.ClickATM(Browser, ChkQuarta);
			MouseActions.ClickATM(Browser, ChkQuinta);
			MouseActions.ClickATM(Browser, ChkSexta);
			MouseActions.ClickATM(Browser, ChkSabado);
		}

		public void ExcluirIndisponibilidade()
		{
			BtnExcluirIndisponibilidade.EsperarElemento(Browser);
			if (BtnExcluirIndisponibilidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnExcluirIndisponibilidade);
			}
		}

		//-----------CRIAR NOVO PERSONAGEM-----------------\\
		public void CriarNovoPersonagem(string nomePersonagem, string nomeAtor, string tipoPersonagem)
		{
			Browser.Abrir(PersonagemUrl);
			ClicarNovoPersonagem();

			ModalNovoPersonagem.EsperarElemento(Browser);
			if (ModalNovoPersonagem.IsElementVisible(Browser))
			{
				PreencherNovoPersonagem(nomePersonagem, nomeAtor);
				SelecioarTipoPersonagem(tipoPersonagem);
				SalvarPersonagem();
			}
		}

		public void SalvarECriarNovoPersonagem(string nomePersonagem, string nomeAtor, string tipoPersonagem)
		{
			ClicarNovoPersonagem();
			ModalNovoPersonagem.EsperarElemento(Browser);
			if (ModalNovoPersonagem.IsElementVisible(Browser))
			{
				PreencherNovoPersonagem(nomePersonagem, nomeAtor);
				SelecioarTipoPersonagem(tipoPersonagem);
				SalvarCriarNovoPersonagem();

				ModalNovoPersonagem.IsElementVisible(Browser);
			}
		}

		public void EditarPersonagem(string nomePersonagem, string editarNomePersonagem)
		{
			EscolherPersonagem(nomePersonagem);

			ClicarBtnEditarPersonagem();
			EditarNomePersonagem(editarNomePersonagem);
			SalvarPersonagem();
		}

		public void EditarIndisponibilidade(string nomePersonagem)
		{
			EscolherPersonagem(nomePersonagem);

			ClicarBtnEditarPersonagem();
			ClicarEditarIndisponibilidade();
			EditarNovaIndisponibilidade();
			SalvarIndisponibilidade();
			SalvarPersonagemIndisponibilidade();
		}

		private void ClicarBtnEditarPersonagem()
		{
			BtnEditarPersonagem.Esperar(Browser, 500);
			BtnEditarPersonagem.EsperarElemento(Browser);
			if (BtnEditarPersonagem.IsElementVisible(Browser))
			{
				BtnEditarPersonagem.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnEditarPersonagem);
			}
		}
	
		private void ClicarNovoPersonagem()
		{
			BtnNovoPersonagem.Esperar(Browser, 1000);
			BtnNovoPersonagem.EsperarElemento(Browser);
			if (BtnNovoPersonagem.IsElementVisible(Browser))
			{
				BtnNovoPersonagem.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnNovoPersonagem);
			}
		}

		private void PreencherNovoPersonagem(string nomePersonagem, string nomeAtor)
		{
			InputNomePersonagem.EsperarElemento(Browser);
			if (InputNomePersonagem.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputNomePersonagem, nomePersonagem);
				AutomatedActions.SendDataATM(Browser, InputNomeAtor, nomeAtor);
				KeyboardActions.ArrowDonw(Browser, InputNomeAtor);
				KeyboardActions.Enter(Browser, InputNomeAtor);
			}
		}

		private void EditarNomePersonagem(string editarNomePersonagem)
		{
			InputNomePersonagem.Esperar(Browser, 300);
			InputNomePersonagem.EsperarElemento(Browser);
			if (InputNomePersonagem.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputNomePersonagem, editarNomePersonagem);
			}
		}

		private void ClicarEditarIndisponibilidade()
		{
			BtnEditarIndisponibilidade.Esperar(Browser, 300);
			BtnEditarIndisponibilidade.EsperarElemento(Browser);
			if (BtnEditarIndisponibilidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnEditarIndisponibilidade);
			}
		}

		private void SelecioarTipoPersonagem(string tipoPersonagem)
		{
			SelecTipoPersonagem.EsperarElemento(Browser);
			if (SelecTipoPersonagem.IsElementVisible(Browser))
			{
				AutomatedActions.TypingListATM(Browser, SelecTipoPersonagem, InputTipoPersonagem, tipoPersonagem);
			}
		}

		private void PreencherTempoPreparacaoPersonagem(string tempoPreparacao)
		{
			InputTempoPreparacaoPersonagem.EsperarElemento(Browser);
			if (InputTempoPreparacaoPersonagem.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputTempoPreparacaoPersonagem, tempoPreparacao);
			}
		}

		private void SalvarPersonagem()
		{
			var BtnSalvarPersonagem = Element.Xpath("//button[text()='Salvar Personagem']");
			BtnSalvarPersonagem.EsperarElemento(Browser);
			if (BtnSalvarPersonagem.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarPersonagem);
			}
		}

		private void SalvarCriarNovoPersonagem()
		{
			var BtnSalvarCriarNovoPersonagem = Element.Xpath("//button[text()='Salvar e Criar Novo Personagem']");
			BtnSalvarCriarNovoPersonagem.EsperarElemento(Browser);
			if (BtnSalvarCriarNovoPersonagem.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarCriarNovoPersonagem);
			}
		}


		//---------------CADASTRAR FICHA CONTINUIDADE-------------\\
		public void CadastrarNovaRoupaFichaContinuidade(string nomePersonagem, string numeroCapitulo)
		{
			EscolherPersonagem(nomePersonagem);
			ClicarFichaContinuidade();
			ClicarNovaRoupaFichaContinuidade();
			PreencherDadosNovaRoupa(numeroCapitulo);
			ClicarBtnSalvar();
		}

		public void FichaContinuidadeJaCadastrada(string numeroCapitulo)
		{
			ClicarNovaRoupaFichaContinuidade();
			PreencherDadosNovaRoupa(numeroCapitulo);
			ClicarBtnSalvar();
		}

		public void ExcluirNovaRoupaFichaContinuidade()
		{
			ClicarBtnExcluirRoupa();
			ConfirmarPopUpExclusaoRoupa();
		}

		public void ExcluirRoupa(string nomePersonagem, string nomeRoupa)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(nomePersonagem);
			ClicarFichaContinuidade();
			EscolherRoupa(nomeRoupa);
			ClicarBtnExclusaoRoupa();
			ConfirmarPopUpExclusaoRoupa();
			MensagemRoupaExcluida();
		}

		private void MensagemRoupaExcluida()
		{
			var Alerta = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");
			Alerta.EsperarElemento(Browser);
			Alerta.IsElementVisible(Browser);
		}

		private void EscolherRoupa(string nomeRoupa)
		{
			DropListRoupa.Esperar(Browser, 2000);
			Browser.RefreshPage();
			DropListRoupa.EsperarElemento(Browser);
			DropListRoupa.Esperar(Browser, 1000);
			if (DropListRoupa.IsElementVisible(Browser))
			{
				AutomatedActions.TypingListATM(Browser, DropListRoupa, InputListRoupa, nomeRoupa);
			}
		}

		public void ExcluirRoupaCadastradaEmOutraCenaFichaContinuidade(string nomePersonagem)
		{
			EscolherPersonagem(nomePersonagem);
			ClicarFichaContinuidade();
		}

		private void ClicarFichaContinuidade()
		{
			BtnFichaContinuidade.EsperarElemento(Browser);
			BtnFichaContinuidade.Esperar(Browser, 1000);
			if (BtnFichaContinuidade.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnFichaContinuidade);
			}
		}

		private void ClicarNovaRoupaFichaContinuidade()
		{
			BtnNovaRoupaFichaContinuidade.EsperarElemento(Browser);
			if (BtnNovaRoupaFichaContinuidade.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnNovaRoupaFichaContinuidade);
		}

		private void PreencherDadosNovaRoupa(string numeroCapitulo)
		{
			InputNovaRoupa.EsperarElemento(Browser);
			if (InputNovaRoupa.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputNovaRoupa, numeroCapitulo);
				AutomatedActions.SendDataATM(Browser, InputBloco, "1");
				AutomatedActions.SendDataATM(Browser, InputDataPeriodo, CalendarioHelper.ObterDataFutura(5));
				KeyboardActions.Enter(Browser, InputDataPeriodo);
				AutomatedActions.SendDataATM(Browser, InputSituacao, FakeHelpers.FullName());
				AutomatedActions.SendDataATM(Browser, InputDescricaoPlanejada, FakeHelpers.FullName());
				AutomatedActions.SendDataATM(Browser, InputCaracterizacao, FakeHelpers.FullName());
		}

		private void ClicarBtnSalvar()
		{
			BtnSalvarFichaContinuidade.EsperarElemento(Browser);
			if (BtnSalvarFichaContinuidade.IsElementVisible(Browser))
				BtnSalvarFichaContinuidade.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnSalvarFichaContinuidade);
		}

		private void ClicarBtnExcluirRoupa()
		{
			BtnNovaRoupaFichaContinuidade.EsperarElemento(Browser);
			if (BtnExcluirRoupa.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnExcluirRoupa);
			else
				Browser.RefreshPage();
				BtnExcluirRoupa.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, BtnExcluirRoupa);
		}

		private void ClicarBtnExclusaoRoupa()
		{
			BtnNovaRoupaFichaContinuidade.EsperarElemento(Browser);
			if (!BtnExcluirRoupa.IsElementVisible(Browser))
			{
				Browser.RefreshPage();
			}
			else
			{
				BtnExcluirRoupa.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, BtnExcluirRoupa);
			}

		}

		private void ConfirmarPopUpExclusaoRoupa()
		{
			BtnConfirmarExclusaoRoupa.Esperar(Browser, 500);
			BtnConfirmarExclusaoRoupa.EsperarElemento(Browser);
			if(BtnConfirmarExclusaoRoupa.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnConfirmarExclusaoRoupa);
		}


		//---------------VALIDAR PESQUISA DE PERSONAGEM-------------\\
		public void PesquisarPorAtor(string nomeAtor)
		{
			EscolherAtor(nomeAtor);
		}

		public void PesquisarPorPersonagem(string nomePersonagem)
		{
			EscolherPersonagem(nomePersonagem);
		}

		public void PesquisarPorTipo(string tipoPersonagem)
		{
			EscolherPorTipoPersonagem(tipoPersonagem);
		}

		public void PesquisarPorAtorePersonagem(string nomeAtor, string nomePersonagem)
		{
			EscolherAtorePersonagem(nomeAtor, nomePersonagem);
		}

		public void PesquisarPorTipoePersonagem(string nomeAtor, string nomePersonagem)
		{
			EscolherAtorePersonagem(nomeAtor, nomePersonagem);
		}

		private void EscolherAtorePersonagem(string nomeAtor, string nomePersonagem)
		{
			EscolherAtor(nomeAtor);
			EscolherPersonagem(nomePersonagem);
		}

		public void PesquisarPorTipoPersonagemeNomePersonagem(string tipoPersonagem, string nomePersonagem)
		{
			EscolherPorTipoPersonagem(tipoPersonagem);
			EscolherPersonagem(nomePersonagem);
		}

		public void EscolherAtor(string nomeAtor)
		{
			InputAtor.EsperarElemento(Browser);
			if (InputAtor.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputAtor, nomeAtor);
				KeyboardActions.Tab(Browser, InputAtor);
			}
			
			ClicarBtnFiltrar();
		}

		private void EscolherPorTipoPersonagem(string tipoPersonagem)
		{
			SelectTipoPersonagem.EsperarElemento(Browser);
			if (SelectTipoPersonagem.IsElementVisible(Browser))
				MouseActions.SelectElementATM(Browser, SelectTipoPersonagem, tipoPersonagem);
		}

		public override void Navegar()
		{
			Browser.Abrir(PersonagemUrl);
			Browser.PageLoad();
		}

		//-------------------VERIFICACOES-------------------\\
		public void VerificarIndisponibilidade()
		{
			ClicarBtnEditarPersonagem();
			TableIndisponibilidade.IsElementVisible(Browser);
		}

		public void VerificarAlertaPersonagem()
		{
			var mensagem = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");
			mensagem.EsperarElemento(Browser);
			if (mensagem.IsElementVisible(Browser))
			{
				string alerta = mensagem.GetTexto(Browser);
				Assert.IsTrue(true, alerta);
			}
		}

		public void VerificarNovoPersonagem(string nomePersonagem)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(nomePersonagem);

			TextoTabelaNomePersonagem.EsperarElemento(Browser);
			string validacao = TextoTabelaNomePersonagem.GetTexto(Browser);

			Assert.AreEqual(validacao, nomePersonagem);
		}

		public void VerificarPersonagemEditado(string personagemEditado)
		{
			Browser.Abrir(PersonagemUrl);
			EscolherPersonagem(personagemEditado);

			TextoTabelaNomePersonagem.EsperarElemento(Browser);
			string validacao = TextoTabelaNomePersonagem.GetTexto(Browser);

			Assert.AreEqual(validacao, personagemEditado);
		}

		public void VerificarContatoAtor()
		{
			var TabelaContato = Element.Css("div[class='ator-contato-dialogo campos-ator form-group']");

			TabelaContato.EsperarElemento(Browser);
			TabelaContato.IsElementVisible(Browser);
		}

		public void VerificarNovoPersonagemExcluido()
		{
			var AlertaMensagem = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");

			AlertaMensagem.EsperarElemento(Browser);
			string validacao = AlertaMensagem.GetTexto(Browser);

			Assert.IsTrue(true, validacao);
		}

		public void VerificarNovaIndisponibilidadeExcluida()
		{
			var TableIndisponibilidade = Element.Css("#listaIndisponibilidades");

			ClicarBtnEditarPersonagem();
			TableIndisponibilidade.IsNotElementVisible(Browser);
		}

		public void VerificarCriticaPersonagem()
		{
			var AlertaCritica = Element.Css("div[class='alert alert-danger alert-dismissable alert-util']");

			AlertaCritica.EsperarElemento(Browser);
			string validacao = AlertaCritica.GetTexto(Browser);

			Assert.IsTrue(true, validacao);
		}

		//---------CADASTRAR FICHA CONTINUIDADE-----------\\
		public void VerificarFichaContinuidade()
		{
			var AlertaFichaContinuidade = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");
			string validacao = AlertaFichaContinuidade.GetTexto(Browser).Substring(3);
			Assert.AreEqual(validacao, "Ficha de continuidade salva com sucesso.");
		}

		public void VerificarFichaContinuidadeCadastrada()
		{
			var AlertaFichaContinuidadeCadastrada = Element.Css("div[class='alert alert-danger alert-dismissable alert-util']");
			string validacao = AlertaFichaContinuidadeCadastrada.GetTexto(Browser).Substring(3);
			Assert.AreEqual(validacao, "A ficha de continuidade não foi salva. Contacte o administrador para maiores detalhes.");
		}

		public void VerificarExclusaoRoupaFichaContinuidade()
		{
			var AlertaExclusaoFichaContinuidade = Element.Css("div[class='alert alert-success alert-dismissable alert-util']");

			if (AlertaExclusaoFichaContinuidade.IsElementVisible(Browser))
			{
				string validacao = AlertaExclusaoFichaContinuidade.GetTexto(Browser).Substring(3);
				Assert.AreEqual(validacao, "Roupa excluída com sucesso.");
			}
		}

		public void VerificarBtnExcluirRoupaCadastrada()
		{
			BtnNovaRoupaFichaContinuidade.EsperarElemento(Browser);
			BtnExcluirRoupa.IsNotElementVisible(Browser);
		}

		//---------------VALIDAR PESQUISA DE PERSONAGEM-------------\\
		public void ValidarPesquisa(string pesquisa)
		{
			var ValidarPesquisa = Element.Xpath("//tbody//td[contains(., '"+pesquisa+"')]");

			ValidarPesquisa.EsperarElemento(Browser);
			if (ValidarPesquisa.IsElementVisible(Browser))
				Assert.IsTrue(true, pesquisa);
		}


        //---------------------------------------CRIAR NOVO PERSONAGEM GROT-------------------------------------------------\\
        public void CriarNovoPersonagemGROT(string nomePersonagem, string nomeAtor, string tipoPersonagem)
        {
            Browser.Abrir(PersonagemUrl);
            ClicarNovoPersonagem();

            ModalNovoPersonagem.EsperarElemento(Browser);
            if (ModalNovoPersonagem.IsElementVisible(Browser))
            {
                PreencherNovoPersonagem(nomePersonagem, nomeAtor);
                SelecioarTipoPersonagem(tipoPersonagem);
                SalvarPersonagem();
            }
        }
    }
}
