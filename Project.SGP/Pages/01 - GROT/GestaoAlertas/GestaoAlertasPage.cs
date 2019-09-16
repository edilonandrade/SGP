using Framework.Core.PageObjects;
using System;
using Framework.Core.Interfaces;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Actions;
using System.Threading;

namespace Project.SGP.Pages
{
    public class GestaoAlertasPage : PageBase
    {
        private string GestaoAlertaUrl { get; }
        private Element AreaAlerta { get; set; }
        private Element TextoAlerta { get; set; }
        private Element ImagemAlerta { get; set; }
        private Element CheckBoxItem { get; set; }
        private Element ChckItensSelecionados { get; }
        private Element ChckItensNaoSelecionados { get; }
        private Element BtnFiltrar { get; }
        private Element BtnFechar { get; }
        private Element ChckSelecionarTodos { get; }
        private Element ListAlertas { get; }
        private Element InputListAlertas { get; }
        private Element SelectListAlerta { get; }
        private Element ItemListAlerta { get; set; }

        public GestaoAlertasPage(IBrowser browser, string gestaoAlertaUrl) : base(browser)
        {
            GestaoAlertaUrl = gestaoAlertaUrl;

            BtnFiltrar = Element.Css("button[id='filtrarbtn']");
            BtnFechar = Element.Css("button[id='Fecharbtn']");
            ListAlertas = Element.Css("select[id='Nomefiltro']");
            InputListAlertas = Element.Xpath("//*[@id='Nomefiltro_chosen']//input");
            ChckSelecionarTodos = Element.Css("input[name='nSelecioanarTodos']");
            ChckItensSelecionados = Element.Css("input[name='Visualiza']");
            ChckItensNaoSelecionados = Element.Css("input[name='nVisualiza']");
            SelectListAlerta = Element.Xpath("//*[@id='Nomefiltro_chosen']");
        }

        //Validações

        public void ValidarArea(string textoArea)
        {
            AreaAlerta = Element.Xpath("//th[text()='" + textoArea + "']");
            AreaAlerta.IsElementVisible(Browser);
        }

        public void ValidarTexto(string texto)
        {
            TextoAlerta = Element.Xpath("//td[text()='" + texto + "']");
            TextoAlerta.IsElementVisible(Browser);
        }

        public void ValidarImgem(string nomeImagem)
        {
            ImagemAlerta = Element.Css("img[src = 'Images/GROT/25X24-AZUL/" + nomeImagem + "']");
            ImagemAlerta.IsElementVisible(Browser);
        }

        public void MarcarItemCheckBox(string texto)
        {
            CheckBoxItem = Element.Xpath("//td[text()='" + texto + "']/..//input[1]");
            CheckBoxItem.ClicarEsperarElemento(Browser);
        }

        public void ValidarItemCheckBox(string texto)
        {
            CheckBoxItem = Element.Xpath("//td[text()='" + texto + "']/..//input[1]");
            CheckBoxItem.IsElementSelected(Browser);
        }

        public void MarcarCheckBoxTodos(bool marcarTodos)
        {
            if (marcarTodos)
            {
                //Se desejo marcar todos e opcao ja estiver selecionada eu nao faço nada
                if (ChckSelecionarTodos.IsElementSelected(Browser))
                {
                    ChckSelecionarTodos.ClicarEsperarElemento(Browser);
                    ChckSelecionarTodos.ClicarEsperarElemento(Browser);
                }
                else
                {
                    ChckSelecionarTodos.ClicarEsperarElemento(Browser);
                }
            }
            else 
            {
                // Desmarcar todos 
                if (ChckSelecionarTodos.IsElementSelected(Browser))
                {
                    ChckSelecionarTodos.ClicarEsperarElemento(Browser);
                }
                else
                {
                    ChckSelecionarTodos.ClicarEsperarElemento(Browser);
                    ChckSelecionarTodos.ClicarEsperarElemento(Browser);
                }
            }
            Thread.Sleep(1000);
        }

        public void MarcarCheckItensSelecionados(bool marcar)
        {
            if (marcar)
            {
                if (!ChckItensSelecionados.IsElementSelected(Browser))
                    ChckItensSelecionados.ClicarEsperarElemento(Browser);
            } else
            {
                if (ChckItensSelecionados.IsElementSelected(Browser))
                    ChckItensSelecionados.ClicarEsperarElemento(Browser);
            }
            Thread.Sleep(2000);
        }

        public void MarcarCheckItensNaoSelecionados(bool marcar)
        {
            if (marcar)
            {
                if (!ChckItensNaoSelecionados.IsElementSelected(Browser))
                    ChckItensNaoSelecionados.ClicarEsperarElemento(Browser);
            }
            else
            {
                if (ChckItensNaoSelecionados.IsElementSelected(Browser))
                    ChckItensNaoSelecionados.ClicarEsperarElemento(Browser);
            }
            Thread.Sleep(2000);
        }

        public void BtnFiltrarAlertas()
        {
            if (BtnFiltrar.IsElementVisible(Browser))
                MouseActions.ClickATM(Browser, BtnFiltrar);
            Thread.Sleep(2000);

        }

        public void BtnFecharAlertas()
        {
            if (BtnFechar.IsElementVisible(Browser))
                MouseActions.ClickATM(Browser, BtnFechar);
            Thread.Sleep(2000);
            Browser.RefreshPage();
        }

        public void SelecionarListaAlerta()
        {
            if (SelectListAlerta.IsClickable(Browser))
            {
                SelectListAlerta.ClicarEsperarElemento(Browser);
                SelectListAlerta.EsperarElemento(Browser);
            }
        }

        public void SelecionarItemAlertaNaLista(string textoAlerta)
        {
            AutomatedActions.SendDataEnterATM(Browser, InputListAlertas, textoAlerta);
        }

        public void FiltrarItensAlertasNaListaPorNome(string textoAlerta)
        {

            InputListAlertas.EsperarElemento(Browser);
            if (InputListAlertas.IsElementVisible(Browser))
                AutomatedActions.SendDataEnterATM(Browser, InputListAlertas, textoAlerta);
        }

        public void NavegarTela(string url)
        {
            Browser.Abrir(url);
        }

        public override void Navegar()
        {
            Browser.Abrir(GestaoAlertaUrl);
        }
    }
}
