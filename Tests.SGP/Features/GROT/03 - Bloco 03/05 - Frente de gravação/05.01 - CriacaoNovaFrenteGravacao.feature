#language: pt-BR
#Author: Rodrigo Magno
#Date: 31/01/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 05.01 - Criação de nova frente de gravação

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
Cenario: 01 - Criar nova frente de gravação com GROT com sucesso
	Quando eu criar uma nova frente de gravacao
	Entao eu visualizo a frente de gravacao criada com sucesso

@chrome @logout
Cenario: 03 - Criar nova frente de gravação tipo estudio com sucesso
	Quando eu criar uma nova frente de gravacao tipo estudio
	Entao eu visualizo a frente de gravacao tipo estudio criada com sucesso

@chrome @logout
Cenario: 05 - Criar nova frente de gravação selecionando segunda-feira no dia da semana com sucesso
	Quando eu criar uma nova frente de gravacao
	E seleciono apenas segunda-feira no dia da semana
	Entao eu visualizo a frente de gravacao criada com sucesso
	
@chrome @logout
Cenario: 06 - Criar nova frente de gravação selecionando mais de um dia da semana com sucesso
	Quando eu criar uma nova frente de gravacao
	E seleciono mais de um dia da semana
	Entao eu visualizo a frente de gravacao criada com sucesso
		
@chrome @logout
Cenario: 07 - Criar nova frente de gravação selecionando todos os dias da semana com sucesso
	Quando eu criar uma nova frente de gravacao
	E seleciono todos os dias da semana
	Entao eu visualizo a frente de gravacao criada com sucesso
		
@chrome @logout
Cenario: 08 - Criar nova frente de gravação selecionando apenas um checkbox dias da semana com sucesso
	Quando eu criar uma nova frente de gravacao
	E seleciono apenas um checkbox dias da semana
	Entao eu visualizo a nova frente de gravacao criada com sucesso
		
@chrome @logout
Cenario: 09 - Criar nova frente de gravação selecionando todos os checkbox dias da semana com sucesso
	Quando eu criar uma nova frente de gravacao
	E seleciono todos os checkbox dias da semana
	Entao eu visualizo a nova frente de gravacao criada com sucesso
