using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using System;
using System.Threading;

namespace Project.SGP.Pages
{
    public class LocalGravacaoPage : PageBase
    {
        public string LocalGravacaoUrl { get; }

        //Inputs
        private Element InpNomeLocal { get; }
        private Element InpRegiaoFiltro { get; }
        private Element InpNomeNovoLocal { get; }
        private Element InpViagem { get; }
        private Element InpTipoLocal { get; }
        private Element InpRegiao { get; }

        private Element DropdownTipoLocal { get; }
        private Element DropdownRegiao { get; }


        //Buttons
        private Element BtnFiltrar { get; }
        private Element BtnNovoLocal { get; }
        private Element BtnSalvarLocal { get; }
        private Element BtnSalvarECriarNovoLocal { get; }
        private Element BtnEditarLocal { get; }
        private Element BtnExcluirLocal { get; }
        private Element BtnSalvarEdicao { get; }
        private Element BtnConfirmarExclusao { get; }
        private Element BtnCancelarExclusao { get; }

        public LocalGravacaoPage(IBrowser browser,
            string localGravacaoUrl) : base(browser)
        {
            LocalGravacaoUrl = localGravacaoUrl;

            //Inputs
            InpNomeLocal = Element.Css("input[id='Enderecofiltro']");
            InpRegiaoFiltro = Element.Css("input[id='Localfiltro']");
            InpNomeNovoLocal = Element.Css("input[id='Endereco']");
            InpViagem = Element.Css("input[id='Viagem']");
            InpTipoLocal = Element.Css("div[id='Tipofiltro_chosen'] input");
            InpRegiao = Element.Css("div[id='GrupoLocalGravacao_chosen'] input");

            DropdownTipoLocal = Element.Css("div[id='Tipofiltro_chosen'] b");
            DropdownRegiao = Element.Css("div[id='GrupoLocalGravacao_chosen'] b");

            //Buttons
            BtnFiltrar = Element.Css("button[id='filtrarbtn']");
            BtnNovoLocal = Element.Css("button[id='NovoLocalGravacao']");
            BtnSalvarLocal = Element.Css("button[class='btn btn btn-default salvarLocalGravacao']");
            BtnSalvarECriarNovoLocal = Element.Css("button[class='btn btn btn-primary salvarCriarLocalGravacao']");
            BtnEditarLocal = Element.Css("a[title='Editar este local']");
            BtnExcluirLocal = Element.Css("a[title='Excluir este local']");
            BtnSalvarEdicao = Element.Css("button[class='btn btn btn-primary editarLocalGravacao']");
            BtnConfirmarExclusao = Element.Css("button[class='btn btn btn-primary exclusaoLocalGravacao']");
            BtnCancelarExclusao = Element.Css("button[class='btn btn btn-tertiary cancelar-acao']");
        }
        
        //private void SlctTipoLocal(string TipoLocal)
        //{
        //    //TipoLocal 1 = Estudio
        //    //TipoLocal 2 = Externo
        //    //TipoLocal 3 = Cidade Cenográfica

        //    var tipoLocal = Element.Css("div[class='chosen-drop'] li[data-option-array-index='" + TipoLocal + "']");
        //    tipoLocal.EsperarElemento(Browser);
        //    tipoLocal.IsElementVisible(Browser);
        //    MouseActions.ClickATM(Browser, tipoLocal);
        //}

        public override void Navegar()
        {
            Browser.Abrir(LocalGravacaoUrl);
            Browser.PageLoad();
        }

        private void ClicarNovoLocal()
        {
            BtnNovoLocal.Esperar(Browser, 2000);
            BtnNovoLocal.EsperarElemento(Browser);
            BtnNovoLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovoLocal);
        }

        private void ClicarFiltrarLocal()
        {
            BtnFiltrar.EsperarElemento(Browser);
            BtnFiltrar.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        private void ClicarSalvarNovoLocal()
        {
            BtnSalvarLocal.EsperarElemento(Browser);
            BtnSalvarLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarLocal);
        }

        private void ClicarEditarLocal()
        {
            BtnEditarLocal.Esperar(Browser, 2000);
            BtnEditarLocal.EsperarElemento(Browser);
            BtnEditarLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnEditarLocal);
        }

        private void ClicarExcluirLocal()
        {
            BtnExcluirLocal.Esperar(Browser, 2000);
            BtnExcluirLocal.EsperarElemento(Browser);
            BtnExcluirLocal.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnExcluirLocal);
        }

        private void ClicarCancelarExclusao()
        {
            BtnCancelarExclusao.EsperarElemento(Browser);
            BtnCancelarExclusao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnCancelarExclusao);
        }

        private void ClicarConfirmarExclusao()
        {
            BtnConfirmarExclusao.EsperarElemento(Browser);
            BtnConfirmarExclusao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnConfirmarExclusao);
        }

        private void ClicarSalvarEdicao()
        {
            BtnSalvarEdicao.EsperarElemento(Browser);
            BtnSalvarEdicao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarEdicao);
        }

        public void FiltrarLocalGravacao(string NomeLocal, string TipoLocal, string Regiao)
        {
            if(NomeLocal != "")
            {
                InpNomeLocal.Esperar(Browser, 2000);
                InpNomeLocal.EsperarElemento(Browser);
                InpNomeLocal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpNomeLocal, NomeLocal);
            }
            if (TipoLocal != "")
            {
                DropdownTipoLocal.EsperarElemento(Browser);
                DropdownTipoLocal.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, DropdownTipoLocal);

                InpTipoLocal.EsperarElemento(Browser);
                InpTipoLocal.IsElementVisible(Browser);
                AutomatedActions.SendDataEnterATM(Browser, InpTipoLocal, TipoLocal);
            }
            if (Regiao != "")
            {
                InpRegiaoFiltro.EsperarElemento(Browser);
                InpRegiaoFiltro.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpRegiaoFiltro, Regiao);
            }

            ClicarFiltrarLocal();
        }

        public void CriarNovoLocal(string NomeLocal, string Viagem, string Regiao)
        {
            ClicarNovoLocal();

            if(NomeLocal != "")
            {
                InpNomeNovoLocal.Esperar(Browser, 2000);
                InpNomeNovoLocal.EsperarElemento(Browser);
                InpNomeNovoLocal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpNomeNovoLocal, NomeLocal);
            }
            if (Viagem != "")
            {
                InpViagem.EsperarElemento(Browser);
                InpViagem.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpViagem, Viagem);
            }
            if (Regiao != "")
            {
                DropdownRegiao.EsperarElemento(Browser);
                DropdownRegiao.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, DropdownRegiao);

                InpRegiao.EsperarElemento(Browser);
                InpRegiao.IsElementVisible(Browser);
                AutomatedActions.SendDataEnterATM(Browser, InpRegiao, Regiao);
            }

            ClicarSalvarNovoLocal();
        }

        public void EditarLocal(string NomeLocal)
        {
            ClicarEditarLocal();

            if (NomeLocal != "")
            {
                InpNomeNovoLocal.Esperar(Browser, 2000);
                InpNomeNovoLocal.EsperarElemento(Browser);
                InpNomeNovoLocal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InpNomeNovoLocal, NomeLocal);
            }

            ClicarSalvarEdicao();
        }

        public void ExcluirLocalGravacao()
        {
            ClicarExcluirLocal();

            var alerta = Element.Xpath("//p[text()='O Local será excluído e não poderá ser recuperado. Tem certeza que deseja excluir este local?']");
            alerta.EsperarElemento(Browser);
            alerta.IsElementVisible(Browser);

            ClicarConfirmarExclusao();
        }

        public void ExcluirLocalComCenasAssociadas()
        {
            ClicarExcluirLocal();

            var alerta = Element.Xpath("//p[text()='Existem cenas associadas a essa localização, deseja adicionar outra localização?']");
            alerta.Esperar(Browser, 1000);
            alerta.EsperarElemento(Browser);
            alerta.IsElementVisible(Browser);

            ClicarCancelarExclusao();
        }

        private void ValidarLocalText(string Valor)
        {
            if(Valor != "")
            {
                var path = Element.Xpath("//strong[text()='" + Valor + "']");
                path.EsperarElemento(Browser);
                path.IsElementVisible(Browser);
            }            
        }

        private void EsperaLoading()
        {
            var esperaPath = Element.Css("div[id='loading']");
            esperaPath.IsNotElementVisible(Browser); ;
        }

        public void ValidarLocal(string Nome, string TipoLocal, string Tamanho, string ForcaTrabalho, string Viagem, string Regiao)
        {
            EsperaLoading();

            ValidarLocalText(Nome);
            ValidarLocalText(TipoLocal);
            ValidarLocalText(Tamanho);
            ValidarLocalText(ForcaTrabalho);
            ValidarLocalText(Viagem);
            ValidarLocalText(Regiao);

            Thread.Sleep(2000);
        }
    }
}
