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
namespace Tests.SGP.Features.SGROT._07_PlanejamentoDeRoteiro._07_05_FiltrosDeCenasRoteirizaveis
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("07.05 - Filtros de cenas roteirizáveis", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero filtrar as cenas roteirizáve" +
        "is no SGP\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\t\r\nFo" +
        "ra de escopo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\07 - Planejamento de roteiro\\07.05 - Filtros de cenas roteirizávei" +
        "s\\01-FiltroCenas.feature", SourceLine=7)]
    public partial class _07_05_FiltrosDeCenasRoteirizaveisFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-FiltroCenas.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "07.05 - Filtros de cenas roteirizáveis", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero filtrar as cenas roteirizáve" +
                    "is no SGP\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\t\r\nFo" +
                    "ra de escopo:\r\n\tTestes negativos", ProgrammingLanguage.CSharp, new string[] {
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Filtrar cenas disponiveis para roteirizacao por tipo", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=24)]
        public virtual void _01_FiltrarCenasDisponiveisParaRoteirizacaoPorTipo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Filtrar cenas disponiveis para roteirizacao por tipo", new string[] {
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
 testRunner.When("filtrar cenas disponiveis para roteirizacao por tipo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 28
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Filtrar cenas disponiveis para roteirizacao por  cenario ou locacao", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=30)]
        public virtual void _02_FiltrarCenasDisponiveisParaRoteirizacaoPorCenarioOuLocacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Filtrar cenas disponiveis para roteirizacao por  cenario ou locacao", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 31
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 32
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 33
 testRunner.When("filtrar cenas disponiveis para roteirizacao por  cenario ou locacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 34
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Filtrar cenas disponiveis para roteirizacao por personagem", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=36)]
        public virtual void _03_FiltrarCenasDisponiveisParaRoteirizacaoPorPersonagem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Filtrar cenas disponiveis para roteirizacao por personagem", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 38
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 39
 testRunner.When("filtrar cenas disponiveis para roteirizacao por personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 40
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Filtrar cenas disponiveis para roteirizacao por status", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=42)]
        public virtual void _04_FiltrarCenasDisponiveisParaRoteirizacaoPorStatus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Filtrar cenas disponiveis para roteirizacao por status", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 44
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 45
 testRunner.When("filtrar cenas disponiveis para roteirizacao por status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 46
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Filtrar cenas disponiveis para roteirizacao por classificacoes", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=48)]
        public virtual void _05_FiltrarCenasDisponiveisParaRoteirizacaoPorClassificacoes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Filtrar cenas disponiveis para roteirizacao por classificacoes", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 50
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 51
 testRunner.When("filtrar cenas disponiveis para roteirizacao por classificacoes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 52
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 - Filtrar cenas disponiveis para roteirizacao por categorias", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=54)]
        public virtual void _06_FiltrarCenasDisponiveisParaRoteirizacaoPorCategorias()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Filtrar cenas disponiveis para roteirizacao por categorias", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 56
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 57
 testRunner.When("filtrar cenas disponiveis para roteirizacao por categorias", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 58
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("07 - Filtrar cenas disponiveis para roteirizacao por periodo do dia", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=60)]
        public virtual void _07_FiltrarCenasDisponiveisParaRoteirizacaoPorPeriodoDoDia()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Filtrar cenas disponiveis para roteirizacao por periodo do dia", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 61
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 62
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 63
 testRunner.When("filtrar cenas disponiveis para roteirizacao por periodo do dia", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 64
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("08 - Filtrar cenas disponiveis para roteirizacao por intervalo de capitulo", new string[] {
                "chrome",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=66)]
        public virtual void _08_FiltrarCenasDisponiveisParaRoteirizacaoPorIntervaloDeCapitulo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Filtrar cenas disponiveis para roteirizacao por intervalo de capitulo", new string[] {
                        "chrome",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 67
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 68
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 69
 testRunner.When("filtrar cenas disponiveis para roteirizacao por intervalo de capitulo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 70
 testRunner.Then("visualizo filtro escolhido com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
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
