#language: pt-BR
#Author: Rodrigo Magno
#Date: 31/01/2018
#Version: 0.01
#Scenarios: 04

@kill_Driver
Funcionalidade: 02.01 - Listar indicadores do produto

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar os indicadores do produto
	Para ter controle dos indicadores do produto

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela de Planejamento de Roteiros GROT


@chrome @logout
Cenario: 01 - Visualizar o campo produto por default com sucesso
	Quando eu acessar a lista de indicadores do produto
	Entao eu visualizo o campo produto por default com sucesso
	
@chrome @logout
Cenario: 02 - Fechar tela de Indicadores do Produto com sucesso
	Quando eu acessar a lista de indicadores do produto
	E clicar em fechar a tela
	Entao eu visualizo a tela de planejamento de roteiros com sucesso
	
@chrome @logout
Cenario: 03 - Preencher novo campo produto com sucesso
	Quando eu acessar a lista de indicadores do produto
	E alterar o produto
	Entao eu visualizo o novo produto com sucesso
		
@chrome @logout
Cenario: 04 - Selecionar mais de um produto com sucesso
	Quando eu acessar a lista de indicadores do produto
	E seleciono mais de um produto
	Entao eu visualizo o novo produto com sucesso
