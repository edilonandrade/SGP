#language: pt-BR
#Author: Lucas Fraga
#Date: 07/11/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 07.02 - Mover roteiro

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
	#Quando eu criar um novo capitulo com decupagem
#
#@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
#Cenario: 05 - Mover roteiro para outro dia
#	Dado que eu esteja com planejamento de roteiro realizado
#	Quando mover roteiro para outro dia
#	Então visualizo roteiro movido para outro dia com sucesso