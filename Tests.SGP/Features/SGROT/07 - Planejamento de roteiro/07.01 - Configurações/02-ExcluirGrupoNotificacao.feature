#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 07.01 - Excluir nomes do grupo de notificacao

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela de Planejamento de Roteiros
	Quando configurar o grupo de notificao

@chrome @logout
Cenario: 02 - Excluir grupo notificacao
	Dado que eu esteja com a programacao selecionada
	Quando excluir nome grupo de notificacao
	Então visualizo mensagem do grupo de notificacao apresentada com sucesso