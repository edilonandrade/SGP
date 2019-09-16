using System;
using Framework.Core.Actions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.SGP.Pages
{
    public class IndisponibilidadeLocaisPage : PageBase
    {
        private string IndisponibilidadeLocal { get; }

        //Inputs
        public Element InpNomeLocalFiltro { get; }
        public Element InpIntervalo { get; }
        public Element InpDataFiltro { get; }
        public Element InpDataFimFiltro { get; }
        public Element InpNovaIndisponibilidadeLocal { get; }

        //Buttons
        public Element BtnFiltrarIndisponibilidadeLocais { get; }
        private Element BtnNovaIndisponibilidadeDeLocais { get; }
        private Element BtnSalvarIndisponibilidadeLocais { get; }
        private Element BtnExcluirIndisponibilidade { get; }
        private Element BtnModalExcluirIndisponibilidade { get; }
        private Element BtnSalvarECriarNovaIndisponibilidade { get; }


        private Element DropNovaIndisponibilidadeLocal { get; }
        private Element ChkAPartirDataAtual { get; }
        private Element ChkAPartirDataFim { get; }
        
        private Element DropDownPeriodos { get; }
        private Element DropUpPeriodos { get; }
        

        public IndisponibilidadeLocaisPage(IBrowser browser,
            string indisponibilidadeLocal) : base(browser)
        {
            IndisponibilidadeLocal = indisponibilidadeLocal;

            //Inputs
            InpNomeLocalFiltro = Element.Css("input[id='Endereco']");
            InpIntervalo = Element.Css("input[id='Intervalo']");
            InpDataFiltro = Element.Css("input[id='DataIniciofiltro']");
            InpDataFimFiltro = Element.Css("input[id='DataFimfiltro']");
            InpNovaIndisponibilidadeLocal = Element.Css("div[id='LocalGravacao_chosen'] input");

            //Buttons
            BtnFiltrarIndisponibilidadeLocais = Element.Css("button[id='filtrarbtn']");
            BtnNovaIndisponibilidadeDeLocais = Element.Css("button[id='NovoIndisponibilidadeLocais']");
            BtnSalvarIndisponibilidadeLocais = Element.Css("button[class='btn btn btn-default salvarIndisponibilidadeLocais']");
            BtnSalvarECriarNovaIndisponibilidade = Element.Css("button[class='btn btn btn-primary salvarCriarIndisponibilidadeLocais']");
            BtnExcluirIndisponibilidade = Element.Css("a[class='icon-button icon-delete excluir-IndisponibilidadeLocais']");
            BtnModalExcluirIndisponibilidade = Element.Css("button[class='btn btn btn-primary exclusaoIndisponibilidadeLocais']");


            DropNovaIndisponibilidadeLocal = Element.Css("div[id='LocalGravacao_chosen'] > a");
            ChkAPartirDataAtual = Element.Css("label[for='IndDataInicio']");
            ChkAPartirDataFim = Element.Css("label[for='IndDataFim']");
            
            DropDownPeriodos = Element.Css("a[class='icon-button icon-down collapse-down']");
            DropUpPeriodos = Element.Css("a[class='icon-button icon-up collapse-up']");
            
        }

        public override void Navegar()
        {
            Browser.Abrir(IndisponibilidadeLocal);
            Browser.PageLoad();
        }

        private void ClicarFiltrar()
        {
            BtnFiltrarIndisponibilidadeLocais.Esperar(Browser, 1000);
            BtnFiltrarIndisponibilidadeLocais.EsperarElemento(Browser);
            BtnFiltrarIndisponibilidadeLocais.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarIndisponibilidadeLocais);
        }

        private void FiltrarDiaDaSemana(string DiaSemana)
        {
            if(DiaSemana != "")
            {
                var diaSemana = Element.Css("input[id='" + DiaSemana + "']");
                diaSemana.Esperar(Browser, 1000);
                diaSemana.EsperarElemento(Browser);

                string chckDiaSemana = "$('input[id=\"" + DiaSemana + "\"]').click();";
                JsActions.JavaScript(Browser, chckDiaSemana);
            }
        }

        private void FiltrarNomeLocal(string NomeLocal)
        {
            if(NomeLocal != "")
            {
                InpNomeLocalFiltro.Esperar(Browser, 1000);
                InpNomeLocalFiltro.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpNomeLocalFiltro, NomeLocal);
                KeyboardActions.Tab(Browser, InpNomeLocalFiltro);
            }
        }

        private void FiltrarDataIndisonibilidade(string Intervalo)
        {
            if(Intervalo != "")
            {
                InpIntervalo.Esperar(Browser, 1000);
                InpIntervalo.EsperarElemento(Browser);
                //MouseActions.ClickATM(Browser, InpIntervalo);

                JsActions.JavaScript(Browser, "$('input[id=\"Intervalo\"]').click();");

                InpDataFiltro.EsperarElemento(Browser);
                InpDataFiltro.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpDataFiltro, CalendarioHelper.ObterDataAtual());
                KeyboardActions.Tab(Browser, InpDataFiltro);

                InpDataFimFiltro.EsperarElemento(Browser);
                InpDataFimFiltro.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpDataFimFiltro, CalendarioHelper.ObterDataFutura(5));
                KeyboardActions.Tab(Browser, InpDataFimFiltro);
            }
        }

        public void FiltrarIndisponibilidadeLocais(string NomeLocal, string Periodo, string DiaSemana)
        {
            FiltrarNomeLocal(NomeLocal);
            FiltrarDataIndisonibilidade(Periodo);
            FiltrarDiaDaSemana(DiaSemana);

            ClicarFiltrar();
        }

        public void CadastrarIndisponibilidadeLocal(string local)
        {
            BtnNovaIndisponibilidadeDeLocais.Esperar(Browser, 2000);
            BtnNovaIndisponibilidadeDeLocais.EsperarElemento(Browser);
            BtnNovaIndisponibilidadeDeLocais.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovaIndisponibilidadeDeLocais);

            DropNovaIndisponibilidadeLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, DropNovaIndisponibilidadeLocal);
            InpNovaIndisponibilidadeLocal.EsperarElemento(Browser);
            AutomatedActions.SendDataEnterATM(Browser, InpNovaIndisponibilidadeLocal, local);

            ChkAPartirDataAtual.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, ChkAPartirDataAtual);
            ChkAPartirDataFim.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, ChkAPartirDataFim);

            SelecionarDias();

            //SalvarIndisponibilidadeLocal();
        }

        public void CadastrarIndisponibilidadeLocal2(string local)
        {
            DropNovaIndisponibilidadeLocal.EsperarElemento(Browser);
            DropNovaIndisponibilidadeLocal.Esperar(Browser, 2000);
            DropNovaIndisponibilidadeLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, DropNovaIndisponibilidadeLocal);
            InpNovaIndisponibilidadeLocal.EsperarElemento(Browser);
            AutomatedActions.SendDataEnterATM(Browser, InpNovaIndisponibilidadeLocal, local);

            ChkAPartirDataAtual.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, ChkAPartirDataAtual);
            ChkAPartirDataFim.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, ChkAPartirDataFim);

            SelecionarDias();

            //SalvarIndisponibilidadeLocal();
        }

        public void SalvarIndisponibilidadeLocal()
        {
            BtnSalvarIndisponibilidadeLocais.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarIndisponibilidadeLocais);

            VerificarInclusaoLocal("Inserido com sucesso");
        }

        public void SalvarECriarNovaIndisponibilidadeLocal()
        {
            BtnSalvarECriarNovaIndisponibilidade.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarECriarNovaIndisponibilidade);

            VerificarInclusaoLocal("Inserido com sucesso");
        }

        private void SelecionarDias()
        {
            int i = 0;
            while (i <= 6)
            {
                var chkdia = Element.Css("label[for='IndDiaTodo" + i + "']");
                MouseActions.ClickATM(Browser, chkdia);
                i++;
            }
        }

        public void ExcluirIndisponibilidadeLocais()
        {
            DropDownPeriodos.Esperar(Browser, 1000);
            DropDownPeriodos.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, DropDownPeriodos);

            BtnExcluirIndisponibilidade.EsperarElemento(Browser);
            BtnExcluirIndisponibilidade.Esperar(Browser, 2000);
            BtnExcluirIndisponibilidade.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnExcluirIndisponibilidade);

            var alerta = Element.Xpath("//p[text()='A Indisponibilidade de local será excluída e não poderá ser recuperada. Tem certeza que deseja excluir esta Indisponibilidade de local?']");
            alerta.EsperarElemento(Browser);
            alerta.IsElementVisible(Browser);

            BtnModalExcluirIndisponibilidade.EsperarElemento(Browser);
            BtnModalExcluirIndisponibilidade.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnModalExcluirIndisponibilidade);
        }

        public void ValidarIndisponibilidadeCadastrada(string Local)
        {
            var localcadastrado = Element.Xpath("//strong[text()='" + Local + "']");
            localcadastrado.Esperar(Browser, 2000);
            localcadastrado.EsperarElemento(Browser);
            localcadastrado.IsElementVisible(Browser);
        }

        public void ValidarIndisponibilidadeExcluida(string Local)
        {
            var localcadastrado = Element.Xpath("//strong[text()='" + Local + "']");
            localcadastrado.IsNotElementVisible(Browser);
        }

        public void VerificarInclusaoLocal(string mensagem)
        {
            var InclusaoSucesso = Element.Css("div[class='container']");
            string Alerta = InclusaoSucesso.GetTexto(Browser).Trim();
            string newAlert = Alerta.Substring(3);

            Assert.AreEqual(mensagem, newAlert);
        }

    }
}
