#language: pt-BR
#Author: Rodrigo Magno
#Date: 05/02/2018
#Version: 0.10

@kill_Driver
Funcionalidade: 04.01 - Gerar relatório dos indicadores de cenas

Narrativa:
	Eu como adminstrador do sistema
	Quero criar aplicar filtros nos relatorios de indicadores de cenas
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 01 - Visualizar os Indicadores
	Dado que eu crio um roteiro com uma cena externa
	Quando acesso o relatorio dos indicadores de cenas
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Filtro para visualização de relatório
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por capitulo em cenas roteirizadas
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso