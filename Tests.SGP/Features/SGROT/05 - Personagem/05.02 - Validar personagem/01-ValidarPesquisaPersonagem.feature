#language: pt-BR
#Author: Lucas Fraga
#Date: 16/10/2017
#Version: 0.10
#Scenarios: 0

@kill_Driver
Funcionalidade: 05.02 - Validar pesquisa personagem

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome @excluir_NovoPersonagem @logout
Cenario: 01 - Validar pesquisa por ator
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por ator
	Entao eu visualizo pesquisa por ator concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 02 - Validar pesquisa por personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por personagem
	Entao eu visualizo pesquisa por personagem concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 03 - Validar pesquisa por tipo todos
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo todos
	Entao eu visualizo pesquisa por tipo todos concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 04 - Validar pesquisa por tipo apoio figurante
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo apoio figurante
	Entao eu visualizo pesquisa por tipo apoio figurante concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 05 - Validar pesquisa por tipo participacao
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo participacao
	Entao eu visualizo pesquisa por tipo participacao concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 06 - Validar pesquisa por tipo principal
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo principal
	Entao eu visualizo pesquisa por tipo principal concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 07 - Validar pesquisa por tipo animal
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo animal
	Entao eu visualizo pesquisa por tipo animal concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 08 - Validar pesquisa por combinacao de ator e personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por ator e personagem
	Entao eu visualizo pesquisa por ator e personagem concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 09 - Validar pesquisa por combinacao de tipo principal e ator
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo principal e ator
	Entao eu visualizo pesquisa por tipo principal e ator concluida com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 10 - Validar pesquisa por combinacao de tipo principal e personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu pesquisar por tipo principal e personagem
	Entao eu visualizo pesquisa por tipo principal e personagem concluida com sucesso

