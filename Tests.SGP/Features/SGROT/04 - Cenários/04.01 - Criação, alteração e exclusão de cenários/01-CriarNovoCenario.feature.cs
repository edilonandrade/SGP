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
namespace Tests.SGP.Features.SGROT._04_Cenarios._04_01_CriacaoAlteracaoEExclusaoDeCenarios
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("04.01 - Criar novo cenario", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Cenário no SGP" +
        "\r\n\tPara ter controle dos Cenários que serão manipulados\r\n\t\r\nFora de escopo:\r\n\tTe" +
        "stes negativos", SourceFile="Features\\SGROT\\04 - Cenários\\04.01 - Criação, alteração e exclusão de cenários\\01" +
        "-CriarNovoCenario.feature", SourceLine=7)]
    public partial class _04_01_CriarNovoCenarioFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-CriarNovoCenario.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "04.01 - Criar novo cenario", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Cenário no SGP" +
                    "\r\n\tPara ter controle dos Cenários que serão manipulados\r\n\t\r\nFora de escopo:\r\n\tTe" +
                    "stes negativos", ProgrammingLanguage.CSharp, new string[] {
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
 testRunner.And("efetuar o login no sistema do SGP com perfil sem GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 21
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Criar novo cenario - Tipo cenario", new string[] {
                "chrome",
                "excluir_NovoCenario",
                "logout"}, SourceLine=24)]
        public virtual void _01_CriarNovoCenario_TipoCenario()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Criar novo cenario - Tipo cenario", new string[] {
                        "chrome",
                        "excluir_NovoCenario",
                        "logout"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 26
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 27
 testRunner.When("criar um novo cenario - tipo cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 28
 testRunner.And("adicionar novo ambiente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 29
 testRunner.Then("visualizo cenario salvo com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Criar novo cenario - Duas criações seguidas", new string[] {
                "chrome",
                "excluir_NovoCenario",
                "logout"}, SourceLine=31)]
        public virtual void _02_CriarNovoCenario_DuasCriacoesSeguidas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Criar novo cenario - Duas criações seguidas", new string[] {
                        "chrome",
                        "excluir_NovoCenario",
                        "logout"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 33
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 34
 testRunner.When("criar um novo cenario e salvar para criar outro cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 35
 testRunner.Then("visualizo cenarios sao incluidos com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Criar novo cenario - Associar ao PDS", new string[] {
                "chrome",
                "excluir_NovoCenario",
                "logout"}, SourceLine=37)]
        public virtual void _03_CriarNovoCenario_AssociarAoPDS()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Criar novo cenario - Associar ao PDS", new string[] {
                        "chrome",
                        "excluir_NovoCenario",
                        "logout"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 39
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 40
 testRunner.When("criar um novo cenario - tipo cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 41
 testRunner.And("associar ao PDS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 42
 testRunner.And("adicionar novo ambiente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 43
 testRunner.Then("visualizo cenario salvo com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Criar novo cenario - Tipo locacao", new string[] {
                "chrome",
                "excluir_NovoCenario",
                "logout"}, SourceLine=45)]
        public virtual void _04_CriarNovoCenario_TipoLocacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Criar novo cenario - Tipo locacao", new string[] {
                        "chrome",
                        "excluir_NovoCenario",
                        "logout"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 47
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 48
 testRunner.When("criar um novo cenario - tipo locacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 49
 testRunner.And("adicionar novo ambiente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 50
 testRunner.Then("visualizo cenario salvo com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Criar novo cenario - Tipo cidade cenográfica", new string[] {
                "chrome",
                "excluir_NovoCenario",
                "logout"}, SourceLine=52)]
        public virtual void _05_CriarNovoCenario_TipoCidadeCenografica()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Criar novo cenario - Tipo cidade cenográfica", new string[] {
                        "chrome",
                        "excluir_NovoCenario",
                        "logout"});
#line 53
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 54
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 55
 testRunner.When("criar um novo cenario - tipo cidade cenografica", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 56
 testRunner.And("adicionar novo ambiente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 57
 testRunner.Then("visualizo cenario salvo com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("15 - Criar novo cenario - Associar ao mesmo PDS", new string[] {
                "chrome",
                "logout"}, SourceLine=59)]
        public virtual void _15_CriarNovoCenario_AssociarAoMesmoPDS()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("15 - Criar novo cenario - Associar ao mesmo PDS", new string[] {
                        "chrome",
                        "logout"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 61
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 62
 testRunner.When("criar um novo cenario - tipo cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 63
 testRunner.And("associar ao PDS existente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 64
 testRunner.Then("visualizo critica do PDS com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
