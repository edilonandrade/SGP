#language: pt-BR
#Author: Lucas Fraga
#Date: 16/10/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 05.01 - Excluir roupas

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

@chrome @excluir_NovoPersonagem @logout
Cenario: 13 - Exclusao de roupa nao utilizada
	Dado que eu navegue para a Tela Personagem
	Quando eu cadastrar nova ficha de continuidade
	E eu excluir roupa nao utilizada
	Entao eu visualizo exclusao de roupa com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 14 - Exclusao de roupa que ja esteja utilizada
	Dado que eu navegue para a Tela Personagem
	Quando eu excluir roupa que ja esteja utilizada
	Entao eu visualizo critica de roupa ja ultilziada com sucesso