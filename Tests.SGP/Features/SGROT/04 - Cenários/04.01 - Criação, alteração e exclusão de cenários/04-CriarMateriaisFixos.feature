#language: pt-BR
#Author: Lucas Fraga
#Date: 27/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 04.01 - Criar materiais fixos

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Cenário no SGP
	Para ter controle dos Cenários que serão manipulados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um novo cenario

@chrome @excluir_NovoCenario @logout
Cenario: 10 - Criar materiais fixos para o cenario
	Dado que eu navegue para a Tela de Cenario
	Quando criar novo material fixo para o cenario
	Entao visualizo material fixo salvo com sucesso