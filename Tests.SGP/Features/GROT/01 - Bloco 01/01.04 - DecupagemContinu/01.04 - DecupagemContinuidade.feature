#language: pt-BR
#Author: Rodrigo Magno
#Date: 03/03/2018

@kill_Driver
Funcionalidade: 01.04 - Decupagem continuidade

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Cenário no SGP
	Para ter controle dos Cenários que serão manipulados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	E que eu criar um capitulo com decupagem
	
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 01 - Alterar campo de Tempo de preparação de Figurino/caracterização.
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade grot
	Entao visualizo decupagem de continuidade realizada com sucesso
	
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 03 - Validação do novo campo para usuário com perfil GROT
	Dado que eu navegue para a Tela de Decupagem Continuidade
	Quando criar uma decupagem de continuidade grot alterando os valores de tempo de preparacao
	Entao visualizo decupagem de continuidade realizada com sucesso
	
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 04 - Decupagem de continuidade com preenchimento do novo campo
	Dado que eu crie uma decupagem de continuidade com perfil grot
	Quando eu faco busca por cena em consulta de log
	Entao eu visualizo a edicao de decupagem de continuidade com sucesso
	
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 05 - Decupagem de continuidade sem preenchimento do novo campo
	Dado que eu crie uma decupagem de continuidade com perfil grot sem preencher o novo campo
	Quando eu faco busca por cena em consulta de log
	Entao eu visualizo a edicao de decupagem de continuidade com sucesso
		
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 06 - Alteração de cena decupada removendo preenchimento do campo "Tempo Preparação figurino/caracterização(min)"
	Dado que eu crie uma decupagem de continuidade com perfil grot
	Quando eu edito a decupagem de continuidade da cena limpando a informacao do campo de tempo preparacao
	Entao eu visualizo as alteracoes de decupagem de continuidade realizada com sucesso no log do sistema
		
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 07 - Alteração de cena decupada  preenchendo o campo "Tempo Preparação figurino/caracterização(min)"
	Dado que eu crie uma decupagem de continuidade com perfil grot
	Quando eu edito a decupagem de continuidade da cena alterando a informacao do campo de tempo preparacao
	Entao eu visualizo as alteracoes de decupagem de continuidade realizada com sucesso no log do sistema
				
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 08 - Decupagem de continuidade com preenchimento do novo campo - Incluir novo Personagem
	Dado que eu crie uma decupagem de continuidade com perfil grot
	Quando eu edito a decupagem de continuidade da cena alterando a informacao do campo de tempo preparacao
	E incluir personagem
	Entao eu visualizo as alteracoes de decupagem de continuidade realizada com sucesso no log do sistema
		
@chrome @excluir_NovoCapitulo @excluir_Roupas @logout
Cenario: 09 - Decupagem de continuidade através de atalho com preenchimento do novo campo
	Dado que eu crie uma decupagem de continuidade com perfil grot atraves do atalho na tela de capitulos e cenas
	Quando eu faco busca por cena em consulta de log
	Entao eu visualizo a edicao de decupagem de continuidade com sucesso
