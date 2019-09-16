#language: pt-BR
#Author: Lucas Fraga
#Date: 13/06/2017
#Version: 0.10
#Scenarios: 03

@kill_Driver
Funcionalidade: 08.01 - Visualizar roteiro

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
	Quando eu criar um novo capitulo com decupagem
	E eu decupar uma cena

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 01 - Visualizar status do roteiro para liberado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	Quando navego para roteiro
	Entao visualizo status do roteiro roteirizada

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Visualizar status do roteiro para fechado com sucesso
	Dado que eu esteja com planejamento de roteiro realizado
	E atualizo status das cenas para gravado
	Quando navego para roteiro
	Entao visualizo status do roteiro gravada

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 03 - Visualizar status do roteiro para fechado a parte com sucesso
	Dado que eu esteja com planejamento de roteiro realizado com duas cenas
	E atualizo status das cenas para fechado a parte
	Quando navego para roteiro
	Entao visualizo status do roteiro gravada a parte