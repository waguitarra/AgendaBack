

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
    public class ProdutosImplementation : BaseRepository<ProdutosEntity>, IUProdutosRepository
    {
        private DbSet<ProdutosEntity> _dataset;

        public ProdutosImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProdutosEntity>();
        }

        public async Task<ProdutosEntity> GetCompleteByCategoria(Guid categoriaId)
        {
            return await _dataset.Include(p => p.Categoria)
                        .FirstOrDefaultAsync(c => c.CategoriaId.Equals(categoriaId));
        }

        public async Task<ProdutosEntity> GetCompleteByTipoServico(Guid TipoServicoId)
        {
            return await _dataset.Include(p => p.TipoServico)
                      .FirstOrDefaultAsync(c => c.TipoServicoId.Equals(TipoServicoId));
        }

        public async Task<ProdutosEntity> GetCompleteByUser(Guid userId)
        {
            return await _dataset.Include(p => p.User)
                      .FirstOrDefaultAsync(c => c.UserId.Equals(userId));
        }

        public async Task<ProdutosEntity> GetCompleteByImagensP(Guid ProdutosId)
        {
            return await _dataset.Include(p => p.ImagensP)
                      .FirstOrDefaultAsync(c => c.Id.Equals(ProdutosId));
        }

        public async Task<ProdutosEntity> GetCompleteByMensagensP(Guid produtosId)
        {
            return await _dataset.Include(p => p.MensagensP)
                      .FirstOrDefaultAsync(c => c.Id.Equals(produtosId));
        }

        public async Task<ProdutosEntity> GetCompleteByCurtidasP(Guid produtosId)
        {
            return await _dataset.Include(p => p.CurtidasP)
                      .FirstOrDefaultAsync(c => c.Id.Equals(produtosId));

        }

        public async Task<ProdutosEntity> GetCompleteById(Guid ProdutosId)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.Id.Equals(ProdutosId));
        }

        public async Task<IEnumerable<ProdutosEntity>> GetAllMyProduto(Guid userId)
        {
            var response = await _dataset
                .Include(p => p.MensagensP)
                .Include(p => p.Categoria)
                .Include(p => p.TipoServico)
                .Include(p => p.User)
                .Include(p => p.Agente)
                .Include(p => p.ImagensP)
                .Include(p => p.DenunciaProdutoUsuario)
                .Where(p => p.User.Id == userId && p.Ativo == true && p.TipoServico.TipoCategoria != "Assunto Livre")                
                .ToListAsync();
            return response;
                                       
                
        }

        public async Task<ProdutosEntity> GetByMensagensPrivadas(Guid userId, Guid clienteUserId)
        {
            var produto = await _dataset
                .Include(p => p.DenunciaProdutoUsuario)
                .Include(p => p.MensagensP)
                        .ThenInclude(p => p.User)
                .Include(p => p.User)
                .Where(p => p.Id == clienteUserId)
                .FirstOrDefaultAsync();

            if (produto != null) 
            {
                produto.MensagensP = produto.MensagensP.OrderBy(p => p.CreateAt).ToList();
                return produto;
            }

                


            var response = await _dataset
                    .Include(p => p.DenunciaProdutoUsuario)
                    .Include(p => p.MensagensP)
                        .ThenInclude(p => p.User)
                    .Include(p => p.User)
                    .Where(p => p.UserId == userId
                    && p.ClienteUsuarioId == clienteUserId
                    || p.UserId == clienteUserId
                    && p.ClienteUsuarioId == userId
                    && p.Ativo == false
                    && p.NomeProduto == "Msg_Privadas"
                    && p.Descricao == "Msg_Privadas").FirstOrDefaultAsync();

            if (response != null)
            {
                response.MensagensP = response.MensagensP.OrderBy(p => p.CreateAt).ToList();
            }
            else {
                // Caso entra nas mensagens e já existe um produto cadastrado para esse usuario vamos devolver ja o produto com as mensagens
               var responseList =  await GetAllMensagensPrivadas(userId);

                foreach (var item in responseList)
                {
                    if (item.UserId == clienteUserId)
                    {
                        response = item;
                        break;
                    }
                    else 
                    {
                        foreach (var itemMsg in item.MensagensP)
                        {
                            if (item.UserId == clienteUserId || item.ClienteUsuarioId == clienteUserId)
                            {
                                response = item;
                                break;
                            }
                        }
                    }

                }
                if(response != null)
                    response.MensagensP = response.MensagensP.OrderBy(p => p.CreateAt).ToList();
            }
            
            return response;
        }

        public async Task<IEnumerable<ProdutosEntity>> GetAllMensagensPrivadas(Guid userId)
        {
            var response = await _dataset
                    .Include(p => p.DenunciaProdutoUsuario)
                    .Include(p => p.MensagensP)
                        .ThenInclude(p => p.User)
                        .ThenInclude(p => p.Produtos)
                    .Include(p => p.User)
                    .Include(p => p.ImagensP)
                    .Include(p => p.Categoria)           
                    .Include(p => p.TipoServico)
                    .Where(p => p.Ativo == false       
                    && p.UserId == userId
                    || p.ClienteUsuarioId == userId).ToArrayAsync();

            var response2 = response.Where(p => p.NomeProduto == "Msg_Privadas" && p.Descricao == "Msg_Privadas").ToList();
            return response2.OrderByDescending(c => c.CreateAt).ToList();
        }

        public async Task<int> GetQtdProdutosFinalizados(Guid userId)
        {
            var response = await _dataset.Include(p => p.User)
                .Where(p => p.Ativo == true 
                    && p.UserId == userId
                    && p.User.Ativo == true 
                    && p.ClienteUsuarioId != new Guid("00000000-0000-0000-0000-000000000000")
                    ).ToListAsync();
            return response.Count();
                
        }

        public async Task<IEnumerable<ProdutosEntity>> GetAllAssuntosLivres(Guid userId)
        {
            var response = await _dataset
                  .Include(p => p.DenunciaProdutoUsuario)
                    .Include(p => p.MensagensP)
                        .ThenInclude(p => p.User)
                        .ThenInclude(p => p.Produtos)
                    .Include(p => p.User)
                    .Include(p => p.ImagensP)
                    .Include(p => p.Categoria)
                    .Include(p => p.TipoServico)
               .Where(p => p.Ativo == true
                   && p.UserId == userId             
                   && p.TipoServico.TipoCategoria == "Assunto Livre"
                   ).ToListAsync();
            return response;
        }


        public async Task<IEnumerable<ProdutosEntity>> GetAllPesquisaIdioma(Guid userId)
        {
            var response = await _dataset
                .Include(p => p.DenunciaProdutoUsuario)
                .Include(p => p.MensagensP)
                    .ThenInclude(p => p.User)
                .Include(p => p.User)
                .Include(p => p.ImagensP)
                .Include(p => p.Categoria)
                .Include(p => p.TipoServico)
                .Where(p =>p.UserId == userId && p.Ativo == true && p.ImagensP.Any())
                .ToListAsync();
            return response;
        }

        public async Task<ProdutosEntity> GetPesquisaProduto(Guid id)
        {
            var response = await _dataset
                .Include(p => p.DenunciaProdutoUsuario)
                .Include(p => p.MensagensP)
                    .ThenInclude(p => p.User)
                .Include(p => p.User)
                .Include(p => p.Agente)
                .Include(p => p.ImagensP)
                .Include(p => p.Categoria)
                .Include(p => p.TipoServico)
                .Include(p => p.CurtidasP)
                .Where(p => p.Ativo == true && p.Id == id  &&  p.ImagensP.Any())
                .FirstOrDefaultAsync();
            return response;
        }

    }
}
