using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class CarregaDadosParametrizadosSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public CriacaoNovaFrenteGravacaoSteps CriacaoNovaFrenteGravacaoSteps { get; private set; }

        public CarregaDadosParametrizadosSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);
            CriacaoNovaFrenteGravacaoSteps = new CriacaoNovaFrenteGravacaoSteps();
        }

        [When(@"eu altero as informações da nova frente")]
        public void QuandoEuAlteroAsInformacoesDaNovaFrente()
        {
            CriacaoNovaFrenteGravacaoSteps.QuandoEuCriarUmaNovaFrenteDeGravacao();
            CriacaoNovaFrenteGravacaoSteps.EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
            TelaPlanejamentoGROT.EditarParametrosNovaFrenteDePlanejamento("3", "20", "1");
            CriacaoNovaFrenteGravacaoSteps.EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
            TelaPlanejamentoGROT.EditarParametrosNovaFrenteDePlanejamento("3", "10", "6");
        }

        [Then(@"eu visualizo as informacoes da nova frente alteradas com sucesso")]
        public void EntaoEuVisualizoAsInformacoesDaNovaFrenteAlteradasComSucesso()
        {
            CriacaoNovaFrenteGravacaoSteps.EntaoEuVisualizoAFrenteDeGravacaoCriadaComSucesso();
            TelaPlanejamentoGROT.EditarParametrosNovaFrenteDePlanejamento("3", "", "");
        }

    }
}
