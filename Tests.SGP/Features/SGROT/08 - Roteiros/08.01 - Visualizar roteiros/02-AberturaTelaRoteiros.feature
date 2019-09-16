#language: pt-BR
#Author: Lucas Fraga
#Date: 14/06/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 08.01 - Abrir espelho de gravação e planejamento através da tela de roteiro

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem
	
@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 04 - Abrir espelho de gravacao atraves da tela de roteiro com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando eu abrir espelho de gravacao pela tela roteiro
	Entao visualizo tela espelho de gravacao

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 05 - Abrir planejamento de roteiros atraves da tela de roteiro com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando eu abrir planejamento roteiro pela tela roteiro
	Entao visualizo tela planejamento roteiro
