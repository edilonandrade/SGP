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
namespace Tests.SGP.Features.SGROT._05_Personagem._05_01_CriacaoEdicaoEExclusaoDePersonagensEIndisponibilidadeDoAtor
{
    using TechTalk.SpecFlow;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("05.01 - Editar indisponibilidade", new string[] {
            "kill_Driver"}, Description = "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
        "P\r\n\tPara ter controle dos Capítulos e Cenas que serão roterizados\r\n\r\nFora do esc" +
        "opo:\r\n\tTestes negativos", SourceFile = "Features\\SGROT\\05 - Personagem\\05.01 - Criação, edição e exclusão de personagens " +
        "e indisponibilidade do ator\\05-EditarNovaIndisponibi.feature", SourceLine = 7)]
    public partial class _05_01_EditarIndisponibilidadeFeature
    {

        private TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "05-EditarNovaIndisponibi.feature"
#line hidden

        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "05.01 - Editar indisponibilidade", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero criar um novo Capítulo no SG" +
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
            testRunner.When("eu criar um novo personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 23
            testRunner.And("eu criar uma nova indisponibilidade", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }

        [TechTalk.SpecRun.ScenarioAttribute("06 - Editar nova indisponibilidade", new string[] {
                "chrome",
                "excluir_NovoPersonagem"}, SourceLine = 25)]
        public virtual void _06_EditarNovaIndisponibilidade()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Editar nova indisponibilidade", new string[] {
                        "chrome",
                        "excluir_NovoPersonagem"});
#line 26
            this.ScenarioSetup(scenarioInfo);
#line 18
            this.FeatureBackground();
#line 27
            testRunner.Given("que eu navegue para a Tela Personagem", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 28
            testRunner.When("eu editar nova indisponibilidade", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 29
            testRunner.Then("eu visualizo nova indisponibilidade editada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
