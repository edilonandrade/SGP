#language: pt-BR
#Author: Rodrigo Magno
#Date: 07/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.05 - Detalhamento de Alertas

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar o Planejamento de Roteiros
	Para visualizar o detalhamento de alertas

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 01 - Exibição do detalhamento - roteiro
	Dado eu crio um roteiro um dia depois da exibicao do capitulo
	Quando clico no icone de alerta de roteiro do planejamento
	Entao eu visualizo o popup de alerta de roteiro com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Exibição do detalhamento - cena
	Dado eu crio um roteiro um dia depois da exibicao do capitulo
	Quando clico no icone de alerta de cena do planejamento
	Entao eu visualizo o popup de alerta de cena com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Exibição do detalhamento - dia
	Dado eu crio um roteiro um dia depois da exibicao do capitulo
	Quando clico no icone de alerta de dia do planejamento
	Entao eu visualizo o popup de alerta de dia com sucesso
			
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 04 - Exibição do detalhamento - semana
	Dado eu crio um roteiro um dia depois da exibicao do capitulo
	Quando clico no icone de alerta de semana do planejamento
	Entao eu visualizo o popup de alerta de semana com sucesso
				
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 05 - Ocultar alertas
	Dado eu crio um roteiro um dia depois da exibicao do capitulo
	Quando clico no icone de alerta de semana do planejamento e oculto o alerta
	Entao eu nao visualizo o alerta ocultado com sucesso
#
#@chrome @excluir_PlanejamentoRoteiro @logout
#Cenario: 06 - Desativar alertas
#	Dado que eu navegue para a Tela Gestao de Alertas
#	Quando eu desmarco um alerta
#	E crio um roteiro um dia depois da exibicao do capitulo
#	Entao eu nao visualizo o alerta com sucesso
