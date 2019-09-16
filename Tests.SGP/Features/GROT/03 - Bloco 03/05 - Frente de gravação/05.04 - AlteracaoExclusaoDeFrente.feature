#language: pt-BR
#Author: Rodrigo Magno
#Date: 02/03/2018
#Version: 0.10

@kill_Driver
Funcionalidade: 05.04 - Alteração e exclusão de frente

Narrativa:
	Eu como adminstrador do sistema
	Quero poder alterar e 
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

@chrome @logout
Cenario: 01 - Alteração e exclusão de frente - Excluir frente de gravação sem roteiro associado
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu excluo uma frente de gravacao sem roteiros associados
	Entao eu nao visualizo mas a frente de gravacao com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Alteração e exclusão de frente - alterar informações de uma frente com roteiros associados
	Quando eu altero a frente de planejamento tendo um roteiro associado
	Entao eu visualizo a frente de gravacao alterada com sucesso