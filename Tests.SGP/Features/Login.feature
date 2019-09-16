#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.20

@kill_Driver
Funcionalidade: Login

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

	Contexto:
		aplicação SGP funcional

@chrome @logout	
Cenario: Login com sucesso
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	Entao eu visualizo a tela inicial
	# url: https://sistemas.h.tvglobo.com.br/SGP/Home