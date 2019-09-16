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
    public class IndicadoresProdutoPage : PageBase
    {
        //Buttons
        private Element BtnPlanejamento { get; }
        private Element BtnIndicadoresDeProduto { get; }
        private Element BtnDefinicoesDaProducao { get; }
        private Element BtnFecharAba { get; }

        public IndicadoresProdutoPage(IBrowser browser) : base(browser)
        {
            //Buttons
            BtnPlanejamento = Element.Css("img[id='botRoteiroMenu']");
            BtnDefinicoesDaProducao = Element.Css("li[id='testGrupoApps']");
            BtnIndicadoresDeProduto = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/IndicadoresProduto']");
            BtnFecharAba = Element.Css("button[id='buttomModalIframe']");
        }

        public override void Navegar()
        {
            throw new NotImplementedException();
        }

        public void ClicarIndicadoresDeProduto()
        {
            BtnPlanejamento.EsperarElemento(Browser);
            BtnPlanejamento.Esperar(Browser, 2000);
            MouseActions.ClickATM(Browser, BtnPlanejamento);
            BtnDefinicoesDaProducao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnDefinicoesDaProducao);
            BtnIndicadoresDeProduto.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnIndicadoresDeProduto);
        }

        public void AlterarProduto(string NomeProduto)
        {
            var IFrameIndicadores = Element.Id("Iframe");
            var SlctProduto = Element.Css("div[id='Produto_chzn'] a");
            var InpProduto = Element.Css("div[class='chzn-search'] input");

            IFrameIndicadores.EsperarIFrame(Browser);

            SlctProduto.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, SlctProduto);
            InpProduto.EsperarElemento(Browser);
            AutomatedActions.SendDataEnterATM(Browser, InpProduto, NomeProduto);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void FecharTela()
        {
            BtnFecharAba.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFecharAba);
        }

        public void ValidarFecharTela()
        {
            var validarTelaPlanejamentoDeRoteiros = Element.Xpath("//div[@class='submenu']/div[contains(., 'Planejamento de Roteiros')]");
            validarTelaPlanejamentoDeRoteiros.EsperarElemento(Browser);
            validarTelaPlanejamentoDeRoteiros.IsElementVisible(Browser);
        }

        public void ValidarIndicadoresProduto(string NomeProduto)
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            var validarProduto = Element.Xpath("//div[@id='Produto_chzn']//span[text()='" + NomeProduto + "']");
            validarProduto.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }
    }
}
