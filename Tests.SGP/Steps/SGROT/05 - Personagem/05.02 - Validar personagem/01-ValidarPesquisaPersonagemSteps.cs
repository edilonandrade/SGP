using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP
{
	[Binding]
	public sealed class ValidarPesquisaPersonagemSteps
	{
		public PersonagemPage TelaPersonagem { get; private set; }

		public ValidarPesquisaPersonagemSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaPersonagem = new PersonagemPage((IBrowser)browser,
				ConfigurationManager.AppSettings["PersonagemURL"]);
		}

		[When(@"eu pesquisar por ator")]
		public void QuandoEuPesquisarPorAtor()
		{
			TelaPersonagem.CriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Principal");
			TelaPersonagem.PesquisarPorAtor("LUCAS ALVES");
		}

		[Then(@"eu visualizo pesquisa por ator concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorAtorConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("LUCAS ALVES");
		}

		[When(@"eu pesquisar por personagem")]
		public void QuandoEuPesquisarPorPersonagem()
		{
			TelaPersonagem.CriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Principal");
			TelaPersonagem.PesquisarPorPersonagem("INM PERSONAGEM");
		}

		[Then(@"eu visualizo pesquisa por personagem concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorPersonagemConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo todos")]
		public void QuandoEuPesquisarPorTipoTodos()
		{
			TelaPersonagem.CriarNovoPersonagem("A INM PERSONAGEM", "LUCAS ALVES", "Principal");
			TelaPersonagem.PesquisarPorTipo("Todos");
		}

		[Then(@"eu visualizo pesquisa por tipo todos concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoTodosConcluidaComSucesso()
		{			
			TelaPersonagem.ValidarPesquisa("A INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo apoio figurante")]
		public void QuandoEuPesquisarPorTipoApoioFigurante()
		{
			TelaPersonagem.CriarNovoPersonagem("A INM PERSONAGEM", "LUCAS ALVES", "Apoio/Figurante");
			TelaPersonagem.PesquisarPorTipo("Apoio/Figurante");
		}

		[Then(@"eu visualizo pesquisa por tipo apoio figurante concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoApoioFiguranteConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("A INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo participacao")]
		public void QuandoEuPesquisarPorTipoParticipacao()
		{
			TelaPersonagem.CriarNovoPersonagem("A INM PERSONAGEM", "LUCAS ALVES", "Participação");
			TelaPersonagem.PesquisarPorTipo("Participação");
		}

		[Then(@"eu visualizo pesquisa por tipo participacao concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoParticipacaoConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("A INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo principal")]
		public void QuandoEuPesquisarPorTipoPrincipal()
		{
			TelaPersonagem.CriarNovoPersonagem("A INM PERSONAGEM", "LUCAS ALVES", "Principal");
			TelaPersonagem.PesquisarPorTipo("Principal");
		}

		[Then(@"eu visualizo pesquisa por tipo principal concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoPrincipalConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("A INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo animal")]
		public void QuandoEuPesquisarPorTipoAnimal()
		{
			TelaPersonagem.CriarNovoPersonagem("A INM PERSONAGEM", "LUCAS ALVES", "Animal");
			TelaPersonagem.PesquisarPorTipo("Animal");
		}

		[Then(@"eu visualizo pesquisa por tipo animal concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoAnimalConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("A INM PERSONAGEM");
		}

		[When(@"eu pesquisar por ator e personagem")]
		public void QuandoEuPesquisarPorAtorEPersonagem()
		{
			TelaPersonagem.CriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Principal");
			TelaPersonagem.PesquisarPorAtorePersonagem("LUCAS ALVES", "INM PERSONAGEM");
		}

		[Then(@"eu visualizo pesquisa por ator e personagem concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorAtorEPersonagemConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo principal e ator")]
		public void QuandoEuPesquisarPorTipoPrincipalEAtor()
		{
			TelaPersonagem.CriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Participação");
			TelaPersonagem.PesquisarPorTipoPersonagemeNomePersonagem("Participação", "INM PERSONAGEM");
		}

		[Then(@"eu visualizo pesquisa por tipo principal e ator concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoPrincipalEAtorConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("INM PERSONAGEM");
		}

		[When(@"eu pesquisar por tipo principal e personagem")]
		public void QuandoEuPesquisarPorTipoPrincipalEPersonagem()
		{
			TelaPersonagem.CriarNovoPersonagem("INM PERSONAGEM", "LUCAS ALVES", "Principal");
			TelaPersonagem.PesquisarPorTipoPersonagemeNomePersonagem("Principal", "INM PERSONAGEM");
		}

		[Then(@"eu visualizo pesquisa por tipo principal e personagem concluida com sucesso")]
		public void EntaoEuVisualizoPesquisaPorTipoPrincipalEPersonagemConcluidaComSucesso()
		{
			TelaPersonagem.ValidarPesquisa("INM PERSONAGEM");
		}

	}
}
