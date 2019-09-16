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
    public class RelatoriosDeIndicadoresDeCenasPage : PageBase
    {
        //Abas do Relatorio dos Indicadores de Cenas
        private Element AbaCenasRoteirizadas { get; }
        public Element AbaFrenteDeGravacao { get; }
        public Element AbaQuebraSequenciaCenica { get; }
        private Element AbaCenasRoteirizadasPorArtista { get; }
        private Element AbaTrocaAmbienteIluminacao { get; }
        private Element AbaLocacoesExternas { get; }
        private Element AbaIndiUltimasSolucoes { get; }
        private Element AbaNumRoteiros { get; }
        private Element AbaCapFechadosEquivalentes { get; }
        private Element AbaElenco { get; }
        private Element AbaMontagem { get; }
        private Element ProximaAba { get; }

        //ACenas Roteirizadas
        private Element SlctDataCenasRoteirizadas { get; }
        private Element SlctRoteiroCenasRoteirizadas { get; }
        private Element SlctCapitulo { get; }
        private Element SlctFrenteCenasRoteirizadas { get; }
        private static Element CenasRoteirizadasText { get; set; }
        private void CenasRoteirizadas(string horizonte, string valor)
        {
            CenasRoteirizadasText = Element.Xpath("//td[text()='" + horizonte + "']/../td[text()='" + valor + "']");
        }
        private Element BtnFiltrarCenasRoteirizadas { get; }
        private Element BtnLimparFiltrosCenasRoteirizadas { get; }

        //Frente de Gravação
        private Element SlctFrenteFrenteGravacao { get; }
        private Element SlcTipoFrenteFrenteGravacao { get; }
        private Element SlctDiasFrenteGravacao { get; }
        private Element BtnFiltrarFrenteGravacao { get; }
        private static Element FrenteGravacaoText { get; set; }
        private void FrenteGravacao(string informacoes, string valores)
        {
            FrenteGravacaoText = Element.Xpath("//td[text()='" + informacoes + "']/../td[text()='" + valores + "']");
        }

        //Quebra de Sequência Cênica
        private Element InpNumQuebras { get; }

        //Cenas Roteirizadas por Artista
        private Element SlctArtistaCenasRoteirizadasArtista { get; }
        private Element SlctFrenteCenasRoteirizadasArtista { get; }
        private Element BtnFiltrarCenasRoteirizadasArtista { get; }

        //Troca de Ambiente e Iluminação
        private Element SlctRoterioTrocaAmbienteIluminacao { get; }
        private Element SlctDataTrocaAmbienteIluminacao { get; }
        private Element SlctFrenteTrocaAmbienteIluminacao { get; }
        private Element SlctTipoLocalTrocaAmbienteIluminacao { get; }
        private Element BtnFiltrarTrocaAmbienteIluminacao { get; }
        private static Element TrocaAmbienteIluminacaoText { get; set; }
        private void TrocaAmbienteIluminacao(string informacoes, string valores)
        {
            TrocaAmbienteIluminacaoText = Element.Xpath("//td[text()='" + informacoes + "']/../td[text()='" + valores + "']");
        }

        //Locações Externas
        private Element SlctDataLocacoesExternas { get; }
        private Element SlctTipoLocalLocacoesExternas { get; }
        public Element InpNumLocais { get; private set; }
        private Element BtnFiltrarLocacoesExternas { get; }

        //Nº de Roteiros
        public Element SlctDataNumRoteiros { get; private set; }
        public Element SlctTipoLocalNumRoteiros { get; private set; }
        public Element InpNumRoteiros { get; private set; }
        public Element BtnFiltrarNumRoteiros { get; private set; }

        //Capitulos Fechados e Equivalentes
        private Element SlctDataCapFechadosEqui { get; }
        private Element BtnFiltrarCapFechadosEqui { get; }

        //Elenco
        private Element SlctArtistaElenco { get; }
        private Element SlctSenioridadeElenco { get; }
        private Element SlctDataElenco { get; }
        private Element BtnFiltrarElenco { get; }

        //Montagem
        private Element SlctDataMontagem { get; }
        private Element SlcCenarioMontagem { get; }
        private Element SlctAmbienteMontagem { get; }
        private Element SlctFrenteMontagem { get; }
        private Element BtnFiltrarMontagem { get; }

        //Validações
        private static Element ValidarTabelaText { get; set; }
        private void ValidarTabela(string informacoes, string valores)
        {
            ValidarTabelaText = Element.Xpath("//td[text()='" + informacoes + "']/../td[text()='" + valores + "']");
        }


        public RelatoriosDeIndicadoresDeCenasPage(IBrowser browser) : base(browser)
        {
            //Abas do Relatorio dos Indicadores de Cenas
            AbaCenasRoteirizadas = Element.Xpath("//a[text()='Cenas Roteirizadas']");
            AbaFrenteDeGravacao = Element.Xpath("//a[text()='Frente de Gravação']");
            AbaQuebraSequenciaCenica = Element.Xpath("//a[text()='Quebra de Sequência Cênica']");
            AbaCenasRoteirizadasPorArtista = Element.Xpath("//a[text()='Cenas Roteirizadas por Artista']");
            AbaTrocaAmbienteIluminacao = Element.Xpath("//a[text()='Troca de Ambiente e Iluminação']");
            AbaLocacoesExternas = Element.Xpath("//a[text()='Locações Externas']");
            AbaIndiUltimasSolucoes = Element.Xpath("//a[text()='Indicadores das Últimas Soluções']");
            AbaNumRoteiros = Element.Xpath("//a[text()='Nº de Roteiros']");
            AbaCapFechadosEquivalentes = Element.Xpath("//a[text()='Capítulos Fechados e Equivalentes']");
            AbaElenco = Element.Xpath("//a[text()='Elenco']");
            AbaMontagem = Element.Xpath("//a[text()='Montagem']");
            ProximaAba = Element.Css("div[id='NextAba']");

            //Cenas Roteirizadas
            SlctDataCenasRoteirizadas = Element.Css("select[id='dataCenasRoteirizadas']");
            SlctRoteiroCenasRoteirizadas = Element.Css("select[id='CenaRoterizacaoRoteiro']");
            SlctCapitulo = Element.Css("select[id='CenaRoterizacaoCapitulo']");
            SlctFrenteCenasRoteirizadas = Element.Css("select[id='CenaRoterizacaoFrente']");
            BtnFiltrarCenasRoteirizadas = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaCenaRoterizacao.filtrar']");
            BtnLimparFiltrosCenasRoteirizadas = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaCenaRoterizacao.limparFiltro']");

            //Frente de Gravação
            SlctFrenteFrenteGravacao = Element.Css("select[id='frenteFrenteGravacao']");
            SlcTipoFrenteFrenteGravacao = Element.Css("select[id='tipoFrenteFrenteGravacao']");
            SlctDiasFrenteGravacao = Element.Css("select[id='diasFrenteGravacao']");
            BtnFiltrarFrenteGravacao = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaFrenteGravacao.filtrar']");

            //Quebra de Sequência Cênica
            InpNumQuebras = Element.Css("input[id='numeroQuebras']");

            //Cenas Roteirizadas por Artista
            SlctArtistaCenasRoteirizadasArtista = Element.Css("select[id='CenasPorArtistaCapitulo']");
            SlctFrenteCenasRoteirizadasArtista = Element.Css("select[id='CenasPorArtistaFrente']");
            InpNumLocais = Element.Css("input[data-bind='textInput: sppRelatorioIndicadoresCena.indicadoresCenaRetr().TotalLocais']");
            BtnFiltrarCenasRoteirizadasArtista = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaCenasPorArtista.filtrar']");

            //Troca de Ambiente e Iluminação
            SlctRoterioTrocaAmbienteIluminacao = Element.Css("select[id='TrocaAmbienteIluminacaoRoteiro']");
            SlctDataTrocaAmbienteIluminacao = Element.Css("select[id='dataTrocaAmbienteIluminacao']");
            SlctFrenteTrocaAmbienteIluminacao = Element.Css("select[id='TrocaAmbienteIluminacaoFrente']");
            SlctTipoLocalTrocaAmbienteIluminacao = Element.Css("select[id='TrocaAmbienteIluminacaoLocal']");
            BtnFiltrarTrocaAmbienteIluminacao = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaTrocaAmbienteIluminacao.filtrar']");

            //Locações Externas
            SlctDataLocacoesExternas = Element.Css("select[id='dataLocacoesExternas']");
            SlctTipoLocalLocacoesExternas = Element.Css("select[id='LocacoesExternasTipoLocal']");
            BtnFiltrarLocacoesExternas = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaLocacoesExternas.filtrar']");

            //Nº de Roteiros
            SlctDataNumRoteiros = Element.Css("select[id='dataNumerosRoteiros']");
            SlctTipoLocalNumRoteiros = Element.Css("select[id='NumerosRoteirosTipoLocal']");
            InpNumRoteiros = Element.Css("input[id='numeroRoteiros']");
            BtnFiltrarNumRoteiros = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaNumerosRoteiros.filtrar']");

            //Capitulos Fechados e Equivalentes
            SlctDataCapFechadosEqui = Element.Css("select[id='dataCapitulosFechadosEqui']");
            BtnFiltrarCapFechadosEqui = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaCapitulosFechadosEqui.filtrar']");

            //Elenco
            SlctArtistaElenco = Element.Css("select[id='elencoArtor']");
            SlctSenioridadeElenco = Element.Css("select[id='senioridade']");
            SlctDataElenco = Element.Css("select[id='dataElenco']");
            BtnFiltrarElenco = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaElenco.filtrar']");

            //Montagem
            SlctDataMontagem = Element.Css("select[id='dataMontagem']");
            SlcCenarioMontagem = Element.Css("select[id='MontagemCenario']");
            SlctAmbienteMontagem = Element.Css("select[id='MontagemAmbientes']");
            SlctFrenteMontagem = Element.Css("select[id='MontagemLocalGravacao']");
            BtnFiltrarMontagem = Element.Css("button[data-bind='click: sppRelatorioIndicadoresCena.telaMontagem.filtrar']");
        }

        public override void Navegar()
        {
            throw new NotImplementedException();
        }

        public void LimparFiltrosCenasRoteirizadas()
        {
            BtnLimparFiltrosCenasRoteirizadas.Esperar(Browser, 2000);
            BtnLimparFiltrosCenasRoteirizadas.IsClickable(Browser);
            BtnLimparFiltrosCenasRoteirizadas.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnLimparFiltrosCenasRoteirizadas);
        }

        private void ClicarProximaAba(int num)
        {
            int i = 0;
            while (i < num)
            {
                ProximaAba.Esperar(Browser, 1000);
                ProximaAba.EsperarElemento(Browser);
                ProximaAba.IsClickable(Browser);
                MouseActions.ClickATM(Browser, ProximaAba);
                i++;
            }
        }

        private void AcessarAba(string Aba)
        {
            Thread.Sleep(2000);
            switch(Aba)
            {
                case "Cenas Roteirizadas por Artista":
                    {
                        int num = 3;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Troca de Ambiente e Iluminação":
                    {
                        int num = 4;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Locações Externas":
                    {
                        int num = 5;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Indicadores das Últimas Soluções":
                    {
                        int num = 6;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Nº de Roteiros":
                    {
                        int num = 7;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Capítulos Fechados e Equivalentes":
                    {
                        int num = 8;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Elenco":
                    {
                        int num = 9;
                        ClicarProximaAba(num);
                        break;
                    }
                case "Montagem":
                    {
                        int num = 10;
                        ClicarProximaAba(num);
                        break;
                    }
            }
        }

        public void AcessarQuebraDeSequenciaCenica()
        {
            AbaQuebraSequenciaCenica.Esperar(Browser, 1000);
            AbaQuebraSequenciaCenica.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaQuebraSequenciaCenica);
        }

        public void AcessarIndicadoresUltimasSolucoes(string Aba)
        {
            AcessarAba(Aba);

            AbaIndiUltimasSolucoes.Esperar(Browser, 1000);
            AbaIndiUltimasSolucoes.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaIndiUltimasSolucoes);
        }

        public void FiltrarAbaCenasRoteirizadas(string Data, string Roteiro, string Capitulo, string Frente)
        {

            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);
            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();

            if (Data != "")
            {
                SlctDataCenasRoteirizadas.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataCenasRoteirizadas, CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Int32.Parse(Data)));
            }
            if(Roteiro != "")
            {
                SlctRoteiroCenasRoteirizadas.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctRoteiroCenasRoteirizadas, NumGROTStr);
            }
            if (Capitulo != "")
            {
                SlctCapitulo.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctCapitulo, Capitulo);
            }
            if (Frente != "")
            {
                SlctFrenteCenasRoteirizadas.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctFrenteCenasRoteirizadas, Frente);
            }
            BtnFiltrarCenasRoteirizadas.Esperar(Browser, 2000);
            BtnFiltrarCenasRoteirizadas.EsperarElemento(Browser);
            BtnFiltrarCenasRoteirizadas.IsClickable(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarCenasRoteirizadas);
        }

        public void FiltrarFrenteGravacao(string Frente, string TipoFrente, string Dias)
        {
            AbaFrenteDeGravacao.Esperar(Browser, 1000);
            AbaFrenteDeGravacao.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaFrenteDeGravacao);

            if (Frente != "")
            {
                SlctFrenteFrenteGravacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctFrenteFrenteGravacao, Frente);
            }
            if (TipoFrente != "")
            {
                SlcTipoFrenteFrenteGravacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlcTipoFrenteFrenteGravacao, TipoFrente);
            }
            if (Dias != "")
            {
                SlctDiasFrenteGravacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDiasFrenteGravacao, CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Int32.Parse(Dias)));
            }
            BtnFiltrarFrenteGravacao.Esperar(Browser, 1000);
            BtnFiltrarFrenteGravacao.IsClickable(Browser);
            BtnFiltrarFrenteGravacao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarFrenteGravacao);
        }

        public void FiltrarCenasRoteirizadasArtista(string Aba, string Artista, string Frente)
        {
            AcessarAba(Aba);

            AbaCenasRoteirizadasPorArtista.Esperar(Browser, 1000);
            AbaCenasRoteirizadasPorArtista.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaCenasRoteirizadasPorArtista);

            if(Artista != "")
            {
                SlctArtistaCenasRoteirizadasArtista.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctArtistaCenasRoteirizadasArtista, Artista);
            }
            if(Frente != "")
            {
                SlctFrenteCenasRoteirizadasArtista.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctFrenteCenasRoteirizadasArtista, Frente);
            }
            BtnFiltrarCenasRoteirizadasArtista.Esperar(Browser, 1000);
            BtnFiltrarCenasRoteirizadasArtista.IsClickable(Browser);
            BtnFiltrarCenasRoteirizadasArtista.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarCenasRoteirizadasArtista);
        }

        public void FiltrarLocacoesExternas(string Aba, string Data, string TipoLocal)
        {
            AcessarAba(Aba);

            AbaLocacoesExternas.Esperar(Browser, 1000);
            AbaLocacoesExternas.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaLocacoesExternas);

            if (Data != "")
            {
                SlctDataLocacoesExternas.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataLocacoesExternas, Data);
            }
            if (TipoLocal != "")
            {
                SlctTipoLocalLocacoesExternas.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctTipoLocalLocacoesExternas, TipoLocal);
            }
            BtnFiltrarLocacoesExternas.Esperar(Browser, 1000);
            BtnFiltrarLocacoesExternas.IsClickable(Browser);
            BtnFiltrarLocacoesExternas.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarLocacoesExternas);
        }

        public void FiltrarNumRoteiros(string Aba, string Data, string TipoLocal)
        {
            AcessarAba(Aba);

            AbaNumRoteiros.Esperar(Browser, 1000);
            AbaNumRoteiros.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaNumRoteiros);

            if (Data != "")
            {
                SlctDataNumRoteiros.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataNumRoteiros, Data);
            }
            if (TipoLocal != "")
            {
                SlctTipoLocalNumRoteiros.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctTipoLocalNumRoteiros, TipoLocal);
            }
            BtnFiltrarNumRoteiros.Esperar(Browser, 1000);
            BtnFiltrarNumRoteiros.IsClickable(Browser);
            BtnFiltrarNumRoteiros.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarNumRoteiros);
        }

        public void FiltroTrocaAmbienteIluminacao(string Aba, string Roteiro, string Data, string Frente, string TipoLocal)
        {
            AcessarAba(Aba);

            var NumGROT = Element.Css("div[class='rnumber rnumberGROT']");
            NumGROT.EsperarElemento(Browser);
            NumGROT.Esperar(Browser, 1000);
            string NumGROTStr = NumGROT.GetTexto(Browser).ToString();

            AbaTrocaAmbienteIluminacao.Esperar(Browser, 1000);
            AbaTrocaAmbienteIluminacao.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaTrocaAmbienteIluminacao);

            if(Roteiro != "")
            {
                SlctRoterioTrocaAmbienteIluminacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctRoterioTrocaAmbienteIluminacao, NumGROTStr);
            }
            if (Data != "")
            {
                SlctDataTrocaAmbienteIluminacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataTrocaAmbienteIluminacao, CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Int32.Parse(Data)));
            }
            if (Frente != "")
            {
                SlctFrenteTrocaAmbienteIluminacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctFrenteTrocaAmbienteIluminacao, Frente);
            }
            if (TipoLocal != "")
            {
                SlctTipoLocalTrocaAmbienteIluminacao.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctTipoLocalTrocaAmbienteIluminacao, TipoLocal);
            }
            BtnFiltrarTrocaAmbienteIluminacao.Esperar(Browser, 1000);
            BtnFiltrarTrocaAmbienteIluminacao.IsClickable(Browser);
            BtnFiltrarTrocaAmbienteIluminacao.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarTrocaAmbienteIluminacao);
        }

        public void FiltrarElenco(string Aba, string Artista, string Senioridade, string Data)
        {
            AcessarAba(Aba);

            AbaElenco.Esperar(Browser, 1000);
            AbaElenco.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaElenco);

            if(Artista != "")
            {
                SlctArtistaElenco.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctArtistaElenco, Artista);
            }
            if(Senioridade != "")
            {
                SlctSenioridadeElenco.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctSenioridadeElenco, Senioridade);
            }
            if(Data != "")
            {
                SlctDataElenco.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataElenco, CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Int32.Parse(Data)));
            }
            BtnFiltrarElenco.Esperar(Browser, 1000);
            BtnFiltrarElenco.IsClickable(Browser);
            BtnFiltrarElenco.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarElenco);
        }

        public void FiltrarMontagem(string Aba, string Data, string Cenario, string Ambiente, string Frente)
        {
            AcessarAba(Aba);

            AbaMontagem.Esperar(Browser, 1000);
            AbaMontagem.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaMontagem);

            if (Data != "")
            {
                SlctDataMontagem.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataMontagem, CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Int32.Parse(Data)));
            }
            if (Cenario != "")
            {
                SlcCenarioMontagem.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlcCenarioMontagem, Cenario);
            }
            if (Ambiente != "")
            {
                SlctAmbienteMontagem.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctAmbienteMontagem, Ambiente);
            }
            if(Frente != "")
            {
                SlctFrenteMontagem.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctFrenteMontagem, Frente);
            }

            BtnFiltrarMontagem.Esperar(Browser, 1000);
            BtnFiltrarMontagem.IsClickable(Browser);
            BtnFiltrarMontagem.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarMontagem);
        }

        public void FiltrarCapitulosFechadosEquivalentes(string Aba, string Data)
        {
            AcessarAba(Aba);

            AbaCapFechadosEquivalentes.Esperar(Browser, 1000);
            AbaCapFechadosEquivalentes.IsClickable(Browser);
            MouseActions.ClickATM(Browser, AbaCapFechadosEquivalentes);

            if(Data != "")
            {
                SlctDataCapFechadosEqui.EsperarElemento(Browser);
                MouseActions.SelectElementATM(Browser, SlctDataCapFechadosEqui, CalendarioHelper.ObterDiaMesAnoFuturoComBarra(Int32.Parse(Data)));
            }

            BtnFiltrarCapFechadosEqui.Esperar(Browser, 1000);
            BtnFiltrarCapFechadosEqui.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnFiltrarCapFechadosEqui);
        }

        public void ValidarIndicadoresUltimasSolucoes(string Indicador, string Solucao, string SolucaoAnterior, string Referencia)
        {
            if(Solucao != "")
            {
                ValidarRelatorio(Indicador, Solucao);
            }
            if(SolucaoAnterior != "")
            {
                ValidarRelatorio(Indicador, SolucaoAnterior);
            }
            if(Referencia != "")
            {
                ValidarRelatorio(Indicador, Referencia);
            }
        }

        public void ValidarRelatorio(string Informacoes, string Valores)
        {
            ValidarTabela(Informacoes, Valores);
            ValidarTabelaText.IsElementVisible(Browser);
        }
        
        public void ValidarAbaCenasRoteirizadas(string Horizonte, string Cenas, string Paginas)
        {
            CenasRoteirizadas(Horizonte, Cenas);
            CenasRoteirizadasText.IsElementVisible(Browser);
            CenasRoteirizadas(Horizonte, Paginas);
            CenasRoteirizadasText.IsElementVisible(Browser);
            CenasRoteirizadasText.Esperar(Browser, 1000);
        }

        public void ValidarQuebraSequenciaCenica(string NumQuebras)
        {
            InpNumQuebras.IsElementVisible(Browser);
        }

        public void ValidarLocacoesExternas(string NumLocais)
        {
            var labelPath = Element.Xpath("//label[text()='Nº de Locais']");
            labelPath.IsElementVisible(Browser);

            InpNumLocais.IsElementVisible(Browser);
        }

        public void ValidarNumRoteiros(string NumRoteiros)
        {
            var labelPath = Element.Xpath("//label[text()='Nº de Roteiros']");
            labelPath.IsElementVisible(Browser);

            InpNumRoteiros.IsElementVisible(Browser);
        }
    }
}
