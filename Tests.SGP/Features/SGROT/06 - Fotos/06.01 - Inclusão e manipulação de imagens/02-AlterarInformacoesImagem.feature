#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 06.01 - Alterar informacoes de uma imagem

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
	E incluir mais de uma imagem

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 03 - Alterar informacoes de uma imagem com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando escolho uma imagem da lista e altero alguma informacao
	Então visualizo o texto editado com sucesso

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 04 - Alterar informacoes de mais de uma imagem com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando escolho uma imagem da lista e altero alguma informacao
	E seleciono uma segunda imagem pelo carrosel
	Então visualizo o texto editado com sucesso