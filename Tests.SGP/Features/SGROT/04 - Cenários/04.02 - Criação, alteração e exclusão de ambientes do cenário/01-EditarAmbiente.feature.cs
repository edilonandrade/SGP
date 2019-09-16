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
namespace Tests.SGP.Features.SGROT._04_Cenarios._04_02_CriacaoAlteracaoEExclusaoDeAmbientesDoCenario
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("04.02 - Editar ambiente", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Cenário no SGP" +
        "\r\n\tPara ter controle dos Cenários que serão manipulados\r\n\t\r\nFora de escopo:\r\n\tTe" +
        "stes negativos", SourceFile="Features\\SGROT\\04 - Cenários\\04.02 - Criação, alteração e exclusão de ambientes d" +
        "o cenário\\01-EditarAmbiente.feature", SourceLine=7)]
    public partial class _04_02_EditarAmbienteFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-EditarAmbiente.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "04.02 - Editar ambiente", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Cenário no SGP" +
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
#line 22
 testRunner.And("que eu criar um novo capitulo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 23
 testRunner.And("que eu criar um novo cenario com ambiente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Editar ambiente", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "excluir_NovoCenario"}, SourceLine=25)]
        public virtual void _02_EditarAmbiente()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Editar ambiente", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "excluir_NovoCenario"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 27
 testRunner.Given("que eu navegue para a Tela de Cenario", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 28
 testRunner.When("editar o ambiente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 29
 testRunner.Then("visualizo ambiente editado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
