#language: pt-BR
#Author: Lucas Fraga
#Date: 08/09/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 03.01 - Cortar cena

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

@chrome @excluir_NovoCapitulo @logout
Cenario: 15 - Cortar cena decupada
	Dado que eu selecione um capitulo e cena para cortar
	Quando cortar capitulo ou cena decupada
	Entao eu visualizo capitulo ou cena cortada com sucesso