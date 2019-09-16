#language: pt-BR
#Author: Lucas Fraga
#Date: 16/08/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 03.06 - Limpar filtros

Narrativa:
	Eu como adminstrador do sistema
	Quero filtrar as cenas roteirizáveis no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 24 - Validar pesquisa de capitulos - Filtro por capitulo
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando filtrar capitulos por cenario
	E limpar todos os filtros e pesquisar
	Então visualizo todas as cenas com sucesso