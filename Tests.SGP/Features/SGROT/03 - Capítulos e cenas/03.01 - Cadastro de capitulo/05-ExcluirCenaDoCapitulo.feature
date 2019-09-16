#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 01 

@kill_Driver
Funcionalidade: 03.01 - Excluir cena do capitulo

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora de escopo:
	Teste negativos

Contexto: Criar um novo capitulo
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome @excluir_NovoCapitulo @logout
Cenario: 05 - Excluir cena do capitulo com sucesso
	Dado que eu esteja com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem
	E excluir cena
	Entao visualizo cena excluida com sucesso
	