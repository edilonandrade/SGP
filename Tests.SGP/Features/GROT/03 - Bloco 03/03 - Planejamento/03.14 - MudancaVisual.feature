#language: pt-BR
#Author: Rodrigo Magno
#Date: 01/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.14 - Mudança Visual

Narrativa:
	Eu como adminstrador do sistema
	Quero realizar um calculo de roteiro
	Para visualizar o novo cabeçalho GROT

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas


@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 01 - Mudança visual - cabeçalho com GROT
	Quando eu criar um roteiro com GROT
	Entao eu visualizo o novo cabecalho GROT com sucesso