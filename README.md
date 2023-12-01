# Documentação.

O presente projeto busca atender a prosposta do trabalho prático 04, da disciplina Sistemas Web II. 
A aplicação consiste em uma Web API para gerenciar informações sobre carros, juntamente com páginas da web para interação com o usuário. A aplicação é desenvolvida usando ASP.NET Core e Entity Framework Core para persistência de dados e banco de dados SQLite.

Tela de listagem inicial
![image](https://github.com/theCatta/SWII6_TP04/assets/101653810/7640dbea-627f-4dbf-9556-a6c3900c8230)

Tela de detalhes de Carro

![image](https://github.com/theCatta/SWII6_TP04/assets/101653810/73b92160-59be-4010-81fa-55f457db61df)

Tela de edição/cadastro de Carro

![image](https://github.com/theCatta/SWII6_TP04/assets/101653810/1a9b87b0-e34b-4575-afe3-9050250489e9)

Tela de deletagem de Carro

![image](https://github.com/theCatta/SWII6_TP04/assets/101653810/afbbaf8e-b520-4b68-babe-154e3c044aed)


## Estrutura do Projeto

A solução é repartida em 3 projetos:
* **API:** Parte do projeto que fornece endpoints RESTful e a lógica para a gestão de informações sobre carros.
* **WebClient:** Segmento responsável expor as telas do projeto, permitindo fácil interação do usúario.
* **Common:** Disposição da camada de serviço, de forma comum a toda a aplicação.

![image](https://github.com/theCatta/SWII6_TP04/assets/101653810/f31ef3db-30ac-4bb0-80ca-4e83137d9d4a)

![image](https://github.com/theCatta/SWII6_TP04/assets/101653810/80e93418-6fa8-4a79-bb02-f871c0d9fdbc)
As principais estruturas que formam o projeto são:

* ### Controllers:

CarroController: Controlador responsável pela lógica da Web API.

* ### Views:

Páginas Create, Details, Edit, Delete e Index para interação com o usuário.

* ### Models:

Carro: Classe modelo para representação de um carro e sua informações.


* ### Data:

CarroContext: Contexto do banco de dados utilizando o Entity Framework Core.
