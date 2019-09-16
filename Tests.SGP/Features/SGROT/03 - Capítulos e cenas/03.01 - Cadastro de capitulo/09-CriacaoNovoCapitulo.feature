#language: pt-BR
#Author: Lucas Fraga
#Date: 16/06/2017
#Version: 0.10
#Scenarios: 01
 
@kill_Driver
Funcionalidade: 03.01 - Criacao de novo capitulo

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

@chrome @excluir_NovoCapitulo @logout
Cenario: 16 - Criar novo capitulo com sucesso
	E que eu criar um novo capitulo
	Entao eu visualizo um capitulo criado com sucesso


