using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public class CurtidasPSeeds
    {
        public static void CurtidasP(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurtidasPEntity>().HasData(

                //Morango -------------------------------------------------------------------
                new CurtidasPEntity
                {
                    Id = new Guid("18767bac-7df0-4440-9350-bdca9156f101"),
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f"),
                },
                new CurtidasPEntity
                {
                    Id = new Guid("f40f4ebe-562b-499c-a864-1680e68a2daf"),
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("2b41a659-ab8d-472a-beb1-113d705ee182")

                },
                new CurtidasPEntity
                {
                    Id = new Guid("568d65f8-de59-4e7e-ae1f-3c4d7bb7fa26"),
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3")

                },
                new CurtidasPEntity
                {
                    Id = new Guid("bc8f4707-8905-4b57-8d3b-a2cd116b3014"),
                    ProdutosId = new Guid("15629bf1-bd06-49cb-8a97-71881fe7611d"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a"),

                },

                //Morango -------------------------------------------------------------------
                new CurtidasPEntity
                {
                    Id = new Guid("1f315cc2-7568-4aeb-ab63-2d5ef03178ed"),
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("5fca95dd-f72a-4069-981f-84a6288523b6"),
                },
                new CurtidasPEntity
                {
                    Id = new Guid("3b81d31f-c640-4fd5-9143-baaf516fe525"),
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("c1c2b571-3619-4e9b-923a-87b9c1cd0772"),
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("20bb63f5-e06e-49df-92bb-03263e6f47c4"),
                    ProdutosId = new Guid("43287a49-057e-4552-9b44-e0f5e8dcf9c2"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("2b41a659-ab8d-472a-beb1-113d705ee182")
                },

                //Bananas -------------------------------------------------------------------
                new CurtidasPEntity
                {
                    Id = new Guid("4da333bd-7b36-469c-ab22-8b571cd33bee"),

                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("db5da92d-06b8-4d18-bea2-5da409bcc791"),
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("2b41a659-ab8d-472a-beb1-113d705ee182")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("279c699e-81dc-4130-a383-d7bd9c77308b"),
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("8cb4d91b-05a0-4507-b81e-438c2febb856"),
                    ProdutosId = new Guid("5d0c3f02-7d4e-449b-aba4-dd560dc5e080"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a")
                },

                //Batata -------------------------------------------------------------------
                new CurtidasPEntity
                {
                    Id = new Guid("81b1deac-d685-47b5-b69a-946e0846117a"),
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("5fca95dd-f72a-4069-981f-84a6288523b6")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("78ed3153-a867-4220-9363-7173da47e950"),
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("d0bffa78-e158-4d3a-8022-1dfebc303abb"),
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("d8a65088-b386-4483-a84e-a5616063b634"),
                    ProdutosId = new Guid("8944a343-abe1-4c1d-91a9-c4574b257861"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("2b41a659-ab8d-472a-beb1-113d705ee182")
                },

                //Tomate -------------------------------------------------------------------
                new CurtidasPEntity
                {
                    Id = new Guid("272c14a3-64ee-483b-acc7-cc23e5c2b188"),
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("370e80ff-d01f-4645-915c-b9c4d46ee13f")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("1e18eba1-d62d-434b-a427-733de0633bcd"),
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("2b41a659-ab8d-472a-beb1-113d705ee182")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("7e483a33-0a8a-47ff-a973-f0526ca12e99"),
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("df8d4849-734a-4fb4-9d48-eeda37e288d3")
                },
                new CurtidasPEntity
                {
                    Id = new Guid("f3d6e14d-6ce4-4ac7-8b3f-a962e358c472"),
                    ProdutosId = new Guid("c42eb999-17f5-45d3-81e9-aa0506d9d534"),
                    CreateAt = DateTime.Now,
                    Curtidas = true,
                    UserId = new Guid("aed1bc34-5f9f-4380-8852-79c55dcd051a")
                }
            );

        }
    }
}
