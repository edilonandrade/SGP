#language: pt-BR
#Author: Lucas Fraga
#Date: 09/10/2017
#Version: 0.10
#Scenarios: 03

@kill_Driver
Funcionalidade: 05.01 - Excluir personagem e indisponibilidade

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
	E eu criar uma nova indisponibilidade
	
@chrome @logout
Cenario: 07 - Excluir novo personagem
	Dado que eu navegue para a Tela Personagem
	Quando eu excluir novo personagem
	Entao eu visualizo novo personagem excluido com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 08 - Excluir nova indisponibilidade
	Dado que eu navegue para a Tela Personagem
	Quando eu excluir nova indisponibilidade
	Entao eu visualizo nova indisponibilidade excluida com sucesso

@chrome @logout
Cenario: 09 - Excluir novo personagem já cadastrado
	Dado que eu navegue para a Tela Personagem
	Quando eu excluir novo personagem cadastrado
	Entao eu visualizo nova crítica de personagem alocado com sucesso
