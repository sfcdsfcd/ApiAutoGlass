# API de Gestão de Produtos
Este projeto é uma API desenvolvida em .NET 8 utilizando arquitetura DDD para gerenciar produtos, com funcionalidades de CRUD e operações avançadas de consulta.

## Tecnologias Utilizadas
- **.NET 8:** Plataforma de desenvolvimento para construção da API.
- **Entity Framework Core:** ORM utilizado para mapeamento objeto-relacional.
- **AutoMapper:** Biblioteca para mapeamento de objetos.
- **Swagger:** Ferramenta para documentação e teste da API.
- **MySQL:** Banco de dados utilizado para persistência dos dados.
  
## Funcionalidades Principais
Cadastro de Produtos: Operações de criação, leitura, atualização e exclusão (CRUD).
Filtragem Avançada: Consulta de produtos com filtros por descrição, status, datas de fabricação e validade, fornecedor, etc.
Paginação de Resultados: Retorno paginado para listagens de produtos.
Validações: Verificação de campos obrigatórios e regras de negócio no servidor.
Segurança: Implementação básica de segurança com autorização e autenticação (se aplicável).  

## Configuração do Banco de Dados:

Configure a conexão com o banco de dados MySQL no arquivo appsettings.json.
Executar a Aplicação:

Build e execute a aplicação utilizando Visual Studio ou CLI do .NET:
Consulte os endpoints disponíveis e teste as operações CRUD e consultas avançadas pelo Swagger.

## Contribuições
Contribuições são bem-vindas! Se encontrar algum problema ou tiver sugestões, por favor, abra uma issue ou envie um pull request.
