using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class TipoServicoSeends
    {
        public static void TipoServico(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoServicoEntity>().HasData(

                new TipoServicoEntity
                {
                    Id = new Guid("99227e7a-a5cf-4148-8a98-2fe0d6ce3299"),
                    TipoCategoria = "Trocas",
                    Descricao = "Categoria dedicada a trocas de plantas, arvores frutas e etc"

                },
                new TipoServicoEntity
                {
                    Id = new Guid("c22fb24f-82f9-4c48-b583-b598b04531d7"),
                    TipoCategoria = "Doações",
                    Descricao = "Categoria dedicada a Doações de plantas, arvores frutas e etc"

                },
                new TipoServicoEntity
                {
                    Id = new Guid("3b2778ce-503d-4b49-b161-c54013d9d355"),
                    TipoCategoria = "Duvidas",
                    Descricao = "Categoria dedicada a Duvidas de plantas, arvores frutas e etc"

                }

           );
        }

    }
}
