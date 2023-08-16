# Clean Architecture Example

Este projeto é um exemplo de implementação da Clean Architecture utilizando C#.

## Estrutura do Projeto

O projeto está organizado seguindo os princípios da Clean Architecture para promover a separação de preocupações e a escalabilidade do código.

### MySales.Api

Esta camada contém os controladores da interface do usuário, lidando com as requisições HTTP e atuando como a ponte entre os usuários e os serviços de aplicação.

### MySales.Application

A camada de Application contém os serviços de aplicação e os casos de uso da aplicação. Ela orquestra as interações entre a camada de Interface do Usuário e a camada de Domínio (Core), aplicando as regras de negócio.

### MySales.Core

A camada de Core (ou Domínio) contém as entidades principais, objetos de valor, agregados e interfaces de repositório e serviços que representam a lógica central e as regras de negócio da aplicação.

### MySales.Infrastructure

A camada de Infrastructure lida com detalhes técnicos, como acesso a bancos de dados, serviços externos, autenticação, etc. Ela contém as implementações concretas das interfaces definidas na camada de Domínio.

## Como Executar o Projeto

1. Clone este repositório.
2. Configure as conexões com bancos de dados e outros serviços na camada de Infrastructure.
3. Abra a solução no Visual Studio (ou outra IDE de sua escolha).
4. Compile e execute o projeto.
