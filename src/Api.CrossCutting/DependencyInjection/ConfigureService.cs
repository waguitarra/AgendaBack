
using Api.Domain.Interfaces.Services.Agente;
using Api.Domain.Interfaces.Services.Categorias;
using Api.Domain.Interfaces.Services.Cliente;
using Api.Domain.Interfaces.Services.CuntidasP;
using Api.Domain.Interfaces.Services.DenunciaProdutoUsuario;
using Api.Domain.Interfaces.Services.Denuncias;
using Api.Domain.Interfaces.Services.FornecedorProdutosService;
using Api.Domain.Interfaces.Services.ImagensF;
using Api.Domain.Interfaces.Services.ImagensP;
using Api.Domain.Interfaces.Services.MensagensP;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Interfaces.Services.TipoServico;
using Api.Domain.Interfaces.Services.UseFornecedor;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Domain.Interfaces.Services.EmailsNewsletter;
using Domain.Interfaces.Services.GoogleCalendar;
using Domain.Interfaces.Services.TermosResponsabilidades;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Google;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ICategoriasService, CategoriaService>();
            serviceCollection.AddTransient<IClientesService, ClienteService>();
            serviceCollection.AddTransient<IImagensPService, ImagensPService>();
            serviceCollection.AddTransient<IProdutosService, ProdutosService>();
            serviceCollection.AddTransient<ITipoServicoService, TipoServicoService>();
            serviceCollection.AddTransient<IMensagensPService, MensagensPService>();
            serviceCollection.AddTransient<ICurtidasPService, CurtidasPService>();
            serviceCollection.AddTransient<IDenunciasService, DenunciaService>();
            serviceCollection.AddTransient<IUUserFornecedorService, UserFornecedorService>();
            serviceCollection.AddTransient<IDenunciaProdutoUsuarioService, DenunciaProdutoUsuarioService>();
            serviceCollection.AddTransient<IFornecedorProdutosService, FornecedorProdutosService>();
            serviceCollection.AddTransient<IImagensFService, ImagensFService>();
            serviceCollection.AddTransient<ITermosResponsabilidadesService, TermosResponsabilidadesService>();
            serviceCollection.AddTransient<IEmailsNewsletterService, EmailsNewsletterService>();
            serviceCollection.AddTransient<IConteudoCategoriaService, ConteudoCategoriaService>();
            serviceCollection.AddTransient<IConteudosService, ConteudosService>();
            serviceCollection.AddTransient<IImagensConteudosService, ImagensConteudosService>();
            serviceCollection.AddTransient<ICurtidasConteudosService, CurtidasConteudosService>();
            serviceCollection.AddTransient<IGoogleCalendarService, GoogleCalendarService>();
            serviceCollection.AddTransient<IAgenteService, AgenteService>();
            serviceCollection.AddTransient<IAgendaAgenteService, AgendaAgenteService>();

        }
    }
}
