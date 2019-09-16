#language: pt-BR
#Author: Lucas Fraga
#Date: 31/08/2017
#Version: 0.10
#Scenarios: 04

@kill_Driver
Funcionalidade: 04.01 - Editar cenario

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

@chrome
Cenario: 06 - Editar cenario - Tipo cenario
	Dado que eu criar um novo cenario
	Quando editar cenario - tipo cenario
	Entao visualizo cenario atualizado com sucesso

@chrome
Cenario: 07 - Editar cenario - Tipo locacao
	Dado que eu criar um novo cenario
	Quando editar cenario - tipo locacao
	Entao visualizo cenario atualizado com sucesso

@chrome
Cenario: 08 - Editar cenario - Tipo cidade cenográfica
	Dado que eu criar um novo cenario
	Quando editar cenario - tipo cidade cenografica
	Entao visualizo cenario atualizado com sucesso

@chrome
Cenario: 09 - Editar cenario - Adicionar ambiente
	Dado que eu criar um novo cenario
	Quando editar cenario - adicionar ambiente
	Entao visualizo cenario atualizado com sucesso