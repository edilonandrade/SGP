#language: pt-BR
#Author: Lucas Fraga
#Date: 08/06/2017
#Version: 0.10
#Scenarios: 03

@kill_Driver
Funcionalidade: 06.01 - Gerar album

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
Cenario: 08 - Gerar album com 2 imagens por pagina com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir quatro imagens
	E gerar album duas por pagina
	Então visualizo album gerado com sucesso

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 09 - Gerar album com 4 imagens por pagina com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir quatro imagens
	E gerar album quatro por pagina
	Então visualizo album gerado com sucesso

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout	
Cenario: 10 - Gerar album com 9 imagens por pagina com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir dez imagens
	E gerar album nove por pagina
	Então visualizo album gerado com sucesso
	