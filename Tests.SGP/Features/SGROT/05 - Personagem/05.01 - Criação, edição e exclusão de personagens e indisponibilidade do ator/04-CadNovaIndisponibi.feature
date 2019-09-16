#language: pt-BR
#Author: Lucas Fraga
#Date: 09/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 05.01 - Cadastrar indisponibilidade

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
	Quando eu criar um novo personagem

@chrome @excluir_NovoPersonagem
Cenario: 05 - Cadastrar nova indisponibilidade
	Dado que eu navegue para a Tela Personagem
	Quando eu criar uma nova indisponibilidade
	Entao eu visualizo nova indisponibilidade criada com sucesso
