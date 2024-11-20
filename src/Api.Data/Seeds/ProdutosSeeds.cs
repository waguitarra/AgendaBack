using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Seeds
{
    public class ProdutosSeeds
    {
        public static void Produtos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutosEntity>().HasData(

                new ProdutosEntity
                {
                    Id = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    NomeProduto = "Tomate",
                    CategoriaId = new Guid("6b7510e0-7c60-4746-95a9-fa784cfec468"),
                    UserId = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f"),
                    TipoServicoId = new Guid("99227e7a-a5cf-4148-8a98-2fe0d6ce3299"),
                    Descricao = "Gostaria de mudas de Tomate ou Tomate maduros",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new ProdutosEntity
                {
                    Id = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    NomeProduto = "Batata",
                    CategoriaId = new Guid("07799b22-e49f-425a-84f8-938d7a6dfd2a"),
                    UserId = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f"),
                    TipoServicoId = new Guid("c22fb24f-82f9-4c48-b583-b598b04531d7"),        
                    Descricao = "Gostaria de mudas de Batata",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new ProdutosEntity
                {
                    Id = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    NomeProduto = "Banana",
                    CategoriaId = new Guid("1c163e6a-4d86-4d5e-8089-54417724e7ae"),
                    UserId = new Guid("5fca95dd-f72a-4069-981f-84a6288523b6"),
                    TipoServicoId = new Guid("3b2778ce-503d-4b49-b161-c54013d9d355"),   
                    Descricao = "Gostaria de mudas de bananas",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new ProdutosEntity
                {
                    Id = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    NomeProduto = "Morango",
                    CategoriaId = new Guid("bf6a4111-23b4-4618-83f2-e1afaf78d062"),
                    UserId = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3"),
                    TipoServicoId = new Guid("3b2778ce-503d-4b49-b161-c54013d9d355"),       
                    Descricao = "Gostaria de Morangos",
                    CreateAt = DateTime.Now,
                    Ativo = true

                },

                new ProdutosEntity
                {
                    Id = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    NomeProduto = "Uva",
                    CategoriaId = new Guid("2c6a159e-6285-4904-8234-f803d86a3de4"),
                    UserId = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a"),
                    TipoServicoId = new Guid("3b2778ce-503d-4b49-b161-c54013d9d355"),
                    Descricao = "Gostaria de mudas de Uva",
                    CreateAt = DateTime.Now,
                    Ativo = true
                }

          );

        }
    }
}
