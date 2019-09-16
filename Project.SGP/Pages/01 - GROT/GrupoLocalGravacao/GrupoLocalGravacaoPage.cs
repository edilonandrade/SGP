using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using System;
using System.Threading;

namespace Project.SGP.Pages
{
    public class GrupoLocalGravacaoPage : PageBase
    {
        private string GrupoLocalGravacaoUrl { get; }

        //Inputs
        public Element InpEndRegiaoA { get; }
        public Element InpEndRegiaoB { get; }
        public Element InpRegiaoFiltro { get; }
        public Element InpNomeLocal { get; }
        public Element InpTempoEquipe { get; }
        public Element InpTempoElenco { get; }
        private Element InputTempoEquipeEdit { get; }
        private Element InputTempoElencoEdit { get; }
        private Element InputNomeEdit { get; }

        //Buttons
        public Element BtnCriarRegiao { get; }
        public Element BtnDetalharRegiao { get; }
        public Element BtnFiltrarRegiao { get; }
        public Element BtnConfirmarExclusao { get; }
        public Element BtnCancelarExclusao { get; }
        public Element BtnCancelarCriacaoLocal { get; }
        public Element BtnLimparLocal { get; }
        public Element BtnSalvarLocal { get; }
        public Element BtnEditar { get; }
        public Element BtnExcluir { get; }
        public Element BtnConfirmarConflitoExclusao { get; }
        private Element BtnSalvar { get; }

        public GrupoLocalGravacaoPage(IBrowser browser,
            string grupoLocalGravacaoUrl) : base(browser)
        {
            GrupoLocalGravacaoUrl = grupoLocalGravacaoUrl;

            //Inputs
            InpEndRegiaoA = Element.Css("input[id='LocalA']");
            InpEndRegiaoB = Element.Css("input[id='LocalB']");
            InpRegiaoFiltro = Element.Css("input[id='NomeFiltro']");
            InpNomeLocal = Element.Css("input[id='Nome_0']");
            InpTempoEquipe = Element.Css("input[id='TempoEquipe_0']");
            InpTempoElenco = Element.Css("input[id='TempoElenco_0']");
            InputTempoEquipeEdit = Element.Css("input[id='TempoEquipe']");
            InputTempoElencoEdit = Element.Css("input[id='TempoElenco']");
            InputNomeEdit = Element.Css("input[id='Nome']");

            //Buttons
            BtnCriarRegiao = Element.Css("button[id='Criarbtn']");
            BtnDetalharRegiao = Element.Css("button[id='Detalharbtn']");
            BtnFiltrarRegiao = Element.Css("button[id='filtrarbtn']");
            BtnConfirmarExclusao = Element.Css("button[class='btn btn btn-primary exclusaoGrupoLocalGravacao']");
            BtnCancelarExclusao = Element.Css("button[class='btn btn btn-tertiary cancelar-acao']");
            BtnCancelarCriacaoLocal = Element.Css("a[id='cancelarForm']");
            BtnLimparLocal = Element.Css("input[id='btnLimpar']");
            BtnSalvarLocal = Element.Css("input[id='btnSaveCriarLocal']");
            BtnSalvar = Element.Css("input[id='btnSave']");
            //BtnDetalhes = Element.Xpath("//strong[text()='INMETRICS REGIAO']/../..//a[@class='icon-button icon-down collapse-down collapsed']");
            BtnEditar = Element.Css("a[class='icon-button icon-edit editar-GrupoLocalGravacao']");
            BtnExcluir = Element.Css("a[class='icon-button icon-delete excluir-GrupoLocalGravacao']");
            BtnConfirmarConflitoExclusao = Element.Css("button[class='btn btn btn-primary conflitoRoteiro']");
        }

        public override void Navegar()
        {
            Browser.Abrir(GrupoLocalGravacaoUrl);
            Browser.PageLoad();
        }

        public void CriarGrupoLocalGravacao(string NomeLocal, string TempoEquipe, string TempoElenco)
        {
            BtnCriarRegiao.Esperar(Browser, 2000);
            BtnCriarRegiao.EsperarElemento(Browser);
            BtnCriarRegiao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnCriarRegiao);

            if(NomeLocal != "")
            {
                InpNomeLocal.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpNomeLocal, NomeLocal);
            }
            if(TempoEquipe != "")
            {
                InpTempoEquipe.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpTempoEquipe, TempoEquipe);
            }
            if (TempoElenco != "")
            {
                InpTempoElenco.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpTempoElenco, TempoElenco);
            }

            BtnSalvarLocal.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarLocal);
        }

        public void FiltroGrupoLocalGravacao(string RegiaoA, string RegiaoB, string NomeLocal)
        {
            if (RegiaoA != "")
            {
                InpEndRegiaoA.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpEndRegiaoA, RegiaoA);
            }
            if (RegiaoB != "")
            {
                InpEndRegiaoB.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpEndRegiaoB, RegiaoB);
            }
            if (NomeLocal != "")
            {
                InpRegiaoFiltro.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InpRegiaoFiltro, NomeLocal);
            }

            BtnFiltrarRegiao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarRegiao);
        }

        public void AlterarGrupoLocalGravacao(string NomeLocal, string TempoEquipe, string TempoElenco)
        {
            BtnEditar.EsperarElemento(Browser);
            BtnEditar.Esperar(Browser, 2000);
            BtnEditar.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnEditar);

            if (NomeLocal != "")
            {
                InputNomeEdit.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputNomeEdit, NomeLocal);
            }
            if (TempoEquipe != "")
            {
                InputTempoEquipeEdit.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputTempoEquipeEdit, TempoEquipe);
            }
            if (TempoElenco != "")
            {
                InputTempoElencoEdit.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputTempoElencoEdit, TempoElenco);
            }

            BtnSalvar.EsperarElemento(Browser);
            BtnSalvar.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvar);
        }

        private void ClicarExcluirGrupoLocalGravacao()
        {
            BtnExcluir.EsperarElemento(Browser);
            BtnExcluir.Esperar(Browser, 3000);
            BtnExcluir.IsElementVisible(Browser);
            BtnExcluir.IsClickable(Browser);
            MouseActions.ClickATM(Browser, BtnExcluir);
        }

        private void ConfirmarExclusao()
        {
            BtnConfirmarExclusao.EsperarElemento(Browser);
            BtnConfirmarExclusao.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnConfirmarExclusao);
        }

        public void ExcluirGrupoLocalGravacao()
        {
            ClicarExcluirGrupoLocalGravacao();

            var textoPath = Element.Xpath("//p[text()='A Região será excluída e não poderá ser recuperada, assim como seus deslocamentos em outras Regiões. Tem certeza que deseja excluir esta Região?']");
            textoPath.EsperarElemento(Browser);
            textoPath.IsElementVisible(Browser);

            ConfirmarExclusao();
            Thread.Sleep(2000);
        }

        public void ExcluirGrupoLocalGravacaoComCapituloAssociadoText()
        {
            var excluir = Element.Xpath("//strong[text()='INMETRICS REGIAO 2']/../..//a[@class='icon-button icon-delete excluir-GrupoLocalGravacao']");
            excluir.Esperar(Browser, 2000);
            excluir.EsperarElemento(Browser);
            excluir.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, excluir);

            var textPath1 = Element.Xpath("//p[text()='Exclusão não permitida, pois existem cenas associadas a esta região. Favor revisar as cenas abaixo, antes de solicitar a exclusão']");
            var strongPath1 = Element.Xpath("//p/strong[text()='Capítulo']");
            var textPath2 = Element.Xpath("//p[text()=': 0500 | ']");
            var strongPath2 = Element.Xpath("//p/strong[text()=' Cena: ']");
            var textPath3 = Element.Xpath("//p[text()='008']");

            textPath1.Esperar(Browser, 2000);
            textPath1.EsperarElemento(Browser);
            textPath1.IsElementVisible(Browser);
            strongPath1.IsElementVisible(Browser);
            textPath2.IsElementVisible(Browser);
            strongPath2.IsElementVisible(Browser);
            textPath3.IsElementVisible(Browser);

            BtnConfirmarConflitoExclusao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnConfirmarConflitoExclusao);
        }

        private void ValidarLocalPath(string Valor)
        {
            var localPath = Element.Xpath("//strong[text()='" + Valor + "']");
            localPath.EsperarElemento(Browser);
            localPath.Esperar(Browser, 2000);
            localPath.IsElementVisible(Browser);
        }

        public void ValidarGrupoLocalGravacao(string NomeRegiao, string TempoEquipe, string TempoElenco)
        {
            if(NomeRegiao != "")
            {
                ValidarLocalPath(NomeRegiao);
            }
            if (TempoEquipe != "")
            {
                ValidarLocalPath(TempoEquipe);
            }
            if (TempoElenco != "")
            {
                ValidarLocalPath(TempoElenco);
            }
        }

        public void ValidarMensagemDeAlteracao(string capitulo, string cena)
        {
            var mensagemInit = Element.Xpath("//p[contains(., 'Existem cenas que utilizam essa região alterada/cadastrada, revisar os seguinte(s) itens:')]");
            var capituloPath = Element.Xpath("//p[contains(., '" + capitulo + "')]");
            var cenaPath = Element.Xpath("//p[contains(., '" + cena + "')]");
            var mensagemEnd = Element.Xpath("//p[contains(., 'e podem influenciar no resultado do planejamento e/ou rascunho de planejamento, deseja continuar? Cenas já roteirizadas não serão impactadas por estas alterações.')]");

            mensagemInit.IsElementVisible(Browser);
            capituloPath.IsElementVisible(Browser);
            cenaPath.IsElementVisible(Browser);
            mensagemEnd.IsElementVisible(Browser);
        }
    }
}
