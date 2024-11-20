### Arquitetura DDD dot.net core 3.1

# README

- Api.Domain
  1 - Entity (Entidades)
  2 - Dtos
  3 - Interfaces
  4 - Models

- Api.Data
  1 - Mapping Entities (Mapear las Entidades)
  2 - Create Seeds y add
  3 - MyContext (Pasta Context)
  3.1 - cambiar la base de datos 
  4 - hacer Migraciones
  5 - Actualizar el Banco de Datos -- dotnet ef Migration add "nombre-migration" -- dotnet ef database update
  6 - Implementations (Implementaçao da classe baseEntity)
  --- 6.1 - Api.Domain.Repository --"No es en Api.Data"
  --- 6.2 - Api.Data.Implementations

- Data.Test
  1 - Teste de todos os Métodos da BaseRepository
  2 - Teste de todos os Métodos da Implementations

- Api.CrossCutting - corte cruzado
  1 - Mappings/DtoToModelProfile
  2 - Mappings/EntityToDtoProfile
  3 - Mappings/ModelToEntityProfile

- Api.Service
  1 - Criar services

- Api.Service.Test
  1 - Testes do AutoMapper
  2 - Teste dos Services com Mock de Service (Retornando repositorio Faker)

- Api.CrossCutting
  1 - Configure Repository
  2 - Configure Service

- Api.Application
  1 - Controller

  ***
