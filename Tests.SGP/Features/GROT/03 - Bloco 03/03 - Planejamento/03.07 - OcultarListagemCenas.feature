#language: pt-BR
#Author: Rodrigo Magno
#Date: 07/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.07 - Ocultar Listagem Cenas

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar o Planejamento de Roteiros
	Para poder ocultar a listagem de cenas

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

@chrome @logout
Cenario: 01 - Ocultar lista - Ocultar lista com GROT
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando clico no icone de ocultar listagem de cenas
	Entao eu não visualizo a listagem de cenas com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Ocultar lista - detalhamento de alertas
	Dado eu crio um roteiro um dia depois da exibicao do capitulo
	Quando clico no icone de alerta de roteiro
	Entao eu não visualizo a listagem de cenas com sucesso