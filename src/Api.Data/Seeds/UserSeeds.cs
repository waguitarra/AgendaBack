using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class UserSeeds
    {
        public static void User(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(

                new UserEntity
                {
                    Id = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f"),
                    Password = "1eL3ENP4IcmdjfH6nPkaaegqO0IAYeriDVGJoPfRmZ8=",
                    Email = "wagner@teste.com",
                    Nome = "Wagner Figueiredo",
                    Sexo = "M",
                    Estado = "Sao paulo",
                    CodEstado = "SP",
                    CreateAt = DateTime.Now,
                    Latitude = 39.461472,
                    Longitude = -0.384608,
                    Tipo = "f336",
                    ImagemLogin = "https://i.pinimg.com/originals/c7/33/25/c73325509a652d7524ad3d7952c6e438.jpg",
                    TokenRedes = "fOfDpFZW3W78+5ZIDAC6d9F2DX4MMnadjy7EmIiNF1k=",
                    Ativo = true,
                    UpdateAt = DateTime.Now,
                    UserLogado = DateTime.Now,

                },

                new UserEntity
                {
                    Id = new Guid("2b41a659-ab8d-472a-beb1-113d705ee182"),
                    Password = "1eL3ENP4IcmdjfH6nPkaaegqO0IAYeriDVGJoPfRmZ8=",
                    Email = "monica@teste.com",
                    Nome = "Monica Silva",
                    Sexo = "F",
                    CreateAt = DateTime.Now,
                    Estado = "Minas",
                    CodEstado = "MG",
                    Latitude = 37.461472,
                    Longitude = -0.684608,
                    Tipo = "user",
                    ImagemLogin = "https://e7.pngegg.com/pngimages/78/110/png-clipart-dragon-ball-super-goku-super-saiyan-bulma-goku-child-face.png",
                    TokenRedes = "fOfDpFZW3W78+5ZIDAC6d9F2DX4MMnadjy7EmIiNF1k=",
                    Ativo = true,
                    UpdateAt = DateTime.Now,
                    UserLogado = DateTime.Now,
                },

                new UserEntity
                {
                    Id = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3"),
                    Password = "1eL3ENP4IcmdjfH6nPkaaegqO0IAYeriDVGJoPfRmZ8=",
                    Email = "Valter@teste.com",
                    Nome = "Valter Budaria",
                    Sexo = "M",
                    Estado = "Sao paulo",
                    CodEstado = "Sao paulo",
                    CreateAt = DateTime.Now,
                    Latitude = 38.461472,
                    Longitude = -0.389608,
                    Tipo = "user",
                    ImagemLogin = "https://e7.pngegg.com/pngimages/189/968/png-clipart-vegeta-goku-gohan-bulma-chi-chi-goku-face-head.png",
                    TokenRedes = "fOfDpFZW3W78+5ZIDAC6d9F2DX4MMnadjy7EmIiNF1k=",
                    Ativo = true,
                    UpdateAt = DateTime.Now,
                    UserLogado = DateTime.Now,
                },
                new UserEntity
                {
                    Id = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a"),
                    Password = "1eL3ENP4IcmdjfH6nPkaaegqO0IAYeriDVGJoPfRmZ8=",
                    Email = "Marcos@teste.com",
                    Nome = "Marcos James",
                    Sexo = "M",
                    CreateAt = DateTime.Now,
                    Estado = "Rio de Janeiro",
                    CodEstado = "RJ",
                    Latitude = 39.471846,
                    Longitude = -1.187272,
                    Tipo = "user",
                    ImagemLogin = "https://w7.pngwing.com/pngs/835/961/png-transparent-gohan-goku-vegeta-trunks-super-saiya-goku-face-shading-human.png",
                    TokenRedes = "fOfDpFZW3W78+5ZIDAC6d9F2DX4MMnadjy7EmIiNF1k=",
                    Ativo = true,
                    UpdateAt = DateTime.Now,
                    UserLogado = DateTime.Now,
                },
                new UserEntity
                {
                    Id = new Guid("5fca95dd-f72a-4069-981f-84a6288523b6"),
                    Password = "1eL3ENP4IcmdjfH6nPkaaegqO0IAYeriDVGJoPfRmZ8=",
                    Email = "Andreia@teste.com",
                    Nome = "Andreia",
                    Sexo = "F",
                    CreateAt = DateTime.Now,
                    Estado = "Piauí",
                    CodEstado = "PI",
                    Latitude = 39.481472,
                    Longitude = -1.384608,
                    Tipo = "user",
                    ImagemLogin = "https://w7.pngwing.com/pngs/491/214/png-transparent-bulma-trunks-goku-vegeta-majin-buu-dragon-ball-bulma-face-cg-artwork-black-hair.png",
                    TokenRedes = "fOfDpFZW3W78+5ZIDAC6d9F2DX4MMnadjy7EmIiNF1k=",
                    Ativo = true,
                    UpdateAt = DateTime.Now,
                    UserLogado = DateTime.Now,
                }
           );
        }

    }
}

