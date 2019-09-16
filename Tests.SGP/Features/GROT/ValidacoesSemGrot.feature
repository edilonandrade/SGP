#language: pt-BR
#Author: Rodrigo Magno
#Date: 06/03/2018

@kill_Driver
Funcionalidade: Validações sem perfil GROT

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar o sistema com um perfil sem GROT
	Para validar que eu não visualizo os campos do perfil GROT
	
Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um capitulo com decupagem
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 01 - Decupagem continuidade - Validação do novo campo para usuário sem perfil GROT
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Entao eu nao visualizo o campo tempo preparacao com sucesso

@chrome @logout
Cenario: 27 - Tela Cenários Incompatíveis para usuário sem perfil do GROT no SEG
	Quando eu clicar no menu principal
	Entao eu não visualizo a opcao de cenarios incompativeis
	