# Processo Seletivo Cartão de Todos
Repositório criado para manter e desenvolver o projeto do processo seletivo da empresa Cartão de Todos

## Tecnologias Utilizadas
- ASP.NET Web API 2
- ASP.NET MVC 5
- ASP.NET Web Forms
- ASP.NET Core
- Angular 2
- SQL Server Express

## Estrutura do Projeto
```bash

PSTodos/
├── Api/
|   └── PSTodos.Api
|
├── Application/
|   └── PSTodos.Application
|
├── Model/
|   └── PSTodos.Model
|
├── Infra/
|   ├── PSTodos.Infrastructure.IoC
|   └── PSTodos.Infrastructure.Repository
|
├── Frontend/
    └── RESTServices/
    |   └── PSTodos.RESTServices
    |
    └── Mvc/
    |   └── PSTodos.Mvc
    |
    └── WebForms/
    |   └── PSTodos.WebForms
    |
    └── Angular/
        └── PSTodos.Angular.Frontend
        └── Pstodos.Angular.Backend

```

## Principais bibliotecas
- [EntityFramework](https://github.com/aspnet/EntityFramework6)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [Ninject](https://github.com/ninject/Ninject)
- [FluentValidation](https://github.com/JeremySkinner/FluentValidation)
- [Materializecss](https://github.com/Dogfalo/materialize)
- [Toastr](https://github.com/CodeSeven/toastr)
- [JQuery](https://github.com/jquery/jquery)
- [Swagger](https://github.com/domaindrivendev/Swashbuckle)
- [SimpleInjector](https://github.com/simpleinjector)

## Instruções para execução das aplicações

### Banco de dados
> A estrutura dos mapeamentos do Entity Framework quanto os repositórios estão presentes no projeto "PSTodos.Infrastructure.Repository".

Foi utilizado o SQL Server Express no desenvolvimento da Api. As configurações de conexão encontram se no arquivo **Web.Config** do projeto PSTodos.Api. O mesmo deve ser ajustado caso necessário:
```xml
...
<connectionStrings>
    <add name="PSTodosConnection" connectionString="Data Source=localhost\SQLEXPRESS; Initial Catalog=ps_todos; Integrated Security=True; MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
...  
```
Posteriormente deve ser utilizado o **Package Manager Console** para rodar o comando `Update-Database` a fim de criar o banco.

### Projeto MVC
A aplicação MVC encontra-se configurada para acessar a Api através do projeto **PSTodos.RESTServices**.

### Projeto Web Forms
A aplicação Web Forms encontra-se configurada para acessar a Api através do projeto **PSTodos.RESTServices**.

### Projeto Angular 2
> O projeto Angular é servido por uma aplicação ASP.Net CORE, portanto é necessário o Visual Studio 2015 com o update 3 para que a mesma possa ser executada.

O projeto Angular pode ser acessado de duas formas:
1. Caso possua o Visual Studio 2015 update 3, o projeto já se encontra compilado na aplicação **PSTodos.Angular.Backend**.
2. Caso não possua os requisitos para a primeira opção o projeto pode ser executado através de sua versão não compilada, que se encontra no PSTodos.Angular.Frontend. Para executa-lo é necessário rodar o comando `npm install` e posteriormente o comando `ng serve` para rodar a aplicação em modo debug.

> Caso seja necessário compilar novamente basta utilizar o comando `ng build` na pasta **PSTodos.Angular.Frontend**. Dessa forma ele será compilado e copiado automaticamente para a pasta wwwroot do projeto **PSTodos.Angular.Backend**.

### Scripts Banco de Dados
Todos os scripts encontram-se na pasta **SCRIPTS BANCO**

## TODO
- Padronizar mensagens de erro e informação
- Aperfeiçoar a validação dos campos
- Confirmação ao excluir um registro
- Melhorar o tratamento dos retornos HTTP



