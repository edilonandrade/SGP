#language: pt-BR
#Author: Rodrigo Magno
#Date: 14/03/2018
#Version: 0.10

@kill_Driver
Funcionalidade: 01.11 - Sequência Cênica

Narrativa:
	Eu como adminstrador do sistema
	Quero criar uma sequencia cenica
	Para determinar a ordem de gravação das cenas do produto

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	#E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a tela de sequecia cenica
	
@chrome @excluir_SequenciaCenica @logout
Cenario: 01 - Listagem de Sequências Cênicas
	Dado que eu tenho uma sequencia cenica criada
	Quando eu faco busca pela sequencia cenica somente por cenas nao gravadas
	Entao eu visualizo a sequencia cenica criada com sucesso
	
@chrome @excluir_SequenciaCenica @logout
Cenario: 02 - Filtrar Sequência Cênica
	Dado que eu tenho uma sequencia cenica criada
	Quando eu faco busca pela sequencia cenica
	Entao eu visualizo a sequencia cenica criada com sucesso
	
@chrome @excluir_SequenciaCenica @logout
Cenario: 03 - Alteração Sequência Cênica
	Dado que eu tenho uma sequencia cenica criada
	Quando eu faco uma alteracao na sequencia cenica criada
	Entao eu visualizo a altercao feita na sequencia cenica com sucesso
	
@chrome @logout
Cenario: 04 - Exclusão de Sequência Cênica
	Dado que eu tenho uma sequencia cenica criada
	Quando eu excluo a sequencia cenica
	Entao eu nao visualizo mas a sequencia cenica com sucesso

@chrome @excluir_SequenciaCenica @logout
Cenario: 05 - Criação de Nova Sequência Cênica
	Quando eu criar uma sequencia cenica
	Entao eu visualizo a sequencia cenica criada com sucesso
	
@chrome @excluir_SequenciaCenica @logout
Cenario: 06 - Alteração de Sequência Cênica
	Dado que eu tenho uma sequencia cenica criada
	Quando eu altero a ordem da sequemcia
	Entao eu visualizo a sequencia cenica criada na ordem desejada com sucesso
	
@chrome @logout
Cenario: 07 - Listagem de Cena 
	Quando eu clico no botao de nova sequencia cenica
	Entao eu visualizo as cenas existentes para o produto com sucesso
	
@chrome @excluir_SequenciaCenica @logout
Cenario: 08 - Definição de Sequência
	Quando eu criar uma sequencia cenica na ordem desejada
	Entao eu visualizo a sequencia cenica criada com sucesso
	
@chrome @logout
Cenario: 09 - Resumo das cenas
	Quando eu clico num cena
	Entao eu visualizo os detalhes da cena com sucesso
	
@chrome @logout
Cenario: 10 - Filtro das cenas
	Dado que eu clico no botao de nova sequencia cenica
	Quando eu clico no botao de filtrar cenas
	Entao eu visualizo as opcoes de filtro de cenas disponiveis com sucesso
	
@chrome @logout
Cenario: 11 - Formas de Visualização
	Quando eu clico no botao de nova sequencia cenica
	Entao eu visualizo as cenas por cenario e capitulos com sucesso
