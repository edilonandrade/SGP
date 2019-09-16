#language: pt-BR
#Author: Rodrigo Magno
#Date: 21/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 01.09 - Local de gravação

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar a tela de Grupo Local de Gravação
	Para ter controle dos locais criados e seus respectivos deslocamentos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada


@chrome @excluir_LocalGravacao @logout
Cenario: 01 - Filtrar Locais de Gravação - Filtro por Nome
	Dado que eu acesse a tela de local de gravacao
	E tenha um local de gravacao cadastrado
	Quando eu faco busca por local de gravacao
	Entao eu visualizo o local de gravacao com sucesso

@chrome @excluir_LocalGravacao @logout
Cenario: 02 - Filtro por Tipo de Local de Gravação
	Dado que eu acesse a tela de local de gravacao
	E tenha um local de gravacao cadastrado
	Quando eu faco busca por tipo de local de gravacao
	Entao eu visualizo o local de gravacao com sucesso

@chrome @excluir_LocalGravacao @logout
Cenario: 03 - Listagem de Locais de Gravação
	Dado que eu acesse a tela de local de gravacao
	E tenha um local de gravacao cadastrado
	Quando eu faco busca por local de gravacao
	Entao eu visualizo o local de gravacao com sucesso
		
@chrome @excluir_LocalGravacao @logout
Cenario: 04 - Alteração de Locais de Gravação
	Dado que eu acesse a tela de local de gravacao
	E tenha um local de gravacao cadastrado
	Quando eu editar um local de gravacao
	Entao eu visualizo o local de gravacao editado com sucesso
	
@chrome @logout
Cenario: 05 - Exclusão de Locais de Gravação
	Dado que eu acesse a tela de local de gravacao
	Quando eu faco busca por local de gravacao com cenas associadas
	Entao eu visualizo o alerta de exclusao com sucesso

@chrome @excluir_LocalGravacao @logout
Cenario: 06 - Criação de Novo Local de Gravação
	Dado que eu acesse a tela de local de gravacao
	Quando eu crio um novo local de gravacao
	Entao eu visualizo o local de gravacao criado com sucesso