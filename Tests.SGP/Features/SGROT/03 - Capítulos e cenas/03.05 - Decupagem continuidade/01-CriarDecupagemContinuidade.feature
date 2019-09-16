#language: pt-BR
#Author: Lucas Fraga
#Date: 27/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 03.05 - Criar decupagem de continuidade

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
	E que eu criar um capitulo com decupagem
	Quando eu decupar uma cena

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 01 - Criar decupagem de continuidade de cena de um capitulo
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	Entao visualizo decupagem de continuidade realizada com sucesso

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 02 - Criar decupagem de continuidade - incluir pesonagem
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	E incluir personagem
	Entao visualizo decupagem de continuidade com personagem incluido com sucesso

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 03 - Criar decupagem de continuidade - reaproveitar roupa
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	E reaproveitar roupa
	Entao visualizo decupagem de continuidade com roupa reaproveitada com sucesso

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 04 - Criar decupagem de continuidade - excluir personagem
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	E excluir personagem
	Entao visualizo exclusao de personagem com sucesso

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 05 - Criar decupagem de continuidade - abrir letra
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	E abrir letra
	Entao visualizo abertura de letra com sucesso

#@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
#Cenario: 06 - Criar decupagem de continuidade - com marcacoes a mao livre
#	Dado que eu navegue para a Tela de Decupagem Continuidade
#	Quando criar uma decupagem de continuidade
#	E marcar a mao livre
#	Entao visualizo marcacao feita com sucesso

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 07 - Criar decupagem de continuidade - consultar roupa
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	E consultar roupa
	Entao visualizo roupa selecionada com sucesso

@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 11 - Criar decupagem de continuidade - imprimir pdf
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade
	E imprimir texto em pdf 
	Entao visualizo impressao do pdf com sucesso