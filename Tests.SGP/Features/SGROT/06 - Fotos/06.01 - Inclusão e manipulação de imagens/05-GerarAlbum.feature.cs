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
namespace Tests.SGP.Features.SGROT._06_Fotos._06_01_InclusaoEManipulacaoDeImagens
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("06.01 - Gerar album", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\t\r\nFora de es" +
        "copo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\06 - Fotos\\06.01 - Inclusão e manipulação de imagens\\05-GerarAlbum" +
        ".feature", SourceLine=7)]
    public partial class _06_01_GerarAlbumFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "05-GerarAlbum.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "06.01 - Gerar album", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
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
        
        [TechTalk.SpecRun.ScenarioAttribute("08 - Gerar album com 2 imagens por pagina com sucesso", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=24)]
        public virtual void _08_GerarAlbumCom2ImagensPorPaginaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Gerar album com 2 imagens por pagina com sucesso", new string[] {
                        "chrome",
                        "excluir_Imagens",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 26
 testRunner.Given("que eu esteja com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 27
 testRunner.And("que eu navegue para a Tela de Fotos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 28
 testRunner.When("incluir quatro imagens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 29
 testRunner.And("gerar album duas por pagina", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 30
 testRunner.Then("visualizo album gerado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("09 - Gerar album com 4 imagens por pagina com sucesso", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=32)]
        public virtual void _09_GerarAlbumCom4ImagensPorPaginaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("09 - Gerar album com 4 imagens por pagina com sucesso", new string[] {
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
 testRunner.When("incluir quatro imagens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 37
 testRunner.And("gerar album quatro por pagina", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 38
 testRunner.Then("visualizo album gerado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("10 - Gerar album com 9 imagens por pagina com sucesso", new string[] {
                "chrome",
                "excluir_Imagens",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=40)]
        public virtual void _10_GerarAlbumCom9ImagensPorPaginaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10 - Gerar album com 9 imagens por pagina com sucesso", new string[] {
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
 testRunner.When("incluir dez imagens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 45
 testRunner.And("gerar album nove por pagina", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 46
 testRunner.Then("visualizo album gerado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
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
