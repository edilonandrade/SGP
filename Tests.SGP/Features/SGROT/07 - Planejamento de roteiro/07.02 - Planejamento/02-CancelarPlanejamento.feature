#language: pt-BR
#Author: Lucas Fraga
#Date: 05/09/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 07.02 - Cancelar planejamento

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
	Quando eu criar um novo capitulo com decupagem

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 08 - Excluir versao de planejamento
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando criar um planejamento de roteiro
	E salvar versao de planejamento
	E excluir versao de planejamento
	Então visualizo versao de planejamento excluida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 09 - Cancelar roteiro liberado
	Dado que eu esteja com planejamento de roteiro realizado
	Quando cancelar planejamento de roteiro
	Então visualizo roteiro cancelado com sucesso