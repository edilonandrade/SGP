#language: pt-BR
#Author: Leonardo Lima
#Date: 08/02/2018
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 01.01 - Listagem de alertas

Narrativa:
	Eu como Adminstrador do sistema
	Quero selecionar a programacao
	E Acessar gestao de alertas
	Para visualizar a listagem

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	
@chrome @logout
Cenario: 01 - Consultar a listagem de todos os alertas existentes com GROT 
	Quando eu navegar para a Tela Gestao de Alertas
	Entao eu visualizo a listagem com sucesso


