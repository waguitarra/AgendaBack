using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class CategoriaSeeds
    {
        public static void Categoria(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaEntity>().HasData(

                new CategoriaEntity
                {

                    Id = new Guid("6b7510e0-7c60-4746-95a9-fa784cfec468"),
                    TipoCategoria = "Todos",
                    Descricao = "Todas as categorias",
                    CreateAt = DateTime.Now,
                    UrlImagens = "http://es.dreamstime.com/planeta-verde-thumb15625832.jpg"

                },

                new CategoriaEntity
                {
                    Id = new Guid("07799b22-e49f-425a-84f8-938d7a6dfd2a"),
                    TipoCategoria = "Plantas",
                    Descricao = "Plantas en diversas ",
                    CreateAt = DateTime.Now,
                    UrlImagens = "https://drvictorsorrentino.com.br/wp-content/uploads/2017/11/beneficios-da-planta-moringa-1280x720.png"

                },
                new CategoriaEntity
                {
                    Id = new Guid("1c163e6a-4d86-4d5e-8089-54417724e7ae"),
                    TipoCategoria = "Arvores",
                    Descricao = "todos os tipos de arvoes",
                    CreateAt = DateTime.Now,
                    UrlImagens = "https://mood.sapo.pt/wp-content/uploads/2017/04/pexels-photo-238342.jpeg"

                },
                new CategoriaEntity
                {
                    Id = new Guid("bf6a4111-23b4-4618-83f2-e1afaf78d062"),
                    TipoCategoria = "arvores e plantas frutiferas",
                    Descricao = "Todas as categorias de plantas frutiferas",
                    CreateAt = DateTime.Now,
                    UrlImagens = "https://construindodecor.com.br/wp-content/uploads/2018/07/arvores-frutiferas-pitanga.jpg"

                },

                new CategoriaEntity
                {
                    Id = new Guid("2c6a159e-6285-4904-8234-f803d86a3de4"),
                    TipoCategoria = "Vegetais e Legumes",
                    Descricao = "Todos os tipos devegetais e legumes",
                    CreateAt = DateTime.Now,
                    UrlImagens = "https://cdn.diferenca.com/imagens/vegetables-226167-960-720-cke.jpg"
                }

           );
        }

    }
}
