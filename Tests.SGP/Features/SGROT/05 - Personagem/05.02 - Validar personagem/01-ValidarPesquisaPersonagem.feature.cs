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
namespace Tests.SGP.Features.SGROT._05_Personagem._05_02_ValidarPersonagem
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("05.02 - Validar pesquisa personagem", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\r\nFora do esc" +
        "opo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\05 - Personagem\\05.02 - Validar personagem\\01-ValidarPesquisaPerso" +
        "nagem.feature", SourceLine=7)]
    public partial class _05_02_ValidarPesquisaPersonagemFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-ValidarPesquisaPersonagem.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "05.02 - Validar pesquisa personagem", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
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
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Validar pesquisa por ator", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=23)]
        public virtual void _01_ValidarPesquisaPorAtor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Validar pesquisa por ator", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 25
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 26
 testRunner.When("eu pesquisar por ator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 27
 testRunner.Then("eu visualizo pesquisa por ator concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Validar pesquisa por personagem", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=29)]
        public virtual void _02_ValidarPesquisaPorPersonagem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Validar pesquisa por personagem", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 31
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 32
 testRunner.When("eu pesquisar por personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 33
 testRunner.Then("eu visualizo pesquisa por personagem concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Validar pesquisa por tipo todos", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=35)]
        public virtual void _03_ValidarPesquisaPorTipoTodos()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Validar pesquisa por tipo todos", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 37
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 38
 testRunner.When("eu pesquisar por tipo todos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 39
 testRunner.Then("eu visualizo pesquisa por tipo todos concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Validar pesquisa por tipo apoio figurante", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=41)]
        public virtual void _04_ValidarPesquisaPorTipoApoioFigurante()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Validar pesquisa por tipo apoio figurante", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 43
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 44
 testRunner.When("eu pesquisar por tipo apoio figurante", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 45
 testRunner.Then("eu visualizo pesquisa por tipo apoio figurante concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Validar pesquisa por tipo participacao", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=47)]
        public virtual void _05_ValidarPesquisaPorTipoParticipacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Validar pesquisa por tipo participacao", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 48
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 49
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 50
 testRunner.When("eu pesquisar por tipo participacao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 51
 testRunner.Then("eu visualizo pesquisa por tipo participacao concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 - Validar pesquisa por tipo principal", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=53)]
        public virtual void _06_ValidarPesquisaPorTipoPrincipal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Validar pesquisa por tipo principal", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 54
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 55
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 56
 testRunner.When("eu pesquisar por tipo principal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 57
 testRunner.Then("eu visualizo pesquisa por tipo principal concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("07 - Validar pesquisa por tipo animal", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=59)]
        public virtual void _07_ValidarPesquisaPorTipoAnimal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Validar pesquisa por tipo animal", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 61
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 62
 testRunner.When("eu pesquisar por tipo animal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 63
 testRunner.Then("eu visualizo pesquisa por tipo animal concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("08 - Validar pesquisa por combinacao de ator e personagem", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=65)]
        public virtual void _08_ValidarPesquisaPorCombinacaoDeAtorEPersonagem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Validar pesquisa por combinacao de ator e personagem", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 66
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 67
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 68
 testRunner.When("eu pesquisar por ator e personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 69
 testRunner.Then("eu visualizo pesquisa por ator e personagem concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("09 - Validar pesquisa por combinacao de tipo principal e ator", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=71)]
        public virtual void _09_ValidarPesquisaPorCombinacaoDeTipoPrincipalEAtor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("09 - Validar pesquisa por combinacao de tipo principal e ator", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 73
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 74
 testRunner.When("eu pesquisar por tipo principal e ator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 75
 testRunner.Then("eu visualizo pesquisa por tipo principal e ator concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("10 - Validar pesquisa por combinacao de tipo principal e personagem", new string[] {
                "chrome",
                "excluir_NovoPersonagem",
                "logout"}, SourceLine=77)]
        public virtual void _10_ValidarPesquisaPorCombinacaoDeTipoPrincipalEPersonagem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10 - Validar pesquisa por combinacao de tipo principal e personagem", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem",
                        "logout"});
#line 78
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 79
 testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 80
 testRunner.When("eu pesquisar por tipo principal e personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 81
 testRunner.Then("eu visualizo pesquisa por tipo principal e personagem concluida com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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