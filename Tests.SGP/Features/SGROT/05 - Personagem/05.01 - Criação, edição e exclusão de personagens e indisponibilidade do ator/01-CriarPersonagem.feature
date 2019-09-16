#language: pt-BR
#Author: Lucas Fraga
#Date: 09/10/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 05.01 - Criar personagem

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

@chrome @excluir_NovoPersonagem @logout
Cenario: 01 - Criar novo personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu criar um novo personagem
	Entao eu visualizo novo personagem criado com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 02 - Salvar e criar novo personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu salvar e criar um novo personagem
	Entao eu visualizo novo personagem criado com sucesso

