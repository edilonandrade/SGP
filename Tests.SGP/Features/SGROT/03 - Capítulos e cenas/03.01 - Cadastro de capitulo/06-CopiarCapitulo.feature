#language: pt-BR
#Author: Lucas Fraga
#Date: 05/09/2017
#Version: 0.10
#Scenarios: 03

@kill_Driver
Funcionalidade: 03.01 - Copiar capitulo

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados

Fora do escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP com perfil sem GROT
	E que eu navegue para a Tela Home com a programacao selecionada
	
@chrome @excluir_NovoCapitulo @logout
Cenario: 18 - Copiar capitulo com cenas decupadas
	Dado que eu criar um capitulo com decupagem
	Quando copiar um capitulo
	Entao eu visualizo capitulo copiado com sucesso


@chrome @excluir_NovoCapitulo @logout
Cenario: 19 - Copiar capitulo com cenas nao decupadas
	Dado que eu criar um novo capitulo
	Quando copiar um capitulo
	Entao eu visualizo capitulo copiado com sucesso

@chrome @excluir_NovoCapitulo @logout
Cenario: 20 - Copiar capitulo ja existente no destino
	Dado que eu criar um capitulo com decupagem
	E que eu crie um capitulo em outra programacao
	Quando copiar um capitulo existente
	Entao eu visualizo critica de capitulo copiado com sucesso
