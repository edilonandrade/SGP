#language: pt-BR
#Author: Rodrigo Magno
#Date: 19/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 01.02 - Cenarios - GROT

Narrativa:
	Eu como adminstrador do sistema
	Quero poder acessar a tela de Cenários
	Para ter controle dos cenarios com viagens associadas

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada


@chrome
Cenario: 01 - Filtrar Cenários por Viagem -  Sugestão de viagem
	Dado que eu navegue para a Tela de Cenario
	Quando eu clico no filtro de viagem
	Entao eu visualizo a lista de sugestoes com sucesso

@chrome
Cenario: 02 - Filtro por Viagem
	Dado que eu navegue para a Tela de Cenario
	Quando eu filtrar por viagem em cenarios
	Entao eu visualizo cenario filtrado com sucesso
	
@chrome
Cenario: 03 - Alteração de Cenário - Sugestão de Grupo Local de Gravação
	Dado que eu navegue para a Tela de Cenario
	Quando eu filtrar por viagem em cenarios
	E clicar em editar
	Entao eu visualizo a lista de regioes cadastradas na opcao regiao