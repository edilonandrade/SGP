#language: pt-BR
#Author: Rodrigo Magno
#Date: 31/01/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.11 - Acionamento novas telas

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar as novas telas pelo GROT
	Para ter controle dos Capítulos e Cenas que serão roterizados

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela de Planejamento de Roteiros GROT


@chrome @logout
Cenario: 01 - Acionar nova tela de indisponibilidade de elenco GROT
	Quando eu acessar a nova tela de indisponibilidade de elenco
	Entao eu visualizo a nova tela de indisponibilidade de elenco com sucesso

@chrome @logout
Cenario: 02 - Acionar nova tela de local de gravacao GROT
	Quando eu acessar a nova tela de local de gravacao
	Entao eu visualizo a nova tela de local de gravacao com sucesso
	
@chrome @logout
Cenario: 03 - Acionar nova tela de indisponibilidade de local GROT
	Quando eu acessar a nova tela de indisponibilidade de local
	Entao eu visualizo a nova tela de indisponibilidade de local com sucesso
		
@chrome @logout
Cenario: 04 - Acionar nova tela de sequencia cenica GROT
	Quando eu acessar a nova tela de sequencia cenica
	Entao eu visualizo a nova tela de sequencia cenica com sucesso

@chrome @logout
Cenario: 05 - Acionar nova tela de cenarios incompativeis GROT
	Quando eu acessar a nova tela de cenarios incompativeis
	Entao eu visualizo a nova tela de cenarios incompativeis com sucesso
	
@chrome @logout
Cenario: 06 - Acionar nova tela de grupo local de gravacao(Regiao) GROT
	Quando eu acessar a nova tela de grupo local de gravacao
	Entao eu visualizo a nova tela de grupo local de gravacao com sucesso
	
@chrome @logout
Cenario: 07 - Acionar nova tela de parametros de producao GROT
	Quando eu acessar a nova tela de parametros de producao
	Entao eu visualizo a nova tela de parametros de producao com sucesso
	
@chrome @logout
Cenario: 08 - Acionar nova tela de gestao de alertas GROT
	Quando eu acessar a nova tela de gestao de alertas
	Entao eu visualizo a nova tela de gestao de alertas com sucesso
