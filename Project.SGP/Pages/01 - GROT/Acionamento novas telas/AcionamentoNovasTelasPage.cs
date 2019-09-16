using Framework.Core.PageObjects;
using System;
using Framework.Core.Interfaces;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Actions;
using System.Threading;

namespace Project.SGP.Pages
{
    public class AcionamentoNovasTelasPage : PageBase
    {
        //Indisponibilidade Elenco
        private Element InpAtorFiltro { get; }
        private Element InpDataIndisponibilidadeElencoFiltro { get; }
        private Element BtnNovaIndisponibilidadeElenco { get; }

        //Local de Gravação
        private Element BtnNovoLocalGravacao { get; }
        public Element InpNomeLocalFiltro { get; }
        public Element InpRegiaoLocalFiltro { get; }
        public Element SlctTipoLocalFiltro { get; }

        //Indisponibilidade de Local
        private Element BtnNovaIndisponibilidadeLocal { get; }
        public Element InpEnderecoLocalIndisponibilidade { get; }
        public Element InpDataLocalIndisponibilidadeFiltro { get; }

        //Cenarios Incompativeis
        private Element BtnNovaListaCenariosIncompativeis { get; }
        public Element LabelCenarioIncompativel { get; }
        public Element LabelAmbienteCenarioIncompativel { get; }

        //Sequencia Cenica
        private Element BtnNovaSequenciaCenica { get; }
        public Element InpNomeSequenciaCenica { get; }
        public Element ChckCenasNaoGravadas { get; }

        //Grupo Local de Gravação(Região)
        private Element BtnCriarNovoGrupoLocalGravacao { get; }
        public Element BtnDetalharGrupoLocalGravacao { get; }
        public Element LabelRegiaoA { get; }
        public Element LabelRegiaoB { get; }
        public Element LabelRegiao { get; }

        //Parâmetros de Produção

        //Gestão de Alertas

        //Menu de Planejamento
        private Element BtnPlanejamento { get; }
        private Element LinkIndisponibilidadeElenco { get; }
        private Element BtnDefinicoesDaProducao { get; }
        private Element LinkLocalDeGravacao { get; }
        public Element LinkIndisponibilidadeLocal { get; }
        public Element LinkSequenciaCenica { get; }
        public Element LinkCenariosIncompativeis { get; }
        public Element LinkGrupoLocalGravacao { get; }
        public Element LinkParametrosDeProducao { get; }
        public Element LinkGestaoDeAlertas { get; }
        public Element LinkRelatorioIndicadoresCenas { get; }
        private Element BtnFecharAba { get; }

        public AcionamentoNovasTelasPage(IBrowser browser) : base(browser)
        {
            //Indisponibilidade Elenco
            InpAtorFiltro = Element.Css("input[id='AtorPupup']");
            InpDataIndisponibilidadeElencoFiltro = Element.Css("input[id='DataInicioFiltro']");
            BtnNovaIndisponibilidadeElenco = Element.Css("button[id='NovoIndisponibilidadeElenco']");

            //Local de Gravação
            BtnNovoLocalGravacao = Element.Css("button[id='NovoLocalGravacao']");
            InpNomeLocalFiltro = Element.Css("input[id='Enderecofiltro']");
            InpRegiaoLocalFiltro = Element.Css("input[id='Localfiltro']");
            SlctTipoLocalFiltro = Element.Css("div[id='Tipofiltro_chosen'] a");

            //Indisponibilidade de Local
            BtnNovaIndisponibilidadeLocal = Element.Css("button[id='NovoIndisponibilidadeLocais']");
            InpEnderecoLocalIndisponibilidade = Element.Css("input[id='Endereco']");
            InpDataLocalIndisponibilidadeFiltro = Element.Css("input[id='DataIniciofiltro']");

            //Sequencia Cenica
            BtnNovaSequenciaCenica = Element.Css("button[id='NovoSequenciaCenica']");
            InpNomeSequenciaCenica = Element.Css("input[id='NomeSequencia']");
            ChckCenasNaoGravadas = Element.Css("input[id='chkSomenteCenaNaoGravadas']");

            //Cenarios Incompativeis
            BtnNovaListaCenariosIncompativeis = Element.Css("button[id='NovaListaIncompatibilidade']");
            LabelCenarioIncompativel = Element.Css("label[for='Cenariofiltro']");
            LabelAmbienteCenarioIncompativel = Element.Css("label[for='AmbienteFiltro']");

            //Grupo Local de Gravação(Região)
            BtnCriarNovoGrupoLocalGravacao = Element.Css("button[id='Criarbtn']");
            BtnDetalharGrupoLocalGravacao = Element.Css("button[id='Detalharbtn']");
            LabelRegiaoA = Element.Css("label[for='LocalA']");
            LabelRegiaoB = Element.Css("label[for='LocalB']");
            LabelRegiao = Element.Css("label[for='Nome']");

            //Parâmetros de Produção

            //Gestão de Alertas

            //Menu de Planejamento
            BtnPlanejamento = Element.Css("img[id='botRoteiroMenu']");
            BtnDefinicoesDaProducao = Element.Css("li[id='testGrupoApps']");
            LinkIndisponibilidadeElenco = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/IndisponibilidadeElenco']");
            LinkLocalDeGravacao = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/LocalGravacao']");
            LinkIndisponibilidadeLocal = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/IndisponibilidadeLocais']");
            LinkSequenciaCenica = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/SequenciaCenica']");
            LinkCenariosIncompativeis = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/ListaIncompatibilidade']");
            LinkGrupoLocalGravacao = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/GrupoLocalGravacao']");
            LinkParametrosDeProducao = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/Relatorio/Index?relatorio=ParametrosProducao']");
            LinkGestaoDeAlertas = Element.Css("li[id='testGrupoApps'] ul li[iframelink='/SGP/GestaoAlerta']");
            LinkRelatorioIndicadoresCenas = Element.Css("li[id='testGrupoApps'] ul li[id='tstRelIndicadoresCenas']");
            BtnFecharAba = Element.Css("button[id='buttomModalIframe']");

        }

        public override void Navegar()
        {
            throw new NotImplementedException();
        }

        public void FecharTela()
        {
            BtnFecharAba.EsperarElemento(Browser);
            Thread.Sleep(2000);
            MouseActions.ClickATM(Browser, BtnFecharAba);
        }

        private void ClicarPlanejamento()
        {
            BtnPlanejamento.Esperar(Browser, 2000);
            BtnPlanejamento.EsperarElemento(Browser);
            BtnPlanejamento.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnPlanejamento);
        }

        private void ClicarDefinicoesDaProducao()
        {
            BtnDefinicoesDaProducao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnDefinicoesDaProducao);
        }

        public void AcessarTelaIndisponibilidadeElenco()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkIndisponibilidadeElenco.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkIndisponibilidadeElenco);
        }

        public void AcessarTelaLocalGravacao()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkLocalDeGravacao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkLocalDeGravacao);
        }

        public void AcessarTelaIndisponibilidadeLocal()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkIndisponibilidadeLocal.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkIndisponibilidadeLocal);
        }

        public void AcessarTelaSequenciaCenica()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkSequenciaCenica.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkSequenciaCenica);
        }

        public void AcessarTelaCenarioIncompativel()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkCenariosIncompativeis.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkCenariosIncompativeis);
        }

        public void AcessarTelaGrupoLocalGravacao()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkGrupoLocalGravacao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkGrupoLocalGravacao);
        }

        public void AcessarTelaParametrosDeProducao()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkParametrosDeProducao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkParametrosDeProducao);
        }

        public void AcessarTelaGestaoDeAlertas()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkGestaoDeAlertas.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkGestaoDeAlertas);
        }

        public void AcessarRelatorioIndicadoresCenas()
        {
            ClicarPlanejamento();
            ClicarDefinicoesDaProducao();
            LinkRelatorioIndicadoresCenas.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, LinkRelatorioIndicadoresCenas);
        }

        public void ValidarTelaGestaoDeAlertas()
        {
            var IFrameIndicadores = Element.Id("Iframe");
            var H3Alertas = Element.Xpath("//h3[text()='Alertas']");
            var ThCena = Element.Xpath("//th[text()='CENA']");
            var ThDia = Element.Xpath("//th[text()='DIA']");
            var ThRoteiro = Element.Xpath("//th[text()='ROTEIRO']");
            var ThSemana = Element.Xpath("//th[text()='SEMANA']");

            IFrameIndicadores.EsperarIFrame(Browser);

            H3Alertas.IsElementVisible(Browser);
            ThCena.IsElementVisible(Browser);
            ThDia.IsElementVisible(Browser);
            ThRoteiro.IsElementVisible(Browser);
            ThSemana.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaParametrosDeProducao()
        {
            var IFrameIndicadores = Element.Id("Iframe");
            var H3Parametros = Element.Xpath("//h3[text()='Parâmetros Gerais']");

            IFrameIndicadores.EsperarIFrame(Browser);

            H3Parametros.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaGrupoLocalGravacao()
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            BtnCriarNovoGrupoLocalGravacao.IsElementVisible(Browser);
            BtnDetalharGrupoLocalGravacao.IsElementVisible(Browser);
            LabelRegiaoA.IsElementVisible(Browser);
            LabelRegiaoB.IsElementVisible(Browser);
            LabelRegiao.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaCenarioIncompativel()
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            BtnNovaListaCenariosIncompativeis.IsElementVisible(Browser);
            LabelCenarioIncompativel.IsElementVisible(Browser);
            LabelAmbienteCenarioIncompativel.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaSequenciaCenica()
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            BtnNovaSequenciaCenica.IsElementVisible(Browser);
            InpNomeSequenciaCenica.IsElementVisible(Browser);
            ChckCenasNaoGravadas.IsElementVisible(Browser);
            

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaIndisponibilidadeLocal()
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            BtnNovaIndisponibilidadeLocal.IsElementVisible(Browser);
            InpEnderecoLocalIndisponibilidade.IsElementVisible(Browser);
            InpDataLocalIndisponibilidadeFiltro.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaLocalGravacao()
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            BtnNovoLocalGravacao.IsElementVisible(Browser);
            InpNomeLocalFiltro.IsElementVisible(Browser);
            InpRegiaoLocalFiltro.IsElementVisible(Browser);
            SlctTipoLocalFiltro.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }

        public void ValidarTelaIndisponibilidadeElenco()
        {
            var IFrameIndicadores = Element.Id("Iframe");

            IFrameIndicadores.EsperarIFrame(Browser);

            InpAtorFiltro.IsElementVisible(Browser);
            InpDataIndisponibilidadeElencoFiltro.IsElementVisible(Browser);
            BtnNovaIndisponibilidadeElenco.IsElementVisible(Browser);

            IFrameIndicadores.SairIFrame(Browser);
        }
    }
}
