using Api.Data.Mapping;
using Api.Data.Seeds;
using Api.Domain.Entities;
using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriaEntity>(new CategoriaMap().Configure);
            modelBuilder.Entity<AgenteProdutosEntity>(new AgenteProdutoMap().Configure);
            modelBuilder.Entity<AgenteEntity>(new AgenteMap().Configure);
            modelBuilder.Entity<ClienteEntity>(new ClienteMap().Configure);
            modelBuilder.Entity<TipoServicoEntity>(new TipoServicoMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<ImagensPEntity>(new ImagensPMap().Configure);
            modelBuilder.Entity<ProdutosEntity>(new ProdutoMap().Configure);
            modelBuilder.Entity<MensagensPEntity>(new MensagensPMap().Configure);
            modelBuilder.Entity<ControleRigadoresEntity>(new ControleRigadoresMap().Configure);
            modelBuilder.Entity<CurtidasPEntity>(new CurtidasPMap().Configure);
            modelBuilder.Entity<DenunciasEntity>(new DenunciasMap().Configure);
            modelBuilder.Entity<UserFornecedorEntity>(new UserFornecedorMap().Configure);
            modelBuilder.Entity<DenunciaProdutoUsuarioEntity>(new DenunciaProdutoUsuarioMap().Configure);
            modelBuilder.Entity<FornecedorProdutosEntity>(new FornecedorProdutosMap().Configure);
            modelBuilder.Entity<ImagensFEntity>(new ImagensFMap().Configure);
            modelBuilder.Entity<TermosResponsabilidadesEntity>(new TermosResponsabilidadesMap().Configure);
            modelBuilder.Entity<EmailsNewsletterEntity>(new EmailsNewsletterMap().Configure);
            modelBuilder.Entity<ConteudoCategoriaEntity>(new ConteudoCategoriaMap().Configure);
            modelBuilder.Entity<ConteudosEntity>(new ConteudosMap().Configure);
            modelBuilder.Entity<ImagensConteudosEntity>(new ImagensConteudosMap().Configure);
            modelBuilder.Entity<CurtidasConteudosEntity>(new CurtidasConteudosMap().Configure);
        }
    }
}
