#language: pt-BR
#Author: Rodrigo Magno
#Date: 20/02/2018
#Version: 0.01

@kill_Driver
Funcionalidade: 02.01 - Grupo de gravação

Narrativa:
	Eu como adminstrador do sistema
	Quero acessar a tela de Grupo Local de Gravação
	Para ter controle dos locais criados e seus respectivos deslocamentos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada


@chrome @logout
Cenario: 01 - Listar Deslocamentos - Listagem do local
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu criar um novo local
	Entao eu visualizo o novo local criado com sucesso
	
@chrome @logout
Cenario: 02 - Criar Local 
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu criar um novo local
	Entao eu visualizo o novo local criado com sucesso
	
@chrome @logout
Cenario: 03 - Exclusão do Local
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu excluo um local com capitulo associado
	Entao eu visualizo a mensagem de critica com sucesso
		
@chrome @logout
Cenario: 04 - Filtro por Local de Gravação A 
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu faco um filtro por local de gravacao A
	Entao eu visualizo o resultado do filtro por local de gravacao A com sucesso
		
@chrome @logout
Cenario: 05 - Filtro por Local de Gravação B
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu faco um filtro por local de gravacao B
	Entao eu visualizo o resultado do filtro por local de gravacao B com sucesso
		
@chrome @logout
Cenario: 06 - Filtro por Grupo Local de Gravação
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu faco um filtro por grupo local de gravacao
	Entao eu visualizo o resultado do filtro por grupo local de gravacao com sucesso
			
@chrome @logout
Cenario: 07 - Detalhar Local
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu criar um novo local realizando o seu detalhamento
	Entao eu visualizo o novo local criado com sucesso
	
@chrome @logout
Cenario: 08 - Filtro por Local de Gravação A 
	Dado que eu acesse a tela de grupo local de gravacao
	Quando eu faco um filtro por local de gravacao A
	E faca uma alteracao
	Entao eu visualizo a mensagem de com sucesso
	