#language: pt-BR
#Author: Lucas Fraga
#Date: 14/11/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 08.05 - Frequencia de elenco

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um capitulo com decupagem
	E que eu esteja com planejamento de roteiro realizado

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 01 - Incluir frequencia de elenco
	Dado que eu navegue para a Tela Frequencia de Elenco
	Quando incluir frequencia de elenco
	Então visualizo mensagem de frequencia de elenco salva com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Alterar frequencia de elenco
	Dado que eu navegue para a Tela Frequencia de Elenco
	Quando incluir frequencia de elenco
	E alterar frequencia de elenco
	Então visualizo mensagem de frequencia de elenco salva com sucesso
