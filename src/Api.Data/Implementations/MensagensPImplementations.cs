using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class MensagensPImplementation : BaseRepository<MensagensPEntity>, IUMensagensPRepository
    {
        private DbSet<MensagensPEntity> _dataset;
        private DbSet<ProdutosEntity> _responseProduto;
        public MensagensPImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MensagensPEntity>();
            _responseProduto = context.Set<ProdutosEntity>();
        }
        enum TipoServicoEnum
        {
           Duvidas,
           Trocas,
           Doacoes
        }


        public async Task<MensagensPEntity> GetCompleteByProdutos(Guid ProdutosId)
        {
            return await _dataset.Include(p => p.Produtos)
                   .FirstOrDefaultAsync(c => c.Mensagens.Equals(ProdutosId));
        }

        public async Task<MensagensPEntity> GetCompleteByMensagensPUser(Guid UserId)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.UserId.Equals(UserId));
        }


        public async Task<IEnumerable<MensagensPEntity>> GetAllByMensagensPUser(Guid UserId, int TipoServico)
        {
        var list = await _dataset
            .Include(p => p.User)
            .Include(p => p.Produtos)
            .Include(p => p.Produtos.MensagensP)
            .Include(p => p.Produtos.Categoria)
            .Include(p => p.Produtos.ImagensP)
            .Include(p => p.Produtos.User)
            .Include(p => p.Produtos.TipoServico)
            .Include(p => p.Produtos.DenunciaProdutoUsuario)
            .Where(p => p.Produtos.DenunciaProdutoUsuario.Count() == 0
                                    && p.UserId == UserId                                 
                                    || p.ClienteUsuarioId == UserId
                                    && p.User.Ativo == true
                                    && p.Produtos.Ativo == true
                                    )
            .ToListAsync();

            var result = list.Where(p => p.Produtos.TipoServico.TipoCategoria == servicoTipo(TipoServico)).ToList();

            return result;
        }



        public async Task<bool> GetAllBMensagensNaoLidas(Guid UserId)
        {
            DateTime dataAtual = DateTime.Now;
            var resultMsg = false;
            var list = await _dataset
                .Include(p => p.User)
                .Include(p => p.Produtos)
                .Include(p => p.Produtos.MensagensP)
                .Include(p => p.Produtos.Categoria)
                .Include(p => p.Produtos.ImagensP)
                .Include(p => p.Produtos.User)
                .Include(p => p.Produtos.TipoServico)
                .Include(p => p.Produtos.DenunciaProdutoUsuario)
                .Where(p => p.Produtos.DenunciaProdutoUsuario.Count() == 0
                                        && p.UserId == UserId
                                        || p.ClienteUsuarioId == UserId
                                        && p.User.Ativo == true
                                        && p.User.EnviarEmail == true
                                        && p.Produtos.Ativo == true
                                        )
                .ToListAsync();

            var result = list.Where(p => p.MensagenLida == false).ToList();

            // Obter a data de hoje
            DateTime hoje = DateTime.Today;

            // Subtrair 7 dias da data de hoje
            DateTime dataAnterior = hoje.AddDays(-7);

            foreach (var item in result)
            {
                if (item.CreateAt < dataAnterior)
                {
                    resultMsg = true;
                    break;
                }
       
            }

            return resultMsg;
        }


        public async Task<int> GetCountMensagensUnico(Guid UserId, int TipoServico)
        {
            var result = await _dataset
              .Include(p => p.User)
              .Include(p => p.Produtos)
              .Include(p => p.Produtos.MensagensP)
              .Include(p => p.Produtos.Categoria)
              .Include(p => p.Produtos.ImagensP)
              .Include(p => p.Produtos.User)
              .Include(p => p.Produtos.TipoServico)
              .Include(p => p.Produtos.DenunciaProdutoUsuario)
              .Where(p => p.Produtos.TipoServico.TipoCategoria == servicoTipo(TipoServico)
                                      //&& p.Produtos.DenunciaProdutoUsuario.Count() == 0
                                      && p.UserId == UserId
                                      && p.Produtos.Ativo == true
                                      && p.User.Ativo == true               
                                      || p.ClienteUsuarioId == UserId)
              .ToListAsync();
            result.Select(p => p.Produtos.MensagensP.Where(e => e.MensagenLida == true)).ToList();
            return result.Count();
        }


        public string servicoTipo(int TipoServico) 
        {
            string servico = "";

            if (((int)TipoServicoEnum.Duvidas) == TipoServico)
                servico = "Duvidas";
            if (((int)TipoServicoEnum.Trocas) == TipoServico)
                servico = "Trocas";
            if (((int)TipoServicoEnum.Doacoes) == TipoServico)
                servico = "Doações";

            return servico;
        }


        public async Task<int> GetCountMensagensAll(Guid UserId)
        {

            int resultmensagens = 0; 
            var result = await _responseProduto
                .Include(p => p.User)
                .Include(p => p.MensagensP)
                .Include(p => p.Categoria)
                .Include(p => p.ImagensP)
                .Include(p => p.User)
                .Include(p => p.TipoServico)
                .Include(p => p.DenunciaProdutoUsuario)
                .Where(p => p.UserId == UserId
                                        || p.ClienteUsuarioId == UserId
                                        && p.Ativo == true                       
                                        && p.User.Ativo == true                                           
                                        ).ToListAsync();


            foreach (var item in result)
            {  
                foreach (var itemList in item.MensagensP)
                {
                    if (itemList.MensagenLida == false &&  itemList.UserId != UserId)
                    {
                        resultmensagens = resultmensagens + 1;
                    }
                }
            }

            return resultmensagens;
        }

        public async Task<IEnumerable<MensagensPEntity>> GetMensagensAllNoLida(Guid UserId)
        {
            //para que localiza as mensagens que ainda ñ foram lidas
             return await _dataset
              .Include(p => p.User)
              .Include(p => p.Produtos)
              .Include(p => p.Produtos.MensagensP)
              .Include(p => p.Produtos.Categoria)
              .Include(p => p.Produtos.ImagensP)
              .Include(p => p.Produtos.User)
              .Include(p => p.Produtos.TipoServico)
              .Include(p => p.Produtos.DenunciaProdutoUsuario)
              .Where(p => p.UserId != UserId
                                       && p.ClienteUsuarioId == UserId
                                       && p.Produtos.Ativo == true
                                       && p.User.Ativo == true
                                       && p.MensagenLida == false
                                       && p.IdProdutoUsuarioTroca == new Guid("00000000-0000-0000-0000-000000000000")
                                       ).ToListAsync();

            
        }

    }
}
