#language: pt-BR
#Author: Lucas Fraga
#Date: 07/06/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 06.01 - Baixar imagem

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
Cenario: 06 - Baixar uma imagem via lista de imagens com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando escolho uma imagem via janela de detalhamento e baixo uma imagem
	Então visualizo imagem baixada com sucesso

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 07 - Baixar mais de uma imagem com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando escolho todas as imagens e as baixo
	Então visualizo zip das imagens baixadas com sucesso
	
