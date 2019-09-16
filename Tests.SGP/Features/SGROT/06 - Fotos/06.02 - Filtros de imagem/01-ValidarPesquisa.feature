#language: pt-BR
#Author: Lucas Fraga
#Date: 01/06/2017
#Version: 0.10
#Scenarios: 11

@kill_Driver
Funcionalidade: 06.02 - Validar pesquisa de imagem

Narrativa:
	Eu como adminstrador do sistema
	Quero criar um novo Capítulo no SGP
	Para ter controle dos Capítulos e Cenas que serão roterizados
	
Fora de escopo:
	Testes negativos

Contexto: Usuario acessa pagina de capitulos
	Dado que eu navegue para a Tela de Login do SGP
	E efetuar o login no sistema do SGP
	E que eu navegue para a Tela Home com a programacao selecionada
	Quando eu criar um novo capitulo com decupagem


#Cenario: 01 - Validar pesquisa de fotos por ID
#	Dado que eu esteja com a programacao selecionada
#	E navego para o Menu Fotos
#	Quando incluir uma imagem
#	E filtrar por ID
#	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 02 - Validar pesquisa de fotos por Inserido Por
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Inserido Por
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 03 - Validar pesquisa de fotos por Tema
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Tema
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 04 - Validar pesquisa de fotos por Personagem
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Personagem
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 05 - Validar pesquisa de fotos por Roupa e Bloco
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Roupa e Bloco
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 06 - Validar pesquisa de fotos por Cenarios
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Cenarios
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 07 - Validar pesquisa de fotos por Capitulo ou Pacote
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Capitulo ou Pacote
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_NovoCapitulo @logout
Cenario: 08 - Validar pesquisa de fotos por Classificacao
	Dado que eu esteja com a programacao selecionada
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Classificacao
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 09 - Validar pesquisa de fotos por Roteiro
	Dado que eu esteja com planejamento de roteiro realizado
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Roteiro
	Entao visualizo a imagem filtrada

@chrome @excluir_Imagens @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 10 - Validar pesquisa de fotos por Intervalo de Capitulo ou Pacote
	Dado que eu esteja com planejamento de roteiro realizado
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Intervalo de Capitulo ou Pacote
	Entao visualizo a imagem filtrada
		
@chrome @excluir_Imagens @excluir_PlanejamentoRoteiro @excluir_NovoCapitulo @logout
Cenario: 11 - Validar pesquisa de fotos por Data de Gravacao
	Dado que eu esteja com planejamento de roteiro realizado
	E que eu navegue para a Tela de Fotos
	Quando incluir uma imagem
	E filtrar por Data de Gravacao
	Entao visualizo a imagem filtrada
	

