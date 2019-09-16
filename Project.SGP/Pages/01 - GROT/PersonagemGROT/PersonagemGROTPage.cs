using Framework.Core.PageObjects;
using System;
using Framework.Core.Interfaces;
using Framework.Core.Extensions.ElementExtensions;
using Framework.Core.Actions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.SGP.Pages
{
    public class PersonagemGROTPage : PageBase
    {
        private string PersonagemURL { get; }

        //Input
        private Element InputNomePersonagem { get; }
        private Element InputNomeAtorTOP { get; }
        private Element InputCargaHorariaMaximaDiaria {get;}
        private Element InputCargaHorariaMaximaSemanal { get; }
        private Element InputInterjornadaMinima { get; }
        private Element InputNroMaximoGravacaoDiasSemana { get; }
        private Element InputTempoPreparacao { get; }
        private Element InputObservacao { get; }
        private Element InputPersonagem { get; }
        private Element InputAtor { get; }
        private Element InputSenioridade { get; }

        //Others
        private Element SelectTipoPersonagem { get; }
        private Element SelectSenioridadePersonagem { get; }
        private Element DDListTipo { get; }
        private Element TextoTabelaNomePersonagem { get; }

        //Button
        private Element BtnNovoPersonagem { get; }
        private Element BtnCancelar { get; }
        private Element BtnSalvarPersonagem { get; }
        private Element BtnSalvarECriarNovoPersonagem { get; }
        private Element BtnFiltrarPersonagem { get; }
        private Element BtnEditarPersonagem { get; }
        private Element BtnExcluirPersonagem { get; }
        private Element BtnCena { get; }
        private Element BtnConfirmarExclusao { get; }
        private Element BtnAlterarPersonagem { get; }
        
        public PersonagemGROTPage(IBrowser browser, string personagemURL) : base(browser)
        {
            PersonagemURL = personagemURL;

            //Input
            InputNomePersonagem = Element.Id("txtNomePersonagem");
            InputNomeAtorTOP = Element.Id("txtNomeAtorTOP");
            InputCargaHorariaMaximaDiaria = Element.Id("txtCargaHorariaMaximaDiaria");
            InputCargaHorariaMaximaSemanal = Element.Id("txtCargaHorariaMaximaSemanal");
            InputInterjornadaMinima = Element.Id("txtInterjornadaMinima");
            InputNroMaximoGravacaoDiasSemana = Element.Id("txtNroMaximoGravacaoDiasSemana");
            InputTempoPreparacao = Element.Id("txtTempoPreparacao");
            InputObservacao = Element.Id("txtObservacao");
            InputPersonagem = Element.Id("inputPersonagem");
            InputAtor = Element.Id("inputAtor");
            InputSenioridade = Element.Css("div[id='selPrioridade_chosen'] input");

            //Button
            BtnNovoPersonagem = Element.Id("btnNovoPersonagem");
            BtnCancelar = Element.Css("button[data-bb-handler='b3']");
            BtnSalvarPersonagem = Element.Css("button[data-bb-handler='b1']");
            BtnSalvarECriarNovoPersonagem = Element.Css("button[data-bb-handler='b2']");
            BtnFiltrarPersonagem = Element.Id("btnSubmit");
            BtnEditarPersonagem = Element.Css("a[title='Editar personagem']");
            BtnExcluirPersonagem = Element.Css("a[title='Excluir personagem']");
            BtnCena = Element.Css("a[title='Ficha']");
            BtnConfirmarExclusao = Element.Css("button[data-bb-handler='confirm']");
            BtnAlterarPersonagem = Element.Css("button[data-bb-handler='1']");

            //Select
            SelectTipoPersonagem = Element.Id("selCargo_chosen");   
            SelectSenioridadePersonagem = Element.Id("selPrioridade_chosen");
            DDListTipo = Element.Id("ddlTipo");
            TextoTabelaNomePersonagem = Element.Css(".col-md-12 td a[class='btnEditar lnkNome']");
        }

        public override void Navegar()
        {
            Browser.Abrir(PersonagemURL);
            Thread.Sleep(2000);
        }
        
        public void CadastrarNovoPersonagem(string nomePersonagem, string nomeAtor, string senioridade,
                                            string tempoPreparacao, string cargaHorariaDiaria, string cargaHorariaSemanal,
                                            string interjornada, string NroMaximoDias)
        {
            if (nomePersonagem != "")
            {
                AutomatedActions.SendDataATM(Browser, InputNomePersonagem, nomePersonagem);
            }

            if (nomeAtor != "")
            {
                AutomatedActions.SendDataATM(Browser, InputNomeAtorTOP, nomeAtor);
            }

            if (senioridade != "")
            {
                MouseActions.ClickATM(Browser, SelectSenioridadePersonagem);
                AutomatedActions.SendDataEnterATM(Browser, InputSenioridade, senioridade);
            }

            if (tempoPreparacao != "")
            {
                AutomatedActions.SendDataATM(Browser, InputTempoPreparacao, tempoPreparacao);
            }

            if (cargaHorariaDiaria != "")
            {
                AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaximaDiaria, cargaHorariaDiaria);
            }

            if (cargaHorariaSemanal != "")
            {
                AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaximaSemanal, cargaHorariaSemanal);
            }

            if (interjornada != "")
            {
                AutomatedActions.SendDataATM(Browser, InputInterjornadaMinima, interjornada);
            }

            if (NroMaximoDias != "")
            {
                AutomatedActions.SendDataATM(Browser, InputNroMaximoGravacaoDiasSemana, NroMaximoDias);
            }

            Thread.Sleep(2000);
        }

        private void AlterarPersonagem(string tempoPreparacao, string cargaHorariaDiaria, 
                                      string cargaHorariaSemanal, string interjornada, string NroMaximoDias)
        {
            if (tempoPreparacao != "")
            {
                AutomatedActions.SendDataATM(Browser, InputTempoPreparacao, tempoPreparacao);
            }

            if (cargaHorariaDiaria != "")
            {
                AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaximaDiaria, cargaHorariaDiaria);
            }
            if (cargaHorariaSemanal != "")
            {
                AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaximaSemanal, cargaHorariaSemanal);
            }

            if (interjornada != "")
            {
                AutomatedActions.SendDataATM(Browser, InputInterjornadaMinima, interjornada);
            }

            if (NroMaximoDias != "")
            {
                AutomatedActions.SendDataATM(Browser, InputNroMaximoGravacaoDiasSemana, NroMaximoDias);
            }
 
            Thread.Sleep(2000);
        }

        public void GravarNovosCamposPersonagem(string senioridade, string tempoPreparacao, string cargaHorariaDiaria,
                                                 string cargaHorariaSemanal, string interjornada, string NroMaximoDias)
        {
            //AutomatedActions.SendDataATM(Browser, SelectSenioridadePersonagem, senioridade);
            AutomatedActions.SendDataATM(Browser, InputTempoPreparacao, tempoPreparacao);
            AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaximaDiaria, cargaHorariaDiaria);
            AutomatedActions.SendDataATM(Browser, InputCargaHorariaMaximaSemanal, cargaHorariaSemanal);
            AutomatedActions.SendDataATM(Browser, InputInterjornadaMinima, interjornada);
            AutomatedActions.SendDataATM(Browser, InputNroMaximoGravacaoDiasSemana, NroMaximoDias);
            KeyboardActions.Tab(Browser, InputNroMaximoGravacaoDiasSemana);
            
        }

        public void ValidarNovosCamposPersonagem(string tempoPreparacao, string cargaHorariaDiaria,
                                                 string cargaHorariaSemanal, string interjornada, string NroMaximoDias)
        {
            if (tempoPreparacao != "")
            {
                string getTempoPreparacao = InputTempoPreparacao.GetValorAtributo("value", Browser);
                Assert.AreEqual(getTempoPreparacao, tempoPreparacao);
            }

            if (cargaHorariaDiaria != "")
            {
                string getCargaHorarioDiaria = InputCargaHorariaMaximaDiaria.GetValorAtributo("value", Browser);
                Assert.AreEqual(getCargaHorarioDiaria, cargaHorariaDiaria);
            }

            if (cargaHorariaSemanal != "")
            {
                string getCargaHorariaSemanal = InputCargaHorariaMaximaSemanal.GetValorAtributo("value", Browser);
                Assert.AreEqual(getCargaHorariaSemanal, cargaHorariaSemanal);
            }

            if (interjornada != "")
            {
                string getInterjornada = InputInterjornadaMinima.GetValorAtributo("value", Browser);
                Assert.AreEqual(getInterjornada, interjornada);
            }
            
            if (NroMaximoDias != "")
            {
                string getNroMaximoDias = InputNroMaximoGravacaoDiasSemana.GetValorAtributo("value", Browser);
                Assert.AreEqual(getNroMaximoDias, NroMaximoDias);
            }
                
            Thread.Sleep(2000);
        }

        public void InputFiltrarPersonagem(string tipo, string ator, string personagem)
        {
            if (tipo != "")
            {
                DDListTipo.ClicarEsperarElemento(Browser);
                AutomatedActions.SendDataEnterATM(Browser, DDListTipo, tipo);
                Thread.Sleep(2000);
            }

            if (ator != "")
            {
                InputAtor.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputAtor, ator);
                Thread.Sleep(2000);
            }

            if (personagem != "")
            {
                InputPersonagem.EsperarElemento(Browser);
                AutomatedActions.SendDataATM(Browser, InputPersonagem, personagem);
                Thread.Sleep(2000);
            }
        }

        public void ClicarNovoPersonagem()
        {
            Thread.Sleep(2000);
            BtnNovoPersonagem.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void ClicarSalvarPersonagem()
        {
            BtnSalvarPersonagem.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void ClicarEditarPersonagem()
        {
            BtnEditarPersonagem.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void ClicarFiltrarPersonagem()
        {
            BtnFiltrarPersonagem.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }
                
        public void ClicarExcluirPersonagem()
        {
            BtnExcluirPersonagem.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void ClicarAlterarPersonagem()
        {
            BtnAlterarPersonagem.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void ClicarConfirmarPersonagem()
        {
            BtnConfirmarExclusao.ClicarEsperarElemento(Browser);
            Thread.Sleep(2000);
        }

        public void ValidarNomePersonagem(string nomePersonagem)
        {
            if (nomePersonagem != "")
            {
                TextoTabelaNomePersonagem.EsperarElemento(Browser);
                TextoTabelaNomePersonagem.IsElementVisible(Browser);
                string validacao = TextoTabelaNomePersonagem.GetTexto(Browser);
                Assert.AreEqual(validacao.ToUpper(), nomePersonagem.ToUpper());
            }   
        }

        public void ExcluirPersonagem(string nome)
        {
            InputFiltrarPersonagem("", "", nome);
            ClicarFiltrarPersonagem();
            ClicarExcluirPersonagem();
            ClicarConfirmarPersonagem();
        }
        
        public void ValidaParametrosPersonagem(string preparacaoPersonagem, string cargaHorMaxDiaria,
            string cargaHorMaxSemanal, string interjornadaElento)
        {
            if (preparacaoPersonagem != "")
            {
                InputTempoPreparacao.EsperarElemento(Browser);
                InputTempoPreparacao.IsElementVisible(Browser);
                string getText = InputTempoPreparacao.GetValorAtributo("value", Browser);
                Assert.AreEqual(getText, preparacaoPersonagem);
            }
            if (cargaHorMaxDiaria != "")
            {
                InputCargaHorariaMaximaDiaria.EsperarElemento(Browser);
                InputCargaHorariaMaximaDiaria.IsElementVisible(Browser);
                string getText = InputCargaHorariaMaximaDiaria.GetValorAtributo("value", Browser);
                Assert.AreEqual(getText, cargaHorMaxDiaria);
            }
            if (cargaHorMaxSemanal != "")
            {
                InputCargaHorariaMaximaSemanal.EsperarElemento(Browser);
                InputCargaHorariaMaximaSemanal.IsElementVisible(Browser);
                string getText = InputCargaHorariaMaximaSemanal.GetValorAtributo("value", Browser);
                Assert.AreEqual(getText, cargaHorMaxSemanal);
            }
            if (interjornadaElento != "")
            {
                InputInterjornadaMinima.EsperarElemento(Browser);
                InputInterjornadaMinima.IsElementVisible(Browser);
                string getText = InputInterjornadaMinima.GetValorAtributo("value", Browser);
                Assert.AreEqual(getText, interjornadaElento);
            }
        }

        public void CriarPersonagem(string nomePersonagem, string nomeAtor, string senioridade,
                                            string tempoPreparacao, string cargaHorariaDiaria, string cargaHorariaSemanal,
                                            string interjornada)
        {
            ClicarNovoPersonagem();
            CadastrarNovoPersonagem(nomePersonagem, nomeAtor, senioridade, tempoPreparacao, cargaHorariaDiaria, cargaHorariaSemanal, interjornada,"2");
            ClicarSalvarPersonagem();
        }
        public void AlterarPersonagem(string tipo, string ator, string personagem,
                                      string tempoPreparacao, string cargaHorariaDiaria,
                                      string cargaHorariaSemanal, string interjornada, string NroMaximoDias)
        {
            InputFiltrarPersonagem(tipo, ator, personagem);
            ClicarFiltrarPersonagem();
            ClicarEditarPersonagem();
            AlterarPersonagem(tempoPreparacao, cargaHorariaDiaria, cargaHorariaSemanal, interjornada, NroMaximoDias);
            ClicarAlterarPersonagem();
        }

        private void ListaInseridaSucesso()
        {
            var Mensagem = Element.Class("container");
            Mensagem.EsperarElemento(Browser);
            Mensagem.IsElementVisible(Browser);

            string texto = Mensagem.GetTexto(Browser);
            Assert.IsTrue(true, texto);
        }

    }
}
