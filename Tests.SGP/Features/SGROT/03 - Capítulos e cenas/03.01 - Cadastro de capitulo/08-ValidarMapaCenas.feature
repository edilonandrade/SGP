#language: pt-BR
#Author: Lucas Fraga
#Date: 14/06/2017
#Version: 0.10
#Scenarios: 01 

@kill_Driver
Funcionalidade: 03.01 - Validar mapa de cenas

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
	Quando eu criar um novo capitulo com decupagem

@chrome @excluir_NovoCapitulo @logout
Cenario: 08 - Validar mapa de cenas com sucesso
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando acessar o mapa de cenas
	Entao visualizo mapa de cenas
	