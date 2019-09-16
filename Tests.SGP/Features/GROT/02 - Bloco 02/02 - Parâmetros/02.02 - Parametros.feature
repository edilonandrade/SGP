#language: pt-BR
#Author: Rodrigo Magno
#Date: 20/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 02.02 - Parâmetros

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar a tela de Parâmetros da Produção
	Para ter controle dos Parâmetros da Produção

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas


@chrome @alterar_ParametroProducao @logout
Cenario: 01 - Alteração de um Parâmetro
	Dado que eu acesse a tela de parametros de producao
	Quando eu alterar um parametro
	Entao eu visualizo a alteracao de um parametro alterado no log com sucesso

	
@chrome @logout
Cenario: 02 - Alteração de mais de um Parâmetro
	Dado que eu acesse a tela de parametros de producao
	Quando eu alterar mais de um parametro
	Entao eu visualizo a alteracao de mais de um parametro alterado no log com sucesso