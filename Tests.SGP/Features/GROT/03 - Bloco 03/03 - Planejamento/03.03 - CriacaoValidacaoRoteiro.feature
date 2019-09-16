#language: pt-BR
#Author: Rodrigo Magno
#Date: 16/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.03 - Utilização da calculadora/Criação roteiro

Narrativa:
	Eu como adminstrador do sistema
	Quero criar e validar um novo roteiro no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas


@chrome @excluir_PlanejamentoRoteiro @alterar_ParametroProducao @logout
Cenario: 01 - Carregar parâmetros de planejamento de roteiro
	Dado que eu preencha o dia de antecedencia na tela de parametro
	Quando eu editar data de exibicao do capitulo e criar um roteiro
	Entao eu visualizo alerta de antecedencia minima com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @alterar_ParametroProducao @logout
Cenario: 02 - Criação de roteiro - Cena de capítulo baixo
	Dado que eu preencha o dia de antecedencia na tela de parametro
	Quando eu editar data de exibicao do capitulo e criar um roteiro com cena de capitulo baixo
	Entao eu visualizo alerta de cena com capitulo baixo com sucesso
		
@chrome @excluir_PlanejamentoRoteiro @alterar_ParametroProducao @logout
Cenario: 03 - Criação de roteiro - Inclusão de cena de capítulo baixo
	Dado que eu preencha o dia de antecedencia na tela de parametro
	Quando eu editar data de exibicao do capitulo e criar um roteiro com cena de capitulo baixo
	Entao eu visualizo alerta de cena com capitulo baixo com sucesso