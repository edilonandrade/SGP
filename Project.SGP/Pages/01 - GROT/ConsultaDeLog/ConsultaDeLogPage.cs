using System;
using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core.Helpers;

namespace Project.SGP.Pages
{
    public class ConsultaDeLogPage : PageBase
    {
        private string ConsultaLogUrl { get; }

        //Select
        public Element SlctAssunto { get; private set; }


        //Inputs
        public Element InpAssunto { get; private set; }
        public Element InpFiltroEntidade { get; private set; }
        public Element InpFiltroLogData { get; private set; }
        public Element InpFiltroEvento { get; private set; }
        public Element InpFiltroUsuario { get; private set; }

        //Buttons
        public Element BtnBuscar { get; private set; }

        public ConsultaDeLogPage(IBrowser browser,
            string consultaLogUrl) : base(browser)
        {
            ConsultaLogUrl = consultaLogUrl;

            //Select
            SlctAssunto = Element.Css("div[id='filtroEntidade_chzn'] a");

            //Inputs
            InpAssunto = Element.Css("div[id='filtroEntidade_chzn'] input");
            InpFiltroEntidade = Element.Css("input[id='filtroEntidadeDe']");
            InpFiltroLogData = Element.Css("input[id='filtroDataLogDe']");
            InpFiltroEvento = Element.Css("div[id='filtroEvento_chzn'] a");
            InpFiltroUsuario = Element.Css("input[id='Usuario']");

            //Buttons
            BtnBuscar = Element.Css("input[id='filtroBuscar']");

        }

        public override void Navegar()
        {
            Browser.Abrir(ConsultaLogUrl);
            Browser.PageLoad();
        }

        public void FiltroConsultaLog(string assunto, string data)
        {
            PreencherAssunto(assunto);
            PreencherDataExecucao(data);

            ClicarBuscarFiltro();
        }

        private void ClicarBuscarFiltro()
        {
            BtnBuscar.EsperarElemento(Browser);
            BtnBuscar.Esperar(Browser, 1000);
            if(BtnBuscar.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnBuscar);
            }
        }

        private void PreencherAssunto(string assunto)
        {
            SlctAssunto.EsperarElemento(Browser);
            SlctAssunto.Esperar(Browser, 1000);
            if (SlctAssunto.IsElementVisible(Browser))
            {
                if(assunto != "")
                {
                    AutomatedActions.TypingListATM(Browser, SlctAssunto, InpAssunto, assunto);
                }
            }
        }

        private void PreencherDataExecucao(string data)
        {
            InpFiltroLogData.EsperarElemento(Browser);
            InpFiltroLogData.Esperar(Browser, 1000);
            if(InpFiltroLogData.IsElementVisible(Browser))
            {
                if(data != "")
                {
                    AutomatedActions.SendDataATM(Browser, InpFiltroLogData, CalendarioHelper.ObterDataAtual());
                    KeyboardActions.Tab(Browser, InpFiltroLogData);
                }
            }
        }

        public void ValidarBusca(string valor)
        {
            var buscaPath = Element.Xpath("//td[contains(., '" + valor + "')]");
            buscaPath.IsElementVisible(Browser);
            buscaPath.Esperar(Browser, 1000);
        }
        public void ValidarBuscaAssunto(string valor)
        {
            var buscaPath = Element.Xpath("//strong[text()='" + valor + "']");
            buscaPath.IsElementVisible(Browser);
            buscaPath.Esperar(Browser, 1000);
        }

        public void ValidarLogPersonagem(string Personagem, string Evento, string DetalhesEvento)
        {
            if(Personagem != "")
            {
                var personagem = Element.Css("tbody tr[class='EntidadeEncontrado Entidade']:nth-child(1) td[class='entidadeLog']");
                string getEntidadeLog = personagem.GetTexto(Browser);
                Assert.AreEqual(getEntidadeLog, Personagem);
            }
            if (Evento != "")
            {
                var personagem = Element.Css("tbody tr[class='EntidadeEncontrado Entidade']:nth-child(1) td[class='eventoLog']");
                string getEntidadeLog = personagem.GetTexto(Browser);
                Assert.AreEqual(getEntidadeLog, Evento);
            }
            if (DetalhesEvento != "")
            {
                var personagem = Element.Css("tbody tr[class='EntidadeEncontrado Entidade']:nth-child(1) td[class='obsLog left']");
                string getEntidadeLog = personagem.GetTexto(Browser);
                Assert.AreEqual(getEntidadeLog, DetalhesEvento);
            }
        }
    }
}
