#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 06.01 - Incluir nova imagem

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
Cenario: 01 - Incluir imagem com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	Então visualizo que a imagem foi incluida com sucesso

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 02 - Incluir mais de uma imagem com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir mais de uma imagem
	Então visualizo que a imagem foi incluida com sucesso