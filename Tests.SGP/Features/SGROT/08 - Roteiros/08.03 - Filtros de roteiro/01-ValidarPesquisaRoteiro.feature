#language: pt-BR
#Author: Lucas Fraga
#Date: 30/10/2017
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 08.03 - Validar pesquisa de roteiro

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

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 01 - Validar pesquisa de roteiro - Filtro por data de gravacao
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por data de inicio de gravacao
	Entao visualizo filtro de data inicio de gravacao realizado com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Validar pesquisa de roteiro - Filtro por intervalo de data da gravacao
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por intervalo de data de gravacao
	Entao visualizo filtro de intervalo de gravacao realizado com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 03 - Validar pesquisa de roteiro - Filtro por numero do roteiro
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por numero do roteiro
	Entao visualizo filtro por numero do roteiro com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 04 - Validar pesquisa de roteiro - Filtro por intervalo de roteiro
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por intervalo de roteiro
	Entao visualizo filtro por numero do roteiro com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 05 - Validar pesquisa de roteiro - Filtro por tipo
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por tipo
	Entao visualizo filtro por tipo do roteiro com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 06 - Validar pesquisa de roteiro - Filtro por cenario
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por cenario do roteiro
	Entao visualizo filtro por cenario do roteiro com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 07 - Validar pesquisa de roteiro - Filtro por status
	Dado que eu esteja com planejamento de roteiro realizado
	Quando filtrar por status do roteiro
	Entao visualizo filtro por status do roteiro com sucesso