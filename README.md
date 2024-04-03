<header>
  <h1 align="center">Blog Api</h1>
</header>

<body>
<h2>• Apresentação do projeto</h2>
  <p>
    API projetada utilizando boas práticas de arquitetura limpa e DDD, foi utilizado .net 8, Entity Framework como ORM e SQL Server como base de dados e alguns pacotes externos, como Flunt, Mediatr e SecureIdentity.
  </p>
<h3>• Configuração</h3>
<p>
1. Clone este repositório para o seu ambiente local. <br>
2. Navegue até o diretório do projeto no seu terminal. <br>
3. Ajuste a ConnectionString no AppSettings <br>
4. Execute o comando dotnet ef database update para aplicar as migrações e criar o banco de dados. <br>
</p>
<h4>• Documentação</h4>
  <p>

### v1/users
*Descrição*: Criar um novo usuario.

- *Método HTTP*: POST
- *URL*: /v1/users
- *Requer Autenticação*: Não

Parâmetros da Requisição

- *Body*:
  string Name, string Email, string Password

Response

- *Código*: 201 Created
- *Corpo*: Guid id, string name, string email.

--------------------------------------------------------------------------------------
### v1/authenticate: Autenticar Usuário

*Descrição*: Autentica o usuário na plataforma e gera um token JWT.

- *Método HTTP*: POST
- *URL*: /v1/authenticate
- *Requer Autenticação*: Não

Parâmetros da Requisição

- *Body*:
  string Email, string Password

Resposta de Sucesso

- *Código*: 200 OK
- *Corpo*: string Token, string Id, string Name, string Email, string[] Roles

--------------------------------------------------------------------------------------
### v1/new-post: Fazer nova Postagem

*Descrição*: Insere uma nova postagem.

- *Método HTTP*: POST
- *URL*: v1/new-post
- *Requer Autenticação*: Sim

 Parâmetros da Requisição

- *Body*:
  string Title, string Description

Resposta de Sucesso

- *Código*: 200 OK
- *Corpo*: string Token, string Id, string Name, string Email, string[] Roles
--------------------------------------------------------------------------------------
### v1/new-post: Fazer nova Postagem

*Descrição*: Insere uma nova postagem.

- *Método HTTP*: POST
- *URL*: v1/new-post
- *Requer Autenticação*: Sim

Parâmetros da Requisição

- *Body*:
  string Title, string Description

Resposta de Sucesso

- *Código*: 200 OK
- *Corpo*: string Id
--------------------------------------------------------------------------------------
### v1/posts: Get todas as postagens

*Descrição*: Get todas as postagens.

- *Método HTTP*: GET
- *URL*: v1/posts
- *Requer Autenticação*: Não

Parâmetros da Requisição

- *Body*:

Resposta de Sucesso

- *Código*: 200 OK
- *Corpo*: List<Post>
--------------------------------------------------------------------------------------
v1/delete-post: Deleta uma postagem

*Descrição*: Delete de uma postagem

- *Método HTTP*: POST
- *URL*: v1/delete-post
- *Requer Autenticação*: Sim

Parâmetros da Requisição

- *Body*: string Id

Resposta de Sucesso

- *Código*: 200 OK
- *Corpo*: string Id
--------------------------------------------------------------------------------------
### v1/put-post: Atualiza uma postagem

*Descrição*: Atualiza uma postagem

- *Método HTTP*: Put
- *URL*: v1/put-post
- *Requer Autenticação*: Sim

Parâmetros da Requisição

- *Body*: Guid Id, string Title, string Description

Resposta de Sucesso

- *Código*: 200 OK
- *Corpo*: string Id
- --------------------------------------------------------------------------------------
  </p>
</body>
