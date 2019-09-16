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
namespace Tests.SGP.Features.GROT._03_Bloco03._05_FrenteDeGravacao
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("05.01 - Criação de nova frente de gravação", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar uma nova Frente de gra" +
        "vação\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados", SourceFile="Features\\GROT\\03 - Bloco 03\\05 - Frente de gravação\\05.01 - CriacaoNovaFrenteGrav" +
        "acao.feature", SourceLine=6)]
    public partial class _05_01_CriacaoDeNovaFrenteDeGravacaoFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "05.01 - CriacaoNovaFrenteGravacao.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "05.01 - Criação de nova frente de gravação", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar uma nova Frente de gra" +
                    "vação\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados", ProgrammingLanguage.CSharp, new string[] {
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
#line 14
#line 15
 testRunner.Given("que eu navegue para a Tela de Login do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 16
 testRunner.And("efetuar o login no sistema do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 17
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 18
 testRunner.And("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Criar nova frente de gravação com GROT com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=21)]
        public virtual void _01_CriarNovaFrenteDeGravacaoComGROTComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Criar nova frente de gravação com GROT com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 23
 testRunner.When("eu criar uma nova frente de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 24
 testRunner.Then("eu visualizo a frente de gravacao criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Criar nova frente de gravação tipo estudio com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=26)]
        public virtual void _03_CriarNovaFrenteDeGravacaoTipoEstudioComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Criar nova frente de gravação tipo estudio com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 28
 testRunner.When("eu criar uma nova frente de gravacao tipo estudio", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 29
 testRunner.Then("eu visualizo a frente de gravacao tipo estudio criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Criar nova frente de gravação selecionando segunda-feira no dia da semana co" +
            "m sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=31)]
        public virtual void _05_CriarNovaFrenteDeGravacaoSelecionandoSegunda_FeiraNoDiaDaSemanaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Criar nova frente de gravação selecionando segunda-feira no dia da semana co" +
                    "m sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 33
 testRunner.When("eu criar uma nova frente de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 34
 testRunner.And("seleciono apenas segunda-feira no dia da semana", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 35
 testRunner.Then("eu visualizo a frente de gravacao criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 - Criar nova frente de gravação selecionando mais de um dia da semana com suce" +
            "sso", new string[] {
                "chrome",
                "logout"}, SourceLine=37)]
        public virtual void _06_CriarNovaFrenteDeGravacaoSelecionandoMaisDeUmDiaDaSemanaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Criar nova frente de gravação selecionando mais de um dia da semana com suce" +
                    "sso", new string[] {
                        "chrome",
                        "logout"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 39
 testRunner.When("eu criar uma nova frente de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 40
 testRunner.And("seleciono mais de um dia da semana", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 41
 testRunner.Then("eu visualizo a frente de gravacao criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("07 - Criar nova frente de gravação selecionando todos os dias da semana com suces" +
            "so", new string[] {
                "chrome",
                "logout"}, SourceLine=43)]
        public virtual void _07_CriarNovaFrenteDeGravacaoSelecionandoTodosOsDiasDaSemanaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Criar nova frente de gravação selecionando todos os dias da semana com suces" +
                    "so", new string[] {
                        "chrome",
                        "logout"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 45
 testRunner.When("eu criar uma nova frente de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 46
 testRunner.And("seleciono todos os dias da semana", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 47
 testRunner.Then("eu visualizo a frente de gravacao criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("08 - Criar nova frente de gravação selecionando apenas um checkbox dias da semana" +
            " com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=49)]
        public virtual void _08_CriarNovaFrenteDeGravacaoSelecionandoApenasUmCheckboxDiasDaSemanaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Criar nova frente de gravação selecionando apenas um checkbox dias da semana" +
                    " com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 50
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 51
 testRunner.When("eu criar uma nova frente de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 52
 testRunner.And("seleciono apenas um checkbox dias da semana", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 53
 testRunner.Then("eu visualizo a nova frente de gravacao criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("09 - Criar nova frente de gravação selecionando todos os checkbox dias da semana " +
            "com sucesso", new string[] {
                "chrome",
                "logout"}, SourceLine=55)]
        public virtual void _09_CriarNovaFrenteDeGravacaoSelecionandoTodosOsCheckboxDiasDaSemanaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("09 - Criar nova frente de gravação selecionando todos os checkbox dias da semana " +
                    "com sucesso", new string[] {
                        "chrome",
                        "logout"});
#line 56
this.ScenarioSetup(scenarioInfo);
#line 14
this.FeatureBackground();
#line 57
 testRunner.When("eu criar uma nova frente de gravacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 58
 testRunner.And("seleciono todos os checkbox dias da semana", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 59
 testRunner.Then("eu visualizo a nova frente de gravacao criada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
