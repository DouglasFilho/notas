# **Sistema de Gerenciamento de Notas Fiscais**

## Integrantes do Grupo
- Douglas Rodrigues Fernandes Filho
- Edson J�nio Bonfim Pinto


## Estat�sticas Atuais
**Quantidade de Testes de Unidade**: 41
**Cobertura de Testes**: 72,78% (Backend)

## Apresenta��o do Projeto

### Conceito
Este � um sistema simples de gerenciamento e armazenamento de notas fiscais.
Temos duas entidades principais que ficam armazenadas em tabelas separadas do banco de dados: **"Empresa"** e **"Nota Fiscal"**.

O usu�rio pode:
- **Cadastrar uma empresa**
	- Ao cadastrar a empresa, s�o solicitados a raz�o social, nome fantasia, CNPJ e endere�o.
	- O endere�o � uma objeto de valor, que � armazenada junto com a empresa e n�o possui tabela pr�pria.
	- Integramos a api ViaCep para que seja poss�vel buscar parte do endere�o atrav�s do CEP.
- **Ver as empresas cadastradas** e editar ou alternar seu status de ativa��o.
    - O status de ativa��o � um campo que indica se a empresa est� ativa ou inativa. Isso � uma forma de "excluir" a empresa sem realmente remov�-la do banco de dados, permitindo que as notas fiscais associadas a ela ainda sejam acess�veis.
- **Cadastrar notas fiscais**.
	- Ao cadastrar uma nota fiscal, pede-se:
      - Empresa emitente e a empresa destinat�ria (em ambos os casos, a empresa j� deve estar cadastrada, pois aceitamos o seu ID neste campo);
      - N�mero da nota;
      - S�rie;
      - Chave de acesso;
      - Data de emiss�o;
      - Tipo da nota (que � armazenado em um ENUM, podendo ser NF-e, NF-s OU CT-e);
      - Valor total;
      - Descri��o.
- **Ver as notas fiscais cadastradas** e edit�-las.
    - Da mesma forma que fizemos nas empresas, n�o � poss�vel remover uma nota, com o intuito de manter registros hist�ricos. Ser� implementado um sistema de status para que seja poss�vel diferenciar as diferentes etapas de processo de uma nota fiscal, como "pendente", "emitida", "cancelada", etc.

### Estrutura
O c�digo fica contido no diret�rio "Backend", seguindo a seguinte estrutura:
- **Api  **: Contem os controllers e configura��o das rotas HTTP;
- **Application**: Cont�m os servicos que conectam o dom�nio com a API;
- **Domain**: Cont�m a l�gica de neg�cios da aplica��o;
    - **Entities**: Cont�m as entidades do dom�nio, como Empresa e Nota Fiscal;
    - **Enums**: Cont�m os enums utilizados, como o tipo de nota fiscal e UF;
    - **Interfaces**: Cont�m as interfaces de reposit�rios e servi�os;
    - **ValueObjects**: Cont�m os objetos de valor que n�o possuem tabelas pr�prias no banco, como o Endere�o;
- **Infrastructure**: Cont�m a configura��o do banco de dados, reposit�rios e integra��o com servi�os externos;
    - **Data**: Cont�m o contexto do banco de dados, reposit�rios e as migra��es;
    - **Dto**: Cont�m os Data Transfer Objects utilizados para comunica��o entre a API e o dom�nio;
    - **Services**:Servicos externos, como a integra��o com a API do ViaCEP;

## Tecnologias Utilizadas
### Backend
- **.NET 8 (C#) + ASP.NET Core**: Framework principal de desenvolvimento;

- **Entity Framework Core**: acesso e manipula��o do banco de dados;
    - Cabe men��o ao uso do **In Memory Database**, que permite que os testes de Reposit�rio rodem isolados do banco de dados real, utilizando uma simula��o em mem�ria;

- **SQLite**: Usado como banco local para desenvolvimento e testes. Escolhido por sua simplicidade, adequada ao projeto;

- **xUnit**: Framework de testes utilizado para cobertura de testes unit�rios;

- **XPlat Code Coverage**: Utilizadas para gera��o de relat�rios de cobertura de testes automatizados;
  - Comando para rodar os testes e gerar o relatorio de cobertura: 
  ``` dotnet test collect:"XPlat Code Coverage"```;

- **HttpClient + JSON**: Utilizados para integra��o com a API do ViaCEP;

### Frontend
Cabe mencionar que o foco desta primeira parte do trabalho � o backend, mas o frontend foi implementado de maneira simplificada para facilitar os testes e a visualiza��o do sistema.
- **React**: Framework principal para o frontend;

- **Axios**: Biblioteca para requisi��es HTTP e comunica��o com o Backend;

- **Vite**: Ferramenta utilizada para build do projeto;

### Ferramentas
- **Visual Studio 2022**: IDE utilizada para desenvolvimento do projeto, com suporte a C# e .NET;
- **Github Actions**: CI/CD para automa��o de testes;
- **Codecov**: Ferramenta para visualiza��o de cobertura de testes;

