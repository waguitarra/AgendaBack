using System;
using Api.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class TermosResponsabilidadesSeeds
    {
        public static void TermosResponsabilidades(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TermosResponsabilidadesEntity>().HasData(
                new TermosResponsabilidadesEntity
                {
                    Id = new Guid("6b7510e0-7c60-4746-95a9-fa784cfec468"),
                    Responsabilidades = "Todos"    
                }              
           );
        }

    }
}
