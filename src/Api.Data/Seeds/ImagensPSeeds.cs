using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public class ImagensPSeeds
    {
        public static void ImagensP(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagensPEntity>().HasData(

                //Morango -------------------------------------------------------------------
                new ImagensPEntity
                {
                    Id = new Guid("18767bac-7df0-4440-9350-bdca9156f101"),
                    UrlImagens = "https://static8.depositphotos.com/1466240/984/i/600/depositphotos_9847088-stock-photo-fresh-strawberries.jpg",
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("f40f4ebe-562b-499c-a864-1680e68a2daf"),
                    UrlImagens = "https://static8.depositphotos.com/1020804/1063/i/600/depositphotos_10634883-stock-photo-strawberries-with-leaves.jpg",
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,

                },
                new ImagensPEntity
                {
                    Id = new Guid("568d65f8-de59-4e7e-ae1f-3c4d7bb7fa26"),
                    UrlImagens = "https://conteudo.imguol.com.br/c/entretenimento/78/2018/02/28/morango-1519823853148_v2_1920x1280.jpg",
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,

                },
                new ImagensPEntity
                {
                    Id = new Guid("bc8f4707-8905-4b57-8d3b-a2cd116b3014"),
                    UrlImagens = "https://sitionovavida.com.br/wp-content/uploads/2016/10/morango-emagrece.jpg",
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,

                },

                //Morango -------------------------------------------------------------------
                new ImagensPEntity
                {
                    Id = new Guid("1f315cc2-7568-4aeb-ab63-2d5ef03178ed"),
                    UrlImagens = "https://st2.depositphotos.com/3279657/5447/i/600/depositphotos_54478619-stock-photo-blue-wet-grapes-bunch-isolated.jpg",
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("3b81d31f-c640-4fd5-9143-baaf516fe525"),
                    UrlImagens = "https://www.embrapa.br/bme_images/m/173440040m.jpg",
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("c1c2b571-3619-4e9b-923a-87b9c1cd0772"),
                    UrlImagens = "https://abrafrutas.org/wp-content/uploads/2019/11/images-2.jpg",
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("20bb63f5-e06e-49df-92bb-03263e6f47c4"),
                    UrlImagens = "https://portalsete.com.br/wp-content/uploads/2016/11/beneficios-e-propriedades-da-uva-verde-para-o-intestino.jpg",
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                },

                //Bananas -------------------------------------------------------------------
                new ImagensPEntity
                {
                    Id = new Guid("4da333bd-7b36-469c-ab22-8b571cd33bee"),
                    UrlImagens = "https://static3.abc.es/media/familia/2019/05/30/diferencias-platano-banana-1-kka--620x349@abc.jpg",
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("db5da92d-06b8-4d18-bea2-5da409bcc791"),
                    UrlImagens = "https://static3.abc.es/media/familia/2019/05/30/diferencias-platano-banana-1-kka--620x349@abc.jpg",
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("279c699e-81dc-4130-a383-d7bd9c77308b"),
                    UrlImagens = "https://saude.abril.com.br/wp-content/uploads/2018/11/bananas.png",
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("8cb4d91b-05a0-4507-b81e-438c2febb856"),
                    UrlImagens = "https://upload.wikimedia.org/wikipedia/commons/4/4c/Bananas.jpg",
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                },

                //Batata -------------------------------------------------------------------
                new ImagensPEntity
                {
                    Id = new Guid("81b1deac-d685-47b5-b69a-946e0846117a"),
                    UrlImagens = "https://joseantonioarcos.es/wp-content/uploads/2019/07/Tomates.jpg",
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("78ed3153-a867-4220-9363-7173da47e950"),
                    UrlImagens = "https://www.65ymas.com/uploads/s1/22/69/84/tomate.jpeg",
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("d0bffa78-e158-4d3a-8022-1dfebc303abb"),
                    UrlImagens = "https://fundacion-antama.org/wp-content/uploads/2020/01/2020-Tomates.jpg",
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("d8a65088-b386-4483-a84e-a5616063b634"),
                    UrlImagens = "https://p2.trrsf.com/image/fget/cf/460/0/images.terra.com/2020/09/08/simpatias-com-batata-15842.jpg",
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                },

                //Tomate -------------------------------------------------------------------
                new ImagensPEntity
                {
                    Id = new Guid("272c14a3-64ee-483b-acc7-cc23e5c2b188"),
                    UrlImagens = "https://joseantonioarcos.es/wp-content/uploads/2019/07/Tomates.jpg",
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("1e18eba1-d62d-434b-a427-733de0633bcd"),
                    UrlImagens = "https://www.65ymas.com/uploads/s1/22/69/84/tomate.jpeg",
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("7e483a33-0a8a-47ff-a973-f0526ca12e99"),
                    UrlImagens = "https://fundacion-antama.org/wp-content/uploads/2020/01/2020-Tomates.jpg",
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                },
                new ImagensPEntity
                {
                    Id = new Guid("f3d6e14d-6ce4-4ac7-8b3f-a962e358c472"),
                    UrlImagens = "https://www.65ymas.com/uploads/s1/22/69/84/tomate.jpeg",
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                }









          );
        }
    }
}


