#language: pt-BR
#Author: Rodrigo Magno
#Date: 06/02/2018
#Version: 0.10

@kill_Driver
Funcionalidade: 05.02 - Carregamento das frentes padrão

Narrativa:
	Eu como adminstrador do sistema
	Quero visualizar o carregamento das frentes padrão
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu navegue para a Tela Capitulos e Cenas

@chrome @logout
Cenario: 01 - Carregamento de frente com GROT
	Dado que eu navegue para a Tela de Planejamento de Roteiros GROT
	Quando eu desbloqueio a tela de planejamento
	Entao eu visualizo os botoes de edicao e exclusao de frente com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 02 - Carregamento de frente - Validar frente de gravação automaticamente
	Quando eu clico em editar a frente tendo um roteiro criado
	Entao eu visualizo os parametros da frente disponiveis com sucesso

@chrome @excluir_PlanejamentoRoteiro @logout
Cenario: 03 - Carregamento de frente - Alterar e validar parâmetros das frentes
	Quando eu clico em editar a frente tendo um roteiro criado
	Entao eu visualizo os parametros da frente disponiveis com sucesso