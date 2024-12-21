using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Data.Implementations;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IUCategoriaRepository, CategoriaImplementation>();
            serviceCollection.AddScoped<IUAgenteRepository, AgenteImplementation>();
            serviceCollection.AddScoped<IUAgenteProdutoRepository, AgenteProdutoImplementations>();
            serviceCollection.AddScoped<IUClienteRepository, ClienteImplementation>();
            serviceCollection.AddScoped<IUImagensPRepository, ImagensPImplementation>();
            serviceCollection.AddScoped<IUProdutosRepository, ProdutosImplementation>();
            serviceCollection.AddScoped<IUTipoServicoRepository, TipoServicoImplementation>();
            serviceCollection.AddScoped<IUMensagensPRepository, MensagensPImplementation>();
            serviceCollection.AddScoped<IUControleRigadoresRepository, ControleRigadoresImplementation>();
            serviceCollection.AddScoped<IUCurtidasPRepository, CurtidasPImplementation>();
            serviceCollection.AddScoped<IUDenunciasRepository, DenunciasImplementation>();
            serviceCollection.AddScoped<IUUserFornecedorRepository, UserFornecedorImplementation>();
            serviceCollection.AddScoped<IUDenunciaProdutoUsuarioRepository, DenunciaProdutoUsuarioImplementation>();
            serviceCollection.AddScoped<IUFornecedorProdutosRepository, FornecedorProdutosImplementation>();
            serviceCollection.AddScoped<IUImagensFRepository, ImagensFImplementation>();
            serviceCollection.AddScoped<IUTermosResponsabilidadesRepository, TermosResponsabilidadesImplementation>();
            serviceCollection.AddScoped<IUEmailsNewsletterRepository, EmailsNewsletterImplementation>();
            serviceCollection.AddScoped<IUConteudoCategoriaRepository, ConteudoCategoriaImplementation>();
            serviceCollection.AddScoped<IUConteudosRepository, ConteudosImplementation>();
            serviceCollection.AddScoped<IUImagensConteudosRepository, ImagensConteudosImplementation>();
            serviceCollection.AddScoped<IUCurtidasConteudosRepository, CurtidasConteudosImplementations>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
            );
            }
        }
    }
}
