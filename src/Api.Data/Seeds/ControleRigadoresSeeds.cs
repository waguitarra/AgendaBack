using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class ControleRigadoresSeeds
    {
        public static void ControleRigadores(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControleRigadoresEntity>().HasData(

                new ControleRigadoresEntity
                {

                    Id = new Guid("6b7510e0-7c60-4746-95a9-fa784cfec469"),
                    Email = "wagner@teste.com",
                    Password = "123456789",
                    Mac = "7c60-4746-95a9-6b7510e0-fa784cfec469",
                    Cabecario = "NFC",
                    Humidade = "070",
                    Temperatura = "030",
                    StatusBomba1 = "01",
                    StatusBomba2 = "01",
                    NivelTanque1 = "010",
                    NivelTanque2 = "023",
                    Fonte1 = "01",
                    Fonte2 = "01",
                    UserId = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f")

                }
           );
        }

    }
}

