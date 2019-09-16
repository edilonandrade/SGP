﻿#language: pt-BR
#Author: Lucas Fraga
#Date: 01/09/2017
#Version: 0.10
#Scenarios: 0

@kill_Driver
Funcionalidade: 04.02 - Editar ambiente

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
	E que eu criar um novo capitulo
	E que eu criar um novo cenario com ambiente

@chrome @excluir_NovoCapitulo @excluir_NovoCenario
Cenario: 02 - Editar ambiente
	Dado que eu navegue para a Tela de Cenario
	Quando editar o ambiente
	Entao visualizo ambiente editado com sucesso