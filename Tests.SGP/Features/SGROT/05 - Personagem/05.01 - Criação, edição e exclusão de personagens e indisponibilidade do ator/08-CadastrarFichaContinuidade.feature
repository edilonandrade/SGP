#language: pt-BR
#Author: Lucas Fraga
#Date: 16/10/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 05.01 - Cadastrar ficha continuidade

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
	Quando eu criar um novo personagem

@chrome @excluir_NovoPersonagem
Cenario: 11 - Cadastrar nova ficha de continuidade de nova roupa
	Dado que eu navegue para a Tela Personagem
	Quando eu cadastrar nova ficha de continuidade
	Entao eu visualizo nova ficha de continuidade com sucesso

@chrome @excluir_NovoPersonagem
Cenario: 12 - Cadastrar ficha de continuidade com roupa já existente
	Dado que eu navegue para a Tela Personagem
	Quando eu cadastrar nova ficha de continuidade
	E eu cadastrar roupa existente
	Entao eu visualizo critica de roupa cadastrada com sucesso