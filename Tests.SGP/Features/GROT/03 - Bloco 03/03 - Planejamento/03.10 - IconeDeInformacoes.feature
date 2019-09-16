#language: pt-BR
#Author: Rodrigo Magno
#Date: 19/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.10 - Ícone de informações

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas


@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 01 - Detalhamento flutuante
	Dado que eu esteja com um novo planejamento de roteiro liberado
	Quando eu clicar no botao de informacoes
	E eu clicar no botao flutuante
	Entao eu visualizo que a tela de informacoes esta em modo flutuante com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Detalhamento não flutuante
	Dado que eu esteja com um novo planejamento de roteiro liberado
	Quando eu clicar no botao de informacoes
	E eu clicar no botao flutuante e fixo
	Entao eu visualizo que a tela de informacoes esta em modo fixo com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Fechar informações
	Dado que eu esteja com um novo planejamento de roteiro liberado
	Quando eu clicar no botao de informacoes
	E eu clicar no botao flutuante
	Entao eu visualizo que a tela de informacoes esta em modo flutuante com sucesso