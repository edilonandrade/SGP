using Framework.Core.Actions;
using Framework.Core.Interfaces;
using Framework.Core.PageObjects;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Helpers;
using System;
using System.Threading;

namespace Project.SGP.Pages
{
    public class IndisponibilidadeElencoPage : PageBase
    {
        private string IndisponibilidadeElencoUrl { get; }

        //Inputs
        public Element InputAtorFiltro { get; private set; }
        public Element InputDataInicioFiltro { get; private set; }
        public Element InputDataFinalFiltro { get; private set; }
        public Element InputIntervalo { get; private set; }
        public Element InputAtor { get; private set; }
        public Element InputDataInicio { get; private set; }
        public Element InputDataFinal { get; private set; }
        public Element InputPeriodoInicio { get; private set; }
        public Element InputPeriodoFinal { get; private set; }
        public Element InputJustificativa { get; private set; }

        //Buttons
        public Element BtnFiltrar { get; private set; }
        public Element BtnNovaIndisponibilidadeElenco { get; private set; }
        public Element BtnExibirIndisponibilidadeElenco { get; private set; }
        public Element BtnEditarIndisponibilidadeElenco { get; private set; }
        public Element BtnExcluirIndisponibilidadeElenco { get; private set; }
        public Element BtnSalvarIndisponibilidade { get; private set; }
        public Element BtnSalvarEdicaoIndisponibilidade { get; private set; }

        public IndisponibilidadeElencoPage(IBrowser browser,
            string indisponibilidadeElencoUrl) : base(browser)
        {
            IndisponibilidadeElencoUrl = indisponibilidadeElencoUrl;

            //Inputs
            InputAtorFiltro = Element.Css("input[id='AtorPupup']");
            InputDataInicioFiltro = Element.Css("input[id='DataInicioFiltro']");
            InputDataFinalFiltro = Element.Css("input[id='DataFimFiltro']");
            InputIntervalo = Element.Css("input[name='IntervaloFiltro']");
            InputAtor = Element.Css("input[id='AtorPupUp']");
            InputDataInicio = Element.Css("input[id='txtPeriodoInicial']");
            InputDataFinal = Element.Css("input[id='txtPeriodoFinal']");
            InputPeriodoInicio = Element.Css("input[id='dtHoraInicio_todos']");
            InputPeriodoFinal = Element.Css("input[id='dtHoraFim_todos']");
            InputJustificativa = Element.Css("input[id='Justificativa_todos']");


            //Buttons
            BtnFiltrar = Element.Css("button[id='filtrarbtn']");
            BtnNovaIndisponibilidadeElenco = Element.Css("button[id='NovoIndisponibilidadeElenco']");
            BtnExibirIndisponibilidadeElenco = Element.Css("a[class='icon-button icon-down collapse-down']");
            BtnEditarIndisponibilidadeElenco = Element.Css("a[class='icon-button icon-edit editar-IndisponibilidadeElenco']");
            BtnExcluirIndisponibilidadeElenco = Element.Css("a[class='icon-button icon-delete excluir-IndisponibilidadeElenco']");
            BtnSalvarIndisponibilidade = Element.Css("button[class='btn btn btn-default salvarIndisponibilidadeElenco']");
            BtnSalvarEdicaoIndisponibilidade = Element.Css("button[class='btn btn btn-primary editarIndisponibilidadeElenco']");
        }

        public override void Navegar()
        {
            Browser.Abrir(IndisponibilidadeElencoUrl);
            Browser.PageLoad();
        }

        public void CadastrarNovaIndisponibilidadeElenco(string Ator, string PeriodoInicio, string PeriodoFinal)
        {
            ClicarNovaIndisponibilidadeElenco();
            PreencherAtor(Ator);
            PreencherPeriodo();
            PreencherPeriodoDia(PeriodoInicio, PeriodoFinal);
            PreencherJustificativa();
        }

        public void EditarIndisponibilidadeElenco(string PeriodoInicio, string PeriodoFinal)
        {
            ClicarEditarIndisponibilidade();
            AlterarPeriodoDia(PeriodoInicio, PeriodoFinal);
        }

        private void ClicarEditarIndisponibilidade()
        {
            string btnClicarEdicao = "$('a[class=\"icon-button icon-edit editar-IndisponibilidadeElenco\"]').click();";
            JsActions.JavaScript(Browser, btnClicarEdicao);
        }

        public void SalvarEdicaoIndisponinilidadeElenco()
        {
            string btnSalvarEdicao = "$('button[class=\"btn btn btn-primary editarIndisponibilidadeElenco\"]').click();";
            JsActions.JavaScript(Browser, btnSalvarEdicao);
        }

        private void PreencherJustificativa()
        {
            InputJustificativa.EsperarElemento(Browser);
            InputJustificativa.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputJustificativa, "Teste INM");
        }

        private void PreencherAtor(string Ator)
        {
            if(Ator != "")
            {
                InputAtor.EsperarElemento(Browser);
                InputAtor.Esperar(Browser, 2000);
                InputAtor.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputAtor, Ator);
                InputAtor.Esperar(Browser, 1000);
                KeyboardActions.ArrowDonw(Browser, InputAtor);
                InputAtor.Esperar(Browser, 1000);
                KeyboardActions.Enter(Browser, InputAtor);
                InputAtor.Esperar(Browser, 1000);
                KeyboardActions.Tab(Browser, InputAtor);
            }
        }

        private void PreencherPeriodo()
        {
            InputDataInicio.EsperarElemento(Browser);
            InputDataInicio.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputDataInicio, CalendarioHelper.ObterDataAtual());
            KeyboardActions.Tab(Browser, InputDataInicio);

            InputDataFinal.EsperarElemento(Browser);
            InputDataFinal.IsElementVisible(Browser);
            AutomatedActions.SendDataATM(Browser, InputDataFinal, CalendarioHelper.ObterDataFutura(6));
            KeyboardActions.Tab(Browser, InputDataFinal);
        }

        private void AlterarPeriodoDia(string PeriodoInicio, string PeriodoFinal)
        {
            if (PeriodoInicio != "")
            {
                InputPeriodoInicio.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoInicio, PeriodoInicio);
                KeyboardActions.Tab(Browser, InputPeriodoInicio);
            }
            if (PeriodoFinal != "")
            {
                InputPeriodoFinal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoFinal, PeriodoFinal);
                KeyboardActions.Tab(Browser, InputPeriodoFinal);

                InputPeriodoInicio.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoInicio, PeriodoInicio);
                KeyboardActions.Tab(Browser, InputPeriodoInicio);
            }
        }

        private void PreencherPeriodoDia(string PeriodoInicio, string PeriodoFinal)
        {
            if(PeriodoInicio != "")
            {
                InputPeriodoInicio.EsperarElemento(Browser);
                InputPeriodoInicio.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoInicio, PeriodoInicio);
                KeyboardActions.Tab(Browser, InputPeriodoInicio);
            }
            if(PeriodoFinal != "")
            {
                InputPeriodoFinal.EsperarElemento(Browser);
                InputPeriodoFinal.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputPeriodoFinal, PeriodoFinal);
                KeyboardActions.Tab(Browser, InputPeriodoFinal);
            }
        }

        private void ClicarNovaIndisponibilidadeElenco()
        {
            BtnNovaIndisponibilidadeElenco.Esperar(Browser, 2000);
            BtnNovaIndisponibilidadeElenco.EsperarElemento(Browser);
            BtnNovaIndisponibilidadeElenco.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnNovaIndisponibilidadeElenco);
        }

        public void SalvarIndisponibilidade()
        {
            BtnSalvarIndisponibilidade.EsperarElemento(Browser);
            BtnSalvarIndisponibilidade.IsElementVisible(Browser);
            MouseActions.ClickATM(Browser, BtnSalvarIndisponibilidade);

            var alertaSucesso = Element.Css("div[class='container']");
            alertaSucesso.IsElementVisible(Browser);
            alertaSucesso.EsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void FiltrarIndisponibilidadeElenco(string Ator, string DataInicio, string DataFinal, string DiaSemana)
        {
            PreencherFiltroAtor(Ator);
            PreencherFiltroData(DataInicio, DataFinal);
            PreencherFiltroDiaSemana(DiaSemana);
            ClicarFiltrar();
        }

        private void PreencherFiltroAtor(string Ator)
        {
            if(Ator != "")
            {
                InputAtorFiltro.Esperar(Browser, 2000);
                InputAtorFiltro.EsperarElemento(Browser);
                InputAtorFiltro.IsClickable(Browser);
                if (InputAtorFiltro.IsElementVisible(Browser))
                {
                    AutomatedActions.SendDataATM(Browser, InputAtorFiltro, Ator);
                }
            }
        }

        private void PreencherFiltroData(string DataInicio, string DataFinal)
        {
            if(DataInicio != "")
            {
                InputDataInicioFiltro.EsperarElemento(Browser);
                InputDataInicioFiltro.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputDataInicioFiltro, CalendarioHelper.ObterDataAtual());
                KeyboardActions.Tab(Browser, InputDataInicioFiltro);
            }
            if(DataFinal != "")
            {
                InputIntervalo.EsperarElemento(Browser);
                InputIntervalo.IsElementVisible(Browser);
                JsActions.JavaScript(Browser, "$('input[id=\"IntervaloFiltro\"]').click();");

                InputDataFinalFiltro.EsperarElemento(Browser);
                InputDataFinalFiltro.IsElementVisible(Browser);
                AutomatedActions.SendDataATM(Browser, InputDataFinalFiltro, CalendarioHelper.ObterDataAtual());
                KeyboardActions.Tab(Browser, InputDataFinalFiltro);
            }            
        }
        
        private void PreencherFiltroDiaSemana(string DiaSemana)
        {
            if (DiaSemana != "")
            {
                var diaSemana = Element.Css("input[id='" + DiaSemana + "']");
                diaSemana.Esperar(Browser, 1000);
                diaSemana.IsElementVisible(Browser);

                string chckDiaSemana = "$('input[id=\"" + DiaSemana + "\"]').click();";
                JsActions.JavaScript(Browser, chckDiaSemana);
            }
        }

        private void ClicarFiltrar()
        {
            string btnSalvar = "$('button[id=\"filtrarbtn\"]').click();";
            JsActions.JavaScript(Browser, btnSalvar);
        }

        public void ExcluirIndisponibilidadeElenco()
        {
            if(BtnExcluirIndisponibilidadeElenco.IsElementVisible(Browser))
            {
                MouseActions.ClickATM(Browser, BtnExcluirIndisponibilidadeElenco);
            }

            var alertaText = Element.Xpath("//p[text()='A Indisponibilidade de elenco será excluída e não poderá ser recuperada. Tem certeza que deseja excluir esta Indisponibilidade de elenco?']");
            if(alertaText.IsElementVisible(Browser))
            {
                var btnOk = Element.Css("button[class='btn btn btn-primary exclusaoIndisponibilidadeElenco']");
                btnOk.IsElementVisible(Browser);
                MouseActions.ClickATM(Browser, btnOk);
            }

        }

        private void ValidarIndisponibilidade(string Valor)
        {
            if(Valor != "")
            {
                var valorPath = Element.Xpath("//tr[@class='periodoIndisponibilidadeElenco']/td[text()='" + Valor + "']");
                valorPath.IsElementVisible(Browser);
            }
        }

        private void ValidarElenco(string valor)
        {
            var valorPath = Element.Xpath("//strong[text()='" + valor + "']");
            valorPath.IsElementVisible(Browser);
        }

        private void ExibirIndisponibilidadeElenco()
        {
            Thread.Sleep(2000);
            string btnExiberDetalhes = "$('table[class=\"panel-header\"] a:nth-child(1)').click();";
            JsActions.JavaScript(Browser, btnExiberDetalhes);
        }

        public void ValidarNovaIndisponibilidade(string Ator, string DataInicio, string DataFinal, string DiaSemana, 
            string HoraInicio, string HoraFinal, string Justificativa)
        {
            ExibirIndisponibilidadeElenco();

            ValidarElenco(Ator);
            //ValidarIndisponibilidade(DataInicio);
            //ValidarIndisponibilidade(DataFinal);
            ValidarIndisponibilidade(DiaSemana);
            ValidarIndisponibilidade(HoraInicio);
            ValidarIndisponibilidade(HoraFinal);
            ValidarIndisponibilidade(Justificativa);
        }
    }
}
