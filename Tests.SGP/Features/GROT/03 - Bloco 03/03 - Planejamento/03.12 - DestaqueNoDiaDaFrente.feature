#language: pt-BR
#Author: Rodrigo Magno
#Date: 19/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 03.12 - Destaque dia da frente com GROT

Narrativa:
	Eu como adminstrador do sistema
	Quero poder acessar a tela de planejaento GROT
	Para ter controle da criação de novas frentes de planejamento com indisponibilidade

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

@chrome @logout
Cenario: 01 - Destaque dia da frente com GROT
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu criar uma nova frente de gravacao
	E seleciono todos os checkbox dias da semana
	Entao eu visualizo a nova frente de gravacao criada com sucesso

@chrome @logout
Cenario: 02 - Criar frente com dia indisponível para gravação
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu criar uma nova frente de gravacao
	E seleciono apenas um checkbox dias da semana
	Entao eu visualizo a nova frente de gravacao criada com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Criar frente com dia indisponível para gravação e manter planejamento
	Dado que eu crio um roteiro em uma nova frente de gravacao
	Quando eu alterar os dias em que a frente de gravacao vai estar disponivel
	Entao eu visualizo que o dia da frente ficou indisponivel mantendo o planejamento de roteiro com sucesso