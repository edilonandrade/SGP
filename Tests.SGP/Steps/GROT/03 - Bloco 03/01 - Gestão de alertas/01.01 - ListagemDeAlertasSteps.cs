using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
    [Binding]
    public class ListagemDeAlertasSteps
    {
        public HomePage TelaHome { get; private set; }
        public IndisponibilidadeLocaisPage TelaIndisponibilidadeLocais { get; private set; }
        public GestaoAlertasPage TelaGestaoAlerta { get; private set; }

        public ListagemDeAlertasSteps()
        {
            var browser = ScenarioContext.Current["browser"];
            TelaHome = new HomePage((IBrowser)browser,
                ConfigurationManager.AppSettings["HomeURL"],
                ConfigurationManager.AppSettings["FotosURL"],
                ConfigurationManager.AppSettings["DecupagemBasicaURL"],
                ConfigurationManager.AppSettings["PlanejamentoRoteiroURL"]);
            TelaIndisponibilidadeLocais = new IndisponibilidadeLocaisPage((IBrowser)browser,
                ConfigurationManager.AppSettings["IndisponibilidadeLocal"]);
            TelaGestaoAlerta = new GestaoAlertasPage((IBrowser)browser, ConfigurationManager.AppSettings["GestaoAlertaUrl"]);
        }

        [When(@"eu navegar para a Tela Gestao de Alertas")]
        public void QuandoEuNavegarParaATelaGestaoDeAlertas()
        {
            TelaGestaoAlerta.Navegar();
        }

        [Then(@"eu visualizo a listagem com sucesso")]
        public void EntaoEuVisualizoAListagemComSucesso()
        {
            //Validar Area

            TelaGestaoAlerta.ValidarArea("CENA");
            TelaGestaoAlerta.ValidarArea("DIA");
            TelaGestaoAlerta.ValidarArea("ROTEIRO");
            TelaGestaoAlerta.ValidarArea("SEMANA");

            //Validar Texto
            TelaGestaoAlerta.ValidarTexto("Antecedência mínima de gravação");
            TelaGestaoAlerta.ValidarTexto("Tempo preparação de elenco");
            TelaGestaoAlerta.ValidarTexto("Iluminação");
            TelaGestaoAlerta.ValidarTexto("Faixa de horário de gravação");
            TelaGestaoAlerta.ValidarTexto("Caracterização de elenco");

            TelaGestaoAlerta.ValidarTexto("Indisponibilidade de elenco");
            TelaGestaoAlerta.ValidarTexto("Jornada da frente");
            TelaGestaoAlerta.ValidarTexto("Refeição de elenco");
            TelaGestaoAlerta.ValidarTexto("Tempo de deslocamento");
            TelaGestaoAlerta.ValidarTexto("Interjornada de elenco");
            TelaGestaoAlerta.ValidarTexto("Conflito de horário de elenco");
            TelaGestaoAlerta.ValidarTexto("Múltipla alocação do ambiente");
            TelaGestaoAlerta.ValidarTexto("Jornada de elenco");

            TelaGestaoAlerta.ValidarTexto("Metragem de estúdio");
            TelaGestaoAlerta.ValidarTexto("Incompatibilidade de cenários e ambientes");
            TelaGestaoAlerta.ValidarTexto("MQE");
            TelaGestaoAlerta.ValidarTexto("Inconsistência");
            TelaGestaoAlerta.ValidarTexto("Refeição da equipe");
            TelaGestaoAlerta.ValidarTexto("Frente de gravação incompatível");

            TelaGestaoAlerta.ValidarTexto("Jornada semanal do elenco");
            TelaGestaoAlerta.ValidarTexto("Limite de Dias de Gravação na Semana da Frente");
            TelaGestaoAlerta.ValidarTexto("Indisponibilidade do local");
            TelaGestaoAlerta.ValidarTexto("Indisponibilidade de frente de gravação");
            TelaGestaoAlerta.ValidarTexto("Interjornada de frente");
            TelaGestaoAlerta.ValidarTexto("Limite de Dias de Gravação na Semana do Elenco");

            //Validar Imagem
            TelaGestaoAlerta.ValidarImgem("Antecedencia-Minima-de-Gravacao.png");
            TelaGestaoAlerta.ValidarImgem("preparacao-elenco.png");
            TelaGestaoAlerta.ValidarImgem("Horarios-Iluminacao-Manha-Tarde-Noite.png");
            TelaGestaoAlerta.ValidarImgem("Faixa-de-horario-de-gravacao.png");
            TelaGestaoAlerta.ValidarImgem("Caracterizacao-de-elenco.png");

            TelaGestaoAlerta.ValidarImgem("indisponibilidade-de-elenco.png");
            TelaGestaoAlerta.ValidarImgem("jornada-de-frente.png");
            TelaGestaoAlerta.ValidarImgem("refeicao_elenco.png");
            TelaGestaoAlerta.ValidarImgem("deslocamento.png");
            TelaGestaoAlerta.ValidarImgem("interjornada-de-elenco.png");
            TelaGestaoAlerta.ValidarImgem("indisponibilidaden-de-horario.png");
            TelaGestaoAlerta.ValidarImgem("Multipla-alocacao-do-ambiente.png");
            TelaGestaoAlerta.ValidarImgem("jornada-de-elenco.png");

            TelaGestaoAlerta.ValidarImgem("metragem-de-estudio.png");
            TelaGestaoAlerta.ValidarImgem("incompatibilidade-de-cenarios-e-ambientes.png");
            TelaGestaoAlerta.ValidarImgem("MQE.png");
            TelaGestaoAlerta.ValidarImgem("iconcistencia.png");
            TelaGestaoAlerta.ValidarImgem("refeicao_frente.png");
            TelaGestaoAlerta.ValidarImgem("Frente-de-gravacao-incompativel.png");

            TelaGestaoAlerta.ValidarImgem("jornada-semanal-de-elenco.png");
            TelaGestaoAlerta.ValidarImgem("limite-de-dias-de-gravacao-na-semana.png");
            TelaGestaoAlerta.ValidarImgem("indisponibilidade-de-local.png");
            TelaGestaoAlerta.ValidarImgem("indisponibilidade-de-frente-de-gravacao.png");
            TelaGestaoAlerta.ValidarImgem("interjornada-de-frente.png");
            TelaGestaoAlerta.ValidarImgem("limite-de-dias-de-gravacao-na-semana.png");
        }

    }
}
