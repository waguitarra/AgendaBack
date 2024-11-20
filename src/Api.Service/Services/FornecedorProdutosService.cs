using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.FornecedorProdutosService;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{

    public class FornecedorProdutosService : IFornecedorProdutosService
    {
        private IUFornecedorProdutosRepository _repository;
        private IUImagensFRepository _ImagensFRepositorio;
        private IUUserFornecedorRepository _userRepositorio;
        private IUUserRepository _userClienteRepositorio;
        private IMapper _mapper;

        public FornecedorProdutosService(IUFornecedorProdutosRepository repository
                            , IMapper mapper
                            , IUImagensFRepository ImagensFRepositorio
                            , IUUserFornecedorRepository userRepositorio
                            , IUUserRepository userClienteRepositorio

                            )
        {
            _repository = repository;
            _mapper = mapper;
            _ImagensFRepositorio = ImagensFRepositorio;
            _userRepositorio = userRepositorio;
            _userClienteRepositorio = userClienteRepositorio;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<FornecedorProdutosDto> Get(Guid id)
        {

            var tb = await _repository.SelectAsync();
            var listEntity = await _repository.SelectAsync(id);
            if (listEntity != null)
            {
                //await _repository.GetCompleteByCategoria(listEntity.CategoriaId);
                //await _repository.GetCompleteByTipoServico(listEntity.TipoServicoId);
                await _repository.GetCompleteByImagensF(id);
                //await _repository.GetCompleteByMensagensP(id);


                //if (listEntity.MensagensP != null)
                //    foreach (var item in listEntity.MensagensP)
                //    {
                //        await _userRepositorio.GetCurtidasPPorUserId(item.UserId);
                //    }

                await _repository.GetCompleteByCurtidasP(id);
                await _repository.GetCompleteByUserFornecedor(listEntity.UserFornecedorId);

                if (listEntity.CurtidasP != null)
                {
                    listEntity.CurtidasP = listEntity.CurtidasP.AsQueryable().Where(p => p.Curtidas == true).ToList();
                    listEntity.CurtidasTotal = listEntity.CurtidasP.Count();
                }
                else
                {
                    listEntity.CurtidasTotal = 0;
                }
                return _mapper.Map<FornecedorProdutosDto>(listEntity);
            }

            return new FornecedorProdutosDto();
        }


        public async Task<IEnumerable<FornecedorProdutosDto>> GetAll(Guid userId)
        {
            //Trazendo usuario logado para calcular latitude longitude
            var listEntity = await _repository.SelectAsync();
            var listUserCliente = await _userClienteRepositorio.GetUserIdDadosBasicos(userId);

            //Ordenar a lista de produto e somente pode trazer FornecedorProdutos ativos
            listEntity = listEntity.AsQueryable().OrderBy(p => p.CreateAt).ToList().Where(a => a.Ativo == true).ToList();
            var userLogado = await _userClienteRepositorio.SelectAsync(userId);


            // caso usuario nao tem registro ñ deve apresentar nenhuma informaçao.
            if (userLogado != null)
            {
                foreach (var item in listEntity)
                {
                    //var denuncias = await _DenunciaProUsuario.GetUserFornecedorProdutos(userId, item.Id);
                    //if (item.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000") && denuncias == null)
                    //{
                    //await _repository.GetCompleteByCategoria(item.CategoriaId);
                    //await _repository.GetCompleteByTipoServico(item.TipoServicoId);
                    await _repository.GetCompleteByImagensF(item.Id);
                    await _repository.GetCompleteByImagensF(item.Id);

                    //if (item.MensagensP.Count() > 0)
                    //    foreach (var msg in item.MensagensP)
                    //    {
                    //        if (msg.IdProdutoUsuarioTroca != new Guid("00000000-0000-0000-0000-000000000000"))
                    //        {
                    //            msg.FornecedorProdutos = await _repository.SelectAsync(msg.IdProdutoUsuarioTroca);
                    //        }

                    //    }

                    var user = await _repository.GetCompleteByUserFornecedor(item.UserFornecedorId);
                    var curtidasFornecedorProdutos = await _repository.GetCompleteByCurtidasP(item.Id);

                    //Trazendo somente as curtidas que está como true.
                    if (curtidasFornecedorProdutos.CurtidasP != null)
                    {
                        curtidasFornecedorProdutos.CurtidasP = curtidasFornecedorProdutos.CurtidasP.AsQueryable().Where(p => p.Curtidas == true).ToList();
                        item.CurtidasTotal = curtidasFornecedorProdutos.CurtidasP.Count();
                    }
                    else
                    {
                        item.CurtidasTotal = 0;
                    }

                    var UserProduto = await _userRepositorio.GetProdutoPorUserId(item.UserFornecedorId);

                    if (userLogado.Latitude != 0 && userLogado.Longitude != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                    {
                        var kilometros = ObtenerDistancia(userLogado.Latitude, userLogado.Longitude, UserProduto.Latitude, UserProduto.Longitude);
                        item.KM = kilometros;
                    }
                    //}


                }
                //Somente usuario ativo podem entrar na lista

                // listEntity = listEntity.AsQueryable().Where(c => c.Categoria != null && c.User.Ativo == true).OrderByDescending(p => p.CreateAt).ToList();
                return _mapper.Map<IEnumerable<FornecedorProdutosDto>>(listEntity.ToList());
            }

            return null;

        }

        public async Task<IEnumerable<FornecedorProdutosDto>> GetAllMeusFornecedorProdutos(Guid userId)
        {
            var listEntity = await _repository.SelectAsync();
            var userLogado = await _userRepositorio.GetProdutoPorUserId(userId);

            if (userLogado == null)
            {
                return null;
            }

            var dadosLista = listEntity.AsQueryable().Where(p => p.UserFornecedorId == userLogado.Id).ToList();


            // somente dados do usuario logado
            if (userLogado != null)
            {
                foreach (var item in dadosLista)
                {
                    if (item.UserFornecedorId == userLogado.Id)
                    {
                        //await _repository.GetCompleteByCategoria(item.CategoriaId);
                        //await _repository.GetCompleteByTipoServico(item.TipoServicoId);
                        await _repository.GetCompleteByImagensF(item.Id);

                        //caso Produto já tenha vinculo com um usuario de troca todas as demais msg ñ será mais nescessaria.
                        //if (item.ClienteUsuarioId != new Guid("00000000-0000-0000-0000-000000000000"))
                        //    await _repository.GetCompleteByMensagensP(item.ClienteUsuarioId);
                        //else
                        //    await _repository.GetCompleteByMensagensP(item.Id);

                        //await _repository.GetCompleteByMensagensP(item.Id);
                        await _repository.GetCompleteByUserFornecedor(item.UserFornecedorId);
                        var curtidasFornecedorProdutos = await _repository.GetCompleteByCurtidasP(item.Id);

                        //Trasendo somente as curtidas que está como true.
                        if (curtidasFornecedorProdutos.CurtidasP != null)
                        {
                            curtidasFornecedorProdutos.CurtidasP = curtidasFornecedorProdutos.CurtidasP.AsQueryable().Where(p => p.Curtidas == true).ToList();
                            item.CurtidasTotal = curtidasFornecedorProdutos.CurtidasP.Count();
                        }
                        else
                        {
                            item.CurtidasTotal = 0;
                        }

                        var UserProduto = await _userRepositorio.GetProdutoPorUserId(item.UserFornecedorId);

                        if (userLogado.Latitude != 0 && userLogado.Longitude != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                        {
                            var kilometros = ObtenerDistancia(userLogado.Latitude, userLogado.Longitude, UserProduto.Latitude, UserProduto.Longitude);
                            item.KM = kilometros;
                        }
                    }

                }

                dadosLista.AsQueryable().OrderBy(p => p.CreateAt).ToList();

                return _mapper.Map<IEnumerable<FornecedorProdutosDto>>(dadosLista);
            }

            return null;

        }

        public async Task<FornecedorProdutosDtoCreateResult> Post(FornecedorProdutosDtoCreate FornecedorProdutos)
        {
            var userLogado = await _userRepositorio.GetProdutoPorUserId(FornecedorProdutos.UserFornecedorId);
            if (userLogado != null)
            {
                var entity = _mapper.Map<FornecedorProdutosEntity>(FornecedorProdutos);
                entity.Ativo = true;   
    
                var result = await _repository.InsertAsync(entity);
                _mapper.Map<FornecedorProdutosDtoCreateResult>(result);


                var ImagensF = FornecedorProdutos.ImagensF;

                if (ImagensF != null)
                    foreach (var item in ImagensF)
                    {
                        item.FornecedorProdutosId = result.Id;
                        var entityImagensF = _mapper.Map<ImagensFEntity>(item);
 
                        await _ImagensFRepositorio.InsertAsync(entityImagensF);
                    }

                return _mapper.Map<FornecedorProdutosDtoCreateResult>(result);
            }
            return null;

        }

        public async Task<FornecedorProdutosDtoUpdateResult> Put(FornecedorProdutosDtoUpdate FornecedorProdutos)
        {
            var userLogado = await _userRepositorio.GetProdutoPorUserId(FornecedorProdutos.UserFornecedorId);
            if (userLogado != null)
            {
                var entity = _mapper.Map<FornecedorProdutosEntity>(FornecedorProdutos);
       
                var result = await _repository.UpdateAsync(entity);
                var FornecedorProdutos_ = _mapper.Map<FornecedorProdutosDtoUpdateResult>(result);

                var ImagensF = FornecedorProdutos.ImagensF;
                foreach (var item in ImagensF)
                {
                    var entityImagensF = _mapper.Map<ImagensFEntity>(item);

                    await _ImagensFRepositorio.UpdateAsync(entityImagensF);

                }

                //await _repository.GetCompleteByCategoria(FornecedorProdutos.CategoriaId);


                return _mapper.Map<FornecedorProdutosDtoUpdateResult>(result);
            }
            return null;

        }

        public async Task<FornecedorProdutosDto> GetCompleteByUser(Guid UserId)
        {
            var listEntity = await _repository.SelectAsync(UserId);
            return _mapper.Map<FornecedorProdutosDto>(listEntity);
        }


        //Para calcular Latitude e Longitude

        public double ObtenerDistancia(double lat1, double lng1, double lat2, double lng2)
        {
            double RadioTierra = 6371;
            double distance = 0.000;
            double Lat = (lat2 - lat1) * (Math.PI / 180);
            double Lon = (lng2 - lng1) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = RadioTierra * c;

            return Math.Round(distance, 3);
        }

    }
}
