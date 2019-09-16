using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class ParametrosSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public ParametrosPage TelaParametros { get; private set; }
        public CapitulosCenasPage TelaCapituloCena { get; private set; }
        public HomePage TelaHome { get; private set; }

        public ParametrosSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaParametros = new ParametrosPage((IBrowser)browser,
               ConfigurationManager.AppSettings["ParametrosURL"]);

            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaCapituloCena = new CapitulosCenasPage((IBrowser)browser,
               ConfigurationManager.AppSettings["CapituloCenaURL"],
               ConfigurationManager.AppSettings["IncluirCapituloURL"],
               ConfigurationManager.AppSettings["IncluirAdendoURL"]);
        }

        [Given(@"que eu acesse a tela de parametros de producao")]
        public void DadoQueEuAcesseATelaDeParametrosDeProducao()
        {
            TelaHome.AcessarMenuList("Parâmetros de Produção");
        }

        [When(@"eu alterar um parametro")]
        public void QuandoEuAlterarUmParametro()
        {
            TelaParametros.PreencherDiasAntecedencia("5");
        }

        [When(@"eu alterar mais de um parametro")]
        public void QuandoEuAlterarMaisDeUmParametro()
        {
            TelaParametros.AlterarParametrosProducao("3", "5");
        }

        [Then(@"eu visualizo a alteracao de um parametro alterado no log com sucesso")]
        public void EntaoEuVisualizoAAlteracaoDeUmParametroAlteradoNoLogComSucesso()
        {
            TelaHome.AcessarMenuList("LOG");
            TelaParametros.FiltrarConsultaDeLog("Parâmetro Produção");
            TelaParametros.ValidarLog(ConfigurationManager.AppSettings["loginId"],
                "Alteração Parâmetros", "Antecedência Miínima de Gravação", "Parâmetros de produção");
        }

        [Then(@"eu visualizo a alteracao de mais de um parametro alterado no log com sucesso")]
        public void EntaoEuVisualizoAAlteracaoDeMaisDeUmParametroAlteradoNoLogComSucesso()
        {
            TelaHome.AcessarMenuList("LOG");
            TelaParametros.FiltrarConsultaDeLog("Parâmetro Produção");
            TelaParametros.ValidarLog(ConfigurationManager.AppSettings["loginId"],
                "Alteração Parâmetros", "Quantidade dias Folga Semanal, Antecedência Miínima de Gravação", "Parâmetros de produção");

            TelaHome.AcessarMenuList("Parâmetros de Produção");
            TelaParametros.AlterarParametrosProducao("1", "3");
        }
        
    }
}
