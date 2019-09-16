using Framework.Core.Actions;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.SGP.Helpers;
using System.Threading;
using System.Windows.Forms;

namespace Project.SGP.Pages
{
	public class DecupagemArtePage : PageBase
	{
		private string DecupagemArteUrl { get; }

		//DropList
		private Element DropListCapitulo { get; }
		private Element DropListCena { get; }

		//Input
		private Element InputCapitulo { get; }
		private Element IFrameDescricao { get; }
		private Element IFrameMaterialFixo { get; }
		private Element InputCapituloDe { get; }
		private Element InputCapituloAte { get; }

		//Button
		private Element BtnImagem { get; }
		private Element BtnIncluirImagem { get; }
		private Element BtnSelecionarImagem { get; }
		private Element BtnSalvarMateriais { get; }
		private Element BtnReaproveitarMateriaisOutraCena { get; }
		private Element BtnReaproveitarMaterial { get; }
		private Element BtnFiltrar { get; }
		private Element BtnEditarCenarioMaterialFixo { get; }
		private Element BtnEditarAmbienteMaterialFixo { get; }
		private Element BtnEditarPersonagemMaterialFixo { get; }
		private Element BtnSalvarMateriasFixos { get; }
		private Element BtnSalvarMateriasFixosPersonagem { get; }

		//Others
		private FotosPage TelaFotos { get; }
		private Element IconeMarcarCena { get; }
		private Element PopUpReaproveitarMateiriais {get; }
		private Element ChkReaproveitarMaterialCena { get; }
		private Element ChkReparoveitarMaterial { get; }
		private Element PopUpMateriaisFixos { get; }


		public DecupagemArtePage(IBrowser browser,
            string decupagemArteUrl) : base(browser)
        {
            DecupagemArteUrl = decupagemArteUrl;

			//DropList
			DropListCapitulo = Element.Id("jumpMenu_chzn");
			DropListCena = Element.Id("dropSelected");

			//Input
			InputCapitulo = Element.Css("#jumpMenu_chzn input");
			InputCapituloDe = Element.Id("tstCapituloDe");
			InputCapituloAte = Element.Id("tstCapituloAte");

			//Button
			BtnIncluirImagem = Element.Css("#confirmarUpload span");
			BtnSelecionarImagem = Element.Link("Selecionar Imagens");
			BtnImagem = Element.Css("#mat0 img[src='../Images/dImages_desab.png']");
			BtnSalvarMateriais = Element.Id("tstSalvarMateriais");
			BtnReaproveitarMateriaisOutraCena = Element.Css("#tstReaproveitarMaterial");
			BtnReaproveitarMaterial = Element.Css("a[class='tstLinkReaproveitarRecente']");
			BtnFiltrar = Element.Id("tstBtnFiltrarCenas");
			BtnEditarCenarioMaterialFixo = Element.Id("tstLinkMaterialFixoCenario");
			BtnEditarAmbienteMaterialFixo = Element.Id("tstLinkMaterialFixoAmbiente");
			BtnEditarPersonagemMaterialFixo = Element.Css("img[data-bind='click: PopupsVM.AbrirPopMateriaisFixosPersonagem']");
			BtnSalvarMateriasFixos = Element.Id("tstSalvarMaterialFixo");
			BtnSalvarMateriasFixosPersonagem = Element.Css("input[value='Salvar materiais']");

			//Others
			IconeMarcarCena = Element.Css("#tstListaMateriais .tstMarcacaoDeCena");
			PopUpReaproveitarMateiriais = Element.Id("popReaproveitarMaterial");
			ChkReaproveitarMaterialCena = Element.Css("img[class='tstCheckCenaConsulta']");
			ChkReparoveitarMaterial = Element.Css("input[class='checkMateriais']");
			PopUpMateriaisFixos = Element.Id("popMateriaisFixos");
			IFrameDescricao = Element.Css("iframe[name='tstmaterial0']");
			IFrameMaterialFixo = Element.Css("#telaMaterialFixo");


		}


		//-------------------METODOS-------------------\\

		//------------CRIAR DECUPAGEM ARTE---------------\\
		public void PreencherDecupagemArte(string numeroCapitulo, string numeroCena)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
			MarcarCena();
			PreencherDescricao();
		}

		public void PreencherReaproveitarDecupagemArte(string numeroCapitulo, string numeroCena)
		{
			SelecionarCapitulo(numeroCapitulo);
			SelecionarCena(numeroCena);
		}

		public void ReaproveitarMaterial()
		{
			ClicarBtnReaproveitarMaterial();
			SelecionarMaterial();
			ClicarBtnReaproveitarJS();
		}

		public void ClicarBtnIncluirImagem()
		{
			var EsperarMateriais = Element.Css("#tstListaMateriais");

			BtnIncluirImagem.EsperarElemento(Browser);
			if (BtnIncluirImagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnIncluirImagem);
			EsperarMateriais.EsperarElemento(Browser);
		}

		public void ClicarBtnImagem()
		{
			BtnImagem.SairIFrame(Browser);
			if (BtnImagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnImagem);
		}

		public void SalvarMateriais()
		{
			BtnSalvarMateriais.EsperarElemento(Browser);
			if (BtnSalvarMateriais.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarMateriais);
		}

		private void SelecionarCapitulo(string numeroCapitulo)
		{
			DropListCapitulo.EsperarElemento(Browser);
			if (DropListCapitulo.IsElementVisible(Browser))
				AutomatedActions.TypingListATM(Browser, DropListCapitulo, InputCapitulo, numeroCapitulo);
		}

		private void SelecionarCena(string numeroCena)
		{
			DropListCena.EsperarElemento(Browser);
			if (DropListCena.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, DropListCena);

			SelectCena(numeroCena);
		}

		private void SelectCena(string numeroCena)
		{
			var Select = Element.Xpath("//div[@id='dropItensMenu']//ul//li[text()='"+ numeroCena + "']");

			Select.EsperarElemento(Browser);
			if (Select.IsElementVisible(Browser))
				Select.IsClickable(Browser);
				MouseActions.ClickATM(Browser, Select);
		}

		private void MarcarCena()
		{
			IconeMarcarCena.EsperarElemento(Browser);
			if (IconeMarcarCena.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, IconeMarcarCena);
		}

		public void PreencherDescricao()
		{
			IFrameDescricao.EsperarIFrame(Browser);

			var Body = Element.Css("body");
			if(Body.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, Body, FakeHelpers.FullName());

			IFrameDescricao.SairIFrame(Browser);
		}

		//--------REAPROVEITAR MATERIAIS-------------\\

		public void ReaproveitarMateriaisOutraCena(string numeroCapitulo)
		{
			ClicarBtnReaproveitarMateriaisOutrasCenas();
			FiltrarReaproveitamentoMateriaisCena(numeroCapitulo);
			ClicarBtnFiltrar();

			SelecionarMaterialCena();
			ClicarBtnReaproveitarJS();
		}
		public void RemoverMaterial(string ordemTabela)
		{
			//Legenda: mat0, mat1, mat2....
			var TabelaOrdem = Element.Xpath("//tr[@id='" + ordemTabela + "']//img[@class='tstRemoverCategoria']");

			TabelaOrdem.EsperarElemento(Browser);
			if (TabelaOrdem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, TabelaOrdem);
		}

		private void ClicarBtnReaproveitarMaterial()
		{
			BtnReaproveitarMaterial.SairIFrame(Browser);
			BtnReaproveitarMaterial.EsperarElemento(Browser);
			if (BtnReaproveitarMaterial.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnReaproveitarMaterial);
		}

		private void FiltrarReaproveitamentoMateriaisCena(string numeroCapitulo)
		{
			PopUpReaproveitarMateiriais.EsperarElemento(Browser);
			if (PopUpReaproveitarMateiriais.IsElementVisible(Browser))
				AutomatedActions.SendDataATM(Browser, InputCapituloDe, numeroCapitulo);
				AutomatedActions.SendDataATM(Browser, InputCapituloAte, numeroCapitulo);
		}

		private void ClicarBtnFiltrar()
		{
			BtnFiltrar.EsperarElemento(Browser);
			if (BtnFiltrar.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnFiltrar);
		}

		private void ClicarBtnReaproveitarMateriaisOutrasCenas()
		{
			BtnReaproveitarMateriaisOutraCena.SairIFrame(Browser);
			BtnReaproveitarMateriaisOutraCena.EsperarElemento(Browser);
			if (BtnReaproveitarMateriaisOutraCena.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnReaproveitarMateriaisOutraCena);
		}

		private void SelecionarMaterial()
		{
			ChkReparoveitarMaterial.EsperarElemento(Browser);
			if (!ChkReparoveitarMaterial.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkReparoveitarMaterial);
		}

		private void SelecionarMaterialCena()
		{
			ChkReaproveitarMaterialCena.EsperarElemento(Browser);
			if (!ChkReaproveitarMaterialCena.IsElementSelected(Browser))
				MouseActions.ClickATM(Browser, ChkReaproveitarMaterialCena);
		}

		private void ClicarBtnReaproveitarJS()
		{
			JsActions.JavaScript(Browser, "$('.ui-dialog-buttonset button span:contains(Reaproveitar)').click();");
		}

		//----------REAPROVEITAR CENARIO E LOCACAO----------\\
		public void ClicarBtnEditarCenarioMateriaisFixos()
		{
			BtnEditarCenarioMaterialFixo.EsperarElemento(Browser);
			if (BtnEditarCenarioMaterialFixo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnEditarCenarioMaterialFixo);
		}

		public void ClicarBtnImagemMateriaisFixos()
		{
			IFrameMaterialFixo.SairIFrame(Browser);
			IFrameMaterialFixo.EsperarIFrame(Browser);

			if (BtnImagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnImagem);
		}

		public void SalvarMateriaisFixos()
		{
			IFrameMaterialFixo.SairIFrame(Browser);
			IFrameMaterialFixo.EsperarIFrame(Browser);
			if (BtnSalvarMateriasFixos.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarMateriasFixos);
		}

		public void SalvarMateriaisFixosPersonagem()
		{
			IFrameMaterialFixo.SairIFrame(Browser);
			IFrameMaterialFixo.EsperarIFrame(Browser);
			if (BtnSalvarMateriasFixosPersonagem.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnSalvarMateriasFixosPersonagem);
		}

		//----------REAPROVEITAR AMBIENTE----------\\
		public void ClicarBtnEditarAmbienteMateriaisFixos()
		{
			BtnEditarAmbienteMaterialFixo.EsperarElemento(Browser);
			if (BtnEditarAmbienteMaterialFixo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnEditarAmbienteMaterialFixo);
		}

		public void ClicarBtnEditarPersonagemMateriaisFixos()
		{
			BtnEditarPersonagemMaterialFixo.EsperarElemento(Browser);
			if (BtnEditarPersonagemMaterialFixo.IsElementVisible(Browser))
				MouseActions.ClickATM(Browser, BtnEditarPersonagemMaterialFixo);
		}

		public override void Navegar()
        {
			Browser.Abrir(DecupagemArteUrl);
			Browser.PageLoad();
		}


		//-------------------VERIFICACOES-------------------\\
		public void VerificarMateriaisDecupagemArte(string mensagem)
        {
			var Alerta = Element.Css(".toast-message");
			string validation = Alerta.GetTexto(Browser);

            Assert.AreEqual(validation, mensagem);
        }

		public void VerificarMateriaisReaproveitadosDecupagemArte()
		{
			var Tabela = Element.Css("#mat1");
			Tabela.EsperarElemento(Browser);
			Tabela.IsElementVisible(Browser);
		}
	}
}
