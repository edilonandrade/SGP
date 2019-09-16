#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 03

@kill_Driver
Funcionalidade: 07.01 - Configuracoes do planejamento de roteiro

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

@chrome @excluir_GrupoNotificacao @logout
Cenario: 01 - Configurar grupo de notificacao
	Dado que eu esteja com a programacao selecionada
	Quando configurar o grupo de notificao
	Então visualizo mensagem do grupo de notificacao apresentada com sucesso

@chrome @logout
Cenario: 03 - Configurar capitulos baixos
	Dado que eu esteja com a programacao selecionada
	Quando configurar capitulos baixos
	Então visualizo mensagem de capitulos baixos apresentada com sucesso

@chrome @logout
Cenario: 04 - Configurar direcao do programa
	Dado que eu esteja com a programacao selecionada
	Quando configurar direcao do programa
	Então visualizo mensagem direcao do programa apresentada com sucesso