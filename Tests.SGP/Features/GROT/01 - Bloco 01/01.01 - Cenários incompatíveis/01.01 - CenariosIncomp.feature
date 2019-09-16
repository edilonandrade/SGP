#language: pt-BR
#Author: Rodrigo Magno
#Date: 03/01/2018
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 01.01 - Criar listagem de cenarios incompativeis

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome @excluir_ListaCenarioIncompativel @logout
Cenario: 01 - Criar listagem de cenarios incompativeis com sucesso
	Quando eu criar listagem de incompativeis
	Entao eu visualizo listagem de incompativeis com sucesso

@chrome @excluir_ListaCenarioIncompativel @logout
Cenario: 02 - Filtrar cenarios incompativeis com sucesso
	Quando eu criar listagem de incompativeis
	E eu filtrar cenarios incompativeis
	Entao eu visualizo listagem de incompativeis com sucesso

@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 03 - Alteracao de Cenarios Incompativeis
    Quando eu altere o cenario incompativel
    Entao eu visualizo listagem de incompativeis alterada com sucesso

@chrome @logout
Cenario: 04 - Exclusao de Cenarios Incompativeis
    Quando eu excluo o cenario incompativel
    Entao eu nao visualizo o cenario de incompativel com sucesso

@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 05 - Criacao de Nova Lista com Cenarios Incompativeis
	Quando eu criar listagem de incompativeis
	Entao eu visualizo listagem de incompativeis com sucesso

@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 06 - Alteração de Lista
    Quando eu altere o nome da lista incompativel
    Entao eu visualizo o nome da listagem de incompativeis alterada com sucesso

@chrome  @logout
Cenario: 07 - Criação de Nova Lista sem Cenários Incompatíveis - Negativo
	Quando eu criar listagem de incompativeis sem preencher os cenarios
	Entao eu visualizo a mensagem de que nao e possivel realizar cadastro com menos de dois cenarios com sucesso

@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 10 - Validação do filtro por cenário
	Quando eu criar listagem de incompativeis
	E eu filtrar cenarios incompativeis
	Entao eu visualizo listagem de incompativeis com sucesso

@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 11 - Validação do filtro por ambiente
	Quando eu criar listagem de incompativeis
	E eu filtrar cenarios incompativeis por ambiente
	Entao eu visualizo listagem de incompativeis com sucesso
	
@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 12 - Validar LOG de alteração de cenários incompatíveis
	Dado que eu tenha alterado uma nova lista de cenarios incompativeis
	Quando eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a alteracao feita na lista de cenarios incompativeis no log com sucesso
		
@chrome @logout
Cenario: 13 - Validar LOG de exclusão da lista de cenários incompatíveis
	Dado que eu tenha excluido uma nova lista de cenarios incompativeis
	Quando eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis no log com sucesso
							
@chrome @excluir_ListaCenarioIncompativel @logout
Cenario: 14 - Validar LOG de Exclusão de 1 item lista de cenários incompatíveis
	Dado que eu tenha excluido todos um item da nova lista de cenarios incompativeis
	Quando eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo o cenario excluido da lista de cenarios incompativeis no log com sucesso
	
@chrome @logout
Cenario: 15 - Validar LOG de exclusão de todos os itens lista de cenários incompatíveis
	Dado que eu tenha excluido todos os itens da nova lista de cenarios incompativeis
	Quando eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis excluida no log com sucesso
	
@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 16 - Validar LOG da função "Salvar e Criar nova lista de incompatibilidade"
	Dado que eu tenha criado duas listas de cenarios incompativeis
	Quando eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo as duas listas de cenarios incompativeis no log com sucesso

@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 17 - Criação de lista - Ambiente já associado
	Quando eu criar listagem de incompativeis
	E criar uma nova listagem de cenarios incompativeis com o ambiente já cadastrado em outra lista
	Entao eu visualizo o alerta de cenarios/ambientes já cadastrados com sucesso
	
@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 18 - Criação de lista cujo nome já pertence a uma lista criada
	Quando eu criar listagem de incompativeis
	E criar uma nova listagem de cenarios incompativeis com o mesmo nome
	Entao eu visualizo o alerta lista já existente com sucesso
		
@chrome @logout
Cenario: 19 - Criação de lista - Preenchimento de apenas 1 linha do cadastro
	Quando eu criar listagem de incompativeis preenchendo apenas uma linha de cenario/ambiente
	Entao eu visualizo o alerta de que o cadastro nao e valido com apenas uma linha com sucesso
			
@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 20 - Validar LOG Criação de lista - Marcação "Todos os Ambientes"
	Dado que eu tenha criado uma nova lista de cenarios incompativeis marcando todos os ambientes
	Quando eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis no log com sucesso
	
@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 21 - Alteração de Nome da Lista - Incluindo nome existente
	Quando eu criar duas listagem de cenarios incompativeis
	E renomear um listagem de cenarios incompativeis com o mesmo nome de outra existente
	Entao eu visualizo o alerta ao tentar editar de lista já existente com sucesso
				
@chrome @excluir_PlanejamentoRoteiro @excluir_ListaCenarioIncompativel @logout
Cenario: 22 - Criação de nova incompatibilidade em cenário já associado a uma cena de roteiro liberado
	Dado que eu tenha um roteiro liberado
	Quando eu crio uma lista de cenarios incompativeis com cenario associado ao roteiro
	E eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis associado a um roteiro no log com sucesso
				
@chrome @excluir_PlanejamentoRoteiro @excluir_ListaCenarioIncompativel @logout
Cenario: 23 - Alteração de incompatibilidade em cenário já associado a uma cena de roteiro liberado
	Dado que eu tenha um roteiro liberado
	Quando eu altero uma lista de cenarios incompativeis com cenario associado ao roteiro
	E eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis associado a um roteiro no log com sucesso
						
@chrome @excluir_PlanejamentoRoteiro @excluir_ListaCenarioIncompativel @logout
Cenario: 24 - Inclusão de nova incompatibilidade em cenário já associado a uma cena de roteiro liberado
	Dado que eu tenha um roteiro liberado
	Quando eu altero uma lista de cenarios incompativeis com cenario associado ao roteiro incluindo um novo cenario
	E eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis associado a um roteiro no log com sucesso
							
@chrome @alterar_NovoStatusRoteiro @excluir_PlanejamentoRoteiro @excluir_ListaCenarioIncompativel @logout
Cenario: 25 - Validar que inclusão de nova incompatibilidade para roteiro fechado não foi impactado
	Dado que eu tenha um roteiro fechado
	Quando eu altero uma lista de cenarios incompativeis com cenario associado ao roteiro incluindo um novo cenario
	E eu faco uma consulta por cenario incompativel no log
	Entao eu visualizo a lista de cenarios incompativeis associado a um roteiro no log com sucesso
	
@chrome @excluir_ListaCenarioIncompativel  @logout
Cenario: 26 - Criação de lista - Cenário já associado
	Quando eu criar listagem de incompativeis
	E criar uma nova listagem de cenarios incompativeis com o cenario já cadastrado em outra lista
	Entao eu visualizo o alerta de cenarios/ambientes já cadastrados com sucesso
