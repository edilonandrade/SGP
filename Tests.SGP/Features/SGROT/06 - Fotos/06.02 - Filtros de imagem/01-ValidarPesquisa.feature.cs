﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.SGP.Features.SGROT._06_Fotos._06_02_FiltrosDeImagem
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("06.02 - Validar pesquisa de imagem", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\t\r\nFora de es" +
        "copo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\06 - Fotos\\06.02 - Filtros de imagem\\01-ValidarPesquisa.feature", SourceLine=7)]
    public partial class _06_02_ValidarPesquisaDeImagemFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-ValidarPesquisa.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "06.02 - Validar pesquisa de imagem", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
                    "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\t\r\nFora de es" +
                    "copo:\r\n\tTestes negativos", ProgrammingLanguage.CSharp, new string[] {
                        "kill_Driver"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 18
#line 19
 testRunner.Given("que eu navegue para a Tela de Login do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 20
 testRunner.And("efetuar o login no sistema do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 21
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 22
 testRunner.When("eu criar um novo capitulo com decupagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Validar pesquisa de fotos por Inserido Por", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=32)]
        public virtual void _02_ValidarPesquisaDeFotosPorInseridoPor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Validar pesquisa de fotos por Inserido Por", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 34
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 35
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 36
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 37
 testRunner.And("filtrar por Inserido Por", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 38
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Validar pesquisa de fotos por Tema", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=40)]
        public virtual void _03_ValidarPesquisaDeFotosPorTema()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Validar pesquisa de fotos por Tema", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 41
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 42
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 43
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 44
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 45
 testRunner.And("filtrar por Tema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 46
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Validar pesquisa de fotos por Personagem", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=48)]
        public virtual void _04_ValidarPesquisaDeFotosPorPersonagem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Validar pesquisa de fotos por Personagem", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 50
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 51
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 52
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 53
 testRunner.And("filtrar por Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 54
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Validar pesquisa de fotos por Roupa e Bloco", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=56)]
        public virtual void _05_ValidarPesquisaDeFotosPorRoupaEBloco()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Validar pesquisa de fotos por Roupa e Bloco", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 58
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 59
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 60
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 61
 testRunner.And("filtrar por Roupa e Bloco", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 62
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 - Validar pesquisa de fotos por Cenarios", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=64)]
        public virtual void _06_ValidarPesquisaDeFotosPorCenarios()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Validar pesquisa de fotos por Cenarios", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 65
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 66
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 67
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 68
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 69
 testRunner.And("filtrar por Cenarios", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 70
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("07 - Validar pesquisa de fotos por Capitulo ou Pacote", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=72)]
        public virtual void _07_ValidarPesquisaDeFotosPorCapituloOuPacote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Validar pesquisa de fotos por Capitulo ou Pacote", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 73
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 74
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 75
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 76
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 77
 testRunner.And("filtrar por Capitulo ou Pacote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 78
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("08 - Validar pesquisa de fotos por Classificacao", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=80)]
        public virtual void _08_ValidarPesquisaDeFotosPorClassificacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Validar pesquisa de fotos por Classificacao", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 81
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 82
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 83
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 84
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 85
 testRunner.And("filtrar por Classificacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 86
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("09 - Validar pesquisa de fotos por Roteiro", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=88)]
        public virtual void _09_ValidarPesquisaDeFotosPorRoteiro()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("09 - Validar pesquisa de fotos por Roteiro", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 89
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 90
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 91
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 92
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 93
 testRunner.And("filtrar por Roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 94
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("10 - Validar pesquisa de fotos por Intervalo de Capitulo ou Pacote", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=96)]
        public virtual void _10_ValidarPesquisaDeFotosPorIntervaloDeCapituloOuPacote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10 - Validar pesquisa de fotos por Intervalo de Capitulo ou Pacote", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 97
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 98
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 99
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 100
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 101
 testRunner.And("filtrar por Intervalo de Capitulo ou Pacote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 102
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("11 - Validar pesquisa de fotos por Data de Gravacao", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=104)]
        public virtual void _11_ValidarPesquisaDeFotosPorDataDeGravacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("11 - Validar pesquisa de fotos por Data de Gravacao", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 105
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 106
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 107
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 108
 testRunner.When("incluir uma imagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 109
 testRunner.And("filtrar por Data de Gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 110
 testRunner.Then("visualizo a imagem filtrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
