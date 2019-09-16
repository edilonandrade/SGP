using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.SGP.Pages
{
	public class ParametrosPage : PageBase
	{
		private string ParametrosUrl { get; }

		//Input
		private Element InputAntecedenciaMinima { get; }
        public Element InputQtdDiasFolgaSemanal { get; }
        public Element InputTempoPreparacaoPersonagem { get; }
        public Element InputCargaHorariaMaxDiariaPersonagem { get; }
        public Element InputCargaHorariaMaxSemanalPersonagem { get; }
        public Element InputInterjornadaMinElenco { get;  }
        public Element InputPeriodoNoturnoInicial { get; }
        public Element InputPeriodoNoturnoFinal { get; }

        //Button
        private Element BtnSimPopUpAtencaoParametros { get; }
        private Element BtnCancelarPopUpAtencaoParametros { get; }
        private Element BtnOKPopUpAtencaoParametros { get; }
        

        public ParametrosPage(IBrowser browser,
		   string parametrosUrl) : base(browser)
		{
			ParametrosUrl = parametrosUrl;

			//Input
			InputAntecedenciaMinima = Element.Id("txtAntecedenciaMinGravacaoDias");
            InputQtdDiasFolgaSemanal = Element.Id("txtQuantidadeDiasFolgaSemanal");
            InputTempoPreparacaoPersonagem = Element.Id("txtTempoPreparacaoPersonagem");
            InputCargaHorariaMaxDiariaPersonagem = Element.Id("txtCargaHorariaMaxDiariaPersonagem");
            InputCargaHorariaMaxSemanalPersonagem = Element.Id("txtCargaHorariaMaxSemanalPersonagem");
            InputInterjornadaMinElenco = Element.Id("txtInterjornadaMinElenco");
            InputPeriodoNoturnoInicial = Element.Id("txtPeriodoNoturnoInicial");
            InputPeriodoNoturnoFinal = Element.Id("txtPeriodoNoturnoFinal");

            //Button
            BtnSimPopUpAtencaoParametros = Element.Id("ButtonSim");
            BtnCancelarPopUpAtencaoParametros = Element.Id("ButtonCancelar");
            BtnOKPopUpAtencaoParametros = Element.Id("ButtonOk");
		}

        public override void Navegar()
        {
            Browser.Abrir(ParametrosUrl);
            Browser.PageLoad();
        }


        //----------ANTECEDENCIA MINIMA GRAVACAO-------------\\
        public void PreencherDiasAntecedencia(string dias)
		{
			InputAntecedenciaMinima.Esperar(Browser, 2000);
			InputAntecedenciaMinima.EsperarElemento(Browser);
			if (InputAntecedenciaMinima.IsElementVisible(Browser))
			{
				AutomatedActions.SendDataATM(Browser, InputAntecedenciaMinima, dias);
			}

			SalvarParametrosProducao();
			PopUpAtencaoParametros();
		}
        
        public void AlterarParametrosProducao(string FolgaSemanal, string AntecedenciaMinima)
        {
            if(FolgaSemanal != "")
            {
                InputQtdDiasFolgaSemanal.EsperarElemento(Browser);
                InputQtdDiasFolgaSemanal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputQtdDiasFolgaSemanal, FolgaSemanal);
            }
            if (AntecedenciaMinima != "")
            {
                InputAntecedenciaMinima.EsperarElemento(Browser);
                InputAntecedenciaMinima.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputAntecedenciaMinima, AntecedenciaMinima);
            }

            SalvarParametrosProducao();
            PopUpAtencaoParametros();
        }

        public void AlterarParametrosPersonagem(string preparacaoPersonagem, string cargaHorMaxDiaria,
            string cargaHorMaxSemanal, string interjornadaElento)
        {
            if (preparacaoPersonagem != "")
            {
                InputTempoPreparacaoPersonagem.EsperarElemento(Browser);
                InputTempoPreparacaoPersonagem.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputTempoPreparacaoPersonagem, preparacaoPersonagem);

            }
            if (cargaHorMaxDiaria != "")
            {
                InputCargaHorariaMaxDiariaPersonagem.EsperarElemento(Browser);
                InputCargaHorariaMaxDiariaPersonagem.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaxDiariaPersonagem, cargaHorMaxDiaria);
            }
            if (cargaHorMaxSemanal != "")
            {
                InputCargaHorariaMaxSemanalPersonagem.EsperarElemento(Browser);
                InputCargaHorariaMaxSemanalPersonagem.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaxSemanalPersonagem, cargaHorMaxSemanal);
            }
            if (interjornadaElento != "")
            {
                InputInterjornadaMinElenco.EsperarElemento(Browser);
                InputInterjornadaMinElenco.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputInterjornadaMinElenco, interjornadaElento);
            }
            SalvarParametrosProducao();
            PopUpAtencaoParametros();
        }

        public void AlterarParametrosDePeriodoNoturno(string peridoNoturnoInicial, string periodoNoturnoFinal)
        {
            if(peridoNoturnoInicial != "")
            {
                InputPeriodoNoturnoInicial.EsperarElemento(Browser);
                InputPeriodoNoturnoInicial.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoNoturnoInicial, peridoNoturnoInicial);
            }
            if (periodoNoturnoFinal != "")
            {
                InputPeriodoNoturnoFinal.EsperarElemento(Browser);
                InputPeriodoNoturnoFinal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoNoturnoFinal, periodoNoturnoFinal);
            }

            SalvarParametrosProducao();
            PopUpAtencaoParametros();
        }

        private void SalvarParametrosProducao()
		{
			var BtnSalvarParametros = Element.Xpath("//div[@aria-labelledby='ui-id-14']//span[text()='Salvar']");
			BtnSalvarParametros.EsperarElemento(Browser);
			if (BtnSalvarParametros.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvarParametros);
			}
		}

		private void PopUpAtencaoParametros()
		{
			var PopUpAtencao = Element.Id("div-alert-free-html0");

			PopUpAtencao.EsperarElemento(Browser);
			if (PopUpAtencao.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSimPopUpAtencaoParametros);
				PopUpAtencao.EsperarElemento(Browser);
				PopUpAtencao.IsElementVisible(Browser);
				//MouseActions.ClickATM(Browser, BtnOKPopUpAtencaoParametros);
                MouseActions.ClickATM(Browser, BtnCancelarPopUpAtencaoParametros);
            }
		}

        public void FiltrarConsultaDeLog(string Assunto)
        {
            var dropDownAssunto = Element.Css("div[id='filtroEntidade_chzn'] a b");
            var inputAssunto = Element.Css("div[id='filtroEntidade_chzn'] input");
            var inputDataExecucao = Element.Css("input[id='filtroDataLogDe']");
            var BtnBuscarLog = Element.Css("input[id='filtroBuscar']");

            dropDownAssunto.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, dropDownAssunto);
            inputAssunto.EsperarElemento(Browser);
            AutomatedActions.SendDataEnterATM(Browser, inputAssunto, Assunto);
            inputDataExecucao.EsperarElemento(Browser);
            AutomatedActions.SendDataEnterATM(Browser, inputDataExecucao, CalendarioHelper.ObterDataAtual());
            KeyboardActions.Tab(Browser, inputDataExecucao);
            BtnBuscarLog.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnBuscarLog);
        }

        private void ValidarTdText(string Valor)
        {
            var tdText = Element.Xpath("//tr[@class='EntidadeEncontrado Entidade']//td[text()='" + Valor + "']");
            tdText.EsperarElemento(Browser);
            tdText.IsElementVisible(Browser);
        }

        private void ValidarAssuntoText(string Entidade)
        {
            var strongText = Element.Xpath("//tr[@class='EntidadeEncontrado Entidade']//strong[text()='" + Entidade + "']");
            strongText.EsperarElemento(Browser);
            strongText.IsElementVisible(Browser);
        }

        public void ValidarLog(string Usuario, string Evento, string DetalhesEvento, string Entidade)
        {
            ValidarTdText(Usuario);
            ValidarTdText(Evento);
            ValidarTdText(DetalhesEvento);
            ValidarAssuntoText(Entidade);
        }
    }
}
