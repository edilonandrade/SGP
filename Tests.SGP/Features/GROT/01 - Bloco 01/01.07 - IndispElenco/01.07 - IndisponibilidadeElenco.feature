#language: pt-BR
#Author: Rodrigo Magno
#Date: 28/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 01.07 - Indisponibilidade de elenco

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar a tela de Indisponibilidade de Elenco
	Para ter controle da Indisponibilidade de Elenco cadastrados no sistema

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada

	
@chrome @excluir_IndisponibilidadeElenco @logout
Cenario: 01 - Filtrar Indisponibilidade de Elenco - Filtro por Personagem/Ator
	Dado que eu acesse a tela de indisponibilidade de elenco
	E que eu tenho uma indisponibilidade de elenco cadastrada
	Quando eu faco busca por nome de elenco indisponivel
	Entao eu visualizo a indisponibilidade de elenco cadastrada com sucesso
		
@chrome @excluir_IndisponibilidadeElenco @logout
Cenario: 02 - Filtro por Dia da Semana
	Dado que eu acesse a tela de indisponibilidade de elenco
	E que eu tenho uma indisponibilidade de elenco cadastrada
	Quando eu faco busca por dia da semana de elenco indisponivel
	Entao eu visualizo a indisponibilidade de elenco cadastrada com sucesso
	
@chrome @excluir_IndisponibilidadeElenco @logout
Cenario: 03 - Listagem de Indisponibilidade do Elenco
	Dado que eu acesse a tela de indisponibilidade de elenco
	Entao eu visualizo a listagem de indisponibilidade de elenco com sucesso
			
@chrome @excluir_IndisponibilidadeElenco @logout
Cenario: 04 - Alteração e Exclusão de Indisponibilidade de Elenco
	Dado que eu acesse a tela de indisponibilidade de elenco
	Quando eu altero uma indisponibilidade de elenco cadastrada
	Entao eu visualizo a indisponibilidade de elenco alterada com sucesso
	
@chrome @excluir_IndisponibilidadeElenco @logout
Cenario: 05 - Criação de nova Indisponibilidade de Elenco
	Dado que eu acesse a tela de indisponibilidade de elenco
	Quando eu cadastro uma nova indisponibilidade de elenco
	Entao eu visualizo a indisponibilidade de elenco cadastrada com sucesso
	
@chrome @excluir_NovoPersonagem @logout
Cenario: 07 - Associar Elenco ao Personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu criar um novo personagem
	Entao eu visualizo novo personagem criado com sucesso