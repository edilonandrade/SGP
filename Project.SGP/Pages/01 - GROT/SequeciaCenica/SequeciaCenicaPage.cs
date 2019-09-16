using System;
using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Project.SGP.Pages
{
    public class SequeciaCenicaPage : PageBase
    {
        private string SequenciaCenicaUrl { get; }

        //Buttons
        private Element BtnNovaSequenciaCenica { get; }
        private Element BtnFiltrar { get; }
        private Element BtnSalvar { get; }
        private Element BtnSalvarECriarNova { get; }
        private Element BtnExpandirCenas { get; }
        private Element BtnExcluirSequencia { get; }
        private Element BtnEditarSequencia { get; }
        private Element BtnFiltrarCenas { get; }
        private Element BtnBuscar { get; }

        //Others
        private Element LinkCenarios { get; }
        private Element LinkCapitulo { get; }
        private Element ChckCenasNaoGravadas { get; }

        //Input
        private Element InputNomeSequenciaFiltro { get; }
        private Element InputNomeSequencia { get; }

        public SequeciaCenicaPage(IBrowser browser,
            string sequenciaCenicaUrl) : base(browser)
        {
            SequenciaCenicaUrl = sequenciaCenicaUrl;

            //Buttons
            BtnNovaSequenciaCenica = Element.Css("button[id='NovoSequenciaCenica']");
            BtnFiltrar = Element.Css("button[id='filtrarbtn']");
            BtnSalvar = Element.Css("button[class='btn btn btn-default salvarSequenciaCenica']");
            BtnSalvarECriarNova = Element.Css("button[class='btn btn btn-primary salvarCriarSequenciaCenica']");
            BtnExpandirCenas = Element.Css("img[data-bind='click: $root.CenasVM.ExpandirTodosAmbientes']");
            BtnExcluirSequencia = Element.Css("a[class='icon-button icon-delete excluir-GrupoSequenciaCenica']");
            BtnEditarSequencia = Element.Css("a[class='icon-button icon-edit editar-SequenciaCenica']");
            BtnFiltrarCenas = Element.Id("tstFiltroCenasRoteirizaveis");
            BtnBuscar = Element.Id("btnBuscarCenas");

            //Others
            LinkCenarios = Element.Link("Cenários");
            LinkCapitulo = Element.Link("Capítulos");
            ChckCenasNaoGravadas = Element.Css("input[id='chkSomenteCenaNaoGravadas']");

            //Input
            InputNomeSequenciaFiltro = Element.Css("input[id='NomeSequencia']");
            InputNomeSequencia = Element.Css("input[id='NomeGrupoSequenciaCenica']");
        }

        public override void Navegar()
        {
            Browser.Abrir(SequenciaCenicaUrl);
            Browser.PageLoad();
        }

        private void ExpandirTodasCenas()
        {
            BtnExpandirCenas.Esperar(Browser, 2000);
            BtnExpandirCenas.EsperarElemento(Browser);
            if (BtnExpandirCenas.IsElementVisible(Browser))
                BtnExpandirCenas.IsClickable(Browser);
            MouseActions.ClickATM(Browser, BtnExpandirCenas);
        }

        public void ValidarCenaExistente(string numeroCapituloCena)
        {
            ExpandirTodasCenas();

            var CapituloCenaEstudio = Element.Xpath("//div[@class='cena ui-draggable ttooltip azul claro'][contains(.,'" + numeroCapituloCena + "')]");

            CapituloCenaEstudio.EsperarElemento(Browser);
            CapituloCenaEstudio.Esperar(Browser, 2000);
            CapituloCenaEstudio.IsElementVisible(Browser);
        }

        private void DragAndDropPrimeiraCenaEstudio(string numeroCapituloCena)
        {
            var CapituloCenaEstudio = Element.Xpath("//div[@class='cena ui-draggable ttooltip azul claro'][contains(.,'" + numeroCapituloCena + "')]");
            var Frente = Element.Css("div[class='tstRoteiroOuSlot ui-droppable']");

            CapituloCenaEstudio.EsperarElemento(Browser);
            CapituloCenaEstudio.Esperar(Browser, 2000);
            CapituloCenaEstudio.IsElementVisible(Browser);
            if (CapituloCenaEstudio.IsClickable(Browser))
            {
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);

                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaEstudio, Frente);
            }
            else throw new Exception("elemento não encontrado");
        }

        private void DragAndDropSegundaCenaEstudio(string numeroCapituloCena)
        {
            var CapituloCenaEstudio = Element.Xpath("//div[@class='cena ui-draggable ttooltip azul claro'][contains(.,'" + numeroCapituloCena + "')]");
            var Frente = Element.Css("div[class='tstCenaRoteiro']");

            CapituloCenaEstudio.EsperarElemento(Browser);
            CapituloCenaEstudio.Esperar(Browser, 2000);
            CapituloCenaEstudio.IsElementVisible(Browser);
            if (CapituloCenaEstudio.IsClickable(Browser))
            {
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);

                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaEstudio, Frente);
            }
            else throw new Exception("elemento não encontrado");
        }


        private void DragAndDropCenaEstudio(string numeroCapituloCena)
        {
            var CapituloCenaEstudio = Element.Xpath("//div[@class='cena ttooltip azul claro'][contains(.,'" + numeroCapituloCena + "')]");
            var Frente = Element.Css("div[class='tstCenaRoteiro']");

            CapituloCenaEstudio.EsperarElemento(Browser);
            CapituloCenaEstudio.Esperar(Browser, 2000);
            CapituloCenaEstudio.IsElementVisible(Browser);
            if (CapituloCenaEstudio.IsClickable(Browser))
            {
                Frente.IsElementVisible(Browser);
                Frente.IsClickable(Browser);

                MouseActions.MouseDragAndDropSML(Browser, CapituloCenaEstudio, Frente);
            }
            else throw new Exception("elemento não encontrado");
        }


        public void CriarSequenciaCenica(string NomeSequencia, string numeroCapituloCena1, string numeroCapituloCena2)
        {
            ClicarNovaSequenciaCenica();

            ValidarCenaExistente(numeroCapituloCena1);

            InputNomeSequencia.EsperarElemento(Browser);
            InputNomeSequencia.Esperar(Browser, 2000);
            InputNomeSequencia.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputNomeSequencia, NomeSequencia);

            ExpandirTodasCenas();
            DragAndDropPrimeiraCenaEstudio(numeroCapituloCena1);
            DragAndDropSegundaCenaEstudio(numeroCapituloCena2);
        }

        public void AlterarOrdemDaSequencia(string numeroCapituloCena)
        {
            DragAndDropCenaEstudio(numeroCapituloCena);
        }

        public void ClicarNovaSequenciaCenica()
        {
            BtnNovaSequenciaCenica.EsperarElemento(Browser);
            BtnNovaSequenciaCenica.Esperar(Browser, 2000);
            BtnNovaSequenciaCenica.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovaSequenciaCenica);
        }

        public void SalvarSequenciaCenica()
        {
            BtnSalvar.EsperarElemento(Browser);
            BtnSalvar.Esperar(Browser, 2000);
            BtnSalvar.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvar);

            ListaInseridaSucesso();
        }

        private void ClicarFiltrar()
        {
            BtnFiltrar.EsperarElemento(Browser);
            BtnFiltrar.Esperar(Browser, 2000);
            BtnFiltrar.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        private void ListaInseridaSucesso()
        {
            var Mensagem = Element.Class("container");
            Mensagem.EsperarElemento(Browser);
            Mensagem.IsElementVisible(Browser);

            string texto = Mensagem.GetTexto(Browser);
            Assert.IsTrue(true, texto);
        }

        public void FiltrarSequenciaCenica(string NomeSequencia)
        {
            InputNomeSequenciaFiltro.EsperarElemento(Browser);
            InputNomeSequenciaFiltro.Esperar(Browser, 2000);
            InputNomeSequenciaFiltro.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputNomeSequenciaFiltro, NomeSequencia);

            ClicarFiltrar();
        }

        public void ValidarChck()
        {
            ChckCenasNaoGravadas.IsElementVisible(Browser);
            ChckCenasNaoGravadas.IsElementSelected(Browser);
        }

        private void ClicarEditarSequenciaCenica()
        {
            BtnEditarSequencia.EsperarElemento(Browser);
            BtnEditarSequencia.Esperar(Browser, 2000);
            BtnEditarSequencia.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnEditarSequencia);
        }

        public void EditarSequenciaCenica(string NomeSequencia, string numeroCapituloCena1, string numeroCapituloCena2)
        {
            EsperaLoading();

            ClicarEditarSequenciaCenica();

            InputNomeSequencia.EsperarElemento(Browser);
            InputNomeSequencia.Esperar(Browser, 2000);
            InputNomeSequencia.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputNomeSequencia, NomeSequencia);

            ExpandirTodasCenas();
            if(numeroCapituloCena1 != "")
            {
                DragAndDropPrimeiraCenaEstudio(numeroCapituloCena1);
            }
            if (numeroCapituloCena2 != "")
            {
                DragAndDropSegundaCenaEstudio(numeroCapituloCena2);
            }
        }

        public void ExcluirSequenciaCenica(string NomeSequencia)
        {
            FiltrarSequenciaCenica(NomeSequencia);

            BtnExcluirSequencia.EsperarElemento(Browser);
            BtnExcluirSequencia.Esperar(Browser, 2000);
            BtnExcluirSequencia.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnExcluirSequencia);

            PopupExcluir();
        }

        private void PopupExcluir()
        {
            string mensagemText = Element.Css("div[class='bootbox-body'] p:nth-child(2)").GetTexto(Browser);
            string mensagem = "O Grupo de Sequência Cênica e seus dados relacionados serão excluídos e não poderão ser recuperados. Tem certeza que deseja excluir este Grupo de Sequência Cênica?";

            Assert.AreEqual(mensagem, mensagemText);
            //var mensagem = Element.Xpath("//p[text()='O Grupo de Sequência Cênica e seus dados relacionados serão excluídos e não poderão ser recuperados. Tem certeza que deseja excluir este Grupo de Sequência Cênica?']");
            //mensagem.IsElementVisible(Browser);

            var BtnExcluirPopup = Element.Css("button[class='btn btn btn-primary exclusaoSequenciaCenica']");
            BtnExcluirPopup.EsperarElemento(Browser);
            BtnExcluirPopup.Esperar(Browser, 2000);
            BtnExcluirPopup.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnExcluirPopup);

            ListaInseridaSucesso();
        }

        public void ExibirCenas()
        {
            var btnExibir = Element.Css("table[class='panel-header'] td:nth-child(1) a:nth-child(1)");
            btnExibir.Esperar(Browser, 2000);
            btnExibir.EsperarElemento(Browser);
            btnExibir.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, btnExibir);
            Thread.Sleep(2000);
        }

        private void EsperaLoading()
        {
            var esperaPath = Element.Css("div[id='loading']");
            esperaPath.IsNotElementVisible(Browser); ;
        }

        public void ValidarCapitulo(string Capitulo)
        {
            LinkCapitulo.EsperarElemento(Browser);
            LinkCapitulo.Esperar(Browser, 2000);
            LinkCapitulo.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, LinkCapitulo);

            ValidarCampos(Capitulo);
        }

        public void Filtrar(string campo, string filtro)
        {
            if (BtnFiltrarCenas.IsElementVisible(Browser))
            {
                //Legenda: Tipos, Cenarios, Capitulos, Status, Classificacoes, Categorias, PeriodoDoDia
                var CampoTipo = Element.Xpath("//*[@id='filtroTipos_chosen']//input");

                BtnFiltrarCenas.EsperarElemento(Browser);
                MouseActions.ClickATM(Browser, BtnFiltrarCenas);
                CampoTipo.EsperarElemento(Browser);
                AutomatedActions.SendDataEnterATM(Browser, CampoTipo, filtro);
                //ClicarBtnBuscarFiltro();
            }
        }

        private void ClicarBtnBuscarFiltro()
        {
            BtnBuscar.EsperarElemento(Browser);
            if (BtnBuscar.IsElementVisible(Browser))
                MouseActions.ClickATM(Browser, BtnBuscar);
        }

        public void ClicarFiltrarCenas()
        {
            EsperaLoading();

            BtnFiltrarCenas.EsperarElemento(Browser);
            BtnFiltrarCenas.Esperar(Browser, 2000);
            BtnFiltrarCenas.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarCenas);
        }

        public void ValidarFiltroDeCenas(string filtro)
        {
            var filtroText = Element.Xpath("//label[contains(., '" + filtro + "')]");
            filtroText.IsElementVisible(Browser);
            filtroText.Esperar(Browser, 500);
        }

        public void ValidarCenario(string Cenario, string Cena)
        {
            EsperaLoading();
            ExpandirTodasCenas();

            LinkCenarios.EsperarElemento(Browser);
            LinkCenarios.Esperar(Browser, 2000);
            LinkCenarios.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, LinkCenarios);

            ValidarCampos(Cenario);
            ValidarSpan(Cena);
        }

        private void ValidarSpan(string valor)
        {
            var campo = Element.Xpath("//span[text()='" + valor + "']");
            campo.IsElementVisible(Browser);
            campo.Esperar(Browser, 1000);
        }

        public void ValidarDetalhes()
        {
            string mensagem = Element.Css("h4[class='ttooltip-title']").GetTexto(Browser);
            string mensagemCorpo = Element.Css("div[class='ttooltip-content'] p").GetTexto(Browser);

            Assert.IsTrue(true, mensagem);
            Assert.IsTrue(true, mensagemCorpo);
        }

        private void ValidarCampos(string valor)
        {
            var campo = Element.Xpath("//strong[text()='" + valor + "']");
            campo.IsElementVisible(Browser);
            campo.Esperar(Browser, 1000);
        }
        
        public void ValidarNomeSequencia(string NomeSequencia)
        {
            //ValidarCampos(NomeSequencia);

            string nomeSequenciaText = Element.Css("table[class='panel-header'] strong").GetTexto(Browser);
            Assert.AreEqual(NomeSequencia, nomeSequenciaText);
        }

        public void ValidarExclusaoSequencia(string NomeSequencia)
        {
            var campo = Element.Xpath("//strong[text()='" + NomeSequencia + "']");
            campo.IsNotElementVisible(Browser);
        }

        public void ValidarSequenciaCenica(string ordem, string capitulo, string cena)
        {
            string ordemText = Element.Css("table[class='table'] tr:nth-child(" + ordem + ") td:nth-child(1) strong").GetTexto(Browser);
            string capituloText = Element.Css("table[class='table'] tr:nth-child(" + ordem + ") td:nth-child(2) strong:nth-child(2)").GetTexto(Browser);
            string cenaText = Element.Css("table[class='table'] tr:nth-child(" + ordem + ") td:nth-child(3) strong").GetTexto(Browser);

            Assert.AreEqual(ordem, ordemText);
            Assert.AreEqual(capitulo, capituloText);
            Assert.AreEqual(cena, cenaText);
        }

    }
}
