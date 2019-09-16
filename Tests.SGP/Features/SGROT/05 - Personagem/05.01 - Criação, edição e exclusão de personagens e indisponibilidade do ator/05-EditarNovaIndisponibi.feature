#language: pt-BR
#Author: Lucas Fraga
#Date: 09/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 05.01 - Editar indisponibilidade

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
	E eu criar uma nova indisponibilidade

@chrome @excluir_NovoPersonagem
Cenario: 06 - Editar nova indisponibilidade
	Dado que eu navegue para a Tela Personagem
	Quando eu editar nova indisponibilidade
	Entao eu visualizo nova indisponibilidade editada com sucesso
