using TechTalk.SpecFlow;
using Project.SGP.Pages;
using System.Configuration;
using Framework.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly LoginPage TelaLogin;

        public LoginSteps()
        {
			var browser = ScenarioContext.Current["browser"];
			TelaLogin = new LoginPage((IBrowser)browser,
                ConfigurationManager.AppSettings["LoginURL"],
                ConfigurationManager.AppSettings["HomeURL"]);
        }

        [Given(@"efetuar o login no sistema do SGP com perfil sem GROT")]
        public void DadoEfetuarOLoginNoSistemaDoSGPComPerfilSemGROT()
        {
            TelaLogin.Logar(ConfigurationManager.AppSettings["loginId"], ConfigurationManager.AppSettings["loginPw"]);
        }

        [Given(@"que eu navegue para a Tela de Login do SGP")]
        public void DadoQueNavegueParaaTelaTelaDeLoginDoSGP()
        {
            TelaLogin.Navegar();
        }

        [Given(@"efetuar o login no sistema do SGP")]
        public void QuandoEfetuarOLoginNoSistemaDoSGP()
        {
            TelaLogin.Logar(ConfigurationManager.AppSettings["loginIdGrot"], ConfigurationManager.AppSettings["loginPwGrot"]);
        }

        [Then(@"eu visualizo a tela inicial")]
        public void EntaoEuVisualizoATelaInicial()
        {
            Assert.AreEqual(true, TelaLogin.UsuarioLogado());
        }
    }
}
