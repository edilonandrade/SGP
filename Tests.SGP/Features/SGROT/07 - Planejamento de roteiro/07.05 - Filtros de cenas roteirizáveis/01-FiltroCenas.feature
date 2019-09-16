#language: pt-BR
#Author: Flavio Arioza
#Date: 04/08/2017
#Version: 0.10
#Scenarios: 08

@kill_Driver
Funcionalidade: 07.05 - Filtros de cenas roteirizáveis

Narrativa:
	Eu como adminstrador do sistema
	Quero filtrar as cenas roteirizáveis no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem

@chrome @excluir_NovoCapitulo @logout	
Cenario: 01 - Filtrar cenas disponiveis para roteirizacao por tipo
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por tipo
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 02 - Filtrar cenas disponiveis para roteirizacao por  cenario ou locacao
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por  cenario ou locacao
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 03 - Filtrar cenas disponiveis para roteirizacao por personagem
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por personagem
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 04 - Filtrar cenas disponiveis para roteirizacao por status
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por status
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 05 - Filtrar cenas disponiveis para roteirizacao por classificacoes
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por classificacoes
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 06 - Filtrar cenas disponiveis para roteirizacao por categorias
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por categorias
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 07 - Filtrar cenas disponiveis para roteirizacao por periodo do dia
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por periodo do dia
	Então visualizo filtro escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout	
Cenario: 08 - Filtrar cenas disponiveis para roteirizacao por intervalo de capitulo
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando filtrar cenas disponiveis para roteirizacao por intervalo de capitulo
	Então visualizo filtro escolhido com sucesso