#language: pt-BR
#Author: Rodrigo Magno
#Date: 16/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.01 - Histórico de planejamento

Narrativa:
	Eu como adminstrador do sistema
	Quero poder acessar o historico dos roteiros liberados
	Para ter acesso a todas as configurações do momento em que este histórico foi gravado

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas
	

@chrome @logout
Cenario: 01 - Visualizar campo histórico com GROT
	Quando eu acessar a tela de planejamento do GROT
	Entao eu visualizo o campo historico com sucesso

@chrome @logout
Cenario: 02 - Compartilhar roteiro e validar alteração no campo Histórico
	Dado que eu altero a data de exibicao do capitulo
	Quando criar um planejamento de roteiro GROT
	Entao eu visualizo o planejamento criado no campo de historico com sucesso

@chrome @logout
Cenario: 03 - Editar novo histórico de planejamento selecionado - negativo
	Quando eu acessar a tela de planejamento do GROT
	Entao eu visualizo o campo historico com sucesso

@chrome @logout
Cenario: 04 - Validar novo histórico de planejamento selecionado
	Quando eu acessar a tela de planejamento do GROT
	Entao eu visualizo o campo historico com sucesso
