#language: pt-BR
#Author: Lucas Fraga
#Date: 15/08/2017
#Version: 0.10
#Scenarios: 20

@kill_Driver
Funcionalidade: 03.06 - Filtros

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


@chrome @excluir_NovoCapitulo @logout	
Cenario: 01 - Validar pesquisa de capitulos - Filtro por capitulo
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar por capitulos
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 02 - Validar pesquisa de capitulos - Filtro por intervalo de capitulo
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar por capitulos com intervalo
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 03 - Validar pesquisa de capitulos - Filtro por capitulos e cenas
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar por capitulos e cenas
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 04 - Validar pesquisa de capitulos - Filtro por capitulo e intervalo de cenas
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar por capitulos e intervalo de cenas
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 05 - Validar pesquisa de capitulos - Filtro por datas de roteiro
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	Dado que eu esteja com planejamento de roteiro realizado
	E que eu navegue para a Tela Capitulos e Cenas
	E filtrar capitulo por datas de roteitros
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 06 - Validar pesquisa de capitulos - Filtro por categoria
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por categoria
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 07 - Validar pesquisa de capitulos - Filtro por cenario
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por cenario
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 08 - Validar pesquisa de capitulos - Filtro por cenario e ambiente
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por cenario e ambiente
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 09 - Validar pesquisa de capitulos - Filtro por numeros de roteiros
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	Dado que eu esteja com planejamento de roteiro realizado
	#E que eu navegue para a Tela Capitulos e Cenas
	E filtrar capitulos por numeros de roteiros
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 10 - Validar pesquisa de capitulos - Filtro por status
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por status
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 11 - Validar pesquisa de capitulos - Filtro por tipo
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por tipo
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 12 - Validar pesquisa de capitulos - Filtro por dois campos de filtros
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos com dois campos
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 13 - Validar pesquisa de capitulos - Filtro por tres campos de filtros
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos com tres campos
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 14 - Validar pesquisa de capitulos - Campos avançados - mat. com marc. de cena
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos com materias e marcacao de cena
	Então visualizo a pesquisa de materias de cena escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 15 - Validar pesquisa de capitulos - Campos avançados - apenas capitulos secretos
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um Novo Capitulo secreto
	E filtrar capitulos por capitulo secreto
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 16 - Validar pesquisa de capitulos - Campos avançados - apenas cenas secretas
	Dado que eu criar um novo capitulo
	Quando eu criar uma cena secreta
	E filtrar capitulos por cena secreta
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 17 - Validar pesquisa de capitulos - Campos avançados - todos os capitulos
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por capitulo e cena opcao todos
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 18 - Validar pesquisa de capitulos - Campos avançados - mat. prioritario
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por material prioritario
	Então visualizo a pesquisa de materias de cena escolhido com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 19 - Validar pesquisa de capitulos - Campos avançados - classificacao
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por classificacao
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 20 - Validar pesquisa de capitulos - Filtro por personagem
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por personagem
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 21 - Validar pesquisa de capitulos - Filtro por figurante
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por figurante
	Então visualizo a pesquisa escolhida com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 22 - Validar pesquisa de capitulos - Filtro por periodo do dia
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por periodo do dia
	Então visualizo a pesquisa escolhida com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 23 - Validar pesquisa de capitulos - Filtro por tipo do cenario
	Dado que eu navegue para a Tela Capitulos e Cenas
	Quando eu criar um novo capitulo com decupagem
	E filtrar capitulos por tipo do cenario
	Então visualizo a pesquisa escolhida com sucesso