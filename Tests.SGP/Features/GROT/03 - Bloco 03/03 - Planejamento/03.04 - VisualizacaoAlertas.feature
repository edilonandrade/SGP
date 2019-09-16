#language: pt-BR
#Author: Rodrigo Magno
#Date: 10/01/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.03.04 - Visualizacao de Alertas

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

#@chrome @excluir_PlanejamentoRoteiro @logout
#Cenario: 14 - Visualizar alerta de metragem de estudio com sucesso
#	Quando eu criar um roteiro com duas cenas de estudio
#	Entao eu visualizo alerta de metragem de estudio com sucesso
#
#@chrome @excluir_PlanejamentoRoteiro @logout
#Cenario: 15 - Visualizar alerta de incompatibilidade de cenarios e ambientes com sucesso
#	Quando eu criar um roteiro com duas cenas de estudio
#	Entao eu visualizo alerta de incompatibilidade de cenarios e ambientes com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 16 - Visualizar alerta de MQE com sucesso
	Quando eu criar um roteiro com duas cenas de estudio
	Entao eu visualizo alerta de MQE com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 26 - Validar alerta - por iluminação - Estúdio - sem alerta
	Quando eu criar um roteiro com cena de estudio
	Entao eu nao visualizo alerta de iluminacao com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 27 - Visualização de Alertas - Validar alerta - por faixa de horário de gravação (noturno) - Estúdio
	Quando eu criar um roteiro com cena de estudio noturna fora da faixa de horario
	Entao eu nao visualizo alerta de faixa de horario de gravacao com sucesso - estudio noturno

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 29 - Visualizar alerta de jornada da frente com sucesso - estudio
	Quando eu criar um roteiro com duas cenas de estudio que ultrapasse a jornada da frente
	Entao eu visualizo alerta de jornada da frente com sucesso - estudio

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 30 - Visualizar alerta de tempo de preparacao de elenco com sucesso - estudio
	Quando eu criar um roteiro com cenas de estudio e com chegada do ator apos o inicio da gravacao
	Entao eu visualizo alerta de tempo de preparacao de elenco com sucesso - estudio

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 31 - Visualizar alerta de tempo de preparacao de elenco com sucesso - cidade cenografica
	Quando eu criar um roteiro com cena de cidade cenografica e com chegada do ator apos o inicio da gravacao
	Entao eu visualizo alerta de tempo de preparacao de elenco com sucesso - cidade cenografica
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 32 - Visualizar alerta de tempo de preparacao de elenco com sucesso - externa
	Quando eu criar um roteiro com cena externa e com chegada do ator apos o inicio da gravacao
	Entao eu visualizo alerta de tempo de preparacao de elenco com sucesso - externa
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 36 - Visualização de Alertas - Validar alerta - por faixa de horário de gravação (diurno)
	Quando eu criar um roteiro com cena diurna fora da faixa de horario
	Entao eu visualizo alerta de faixa de horario de gravacao com sucesso - diurno

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 37 - Visualizar alerta de faixa de horario de gravacao com sucesso - noturno
	Quando eu criar um roteiro com cena noturna fora da faixa de horario
	Entao eu visualizo alerta de faixa de horario de gravacao com sucesso - noturno

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 38 - Validar sumarização de alertas por tipo
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo a sumarizacao de alertas por tipo com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 40 - Validar alertas com maior incidência - Exibição de 3 alertas
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo os tres alertas com maior incidencia com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 41 - Validar alertas com maior incidência - Exibição de mais de 3 alertas
	Quando que eu crio um roteiro com uma cena externa
	Entao eu visualizo os demais alertas com maior incidencia com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 42 - Validar alerta - por horário de elenco
	Quando eu criar um roteiro em cada frente no mesmo dia
	Entao eu visualizo alerta de conflito de horario de elenco com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 43 - Filtro de alertas - alterar sumarização de alertas por frente: TODAS
	Quando eu criar um roteiro em cada frente no mesmo dia
	E filtrar a frente por TODAS
	Entao eu visualizo a sumarizacao de alertas de todas as frentes com sucesso
			
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 44 - Filtro de alertas - alterar sumarização de alertas por frente: MAIS DE UMA
	Quando eu criar um roteiro em cada frente no mesmo dia
	E alterar o filtro entre uma frente e outra
	Entao eu visualizo a sumarizacao de alertas de todas as frentes com sucesso
			
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 45 - Visualização de Alertas - Alerta vai e vem pelo roteiro
	Quando eu criar um roteiro em cada frente no mesmo dia
	E clicar no icone vai e vem dos dois roteiros
	Entao eu visualizo o pop up com as informacoes de cada roteiro com sucesso
			
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 46 - Visualização de Alertas - Criar conflito de roteiro
	Dado que eu salvo um rascunho de roteiro com tres cenas
	Quando eu abro o rascunho e arrasto uma cena para outro dia da frente e salvo como outro rascunho
	E eu abro o primeiro rascunho e libero o roteiro
	E eu abro o segundo rascunho e libero o roteiro
	Entao eu visualizo o alerta de conflito de roteiros
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 47 - Visualizar alerta de tempo de caracterizacao do elenco com sucesso
	Quando eu preencher os horarios de um roteiro para alerta de tempo de caracterizacao de elenco
	Entao eu visualizo alerta de tempo de caracterizacao do elenco com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 48 - Validar alerta - por tempo de preparação alteração no personagem
	Quando eu criar um roteiro com cenas de estudio e com chegada do ator apos o inicio da gravacao
	Entao eu visualizo alerta de tempo de preparacao de elenco com sucesso - estudio

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 49 - Validar o total de alertas gerados
	Quando eu criar um roteiro em cada frente no mesmo dia
	Entao eu visualizo o total de alertas gerados com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Esquema do Cenario: Alertas GROT
	Dado que crie um planejamento de roteiro com as cenas <cena1>, <cena2>, <cena3>, <cena4>, <cena5>, <cena6>
	Quando editar o horario do roteiro para o <alerta>
	Entao visualizo a mensagem <alerta>

	Exemplos: 
      | caso de teste                                                                          | alerta                                                     | cena1      | cena2      | cena3      | cena4      | cena5      | cena6      |
      | "01 - Visualizar alerta de antecedencia minima de gravacao com sucesso"                | "Antecedência mínima de gravação"                          | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "02 - Visualizar alerta de tempo de preparacao de elenco com sucesso"                  | "Tempo preparação de elenco"                               | "0500/003" | ""         | ""         | ""         | ""         | ""         |
      | "03 - Visualizar alerta de iluminacao com sucesso"                                     | "Iluminação"                                               | "0500/001" | ""         | ""         | "0500/003" | ""         | ""         |
      | "04 - Visualizar alerta de faixa de horario de gravacao com sucesso"                   | "Faixa de horário de gravação"                             | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "05 - Visualizar alerta de tempo de caracterizacao do elenco com sucesso"              | "Caracterização de elenco"                                 | "0500/003" | ""         | ""         | ""         | ""         | ""         |
      | "06 - Visualizar alerta de indisponibilidade de elenco com sucesso"                    | "Indisponibilidade de elenco"                              | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "07 - Visualizar alerta de jornada da frente com sucesso - externa"                    | "Jornada da frente"                                        | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "08 - Visualizar alerta de refeicao de elenco com sucesso"                             | "Refeição de Elenco"                                       | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "09 - Visualizar alerta de tempo de deslocamento com sucesso"                          | "Tempo de deslocamento"                                    | "0500/001" | ""         | ""         | "0500/003" | ""         | ""         |
      | "10 - Visualizar alerta de interjornada de elenco com sucesso"                         | "Interjornada de elenco"                                   | "0500/003" | "0500/004" | ""         | ""         | ""         | ""         |
      | "11 - Visualizar alerta de conflito de horario de elenco com sucesso"                  | "Conflito de horário de elenco"                            | "0500/003" | ""         | ""         | ""         | ""         | "0500/004" |
      | "12 - Visualizar alerta de multipla alocacao de ambiente com sucesso"                  | "Múltipla alocação do ambiente"                            | "0500/003" | ""         | ""         | ""         | ""         | "0500/004" |
      | "13 - Visualizar alerta de jornada de elenco com sucesso"                              | "Jornada de elenco"                                        | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "17 - Visualizar alerta de inconsistencia com sucesso"                                 | "Inconsistência"                                           | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "18 - Visualizar alerta de refeicao da equipe com sucesso"                             | "Refeição da equipe"                                       | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "20 - Visualizar alerta de jornada semanal de elenco com sucesso"                      | "Jornada semanal do elenco (SEMANAL)"                      | "0500/001" | "0500/003" | "0500/004" | ""         | ""         | ""         |
      | "21 - Visualizar alerta de limite de dias de gravacao na semana da frente com sucesso" | "Limite de Dias de Gravação na Semana da Frente (SEMANAL)" | "0500/001" | "0500/003" | "0500/004" | ""         | ""         | ""         |
      | "22 - Visualizar alerta de indisponibilidade do local com sucesso"                     | "Indisponibilidade do local (SEMANAL)"                     | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "23 - Visualizar alerta de indisponibilidade de frente de gravacao com sucesso"        | "Indisponibilidade de frente de gravação (SEMANAL)"        | "0500/001" | ""         | ""         | ""         | ""         | ""         |
      | "24 - Visualizar alerta de interjornada de frente com sucesso"                         | "Interjornada de frente (SEMANAL)"                         | "0500/001" | "0500/003" | "0500/004" | ""         | ""         | ""         |
      | "25 - Visualizar alerta de limite de dias de gravacao na semana do elenco com sucesso" | "Limite de Dias de Gravação na Semana do Elenco (SEMANAL)" | "0500/001" | "0500/003" | "0500/004" | ""         | ""         | ""         |
      | "28 - Visualizar alerta de refeicao da equipe com sucesso - cenas curtas"              | "Refeição da equipe"                                       | "0500/001" | ""         | ""         | "0500/003" | "0500/004" | ""         |

@chrome @excluir_PlanejamentoRoteiro @logout
Esquema do Cenario: Alertas GROT - Estudio
	Dado que crie um planejamento de roteiro com as cenas <cena1>, <cena2>, <cena3>, <cena4>, <cena5> de estudio
	Quando editar o horario do roteiro para o <alerta>
	Entao visualizo a mensagem <alerta>

	Exemplos: 
      | caso de teste                                                                     | alerta                                      | cena1      | cena2      | cena3 | cena4 | cena5 |
      | "14 - Visualizar alerta de metragem de estudio com sucesso"                       | "Metragem de estúdio"                       | "0502/003" | "0502/004" | ""    | ""    | ""    |
      | "15 - Visualizar alerta de incompatibilidade de cenarios e ambientes com sucesso" | "Incompatibilidade de Cenarios e Ambientes" | "0502/003" | "0502/004" | ""    | ""    | ""    |
      | "16 - Visualizar alerta de MQE com sucesso"                                       | "MQE"                                       | "0502/003" | "0502/004" | ""    | ""    | ""    |
    