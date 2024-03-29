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
namespace Tests.SGP.Features.GROT._03_Bloco03._02_IndicadoresDoProduto
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("02.01 - Listar indicadores do produto", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero acessar os indicadores do pr" +
        "oduto\r\n\tPara ter controle dos indicadores do produto", SourceFile="Features\\GROT\\03 - Bloco 03\\02 - Indicadores do produto\\02.01 - IndicadoresProdut" +
        "o.feature", SourceLine=7)]
    public partial class _02_01_ListarIndicadoresDoProdutoFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "02.01 - IndicadoresProduto.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "02.01 - Listar indicadores do produto", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero acessar os indicadores do pr" +
                    "oduto\r\n\tPara ter controle dos indicadores do produto", ProgrammingLanguage.CSharp, new string[] {
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
#line 15
#line 16
 testRunner.Given("que eu navegue para a Tela de Login do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 17
 testRunner.And("efetuar o login no sistema do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 18
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 19
 testRunner.And("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Visualizar o campo produto por default com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=22)]
        public virtual void _01_VisualizarOCampoProdutoPorDefaultComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Visualizar o campo produto por default com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 15
this.FeatureBackground();
#line 24
 testRunner.When("eu acessar a lista de indicadores do produto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 25
 testRunner.Then("eu visualizo o campo produto por default com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Fechar tela de Indicadores do Produto com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=27)]
        public virtual void _02_FecharTelaDeIndicadoresDoProdutoComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Fechar tela de Indicadores do Produto com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 15
this.FeatureBackground();
#line 29
 testRunner.When("eu acessar a lista de indicadores do produto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 30
 testRunner.And("clicar em fechar a tela", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 31
 testRunner.Then("eu visualizo a tela de planejamento de roteiros com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Preencher novo campo produto com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=33)]
        public virtual void _03_PreencherNovoCampoProdutoComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Preencher novo campo produto com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 15
this.FeatureBackground();
#line 35
 testRunner.When("eu acessar a lista de indicadores do produto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 36
 testRunner.And("alterar o produto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 37
 testRunner.Then("eu visualizo o novo produto com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Selecionar mais de um produto com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=39)]
        public virtual void _04_SelecionarMaisDeUmProdutoComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Selecionar mais de um produto com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line 15
this.FeatureBackground();
#line 41
 testRunner.When("eu acessar a lista de indicadores do produto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 42
 testRunner.And("seleciono mais de um produto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 43
 testRunner.Then("eu visualizo o novo produto com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
