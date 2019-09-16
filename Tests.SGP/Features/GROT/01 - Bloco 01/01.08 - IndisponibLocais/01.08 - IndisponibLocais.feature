#language: pt-BR
#Author: Rodrigo Magno
#Date: 21/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 01.08 - Indisponibilidade de local

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar a tela de Indisponibilidade de Locais
	Para ter controle da Indisponibilidade de Locais cadastrados no sistema

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada

	
@chrome @excluir_IndisponibilidadeLocais @logout
Cenario: 01 - Filtrar Indisponibilidade de Local - Filtro por Local de Gravação
	Dado que eu acesse a tela de indisponibilidade de locais
	E que eu tenho uma indisponibilidade de local cadastrada
	Quando eu faco busca por nome de local indisponivel
	Entao eu visualizo a indisponibilidade de local cadastrada com sucesso
			
@chrome @excluir_IndisponibilidadeLocais @logout
Cenario: 02 - Filtro por Dia da Semana
	Dado que eu acesse a tela de indisponibilidade de locais
	E que eu tenho uma indisponibilidade de local cadastrada
	Quando eu faco busca por dia da semana na tela de indisponibilidade de locais
	Entao eu visualizo a indisponibilidade de local cadastrada com sucesso
				
@chrome @excluir_IndisponibilidadeLocais @logout
Cenario: 03 - Filtro por Período
	Dado que eu acesse a tela de indisponibilidade de locais
	E que eu tenho uma indisponibilidade de local cadastrada
	Quando eu faco busca por periodo na tela de indisponibilidade de locais
	Entao eu visualizo a indisponibilidade de local cadastrada com sucesso
				
@chrome @excluir_IndisponibilidadeLocais @logout
Cenario: 04 - Listagem de Indisponibilidade do Local
	Dado que eu acesse a tela de indisponibilidade de locais
	E que eu tenho uma indisponibilidade de local cadastrada
	Quando eu faco busca por nome de local indisponivel
	Entao eu visualizo a indisponibilidade de local cadastrada com sucesso
				
@chrome @logout
Cenario: 06 - Exclusão de Indisponibilidade de Local
	Dado que eu acesse a tela de indisponibilidade de locais
	E que eu tenho uma indisponibilidade de local cadastrada
	Quando eu excluo uma indisponibilidade de local
	Entao eu nao visualizo mais a indisponibilidade de local cadastrada com sucesso

@chrome @excluir_IndisponibilidadeLocais @logout
Cenario: 07 - Criação de nova Indisponibilidade de Local
	Dado que eu acesse a tela de indisponibilidade de locais
	Quando eu cadastro uma nova indisponibilidade
	Entao eu visualizo a indisponibilidade de local cadastrada com sucesso
	
@chrome @excluir_IndisponibilidadeLocais @logout
Cenario: 08 - Inclusão de Nova Indisponibilidade de Local-Salvar e Criar Nova Indisponibilidade de Locais
	Dado que eu acesse a tela de indisponibilidade de locais
	Quando eu cadastro duas indisponibilidade de local
	Entao eu visualizo as duas indisponibilidades de local cadastrada com sucesso