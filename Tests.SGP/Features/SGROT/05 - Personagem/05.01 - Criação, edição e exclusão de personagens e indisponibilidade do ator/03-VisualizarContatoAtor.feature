﻿#language: pt-BR
#Author: Lucas Fraga
#Date: 09/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 05.01 - Visualizar contato do ator

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

@chrome
Cenario: 04 - Visualizar contato do ator
	Dado que eu navegue para a Tela Personagem
	Quando eu filtrar personagem e acessar a tela de contato do ator
	Entao eu visualizo novo contato do ator com sucesso
