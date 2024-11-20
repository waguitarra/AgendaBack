using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Seeds
{
    public class UserFornecedorSeeds
    {
        public static void UserFornecedor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFornecedorEntity>().HasData(

             new UserFornecedorEntity
             {
                 Id = new Guid("944f16b3-0a25-4282-a205-b8dad579b733"),
                 NomeEmpresa = "Macros Assessorias",
                 Email = "Macros@example.com",
                 Password = "string",
                 TokenRedes = "string",
                 CodRegistroEmpresas = "47.794.774/0001-03",
                 Endereco = "Rua manoel moreira de sá ",
                 Numero = "628",
                 Estado = "sao paulo",
                 CodEstado = "SP",
                 Latitude = 56.32652,
                 Longitude = -14.235,
                 LogoTipo = "https=//upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Logo_TV_2015.png/200px-Logo_TV_2015.png",
                 Telefone = "52525252525",
                 WhatsApp = "963963963",
                 Ativo = true
             },
            new UserFornecedorEntity
            {
                Id = new Guid("60653120-9e9b-4abc-9313-389c9f33e894"),
                NomeEmpresa = "Verdecora",
                Email = "Verdecora@example.com",
                Password = "string",
                TokenRedes = "string",
                CodRegistroEmpresas = "04.978.315/0001-69",
                Endereco = "Av Paulista ",
                Numero = "3232",
                Estado = "sao paulo",
                CodEstado = "SP",
                Latitude = -23.557482,
                Longitude = -46.660903,
                LogoTipo = "https=//www.alpearitana.com.br/public/blog/6/6-o-futuro-das-lojas-de-plantas_g.jpg",
                Telefone = "52525252525",
                WhatsApp = "963963963",
                Ativo = true

            },
            new UserFornecedorEntity
            {
                Id = new Guid("b0dfea77-feeb-4a8d-80d1-650964cffc53"),
                NomeEmpresa = "Jardim 360",
                Email = "360@example.com",
                Password = "string",
                TokenRedes = "string",
                CodRegistroEmpresas = "98.072.694/0001-77",
                Endereco = "Av Paulista ",
                Numero = "3200",
                Estado= "sao paulo",
                CodEstado = "SP",
                Latitude = -23.562858,
                Longitude = -46.654992,
                LogoTipo = "https=//uploads.metropoles.com/wp-content/uploads/2018/07/13135803/180711FC-roteiro-verde-037.jpg",
                Telefone = "52525252525",
                WhatsApp = "963963963",                
                Ativo = true
            },
            new UserFornecedorEntity
            {
                Id = new Guid("85074d64-456a-4307-b27b-bc31ced36eac"),
                NomeEmpresa = "Macros Assessorias",
                Email = "user@example.com",
                Password = "string",
                TokenRedes = "string",
                CodRegistroEmpresas = "26.604.370/0001-21",
                Endereco = "Av Paulista ",
                Numero = "2232",
                Estado= "sao paulo",
                CodEstado = "SP",
                Latitude = -23.565195,
                Longitude = -46.652087,
                LogoTipo = "https://dcomercio.com.br/public/upload/gallery/2018/vidaeestilo/17-these-startups-are-trying-to-disrupt-plants.jpg",
                Telefone = "52525252525",
                WhatsApp = "963963963",            
                Ativo = true
            },
            new UserFornecedorEntity
            {
                Id = new Guid("a27b37ee-e729-469e-9548-57813bcbd295"),
                NomeEmpresa = "Manga Rosa",
                Email = "Rosa@example.com",
                Password = "string",
                TokenRedes = "string",
                CodRegistroEmpresas = "44.960.589/0001-45",
                Endereco = "Av Paulista ",
                Numero = "1232",
                Estado= "sao paulo",
                CodEstado = "SP",
                Latitude = -23.568576,
                Longitude = -46.647940,
                LogoTipo = "https://conteudo.imguol.com.br/c/entretenimento/16/2017/08/23/botanista-1503502065225_v2_450x337.jpg",
                Telefone = "52525252525",
                WhatsApp = "963963963",             
                Ativo = true
            }

          );

        }
    }
}
