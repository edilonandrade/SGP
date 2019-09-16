#language: pt-BR
#Author: Rodrigo Magno
#Date: 01/02/2018
#Version: 0.10

@kill_Driver
Funcionalidade: 04.02 - Aplicar filtro dentro do relatório de cenas

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
Cenario: 01 - Filtrar e Validar Cenas roteirizadas - Capítulo
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por capitulo em cenas roteirizadas
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Filtrar e Validar Cenas roteirizadas - Frente
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por frente em cenas roteirizadas
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Filtrar e Validar Cenas roteirizadas - Data da cena e frente
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por data da cena e frente em cenas roteirizadas
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 04 - Filtrar e Validar Cenas roteirizadas - Todos os filtros
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por todos os filtros em cenas roteirizadas
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 05 - Filtrar e Validar Cenas roteirizadas - Limpar Filtros
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por todos os filtros em cenas roteirizadas
	E clico em limpar os filtros
	Entao eu visualizo o relatorio de cenas roteirizadas com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 06 - Filtrar e Validar Frentes de Gravação - Frente e Dias
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por frente e dias em frente de gravacao
	Entao eu visualizo o relatorio de frente de gravacao com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 07 - Filtrar e Validar Quebra de Sequência Cênica - Número de quebras
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu acesso a quebra de sequencia cenica
	Entao eu visualizo o numero de sequencias cenicas existentes com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 08 - Filtrar e Validar Cenas Roteirizadas por Artista - Artista
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por artista em cenas roteirizadas por artista
	Entao eu visualizo o relatorio de cenas roteirizadas por artista com sucesso
				
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 09 - Filtrar e Validar Cenas Roteirizadas por Artista - Frente e Artista
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por frente e artista em cenas roteirizadas por artista
	Entao eu visualizo o relatorio de cenas roteirizadas por artista com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 10 - Filtrar e Validar Troca de Ambiente e Iluminação - Frente
	Dado que eu crio um roteiro com tres cenas externas
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por frente em troca de ambiente e iluminacao
	Entao eu visualizo o relatorio de troca de ambiente e iluminacao com sucesso
			
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 11 - Filtrar e Validar Troca de Ambiente e Iluminação - Roteiro
	Dado que eu crio um roteiro com tres cenas externas
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por Roteiro em troca de ambiente e iluminacao
	Entao eu visualizo o relatorio de troca de ambiente e iluminacao com sucesso
					
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 12 - Filtrar e Validar Locações Externas - Tipo do Local
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por tipo do local em locacoes externas
	Entao eu visualizo o numero de locais existentes com sucesso
																
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 13 - Filtrar e Validar Indicadores de Cenas - Indicadores das últimas soluções
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu acesso a aba de indicadores das ultimas solucoes
	Entao eu visualizo os indicadores das ultimas solucoes com sucesso
						
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 14 - Filtrar e Validar Número de Roteiros - Tipo do Local
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por tipo do local em numero de roteiros
	Entao eu visualizo o numero de roteios existentes em numero de roteiros com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 15 - Filtrar e Validar Capítulos Fechados e Equivalentes - Data
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por data em capitulos fechados e equivalentes
	Entao eu visualizo o relatorio de capitulos fechados e equivalentes com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 16 - Filtrar e Validar Elenco - Artista
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por artista em elenco
	Entao eu visualizo o relatorio de elenco com sucesso
				
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 17 - Filtrar e Validar Elenco - Data e Artista
	Dado que eu crio um roteiro com uma cena externa
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por data e artista em elenco
	Entao eu visualizo o relatorio de elenco por data com sucesso
					
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 18 - Filtrar e Validar Montagem - Todos os filtros
	Dado que eu crio um roteiro com duas cenas de estudio
	E acesso o relatorio dos indicadores de cenas
	Quando eu faco filtro por todos os campos em montagem
	Entao eu visualizo o relatorio de montagem com sucesso
