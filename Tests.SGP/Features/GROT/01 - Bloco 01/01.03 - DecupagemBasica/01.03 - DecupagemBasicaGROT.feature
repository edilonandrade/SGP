#language: pt-BR
#Author: Rodrigo Magno
#Date: 28/02/2018

@kill_Driver
Funcionalidade: 01.03 - Decupagem basica GROT

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de Decupagem
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um novo capitulo

@chrome @excluir_NovoCapitulo @logout
Cenario: 01 - Novos campos na tela de Decupagem - Carregar as informações padrões
	Dado que eu navegue para a Tela de Decupagem Basica
	Entao eu visualizo os novos campos de decupagem basica com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 02 - Alteração no Cadastro de Decupagem
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu faco uma decupagem basica preenchendo os novos campos GROT
	Entao eu visualizo os novos campos de decupagem basica com sucesso
	
@chrome @excluir_NovoCapitulo @excluir_NovoCenario @excluir_LocalGravacao @excluir_Regiao @logout
Cenario: 03 - Criação de novo Local de Gravação - Criação de local de gravação
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu crio um novo local durante a decupagem basica
	Entao eu visualizo a Cena criada com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 04 - Validação da criação dos campos novos para usuário com perfil de rollout gradativo
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu faco uma decupagem basica com perfil GROT
	Entao eu visualizo a Cena criada com sucesso
		
@chrome @excluir_NovoCapitulo @logout
Cenario: 05 - Validação dos novos campos
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu faco uma decupagem basica preenchendo o campo duracao com caracteres invalidos
	Entao eu visualizo a Cena criada com sucesso com o campo duracao exibindo o ultimo caracter valido
		
@chrome @excluir_NovoCapitulo @alterar_ParametroProducao @logout
Cenario: 06 - Alteração de parâmetros default
	Dado que eu navegue para a Tela de Decupagem Basica
	E visualizo os novos campos de decupagem basica
	Quando eu acesso a tela de parametros
	E altero os valores padroes desses campos
	Entao eu visualizo os valores atualizados na tela de decupagem basica
		
@chrome @excluir_NovoCapitulo @excluir_NovoCenario @excluir_LocalGravacao @excluir_Regiao @logout
Cenario: 07 - Criação de novo local de gravação
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu crio um novo local durante a decupagem basica
	Entao eu visualizo a Cena criada com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 08 - Decupagem com alteração dos campos "default" na tela
	Dado que eu tenha uma cena decupada
	Quando eu realizo uma alteracao na decupagem basica
	E eu faco busca por cena em consulta de log
	Entao eu visualizo a alteracao feita no log com sucesso
			
@chrome @excluir_NovoCapitulo @excluir_NovoCenario @excluir_LocalGravacao @excluir_Regiao @logout
Cenario: 09 - Decupagem com preenchimento dos campos Local e Local de Gravação
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu crio um novo local durante a decupagem basica
	Entao eu visualizo a Cena criada com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 10 - Decupagem alterando os novos campos
	Dado que eu tenha uma cena decupada
	Quando eu realizo uma alteracao na decupagem basica
	E eu faco busca por cena em consulta de log
	Entao eu visualizo a alteracao feita no log com sucesso
		
@chrome @excluir_NovoCapitulo @logout
Cenario: 11 - Criação de decupagem para o período "Dia"
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu faco uma decupagem basica para o periodo Dia
	Entao eu visualizo a Cena criada com periodo dia com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 12 - Criação de decupagem para o período "Tarde"
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu faco uma decupagem basica para o periodo Tarde
	Entao eu visualizo a Cena criada com periodo tarde com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 13 - Criação de decupagem para o período "Noite"
	Dado que eu navegue para a Tela de Decupagem Basica
	Quando eu faco uma decupagem basica para o periodo Noite
	Entao eu visualizo a Cena criada com periodo noite com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 14 - Alteração de cena decupada
	Dado que eu tenha uma cena decupada
	Quando eu realizo uma alteracao na decupagem basica
	E eu faco busca por cena em consulta de log
	Entao eu visualizo a alteracao feita no log com sucesso
		
@chrome @excluir_NovoCapitulo @logout
Cenario: 15 - Decupagem de cena através de atalho
	Dado que eu navegue para a Tela de Decupagem Basica atraves de atalho
	Quando eu faco uma decupagem basica preenchendo os novos campos GROT
	Entao eu visualizo os novos campos de decupagem basica com sucesso
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 16 - Alteração de cena decupada - limpar preenchimento dos novos campos
	Dado que eu tenha uma cena decupada
	Quando eu edito a cena decupada limpando os campos GROT
	E eu faco busca por cena em consulta de log
	Entao eu visualizo a alteracao feita no log com sucesso
	
@chrome @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 17 - Criação e liberação de Roteiro
	Dado que eu tenha uma cena decupada
	Quando criar um planejamento de roteiro
	Então visualizo roteiro criado com sucesso

@chrome @alterar_StatusRoteiro @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 18 - Alteração de cena para Gravada
	Dado que eu tenha uma cena decupada
	E que eu esteja com planejamento de roteiro realizado
	Quando Atualizar cena para gravada
	Entao visualizo status do roteiro gravada
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 19 - Alteração de parâmetro Faixa prevista Gravação (hh:mm) - de - até
	Dado que eu acesse a tela de parametros de producao apos criar um capitulo
	Quando eu altero os valores de periodo noturno
	Entao eu visualizo que a alteracao feita nao foi refletida na tela de decupagem basica com sucesso
		
@chrome @excluir_NovoCapitulo @logout
Cenario: 20 - Validação de cena após alteração de parâmetro do período "Noite"
	Dado que eu acesse a tela de parametros de producao apos criar um capitulo
	Quando eu altero os valores de periodo noturno
	Entao eu visualizo que a alteracao feita nao foi refletida na tela de decupagem basica com sucesso