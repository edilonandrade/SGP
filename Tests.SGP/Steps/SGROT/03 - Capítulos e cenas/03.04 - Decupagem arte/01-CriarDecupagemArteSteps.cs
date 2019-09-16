using Framework.Core.Interfaces;
using Project.SGP.Pages;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.SGP.Steps
{
	[Binding]
	public sealed class CriarDecupagemArteSteps
	{
		public FotosPage TelaFotos { get; private set; }
		public DecupagemArtePage TelaDecupagemArte { get; private set; }

		public CriarDecupagemArteSteps()
		{
			var browser = ScenarioContext.Current["browser"];
			TelaDecupagemArte = new DecupagemArtePage((IBrowser)browser,
				ConfigurationManager.AppSettings["DecupagemArteURL"]);

			TelaFotos = new FotosPage((IBrowser)browser,
				ConfigurationManager.AppSettings["FotosURL"],
				ConfigurationManager.AppSettings["RoteiroURL"]);
		}

		[Given(@"que eu navegue para a Tela de Decupagem Arte")]
		public void DadoQueEuNavegueParaATelaDeDecupagemArte()
		{
			TelaDecupagemArte.Navegar();
		}

		[When(@"eu criar uma nova decupagem de arte")]
		public void QuandoEuCriarUmaNovaDecupagemDeArte()
		{
			TelaDecupagemArte.PreencherDecupagemArte("0400", "001");
			TelaDecupagemArte.ClicarBtnImagem();
			TelaFotos.IncluirUmaFotoDecupagemArte("INMETRICS PERSONAGEM", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "Teste");
			TelaDecupagemArte.ClicarBtnIncluirImagem();
			TelaDecupagemArte.SalvarMateriais();
		}

		[When(@"reaproveitar material de outra cena")]
		public void QuandoReaproveitarMaterialDeOutraCena()
		{
			TelaDecupagemArte.PreencherReaproveitarDecupagemArte("0400", "002");
			TelaDecupagemArte.ReaproveitarMateriaisOutraCena("0400");
			TelaDecupagemArte.RemoverMaterial("mat1"); //id: mat0, mat1, mat2 (na ordem da tabela).
			TelaDecupagemArte.SalvarMateriais();
		}

		[When(@"reaproveitar material")]
		public void QuandoReaproveitarMaterial()
		{
			TelaDecupagemArte.PreencherReaproveitarDecupagemArte("0400", "002");
			TelaDecupagemArte.ReaproveitarMaterial();
			TelaDecupagemArte.RemoverMaterial("mat1");
			TelaDecupagemArte.SalvarMateriais();
		}

		[When(@"adicionar material fixo de cenario")]
		public void QuandoAdicionarMaterialFixoDeCenario()
		{
			TelaDecupagemArte.PreencherReaproveitarDecupagemArte("0400", "002");
			TelaDecupagemArte.ClicarBtnEditarCenarioMateriaisFixos();

			TelaDecupagemArte.ClicarBtnImagemMateriaisFixos();
			TelaFotos.IncluirUmaFotoDecupagemArte("INMETRICS PERSONAGEM", "INMETRICS ESTUDIO", "INMETRICS AMBIENTE", "Teste");
			TelaDecupagemArte.ClicarBtnIncluirImagem();
			TelaDecupagemArte.SalvarMateriaisFixos();
		}

		[When(@"adicionar material fixo de ambiente")]
		public void QuandoAdicionarMaterialFixoDeAmbiente()
		{
			TelaDecupagemArte.PreencherReaproveitarDecupagemArte("0400", "002");
			TelaDecupagemArte.ClicarBtnEditarAmbienteMateriaisFixos();
			TelaDecupagemArte.SalvarMateriaisFixos();
		}

		[When(@"adicionar material fixo de personagem")]
		public void QuandoAdicionarMaterialFixoDePersonagem()
		{
			TelaDecupagemArte.PreencherReaproveitarDecupagemArte("0400", "002");
			TelaDecupagemArte.ClicarBtnEditarPersonagemMateriaisFixos();
			TelaDecupagemArte.SalvarMateriaisFixosPersonagem();
		}


		[Then(@"eu visualizo material reaproveitado com sucesso")]
		public void EntaoEuVisualizoMaterialReaproveitadoComSucesso()
		{
			TelaDecupagemArte.VerificarMateriaisReaproveitadosDecupagemArte();
		}


		[Then(@"eu visualizo mensagem de decupagem de arte com sucesso")]
		public void EntaoEuVisualizoMensagemDeDecupagemDeArteComSucesso()
		{
			TelaDecupagemArte.VerificarMateriaisDecupagemArte("Fotos foram salvas com sucesso");
		}

		[Then(@"eu visualizo material de outra cena reaproveitado com sucesso")]
		public void EntaoEuVisualizoMaterialDeOutraCenaReaproveitadoComSucesso()
		{
			TelaDecupagemArte.VerificarMateriaisReaproveitadosDecupagemArte();
		}

		[Then(@"eu visualizo material salvo com sucesso")]
		public void EntaoEuVisualizoMaterialSalvoComSucesso()
		{
			TelaDecupagemArte.VerificarMateriaisDecupagemArte("Lista de Materiais Salva com sucesso");
		}
	}
}
