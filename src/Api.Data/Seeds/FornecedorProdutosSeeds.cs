using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Seeds
{
    public class FornecedorProdutosSeeds
    {
        public static void FornecedorProdutos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FornecedorProdutosEntity>().HasData(

                new FornecedorProdutosEntity
                {
                    Id = new Guid("4851fe4c-7b26-441e-b090-f03d930e705c"),
                    NomeProdutoFornecedor = "Jadrim & CIA",
                    //CategoriaId = new Guid("07799b22-e49f-425a-84f8-938d7a6dfd2a"),
                    UserFornecedorId = new Guid("60653120-9e9b-4abc-9313-389c9f33e894"),
                    Descricao = "Estimativas on-line · Serviços no local",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new FornecedorProdutosEntity
                {
                    Id = new Guid("dd41a0f8-4bbc-4668-9ca3-0788defedfa0"),
                    NomeProdutoFornecedor = "Arvores e plantas & CIA",
                    //CategoriaId = new Guid("1c163e6a-4d86-4d5e-8089-54417724e7ae"),
                    UserFornecedorId = new Guid("85074d64-456a-4307-b27b-bc31ced36eac"),
                    Descricao = "Compras na loja · Retirada na porta · Entrega",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new FornecedorProdutosEntity
                {
                    Id = new Guid("c4406ef2-2e69-4530-828e-3fedd6dd66e7"),
                    NomeProdutoFornecedor = "Acessórios & CIA",
                    //CategoriaId = new Guid("2c6a159e-6285-4904-8234-f803d86a3de4"),
                    UserFornecedorId = new Guid("944f16b3-0a25-4282-a205-b8dad579b733"),
                    Descricao = "Compras na loja · Retirada na loja · Entrega",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new FornecedorProdutosEntity
                {
                    Id = new Guid("d36684ae-77b3-4885-b863-12f392fd5ae3"),
                    NomeProdutoFornecedor = "Jadrim e Acessórios",
                    //CategoriaId = new Guid("6b7510e0-7c60-4746-95a9-fa784cfec468"),
                    UserFornecedorId = new Guid("a27b37ee-e729-469e-9548-57813bcbd295"),
                    Descricao = "Compras na loja · Retirada na loja",
                    CreateAt = DateTime.Now,
                    Ativo = true
                },

                new FornecedorProdutosEntity
                {
                    Id = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
                    NomeProdutoFornecedor = "Acessórios para jardim",
                    //CategoriaId = new Guid("bf6a4111-23b4-4618-83f2-e1afaf78d062"),
                    UserFornecedorId = new Guid("b0dfea77-feeb-4a8d-80d1-650964cffc53"),
                    Descricao = "Compras na loja · Retirada na loja · Entrega",
                    CreateAt = DateTime.Now,
                    Ativo = true
                }

          );

        }
    }
}
