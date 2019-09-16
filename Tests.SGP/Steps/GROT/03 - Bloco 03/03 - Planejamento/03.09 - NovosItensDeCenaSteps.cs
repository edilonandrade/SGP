using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
    [Binding]
    public class NovosItensDeCenaSteps
    {
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }

        public NovosItensDeCenaSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);
        }

        [When(@"eu clico em Editar")]
        public void QuandoEuClicoEmEditar()
        {
            TelaPlanejamentoGROT.ClickEditarBloquear();
        }

        [When(@"eu crio um roteiro incluindo o novo icone de refeicao")]
        public void QuandoEuCrioUmRoteiroIncluindoONovoIconeDeRefeicao()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Refeição", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu crio um roteiro informando o tempo de preparacao inicial")]
        public void QuandoEuCrioUmRoteiroInformandoOTempoDePreparacaoInicial()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Preparacao", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu crio um roteiro informando o tempo de deslocamento")]
        public void QuandoEuCrioUmRoteiroInformandoOTempoDeDeslocamento()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Deslocamento", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "1000/010P", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu crio um roteiro aumentando o tempo de preparacao inicial")]
        public void QuandoEuCrioUmRoteiroAumentandoOTempoDePreparacaoInicial()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Preparacao", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.AlterarTempo("Aumentar", 3);
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu crio um roteiro diminuindo o tempo de preparacao inicial")]
        public void QuandoEuCrioUmRoteiroDiminuindoOTempoDePreparacaoInicial()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Preparacao", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.AlterarTempo("Diminuir", 2);
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu crio um roteiro aumentando o tempo de deslocamento")]
        public void QuandoEuCrioUmRoteiroAumentandoOTempoDeDeslocamento()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Deslocamento", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.AlterarTempo("Aumentar", 3);
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "1000/010P", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [When(@"eu crio um roteiro diminuindo o tempo de deslocamento")]
        public void QuandoEuCrioUmRoteiroDiminuindoOTempoDeDeslocamento()
        {
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTDiario(CalendarioHelper.ObterDataAtual(), "1000/025", "2");
            TelaPlanejamentoGROT.IncluirNovoIcone("Deslocamento", CalendarioHelper.ObterDataAtual());
            TelaPlanejamentoGROT.AlterarTempo("Diminuir", 2);
            TelaPlanejamentoGROT.CriarPlanejamentoRoteiroGROTSemanal(CalendarioHelper.ObterDataAtual(), "1000/010P", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [Then(@"eu visualizo as cenas de roteiro com o tempo de deslocamento maior que o padrao com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComOTempoDeDeslocamentoMaiorQueOPadraoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Deslocamento", "00:30");
        }

        [Then(@"eu visualizo as cenas de roteiro com o tempo de deslocamento menor que o padrao com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComOTempoDeDeslocamentoMenorQueOPadraoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Deslocamento", "00:05");
        }

        [Then(@"eu visualizo as cenas de roteiro com o tempo de preparacao inicial maior que o padrao com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComOTempoDePreparacaoInicialMaiorQueOPadraoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Preparação", "00:30");
        }

        [Then(@"eu visualizo as cenas de roteiro com o tempo de preparacao inicial menor que o padrao com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComOTempoDePreparacaoInicialMenorQueOPadraoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Preparação", "00:05");
        }

        [Then(@"eu visualizo as cenas de roteiro com o tempo de deslocamento com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComOTempoDeDeslocamentoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Deslocamento", "00:15");
        }

        [Then(@"eu visualizo as cenas de roteiro com o tempo de preparacao inicial com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComOTempoDePreparacaoInicialComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Preparação", "00:15");
        }

        [Then(@"eu visualizo as cenas de roteiro com horario de refeicao com sucesso")]
        public void EntaoEuVisualizoAsCenasDeRoteiroComHorarioDeRefeicaoComSucesso()
        {
            TelaPlanejamentoGROT.ValidarItemDeCenaNoRoteiro("Refeição", "01:00");
        }

        [Then(@"eu visualizo os novos itens de cena acima da listagem de cenas com sucesso")]
        public void EntaoEuVisualizoOsNovosItensDeCenaAcimaDaListagemDeCenasComSucesso()
        {
            TelaPlanejamentoGROT.ValidarIconesDeCena();
        }
    }
}
