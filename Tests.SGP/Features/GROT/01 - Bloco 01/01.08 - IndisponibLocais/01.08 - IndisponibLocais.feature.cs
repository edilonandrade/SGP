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
namespace Tests.SGP.Features.GROT._01_Bloco01._01_08_IndisponibLocais
{
    using TechTalk.SpecFlow;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("01.08 - Indisponibilidade de local", new string[] {
            "kill_Driver"}, Description = "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero acessar a tela de Indisponib" +
        "ilidade de Locais\r\n\tPara ter controle da Indisponibilidade de Locais cadastrados" +
        " no sistema", SourceFile = "Features\\GROT\\01 - Bloco 01\\01.08 - IndisponibLocais\\01.08 - IndisponibLocais.fea" +
        "ture", SourceLine = 6)]
    public partial class _01_08_IndisponibilidadeDeLocalFeature
    {

        private TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "01.08 - IndisponibLocais.feature"
#line hidden

        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "01.08 - Indisponibilidade de local", "Narrativa:\r\n\tEu como adminstrador do sistema\r\n\tQuero acessar a tela de Indisponib" +
                    "ilidade de Locais\r\n\tPara ter controle da Indisponibilidade de Locais cadastrados" +
                    " no sistema", ProgrammingLanguage.CSharp, new string[] {
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
#line hidden
        }

        [TechTalk.SpecRun.ScenarioAttribute("01 - Filtrar Indisponibilidade de Local - Filtro por Local de Gravação", new string[] {
                "chrome",
                "excluir_IndisponibilidadeLocais",
                "logout"}, SourceLine = 20)]
        public virtual void _01_FiltrarIndisponibilidadeDeLocal_FiltroPorLocalDeGravacao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Filtrar Indisponibilidade de Local - Filtro por Local de Gravação", new string[] {
                        "chrome",
                        "excluir_IndisponibilidadeLocais",
                        "logout"});
#line 21
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 22
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 23
            testRunner.And("que eu tenho uma indisponibilidade de local cadastrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 24
            testRunner.When("eu faco busca por nome de local indisponivel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 25
            testRunner.Then("eu visualizo a indisponibilidade de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }

        [TechTalk.SpecRun.ScenarioAttribute("02 - Filtro por Dia da Semana", new string[] {
                "chrome",
                "excluir_IndisponibilidadeLocais",
                "logout"}, SourceLine = 27)]
        public virtual void _02_FiltroPorDiaDaSemana()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Filtro por Dia da Semana", new string[] {
                        "chrome",
                        "excluir_IndisponibilidadeLocais",
                        "logout"});
#line 28
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 29
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 30
            testRunner.And("que eu tenho uma indisponibilidade de local cadastrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 31
            testRunner.When("eu faco busca por dia da semana na tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 32
            testRunner.Then("eu visualizo a indisponibilidade de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }

        [TechTalk.SpecRun.ScenarioAttribute("03 - Filtro por Período", new string[] {
                "chrome",
                "excluir_IndisponibilidadeLocais",
                "logout"}, SourceLine = 34)]
        public virtual void _03_FiltroPorPeriodo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Filtro por Período", new string[] {
                        "chrome",
                        "excluir_IndisponibilidadeLocais",
                        "logout"});
#line 35
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 36
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 37
            testRunner.And("que eu tenho uma indisponibilidade de local cadastrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 38
            testRunner.When("eu faco busca por periodo na tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 39
            testRunner.Then("eu visualizo a indisponibilidade de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }

        [TechTalk.SpecRun.ScenarioAttribute("04 - Listagem de Indisponibilidade do Local", new string[] {
                "chrome",
                "excluir_IndisponibilidadeLocais",
                "logout"}, SourceLine = 41)]
        public virtual void _04_ListagemDeIndisponibilidadeDoLocal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Listagem de Indisponibilidade do Local", new string[] {
                        "chrome",
                        "excluir_IndisponibilidadeLocais",
                        "logout"});
#line 42
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 43
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 44
            testRunner.And("que eu tenho uma indisponibilidade de local cadastrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 45
            testRunner.When("eu faco busca por nome de local indisponivel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 46
            testRunner.Then("eu visualizo a indisponibilidade de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }

        [TechTalk.SpecRun.ScenarioAttribute("06 - Exclusão de Indisponibilidade de Local", new string[] {
                "chrome",
                "logout"}, SourceLine = 48)]
        public virtual void _06_ExclusaoDeIndisponibilidadeDeLocal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Exclusão de Indisponibilidade de Local", new string[] {
                        "chrome",
                        "logout"});
#line 49
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 50
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 51
            testRunner.And("que eu tenho uma indisponibilidade de local cadastrada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 52
            testRunner.When("eu excluo uma indisponibilidade de local", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 53
            testRunner.Then("eu nao visualizo mais a indisponibilidade de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }

        [TechTalk.SpecRun.ScenarioAttribute("07 - Criação de nova Indisponibilidade de Local", new string[] {
                "chrome",
                "excluir_IndisponibilidadeLocais",
                "logout"}, SourceLine = 55)]
        public virtual void _07_CriacaoDeNovaIndisponibilidadeDeLocal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Criação de nova Indisponibilidade de Local", new string[] {
                        "chrome",
                        "excluir_IndisponibilidadeLocais",
                        "logout"});
#line 56
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 57
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 58
            testRunner.When("eu cadastro uma nova indisponibilidade", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 59
            testRunner.Then("eu visualizo a indisponibilidade de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }

        [TechTalk.SpecRun.ScenarioAttribute("08 - Inclusão de Nova Indisponibilidade de Local-Salvar e Criar Nova Indisponibil" +
            "idade de Locais", new string[] {
                "chrome",
                "excluir_IndisponibilidadeLocais",
                "logout"}, SourceLine = 61)]
        public virtual void _08_InclusaoDeNovaIndisponibilidadeDeLocal_SalvarECriarNovaIndisponibilidadeDeLocais()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Inclusão de Nova Indisponibilidade de Local-Salvar e Criar Nova Indisponibil" +
                    "idade de Locais", new string[] {
                        "chrome",
                        "excluir_IndisponibilidadeLocais",
                        "logout"});
#line 62
            this.ScenarioSetup(scenarioInfo);
#line 14
            this.FeatureBackground();
#line 63
            testRunner.Given("que eu acesse a tela de indisponibilidade de locais", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 64
            testRunner.When("eu cadastro duas indisponibilidade de local", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 65
            testRunner.Then("eu visualizo as duas indisponibilidades de local cadastrada com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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
