#language: pt-BR
#Author: Lucas Fraga
#Date: 02/10/2017
#Version: 0.10
#Scenarios: 05

@kill_Diver
Funcionalidade: 04.03 - Filtro de cenarios

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Cenário no SGP
	Para ter controle dos Cenários que serão manipulados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome @excluir_NovoCenario
Cenario: 01 - Validar pesquisa - Apenas 1 cenario
	Dado que eu criar um novo cenario
	Quando filtrar por cenario
	Entao visualizo cenario filtrado com sucesso

@chrome @excluir_NovoCenario
Cenario: 02 - Validar pesquisa - Mais de 2 cenarios
	Dado que eu criar dois cenarios
	Quando filtrar dois cenarios
	Entao visualizo os dois cenario filtrados com sucesso

@chrome @excluir_NovoCenario
Cenario: 03 - Validar pesquisa - Por ambiente
	Dado que eu criar um novo cenario com ambiente
	Quando filtrar por ambiente
	Entao visualizo cenario filtrado com sucesso

@chrome @excluir_NovoCenario
Cenario: 04 - Validar pesquisa - Por tipo cidade cenografica
	Dado que eu criar um novo cenario cidade cenografica
	Quando filtrar por tipo - cidade cenografica
	Entao visualizo cenario filtrado com sucesso

@chrome @excluir_NovoCenario
Cenario: 05 - Validar pesquisa - Por tipo estudio
	Dado que eu criar um novo cenario estudio
	Quando filtrar por tipo - estudio
	Entao visualizo cenario filtrado com sucesso

@chrome @excluir_NovoCenario
Cenario: 06 - Validar pesquisa - Por tipo locacao
	Dado que eu criar um novo cenario tipo externo
	Quando filtrar por tipo - externa
	Entao visualizo cenario filtrado com sucesso
