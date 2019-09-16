using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public sealed class AtualizarValidarCenasSteps
    {

        public PlanejamentoRoteiroPage TelaPlanejamentoRoteiro { get; private set; }
        public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }
        public RoteiroPage TelaRoteiro { get; private set; }

        public AtualizarValidarCenasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaPlanejamentoRoteiro = new PlanejamentoRoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);

            TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
                ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);

            TelaRoteiro = new RoteiroPage((IBrowser)browser,
                ConfigurationManager.AppSettings["RoteiroURL"],
				ConfigurationManager.AppSettings["CapituloCenaURL"]);
        }

        [When(@"Atualizar cena para gravada")]
        public void QuandoAtualizarCenaParaGravada()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Gravada");
            TelaEspelhoGravacao.PreencherEspelhoGravacao();
        }

        [When(@"Atualizar cena para gravada a parte")]
        public void QuandoAtualizarCenaParaGravadaAParte()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Gravada Parte");
            TelaEspelhoGravacao.PreencherEspelhoGravacao();
        }

        [When(@"Atualizar cena para pendurada")]
        public void QuandoAtualizarCenaParaPendurada()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Pendurada");
            TelaEspelhoGravacao.PreencherEspelhoGravacao();
        }

        [When(@"Atualizar cena para cortada")]
        public void QuandoAtualizarCenaParaCortada()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Cortada");
            TelaEspelhoGravacao.PreencherEspelhoGravacao();
        }

        [When(@"Atualizar cena para fechada a parte")]
        public void QuandoAtualizarCenaParaFechadaAParte()
        {
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("0400/001", "Gravada Parte");
            //TelaEspelhoGravacao.AlterarStatusSegundaCena("0400/002", "Roteirizada");
            TelaEspelhoGravacao.PreencherEspelhoGravacao();
        }

        [Then(@"visualizo status do roteiro gravada")]
        public void EntaoVisualizoStatusDoRoteiroGravada()
        {
            TelaRoteiro.VerificarStatusRoteiro("Fechado", "Gravada");
        }

        [Then(@"visualizo status do roteiro gravada a parte")]
        public void EntaoVisualizoStatusDoRoteiroGravadaAParte()
        {
            TelaRoteiro.VerificarStatusRoteiro("Fechado", "Gravada Parte");
        }

        [Then(@"visualizo status do roteiro pendurada")]
        public void EntaoVisualizoStatusDoRoteiroPendurada()
        {
            TelaRoteiro.VerificarStatusRoteiro("Fechado", "Pendurada");
        }

        [Then(@"visualizo status do roteiro cortada")]
        public void EntaoVisualizoStatusDoRoteiroCortada()
        {
            TelaRoteiro.VerificarStatusRoteiro("Fechado", "Cortada");
        }

        [Then(@"visualizo status do roteiro com duas cenas")]
        public void EntaoVisualizoStatusDoRoteiroComDuasCenas()
        {
            TelaRoteiro.VerificarStatusRoteiroCenaUm("Fechado Parte", "Gravada Parte");
            //TelaRoteiro.VerificarStatusRoteiroCenaDois("Fechado Parte", "Roteirizada");
        }
    }
}
