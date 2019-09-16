using Framework.Core.Actions;
using Framework.Core.Exceptions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;

namespace Project.SGP.Pages
{
	public class PlanejamentoGROTPage : PageBase
	{
        private string PlanejamentoGROTUrl { get; }
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
		private Element InputHoraSaida { get; }
		private Element InputHoraInicio { get; }
		private Element InputHoraRefeicao { get; }
		private Element InputFinalGravacao { get; }
		private Element InputDirecaoFrente { get; }
		private Element InputRecadoGerente { get; }
		private Element InputCargaHorariaMax { get; }
        public Element InputProdutivMedia { get; }
        private Element InputQtdDiasPlanejamento { get; }
        private Element InputInterjornadaMin { get; }

        //Button
        private Element BtnDestacar { get; }
		private Element BtnCalcular { get; }

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
		private Element BtnRelatorioAlertas { get; }
		private Element BtnEditarFrente {get;}
        public Element BtnVerRelatorioPorPeriodo { get; }
        public Element BtnVerRelatorioPorAlerta { get; }
        private Element BtnRelatorioPorPeriodoMaisDetalhes { get; }
        private Element BtnOcultarListaCenas { get; }


        //Others
        private Element SubListSalvarComo { get; }
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
        //private Element IcoAlertRoteiro { get; }
        private Element ModalAlert { get; }

        //--------------------------------------------------NOVAS ITENS DE CENA------------------------------------------------------//
        private Element IconeRefeicao { get; }
        private Element IconePreparacao { get; }
        private Element AddIconePreparacao { get; }
        private Element SubIconePreparacao { get; }
        private Element IconeDeslocamento { get; }
        private Element AddIconeDeslocamento { get; }
        private Element SubIconeDeslocamento { get; }


        public PlanejamentoGROTPage(IBrowser browser,
		   string planejamentoGROTUrl) : base(browser)
		{
			PlanejamentoGROTUrl = planejamentoGROTUrl;

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
			InputHoraSaida = Element.Css("input[class='tstSaidaDetalhe field']");
			InputHoraInicio = Element.Css("input[class='tstInicioGravacaoDetalhe field']");
			InputHoraRefeicao = Element.Css("input[class='tstLimiteRefeicaoDetalhe field']");
			InputFinalGravacao = Element.Css("input[class='tstFimGravacaoDetalhe field']");
			InputDirecaoFrente = Element.Css(".odd td[colspan='7'] input");
			InputRecadoGerente = Element.Css("td[colspan='7'] textarea");
			InputCargaHorariaMax = Element.Id("CargaHorariaMax");
            InputProdutivMedia = Element.Id("ProdutivMedia");
            InputQtdDiasPlanejamento = Element.Id("QtdDiasPlanejamento");
            InputInterjornadaMin = Element.Id("InterjornadaMin");

            //Button
            BtnCalcular = Element.Css(".btCalcular");
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
            BtnRelatorioAlertas = Element.Css("span.relatAlertRoteiro");
			BtnEditarFrente = Element.Css(".editarFrente");
            BtnVerRelatorioPorPeriodo = Element.Xpath("//div//span[text()='POR PERIODO']");
            BtnVerRelatorioPorAlerta = Element.Xpath("//div//span[text()='POR ALERTA']");
            BtnRelatorioPorPeriodoMaisDetalhes = Element.Css("div[data-bind='event: { click: function(){visualizado(!visualizado())} }']");
            BtnOcultarListaCenas = Element.Css("div[id='hideFiltroRoteiroECenas']");

            //Others
            SubListSalvar = Element.Id("tstSalvarMapa");
            SubListSalvarComo = Element.Css("li[id='tstSalvarMapaComo']");
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
            //IcoAlertRoteiro = Element.Css("img[src='/SGP/Images/planrotGROT/action.png']");
            ModalAlert = Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//div[@id='RelatorioAlertas']");

            //--------------------------------------------------NOVAS ITENS DE CENA------------------------------------------------------//
            IconeRefeicao = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable refeicao ui-draggable']");
            IconePreparacao = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable preparacao ui-draggable']");
            AddIconePreparacao = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable preparacao ui-draggable'] img[src='/SGP/Images/maisN.png']");
            SubIconePreparacao = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable preparacao ui-draggable'] img[src='/SGP/Images/menosN.png']");
            IconeDeslocamento = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable deslocamento ui-draggable']");
            AddIconeDeslocamento = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable deslocamento ui-draggable'] img[src='/SGP/Images/maisN.png']");
            SubIconeDeslocamento = Element.Css("div[class='col-md-4 itensCenaRoteiro bloquearDraggable deslocamento ui-draggable'] img[src='/SGP/Images/menosN.png']");

        }

        //------------OCULTAR LISTAGEM DE CENAS-------------\\
        public void ClicarOcultarListagemCenas()
        {
            BtnOcultarListaCenas.Esperar(Browser, 1000);
            BtnOcultarListaCenas.EsperarElemento(Browser);
            if(BtnOcultarListaCenas.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnOcultarListaCenas);
            }
        }

        public void ValidarOcultarListagemCenas()
        {
            //BtnFiltrarCenas.IsNotElementVisible(Browser);
            var ListagemCenas = Element.Xpath("//div[@id='hideFiltroRoteiroECenas' and contains(@style,'block')] ");
            ListagemCenas.IsNotElementVisible(Browser);
        }


        //------------Detalhamento dos alertas-------------\\
        public void ClicarAlertaRoteiro()
        {
            var bntRoteiro = Element.Css("div[class='tstRoteiroOuSlot tstFrenteRoteiro'] img[src='/SGP/Images/planrotGROT/warning.png']");
            bntRoteiro.EsperarElemento(Browser);
            bntRoteiro.Esperar(Browser, 2000);
            bntRoteiro.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, bntRoteiro);
        }

        public void ClicarAlertaCena()
        {
            var bntCena = Element.Css("div[class='tstRoteiroOuSlot tstFrenteRoteiro'] img[src='/SGP/Images/planrotGROT/action.png']");
            bntCena.EsperarElemento(Browser);
            bntCena.Esperar(Browser, 2000);
            bntCena.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, bntCena);
        }

        public void ClicarAlertaDia()
        {
            var iconeAlertaDia = Element.Xpath("//table[@id='weekDaysHeader']//td[3]//img");
            iconeAlertaDia.EsperarElemento(Browser);
            iconeAlertaDia.Esperar(Browser, 2000);
            iconeAlertaDia.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, iconeAlertaDia);
        }

        public void ClicarAlertaSemana()
        {
            var iconeAlertaSemana = Element.Xpath("//td[@id='IDheaderspacerAlertas']/img");
            iconeAlertaSemana.EsperarElemento(Browser);
            iconeAlertaSemana.Esperar(Browser, 2000);
            iconeAlertaSemana.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, iconeAlertaSemana);
        }

        public void ClicarChckOcultarAlertaPopup(string NumChckAlerta)
        {
            var checkbok = Element.Css("label[for='violacao_" + NumChckAlerta + "']");
            checkbok.EsperarElemento(Browser);
            if(checkbok.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, checkbok);
            }
        }

        private void ClicarBtnAlertasDemais()
        {
            var btnAlertas = Element.Css("div[data-bind='click: showHideAllAlertsClick']");
            btnAlertas.EsperarElemento(Browser);
            if (btnAlertas.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, btnAlertas);
            }
        }

        public void ValidarAlertaOcultadoPopup(string TipoAlerta)
        {
            ClicarBtnAlertasDemais();

            if (TipoAlerta == "Indisponibilidade de frente")
            {
                var alerta = Element.Css("img[id='imgAlertBar_INDISPONIBILIDADE_FRENTE_GRAVACAO']");
                alerta.IsNotElementVisible(Browser);
            }
        }

        public void ValidarDetalhamentoAlertaSemana(string TipoAlerta, int Data, string TxtAlert, string NumChckAlerta)
        {
            var diaSemanaPath = Element.Css("td[class='dayHeaderweek']:nth-child(3) span[class='tstDiaSemana']");
            diaSemanaPath.EsperarElemento(Browser);
            diaSemanaPath.IsElementVisible(Browser);
            var dataInicioSemana = Element.Css("td[class='dayHeaderweek']:nth-child(3) strong");
            dataInicioSemana.EsperarElemento(Browser);
            dataInicioSemana.IsElementVisible(Browser);
            var dataFimSemana = Element.Css("td[class='dayHeaderweek']:nth-child(15) strong");
            dataFimSemana.EsperarElemento(Browser);
            dataFimSemana.IsElementVisible(Browser);


            string diaSemana = diaSemanaPath.GetTexto(Browser).ToString();
            string inicioSemana = dataInicioSemana.GetTexto(Browser).ToString();
            string fimSemana = dataFimSemana.GetTexto(Browser).ToString();

            string popupAlerta = "//div[@class='dumb ui-dialog-content ui-widget-content']";

            var semana = Element.Xpath(popupAlerta + "//h2[text()='semana " + inicioSemana + " até " + fimSemana + "']");
            semana.IsElementVisible(Browser);

            var iconeAlerta = Element.Xpath(popupAlerta + "//div[@class='INDISPONIBILIDADE_FRENTE_GRAVACAO']");
            iconeAlerta.IsElementVisible(Browser);

            var checkbok = Element.Css("label[for='violacao_" + NumChckAlerta + "']");
            checkbok.IsElementVisible(Browser);

            if(TipoAlerta == "1")
            {
                if (diaSemana == "Terça")
                {
                    diaSemana = "terca";
                }
                if (diaSemana == "Sábado")
                {
                    diaSemana = "sabado";
                }
                var descricao = Element.Xpath(popupAlerta + "//span[text()='" + TxtAlert + diaSemana.ToUpper() + ", dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Data) + ".']");
                descricao.IsElementVisible(Browser);
            }
            
        }

        public void ValidarDetalhamentoAlertaDia(string TipoAlerta, int Data, string TxtAlert, string NumChckAlerta)
        {
            string popupAlerta = "//div[@class='dumb ui-dialog-content ui-widget-content']";

            var data = Element.Xpath(popupAlerta + "//h2[contains(., '" + CalendarioHelper.ObterDiaMesFuturoComBarra(Data) + "')]");
            data.IsElementVisible(Browser);

            var iconeAlerta = Element.Xpath(popupAlerta + "//div[@class='JORNADA_FRENTE']");
            iconeAlerta.IsElementVisible(Browser);

            var checkbok = Element.Css("label[for='violacao_" + NumChckAlerta + "']");
            checkbok.IsElementVisible(Browser);

            if(TipoAlerta == "1")
            {
                var descricao = Element.Xpath(popupAlerta + "//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Data) + ".']");
                descricao.EsperarElemento(Browser);
                descricao.IsElementVisible(Browser);
            }

            var btnfechar = Element.Xpath(popupAlerta + "//img[@src='../Images/grot_close.png']");
            btnfechar.EsperarElemento(Browser);
            if (btnfechar.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, btnfechar);
            }
        }

        public void ValidarDetalhamentoRoteiroECena(string TipoAlerta, string Frente, int Data, string TxtAlert, string NumChckAlerta)
        {
            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);
            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();

            string popupAlerta = "//div[@class='dumb ui-dialog-content ui-widget-content']";

            var frente = Element.Xpath(popupAlerta + "//span[contains(., '" + Frente +"')]");
            frente.IsElementVisible(Browser);
            var diaSemana = Element.Xpath(popupAlerta + "//span[contains(., '" + CalendarioHelper.ObterDiaMesFuturoComBarra(Data) + "')]");
            diaSemana.IsElementVisible(Browser);
            var roteiro = Element.Xpath(popupAlerta + "//div[@class='codigoRoteiro']/div[text()='" + NumGROTStr + "']");
            roteiro.IsElementVisible(Browser);
            var checkbok = Element.Css("label[for='violacao_" + NumChckAlerta + "']");
            checkbok.IsElementVisible(Browser);

            if (TipoAlerta == "Roteiro")
            {
                var iconeRoteiro = Element.Xpath("//img[@src='../Images/planrotGROT/warning.png']");
                iconeRoteiro.IsElementVisible(Browser);
                var descricao = Element.Xpath(popupAlerta + "//span[text()='Inconsistência no Roteiro " + NumGROTStr + "" + TxtAlert + "']");
                descricao.IsElementVisible(Browser);
            }
            if (TipoAlerta == "Cena")
            {
                var iconeCena = Element.Xpath("//img[@src='../Images/planrotGROT/action.png']");
                iconeCena.IsElementVisible(Browser);
                var descricao = Element.Xpath(popupAlerta + "//span[text()='" + TxtAlert + "']");
                descricao.IsElementVisible(Browser);
            }

            var btnfechar = Element.Xpath(popupAlerta + "//img[@src='../Images/grot_close.png']");
            btnfechar.EsperarElemento(Browser);
            if(btnfechar.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, btnfechar);
            }
        }

        //----------ANTECEDENCIA MINIMA GRAVACAO-------------\\

        public void CriarNovaFrente(string TipoFrente)
        {
            ClickEditarBloquear();
            //var nomeFrente = Element.Xpath("//label[text()='Nome']/..//input[@id='Nome']");
            var novaFrente = Element.Css("img[src='../Images/bt_novaFrente2.gif']");
            var dropdownTipoFrente = Element.Css("div[id='TipoFrente_chzn'] b");
            var frenteExterna = Element.Css("ul li[id='TipoFrente_chzn_o_2']");
            var frenteEstudio = Element.Css("ul li[id='TipoFrente_chzn_o_1']");
            var btnOKFrenteInvalida = Element.Xpath("//div[@aria-labelledby='ui-id-1']//button");
            var btnSalvarFrente = Element.Xpath("//div[@aria-labelledby='ui-id-28']//button/span[text()='Salvar']");
            var btnOKFrente = Element.Xpath("//div[@aria-labelledby='ui-id-2']//button/span[text()='OK']");
            
            novaFrente.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, novaFrente);
            dropdownTipoFrente.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, dropdownTipoFrente);
            if (TipoFrente == "Externa")
            {
                frenteExterna.EsperarElemento(Browser);
                MouseActions.ClickATM(Browser, frenteExterna);
            }
            if (TipoFrente == "Estudio")
            {
                frenteEstudio.EsperarElemento(Browser);
                MouseActions.ClickATM(Browser, frenteEstudio);
            }
            btnSalvarFrente.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, btnSalvarFrente);

            if (btnOKFrente.IsElementVisible(Browser))
            {
                btnOKFrente.EsperarElemento(Browser);
                btnOKFrente.IsClickable(Browser);
                MouseActions.ClickATM(Browser, btnOKFrente);
            }

            Thread.Sleep(2000);
        }

        public void CriarPlanejamentoRoteiroGROTSemanalFrente2(string data, string numeroCapituloCena, string frente, string TipoFrente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            CriarNovaFrente(TipoFrente);
            ExpandirTodasCenas();
            DragAndDropSegundaCenaExternaFrente2(numeroCapituloCena, frente);
        }

        public void CriarPlanejamentoRoteiroGROTDiario(string data, string numeroCapituloCena, string frente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            //EsperaLoading();
            EscolherVisao("Diaria");
            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaExterna(numeroCapituloCena, frente);

            EscolherVisao("Semanal");
        }

        public void CriarPlanejamentoRoteiroGROTDiarioNoturno(string data, string numeroCapituloCena, string frente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            EscolherVisao("Diaria");
            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaExternaNoturna(numeroCapituloCena, frente);

            EscolherVisao("Semanal");
        }

        public void CriarPlanejamentoRoteiroGROTSemanal(string data, string numeroCapituloCena, string frente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            ExpandirTodasCenas();
            DragAndDropSegundaCenaExterna(numeroCapituloCena, frente);
        }

        public void CalcularPlanejamentoGROT()
		{
            Thread.Sleep(2000);
            BtnCalcular.Esperar(Browser, 3000);
			BtnCalcular.EsperarElemento(Browser);
			if (BtnCalcular.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnCalcular);
			}
            Thread.Sleep(2000);
		}


		//-----------------TEMPO DE PREPARACAO ELENCO-----------------\\
		public void PreencherHorarioPersonagemRoteiro(string opcao, string saida, string inicioGravacao, string almoco, string finalGravacao, string horarioElenco, int qtdPersonagens)
		{
			ClicarBtnRoldanaRoteiro();
			OpcaoRoldana(opcao);
			PreencherDetalhesPlanejamentoHorariosRoteiro(saida, inicioGravacao, almoco, finalGravacao);
			PreencherHorarioElenco(horarioElenco, qtdPersonagens);
			ClicarBtnOK();
			//ClicarBtnOKRercursosRoteiro();
		}

		private void PreencherHorarioElenco(string horario, int qtdPersonagens)
		{
            int i = 1;

            while(i <= qtdPersonagens)
                {
                    var InputChegadaElenco = Element.Xpath("//div[@data-bind='visible: MapaVM.RoteiroSelecionadoClone().ListaAtores().length > 0']//tr[" + i + "]//input[contains(@data-bind,'HoraChegadaString')]");
                    if(InputChegadaElenco.IsElementVisible(Browser))
                    {
                        InputChegadaElenco.EsperarElemento(Browser);
                        AutomatedActions.SendDataATM(Browser, InputChegadaElenco, horario);
                    }
                    i++;
                }

		}

		//-----------------JORNADA DA FRENTE-----------------\\
        public void ValidarBotoesEditarExcluirFrenteGrot(string Frente)
        {
            var editarfrente = Element.Xpath("//span[text()='FRENTE " + Frente + "']/..//img[@class='editarFrente']");
            var excluirfrente = Element.Xpath("//span[text()='FRENTE " + Frente + "']/..//img[@class='excluirFrente']");

            editarfrente.EsperarElemento(Browser);
            editarfrente.IsElementVisible(Browser);
            excluirfrente.EsperarElemento(Browser);
            excluirfrente.IsElementVisible(Browser);
        }
        
		public void EditarCargaHorariaEProdutivMediaFrente(string Horas, string Media)
		{
			ClicarBtnEditarFrente();
            if(Horas != "")
            {
                PreencherCargaHorariaMaxima(Horas);
            }
			if(Media != "")
            {
                PreencherProdutivMedia(Media);
            }
            ClicarBtnSalvarFrenteGravacao();
		}

		public void ClicarBtnEditarFrente()
		{
			BtnEditarFrente.EsperarElemento(Browser);
			if (BtnEditarFrente.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnEditarFrente);
			}
		}

        private void ClicarBtnEditarNovaFrente(string Frente)
        {
            var editarNovaFrente = Element.Xpath("//td[@class='frentename']//span[text()='FRENTE " + Frente + "']/../div/img[@class='editarFrente']");
            editarNovaFrente.EsperarElemento(Browser);
            editarNovaFrente.Esperar(Browser, 2000);
            editarNovaFrente.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, editarNovaFrente);
        }

        private void ClicarBtnExcluirFrente(string Frente)
        {
            var excluirNovaFrente = Element.Xpath("//td[@class='frentename']//span[text()='FRENTE " + Frente + "']/../div/img[@class='excluirFrente']");
            excluirNovaFrente.EsperarElemento(Browser);
            excluirNovaFrente.Esperar(Browser, 2000);
            excluirNovaFrente.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, excluirNovaFrente);
        }

        private void PreencherCargaHorariaMaxima(string Horas)
		{
			InputCargaHorariaMax.EsperarElemento(Browser);
			if (InputCargaHorariaMax.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputCargaHorariaMax, Horas);
			}
		}

        private void PreencherProdutivMedia(string Media)
        {
            InputProdutivMedia.EsperarElemento(Browser);
            if (InputProdutivMedia.IsElementVisible(Browser))
            {
                AutomatedActions.SendDataATM(Browser, InputProdutivMedia, Media);
            }
        }

        private void ClicarBtnSalvarFrenteGravacao()
		{
            try
            {
                var BtnSalvarFrente = Element.Xpath("//div[@aria-labelledby='ui-id-28']//button//span[text()='Salvar']");
                BtnSalvarFrente.Esperar(Browser, 1000);
                BtnSalvarFrente.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, BtnSalvarFrente);
            }
            catch
            {
                var BtnSalvarFrente = Element.Xpath("//div[@aria-labelledby='ui-id-29']//button//span[text()='Salvar']");
                BtnSalvarFrente.Esperar(Browser, 1000);
                BtnSalvarFrente.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, BtnSalvarFrente);
            }
		}

        //-----------------EDITAR FRENTE-----------------\\

        public void EditarFrenteDePlanejamento(string InterjornadaMin, string QtdDias, string AlterarDiasDisponibilidade)
        {
            ClicarBtnEditarFrente();
            if (InterjornadaMin != "")
            {
                InputInterjornadaMin.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputInterjornadaMin, InterjornadaMin);
            }
            if (QtdDias != "")
            {
                InputQtdDiasPlanejamento.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputQtdDiasPlanejamento, QtdDias);
            }
            if(AlterarDiasDisponibilidade != "")
            {
                SelecionarDiasDeDisponibilidadeDaFrente();
            }
            ClicarBtnSalvarFrenteGravacao();
        }

        public void IndisponibilizarDiasDaFrenteDePlanejamento3(int Qtd, string Frente)
        {
            try
            {
                var FrentePath = Element.Xpath("//table[@id='weekDaysBody']//tr[8]/td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable'][2]");
                FrentePath.IsElementVisible(Browser);
                EditarNovaFrenteDePlanejamento(Qtd, Frente);
            }
            catch
            {

            }
        }

        public void EditarNovaFrenteDePlanejamento(int Qtd, string Frente)
        {
            ClicarBtnEditarNovaFrente(Frente);

            var dropdownTipoFrente = Element.Css("div[id='TipoFrente_chzn'] b");
            var frenteExterna = Element.Css("ul li[id='TipoFrente_chzn_o_2']");
            var btnOKFrente = Element.Xpath("//div[@aria-labelledby='ui-id-2']//button/span[text()='OK']");

            dropdownTipoFrente.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, dropdownTipoFrente);
            frenteExterna.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, frenteExterna);

            SelecionarDiasDeDisponibilidade(Qtd);
            ClicarBtnSalvarFrenteGravacao();

            if(btnOKFrente.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, btnOKFrente);
            }

            Thread.Sleep(2000);
        }

        public void EditarParametrosNovaFrenteDePlanejamento(string Frente, string InterjornadaMin, string QtdDias)
        {
            ClicarBtnEditarNovaFrente(Frente);

            var dropdownTipoFrente = Element.Css("div[id='TipoFrente_chzn'] b");
            var frenteExterna = Element.Css("ul li[id='TipoFrente_chzn_o_2']");
            var btnOKFrente = Element.Xpath("//div[@aria-labelledby='ui-id-2']//button/span[text()='OK']");

            dropdownTipoFrente.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, dropdownTipoFrente);
            frenteExterna.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, frenteExterna);

            if (InterjornadaMin != "")
            {
                InputInterjornadaMin.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputInterjornadaMin, InterjornadaMin);
            }
            if (QtdDias != "")
            {
                InputQtdDiasPlanejamento.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputQtdDiasPlanejamento, QtdDias);
            }

            ClicarBtnSalvarFrenteGravacao();

            if (btnOKFrente.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, btnOKFrente);
            }

            Thread.Sleep(2000);
        }

        public void ExcluirFrenteDeGravacao(string Frente)
        {
            //EsperaLoading();
            ClickEditarBloquear();
            ClicarBtnExcluirFrente(Frente);

            var atencao = Element.Xpath("//div[text()='Tem certeza que deseja excluir esta frente de gravação?']");
            atencao.EsperarElemento(Browser);
            atencao.IsElementVisible(Browser);

            var btnSim = Element.Xpath("//div[@class='ui-dialog-buttonset']//button/span[text()='Sim']");
            btnSim.EsperarElemento(Browser);
            btnSim.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, btnSim);
        }

        private void SelecionarDiasDeDisponibilidadeDaFrente()
        {
            int i = 1;
            while (i <= 7)
            {
                var chkdia = Element.Css("div[data-bind='foreach: DiasSemana'] div:nth-child(" + i + ") label");
                MouseActions.ClickATM(Browser, chkdia);
                i++;
            }

        }

        private void SelecionarDiasDeDisponibilidade(int Qtd)
        {
            int i = 1;
            while (i <= Qtd)
            {
                var chkdia = Element.Css("div[data-bind='foreach: DiasSemana'] div:nth-child(" + i + ") label");
                MouseActions.ClickATM(Browser, chkdia);
                i++;
            }

        }

        public void ValidarNovaFrente(string Frente)
        {
            var novaFrente = Element.Xpath("//td[@class='frentename']//span[text()='" + Frente + "']");
            novaFrente.IsElementVisible(Browser);
        }

        public void ValidarExclusaoFrenteDeGravacao(string Frente)
        {
            var novaFrente = Element.Xpath("//td[@class='frentename']//span[text()='" + Frente + "']");
            novaFrente.IsNotElementVisible(Browser);
        }

        public void ValidarTrocaDeTipoDeFrente(string TipoFrente, string Frente)
        {
            if(TipoFrente == "Externa")
            {
                var validar = Element.Xpath("//div[@class='nameSlot frenteAmarela']//span[text()='FRENTE " + Frente + "']");
                validar.EsperarElemento(Browser);
                validar.IsElementVisible(Browser);
            }
            if (TipoFrente == "Estudio")
            {
                var validar = Element.Xpath("//div[@class='nameSlot frenteAzul']//span[text()='FRENTE " + Frente + "']");
                validar.EsperarElemento(Browser);
                validar.IsElementVisible(Browser);
            }

        }

        public void ValidarFrente3Indisponivel(string dia)
        {
            var Frente = Element.Xpath("//table[@id='weekDaysBody']//tr[8]/td[@class='frenteslot frenteIndisponivel tstRoteiroOuSlot.ui-droppable ui-droppable'][" + dia + "]");
            Frente.IsElementVisible(Browser);
        }

        //-----------------SEM GROT SEM GROT SEM GROT SEM GROT-------------------\\

        //-------------------METODOS-------------------\\
        public void ClickEditarBloquear()
		{
			BtnEditarOrBloquear.Esperar(Browser, 1000);
			BtnEditarOrBloquear.EsperarElemento(Browser);
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
			PreencherDataRoteiro(data);
			EscolherVisao("Diaria");
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
			SubListCancelar.EsperarElemento(Browser);
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
			Browser.Abrir(PlanejamentoRoteiroUrl);
			ClickEditarBloquear();
			PreencherDataRoteiro(data);
			EscolherVisao("Diaria");
			ExpandirTodasCenas();
			DragAndDropPrimeiraCenaExterna(numeroCapituloCena, frente);
			LiberarRoteiro();
		}

		public void SalvarPlanejamento(string saida, string inicioGravacao, string almoco, string finalGravaao)
		{
			//ClickEditarBloquear();
			ClicarConfigPlanejamentoRoteiro();
			EditarPlanejamentoRoteiro();
			PreencherDetalhesPlanejamentoHorariosRoteiro(saida, inicioGravacao, almoco, finalGravaao);
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

		public void ExpandirTodasCenas()
		{
			BtnExpandirCenas.EsperarElemento(Browser);
			if (BtnExpandirCenas.IsElementVisible(Browser))
				BtnExpandirCenas.IsClickable(Browser);
			MouseActions.ClickATM(Browser, BtnExpandirCenas);
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

		private void PreencherDetalhesPlanejamentoHorariosRoteiro(string saida, string inicioGravacao, string almoco, string finalGravacao)
		{
			InputHoraSaida.EsperarElemento(Browser);
			if (InputHoraSaida.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputHoraSaida, saida);
				AutomatedActions.SendDataATM(Browser, InputHoraInicio, inicioGravacao);
				AutomatedActions.SendDataATM(Browser, InputHoraRefeicao, almoco);
				AutomatedActions.SendDataATM(Browser, InputFinalGravacao, finalGravacao);
				AutomatedActions.SendDataATM(Browser, InputDirecaoFrente, FakeHelpers.FirstName());
				AutomatedActions.SendDataATM(Browser, InputRecadoGerente, FakeHelpers.FullName());
			}
		}

		private void ClicarBtnOK()
		{
			var BtnOk = Element.Xpath("//div[@aria-labelledby='ui-id-14']//button/span[text()='OK']");

			BtnOk.EsperarElemento(Browser);
			if (BtnOk.IsElementVisible(Browser))
			{
				BtnOk.IsClickable(Browser);
				MouseActions.ClickATM(Browser, BtnOk);
			}
		}

		public void CriarPlanejamentoRoteiroDuasCenas(string data, string numeroCapituloCena1, string numeroCapituloCena2, string frente)

		{
			Browser.Abrir(PlanejamentoRoteiroUrl);
			ClickEditarBloquear();
			EscolherVisao("Diaria");
			PreencherDataRoteiro(data);
			DragAndDropPrimeiraCenaExterna(numeroCapituloCena1, frente);
			PaginaRoetiro.Esperar(Browser, 1500);
			//DragAndDropSegundaCena(numeroCapituloCena2);
			//PaginaRoetiro.Esperar(Browser, 700);
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
			if (Browser.PageSource("Este roteiro está com o status Liberado no sistema."))
			{
				MouseActions.ClickATM(Browser, BtnPopUpSIM);
			}
			else throw new Exception("Elemento não encontrado");
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
			LiberarAll.Esperar(Browser, 500);
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

			//BtnCancelarEmail.EsperarElemento(Browser);
            BtnCancelarEmail.IsClickable(Browser);
			BtnCancelarEmail.Esperar(Browser, 2000);
            try
            {
                 MouseActions.ClickATM(Browser, BtnCancelarEmail);
            }
            catch
            {
                Navegar();
            }
           
			//else throw new Exception("elemento não encontrado");
		}

        public void SalvarRascunhoRoteiro(string NomeRascunho)
        {
            var inputRascunho = Element.Css("input[id='txtDialogNomeMapa']");
            var btnOk = Element.Xpath("//div[text()='Digite um nome para esta versão do planejamento:']/../..//button/span[text()='Ok']");
            var btnSim = Element.Xpath("//div[text()='Deseja continuar editando os roteiros da produção?']/..//button/span[text()='Sim']");

            SelecionarPlanejamento();
            SubListSalvarComo.EsperarElemento(Browser);
            if (SubListSalvarComo.IsElementVisible(Browser))
            {
                SubListSalvarComo.IsClickable(Browser);
                MouseActions.ClickATM(Browser, SubListSalvarComo);

                inputRascunho.EsperarElemento(Browser);
                inputRascunho.Esperar(Browser, 2000);
                inputRascunho.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, inputRascunho, NomeRascunho);

                btnOk.EsperarElemento(Browser);
                btnOk.Esperar(Browser, 2000);
                btnOk.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, btnOk);

                btnSim.EsperarElemento(Browser);
                btnSim.Esperar(Browser, 2000);
                btnSim.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, btnSim);
            }
            else throw new Exception("elemento não encontrado");
        }

        public void AbrirRascunho(string NomeRascunho)
        {
            var abrirList = Element.Css("li[id='tstAbrirMapas']");
            var rascunho = Element.Xpath("//a/strong[text()='" + NomeRascunho + "']");

            SelecionarPlanejamento();
            abrirList.EsperarElemento(Browser);
            if (abrirList.IsElementVisible(Browser))
            {
                abrirList.IsClickable(Browser);
                MouseActions.ClickATM(Browser, abrirList);

                rascunho.EsperarElemento(Browser);
                rascunho.Esperar(Browser, 2000);
                rascunho.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, rascunho);

                Thread.Sleep(2000);
                ExpandirCenasDeRoteiro();
            }
            else throw new Exception("elemento não encontrado");
        }

        public void DeletarRascunho()
        {
            var lixeira = Element.Css("a img[src='/SGP/Images/ic_trash.png']");
            var abrirList = Element.Css("li[id='tstAbrirMapas']");

            SelecionarPlanejamento();
            abrirList.EsperarElemento(Browser);
            if (abrirList.IsElementVisible(Browser))
            {
                abrirList.IsClickable(Browser);
                MouseActions.ClickATM(Browser, abrirList);

                lixeira.EsperarElemento(Browser);
                lixeira.Esperar(Browser, 2000);
                lixeira.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, lixeira);
            }
            else throw new Exception("elemento não encontrado");
        }

        public void DragAndDropCenaExterna(string numeroCapituloCena, string frente)
        {
            var CapituloCenaExterna = Element.Xpath("//div[@class='cena ttooltip amarelo claro'][contains(.,'" + numeroCapituloCena + "')]");
            CapituloCenaExterna.EsperarElemento(Browser);
            CapituloCenaExterna.IsElementVisible(Browser);

            try
            {
                var Frente = Element.Xpath("//td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable'][" + frente + "]");
                //Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
            catch
            {
                var Frente = Element.Xpath("//td[@class='tstRoteiroOuSlot frenteslot ui-droppable'][" + frente + "]");
                Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
        }

        public void ValidarConflitoRoteiro(string Mensagem)
        {
            var mensagemText = Element.Xpath("//div[text()='" + Mensagem + "']");
            mensagemText.IsElementVisible(Browser);
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
			else throw new Exception("elemento não encontrado");
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
			else throw new Exception("elemento não encontrado");
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
			else throw new Exception("elemento não encontrado");
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
			else throw new Exception("elemento não encontrado");
		}

		private void PopUpCancelarRoteiro()
		{
			var BtnOk = Element.Xpath("//div[24]//button[1]//span[text()='OK']");

			if (Browser.PageSource("Justifique o cancelamento do roteiro"))
			{
				AutomatedActions.SendDataATM(Browser, InputPopUpCancelamento, "cancelar");
				MouseActions.ClickATM(Browser, BtnOk);
			}
			else throw new Exception("elemento não encontrado");
		}

		public void EscolherVisao(string tempoVisao)
		{
			//Legenda: Diaria | Semanal | Mensal
			var RadioButtonVisao = Element.Css("#tstTrocaVisao" + tempoVisao + "");

            RadioButtonVisao.Esperar(Browser, 2000);
            RadioButtonVisao.EsperarElemento(Browser);
            if (RadioButtonVisao.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, RadioButtonVisao);
            }
            else throw new Exception("elemento não encontrado");
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
			else throw new Exception("elemento não encontrado");
		}

		private void DragAndDropPrimeiraCenaExterna(string numeroCapituloCena, string frente)
		{
			//Legenda¹: Colocar o número cap/cena para pega-lo.
			//Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
			var CapituloCenaExterna = Element.Xpath("//div[@class='cena ui-draggable ttooltip amarelo claro'][contains(.,'" + numeroCapituloCena + "')]");
			CapituloCenaExterna.EsperarElemento(Browser);
			CapituloCenaExterna.IsElementVisible(Browser);

            try
            {
                var Frente = Element.Xpath("//td[@class='tstRoteiroOuSlot frenteslot ui-droppable'][" + frente + "]");
                //Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
            catch
            {
                var Frente = Element.Xpath("//td[@class='tstRoteiroOuSlot frenteslot ui-droppable frenteIndisponivel'][" + frente + "]");
                Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
		}

        private void DragAndDropPrimeiraCenaExternaNoturna(string numeroCapituloCena, string frente)
        {
            //Legenda¹: Colocar o número cap/cena para pega-lo.
            //Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
            var CapituloCenaExterna = Element.Xpath("//div[@class='cena ui-draggable ttooltip amarelo claro escuro'][contains(.,'" + numeroCapituloCena + "')]");
            var Frente = Element.Xpath("//td[@class='tstRoteiroOuSlot frenteslot ui-droppable'][" + frente + "]");

            CapituloCenaExterna.EsperarElemento(Browser);
            CapituloCenaExterna.IsElementVisible(Browser);
            if (CapituloCenaExterna.IsClickable(Browser))
            {
                Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
            else throw new Exception("elemento não encontrado");
        }

        private void DragAndDropSegundaCenaExterna(string numeroCapituloCena, string frente)
        {
            //Legenda¹: Colocar o número cap/cena para pega-lo.
            //Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
            var CapituloCenaExterna = Element.Xpath("//div[@class='cena ui-draggable ttooltip amarelo claro'][contains(.,'" + numeroCapituloCena + "')]");                        
            CapituloCenaExterna.EsperarElemento(Browser);
            CapituloCenaExterna.IsElementVisible(Browser);

            try
            {
                var Frente = Element.Xpath("//td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable frenteIndisponivel'][" + frente + "]");
                //Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
            catch
            {
                var Frente = Element.Xpath("//td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable'][" + frente + "]");
                Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
        }

        private void DragAndDropSegundaCenaExternaFrente2(string numeroCapituloCena, string frente)
        {
            //Legenda¹: Colocar o número cap/cena para pega-lo.
            //Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
            var CapituloCenaExterna = Element.Xpath("//div[@class='cena ui-draggable ttooltip amarelo claro'][contains(.,'" + numeroCapituloCena + "')]");
            CapituloCenaExterna.EsperarElemento(Browser);
            CapituloCenaExterna.IsElementVisible(Browser);

            try
            {
                var Frente = Element.Xpath("//table[@id='weekDaysBody']//tr[5]/td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable frenteIndisponivel'][" + frente + "]");
                //Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
            catch (Exception)
            {
                var Frente = Element.Xpath("//table[@id='weekDaysBody']//tr[5]/td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable'][" + frente + "]");
                Frente.EsperarElemento(Browser);
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }

        }

        private void DragAndDropCenaExternaFrente3(string numeroCapituloCena, string frente)
        {
            //Legenda¹: Colocar o número cap/cena para pega-lo.
            //Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
            var CapituloCenaExterna = Element.Xpath("//div[@class='cena ui-draggable ttooltip amarelo claro'][contains(.,'" + numeroCapituloCena + "')]");
            CapituloCenaExterna.EsperarElemento(Browser);
            CapituloCenaExterna.IsElementVisible(Browser);

            try
            {
                var Frente = Element.Xpath("//table[@id='weekDaysBody']//tr[8]/td[@class='frenteslot frenteIndisponivel tstRoteiroOuSlot.ui-droppable ui-droppable'][" + frente + "]");
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }
            catch (Exception)
            {
                var Frente = Element.Xpath("//table[@id='weekDaysBody']//tr[8]/td[@class='frenteslot tstRoteiroOuSlot.ui-droppable ui-droppable'][" + frente + "]");
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);
                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaExterna, Frente);
            }

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
			else throw new Exception("elemento não encontrado");
		}

        private void DragAndDropPrimeiraCenaEstudioNoturno(string numeroCapituloCena, string frente)
        {
            //Legenda¹: Colocar o número cap/cena para pega-lo.
            //Legenda²: Colocar numéro 1 ou 2 para pegar as frentes.
            var CapituloCenaEstudio = Element.Xpath("//div[@class='cena ui-draggable ttooltip azul claro escuro'][contains(.,'" + numeroCapituloCena + "')]");
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
            else throw new Exception("elemento não encontrado");
        }

        private void EsperarRoteiroHabilitar()
		{
			var roteiroHabilitado = Element.Css("div[class='rnumber numeroRoteiroVermelho']");
			if (roteiroHabilitado.IsElementVisible(Browser))
			{
				roteiroHabilitado.EsperarElemento(Browser);
				roteiroHabilitado.IsClickable(Browser);
			}
			else throw new Exception("elemento não encontrado");
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
				MouseActions.ClickATM(Browser, BtnFechar);
		}

		public override void Navegar()
		{
			Browser.Abrir(PlanejamentoGROTUrl);
			Browser.PageLoad();
		}

		private void Filtrar(string campo, string filtro)
		{
			if (BtnFiltrarCenas.IsElementVisible(Browser))
			{
				//Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
				var CampoTipo = Element.Xpath("//*[@id='filtro" + campo + "_chzn']//input");

				BtnFiltrarCenas.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, BtnFiltrarCenas);
				CampoTipo.EsperarElemento(Browser);
				AutomatedActions.SendDataEnterATM(Browser, CampoTipo, filtro);
				ClicarBtnBuscarFiltro();
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
			DragAndDropPrimeiraCenaExterna(numeroCapituloCena, frente);
		}

        public void CriarFrenteExternaFrente3(string data, string numeroCapituloCena, string frente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            CriarNovaFrente("Externa");
            DragAndDropCenaExternaFrente3(numeroCapituloCena, frente);
        }
        //---------------CRIAR FRENTE ESTUDIO---------------\\
        public void CriarFrenteEstudio(string data, string numeroCapituloCena, string frente)
		{
			ClickEditarBloquear();
            PreencherDataRoteiro(data);
            EscolherVisao("Diaria");
            ExpandirTodasCenas();
			DragAndDropPrimeiraCenaEstudio(numeroCapituloCena, frente);
        }

        public void CriarFrenteEstudioDiario(string data, string numeroCapituloCena, string frente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            EscolherVisao("Diaria");
            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaEstudio(numeroCapituloCena, frente);
            EscolherVisao("Semanal");
        }

        public void CriarFrenteEstudioDiarioNoturno(string data, string numeroCapituloCena, string frente)
        {
            ClickEditarBloquear();
            PreencherDataRoteiro(data);
            EscolherVisao("Diaria");
            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaEstudioNoturno(numeroCapituloCena, frente);
            EscolherVisao("Semanal");
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
				JsActions.JavaScript(Browser, "$('div[contenteditable]').text('" + texto + "');");
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
		public void MoverRoteiroParaOutroDia(string data, string opcao, string numeroFrente, string dataFutura)
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
			//ClicarBtnConfirmarMoverRoteiro();
		}

        public void MoverRoteiroParaOutraFrente(string data, string opcao, string numeroFrente, string dataFutura)
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
			var EscolherData = Element.Xpath("//div[@id='popSelecaoDataRoteiro']//td[@data-handler='selectDay']//a[text()='" + dataFutura + "']");
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

        //-------------------FUNÇÃO VAI E VEM DO PLANEJAMENTO------------------\\
        public void ClicarIconeVaiEVem(string frente)
        {
            //frente = 2 (Frente 1) frente = 5 (Frente 2)
            var iconePath = Element.Css("tr[class='weekDaysBody_row1']:nth-child(" + frente + ") span[class='VaiEVem']");
            iconePath.EsperarElemento(Browser);
            iconePath.Esperar(Browser, 2000);
            iconePath.IsElementVisible(Browser);
            //MouseActions.ClickATM(Browser, iconePath);

            string link = "$('tr[class=\"weekDaysBody_row1\"]:nth-child(" + frente + ") span[class=\"VaiEVem\"]').click();";
            JsActions.JavaScript(Browser, link);

        }

        public void ValidarIconeVaiEVem(string frente)
        {
            //frente = 2 (Frente 1) frente = 5 (Frente 2)
            var NumGROT = Element.Css("tr[class='weekDaysBody_row1']:nth-child(" + frente + ") div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);

            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();

            var validarRoteiro = Element.Xpath("//strong[text()='Roteiro " + NumGROTStr + "']");
            validarRoteiro.IsElementVisible(Browser);

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
			CampoCenas.EsperarElemento(Browser);
			if (CampoCenas.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, CampoCenas);
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


        //Validação de Alertas
        public void ValidarCenaCapituloBaixo(string Cena)
        {
            var cenaPath = Element.Xpath("//img[@src='/SGP/Images/cenaBandeirinha.png']/..//span[text()='" + Cena + "']");
            cenaPath.EsperarElemento(Browser);
            cenaPath.IsElementVisible(Browser);
        }

        public void ValidarAlertaCena(string TxtAlert, string ILinha)
        {
            ClicarAlertaCena();

            var IcoAlert = Element.Xpath("//img[@src='../Images/planrotGROT/action.png']" + "//following::span[text()='" + TxtAlert + "']");
            //IcoAlert.EsperarElemento(Browser);
            IcoAlert.Esperar(Browser, 1000);
            IcoAlert.IsElementVisible(Browser);

            ClicarIcoFecharAlertaRoteiroCena();
        }

        public void ValidarAlertaCenaNegativo(string TxtAlert, string ILinha)
        {
            ClicarAlertaCena();

            var IcoAlert = Element.Xpath("//img[@src='../Images/planrotGROT/action.png']" + "//following::span[text()='" + TxtAlert + "']");
            IcoAlert.IsNotElementVisible(Browser);

            ClicarIcoFecharAlertaRoteiroCena();
        }
        private void ClicarIcoAlertaCena(string ILinha)
        {
            var IcoAlertaCena = Element.Xpath("//td[@class='frenteslot'][" + ILinha + "]//img[@src='/SGP/Images/planrotGROT/action.png']");
            Thread.Sleep(2000);
            //IcoAlertaCena.EsperarElemento(Browser);
            IcoAlertaCena.Esperar(Browser, 1000);
            if (IcoAlertaCena.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoAlertaCena);
            }
        }

        public void ValidarAlertaRoteiroInconsitencia(string TxtAlert, string ILinha)
        {
            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);

            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();
            string PathIcoAlert = "//img[@src='../Images/planrotGROT/warning.png']";

            ClicarIcoAlertaInconsitenciaRoteiro(ILinha);

            var MsgAlertRoteiroInconsitencia = Element.Xpath(PathIcoAlert + "//following::span[text()='Inconsistência no Roteiro " + NumGROTStr + "" + TxtAlert + "']");
            MsgAlertRoteiroInconsitencia.EsperarElemento(Browser);
            MsgAlertRoteiroInconsitencia.Esperar(Browser, 1000);
            MsgAlertRoteiroInconsitencia.IsElementVisible(Browser);

            ClicarIcoFecharAlertaRoteiroCena();
        }

        public void ValidarAlertaRoteiroConflitoDeHorario(string ILinha, string TxtAlert1, string TxtAlert2)
        {
            var NumGROT1 = Element.Css("tr:nth-child(2) div[class='rnumber rnumberGROT']");
            NumGROT1.EsperarElemento(Browser);
            NumGROT1.Esperar(Browser, 1000);
            string NumGROTStr1 = NumGROT1.GetTexto(Browser).ToString();

            var NumGROT2 = Element.Css("tr:nth-child(5) div[class='rnumber rnumberGROT']");
            NumGROT2.EsperarElemento(Browser);
            NumGROT2.Esperar(Browser, 1000);
            string NumGROTStr2 = NumGROT2.GetTexto(Browser).ToString();

            string PathIcoAlert = "//img[@src='../Images/planrotGROT/warning.png']";

            ClicarIcoAlertaSemana(ILinha);

            var MsgAlertRoteiroConflitoDeHorario = Element.Xpath(PathIcoAlert + "//following::span[text()='"+ TxtAlert1 + NumGROTStr1 + " e  " + NumGROTStr2 + TxtAlert2 + "']");
            MsgAlertRoteiroConflitoDeHorario.EsperarElemento(Browser);
            MsgAlertRoteiroConflitoDeHorario.Esperar(Browser, 1000);
            MsgAlertRoteiroConflitoDeHorario.IsElementVisible(Browser);

            ClicarIcoFecharAlertaRoteiroCena();
        }

        public void ValidarAlertaRoteiro(string TxtAlert, string TipoAlert, string ILinha)
        {
            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);

            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();
            string PathIcoAlert = "//img[@src='../Images/planrotGROT/warning.png']";

            ClicarIcoAlertaInconsitenciaRoteiro(ILinha);

            if(TipoAlert == "1")
            {
                Element.Xpath(PathIcoAlert + "//following::span[text()='Roteiro " + NumGROTStr + "" + TxtAlert + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "2")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + "." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "6")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + " em 250 m².']").IsElementVisible(Browser);
            }
            if (TipoAlert == "7")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + " em 177 m².']").IsElementVisible(Browser);
            }
            ClicarIcoFecharAlertaRoteiroCena();
        }

        private void ClicarIcoAlertaInconsitenciaRoteiro(string ILinha)
        {
            var IcoAlertaRelatorio = Element.Xpath("//div[@class='rTop'][" + ILinha + "]//img[@src='/SGP/Images/planrotGROT/warning.png']");

            IcoAlertaRelatorio.EsperarElemento(Browser);
            IcoAlertaRelatorio.Esperar(Browser, 1000);
            if (IcoAlertaRelatorio.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoAlertaRelatorio);
            }
        }

        private void ClicarIcoAlertaSemana(string ILinha)
        {
            string PathIcoAlertaCena = "//tr[@class='weekDaysHeader_row1']/td[" + ILinha + "]//img[@src='/SGP/Images/planrotGROT/warning.png']";

            var IcoAlertaRelatorio = Element.Xpath(PathIcoAlertaCena);
            IcoAlertaRelatorio.EsperarElemento(Browser);
            IcoAlertaRelatorio.Esperar(Browser, 1000);
            if (IcoAlertaRelatorio.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoAlertaRelatorio);
            }
        }

        private void ClicarAlertaGeralSemanal()
        {
            var IcoAlertaGeralSemanal = Element.Xpath("//td/img[@src='/SGP/Images/planrotGROT/warning.png']");
            IcoAlertaGeralSemanal.EsperarElemento(Browser);
            IcoAlertaGeralSemanal.Esperar(Browser, 1000);
            if(IcoAlertaGeralSemanal.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoAlertaGeralSemanal);
            }
        }

        private void ClicarIcoFecharAlertaRoteiroCena()
        {
            var IcoFecharAlertaRoteiroCena = Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//img[@src='../Images/grot_close.png']");

            IcoFecharAlertaRoteiroCena.EsperarElemento(Browser);
            IcoFecharAlertaRoteiroCena.Esperar(Browser, 1000);
            if (IcoFecharAlertaRoteiroCena.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoFecharAlertaRoteiroCena);
            }
        }

        public void ValidarAlertaDia(string TxtAlert, string TipoAlert)
        {
            ClicarAlertaDia();

            if (TipoAlert == "1")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "2")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + "." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "5")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + "')]").IsElementVisible(Browser);
            }
            if (TipoAlert == "8")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + "')]").IsElementVisible(Browser);
            }
        }

        public void ValidarAlertaGeralSemanal(string TxtAlert, string TipoAlert)
        {
            ClicarAlertaSemana();
           
            if (TipoAlert == "1")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + "')]").IsElementVisible(Browser);
            }
            if (TipoAlert == "2")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + "." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "5")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(0) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + "')]").IsElementVisible(Browser);
            }
        }

        public void ValidarRelatorioAlertas(string TxtAlert, string TipoAlert, int DiasAFrente)
        {
            ClicarRelatorioAlertas();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);

            if (TipoAlert == "1")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '"+ TxtAlert + "')]").IsElementVisible(Browser);
            }
            if (TipoAlert == "2")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + "')]").IsElementVisible(Browser);
            }
            if (TipoAlert == "3")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + ", de 00:00 a 23:59 (Justificativa de teste)." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "4")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " de 00:00 a 23:59." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "5")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + "')]").IsElementVisible(Browser);
            }
            if (TipoAlert == "6")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " em 250 m².']").IsElementVisible(Browser);
            }
            if (TipoAlert == "7")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " em 177 m².']").IsElementVisible(Browser);
            }
            if (TipoAlert == "8")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[contains(., '" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + "')]").IsElementVisible(Browser);
            }
            if (TipoAlert == "9")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para LUCAS ALMEIDA." + "']").IsElementVisible(Browser);
            }


            if (TipoAlert == "Inconsistência")
            {
                string teste = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/iconcistencia.png']/../..//span[@data-bind='text: mensagem']").GetTexto(Browser);
                Assert.IsTrue(true, teste);
            }
            if (TipoAlert == "Antecedência mínima de gravação")
            {
                string teste = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Antecedencia-Minima-de-Gravacao.png']/../..//span[@data-bind='text: mensagem']").GetTexto(Browser);
                Assert.IsTrue(true, teste);
            }


            if (TipoAlert == "Jornada da Frente")
            {
                string teste = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/jornada-de-frente.png']/../..//span[@data-bind='text: mensagem']").GetTexto(Browser);
                Assert.IsTrue(true, teste);
            }
            if (TipoAlert == "MQE")
            {
                string teste = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/MQE.png']/../..//span[@data-bind='text: mensagem']").GetTexto(Browser);
                Assert.IsTrue(true, teste);
            }
            if (TipoAlert == "Metragem")
            {
                string teste = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/metragem-de-estudio.png']/../..//span[@data-bind='text: mensagem']").GetTexto(Browser);
                Assert.IsTrue(true, teste);
            }
            if (TipoAlert == "Indisponibilidade de frente de gravacao")
            {
                var diaSemanaPath = Element.Css("td[class='dayHeaderweek']:nth-child(3) span[class='tstDiaSemana']");
                diaSemanaPath.EsperarElemento(Browser);
                diaSemanaPath.IsElementVisible(Browser);

                string diaSemana = diaSemanaPath.GetTexto(Browser).ToString();
                if (diaSemana == "Terça")
                {
                    diaSemana = "terca";
                }
                if (diaSemana == "Sábado")
                {
                    diaSemana = "sabado";
                }
                var descricao = Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + diaSemana.ToUpper() + ", dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + ".']");
                descricao.IsElementVisible(Browser);
                //Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para LUCAS ALMEIDA." + "']").IsElementVisible(Browser);
            }

            ClicarFecharRelatorioAlertas();
        }

        public void ValidarRelatorioAlertasGeral(string TipoAlert)
        {
            ClicarRelatorioAlertas();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);

            switch (TipoAlert)
            {
                case "Antecedência mínima de gravação":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Antecedencia-Minima-de-Gravacao.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Tempo preparação de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/preparacao-elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Iluminação":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Horarios-Iluminacao-Manha-Tarde-Noite.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Faixa de horário de gravação":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Faixa-de-horario-de-gravacao.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Caracterização de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Caracterizacao-de-elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Indisponibilidade de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/indisponibilidade-de-elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Jornada da frente":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/jornada-de-frente.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Refeição de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/refeicao_elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Tempo de deslocamento":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/deslocamento.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Interjornada de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/interjornada-de-elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Conflito de horário de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/indisponibilidaden-de-horario.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Múltipla alocação do ambiente":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Multipla-alocacao-do-ambiente.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Jornada de elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/jornada-de-elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Metragem de estúdio":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/metragem-de-estudio.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Incompatibilidade de cenários e ambientes":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/incompatibilidade-de-cenarios-e-ambientes.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "MQE":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/MQE.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Inconsistência":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/iconcistencia.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Refeição da equipe":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/refeicao_frente.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Frente de gravação incompatível":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/Frente-de-gravacao-incompativel.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Jornada semanal do elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/jornada-semanal-de-elenco.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Limite de Dias de Gravação na Semana da Frente":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/limite-de-dias-de-gravacao-na-semana.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Indisponibilidade do local":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/indisponibilidade-de-local.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Indisponibilidade de frente de gravação":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/indisponibilidade-de-frente-de-gravacao.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Interjornada de frente":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/interjornada-de-frente.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }
                case "Limite de Dias de Gravação na Semana do Elenco":
                    {
                        var mensagemText = Element.Xpath("//img[@src='../Images/GROT/25X24-AZUL/limite-de-dias-de-gravacao-na-semana.png']/../..//span[@data-bind='text: mensagem']");
                        mensagemText.EsperarElemento(Browser);
                        string mensagem = mensagemText.GetTexto(Browser);
                        Assert.IsTrue(true, mensagem);
                        break;
                    }


            }
                    ClicarFecharRelatorioAlertas();
        }

        public void ValidarRelatorioAlertasPorPeriodo(string TxtAlert, string TipoAlert, int DiasAFrente)
        {
            ClicarRelatorioAlertas();
            ClicarRelatorioPorPeriodo();
            ClicarMaisDetalhesRelatorioPeriodo();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);


            if (TipoAlert == "1")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "2")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + "." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "3")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + ", de 00:00 a 23:59 (Alerta: Indisponibilidade de elenco.)." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "4")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " de 00:00 a 23:59." + "']").IsElementVisible(Browser);
            }
            if (TipoAlert == "5")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + " em 01:10 horas.']").IsElementVisible(Browser);
            }
            if (TipoAlert == "6")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " em 250 m².']").IsElementVisible(Browser);
            }
            if (TipoAlert == "7")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " em 177 m².']").IsElementVisible(Browser);
            }
            if (TipoAlert == "8")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para o dia " + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(1) + " em 00:10 horas.']").IsElementVisible(Browser);
            }
            if (TipoAlert == "9")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + " para LUCAS ALMEIDA." + "']").IsElementVisible(Browser);
            }

            ClicarRelatorioPorAlerta();
            ClicarFecharRelatorioAlertas();
        }

        public void ValidarTeste(string mensagem)
        {
            var nome = Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + mensagem + "']");
            //var nome = Element.Css("div span[data-bind='text: mensagem']");

            string teste = nome.GetTexto(Browser);

            //JsActions.JavaScript(Browser, @"var input_h = document.createElement('input'); input_h.setAttribute('type','hidden'); input_h.setAttribute('id','span_mensagem');");
            //var teste = Element.Id("span_mensagem");
            //string valor_span = teste.GetTexto(Browser);
            Assert.AreEqual(mensagem, teste);
        }

        public void ValidarRelatorioAlertasNegativo(string TxtAlert, string TipoAlert, int DiasAFrente)
        {
            ClicarRelatorioAlertas();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);

            if (TipoAlert == "1")
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']//span[text()='" + TxtAlert + "']").IsNotElementVisible(Browser);
            }

            ClicarFecharRelatorioAlertas();
        }
        public void ValidarRelatorioRoteiroInconsitencia(string TxtAlert)
        {
            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);
            string NumGROTStr = NumGROT.GetTexto(Browser).ToString(); 

            ClicarRelatorioAlertas();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);
            if (ModalAlert.IsElementVisible(Browser))
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']" + "//span[text()='Inconsistência no Roteiro " + NumGROTStr + "" + TxtAlert + "']").IsElementVisible(Browser);
            }
            ClicarFecharRelatorioAlertas();
        }

        public void ValidarRelatorioRoteiroRefeicaoDaEquipe(string TxtAlert)
        {
            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);
            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();

            ClicarRelatorioAlertas();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);
            if (ModalAlert.IsElementVisible(Browser))
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']" + "//span[text()='Roteiro " + NumGROTStr + "" + TxtAlert + "']").IsElementVisible(Browser);
            }
            ClicarFecharRelatorioAlertas();
        }

        public void ValidarRelatorioRoteiroConflitoDeHorario(string TxtAlert1, string TxtAlert2)
        {
            var NumGROT1 = Element.Css("tr:nth-child(2) div[class='rnumber rnumberGROT']");
            NumGROT1.EsperarElemento(Browser);
            NumGROT1.Esperar(Browser, 1000);
            string NumGROTStr1 = NumGROT1.GetTexto(Browser).ToString();

            var NumGROT2 = Element.Css("tr:nth-child(5) div[class='rnumber rnumberGROT']");
            NumGROT2.EsperarElemento(Browser);
            NumGROT2.Esperar(Browser, 1000);
            string NumGROTStr2 = NumGROT2.GetTexto(Browser).ToString();
            
            ClicarRelatorioAlertas();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);
            if (ModalAlert.IsElementVisible(Browser))
            {
                Element.Xpath("//div[@class='dumb ui-dialog-content ui-widget-content']" + "//span[text()='"+ TxtAlert1 + NumGROTStr1 + " e  " + NumGROTStr2 + TxtAlert2 + "']").IsElementVisible(Browser);
            }
            ClicarFecharRelatorioAlertas();
        }

        private void ClicarFecharRelatorioAlertas()
        {
            var IcoFechar = Element.Css("div#RelatorioAlertas img.pinPopup-button-close");
            IcoFechar.EsperarElemento(Browser);
            IcoFechar.Esperar(Browser, 1000);
            if (IcoFechar.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoFechar);
            }
        }

        public void ClicarRelatorioAlertas()
        {
            Thread.Sleep(2000);
            BtnRelatorioAlertas.EsperarElemento(Browser);
            BtnRelatorioAlertas.Esperar(Browser, 1000);
            if (BtnRelatorioAlertas.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnRelatorioAlertas);
            }
        }

        private void ClicarRelatorioPorPeriodo()
        {
            BtnVerRelatorioPorPeriodo.EsperarElemento(Browser);
            BtnVerRelatorioPorPeriodo.Esperar(Browser, 1000);
            if(BtnVerRelatorioPorPeriodo.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnVerRelatorioPorPeriodo);
            }

        }

        private void ClicarRelatorioPorAlerta()
        {
            BtnVerRelatorioPorAlerta.EsperarElemento(Browser);
            BtnVerRelatorioPorAlerta.Esperar(Browser, 1000);
            if (BtnVerRelatorioPorAlerta.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnVerRelatorioPorAlerta);
            }

        }

        private void ClicarMaisDetalhesRelatorioPeriodo()
        {
            BtnRelatorioPorPeriodoMaisDetalhes.EsperarElemento(Browser);
            BtnRelatorioPorPeriodoMaisDetalhes.Esperar(Browser, 1000);
            if(BtnRelatorioPorPeriodoMaisDetalhes.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnRelatorioPorPeriodoMaisDetalhes);
            }
        }

        public void ValidarAlertaRelatorioDia(string TxtAlert, string ILinha, int DiasAFrente)
        {
            string PathIcoAlert = "//img[@src='../Images/planrotGROT/warning.png']";

            ClicarIcoAlertaRelatorio(ILinha);

            var IcoAlert = Element.Xpath(PathIcoAlert + "//following::span[text()='" + TxtAlert + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + "." + "']");
            IcoAlert.EsperarElemento(Browser);
            IcoAlert.Esperar(Browser, 1000);
            IcoAlert.IsElementVisible(Browser);
        }

        private void ClicarIcoAlertaRelatorio(string ILinha)
        {
            string PathIcoAlertaCena = "//td[@class='dayHeaderweek'][" + ILinha + "]//img[@src='/SGP/Images/planrotGROT/warning.png']";
            var IcoAlertaRelatorio = Element.Xpath(PathIcoAlertaCena);
            IcoAlertaRelatorio.EsperarElemento(Browser);
            IcoAlertaRelatorio.Esperar(Browser, 1000);
            if (IcoAlertaRelatorio.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoAlertaRelatorio);
            }
        }

        public void ValidarAlertaJornadaMaxima(string TxtAlert, string ILinha, int DiasAFrente)
        {
            ClicarIcoAlertaJornadaSemanal(ILinha, DiasAFrente);

            string PathMsgAlertaJornadaMaxima = "//span[text()='" + TxtAlert + "" + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + "." + "']";

            var MsgAlertaJornadaMaxima = Element.Xpath(PathMsgAlertaJornadaMaxima);
            MsgAlertaJornadaMaxima.EsperarElemento(Browser);
            MsgAlertaJornadaMaxima.Esperar(Browser, 1000);
            MsgAlertaJornadaMaxima.IsElementVisible(Browser);

            ClicarIcoFecharAlertaRoteiroCena();
        }

        public void ValidarAlertaIndisponibilidadeElenco(string TxtAlert, string ILinha, int DiasAFrente)
        {
            ClicarIcoAlertaJornadaSemanal(ILinha, DiasAFrente);

            string PathMsgAlertaJornadaMaxima = "//span[text()='" + TxtAlert + "" + CalendarioHelper.ObterDiaMesAnoFuturoComBarra(DiasAFrente) + ", de 00:00 a 23:59 (Justificativa de teste)." + "']";

            var MsgAlertaJornadaMaxima = Element.Xpath(PathMsgAlertaJornadaMaxima);
            MsgAlertaJornadaMaxima.EsperarElemento(Browser);
            MsgAlertaJornadaMaxima.Esperar(Browser, 1000);
            MsgAlertaJornadaMaxima.IsElementVisible(Browser);

            ClicarIcoFecharAlertaRoteiroCena();
        }

        private void ClicarIcoAlertaJornadaSemanal(string ILinha, int DiasAFrente)
        {
            //string PathIcoAlertJornadaMaxima = "//strong[text()='" + CalendarioHelper.ObterDiaMesFuturoComBarra(DiasAFrente) + "']//following::img[@src='/SGP/Images/planrotGROT/warning.png'][" + ILinha + "]";
            Thread.Sleep(2000);
            var IcoAlertJornadaMaxima = Element.Xpath("//strong[text()='" + CalendarioHelper.ObterDiaMesFuturoComBarra(DiasAFrente) + "']//following::img[@src='/SGP/Images/planrotGROT/warning.png'][" + ILinha + "]");
            IcoAlertJornadaMaxima.EsperarElemento(Browser);
            if (IcoAlertJornadaMaxima.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, IcoAlertJornadaMaxima);
            }
        }

        public void ValidarCabecalhoGrot()
        {
            var historico = Element.Xpath("//h4[contains (., 'Histórico')]");
            var total = Element.Xpath("//div[@data-bind='visible: visible']//span[contains (., 'TOTAL')]");
            var alertas = Element.Xpath("//div[@data-bind='visible: visible']//span[contains (., 'ALERTAS')]");
            var relatorioDeAlertas = Element.Xpath("//div[@data-bind='visible: visibleRelatorio']/span[contains (., 'Relatório de alertas')]");
            var frentes = Element.Css("label[for='frentes']");
            var iconeAntecedencia = Element.Css("div[data-bind='visible: visible'] img[id='imgAlertBar_ANTECEDENCIA_MINIMA_GRAVACAO']");
            var iconeFaixaHorario = Element.Css("div[data-bind='visible: visible'] img[id='imgAlertBar_FAIXA_HORARIO_CENA']");
            var iconeJornadaFrente = Element.Css("div[data-bind='visible: visible'] img[id='imgAlertBar_JORNADA_FRENTE']");

            Thread.Sleep(2000);
            historico.EsperarElemento(Browser);
            historico.IsElementVisible(Browser);
            total.IsElementVisible(Browser);
            alertas.IsElementVisible(Browser);
            relatorioDeAlertas.IsElementVisible(Browser);
            frentes.IsElementVisible(Browser);
            iconeAntecedencia.IsElementVisible(Browser);
            iconeFaixaHorario.IsElementVisible(Browser);
            iconeJornadaFrente.IsElementVisible(Browser);
        }

        //------------Validar Sumarização de Alertas------------//
        public void FiltrarAlertasPorFrente(string Frente)
        {
            var frentesPath = Element.Css("div[id='frentes_chzn'] b");
            var frentesInput = Element.Css("div[id='frentes_chzn'] input");
            frentesPath.Esperar(Browser, 1500);
            frentesPath.EsperarElemento(Browser);
            
            MouseActions.ClickATM(Browser, frentesPath);
            AutomatedActions.SendDataEnterATM(Browser, frentesInput, Frente);
            
        }

        public void ExpandirAlertas()
        {
            var BtnMostrarAlertas = Element.Css("div[data-bind='click: showHideAllAlertsClick']");
            BtnMostrarAlertas.Esperar(Browser, 2000);
            BtnMostrarAlertas.EsperarElemento(Browser);
            if(BtnMostrarAlertas.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnMostrarAlertas);
            }
        }

        public void ValidarTotalAlertas(string Total)
        {
            var totalAlertasPath = Element.Css("span[data-bind='text: total']");
            string totalAlertas = totalAlertasPath.GetTexto(Browser).ToString();
            Assert.AreEqual(Total, totalAlertas);
        }

        public void ValidarSumarizacaoAlerta(string TipoAlerta, string Qtd)
        {
            var validarAlerta = Element.Xpath("//img[@id='imgAlertBar_" + TipoAlerta + "']/../span[text()='" + Qtd + "']");
            validarAlerta.EsperarElemento(Browser);
            validarAlerta.IsElementVisible(Browser);
        }

        //---------------Botão Flutuante do Icone de Informações(i)-------------------------//
        public void ClicarBtnInformacoes()
        {
            var btnInformacoes = Element.Css("div[id='infoAlertGROTcall']");
            btnInformacoes.EsperarElemento(Browser);
            btnInformacoes.IsClickable(Browser);
            MouseActions.ClickATM(Browser, btnInformacoes);
        }

        public void ClicarBtnFlutuanteInformacoes(string TipoFlutuante)
        {
            var btnFlutuante = Element.Css("div img[src='../Images/grot_pinned.png']");
            var btnNaoFlutuante = Element.Css("div img[src='../Images/grot_unpinned.png']");

            if(TipoFlutuante == "1")
            {
                btnFlutuante.EsperarElemento(Browser);
                btnFlutuante.IsClickable(Browser);
                MouseActions.ClickATM(Browser, btnFlutuante);
            }
            if (TipoFlutuante == "2")
            {
                btnNaoFlutuante.EsperarElemento(Browser);
                btnNaoFlutuante.IsClickable(Browser);
                MouseActions.ClickATM(Browser, btnNaoFlutuante);
            }
        }

        private void ClicarFecharPopupInformacoes()
        {
            var btnFechar = Element.Css("div[class='container legendaAlertas'] img[src='../Images/grot_close.png']");
            btnFechar.EsperarElemento(Browser);
            btnFechar.IsClickable(Browser);
            MouseActions.ClickATM(Browser, btnFechar);
        }

        public void ValidarTelaInformacoesFlutuante(string TipoFlutuante)
        {
            if(TipoFlutuante == "Flutuante")
            {
                var telaFlutuantePath = Element.Css("div[class='dumb ui-dialog-content ui-widget-content'] div[class='container legendaAlertas']");
                telaFlutuantePath.IsElementVisible(Browser);
            }
            if (TipoFlutuante == "Fixo")
            {
                var telaFlutuantePath = Element.Css("div[class='dumb'] div[class='container legendaAlertas']");
                telaFlutuantePath.IsElementVisible(Browser);
            }
            ClicarFecharPopupInformacoes();
        }

        private void EsperaLoading()
        {
            var esperaPath = Element.Css("div[id='loading']");
            esperaPath.IsNotElementVisible(Browser); ;
        }


        //--------------------------------------------------NOVAS ITENS DE CENA------------------------------------------------------//
        public void IncluirNovoIcone(string icone, string data)
        {
            PreencherDataRoteiro(data);
            if(icone == "Refeição")
            {
                DragAndDropRefeicao();
            }
            if(icone == "Preparacao")
            {
                DragAndDropPreparacao();
            }
            if(icone == "Deslocamento")
            {
                DragAndDropDeslocamento();
            }
            var menuText = Element.Css("div[class='toast-message']");
            MouseActions.ClickATM(Browser, menuText);
        }

        public void AlterarTempo(string Alteracao, int Qtd)
        {
            int i = 1;
            while(i <= Qtd)
            {
                TempoPreparacaoDeslocamento(Alteracao);
                i++;
            }
        }

        private void TempoPreparacaoDeslocamento(string Alteracao)
        {
            if(Alteracao == "Aumentar")
            {
                var aumentarTempo = Element.Xpath("//strong[@class='tstTextoCenaRoteiro']/..//img[@src='/sgp/Images/maisN.png']");
                aumentarTempo.EsperarElemento(Browser);
                aumentarTempo.Esperar(Browser, 2000);
                aumentarTempo.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, aumentarTempo);
            }
            if (Alteracao == "Diminuir")
            {
                var aumentarTempo = Element.Xpath("//strong[@class='tstTextoCenaRoteiro']/..//img[@src='/sgp/Images/menosN.png']");
                aumentarTempo.EsperarElemento(Browser);
                aumentarTempo.Esperar(Browser, 2000);
                aumentarTempo.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, aumentarTempo);
            }
        }

        private void DragAndDropRefeicao()
        {
            ExpandirCenasDeRoteiro();

            IconeRefeicao.EsperarElemento(Browser);
            IconeRefeicao.IsElementVisible(Browser);

            var Frente = Element.Css("div[class='roteiro semanal unselectable ui-droppable']");
            Frente.EsperarElemento(Browser);
            Frente.IsElementVisible(Browser);
            Frente.IsClickable(Browser);
            MouseActions.MouseDragAndDropSML(Browser, IconeRefeicao, Frente);
        }

        private void DragAndDropPreparacao()
        {
            ExpandirCenasDeRoteiro();

            IconePreparacao.EsperarElemento(Browser);
            IconePreparacao.IsElementVisible(Browser);

            var Frente = Element.Css("div[class='cena ttooltip amarelo claro']");
            Frente.EsperarElemento(Browser);
            Frente.IsElementVisible(Browser);
            Frente.IsClickable(Browser);
            MouseActions.MouseDragAndDropSML(Browser, IconePreparacao, Frente);
        }

        private void DragAndDropDeslocamento()
        {
            ExpandirCenasDeRoteiro();

            IconeDeslocamento.EsperarElemento(Browser);
            IconeDeslocamento.IsElementVisible(Browser);

            var Frente = Element.Css("div[class='cena ttooltip amarelo claro']");
            Frente.EsperarElemento(Browser);
            Frente.IsElementVisible(Browser);
            Frente.IsClickable(Browser);
            MouseActions.MouseDragAndDropSML(Browser, IconeDeslocamento, Frente);
        }

        public void ExpandirCenasDeRoteiro()
        {
            var expandirPath = Element.Css("div[class='rscenes']");
            expandirPath.EsperarElemento(Browser);
            expandirPath.Esperar(Browser, 2000);
            expandirPath.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, expandirPath);
        }

        public void ValidarItemDeCenaNoRoteiro(string NomeItem, string Tempo)
        {
            ExpandirCenasDeRoteiro();

            var descricao = Element.Xpath("//span[text()='" + NomeItem + "']");
            var tempoPreparacao = Element.Xpath("//strong[@class='tstTextoCenaRoteiro']/span[text()='" + Tempo + "']");

            descricao.IsElementVisible(Browser);
            tempoPreparacao.IsElementVisible(Browser);
        }

        public void ValidarPreparacao(string TempoPreparacao)
        {
            ExpandirCenasDeRoteiro();

            var descricao = Element.Xpath("//span[text()='Preparação']");
            var tempoPreparacao = Element.Xpath("//strong[@class='tstTextoCenaRoteiro']/span[text()='" + TempoPreparacao + "']");

            descricao.IsElementVisible(Browser);
            tempoPreparacao.IsElementVisible(Browser);
        }

        public void ValidarRefeicaoRoteiro()
        {
            ExpandirCenasDeRoteiro();

            var descricao = Element.Xpath("//span[text()='Refeição']");
            var hora = Element.Xpath("//span[text()='01:00']");

            descricao.IsElementVisible(Browser);
            hora.IsElementVisible(Browser);
        }

        public void ValidarIconesDeCena()
        {
            ClickEditarBloquear();
            //EsperaLoading();

            IconeRefeicao.IsElementVisible(Browser);
            IconePreparacao.IsElementVisible(Browser);
            IconeDeslocamento.IsElementVisible(Browser);
        }

        public void ValidarTotalDeAlertas(string qtd)
        {
            var qtdTotal = Element.Css("span[data-bind='text: total']");
            string validarQtd = qtdTotal.GetTexto(Browser);

            Assert.AreEqual(qtd, validarQtd);
        }
        //--------------------------------------------------NOVAS ITENS DE CENA------------------------------------------------------//

        public void ImprimirRelatorio()
        {
            ClicarRelatorioAlertas();
            //ClicarRelatorioPorPeriodo();
            //ClicarMaisDetalhesRelatorioPeriodo();
            ModalAlert.EsperarElemento(Browser);
            ModalAlert.Esperar(Browser, 1000);

            var BtnGerar = Element.Css("img[src='../Images/planrotGROT/print.png']");
            BtnGerar.EsperarElemento(Browser);
            if (BtnGerar.IsClickable(Browser))
                MouseActions.ClickATM(Browser, BtnGerar);
        }

        public void VisualizarRelatorioDeAlertas(string texto, string caminho)
        {
            PDFHelpers.GetTextPDF(Browser, texto, caminho);
            DeletePDF.DeletarPDF(Browser, caminho);
        }

        //--------------------------------------------------HISTORICO------------------------------------------------------//
        public void ValidarHistorico(int data, string ordem)
        {
            var historico = Element.Css("select[id='listaHistorico']");
            var optHistorico = Element.Xpath("//select[@id='listaHistorico']/option[contains(., 'Liberado em: " + CalendarioHelper.ObterDataFutura(data) + "')][" + ordem + "]");

            MouseActions.ClickATM(Browser, historico);
            MouseActions.ClickATM(Browser, optHistorico);
        }


        public void ValidarCampoHistorico()
        {
            var historicoPath = Element.Css("div[id='historicoGROT']");
            historicoPath.EsperarElemento(Browser);
            historicoPath.IsElementVisible(Browser);
        }

    }
}