#language: pt-BR
#Author: Leonardo Lima
#Date: 08/02/2018
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 03.01.02 - Fitro de alertas

Narrativa:
	Eu como Adminstrador do sistema
	Quero acessar gestao de alertas
	Para gerenciar os alertas que deveram aparecer no calculo do GROT

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que esteja na Tela Gestao de Alertas
	
@chrome @selecionarTodosAlertas @logout
Cenario: 02 - Selecionar mais de um alerta
	Quando eu seleciono mais de um alerta
	Entao eu visualizo alertas selecionados com sucesso

@chrome @selecionarTodosAlertas @logout
Cenario: 03 - Selecionar checkbox para selecionar todos os alertas
	Quando eu seleciono opcao todos os alertas
	Entao eu visualizo todos os alertas selecionados

@chrome @selecionarTodosAlertas @logout
Cenario: 05 - Selecionar dois alertas e depois clicar em selecionar todos os alertas
	Quando eu seleciono dois alertas
	E depois seleciono todos os alertas
	Entao eu visualizo todos os alertas marcados com sucesso

@chrome @selecionarTodosAlertas @logout
Cenario: 09 - Filtrar nome valido
	Quando que faca um filtro por alerta de antecedencia minima
	Entao visualizo o filtro por antecedencia minima com sucesso

@chrome @selecionarTodosAlertas @logout
Cenario: 12 - Selecionar checkbox itens selecionados
	Quando faco filtro por itens selecionados
	Entao eu visualizo todos os alertas selecionados

@chrome @selecionarTodosAlertas @logout
Cenario: 13 - Selecionar checkbox itens nao selecionados
	Dado que desmarco dois alertas
	Quando faco filtro por itens nao selecionados
	Entao eu visualizo todos os alertas nao selecionados

@chrome @selecionarTodosAlertas @logout
Cenario: 14 - Exibir lista de sugestão no campo Nome
	Quando clico na lista de alertas
	Entao escrevo nome pausadamente para exibir lista de sugestao

@chrome @selecionarTodosAlertas @logout
Cenario: 19 - Filtrar nome com numeros
	Quando clico na lista de alertas
	Entao escrevo nome com numeros na lista de sugestao

@chrome @selecionarTodosAlertas @logout
Cenario: 20 - Filtrar e fechar campo
	Quando clico na lista de alertas
	E filtro nome valido
	Entao clico no botao fechar

@chrome @excluir_PlanejamentoRoteiro @selecionarTodosAlertas @logout
Cenario: 21 - Filtrar alertas semanais - Jornada e Indisponibilidade
	Quando desmarco todos os alertas
	E seleciono alertas Jornada e Indisponibilidade
	E acesso planejamento de roteiro semanal
	Entao visualizo alertas semanal com sucesso

@chrome @selecionarTodosAlertas @excluir_PlanejamentoRoteiro @logout
Cenario: 22 - Filtrar alertas diarios - Iluminação e Jornada de frente
	Quando desmarco todos os alertas
	E seleciono alertas Iluminacao e JornadaFrete
	E acesso planejamento de roteiro diario
	Entao visualizado alertas diarios com sucesso

@chrome @selecionarTodosAlertas @excluir_PlanejamentoRoteiro @logout
Cenario: 24 - Filtrar - Selecionar todos os alertas
	Quando eu seleciono opcao todos os alertas
	E acesso planejamento de roteiro
	Entao visualizado alertas selecionados

@chrome @selecionarTodosAlertas @logout
Cenario: 28 - Modificar programação na tela de gestão de alertas
	Entao modifico a programacao

@chrome @selecionarTodosAlertas @logout
Cenario: 29 - Exibir campos selecionados alterando programacao
	Quando seleciono um alerta
	E seleciono outra programacao
	E valido se alertas selecionados
	E seleciono uma programacao
	Entao valido se alerta selecionado