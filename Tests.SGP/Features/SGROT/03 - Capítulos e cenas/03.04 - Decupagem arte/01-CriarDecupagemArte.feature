#language: pt-BR
#Author: Lucas Fraga
#Date: 26/10/2017
#Version: 0.10
#Scenarios: 05

@kill_Driver
Funcionalidade: 03.04 - Criar decupagem de arte

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de Decupagem
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um capitulo com decupagem
	Quando eu decupar uma cena

@chrome @excluir_NovoCapitulo @logout
Cenario: 01 - Realizar decupagem de arte
	Dado que eu navegue para a Tela de Decupagem Arte
	Quando eu criar uma nova decupagem de arte
	Entao eu visualizo mensagem de decupagem de arte com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 02 - Raproveitar material 
	Dado que eu navegue para a Tela de Decupagem Arte
	Quando eu criar uma nova decupagem de arte
	E reaproveitar material
	Entao eu visualizo material reaproveitado com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 03 - Raproveitar material de outra cena
	Dado que eu navegue para a Tela de Decupagem Arte
	Quando eu criar uma nova decupagem de arte
	E reaproveitar material de outra cena
	Entao eu visualizo material de outra cena reaproveitado com sucesso

#@chrome @excluir_NovoCapitulo @logout
#Cenario: 04 - Raproveitar materiais fixos cenario
#	Dado que eu navegue para a Tela de Decupagem Arte
#	Quando eu criar uma nova decupagem de arte
#	E adicionar material fixo de cenario
#	Entao eu visualizo material de outra cena reaproveitado com sucesso
#
#@chrome @excluir_NovoCapitulo @logout
#Cenario: 05 - Raproveitar materiais fixos ambiente
#	Dado que eu navegue para a Tela de Decupagem Arte
#	Quando eu criar uma nova decupagem de arte
#	E adicionar material fixo de ambiente
#	Entao eu visualizo material salvo com sucesso
#
#@chrome @excluir_NovoCapitulo @logout
#Cenario: 06 - Raproveitar materiais fixos personagem
#	Dado que eu navegue para a Tela de Decupagem Arte
#	Quando eu criar uma nova decupagem de arte
#	E adicionar material fixo de personagem
#	Entao eu visualizo material salvo com sucesso