#language: pt-BR
#Author: Rodrigo Magno
#Date: 06/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.08 - Relatório de Alertas

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar o Planejamento de Roteiros
	Para ter controle dos Capítulos e Cenas que serão roterizados

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas


@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 01 - Relatório de alertas - Exibição de relatório na tela com GROT
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo a opcao de relatorio de alertas com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Exibição de relatório na tela - Visões do relatório - por alertas
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo a opcao de relatorio de alertas por alertas com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Exibição de relatório na tela - Visões do relatório - por período
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo a opcao de relatorio de alertas por periodo com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 04 - Exibição de relatório na tela - Visões do relatório - por período com detalhamento
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo a opcao de relatorio de alertas por periodo com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 05 - Exibição de relatório na tela - Visões do relatório - fechar tela
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo a opcao de relatorio de alertas por periodo com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 06 - Exibição de relatório na tela - Impressão de todos os alertas
	Quando que eu crio um roteiro com uma cena externa
	E faco download do relatorio de alertas
	Entao eu visualizo relatorio de alertas com sucesso
