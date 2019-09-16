using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;

namespace Project.SGP.Pages
{
    public class LoginPage : PageBase
    {
        private string Url { get; }
        private string HomeUrl { get; }

        //Login - Input
        private Element InputUser { get; set; }
        private Element InputPass { get; set; }

        //Login - Button
        private Element BtnLogin { get; set; }

        public LoginPage(IBrowser browser, string url, string homeUrl) : base(browser)
        {
            Url = url;
            HomeUrl = homeUrl;

            //Login - Input
            InputUser = Element.Css("input[id='txtUser']");
            InputPass = Element.Css("input[id='txtPassword']");

            //Login - Button
            BtnLogin = Element.Css("input[id='btnLogon']");
        }


        //-------------------METODOS-------------------\\
        public void Logar(string login, string senha)
		{
			PreencherLogin(login, senha);
			ClicarBtnLogin();
		}

		private void ClicarBtnLogin()
		{
			if (BtnLogin.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnLogin);
		}

		private void PreencherLogin(string login, string senha)
		{
			if(InputUser.IsElementVisible(Browser))
            {
                AutomatedActions.SendDataATM(Browser, InputUser, login);
                AutomatedActions.SendDataATM(Browser, InputPass, senha);
            }
				
		}

		public override void Navegar()
        {
			Browser.Abrir(Url);
		}

		public bool UsuarioLogado()
        {
            return Browser.UrlAtual() == HomeUrl;
        }
    }
}
