#language: pt-BR
#Author: Rodrigo Magno
#Date: 15/03/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.09 - Novos itens de cena

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas
	

@chrome @logout
Cenario: 01 - Exibir novos itens com GROT
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu clico em Editar
	Entao eu visualizo os novos itens de cena acima da listagem de cenas com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Informar horário de apenas uma refeição
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro incluindo o novo icone de refeicao
	Entao eu visualizo as cenas de roteiro com horario de refeicao com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Informar tempo de preparação inicial para apenas um roteiro
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro informando o tempo de preparacao inicial
	Entao eu visualizo as cenas de roteiro com o tempo de preparacao inicial com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 04 - Validar aumento de 5 em 5 minutos - Preparação inicial
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro aumentando o tempo de preparacao inicial
	Entao eu visualizo as cenas de roteiro com o tempo de preparacao inicial maior que o padrao com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 05 - Validar subtração de 5 em 5 minutos - Preparação inicial
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro diminuindo o tempo de preparacao inicial
	Entao eu visualizo as cenas de roteiro com o tempo de preparacao inicial menor que o padrao com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 06 - Informar tempo de deslocamento para apenas um roteiro
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro informando o tempo de deslocamento
	Entao eu visualizo as cenas de roteiro com o tempo de deslocamento com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 07 - Validar aumento de 5 em 5 minutos - Deslocamento
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro aumentando o tempo de deslocamento
	Entao eu visualizo as cenas de roteiro com o tempo de deslocamento maior que o padrao com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 08 - Validar subtração de 5 em 5 minutos - Deslocamento
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu crio um roteiro diminuindo o tempo de deslocamento
	Entao eu visualizo as cenas de roteiro com o tempo de deslocamento menor que o padrao com sucesso
