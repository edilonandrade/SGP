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
namespace Tests.SGP.Features.SGROT._07_PlanejamentoDeRoteiro._07_03_GeracaoDeRelatorio
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("07.03 - Geracao de relatorio", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizadoss\r\n\t\r\nFora de e" +
        "scopo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\07 - Planejamento de roteiro\\07.03 - Geração de relatório\\01-GeraR" +
        "elat.feature", SourceLine=7)]
    public partial class _07_03_GeracaoDeRelatorioFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-GeraRelat.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "07.03 - Geracao de relatorio", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
                    "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizadoss\r\n\t\r\nFora de e" +
                    "scopo:\r\n\tTestes negativos", ProgrammingLanguage.CSharp, new string[] {
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Gerar relatorio de cenas", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=24)]
        public virtual void _01_GerarRelatorioDeCenas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Gerar relatorio de cenas", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 26
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 27
 testRunner.When("gerar relatorio de cenas", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 28
 testRunner.Then("visualizo o relatorio com a cena a roteirizar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Gerar relatorio de capa da semana de gravacao", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=30)]
        public virtual void _02_GerarRelatorioDeCapaDaSemanaDeGravacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Gerar relatorio de capa da semana de gravacao", new string[] {
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
 testRunner.When("gerar o relatorio selecionando a Capa de Gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 34
 testRunner.Then("visualizo o relatorio com a Capa da semana de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Gerar relatorio basico - Roteiro de gravacao", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=36)]
        public virtual void _03_GerarRelatorioBasico_RoteiroDeGravacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Gerar relatorio basico - Roteiro de gravacao", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 38
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 39
 testRunner.When("gerar relatorio basico roteiro de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 40
 testRunner.Then("visualizo o relatorio basico roteiro de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Gerar relatorio de roupas", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=42)]
        public virtual void _04_GerarRelatorioDeRoupas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Gerar relatorio de roupas", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 44
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 45
 testRunner.When("gerar relatorio de Roupas", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 46
 testRunner.Then("visualizo o relatorio de roupas", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Gerar relatorio de recursos dos roteiros", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=48)]
        public virtual void _05_GerarRelatorioDeRecursosDosRoteiros()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Gerar relatorio de recursos dos roteiros", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 50
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 51
 testRunner.When("gerar relatorio de recursos de roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 52
 testRunner.Then("visualizo o de recursos dos roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 - Gerar relatorio - Todas as opcoes", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=54)]
        public virtual void _06_GerarRelatorio_TodasAsOpcoes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Gerar relatorio - Todas as opcoes", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 56
 testRunner.Given("que eu esteja com planejamento de roteiro realizado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 57
 testRunner.When("gerar relatorio - Todas as opcoes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 58
 testRunner.Then("visualizo o relatorio com todas as opcoes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
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
