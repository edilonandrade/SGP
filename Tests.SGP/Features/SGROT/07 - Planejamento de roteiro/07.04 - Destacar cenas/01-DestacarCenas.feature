#language: pt-BR
#Author: Lucas Fraga
#Date: 04/09/2017
#Version: 0.10
#Scenarios: 00

@kill_Driver
Funcionalidade: 07.04 - Destacar cenas

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

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 01 - Destacar cenas - Por cenas
	Dado que eu esteja com planejamento de roteiro realizado
	Quando destacar cenas por cena
	Então visualizo cena destacada

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Destacar cenas - Por tipo
	Dado que eu esteja com planejamento de roteiro realizado
	Quando destacar cenas por tipo
	Então visualizo cena destacada

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 03 - Destacar cenas - Por cenario ou locacao
	Dado que eu esteja com planejamento de roteiro realizado
	Quando destacar cenas por cenario ou locacao
	Então visualizo cena destacada

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 04 - Destacar cenas - Por personagem
	Dado que eu esteja com planejamento de roteiro realizado
	Quando destacar cenas por personagem
	Então visualizo cena destacada

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 05 - Destacar cenas - Por status
	Dado que eu esteja com planejamento de roteiro realizado
	E modificar o status da cena
	Quando destacar cenas por status
	Então visualizo cena destacada por status

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 06 - Destacar cenas - Por periodo do dia
	Dado que eu esteja com planejamento de roteiro realizado
	Quando destacar cenas por periodo do dia
	Então visualizo cena destacada