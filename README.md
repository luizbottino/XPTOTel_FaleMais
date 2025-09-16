# XPTOTel - FaleMais

API desenvolvida para um sistema de gerencia de planos, tarifas, usuários e calculo do custo de ligações telefônicas.

---

## Como Configurar e Executar o Projeto

---

### Passo 1: Preparar o Banco de Dados

A primeira coisa a fazer é criar o banco de dados que a aplicação irá usar.

1.  Crie um banco de dados SQL Server vazio.
2.  No projeto, você encontrará um arquivo de script SQL para a criação das tabelas do projeto na pasta raiz.
3.  Execute o conteúdo desse script no seu banco de dados recém-criado.

### Passo 2: Configurar a Conexão com o Banco de Dados

Configure as strings de conexão do banco (Pode ser configurado no arquivo [appsettings.json] do projeto XPTOTel_FaleMais.Api ou nos user secrets [secrets.json] do mesmo.
OBS: Para os testes que eu realizei, fiz uso dos user secrets, caso precise da connection string do banco que eu utilizei para testar basta entrar em contato comigo).

### Passo 4: Configuração da Secret Key para o Token JWT

Novamente nos arquivos [appsettings.json] ou [secrest.json], faça a configuração de uma Secret Key para a funcionalidade do token.

### Passo 5: Executar e testar a aplicação

Para testar a api basta iniciar o projeto no visual studio.
Segue a collection no postman com as requisições já prontas para uso:
https://api.postman.com/collections/27689883-b05766ce-9df2-4ce1-a1d6-69928222db49?access_key=PMAT-01K5ACRV2Q9T2E8AVE1ZWK1PKR