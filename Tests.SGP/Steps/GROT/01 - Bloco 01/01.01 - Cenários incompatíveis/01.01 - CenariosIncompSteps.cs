using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps.GROT
{
	[Binding]
	public sealed class CriarListagemCenariosIncompativeisSteps
	{
		public CenarioIncompativelPage TelaCenarioIncompativel { get; private set; }
        public CriarNovoCenarioSteps CriarNovoCenarioSteps { get; private set; }
        public ConsultaDeLogPage TelaConsultaDeLog { get; private set; }
        public PlanejamentoGROTPage TelaPlanejamentoGROT { get; private set; }
        public EspelhoGravacaoPage TelaEspelhoGravacao { get; private set; }

        public CriarListagemCenariosIncompativeisSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaCenarioIncompativel = new CenarioIncompativelPage((IBrowser)browser,
			   ConfigurationManager.AppSettings["CenarioIncompativelURL"]);

            CriarNovoCenarioSteps = new CriarNovoCenarioSteps();

            TelaConsultaDeLog = new ConsultaDeLogPage((IBrowser)browser,
               ConfigurationManager.AppSettings["ConsultaLogUrl"]);

            TelaPlanejamentoGROT = new PlanejamentoGROTPage((IBrowser)browser,
               ConfigurationManager.AppSettings["PlanejamentoRoteiroGROTURL"]);

            TelaEspelhoGravacao = new EspelhoGravacaoPage((IBrowser)browser,
                ConfigurationManager.AppSettings["EspelhoGravacaoURL"]);
        }

        [Given(@"que eu tenha excluido uma nova lista de cenarios incompativeis")]
        public void DadoQueEuTenhaExcluidoUmaNovaListaDeCenariosIncompativeis()
        {
            QuandoEuExcluoOCenarioIncompativel();
            EntaoEuNaoVisualizoOCenarioDeIncompativelComSucesso();
        }

        [Given(@"que eu tenha criado duas listas de cenarios incompativeis")]
        public void DadoQueEuTenhaCriadoDuasListasDeCenariosIncompativeis()
        {
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "PAÇO IMPERIAL - EST", "PAÇO IMPERIAL - EST", "SALA DE DOM PEDRO", "SALA DO BEIJA-MÃO");
            TelaCenarioIncompativel.SalvarECriarNovaListaIncompatibilidade();
            TelaCenarioIncompativel.CriarSegundaListaCenarioIncompativel("INM LISTA NOVA", "CASA DE WOLFGANG", "PAÇO IMPERIAL - EST", "", "QUARTO", "CORREDOR", "");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [Given(@"que eu tenha alterado uma nova lista de cenarios incompativeis")]
        public void DadoQueEuTenhaAlteradoUmaNovaListaDeCenariosIncompativeis()
        {
            QuandoEuCriarListagemDeIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("INM LISTA", "", "PAÇO IMPERIAL - EST", "", "", "SALA DO BEIJA - MÃO", "", "2");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
        }

        [Given(@"que eu tenha criado uma nova lista de cenarios incompativeis marcando todos os ambientes")]
        public void DadoQueEuTenhaCriadoUmaNovaListaDeCenariosIncompativeisMarcandoTodosOsAmbientes()
        {
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "PAÇO IMPERIAL - EST", "CASA DE WOLFGANG", "", "");
            TelaCenarioIncompativel.MarcarTodosAmbientes("1", "2");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [Given(@"que eu tenha excluido todos os itens da nova lista de cenarios incompativeis")]
        public void DadoQueEuTenhaExcluidoTodosOsItensDaNovaListaDeCenariosIncompativeis()
        {
            QuandoEuCriarListagemDeIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            EntaoEuVisualizoListagemDeIncompativeisComSucesso();
            TelaCenarioIncompativel.ExcluirCenarioIncompativel("1");
        }

        [Given(@"que eu tenha um roteiro liberado")]
        public void DadoQueEuTenhaUmRoteiroLiberado()
        {
            TelaPlanejamentoGROT.Navegar();
            TelaPlanejamentoGROT.CriarFrenteEstudio(CalendarioHelper.ObterDataAtual(), "1000/014", "2");
            //TelaPlanejamentoGROT.CriarFrenteEstudioDiario(CalendarioHelper.ObterDataAtual(), "1000/015", "1");
            TelaPlanejamentoGROT.LiberarRoteiro();
        }

        [Given(@"que eu tenha um roteiro fechado")]
        public void DadoQueEuTenhaUmRoteiroFechado()
        {
            DadoQueEuTenhaUmRoteiroLiberado();
            TelaEspelhoGravacao.AlterarStatusPrimeiraCena("1000/014", "Gravada");
            TelaEspelhoGravacao.PreencherEspelhoGravacao();
        }

        [Given(@"que eu tenha excluido todos um item da nova lista de cenarios incompativeis")]
        public void DadoQueEuTenhaExcluidoTodosUmItemDaNovaListaDeCenariosIncompativeis()
        {
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.ClicarBtnNovaListaIncompatibilidade();
            TelaCenarioIncompativel.CriarSegundaListaCenarioIncompativel("INM LISTA", "PAÇO IMPERIAL - EST", "PAÇO IMPERIAL - EST", "CASA DE WOLFGANG", "SALA DE DOM PEDRO", "SALA DO BEIJA-MÃO", "QUARTO");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            EntaoEuVisualizoListagemDeIncompativeisComSucesso();
            TelaCenarioIncompativel.ExcluirCenarioIncompativel("3");
        }

        [When(@"eu crio uma lista de cenarios incompativeis com cenario associado ao roteiro")]
        public void QuandoEuCrioUmaListaDeCenariosIncompativeisComCenarioAssociadoAoRoteiro()
        {
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "PAÇO IMPERIAL - EST", "PAÇO IMPERIAL - EST", "SALA DE DOM PEDRO", "SALA DO BEIJA-MÃO");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [When(@"eu faco uma consulta por cenario incompativel no log")]
        public void QuandoEuFacoUmaConsultaPorCenarioIncompativelNoLog()
        {
            TelaConsultaDeLog.Navegar();
            TelaConsultaDeLog.FiltroConsultaLog("Cenário Incompatível", "0");
        }

        [When(@"eu criar listagem de incompativeis")]
		public void QuandoEuCriarListagemDeIncompativeis()
		{
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "PAÇO IMPERIAL - EST", "PAÇO IMPERIAL - EST", "SALA DE DOM PEDRO", "SALA DO BEIJA-MÃO");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [When(@"eu filtrar cenarios incompativeis")]
        public void QuandoEuFiltrarCenariosIncompativeis()
        {
            TelaCenarioIncompativel.FiltrarCenariosIncompativeis("PAÇO IMPERIAL - EST", "");
        }

        [When(@"eu filtrar cenarios incompativeis por ambiente")]
        public void QuandoEuFiltrarCenariosIncompativeisPorAmbiente()
        {
            TelaCenarioIncompativel.FiltrarCenariosIncompativeis("", "SALA DE DOM PEDRO");
        }

        [When(@"eu altere o cenario incompativel")]
        public void QuandoEuAltereOCenarioIncompativel()
        {
            QuandoEuCriarListagemDeIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("INM LISTA", "CASA DE WOLFGANG", "", "", "QUARTO", "", "", "1");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
            TelaCenarioIncompativel.FiltrarCenariosIncompativeis("PAÇO IMPERIAL - EST", "");
        }

        [When(@"eu excluo o cenario incompativel")]
        public void QuandoEuExcluoOCenarioIncompativel()
        {
            QuandoEuCriarListagemDeIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            TelaCenarioIncompativel.ApagarListaCenarioIncompativel("PAÇO IMPERIAL - EST", "");
        }

        [When(@"eu altere o nome da lista incompativel")]
        public void QuandoEuAltereONomeDaListaIncompativel()
        {
            QuandoEuCriarListagemDeIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("INM LISTA EDITADA", "", "", "", "", "", "", "");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
        }

        [When(@"criar uma nova listagem de cenarios incompativeis com o mesmo nome")]
        public void QuandoCriarUmaNovaListagemDeCenariosIncompativeisComOMesmoNome()
        {
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "", "", "", "");
        }

        [When(@"criar uma nova listagem de cenarios incompativeis com o ambiente já cadastrado em outra lista")]
        public void QuandoCriarUmaNovaListagemDeCenariosIncompativeisComOAmbienteJaCadastradoEmOutraLista()
        {
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA NOVA", "PAÇO IMPERIAL - EST", "PAÇO IMPERIAL - EST", "SALA DE DOM PEDRO", "SALA DO BEIJA-MÃO");
            TelaCenarioIncompativel.ClicarSalvarListaCenariosIncompativeis();
        }

        [When(@"eu criar duas listagem de cenarios incompativeis")]
        public void QuandoEuCriarDuasListagemDeCenariosIncompativeis()
        {
            QuandoEuCriarListagemDeIncompativeis();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA NOVA", "PAÇO IMPERIAL - EST", "CASA DE WOLFGANG", "CORREDOR", "QUARTO");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [When(@"renomear um listagem de cenarios incompativeis com o mesmo nome de outra existente")]
        public void QuandoRenomearUmListagemDeCenariosIncompativeisComOMesmoNomeDeOutraExistente()
        {
            TelaCenarioIncompativel.FiltrarCenariosIncompativeis("CASA DE WOLFGANG", "");
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("INM LISTA", "", "", "", "", "", "", "");
            TelaCenarioIncompativel.ClicarSalvarListaCenariosIncompativeis();
        }

        [When(@"criar uma nova listagem de cenarios incompativeis com o cenario já cadastrado em outra lista")]
        public void QuandoCriarUmaNovaListagemDeCenariosIncompativeisComOCenarioJaCadastradoEmOutraLista()
        {
            QuandoCriarUmaNovaListagemDeCenariosIncompativeisComOAmbienteJaCadastradoEmOutraLista();
        }

        [When(@"eu criar listagem de incompativeis preenchendo apenas uma linha de cenario/ambiente")]
        public void QuandoEuCriarListagemDeIncompativeisPreenchendoApenasUmaLinhaDeCenarioAmbiente()
        {
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "PAÇO IMPERIAL - EST", "", "SALA DE DOM PEDRO", "");
            TelaCenarioIncompativel.ClicarSalvarListaCenariosIncompativeis();
        }

        [When(@"eu clicar no menu principal")]
        public void QuandoEuClicarNoMenuPrincipal()
        {
            TelaCenarioIncompativel.ClicarMenuPrincipal();
        }

        [When(@"eu altero uma lista de cenarios incompativeis com cenario associado ao roteiro")]
        public void QuandoEuAlteroUmaListaDeCenariosIncompativeisComCenarioAssociadoAoRoteiro()
        {
            QuandoEuAltereOCenarioIncompativel();
        }

        [When(@"eu altero uma lista de cenarios incompativeis com cenario associado ao roteiro incluindo um novo cenario")]
        public void QuandoEuAlteroUmaListaDeCenariosIncompativeisComCenarioAssociadoAoRoteiroIncluindoUmNovoCenario()
        {
            QuandoEuCriarListagemDeIncompativeis();
            QuandoEuFiltrarCenariosIncompativeis();
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("INM LISTA", "CASA DE WOLFGANG", "", "PAÇO IMPERIAL - EST", "QUARTO", "", "SALA DE CHALAÇA", "1");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
            TelaCenarioIncompativel.FiltrarCenariosIncompativeis("PAÇO IMPERIAL - EST", "");
        }

        [When(@"eu criar listagem de incompativeis sem preencher os cenarios")]
        public void QuandoEuCriarListagemDeIncompativeisSemPreencherOsCenarios()
        {
            TelaCenarioIncompativel.Navegar();
            TelaCenarioIncompativel.CriarListaCenarioIncompativel("INM LISTA", "", "", "", "");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [Then(@"eu visualizo a mensagem de que nao e possivel realizar cadastro com menos de dois cenarios com sucesso")]
        public void EntaoEuVisualizoAMensagemDeQueNaoEPossivelRealizarCadastroComMenosDeDoisCenariosComSucesso()
        {
            TelaCenarioIncompativel.ValidarMensagem();
        }

        [Then(@"eu não visualizo a opcao de cenarios incompativeis")]
        public void EntaoEuNaoVisualizoAOpcaoDeCenariosIncompativeis()
        {
            TelaCenarioIncompativel.ValidarOpcaoCenariosIncompativeisInexistentes();
        }

        [Then(@"eu visualizo o alerta de que o cadastro nao e valido com apenas uma linha com sucesso")]
        public void EntaoEuVisualizoOAlertaDeQueOCadastroNaoEValidoComApenasUmaLinhaComSucesso()
        {
            TelaCenarioIncompativel.ValidarAlerta();
        }

        [Then(@"eu visualizo o alerta ao tentar editar de lista já existente com sucesso")]
        public void EntaoEuVisualizoOAlertaAoTentarEditarDeListaJaExistenteComSucesso()
        {
            TelaCenarioIncompativel.ValidarAlerta();
            TelaCenarioIncompativel.ApagarListaCenarioIncompativel("CASA DE WOLFGANG", "");
        }

        [Then(@"eu visualizo o alerta de cenarios/ambientes já cadastrados com sucesso")]
        public void EntaoEuVisualizoOAlertaDeCenariosAmbientesJaCadastradosComSucesso()
        {
            TelaCenarioIncompativel.ValidarCenarioAmbienteJaCadastrados("Existem Cenários/Ambientes já cadastrados em outras listagens, deseja continuar?");
        }

        [Then(@"eu visualizo o alerta lista já existente com sucesso")]
        public void EntaoEuVisualizoOAlertaListaJaExistenteComSucesso()
        {
            TelaCenarioIncompativel.ValidarListaJaCadastrada("Já existe lista de incompatibilidade com este nome.");
        }

        [Then(@"eu visualizo o nome da listagem de incompativeis alterada com sucesso")]
        public void EntaoEuVisualizoONomeDaListagemDeIncompativeisAlteradaComSucesso()
        {
            TelaCenarioIncompativel.VerificarNovaListaCriada("INM LISTA EDITADA");
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("INM LISTA", "", "", "", "", "", "", "");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [Then(@"eu nao visualizo o cenario de incompativel com sucesso")]
        public void EntaoEuNaoVisualizoOCenarioDeIncompativelComSucesso()
        {
            TelaCenarioIncompativel.VerificarNovaListaExcluida("INM LISTA");
        }

        [Then(@"eu visualizo listagem de incompativeis alterada com sucesso")]
        public void EntaoEuVisualizoListagemDeIncompativeisAlteradaComSucesso()
        {
            TelaCenarioIncompativel.VerificarNovaListaCriada("INM LISTA");
            TelaCenarioIncompativel.EditarListaCenarioIncompativel("", "PAÇO IMPERIAL - EST", "", "", "SALA DE DOM PEDRO", "", "", "1");
            TelaCenarioIncompativel.SalvarListaCenariosIncompativeis();
        }

        [Then(@"eu visualizo listagem de incompativeis com sucesso")]
		public void EntaoEuVisualizoListagemDeIncompativeisComSucesso()
		{
			TelaCenarioIncompativel.VerificarNovaListaCriada("INM LISTA");
		}

        [Then(@"eu visualizo a lista de cenarios incompativeis no log com sucesso")]
        public void EntaoEuVisualizoAListaDeCenariosIncompativeisNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA");
            TelaConsultaDeLog.ValidarBusca("Inclusão Cen. Incomp.");
        }

        [Then(@"eu visualizo as duas listas de cenarios incompativeis no log com sucesso")]
        public void EntaoEuVisualizoAsDuasListasDeCenariosIncompativeisNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA");
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA NOVA");
            TelaConsultaDeLog.ValidarBusca("Inclusão Cen. Incomp.");
            TelaCenarioIncompativel.ApagarListaCenarioIncompativel("CASA DE WOLFGANG", "");
        }

        [Then(@"eu visualizo a alteracao feita na lista de cenarios incompativeis no log com sucesso")]
        public void EntaoEuVisualizoAAlteracaoFeitaNaListaDeCenariosIncompativeisNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBusca("Cenario: PAÇO IMPERIAL - EST, Ambiente: SALA DO BEIJA-MÃO, Cenario: PAÇO IMPERIAL - EST, Ambiente: SALA DE DOM PEDRO");
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA");
            TelaConsultaDeLog.ValidarBusca("Inclusão Cen. Incomp.");
        }

        [Then(@"eu visualizo a lista de cenarios incompativeis excluida no log com sucesso")]
        public void EntaoEuVisualizoAListaDeCenariosIncompativeisExcluidaNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA");
            TelaConsultaDeLog.ValidarBusca("Exclusão Cen. Incomp.");
        }

        [Then(@"eu visualizo a lista de cenarios incompativeis associado a um roteiro no log com sucesso")]
        public void EntaoEuVisualizoAListaDeCenariosIncompativeisAssociadoAUmRoteiroNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA");
            TelaConsultaDeLog.ValidarBusca("Inclusão Cen. Incomp.");
        }

        [Then(@"eu visualizo o cenario excluido da lista de cenarios incompativeis no log com sucesso")]
        public void EntaoEuVisualizoOCenarioExcluidoDaListaDeCenariosIncompativeisNoLogComSucesso()
        {
            TelaConsultaDeLog.ValidarBuscaAssunto("INM LISTA");
            TelaConsultaDeLog.ValidarBusca("Exclusão Cen. Incomp.");
            TelaConsultaDeLog.ValidarBusca("Cenário: PAÇO IMPERIAL - EST excluído.");
        }

    }
}
