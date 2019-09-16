#language: pt-BR
#Author: Rodrigo Magno
#Date: 02/03/2018
#Version: 0.10

@kill_Driver
Funcionalidade: 05.03 - Carregamento dados parametrizados

Narrativa:
	Eu como adminstrador do sistema
	Quero visualizar o carregamento dos dados parametrizados
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome @logout
Cenario: 01 - Carregamento de dados - Alterar e validar informações de uma frente
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu altero as informações da nova frente
	Entao eu visualizo as informacoes da nova frente alteradas com sucesso