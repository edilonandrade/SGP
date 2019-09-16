#language: pt-BR
#Author: Lucas Fraga
#Date: 01/09/2017
#Version: 0.10
#Scenarios: 02

@kill_Driver
Funcionalidade: 07.02 - Criar planejamento de roteiro

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 01 - Criar planejamento de roteiro com uma frente de trabalho
	#Dado que eu esteja com o capitulo o criado
	Quando criar um planejamento de roteiro
	Então visualizo roteiro criado com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 02 - Criar planejamento de roteiro com duas frentes de trabalho
	Dado que eu decupe uma cena do tipo estudio
	Quando criar um planejamento de roteiro com duas frentes
	Então visualizo as duas frentes criadas com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 03 - Compartilhar planejamento nao liberado
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando que eu esteja com planejamento de roteiro nao liberado
	Então visualizo roteiro nao liberado om sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 04 - Incluir recursos de roteiro
	Dado que eu esteja com planejamento de roteiro realizado
	Quando eu incluir recurso de roteiro
	Então visualizo recurso de roteiro com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 07 - Incluir frequencia de elenco
	Dado que eu esteja com planejamento de roteiro realizado
	Quando eu incluir frequencia de elenco
	Então visualizo frequencia de elenco com sucesso
	 
@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 10 - Salvar planejamento de roteiro
	#Dado que eu esteja com o capitulo o criado
	Quando criar um planejamento de roteiro
	E salvar versao de planejamento
	Então visualizo roteiro criado com sucesso

@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 11 - Compartilhar roteiro - não liberado e depois libera-lo
	Dado que eu navegue para a Tela de Planejamento de Roteiros
	Quando que eu esteja com planejamento de roteiro nao liberado
	E eu libero o roteiro
	Então visualizo roteiro criado com sucesso