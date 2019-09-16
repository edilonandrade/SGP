using System;
using Framework.Core.Actions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Framework.Core.Extensions.ElementExtensions;

namespace Project.SGP.Pages
{
    public class HomePage : PageBase
    {
        private string HomeUrl { get; }
        private string FotosUrl { get; }
        private string DecupagemBasicaUrl { get; }
        private string PlanejamentoRoteiroUrl { get; }

        //DropList
        private Element DropListACURA { get; }
        private Element DropList100ANOS { get; }
		private Element Menu { get; }
		private Element MenuList { get; }

        //Input
        private Element InputProgramacao { get; }

		//Others
		private Element TimeLineHome { get; }
		private Element DropListHome { get; }



		public HomePage(IBrowser browser,
            string homeUrl,
            string fotosUrl,
            string decupagembasicaUrl,
            string planejamentoroteiroUrl) : base(browser)
        {
            HomeUrl = homeUrl;
            FotosUrl = fotosUrl;
            DecupagemBasicaUrl = decupagembasicaUrl;
            PlanejamentoRoteiroUrl = planejamentoroteiroUrl;

            //Programacao - Input
            InputProgramacao = Element.Xpath("//*[@id='selectProgramas_chzn']//input");

			//Others
			TimeLineHome = Element.Css("#timeline");
			DropListHome = Element.Css("#selectProgramas_chzn > a > span");
			Menu = Element.Link("Menu");
		}


        //-------------------METODOS-------------------\
        private void TrocaProgramacao(string programacoes)
        {
            var Submenu = Element.Css("div[class='submenu']");
            Submenu.EsperarElemento(Browser);
            DropListHome.EsperarElemento(Browser);
            DropListHome.IsElementVisible(Browser);
            DropListHome.IsClickable(Browser);
            AutomatedActions.TypingListATM(Browser, DropListHome, InputProgramacao, programacoes.Trim());
        }

        public void EscolherProgramacao(string programacoes)
        {
            try
            {
                TrocaProgramacao(programacoes);
            }
            catch
            {
                TrocaProgramacao(programacoes);
            }

            TimeLineHome.EsperarElemento(Browser);
        }

        public void AcessarMenuList(string nomeMenuList)
		{
			var MenuList = Element.Link(nomeMenuList);

			Menu.EsperarElemento(Browser);
            Menu.Esperar(Browser, 2000);
            if (Menu.IsElementVisible(Browser))
			{
				MouseActions.ClickATM(Browser, Menu);
			}

			MenuList.EsperarElemento(Browser);
			MenuList.IsElementVisible(Browser);
			MouseActions.ClickATM(Browser, MenuList);
		}

        public override void Navegar()
        {
			Browser.Abrir(HomeUrl);
			Browser.PageLoad();
		}
	}
}