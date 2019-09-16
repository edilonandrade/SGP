#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 05

@kill_Driver
Funcionalidade: 06.03 - Refinar marcacao de imagem

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem
	
@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 01 - Refinar marcacao por Cenas
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E refinar a marcacao por cenas
	Então visualizo a imagem refinada por marcacao de cena

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 02 - Refinar marcacao por Cenarios
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E refinar a marcacao por cenarios
	Então visualizo a imagem refinada por marcacao de cenario

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 03 - Refinar marcacao por Roupas
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E refinar a marcacao por roupas
	Então visualizo a imagem refinada por marcacao de roupa

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 04 - Refinar marcacao por Ambientes
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E refinar a marcacao por ambientes
	Então visualizo a imagem refinada por marcacao de ambiente
#
#@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
#Cenario: 05 - Refinar marcacao com duas ou mais marcacoes
#	Dado que eu esteja com a programacao selecionada
#	E que eu navegue para a Tela de Fotos
#	Quando incluir uma imagem
#	E refinar a marcacao por ambientes
#	E refinar a marcacao por roupas
#	Então visualizo a imagem refinada por marcacao de ambiente
#	E visualizo a imagem refinada por marcacao de roupa
#
