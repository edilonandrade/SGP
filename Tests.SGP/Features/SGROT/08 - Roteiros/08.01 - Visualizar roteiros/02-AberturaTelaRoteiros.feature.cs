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
namespace Tests.SGP.Features.SGROT._08_Roteiros._08_01_VisualizarRoteiros
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("08.01 - Abrir espelho de gravação e planejamento através da tela de roteiro", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\r\nFora do esc" +
        "opo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\08 - Roteiros\\08.01 - Visualizar roteiros\\02-AberturaTelaRoteiros." +
        "feature", SourceLine=7)]
    public partial class _08_01_AbrirEspelhoDeGravacaoEPlanejamentoAtravesDaTelaDeRoteiroFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "02-AberturaTelaRoteiros.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "08.01 - Abrir espelho de gravação e planejamento através da tela de roteiro", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
                    "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\r\nFora do esc" +
                    "opo:\r\n\tTestes negativos", ProgrammingLanguage.CSharp, new string[] {
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
#line 22
 testRunner.When("eu criar um novo capitulo com decupagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Abrir espelho de gravacao atraves da tela de roteiro com sucesso", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=24)]
        public virtual void _04_AbrirEspelhoDeGravacaoAtravesDaTelaDeRoteiroComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Abrir espelho de gravacao atraves da tela de roteiro com sucesso", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 26
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 27
 testRunner.When("eu abrir espelho de gravacao pela tela roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 28
 testRunner.Then("visualizo tela espelho de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Abrir planejamento de roteiros atraves da tela de roteiro com sucesso", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=30)]
        public virtual void _05_AbrirPlanejamentoDeRoteirosAtravesDaTelaDeRoteiroComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Abrir planejamento de roteiros atraves da tela de roteiro com sucesso", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 31
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 32
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 33
 testRunner.When("eu abrir planejamento roteiro pela tela roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 34
 testRunner.Then("visualizo tela planejamento roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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