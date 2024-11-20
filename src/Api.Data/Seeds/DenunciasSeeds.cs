using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class DenunciasSeeds
    {
        public static void Denuncias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DenunciasEntity>().HasData(

                new DenunciasEntity
                {
                    Id = new Guid("7768ff25-0e5a-4738-ad07-1d7a21b82ccb"),
                    TipoDenuncias = "Sem denuncias",
                    Descricao = "Quando usuario está colocando imagens que nao faz parte de conteudo da App",
                    CreateAt = DateTime.Now,
                },

                new DenunciasEntity
                {

                    Id = new Guid("fbab81e7-6365-45f2-8379-aba617a7fa75"),
                    TipoDenuncias = "Imagens Indevidas",
                    Descricao = "Quando usuario está colocando imagens que nao faz parte de conteudo da App",
                    CreateAt = DateTime.Now,
                },

                new DenunciasEntity
                {
                    Id = new Guid("9052df67-aa86-41af-9656-ef96664ef0a7"),
                    TipoDenuncias = "Está vendendo",
                    Descricao = "Vendas nao sao permitidas",
                    CreateAt = DateTime.Now,

                },
                new DenunciasEntity
                {
                    Id = new Guid("1795db51-f854-4006-98a3-2ad1840a9dd0"),
                    TipoDenuncias = "Agressivo",
                    Descricao = "Usuario está postando algo muito agressivo",
                    CreateAt = DateTime.Now,
                },

                new DenunciasEntity
                {
                    Id = new Guid("d00ba4f3-fbb6-493a-89d6-248b529d70c1"),
                    TipoDenuncias = "Texto Agressivo",
                    Descricao = "Texto bem agressivo",
                    CreateAt = DateTime.Now,

                },

                new DenunciasEntity
                {
                    Id = new Guid("2e591d8a-b563-413b-a987-149a1b2e2a39"),
                    TipoDenuncias = "Nao tem respeito",
                    Descricao = "Usuario está faltando com respeito",
                    CreateAt = DateTime.Now,
                }

           );
        }

    }
}
