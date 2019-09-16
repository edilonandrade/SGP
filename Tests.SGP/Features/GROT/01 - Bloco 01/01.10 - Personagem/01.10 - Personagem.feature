#language: pt-BR
#Author: Lenardo Lima
#Date: 01/03/2018
#Version: 0.10
#Scenarios: 01

@kill_Driver
Funcionalidade: 01.10 - Personagem

Narrativa:
       Eu como administrador do sistema
       Quero gerenciar os personagens 
       Para ter controle das cenas que serão roteirizadas

Fora do escopo:
       Testes negativos

Contexto: Usuario acessa pagina de personagem
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada

@chrome @excluir_NovoPersonagem @logout
Cenario: 01.10.01 - Validar gravação dos dados do Tempo de preparação de Figurino/caracterização
	Dado que esteja na tela de Personagem
	Quando cadastrar um novo personagem
	Entao visualizo o personagem criado com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 01.10.02 - Validar alteração de personagem sem roteiros não gravados
	   Dado que esteja na tela de Personagem
       Quando eu seleciono um Personagem para edicao
       Entao visualizo Personagem alterado com sucesso

@chrome @logout
Cenario: 01.10.03 - Tela Personagens para usuário com perfil do GROT
	   Dado que esteja na tela de Personagem
       Quando valido novos campos criados em Novo Personagem
       Entao visualizo os novos campos com sucesso

@chrome @alterar_ParametroProducaoPersonagem @logout
Cenario: 01.10.04  - Alteração de valores na tela de parâmetros
	   Dado que esteja na tela Parametros
       Quando eu altero os valores dos novos campos criados
       Entao visualizo os valores alterados com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 01.10.05 - Validar LOG - Novo Personagem - Parâmetros alterados
	   Dado que esteja na tela de Personagem
	   Quando cadastrar um novo personagem alterando os valores padroes de paramentro
       Entao visualizo o log do processo executado com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 01.10.06 - Validar LOG - Novo Personagem - parametros default do SGP
	   Dado que esteja na tela de Personagem
       Quando cadastrar um novo personagem sem alterar os valores padroes de paramentro
       Entao visualizo o log do processo executado com sucesso

@chrome @excluir_NovoPersonagem @logout
Cenario: 01.10.07 - Validar LOG - Alteração de informações do ator
		Dado que esteja na tela de Personagem
		Quando cadastrar um novo personagem
		E alterar as informacoes do ator
		Entao visualizo o log da alteracao feita no personagem

@chrome @excluir_NovoPersonagem @logout
Cenario: 01.10.11 - Validar LOG - Limpar informações cadastradas nos novos campos
		Dado que esteja na tela de Personagem
		Quando cadastrar um novo personagem
		E apagar as informacoes cadastradas nos novos campos
		Entao visualizo o log da alteracao feita no personagem

@chrome @excluir_NovoPersonagem @logout
Cenario: 02.03.01 - Alteração do Cadastro de personagem - Validar Número máximo de dias de gravação por semana
	   Dado que esteja na tela de Personagem
       Quando eu seleciono um Personagem para edicao
       Entao visualizo Personagem alterado com sucesso