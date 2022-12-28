## Tabela de Conteúdo
* [Informações Gerais](#informações-gerais)
* [Tecnologias](#tecnologias)
* [Processo de Investigação](#processo-de-investigação)
* [Setup](#setup)
* [Video](#video)

## Informações Gerais
  O presente projeto teve como fim o desenvolvimento de um webscrapper de produtos disponibilizados no site "https://world.openfoodfacts.org/", e de uma Api para acessar as infomações resultantes do webscrapping: 1-contando com estrutura que suporta integração com MySql e MongoDb; 2- "scheduler" para realização do scrapping automaticamente; 3-testes unitários e de integração utilziando XUnit e padrão AAA; 4-documentação de acordo com padrão OpenApi; 5-podendo ser utilizado com Docker.

## Tecnologias
Projeto criado usando:
* C#;
* ASP.NETCore;
* EntityFramework;
* XUnit;
* AutoMapper;
* FluentScheduler;
* HtmlAgilityPack;
* MySql;
* MongoDb;
* Docker;

## Processo de Investigação
  O processo de desenvolvimento se deu partindo da estrutura de scrapping, seguindo para a Api, integração com os bancos, e por fim a criação das imagens Docker e Docker Compose, tudo isso sustentado por TDD.
  A estrutura responsável pelo scrapping foi desenvolvida consultando ativamente o HTML das páginas, buscando a melhor estratégia para captura das informações necessárias.
  A Api foi criada usando conceitos como "Open Close", facilitando a integração com estruturas do MySql e do MongoDb.
## Setup
 Para rodar o projeto, pode-se optar por duas alternativas: ultilizar as estruturas do Docker, ou rodar pela IDE.
  ### Rodando pela IDE
  Para essa opção, é necessário que se atente a base de dados que se deseja utilizar. Por default a aplicação vai utilizar o MongoDb, portanto, é necessário checkar se as informações no arquivo "appsettings.json" estão de acordo com o ambiente. Caso opte por utilizar MySql, é necessário alterar o valor do campo "IsMySqlDataBase" para "true".
  #### Utilizando MySql
      * Baixe o projeto;
      * Rode o script presente no arquivo "initDb.sql";
      * Verifique se as variáveis de ambiente presentes no arquivo "appsettings.json" estão de acordo com seu ambiente;
      * Rode o projeto;
      * No Swagger, execute o end-point "Scrapper" para popular o banco, e em seguida utilize os outros end-points conforme desejar.
      
  #### Utilizando MongoDb
      * Baixe o projeto;
      * Opcional para setar o banco: com docker instalado, execute na CLI o seguinte comando "docker run -d -p 27017:27017 --name example-mongo mongo:latest";
      * Verifique se as variáveis de ambiente presentes no arquivo "appsettings.json" estão de acordo com seu ambiente;
      * Rode o projeto;
      * No Swagger, execute o end-point "Scrapper" para popular o banco, e em seguida utilize os outros end-points conforme desenjar.
      
   ### Rodando com Docker Compose
      * Copie os arquivos presentes na pasta "Arquivos Docker" para sua máquina;
      * Caso queira rodar com MongoDb, utilize o comando: "docker compose -f .\Docker-Compose-MongoDb.yml up -d" e acesse "http://localhost:44318/swagger/index.html" para utilizar o Swagger;
      * Caso queira rodar com MySql, utilize o comando: "docker compose -f .\Docker-Compose-MySql.yml up -d" "http://localhost:44319/swagger/index.html" para utilizar o Swagger;
## Video
https://www.loom.com/share/0872b67fdfe5465fab27049d88b4b1d1


>  This is a challenge by [Coodesh](https://coodesh.com/)
