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
namespace Tests.SGP.Features.GROT._03_Bloco03._03_Planejamento
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("03.09 - Novos itens de cena", new string[] {
            "kill_Driver"}, SourceFile="Features\\GROT\\03 - Bloco 03\\03 - Planejamento\\03.09 - NovosItensDeCena.feature", SourceLine=6)]
    public partial class _03_09_NovosItensDeCenaFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "03.09 - NovosItensDeCena.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "03.09 - Novos itens de cena", null, ProgrammingLanguage.CSharp, new string[] {
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
#line 9
#line 10
 testRunner.Given("que eu navegue para a Tela de Login do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 11
 testRunner.And("efetuar o login no sistema do SGP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 12
 testRunner.And("que eu navegue para a Tela Home com a programacao selecionada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 13
 testRunner.And("que eu navegue para a Tela Capitulos e Cenas", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("01 - Exibir novos itens com GROT", new string[] {
                "chrome",
                "logout"}, SourceLine=16)]
        public virtual void _01_ExibirNovosItensComGROT()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01 - Exibir novos itens com GROT", new string[] {
                        "chrome",
                        "logout"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 18
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 19
 testRunner.When("eu clico em Editar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 20
 testRunner.Then("eu visualizo os novos itens de cena acima da listagem de cenas com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("02 - Informar horário de apenas uma refeição", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=22)]
        public virtual void _02_InformarHorarioDeApenasUmaRefeicao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02 - Informar horário de apenas uma refeição", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 24
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 25
 testRunner.When("eu crio um roteiro incluindo o novo icone de refeicao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 26
 testRunner.Then("eu visualizo as cenas de roteiro com horario de refeicao com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("03 - Informar tempo de preparação inicial para apenas um roteiro", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=28)]
        public virtual void _03_InformarTempoDePreparacaoInicialParaApenasUmRoteiro()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03 - Informar tempo de preparação inicial para apenas um roteiro", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 30
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 31
 testRunner.When("eu crio um roteiro informando o tempo de preparacao inicial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 32
 testRunner.Then("eu visualizo as cenas de roteiro com o tempo de preparacao inicial com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("04 - Validar aumento de 5 em 5 minutos - Preparação inicial", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=34)]
        public virtual void _04_ValidarAumentoDe5Em5Minutos_PreparacaoInicial()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04 - Validar aumento de 5 em 5 minutos - Preparação inicial", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 36
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 37
 testRunner.When("eu crio um roteiro aumentando o tempo de preparacao inicial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 38
 testRunner.Then("eu visualizo as cenas de roteiro com o tempo de preparacao inicial maior que o pa" +
                    "drao com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("05 - Validar subtração de 5 em 5 minutos - Preparação inicial", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=40)]
        public virtual void _05_ValidarSubtracaoDe5Em5Minutos_PreparacaoInicial()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05 - Validar subtração de 5 em 5 minutos - Preparação inicial", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 41
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 42
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 43
 testRunner.When("eu crio um roteiro diminuindo o tempo de preparacao inicial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 44
 testRunner.Then("eu visualizo as cenas de roteiro com o tempo de preparacao inicial menor que o pa" +
                    "drao com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("06 - Informar tempo de deslocamento para apenas um roteiro", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=46)]
        public virtual void _06_InformarTempoDeDeslocamentoParaApenasUmRoteiro()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06 - Informar tempo de deslocamento para apenas um roteiro", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 47
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 48
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 49
 testRunner.When("eu crio um roteiro informando o tempo de deslocamento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 50
 testRunner.Then("eu visualizo as cenas de roteiro com o tempo de deslocamento com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("07 - Validar aumento de 5 em 5 minutos - Deslocamento", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=52)]
        public virtual void _07_ValidarAumentoDe5Em5Minutos_Deslocamento()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07 - Validar aumento de 5 em 5 minutos - Deslocamento", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 53
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 54
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 55
 testRunner.When("eu crio um roteiro aumentando o tempo de deslocamento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 56
 testRunner.Then("eu visualizo as cenas de roteiro com o tempo de deslocamento maior que o padrao c" +
                    "om sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("08 - Validar subtração de 5 em 5 minutos - Deslocamento", new string[] {
                "chrome",
                "excluir_PlanejamentoRoteiro",
                "logout"}, SourceLine=58)]
        public virtual void _08_ValidarSubtracaoDe5Em5Minutos_Deslocamento()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08 - Validar subtração de 5 em 5 minutos - Deslocamento", new string[] {
                        "chrome",
                        "excluir_PlanejamentoRoteiro",
                        "logout"});
#line 59
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 60
 testRunner.Given("que eu navegue para a Tela de Planejamento de Roteiros GROT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 61
 testRunner.When("eu crio um roteiro diminuindo o tempo de deslocamento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 62
 testRunner.Then("eu visualizo as cenas de roteiro com o tempo de deslocamento menor que o padrao c" +
                    "om sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
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