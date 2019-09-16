﻿#language: pt-BR
#Author: Lucas Fraga
#Date: 09/06/2017
#Version: 0.10
#Scenarios: 05

@kill_Driver
Funcionalidade: 08.04 - Atualizar e validar cenas

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
	E eu decupar uma cena

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 01 - Atualizar cenas para gravada e validar roteiro fechado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando Atualizar cena para gravada
	Entao visualizo status do roteiro gravada

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Atualizar cenas para gravada a parte e validar roteiro fechado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando Atualizar cena para gravada a parte
	Entao visualizo status do roteiro gravada a parte

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 03 - Atualizar cenas para pendurada e validar roteiro fechado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando Atualizar cena para pendurada
	Entao visualizo status do roteiro pendurada

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 04 - Atualizar cenas para cortada e validar roteiro fechado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando Atualizar cena para cortada
	Entao visualizo status do roteiro cortada

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 05 - Atualizar algumas cenas para gravada e validar roteiro fechado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado com duas cenas
	Quando Atualizar cena para fechada a parte
	Entao visualizo status do roteiro com duas cenas


