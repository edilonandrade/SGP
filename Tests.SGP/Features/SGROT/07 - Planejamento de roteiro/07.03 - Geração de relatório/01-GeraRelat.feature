#language: pt-BR
#Author: Flavio Arioza
#Date: 16/06/2017
#Version: 0.10
#Scenarios: 08

@kill_Driver
Funcionalidade: 07.03 - Geracao de relatorio

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizadoss
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem

@chrome @excluir_NovoCapitulo @logout
Cenario: 01 - Gerar relatorio de cenas
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando gerar relatorio de cenas
	Então visualizo o relatorio com a cena a roteirizar

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Gerar relatorio de capa da semana de gravacao
	Dado que eu esteja com planejamento de roteiro realizado
	Quando gerar o relatorio selecionando a Capa de Gravacao
	Então visualizo o relatorio com a Capa da semana de gravacao

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 03 - Gerar relatorio basico - Roteiro de gravacao
	Dado que eu esteja com planejamento de roteiro realizado
	Quando gerar relatorio basico roteiro de gravacao
	Então visualizo o relatorio basico roteiro de gravacao

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 04 - Gerar relatorio de roupas
	Dado que eu esteja com planejamento de roteiro realizado
	Quando gerar relatorio de Roupas
	Então visualizo o relatorio de roupas

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 05 - Gerar relatorio de recursos dos roteiros
	Dado que eu esteja com planejamento de roteiro realizado
	Quando gerar relatorio de recursos de roteiros
	Então visualizo o de recursos dos roteiros

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 06 - Gerar relatorio - Todas as opcoes
	Dado que eu esteja com planejamento de roteiro realizado
	Quando gerar relatorio - Todas as opcoes
	Então visualizo o relatorio com todas as opcoes
#
#@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
#Cenario: 07 - Gerar relatorio - Selecionar apenas um Roteiro
#	Dado que eu esteja com planejamento de roteiro realizado
#	Quando gerar relatorio - Selecionar apenas um roteiro
#	Então visualizo o relatorio com apenas um Roteiro selecionado
#
#@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
#Cenario: 08 - Gerar relatorio - Selecionar todos os Roteiros
#	Dado que eu esteja com planejamento de roteiro realizado
#	Quando gerar relatorio - Selecionar todos os roteiros
#	Então visualizo o relatorio com todos os roteiros selecionados