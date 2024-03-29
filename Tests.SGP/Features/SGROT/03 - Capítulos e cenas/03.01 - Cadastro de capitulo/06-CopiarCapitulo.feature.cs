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
namespace Tests.SGP.Features.SGROT._03_CapitulosECenas._03_01_CadastroDeCapitulo
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("03.01 - Copiar capitulo", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\r\nFora do esc" +
        "opo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\03 - Capítulos e cenas\\03.01 - Cadastro de capitulo\\06-CopiarCapit" +
        "ulo.feature", SourceLine=7)]
    public partial class _03_01_CopiarCapituloFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "06-CopiarCapitulo.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "03.01 - Copiar capitulo", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
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
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("18 - Copiar capitulo com cenas decupadas", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=23)]
        public virtual void _18_CopiarCapituloComCenasDecupadas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("18 - Copiar capitulo com cenas decupadas", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 25
 testRunner.Given("que eu criar um capitulo com decupagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 26
 testRunner.When("copiar um capitulo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 27
 testRunner.Then("eu visualizo capitulo copiado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("19 - Copiar capitulo com cenas nao decupadas", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=30)]
        public virtual void _19_CopiarCapituloComCenasNaoDecupadas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("19 - Copiar capitulo com cenas nao decupadas", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 31
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 32
 testRunner.Given("que eu criar um novo capitulo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 33
 testRunner.When("copiar um capitulo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 34
 testRunner.Then("eu visualizo capitulo copiado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("20 - Copiar capitulo ja existente no destino", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=36)]
        public virtual void _20_CopiarCapituloJaExistenteNoDestino()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("20 - Copiar capitulo ja existente no destino", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 38
 testRunner.Given("que eu criar um capitulo com decupagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 39
 testRunner.And("que eu crie um capitulo em outra programacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 40
 testRunner.When("copiar um capitulo existente", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 41
 testRunner.Then("eu visualizo critica de capitulo copiado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
