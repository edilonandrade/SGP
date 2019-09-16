using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Project.SGP.Helpers;
using System.Threading;
using System.Windows.Forms;

namespace Project.SGP.Pages
{
    public class EspelhoGravacaoPage : PageBase
    {
        private string EspelhoGravacaoUrl { get; }
        public string numeroRoteiro { get; set; }

        //Modificar status - Others
        private Element NumeroCena { get; }
        private Element NumeroRoteiro { get; }
        private Element DropNumeroRoteiro { get; }

        //Modificar status - Drop
        private Element DropListStatusCena { get; }

        //Modificar status - Input
        private Element InputStatusCena { get; }

        //Modificar status - Button
        private Element BtnSalvar { get; }

        //Espelho gravacao - Input
        private Element InputPendurar { get; }
        private Element InputClassificacao { get; }
        private Element InputAmbiente { get; }
        private Element InputCenario { get; }
        private Element InputRoupa { get; }
        private Element InputPersonagem { get; }
        private Element InputCena { get; }
        private Element InputCampoOBS { get; }
        private Element InputNovaFita { get; }
        private Element InputCampoContinuidadeCena { get; }

        //Espelho gravacao - Button
        private Element BtnPendurar { get; }
        private Element BtnIncluirImagem { get; }
        private Element BtnSelecionarImagem { get; }
        private Element BtnAddFoto { get; }
        private Element BtnInserirNovaFita { get; }
        private Element BtnSalvarImagem { get; }

        //Espelho gravacao - Others
        private Element PopUpPendurar { get; }
        private Element AbaContinuidadeCena { get; }
        private Element AbaPersonagem { get; }

        //Espelho gravacao - DropList
        private Element DropListClassificao { get; }
        private Element DropListAmbiente { get; }
        private Element DropListCenario { get; }
        private Element DropListRoupa { get; }
        private Element DropListPersonagem { get; }
        private Element DropListCena { get; }
        private Element DropListTema { get; }
        private Element DropListInseridoPor { get; }
        private Element ListInseridoPor { get; }


        public EspelhoGravacaoPage(IBrowser browser,
          string espelhoGravacaoUrl) : base(browser)
        {
            EspelhoGravacaoUrl = espelhoGravacaoUrl;

            //Modificar status - Others
            PopUpPendurar = Element.Id("motivoPendurar");
            NumeroCena = Element.Id("numeroCena");
            NumeroRoteiro = Element.Id("numeroRoteiro");
            DropNumeroRoteiro = Element.Css("div[id='dropMenuRoteiro'] li");

            //Modificar status - Drop
            DropListStatusCena = Element.Css("#statusCena_chzn > a > span");

            //Modificar status - Input
            InputPendurar = Element.Id("textMotivoPendurar");
            InputStatusCena = Element.Css("div[id='statusCena_chzn'] input");

            //Modificar status - Button
            BtnIncluirImagem = Element.Id("confirmarUpload");
            BtnSalvar = Element.Css("div[class='buttons'] input[value='Salvar']");

            //Espelho gravacao - Input
            InputClassificacao = Element.Id("s2id_autogen1");
            InputAmbiente = Element.Xpath("//*[@id='marcacao0_chzn']//input");
            InputCenario = Element.Xpath("//*[@id='marcacao2_chzn']//input");
            InputRoupa = Element.Xpath("//*[@id='marcacao4_chzn']//input");
            InputPersonagem = Element.Xpath("//*[@id='marcacao3_chzn']//input");
            InputCena = Element.Xpath("//*[@id='marcacao1_chzn']//input");
            InputCampoOBS = Element.Css("#obsParaEdicao");
            InputNovaFita = Element.Css("#nomeFita.field");
            InputCampoContinuidadeCena = Element.Css("#observacaoDeContinuidade");

            //Espelho gravacao - Button
            BtnPendurar = Element.Xpath("//button//span[text()='Pendurar']");
            BtnAddFoto = Element.Id("btnAddFotoPers");
            BtnInserirNovaFita = Element.Css("#botaoInserirFita");
            BtnSelecionarImagem = Element.Link("Selecionar Imagens");
            BtnSalvarImagem = Element.Xpath("//button//span[text()='Salvar']");

            //Espelho gravacao - Others
            AbaContinuidadeCena = Element.Id("abaCena");
            AbaPersonagem = Element.Id("abaPersonagem");

            //Espelho gravacao - DropList
            DropListClassificao = Element.Css("#s2id_marcacao8 > ul > li");
            DropListAmbiente = Element.Id("marcacao0_chzn");
            DropListCenario = Element.Id("marcacao2_chzn");
            DropListRoupa = Element.Id("marcacao4_chzn");
            DropListPersonagem = Element.Id("marcacao3_chzn");
            DropListCena = Element.Id("marcacao1_chzn");
            DropListInseridoPor = Element.Xpath("//a[span='Arte']");
            ListInseridoPor = Element.Xpath("(//input[@type='text'])[6]");
            DropListTema = Element.Xpath("(//input[@value='Escolha...'])[5]");


        }

        //-------------------METODOS-------------------\\
        public void AlterarStatusPrimeiraCena(string numeroCena, string statusCena)
        {
            PegarNumeroRoteiro();

			Browser.Abrir(EspelhoGravacaoUrl);

            EscolherNumeroRoteiro();
            EscolherCena(numeroCena);
            ModificarStatus(statusCena);
            if (PopUpPendurar.IsElementVisible(Browser))
            {
                AutomatedActions.SendDataATM(Browser, InputPendurar, "pendurar cena");
                MouseActions.ClickATM(Browser, BtnPendurar);
                SalvarStatus();
            }
            else
            {
                SalvarStatus();
            }
        }

        public void AlterarStatusSegundaCena(string numeroCena, string statusCena)
        {
            EscolherNumeroRoteiro();
            EscolherCena(numeroCena);
            ModificarStatus(statusCena);
            if (PopUpPendurar.IsElementVisible(Browser))
            {
                AutomatedActions.SendDataATM(Browser, InputPendurar, "pendurar cena");
                MouseActions.ClickATM(Browser, BtnPendurar);
                SalvarStatus();
            }
            else
            {
                SalvarStatus();
            }
        }

        public void AlterarStatus(string numeroCena, string statusCena)
        {
            //Browser.BackPage();
            Browser.Abrir(EspelhoGravacaoUrl);
            EscolherNumeroRoteiro();
            EscolherCena(numeroCena);
            ModificarStatus(statusCena);
            SalvarStatus();
        }

        public void PreencherEspelhoGravacao()
        {
            PreencherPersonagem();
            //TirarAlerta();
            PreencherContinuidadeCena();
            SalvarStatus();
        }

        private void PreencherPersonagem()
        {
            PreencherCampoOBS();
            InserirNovaFita();
            //AdicionarFotoPersonagem();
            //PreecherInformacoesImagem(numeroCapituloCena);
            //IncluirImagem();
            //SalvarImagem();
        }

        private void PreencherContinuidadeCena()
        {
            PreencherCampoOBSContinuidade();
        }

        private void PreencherCampoOBSContinuidade()
        {
			AbaContinuidadeCena.EsperarElemento(Browser);
			AbaContinuidadeCena.Esperar(Browser, 2000);
			if (AbaContinuidadeCena.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, AbaContinuidadeCena);
                AutomatedActions.SendDataATM(Browser, InputCampoContinuidadeCena, FakeHelpers.FullName());
            }
        }

        private void IncluirImagem()
        {
            BtnIncluirImagem.EsperarElemento(Browser);
            BtnIncluirImagem.Esperar(Browser, 600);
            if (BtnIncluirImagem.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnIncluirImagem);
            }
        }

        private void PreencherCampoOBS()
        {
			InputCampoOBS.EsperarElemento(Browser);
			AutomatedActions.SendDataATM(Browser, InputCampoOBS, FakeHelpers.FullName());
        }

        private void InserirNovaFita()
        {
			InputNovaFita.EsperarElemento(Browser);
			AutomatedActions.SendDataATM(Browser, InputNovaFita, FakeHelpers.FirstName());
            if (BtnInserirNovaFita.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnInserirNovaFita);
            }
        }

        private void SalvarImagem()
        {
            BtnSalvarImagem.EsperarElemento(Browser);
            if (BtnSalvarImagem.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnSalvarImagem);
            }
        }

        private void AdicionarFotoPersonagem()
        {
            AbaPersonagem.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, AbaPersonagem);

			BtnAddFoto.EsperarElemento(Browser);
			if (BtnAddFoto.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnAddFoto);
                SelecionarUmaFoto();
            }
        }

        private void SelecionarUmaFoto()
        {
            BtnSelecionarImagem.EsperarElemento(Browser);
            MouseActions.ClickMouseMoveToElementSML(Browser, BtnSelecionarImagem);
            Thread.Sleep(400);
            SendKeys.SendWait(GetPath.GetResourcePath("IMG_6582.JPG"));
            SendKeys.SendWait(@"{Enter}");
        }

        private void PreencherCampoNovaFita()
        {
            AutomatedActions.SendDataATM(Browser, InputNovaFita, FakeHelpers.FirstName());
        }

        private void EscolherNumeroRoteiro()
        {
            NumeroRoteiro.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, NumeroRoteiro);

            if (DropNumeroRoteiro.IsElementVisible(Browser))
            {
                var SelecionarRoteiro = Element.Xpath("//div[@id='dropMenuRoteiro']//li[contains(.,'" + numeroRoteiro + "')]");
                MouseActions.ClickATM(Browser, SelecionarRoteiro);
            }
        }

        private void EscolherCena(string numeroCena)
        {
            NumeroCena.EsperarElemento(Browser);
            MouseActions.ClickATM(Browser, NumeroCena);

            var DropNumeroCena = Element.Xpath("//div[@id='dropMenuCena']//li[contains(.,'" + numeroCena + "')]");

            DropNumeroCena.EsperarElemento(Browser);
            if (DropNumeroCena.IsClickable(Browser))
            {
                MouseActions.ClickATM(Browser, DropNumeroCena);
            }
        }

        private void ModificarStatus(string statusCena)
        {
            DropListStatusCena.EsperarElemento(Browser);
            DropListStatusCena.Esperar(Browser, 400);
            if (DropListStatusCena.IsClickable(Browser))
            {
                AutomatedActions.TypingListATM(Browser, DropListStatusCena, InputStatusCena, statusCena);
            }
        }

        private void SalvarStatus()
        {
            BtnSalvar.EsperarElemento(Browser);
            if (BtnSalvar.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnSalvar);
            }
           
        }

       private void TirarAlerta()
        {
            var Alerta = Element.Xpath("//div[@class='toast-message'][text()='Foto salva com sucesso']");
            Alerta.EsperarElemento(Browser);
            if (Alerta.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, Alerta);
            }
            else
            {
                SalvarStatus();
            }
        }

        private string PegarNumeroRoteiro()
        {
			//var PegaNumeroRoteiro = Element.Css("div[class='rnumber numeroRoteiroVermelho']");
			var PegaNumeroRoteiro = Element.Css(".rnumber");
            numeroRoteiro = PegaNumeroRoteiro.GetTexto(Browser);

            return numeroRoteiro;
        }

        private void PreecherDados(string numeroCapitulo)
        {
            DropListInseridoPor.EsperarElemento(Browser);
            AutomatedActions.TypingListATM(Browser, DropListInseridoPor, ListInseridoPor, "Decupagem");
            AutomatedActions.SendDataATM(Browser, DropListTema, "Decupagem");
            KeyboardActions.Enter(Browser, DropListTema);
            AutomatedActions.TypingListATM(Browser, DropListCena, InputCena, numeroCapitulo);
            AutomatedActions.TypingListATM(Browser, DropListPersonagem, InputPersonagem, "FLAVIO");
            AutomatedActions.TypingListATM(Browser, DropListRoupa, InputRoupa, "1 (1º Bloco) - FLAVIO");
            AutomatedActions.TypingListATM(Browser, DropListCenario, InputCenario, "BAR QUALQUER");
            AutomatedActions.TypingListATM(Browser, DropListAmbiente, InputAmbiente, "AMBIENTE QA");
            AutomatedActions.TypingListATM(Browser, DropListClassificao, InputClassificacao, "Teste");
        }


        public override void Navegar()
        {
			Browser.Abrir(EspelhoGravacaoUrl);
			Browser.PageLoad();
		}



		//-------------------VERIFICACOES-------------------\\

	}
}
