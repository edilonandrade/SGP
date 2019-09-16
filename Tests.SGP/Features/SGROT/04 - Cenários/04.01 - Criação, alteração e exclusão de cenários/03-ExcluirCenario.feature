#language: pt-BR
#Author: Lucas Fraga
#Date: 01/09/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 04.01 - Excluir cenario

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Cenário no SGP
	Para ter controle dos Cenários que serão manipulados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome
Cenario: 14 - Excluir cenario
	Dado que eu criar um novo cenario
	Quando eu excluir cenario
	Entao visualizo cenario excluido com sucesso