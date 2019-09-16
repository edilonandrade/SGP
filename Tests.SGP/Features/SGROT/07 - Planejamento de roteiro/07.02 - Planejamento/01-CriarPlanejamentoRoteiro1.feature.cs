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
namespace Tests.SGP.Features.SGROT._07_PlanejamentoDeRoteiro._07_02_Planejamento
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("07.02 - Criar planejamento de roteiro", new string[] {
            "kill_Driver"}, Description="Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\t\r\nFora de es" +
        "copo:\r\n\tTestes negativos", SourceFile="Features\\SGROT\\07 - Planejamento de roteiro\\07.02 - Planejamento\\01-CriarPlanejam" +
        "entoRoteiro.feature", SourceLine=7)]
    public partial class _07_02_CriarPlanejamentoDeRoteiroFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "01-CriarPlanejamentoRoteiro.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "07.02 - Criar planejamento de roteiro", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
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
 testRunner.And("efetuar o login no sistema do SGP com perfil sem GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 21
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 22
 testRunner.When("eu criar um novo capitulo com decupagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Criar planejamento de roteiro com uma frente de trabalho", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=24)]
        public virtual void _01_CriarPlanejamentoDeRoteiroComUmaFrenteDeTrabalho()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Criar planejamento de roteiro com uma frente de trabalho", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 27
 testRunner.When("criar um planejamento de roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 28
 testRunner.Then("visualizo roteiro criado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Criar planejamento de roteiro com duas frentes de trabalho", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=30)]
        public virtual void _02_CriarPlanejamentoDeRoteiroComDuasFrentesDeTrabalho()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Criar planejamento de roteiro com duas frentes de trabalho", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 31
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 32
 testRunner.Given("que eu decupe uma cena do tipo estudio", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 33
 testRunner.When("criar um planejamento de roteiro com duas frentes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 34
 testRunner.Then("visualizo as duas frentes criadas com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Compartilhar planejamento nao liberado", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=36)]
        public virtual void _03_CompartilharPlanejamentoNaoLiberado()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Compartilhar planejamento nao liberado", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 38
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 39
 testRunner.When("que eu esteja com planejamento de roteiro nao liberado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 40
 testRunner.Then("visualizo roteiro nao liberado om sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Incluir recursos de roteiro", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=42)]
        public virtual void _04_IncluirRecursosDeRoteiro()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Incluir recursos de roteiro", new string[] {
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
 testRunner.When("eu incluir recurso de roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 46
 testRunner.Then("visualizo recurso de roteiro com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("07 - Incluir frequencia de elenco", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=48)]
        public virtual void _07_IncluirFrequenciaDeElenco()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Incluir frequencia de elenco", new string[] {
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
 testRunner.When("eu incluir frequencia de elenco", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 52
 testRunner.Then("visualizo frequencia de elenco com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("10 - Salvar planejamento de roteiro", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=54)]
        public virtual void _10_SalvarPlanejamentoDeRoteiro()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10 - Salvar planejamento de roteiro", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 57
 testRunner.When("criar um planejamento de roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 58
 testRunner.And("salvar versao de planejamento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 59
 testRunner.Then("visualizo roteiro criado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("11 - Compartilhar roteiro - não liberado e depois libera-lo", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "excluir_NovoCapitulo",
                "logout"}, SourceLine=61)]
        public virtual void _11_CompartilharRoteiro_NaoLiberadoEDepoisLibera_Lo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("11 - Compartilhar roteiro - não liberado e depois libera-lo", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "excluir_NovoCapitulo",
                        "logout"});
#line 62
this.ScenarioSetup(scenarioInfo);
#line 18
this.FeatureBackground();
#line 63
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 64
 testRunner.When("que eu esteja com planejamento de roteiro nao liberado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 65
 testRunner.And("eu libero o roteiro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 66
 testRunner.Then("visualizo roteiro criado com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
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