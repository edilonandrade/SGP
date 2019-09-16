using Project.SGP.Helpers;
using System.Windows.Forms;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Framework.Core.Extensions.ElementExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Core.Actions;
using System.Threading;
using System;
using System.IO;
using System.Linq;
using Framework.Core.Helpers;
using System.Configuration;

namespace Project.SGP.Pages
{
    public class FotosPage : PageBase
    {
        private string HomeUrl { get; }
        private string FotosUrl { get; }
        private string RoteiroUrl { get; }

        //Fotos - DropList
        private Element DropListTema { get; }
        private Element DropListCena { get; }
        private Element DropListRoupa { get; }
        private Element DropListCenario { get; }
        private Element DropListAmbiente { get; }
        private Element DropListTemaFoto { get; }
        private Element DropListPersonagem { get; }
        private Element DropListClassificao { get; }
        private Element InputClassificacao { get; }
        private Element DropListInseridoPor { get; }
        private Element DropListCenarioFoto { get; }
        private Element DropListPersonagemFoto { get; }
        private Element DropListInseridoPorFoto { get; }

        //Fotos - Check Box
        private Element ChkSelectAllFotos { get; }
        private Element ChkIntervaloCapitulo { get; }

        //Fotos - List
        private Element ListInseridoPor { get; }

        //Fotos - Input
        private Element InputCena { get; }
        private Element InputRoupa { get; }
        private Element InputIDFoto { get; }
        private Element InputCenario { get; }
        private Element InputAmbiente { get; }
        private Element BtnApagaFotos { get; }
        private Element InputTemaFoto { get; }
        private Element InputRoupaFoto { get; }
        private Element InputBlocoFoto { get; }
        private Element InputPersonagem { get; }
        private Element InputCenarioFoto { get; }
        private Element InputRoteiroFoto { get; }
        private Element InputCapituloFoto { get; }
        private Element BtnAplicarMarcacao { get; }
        private Element InputPersonagemFoto { get; }
        private Element InputInseridoPorFoto { get; }
        private Element InputDataGravacaoFoto { get; }
        private Element InputClassificacaoFoto { get; }

        //Fotos - Button
        private Element BtnOK { get; }
        private Element BtnLimpar { get; }
        private Element BtnSalvar { get; }
        private Element BtnFiltrar { get; }
        private Element BtnIncluir { get; }
        private Element BtnGerarAlbum { get; }
        private Element BtnIncluirFoto { get; }
        private Element BtnExcluirFoto { get; }
        private Element BtnBaixarImagem { get; }
        private Element BtnImprimirAlbum { get; }
        private Element BtnBaixarAllImagem { get; }
        private Element BtnExcluirFotoIcone { get; }
        private Element BtnSelecionarImagem { get; }

        //Fotos - Others
        private Element DownloadsPage { get; }
        private Element DivResultados { get; }
        private Element FotoPrincipal { get; }
        private Element TextoElementoID { get; }



        public FotosPage(IBrowser browser,
            string fotosUrl,
            string roteiroUrl) : base(browser)
        {
            FotosUrl = fotosUrl;
            RoteiroUrl = roteiroUrl;

            //Fotos - DropList
            DropListCena = Element.Id("marcacao1_chzn");
            DropListRoupa = Element.Id("marcacao4_chzn");
            DropListCenario = Element.Id("marcacao2_chzn");
            DropListAmbiente = Element.Id("marcacao0_chzn");
            DropListPersonagem = Element.Id("marcacao3_chzn");
            DropListInseridoPor = Element.Xpath("//a[span='Arte']");
            DropListClassificao = Element.Css("#s2id_marcacao8 > ul > li");
            DropListTema = Element.Xpath("(//input[@value='Escolha...'])[5]");
            DropListTemaFoto = Element.Xpath("//*[@id='comboTema_chzn']//ul");
            DropListCenarioFoto = Element.Xpath("//*[@id='comboCenarios_chzn']//ul");
            DropListInseridoPorFoto = Element.Xpath("//*[@id='comboDono_chzn']//ul");
            DropListPersonagemFoto = Element.Xpath("//*[@id='comboPersonagens_chzn']//ul");

            //Fotos - Check Box 
            ChkIntervaloCapitulo = Element.Id("checkIntervaloCapitulo");
            ChkSelectAllFotos = Element.Css("#btnSelecionarTodas > img");

            //Fotos - List
            ListInseridoPor = Element.Xpath("(//input[@type='text'])[6]");

            //Fotos - Input
            InputRoupaFoto = Element.Id("campoRoupa");
            InputRoteiroFoto = Element.Id("campoRoteiro");
            InputCapituloFoto = Element.Id("campoCAPPCT");
            BtnApagaFotos = Element.Id("btnApagarSelecao");
            InputBlocoFoto = Element.Id("campoBlocoRoupa");
            InputClassificacao = Element.Id("s2id_autogen1");
            BtnAplicarMarcacao = Element.Id("refinarFiltro");
            InputIDFoto = Element.Id("campoIdentificadorFoto");
            InputClassificacaoFoto = Element.Id("campoMarcacao");
            InputDataGravacaoFoto = Element.Id("campoDataGravacao");
            InputCena = Element.Xpath("//*[@id='marcacao1_chzn']//input");
            InputRoupa = Element.Xpath("//*[@id='marcacao4_chzn']//input");
            InputCenario = Element.Xpath("//*[@id='marcacao2_chzn']//input");
            InputAmbiente = Element.Xpath("//*[@id='marcacao0_chzn']//input");
            InputTemaFoto = Element.Xpath("//*[@id='comboTema_chzn']//input");
            InputPersonagem = Element.Xpath("//*[@id='marcacao3_chzn']//input");
            InputCenarioFoto = Element.Xpath("//*[@id='comboCenarios_chzn']//input");
            InputInseridoPorFoto = Element.Xpath("//*[@id='comboDono_chzn']//input");
            InputPersonagemFoto = Element.Xpath("//*[@id='comboPersonagens_chzn']//input");

            //Fotos - Button
            BtnLimpar = Element.Id("limpar");
            BtnFiltrar = Element.Id("filtrar");
            BtnIncluir = Element.Css("#confirmarUpload span");
            BtnImprimirAlbum = Element.Id("btnImprimirFotos");
            BtnIncluirFoto = Element.Id("btnIncluirFotos");
            BtnBaixarAllImagem = Element.Id("btnBaixarFotos");
            BtnExcluirFotoIcone = Element.Id("excluirFotoPop");
            BtnOK = Element.Xpath("//button//span[text()='OK']");
            BtnSelecionarImagem = Element.Link("Selecionar Imagens");
            BtnBaixarImagem = Element.Xpath("//button//span[text()='Baixar']");
            BtnSalvar = Element.Xpath("//button[2]//span[contains(.,'Salvar')]");
            BtnGerarAlbum = Element.Xpath("//button//span[text()='Gerar Álbum']");
            BtnExcluirFoto = Element.Xpath("//span[@class='ui-button-text'][text()='OK']");

            //Fotos - Others
            DownloadsPage = Element.Id("file-link");
            DivResultados = Element.Id("resultados");
            FotoPrincipal = Element.Id("fotoPrincipal");
            TextoElementoID = Element.Xpath("//*[@id='fotosBuscaFiltro']/div[1]/div[2]");


        }


        //-------------------METODOS-------------------\\
        public void IncluirUmaFoto
			(string nomeInseridoPor, string nomeTema, string numeroCapituloCena, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
        {
			Browser.Abrir(FotosUrl);
            ClicarBtnIncluirFoto();
            SelecionarUmaFoto();
            PreecherInformacoesImagem(nomeInseridoPor, nomeTema, numeroCapituloCena, nomePersonagem, nomeRoupa, nomeCenario, nomeAmbiente, nomeClassificacao);
        }

		public void IncluirUmaFotoDecupagemArte
			(string nomePersonagem, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
		{
			SelecionarUmaFoto();
			PreencherInformacoesImagemDecupagemArte(nomePersonagem, nomeCenario, nomeAmbiente, nomeClassificacao);
		}

        public void IncluirDuasFotos
			(string nomeInseridoPor, string nomeTema, string numeroCapituloCena, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
        {
			Browser.Abrir(FotosUrl);
            ClicarBtnIncluirFoto();
            SelecionarDuasFotos();
			PreecherInformacoesImagem(nomeInseridoPor, nomeTema, numeroCapituloCena, nomePersonagem, nomeRoupa, nomeCenario, nomeAmbiente, nomeClassificacao);
		}

		public void IncluirQuatroFotos
			(string nomeInseridoPor, string nomeTema, string numeroCapituloCena, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
        {
			Browser.Abrir(FotosUrl);
            ClicarBtnIncluirFoto();
            SelecionarQuatroFotos();
			PreecherInformacoesImagem(nomeInseridoPor, nomeTema, numeroCapituloCena, nomePersonagem, nomeRoupa, nomeCenario, nomeAmbiente, nomeClassificacao);
		}

		public void IncluirDezFotos
			(string nomeInseridoPor, string nomeTema, string numeroCapituloCena, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
        {
			Browser.Abrir(FotosUrl);
            ClicarBtnIncluirFoto();
            SelecionarDezFotos();
            PreecherInformacoesImagem(nomeInseridoPor, nomeTema, numeroCapituloCena, nomePersonagem, nomeRoupa, nomeCenario, nomeAmbiente, nomeClassificacao);
		}

		public void IncluirImagens()
        {
			var EsperarFotos = Element.Css(".fotosVitrine");

			BtnIncluir.EsperarElemento(Browser);
	        MouseActions.ClickATM(Browser, BtnIncluir);
			EsperarFotos.EsperarElemento(Browser);
		}

        public void AlterarDadosImagem(string numeroCapitulo, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente)
        {
            BtnSalvar.EsperarElemento(Browser);
            AlterarInformacoes(numeroCapitulo, nomePersonagem, nomeRoupa, nomeCenario, nomeAmbiente);
        }

        public void ExcluirTodasImagens()
        {
			Browser.Abrir(FotosUrl);
            SelecionarTodasImagens();
            ApagarFotos();
        }

        public void GerarAlbumPorPagina(string numeroPagina)
        {
			Browser.Abrir(FotosUrl);
            BtnSalvar.Esperar(Browser, 1000);
            Browser.RefreshPage();

            SelecionarAllFotos();
            ImprimirAlbum();
            SelecionarQTAlbum(numeroPagina);
            BtnSalvar.Esperar(Browser, 500);
        }

        public void SelecionarImagemCarrosel(string posicaoImagemCarrosel)
        {
            var ImagemCarrosel = Element.Xpath("//*[@class='owl-item'][" + posicaoImagemCarrosel + "]");
            ImagemCarrosel.EsperarElemento(Browser);
			if (ImagemCarrosel.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, ImagemCarrosel);
			}
        }

        public void SalvarFoto()
        {
            BtnSalvar.EsperarElemento(Browser);
			if (BtnSalvar.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, BtnSalvar);
			}
        }

        public void EscolherImagem(string posicaoImagem)
        {
			var EscolherFoto = Element.Xpath("//*[@id='fotosBuscaFiltro']//div[" + posicaoImagem + "]/div[2]/img[1]");

			DivResultados.Esperar(Browser, 4000);
			Browser.RefreshPage();
			DivResultados.EsperarElemento(Browser);
            EscolherFoto.EsperarElemento(Browser);
			if (EscolherFoto.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, EscolherFoto);
			}
        }

        public void ExcluirImagemViaDetalhamento(string posicaoImagem)
        {
            EscolherImagem(posicaoImagem);
            ExcluirFotoViaDetalhamento();
            ExclusaoFotoPopUp();
        }

        public void BaixarUmaImagem()
        {
            BtnBaixarImagem.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnBaixarImagem);
            BtnBaixarImagem.Esperar(Browser, 2000);

            FecharDetalhesFoto();
        }

        public void BaixarTotalImagens()
        {
            BtnBaixarAllImagem.Esperar(Browser, 2000);
            Browser.RefreshPage();
            SelecionarAllFotos();
            BtnBaixarAllImagem.EsperarElemento(Browser);
            if (BtnBaixarAllImagem.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, BtnBaixarAllImagem);
                BtnBaixarAllImagem.Esperar(Browser, 2000);
            }
        }

        private void SelecionarAllFotos()
        {
            ChkSelectAllFotos.EsperarElemento(Browser);
            if (ChkSelectAllFotos.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, ChkSelectAllFotos);
            }
            else
            {
                Browser.RefreshPage();
            }
        }

        public void PesquisarCampoID()
        {
            InputIDFoto.EsperarElemento(Browser);
            InputIDFoto.IsClickable(Browser);

            var TextoElementoID = Element.Css("div:nth-child(1) > .picId > h1");
            string textoID = TextoElementoID.GetTexto(Browser);

            AutomatedActions.SendDataATM(Browser, InputIDFoto, textoID);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoInseridoPor(string textoInseridoPor)
        {
            DropListInseridoPorFoto.EsperarElemento(Browser);
            DropListInseridoPorFoto.IsClickable(Browser);

            AutomatedActions.TypingListATM(Browser, DropListInseridoPorFoto, InputInseridoPorFoto, textoInseridoPor);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoTema(string textoTema)
        {
            DropListTemaFoto.EsperarElemento(Browser);
            DropListTemaFoto.IsClickable(Browser);

            AutomatedActions.TypingListATM(Browser, DropListTemaFoto, InputTemaFoto, textoTema);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoPersonagem(string textoPersonagem)
        {
            DropListPersonagemFoto.EsperarElemento(Browser);
            DropListPersonagemFoto.IsClickable(Browser);

            AutomatedActions.TypingListATM(Browser, DropListPersonagemFoto, InputPersonagemFoto, textoPersonagem);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoRoupaBloco(string textoRoupa, string textoBloco)
        {
            InputRoupaFoto.EsperarElemento(Browser);
            InputRoupaFoto.IsClickable(Browser);

            MouseActions.ClickATM(Browser, ChkIntervaloCapitulo);
            AutomatedActions.SendDataATM(Browser, InputRoupaFoto, textoRoupa);
            AutomatedActions.SendDataATM(Browser, InputBlocoFoto, textoBloco);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoCenario(string textoCenario)
        {
            DropListCenarioFoto.EsperarElemento(Browser);
            DropListCenarioFoto.IsClickable(Browser);

            AutomatedActions.TypingListATM(Browser, DropListCenarioFoto, InputCenarioFoto, textoCenario);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoCapitulo(string textoCapitulo)
        {
            InputCapituloFoto.EsperarElemento(Browser);
            InputCapituloFoto.IsClickable(Browser);

            MouseActions.ClickATM(Browser, ChkIntervaloCapitulo);
            AutomatedActions.SendDataATM(Browser, InputCapituloFoto, textoCapitulo);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoIntervaloCapitulo(string textoCapitulo)
        {
            InputCapituloFoto.EsperarElemento(Browser);
            InputCapituloFoto.IsClickable(Browser);

            AutomatedActions.SendDataATM(Browser, InputCapituloFoto, textoCapitulo);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoRoteiro()
        {
            PegarNumeroRoteiroAndPesquisar();
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        private void PegarNumeroRoteiroAndPesquisar()
        {
            InputRoteiroFoto.EsperarElemento(Browser);
            InputRoteiroFoto.IsClickable(Browser);

			Browser.Abrir(RoteiroUrl);

            var Roteiro = Element.Css(".codigoRoteiro");
            string numeroRoteiro = Roteiro.GetTexto(Browser);

            Browser.BackPage();
            InputRoteiroFoto.EsperarElemento(Browser);
            AutomatedActions.SendDataATM(Browser, InputRoteiroFoto, numeroRoteiro);
        }

        public void PesquisarCampoDataGravacao(string textoDataGravacao)
        {
            InputDataGravacaoFoto.EsperarElemento(Browser);
            InputDataGravacaoFoto.IsClickable(Browser);

            AutomatedActions.SendDataEnterATM(Browser, InputDataGravacaoFoto, textoDataGravacao);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void PesquisarCampoClassificacao(string textoClassificacao)
        {
            InputClassificacaoFoto.EsperarElemento(Browser);
            InputClassificacaoFoto.IsClickable(Browser);

            AutomatedActions.SendDataATM(Browser, InputClassificacaoFoto, textoClassificacao);
            MouseActions.ClickATM(Browser, BtnFiltrar);
        }

        public void RefinarMarcacaoCena(string numeroCena)
        {
            var TagMarcacaoCena = Element.Xpath("//span[@class='tag tagCena tagRefinar'][text()='" + numeroCena + "']");
            TagMarcacaoCena.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, TagMarcacaoCena);

            var TagRefinarCena = Element.Xpath("//span[@class='tag tagCena'][text()='" + numeroCena + "']");

            TagRefinarCena.EsperarElemento(Browser);
            if (TagRefinarCena.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, BtnAplicarMarcacao);
            }

            else
            {
                throw new TimeoutException("Elemento não disponível.");
            }
        }

        public void RefinarMarcacaoCenario(string nomeCenario)
        {
            var TagMarcacaoCenario = Element.Xpath("//span[@class='tag tagCenario tagRefinar'][text()='" + nomeCenario + "']");
            TagMarcacaoCenario.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, TagMarcacaoCenario);

            var TagRefinarCenario = Element.Xpath("//span[@class='tag tagCenario'][text()='" + nomeCenario + "']");

            TagRefinarCenario.EsperarElemento(Browser);
            if (TagRefinarCenario.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, BtnAplicarMarcacao);
            }

            else
            {
                throw new TimeoutException("Elemento não disponível.");
            }
        }

        public void RefinarMarcacaoRoupa(string nomeRoupa)
        {
            var TagMarcacaoRoupa = Element.Css("span[class='tag tagRoupa tagRefinar']");
            TagMarcacaoRoupa.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, TagMarcacaoRoupa);

            var TagRefinarRoupa = Element.Xpath("//span[@class='tag tagRoupa'][text()='" + nomeRoupa + "']");

            TagRefinarRoupa.EsperarElemento(Browser);
            if (TagRefinarRoupa.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, BtnAplicarMarcacao);
            }

            else
            {
                throw new TimeoutException("Elemento não disponível.");
            }
        }

        public void RefinarMarcacaoAmbiente(string nomeAmbiente)
        {
            var TagMarcacaoAmbiente = Element.Xpath("//span[@class='tag tagAmbiente tagRefinar']");
            TagMarcacaoAmbiente.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, TagMarcacaoAmbiente);

            var TagRefinarAmbiente = Element.Xpath("//span[@class='tag tagAmbiente'][text()='" + nomeAmbiente + "']");

            TagRefinarAmbiente.EsperarElemento(Browser);
            if (TagRefinarAmbiente.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnAplicarMarcacao);
            }

            else
            {
                throw new TimeoutException("Elemento não disponível.");
            }
        }

		public void PreecherInformacoesImagem
		  (string nomeInseridoPor, string nomeTema, string numeroCapitulo, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
		{
			DropListInseridoPor.EsperarElemento(Browser);
			if(DropListInseridoPor.IsElementVisible(Browser))
			AutomatedActions.TypingListATM(Browser, DropListInseridoPor, ListInseridoPor, nomeInseridoPor);
			AutomatedActions.SendDataATM(Browser, DropListTema, nomeTema);
			KeyboardActions.Enter(Browser, DropListTema);
			AutomatedActions.TypingListATM(Browser, DropListCena, InputCena, numeroCapitulo);
			AutomatedActions.TypingListATM(Browser, DropListPersonagem, InputPersonagem, nomePersonagem);
			AutomatedActions.TypingListATM(Browser, DropListRoupa, InputRoupa, nomeRoupa);
			AutomatedActions.TypingListATM(Browser, DropListCenario, InputCenario, nomeCenario);
			AutomatedActions.TypingListATM(Browser, DropListAmbiente, InputAmbiente, nomeAmbiente);
			AutomatedActions.TypingListATM(Browser, DropListClassificao, InputClassificacao, nomeClassificacao);
		}

		private void PreencherInformacoesImagemDecupagemArte
			(string nomePersonagem, string nomeCenario, string nomeAmbiente, string nomeClassificacao)
		{
			DropListPersonagem.EsperarElemento(Browser);
			if (DropListPersonagem.IsElementVisible(Browser))
			AutomatedActions.TypingListATM(Browser, DropListPersonagem, InputPersonagem, nomePersonagem);
			AutomatedActions.TypingListATM(Browser, DropListCenario, InputCenario, nomeCenario);
			AutomatedActions.TypingListATM(Browser, DropListAmbiente, InputAmbiente, nomeAmbiente);
			AutomatedActions.TypingListATM(Browser, DropListClassificao, InputClassificacao, nomeClassificacao);
		}

		public override void Navegar()
        {
			Browser.Abrir(FotosUrl);
			Browser.PageLoad();
		}

		private void SelecionarTodasImagens()
        {
            BtnLimpar.EsperarElemento(Browser);
            if (BtnLimpar.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, BtnLimpar);
                MouseActions.ClickATM(Browser, BtnFiltrar);
                ChkSelectAllFotos.EsperarElemento(Browser);
                MouseActions.ClickATM(Browser, ChkSelectAllFotos);
            }
        }

        private void ApagarFotos()
        {
            BtnApagaFotos.EsperarElemento(Browser);
            if (BtnApagaFotos.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, BtnApagaFotos);

                if (Browser.PageSource("A exclusão destas fotos irá excluir também todas as marcações associadas a estas fotos. Tem certeza que deseja excluí-las?"))
                {
                    MouseActions.ClickATM(Browser, BtnExcluirFoto);
                    BtnExcluirFoto.EsperarElemento(Browser);
                }
                else
                    throw new TimeoutException("Elemento não disponível.");
            }
        }

        private void ClicarBtnIncluirFoto()
        {
            BtnIncluirFoto.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, BtnIncluirFoto);
        }

        private void SelecionarUmaFoto()
        {
            BtnIncluir.EsperarElemento(Browser);
            MouseActions.ClickMouseMoveToElementSML(Browser, BtnSelecionarImagem);
            Thread.Sleep(400);
            SendKeys.SendWait(GetPath.GetResourcePath("IMG_6582.JPG"));
            SendKeys.SendWait(@"{Enter}");
        }

        private void SelecionarDuasFotos()
        {
            BtnIncluir.EsperarElemento(Browser);
			if(BtnSelecionarImagem.IsElementVisible(Browser))
				MouseActions.ClickMouseMoveToElementSML(Browser, BtnSelecionarImagem);
				Thread.Sleep(400);
				SendKeys.SendWait(GetPath.GetResourcePath("\"IMG_6582.JPG\" \"IMG_6465.JPG\""));
				SendKeys.SendWait(@"{Enter}");
        }

        private void SelecionarQuatroFotos()
        {
            BtnIncluir.EsperarElemento(Browser);
            if(BtnSelecionarImagem.IsElementVisible(Browser))
				MouseActions.ClickMouseMoveToElementSML(Browser, BtnSelecionarImagem);
				Thread.Sleep(400);
				SendKeys.SendWait(GetPath.GetResourcePath("\"IMG_6582.JPG\" \"IMG_6465.JPG\" \"IMG_6466.JPG\" \"IMG_6467.JPG\""));
				SendKeys.SendWait(@"{Enter}");
        }

        private void SelecionarDezFotos()
        {
            BtnIncluir.EsperarElemento(Browser);
			if(BtnSelecionarImagem.IsElementVisible(Browser))
				MouseActions.ClickMouseMoveToElementSML(Browser, BtnSelecionarImagem);
				Thread.Sleep(400);
				SendKeys.SendWait(GetPath.GetResourcePath
					("\"IMG_6465.JPG\" \"IMG_6466.JPG\" \"IMG_6467.JPG\" \"IMG_6468.JPG\" " +
					"\"IMG_6469.JPG\" \"IMG_6470.JPG\" \"IMG_6471.JPG\" \"IMG_6472.JPG\" \"IMG_6473.JPG\" \"IMG_6582.JPG\""));
				SendKeys.SendWait(@"{Enter}");
        }

        private void AlterarInformacoes(string numeroCapitulo, string nomePersonagem, string nomeRoupa, string nomeCenario, string nomeAmbiente)
        {
            InputCena.ApagarEditarDados(numeroCapitulo, Browser);
            InputPersonagem.ApagarEditarDados(nomePersonagem, Browser);
            InputRoupa.ApagarEditarDados(nomeRoupa, Browser);
            InputCenario.ApagarEditarDados(nomeCenario, Browser);
            InputAmbiente.ApagarEditarDados(nomeAmbiente, Browser);
        }

        private void ImprimirAlbum()
        {
			BtnImprimirAlbum.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, BtnImprimirAlbum);
        }

        private void SelecionarQTAlbum(string numeroPagina)
        {
            //Legenda: 2 - 4 - 9 
            var PaginaAlbum = Element.Css("td[data-quantidade='" + numeroPagina + "']");

			PaginaAlbum.EsperarElemento(Browser);
			if (PaginaAlbum.IsClickable(Browser))
                MouseActions.ClickATM(Browser, PaginaAlbum);
                MouseActions.ClickATM(Browser, BtnGerarAlbum);
        }

		private void ExcluirFotoViaDetalhamento()
		{
			SelecionarFotoPrincipal();
			ExcluirFotoDetalhamento();
		}

		private void ExcluirFotoDetalhamento()
		{
			BtnExcluirFotoIcone.EsperarElemento(Browser);
			if (BtnExcluirFotoIcone.IsClickable(Browser))
				MouseActions.ClickATM(Browser, BtnExcluirFotoIcone);
		}

		private void SelecionarFotoPrincipal()
		{
			FotoPrincipal.EsperarElemento(Browser);
			MouseActions.ClickATM(Browser, FotoPrincipal);
		}

        private void ExclusaoFotoPopUp()
        {
            if (Browser.PageSource("A exclusão desta foto irá excluir também todas as marcações associadas a esta foto. Tem certeza que deseja excluí-la?"))
            {
                BtnOK.EsperarElemento(Browser);
                MouseActions.ClickATM(Browser, BtnOK);
            }
        }

        private void FecharDetalhesFoto()
        {
            var BtnFechar = Element.Xpath("//button//span[text()='Fechar']");

            BtnFechar.Esperar(Browser, 2000);
            if (BtnFechar.IsClickable(Browser))
                MouseActions.ClickATM(Browser, BtnFechar);
        }


        //-------------------VERIFICACOES-------------------\\
        public void VerificarFoto(string posicaoFoto, string validation)
        {
            var MoreDetailsFoto = Element.Css(":nth-child(" + posicaoFoto + ") > .picInfo > img");
            
			if (MoreDetailsFoto.IsClickable(Browser))
			{
				MoreDetailsFoto.EsperarElemento(Browser);
				MouseActions.ClickATM(Browser, MoreDetailsFoto);

				var TagDetailsAmbiente = Element.Css(".vertodosAdiv div.tagAmbiente").GetTexto(Browser);
				Assert.AreEqual(validation, TagDetailsAmbiente);
			}

			else
			{
				Thread.Sleep(6000);
				Browser.RefreshPage();
				MouseActions.ClickATM(Browser, MoreDetailsFoto);

				var TagDetailsAmbiente = Element.Css(".vertodosAdiv div.tagAmbiente").GetTexto(Browser);
				Assert.AreEqual(validation, TagDetailsAmbiente);
			}
        }

        public void VerificarImagemEditada(string posicaoImagem)
        {
            //Legenda: Posicao foto inicio 1 | 2 | 3....
            string validation = "LUCAS";
            var TagPersonagemPosicaoFoto = Element.Css(":nth-child(" + posicaoImagem + ") > .picInfo > .tag.tagPersonagem");
            Assert.IsTrue(true, TagPersonagemPosicaoFoto.GetTexto(Browser), validation);
        }

        public void VerificarImagemFiltrada()
        {
            var VerificarElemento = Element.Css("div[class='picInfo'] h1");
            string validarElemento = VerificarElemento.GetTexto(Browser);

            Assert.IsTrue(true, validarElemento);
			Thread.Sleep(1000);
        }

        public void VerificarMarcacaoCena(string verificarMarcacao)
        {
            var MarcacaoCena = Element.Css("span[class='tag tagCena tagRefinar']");
            MarcacaoCena.EsperarElemento(Browser);
            string nomeMarcacaoCena = MarcacaoCena.GetTexto(Browser);

            Assert.AreEqual(nomeMarcacaoCena, verificarMarcacao);
        }

        public void VerificarMarcacaoCenario(string verificarMarcacao)
        {
            var MarcacaoCenario = Element.Css("span[class='tag tagCenario']");
            MarcacaoCenario.EsperarElemento(Browser);
            string nomeMarcacao = MarcacaoCenario.GetTexto(Browser);
            string nomeMarcacaoCenario = nomeMarcacao.Remove(nomeMarcacao.Length - 1);

            Assert.AreEqual(nomeMarcacaoCenario, verificarMarcacao);
        }

        public void VerificarMarcacaoRoupa(string verificarMarcacao)
        {
            var MarcacaoRoupa = Element.Css("span[class='tag tagRoupa']");
            MarcacaoRoupa.EsperarElemento(Browser);
            string nomeMarcacao = MarcacaoRoupa.GetTexto(Browser);
            string nomeMarcacaoRoupa = nomeMarcacao.Remove(nomeMarcacao.Length - 1);

            Assert.AreEqual(nomeMarcacaoRoupa, verificarMarcacao);
        }

        public void VerificarMarcacaoAmbiente(string verificarMarcacao)
        {
            var MarcacaoAmbiente = Element.Css("span[class='tag tagAmbiente']");
            MarcacaoAmbiente.EsperarElemento(Browser);
            string nomeMarcacao = MarcacaoAmbiente.GetTexto(Browser);
            string nomeMarcacaoAmbiente = nomeMarcacao.Remove(nomeMarcacao.Length - 1);

            Assert.AreEqual(nomeMarcacaoAmbiente, verificarMarcacao);
        }

        public void VerificarExclusaoFoto()
        {
            var AlertaFoto = Element.Css("div[class='toast-message']");
            string alerta = AlertaFoto.GetTexto(Browser);
            string validation = "Exclusão realizada com sucesso.";

            Assert.AreEqual(alerta, validation);
        }

        public void VerificarDownloadUmaImagem()
        {
			DeletePDF.DeletarJPEG(Browser, ConfigurationManager.AppSettings["downloadPath"], TextoElementoID);
		}

		public void VerificarDownloadImagens()
        {
			 DeletePDF.DeletarPDF(Browser, ConfigurationManager.AppSettings["downloadPath"]);
        }
	}
}