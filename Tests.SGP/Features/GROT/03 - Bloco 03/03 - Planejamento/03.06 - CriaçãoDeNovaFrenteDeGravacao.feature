#language: pt-BR
#Author: Rodrigo Magno
#Date: 01/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.06 - Criação de nova frente de gravação

Narrativa:
	Eu como adminstrador do sistema
	Quero criar uma nova Frente de gravação
	Para ter controle dos Capítulos e Cenas que serão roterizados

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela de Planejamento de Roteiros GROT


@chrome @logout
Cenario: 01 - Criar nova frente com GROT com sucesso
	Quando eu criar uma nova frente de gravacao
	Entao eu visualizo a frente de gravacao criada com sucesso

@chrome @logout
Cenario: 02 - Criar nova frente por tipo estudio com sucesso
	Quando eu criar uma nova frente de gravacao tipo estudio
	Entao eu visualizo a frente de gravacao tipo estudio criada com sucesso

@chrome @excluir_planejamentoroteiro @logout
Cenario: 03 - Movimentar frente com sucesso
	Dado eu criar um roteiro em cada frente no mesmo dia
	Quando movimento uma cena do roteiro para outra frente
	Entao eu visualizo o alerta na nova frente com sucesso
	