#language: pt-BR
#Author: Lucas Fraga
#Date: 31/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 03.01 - Validar impressao

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

@chrome @excluir_NovoCapitulo @logout
Cenario: 10 - Validar impressao listagem basica - Todas as opcoes
	Dado que eu criar um capitulo com decupagem
	Quando eu validar impressao listagem basia - todas as opcoes
	Entao eu visualizo pdf com as opcoes com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 11 - Validar impressao listagem basica - Opcao capitulo e texto da cena
	Dado que eu criar um capitulo com decupagem
	Quando eu validar impressao listagem basia - Opcao capitulo e texto da cena
	Entao eu visualizo pdf com as opcoes com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 12 - Validar impressao listagem basica - Listagem por capitulo
	Dado que eu criar um capitulo com decupagem
	Quando eu validar impressao listagem basica - Listagem por capitulo
	Entao eu visualizo pdf com as opcoes com sucesso
