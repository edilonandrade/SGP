#language: pt-BR
#Author: Flavio Arioza
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 09

@kill_Driver
Funcionalidade: 03.03 - Criar decupagem basica

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de Decupagem
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um novo capitulo

@chrome @excluir_NovoCapitulo @logout
Cenario: 01 - Cena salva com sucesso
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Decupagem Basica
	Quando eu decupar uma cena
	Entao eu visualizo a Cena criada com sucesso

@chrome @excluir_NovoCapitulo @excluir_NovoCenario @logout
Cenario: 02 - Criar novo cenario ambiente
	Dado que eu esteja com a programacao selecionada
	Quando eu criar um novo cenario ambiente 
	E utilizar novo cenario e ambiente
	Entao eu visualizo cenario ambiente criados com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 03 - Criar abertura letra
	Dado que eu esteja com a programacao selecionada
	Quando eu criar abertura de letra
	Entao eu visualizo abertura de letra criada com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 04 - Abrir letra cena decupada
	Dado que eu esteja com a programacao selecionada
	Quando eu abrir letra com cena decupada
	Entao eu visualizo abertura de letra realizada com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 05 - Criar cena secreta
	Dado que eu esteja com a programacao selecionada
	Quando eu criar uma cena secreta
	Entao visualizo cena criada com sucesso

@chrome @excluir_NovoCapitulo @excluir_NovoPersonagem @logout
Cenario: 06 - Criar novo personagem
	Dado que eu esteja com a programacao selecionada
	Quando eu criar um novo personagem na tela de decupagem
	Entao eu visualizo personagem criado com sucesso

@chrome @excluir_NovoCapitulo @excluir_NovoPersonagem @logout
Cenario: 07 - Criar novo personagem e nova indisponibilidade
	Dado que eu esteja com a programacao selecionada
	Quando eu criar um novo personagem e nova indisponibilidade
	Entao eu visualizo personagem e indisponibilidade criados com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 08 - Salvar decupar proxima cena
	Dado que eu esteja com a programacao selecionada
	Quando eu decupar a proxima cena
	Entao eu visualizo cena decupada com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 09 - Anexar capitulo
	Dado que eu esteja com a programacao selecionada
	#E que eu criar um novo capitulo
	Entao eu visualizo um capitulo criado com sucesso