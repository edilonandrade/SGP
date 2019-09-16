#language: pt-BR
#Author: Lucas Fraga
#Date: 01/09/2017
#Version: 0.10
#Scenarios: 05

@kill_Driver
Funcionalidade: 04.01 - Criar novo cenario

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
	#E que eu criar um novo capitulo
	 
@chrome @excluir_NovoCenario @logout
Cenario: 01 - Criar novo cenario - Tipo cenario
	Dado que eu navegue para a Tela de Cenario
	Quando criar um novo cenario - tipo cenario
	E adicionar novo ambiente
	Entao visualizo cenario salvo com sucesso

@chrome @excluir_NovoCenario @logout
Cenario: 02 - Criar novo cenario - Duas criações seguidas
	Dado que eu navegue para a Tela de Cenario
	Quando criar um novo cenario e salvar para criar outro cenario
	Entao visualizo cenarios sao incluidos com sucesso

@chrome @excluir_NovoCenario @logout
Cenario: 03 - Criar novo cenario - Associar ao PDS
	Dado que eu navegue para a Tela de Cenario
	Quando criar um novo cenario - tipo cenario
	E associar ao PDS
	E adicionar novo ambiente
	Entao visualizo cenario salvo com sucesso

@chrome @excluir_NovoCenario @logout
Cenario: 04 - Criar novo cenario - Tipo locacao
	Dado que eu navegue para a Tela de Cenario
	Quando criar um novo cenario - tipo locacao
	E adicionar novo ambiente
	Entao visualizo cenario salvo com sucesso

@chrome @excluir_NovoCenario @logout
Cenario: 05 - Criar novo cenario - Tipo cidade cenográfica
	Dado que eu navegue para a Tela de Cenario
	Quando criar um novo cenario - tipo cidade cenografica
	E adicionar novo ambiente
	Entao visualizo cenario salvo com sucesso

@chrome @logout
Cenario: 15 - Criar novo cenario - Associar ao mesmo PDS
	Dado que eu navegue para a Tela de Cenario
	Quando criar um novo cenario - tipo cenario
	E associar ao PDS existente
	Entao visualizo critica do PDS com sucesso
