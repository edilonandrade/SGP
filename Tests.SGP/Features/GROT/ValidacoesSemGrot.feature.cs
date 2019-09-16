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
namespace Tests.SGP.Features.GROT
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Validações sem perfil GROT", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero acessar o sistema com um per" +
        "fil sem GROT\r\n\tPara validar que eu não visualizo os campos do perfil GROT", SourceFile="Features\\GROT\\ValidacoesSemGrot.feature", SourceLine=5)]
    public partial class ValidacoesSemPerfilGROTFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ValidacoesSemGrot.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Validações sem perfil GROT", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero acessar o sistema com um per" +
                    "fil sem GROT\r\n\tPara validar que eu não visualizo os campos do perfil GROT", ProgrammingLanguage.CSharp, new string[] {
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
#line 13
#line 14
 testRunner.Given("que eu navegue para a Tela de Login do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 15
 testRunner.And("efetuar o login no sistema do SGP com perfil sem GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 16
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 17
 testRunner.And("que eu criar um capitulo com decupagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Decupagem continuidade - Validação do novo campo para usuário sem perfil GRO" +
            "T", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=19)]
        public virtual void _01_DecupagemContinuidade_ValidacaoDoNovoCampoParaUsuarioSemPerfilGROT()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Decupagem continuidade - Validação do novo campo para usuário sem perfil GRO" +
                    "T", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 13
this.FeatureBackground();
#line 21
 testRunner.Given("que eu navegue para a Tela de Decupagem Continuidade", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 22
 testRunner.Then("eu nao visualizo o campo tempo preparacao com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("27 - Tela Cenários Incompatíveis para usuário sem perfil do GROT no SEG", new string[] {
                "chrome",
                "logout"}, SourceLine=24)]
        public virtual void _27_TelaCenariosIncompativeisParaUsuarioSemPerfilDoGROTNoSEG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("27 - Tela Cenários Incompatíveis para usuário sem perfil do GROT no SEG", new string[] {
                        "chrome",
                        "logout"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 13
this.FeatureBackground();
#line 26
 testRunner.When("eu clicar no menu principal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 27
 testRunner.Then("eu não visualizo a opcao de cenarios incompativeis", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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