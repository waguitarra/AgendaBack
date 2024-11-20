using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.MensagensP;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.EmailsNewsletter;
using Domain.Dtos.EnviarEmailDto;
using Domain.Dtos.MensagensP;
using Domain.Interfaces.Services.EmailsNewsletter;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using NLog;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class MensagensPService : IMensagensPService
    {
        IUMensagensPRepository _repository;
        private IMapper _mapper;
        IUUserRepository _repositoryUser;
        IUProdutosRepository _repositoryProduto;
        IUDenunciaProdutoUsuarioRepository _denunciaProdutoUsuarioRepository;
        IConfiguration _configuration;
        private static ProdutosEntity produtoEmailResponse;
        private static EmailsNewsletterDto emailsNewsletterDto;
        private static UserEntity userEmailResponse;
        private static string MensagensUsuario;
        private static string ProdutoMensagem;
        private IEmailsNewsletterService _emailsNewsletterService;
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();


        public MensagensPService(IUMensagensPRepository repository,
                                IMapper mapper,
                                IUUserRepository repositoryUser,
                                IUProdutosRepository repositoryProduto,
                                IUImagensPRepository repositoryImagens,
                                IUDenunciaProdutoUsuarioRepository repositoryDenunciaProdutoUsuarioRepository,
                                IConfiguration configuration,
                                IEmailsNewsletterService emailsNewsletterService
                                )
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryUser = repositoryUser;
            _repositoryProduto = repositoryProduto;
            _denunciaProdutoUsuarioRepository = repositoryDenunciaProdutoUsuarioRepository;
            _configuration = configuration;
            _emailsNewsletterService = emailsNewsletterService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MensagensPDto> Get(Guid Id)
        {
            var listEntity = await _repository.SelectAsync(Id);
            if (listEntity != null)
            {
                MensagensPDto listMensagens = new MensagensPDto();

                listEntity.User = await _repositoryUser.SelectAsync(listEntity.UserId);
                listEntity.Produtos = await _repositoryProduto.GetCompleteById(listEntity.ProdutosId);
                await _repositoryProduto.GetCompleteByImagensP(listEntity.IdProdutoUsuarioTroca);


                listMensagens = _mapper.Map<MensagensPDto>(listEntity);

                var listEntity2 = await _repository.SelectAsync(Id);

                listEntity2.User = await _repositoryUser.GetProdutoPorUserId(listEntity.ClienteUsuarioId);
                listEntity2.Produtos = await _repositoryProduto.GetCompleteByMensagensP(listEntity.IdProdutoUsuarioTroca);
                var imagens = await _repositoryProduto.GetCompleteByImagensP(listEntity.IdProdutoUsuarioTroca);


                listMensagens.UserCliente = _mapper.Map<MensagensPDto>(listEntity2).User;
                listMensagens.ProdutoCliente = _mapper.Map<MensagensPDto>(listEntity2).Produtos;

                return _mapper.Map<MensagensPDto>(listMensagens);
            }
            return new MensagensPDto();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MensagensPDto>> GetAll(Guid UserId)
        {

            var listEntity = await _repository.SelectAsync();
            var dados = listEntity.AsQueryable().Where(p => p.UserId == UserId).Where(p => p.IdProdutoUsuarioTroca != new Guid("00000000-0000-0000-0000-000000000000")).ToList();

            if (listEntity != null && dados.Count() > 0)
            {
                foreach (var item in dados)
                {
                    await _repositoryUser.SelectAsync(UserId);
                    await _repositoryProduto.GetCompleteByMensagensP(item.ProdutosId);
                    await _repositoryProduto.GetCompleteByImagensP(item.ProdutosId);

                }

                return _mapper.Map<IEnumerable<MensagensPDto>>(dados);

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private List<MensagensPClienteUserProdutoUserDto> EliminarDuplicidade(List<MensagensPClienteUserProdutoUserDto> msg) 
        {
            //Considerando que informaçao é duplicada quando ClienteId UserId sao as mesma infomaçoes
            List<MensagensPClienteUserProdutoUserDto> ResultMsg = new List<MensagensPClienteUserProdutoUserDto>();
            List<MensagensPClienteUserProdutoUserDto> ResultMsgFinal = new List<MensagensPClienteUserProdutoUserDto>();

            foreach (var list in msg)
            {
                if (ResultMsg.Count() == 0)
                {
                    ResultMsg.Add(list);
                }
                else
                    if (0 == ResultMsg.Where(p => p.UserId == list.UserId
                        && p.ProdutosId == list.ProdutosId
                        && p.clienteUsuarioId == list.clienteUsuarioId
                        && p.idProdutoUsuarioTroca == list.idProdutoUsuarioTroca).ToList().Count())
                    {
                    if (0 == ResultMsg.Where(p => p.clienteUsuarioId == list.UserId
                          && p.ProdutosId == list.ProdutosId
                          && p.clienteUsuarioId == list.UserId
                          && p.idProdutoUsuarioTroca == list.idProdutoUsuarioTroca).ToList().Count()) 
                        {
                            ResultMsg.Add(list);
                        }
                    }
                

            }
            return ResultMsg.Distinct().ToList();
        }


        /// <summary>
        /// Regras de mensagens por produtos e usuario de categorias Tipo de Serviço: Trocas, Doaçoes e Dúvidas.
        /// Cada cliente tem o seu produto con as mensagens recebida pelo produto, con UserId 
        /// vamos varrer todos os produtos desse usuario e depois separara por ProdutoId, ClienteUsuarioId e IdProdutoUsuarioTroca
        /// Dessa forma tenho uma convesa unica de cada produto por usuario 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>MensagensPClienteUserProdutoUserDto</returns>
        public async Task<IEnumerable<MensagensPPorUnicoUsuarioDto>> GetAllMensagensPUnicoUsuario(Guid UserId, Guid MyId)
        {
            _logge.Info($"UserId: {UserId} UserId: { MyId}");
            List< MensagensPPorUnicoUsuarioDto> resultMsg = new List<MensagensPPorUnicoUsuarioDto>();        
            List<MensagensPClienteUserProdutoUserDto> ClientesMgs = new List<MensagensPClienteUserProdutoUserDto>();
            List<MensagensPClienteUserProdutoUserDto> ReportDatosList = new List<MensagensPClienteUserProdutoUserDto>();

            List<MensagensPDto> mensagensP = new List<MensagensPDto>();

            var listEntity = await _repository.SelectAsync();
            var dados = listEntity.AsQueryable().Where(p => p.ClienteUsuarioId == UserId || p.UserId == UserId).ToList();

            foreach (var item in dados)
            {

                MensagensPClienteUserProdutoUserDto ReportDatos = new MensagensPClienteUserProdutoUserDto
                {
                    UserId = item.UserId,
                    ProdutosId = item.ProdutosId,
                    clienteUsuarioId = item.ClienteUsuarioId,
                    idProdutoUsuarioTroca = item.IdProdutoUsuarioTroca,
                };

                ReportDatosList.Add(ReportDatos);
            }

            var MyProdutcs = EliminarDuplicidade(ReportDatosList.AsQueryable().Where(x => x.UserId == UserId || x.clienteUsuarioId == UserId).ToList());

            if (ReportDatosList.Count == 1)
                MyProdutcs = ReportDatosList.AsQueryable().Where(x => x.UserId == UserId || x.clienteUsuarioId == UserId).ToList();
            
            ReportDatosList.Clear();
            foreach (var itemP in MyProdutcs)
            {
                ReportDatosList.Add(itemP);
            }

    

            foreach (var itemT in ReportDatosList)
            {
                MensagensPPorUnicoUsuarioDto Msg = new MensagensPPorUnicoUsuarioDto();

                var item = dados.Where(p => p.UserId == itemT.UserId
                                && p.ProdutosId == itemT.ProdutosId
                                && p.ClienteUsuarioId == itemT.clienteUsuarioId
                                && p.IdProdutoUsuarioTroca == itemT.idProdutoUsuarioTroca
                                ).FirstOrDefault();

                bool gatilho = true;      

                if (ClientesMgs.Count > 0)
                {
                    var MensagensRepetidaOrige = ClientesMgs.Where(p => p.clienteUsuarioId == item.ClienteUsuarioId
                                 && p.UserId == item.UserId
                                 && item.IdProdutoUsuarioTroca == p.idProdutoUsuarioTroca
                                 && p.ProdutosId == item.ProdutosId
                                 ).ToList();

                    var MensagensRepetida = ClientesMgs.Where(p => p.clienteUsuarioId == item.UserId
                                              && p.UserId == item.ClienteUsuarioId
                                              && item.IdProdutoUsuarioTroca == p.ProdutosId
                                              && p.idProdutoUsuarioTroca == item.ProdutosId
                                              ).ToList();

                    if (MensagensRepetida.Count() > 0 || MensagensRepetidaOrige.Count() > 0)
                        gatilho = false;
                }

                var user = await _repositoryUser.SelectAsync(item.UserId);
                await _repositoryProduto.GetCompleteByMensagensP(item.ProdutosId);
                await _repositoryProduto.GetCompleteByImagensP(item.ProdutosId);
                await _repositoryProduto.GetCompleteByUser(UserId);
                await _repositoryProduto.GetCompleteByTipoServico(item.Produtos.TipoServicoId);
                var denunciasProduto = await _denunciaProdutoUsuarioRepository.GetCompleteByProdutos(item.ProdutosId);
                var denunciasProdutoTroca = await _denunciaProdutoUsuarioRepository.GetCompleteByProdutos(item.IdProdutoUsuarioTroca);

                bool denuncias = false;
                if (denunciasProduto?.UserId == MyId || denunciasProdutoTroca?.UserId == MyId)
                {
                    denuncias = true;
                }

                if (gatilho && item.Produtos.TipoServico.TipoCategoria == "Trocas" && denuncias == false)
                {
                    List<MensagensPBasicoDto> ListMensagens = new List<MensagensPBasicoDto>();

                    Msg.Id = item.Id;
                    Msg.UserId = item.UserId;
                    Msg.ProdutosId = item.ProdutosId;
                    Msg.UserName = user.Nome;
                    var categoria = await _repositoryProduto.GetCompleteByCategoria(item.Produtos.CategoriaId);
                    var tipoServicio = await _repositoryProduto.GetCompleteByTipoServico(item.Produtos.TipoServicoId);
                    Msg.Categoria = categoria.Categoria.TipoCategoria;
                    Msg.TipoServico = tipoServicio.TipoServico.TipoCategoria;

                    if (user.UserLogado != null)         
                        Msg.UserLogado = (DateTime)user.UserLogado;
                    Msg.UserImagem = user.ImagemLogin;
                    Msg.Produtos = _mapper.Map<ProdutosDtoBasic>(item.Produtos);

                    Msg.clienteUsuarioId = item.ClienteUsuarioId;


                    var UserCliente = await _repositoryUser.SelectAsync(item.ClienteUsuarioId);
                    Msg.UserClienteName = UserCliente.Nome;
                    Msg.UserClienteImagem = UserCliente.ImagemLogin; 
                    Msg.idProdutoUsuarioTroca = item.IdProdutoUsuarioTroca;
                    if (UserCliente.UserLogado != null)
                        Msg.UserClienteLogado = (DateTime)UserCliente.UserLogado;
                    var ProdutoCliente = await _repositoryProduto.GetCompleteByImagensP(item.IdProdutoUsuarioTroca);

                    var validador = ClientesMgs.Where(p => p.clienteUsuarioId == Msg.clienteUsuarioId 
                                                        && p.idProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca 
                                                        && p.UserId == Msg.UserId
                                                        && p.ProdutosId == Msg.ProdutosId
                                                        );

                    if (validador.Count() == 0)
                    {

                        foreach (var ItemMsg in dados.Where(p => p.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && p.Produtos != null).ToList())
                        {
                            if (ItemMsg.Produtos == null)
                                ItemMsg.Produtos = await _repositoryProduto.SelectAsync(ItemMsg.ProdutosId);

                            MensagensPBasicoDto tbb = (MensagensPBasicoDto)ListMensagens.Where(p => p.Id == ItemMsg.Id).FirstOrDefault();
                            if (tbb == null)
                            {

                                if (ItemMsg.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && ItemMsg.ProdutosId == Msg.ProdutosId && ItemMsg.Produtos.TipoServico.TipoCategoria == "Trocas")
                                {
                                    if (ItemMsg.ClienteUsuarioId == UserId)
                                    {
                                        MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                        {
                                            Id = ItemMsg.Id,
                                            UserName = ItemMsg.User.Nome,
                                            UserId = ItemMsg.User.Id,
                                            Mensagens = ItemMsg.Mensagens,
                                            UrlImagem = ItemMsg.User.ImagemLogin,
                                            MensagemUserIdPrincipal = false,
                                            MensagenLida = ItemMsg.MensagenLida,
                                            CreateAt = (DateTime)ItemMsg.CreateAt,
                                        };
                                        ListMensagens.Add(_dtoMsg);
                                    }

                                }

                            }

                        }


                        foreach (var ItemMsg in dados.Where(p => p.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && p.Produtos != null).ToList())
                        {
                            if (ItemMsg.Produtos == null)
                                ItemMsg.Produtos = await _repositoryProduto.SelectAsync(ItemMsg.ProdutosId);

                            MensagensPBasicoDto tbb = (MensagensPBasicoDto)ListMensagens.Where(p => p.Id == ItemMsg.Id).FirstOrDefault();
                            if (tbb == null)
                            {

                                if (ItemMsg.UserId == UserId || ItemMsg.ProdutosId == Msg.ProdutosId || ItemMsg.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && ItemMsg.Produtos.TipoServico.TipoCategoria == "Trocas")
                                {
                                    MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                    {
                                        Id = ItemMsg.Id,
                                        UserName = ItemMsg.User.Nome,
                                        UserId = ItemMsg.User.Id,
                                        Mensagens = ItemMsg.Mensagens,
                                        UrlImagem = ItemMsg.User.ImagemLogin,
                                        MensagemUserIdPrincipal = true,
                                        MensagenLida = ItemMsg.MensagenLida,
                                        CreateAt = (DateTime)ItemMsg.CreateAt,
                                    };
                                    ListMensagens.Add(_dtoMsg);
                                }
                            }

                        }

                    }


                    Msg.MensagensP = ListMensagens.OrderBy(p => p.CreateAt);

                    Msg.CreateAt = (DateTime)item.CreateAt;

                    var f = new MensagensPPorUnicoUsuarioDto();
                    f = Msg;

                    resultMsg.Add(f);

                    MensagensPClienteUserProdutoUserDto listClient = new MensagensPClienteUserProdutoUserDto
                    {
                        UserId = Msg.UserId,
                        ProdutosId = Msg.ProdutosId,
                        clienteUsuarioId = Msg.clienteUsuarioId,
                        idProdutoUsuarioTroca = Msg.idProdutoUsuarioTroca,
                    };

                    ClientesMgs.Add(listClient);
                }

                else if(gatilho && item.Produtos.TipoServico.TipoCategoria != "Duvidas" && denuncias == false)
                {
                    List<MensagensPBasicoDto> ListMensagens = new List<MensagensPBasicoDto>();

                    Msg.Id = item.Id;
                    Msg.UserId = item.UserId;
                    Msg.ProdutosId = item.ProdutosId;
                    Msg.UserName = user.Nome;
                    var categoria = await _repositoryProduto.GetCompleteByCategoria(item.Produtos.CategoriaId);
                    var tipoServicio = await _repositoryProduto.GetCompleteByTipoServico(item.Produtos.TipoServicoId);
                    Msg.Categoria = categoria.Categoria.TipoCategoria;
                    Msg.TipoServico = tipoServicio.TipoServico.TipoCategoria;

                    if (user.UserLogado != null)
                        Msg.UserLogado = (DateTime)user.UserLogado;
                    Msg.UserImagem = user.ImagemLogin;
                    Msg.Produtos = _mapper.Map<ProdutosDtoBasic>(item.Produtos);

                    Msg.clienteUsuarioId = item.ClienteUsuarioId;


                    var UserCliente = await _repositoryUser.SelectAsync(item.ClienteUsuarioId);
                    Msg.UserClienteName = UserCliente.Nome;
                    Msg.UserClienteImagem = UserCliente.ImagemLogin; //////////////////////////////////////////////////
                    Msg.idProdutoUsuarioTroca = item.IdProdutoUsuarioTroca;
                    if (UserCliente.UserLogado != null)
                        Msg.UserClienteLogado = (DateTime)UserCliente.UserLogado;
                    var ProdutoCliente = await _repositoryProduto.GetCompleteByImagensP(item.IdProdutoUsuarioTroca);

                    var validador = ClientesMgs.Where(p => p.clienteUsuarioId == Msg.clienteUsuarioId
                                                        && p.idProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca
                                                        && p.UserId == Msg.UserId
                                                        && p.ProdutosId == Msg.ProdutosId
                                                        );

                    if (validador.Count() == 0)
                    {

                        foreach (var ItemMsg in dados.Where(p => p.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && p.Produtos != null).ToList())
                        {
                            if (ItemMsg.Produtos == null)
                                ItemMsg.Produtos = await _repositoryProduto.SelectAsync(ItemMsg.ProdutosId);

                            MensagensPBasicoDto tbb = (MensagensPBasicoDto)ListMensagens.Where(p => p.Id == ItemMsg.Id).FirstOrDefault();
                            if (tbb == null)
                            {

                                if (ItemMsg.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && ItemMsg.ProdutosId == Msg.ProdutosId && ItemMsg.Produtos.TipoServico.TipoCategoria != "Duvidas")
                                {
                                    if (ItemMsg.ClienteUsuarioId == UserId)
                                    {
                                        MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                        {
                                            Id = ItemMsg.Id,
                                            UserName = ItemMsg.User.Nome,
                                            UserId = ItemMsg.User.Id,
                                            Mensagens = ItemMsg.Mensagens,
                                            UrlImagem = ItemMsg.User.ImagemLogin,
                                            MensagemUserIdPrincipal = false,
                                            MensagenLida = ItemMsg.MensagenLida,
                                            CreateAt = (DateTime)ItemMsg.CreateAt,
                                        };
                                        ListMensagens.Add(_dtoMsg);
                                    }

                                }

                            }

                        }


                        foreach (var ItemMsg in dados.Where(p => p.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && p.Produtos != null).ToList())
                        {
                            if (ItemMsg.Produtos == null)
                                ItemMsg.Produtos = await _repositoryProduto.SelectAsync(ItemMsg.ProdutosId);

                            MensagensPBasicoDto tbb = (MensagensPBasicoDto)ListMensagens.Where(p => p.Id == ItemMsg.Id).FirstOrDefault();
                            if (tbb == null)
                            {

                                if (ItemMsg.UserId == UserId || ItemMsg.ProdutosId == Msg.ProdutosId || ItemMsg.IdProdutoUsuarioTroca == Msg.idProdutoUsuarioTroca && ItemMsg.Produtos.TipoServico.TipoCategoria != "Duvidas")
                                {
                                    MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                    {
                                        Id = ItemMsg.Id,
                                        UserName = ItemMsg.User.Nome,
                                        UserId = ItemMsg.User.Id,
                                        Mensagens = ItemMsg.Mensagens,
                                        UrlImagem = ItemMsg.User.ImagemLogin,
                                        MensagemUserIdPrincipal = true,
                                        MensagenLida = ItemMsg.MensagenLida,
                                        CreateAt = (DateTime)ItemMsg.CreateAt,
                                    };
                                    ListMensagens.Add(_dtoMsg);
                                }
                            }

                        }
                    }

                    Msg.MensagensP = ListMensagens.OrderBy(p => p.CreateAt);

                    Msg.CreateAt = (DateTime)item.CreateAt;

                    var f = new MensagensPPorUnicoUsuarioDto();
                    f = Msg;

                    resultMsg.Add(f);

                    MensagensPClienteUserProdutoUserDto listClient = new MensagensPClienteUserProdutoUserDto
                    {
                        UserId = Msg.UserId,
                        ProdutosId = Msg.ProdutosId,
                        clienteUsuarioId = Msg.clienteUsuarioId,
                        idProdutoUsuarioTroca = Msg.idProdutoUsuarioTroca,
                    };

                    ClientesMgs.Add(listClient);
                }
                          
                else
                {               
                    List<MensagensPBasicoDto> ListMensagens = new List<MensagensPBasicoDto>();

                    if (ClientesMgs.Select(p => p.ProdutosId == Msg.ProdutosId && p.UserId == Msg.UserId).ToList().Count() == 0 && denuncias == false)
                    {
                        Msg.Id = item.Id;
                        var categoria = await _repositoryProduto.GetCompleteByCategoria(item.Produtos.CategoriaId);
                        var tipoServicio = await _repositoryProduto.GetCompleteByTipoServico(item.Produtos.TipoServicoId);
                        Msg.Categoria = categoria.Categoria.TipoCategoria;
                        Msg.TipoServico = tipoServicio.TipoServico.TipoCategoria;
                        Msg.UserId = item.UserId;
                        Msg.ProdutosId = item.ProdutosId;
                        Msg.UserName = user.Nome;
                        if (user.UserLogado != null)
                            Msg.UserLogado = (DateTime)user.UserLogado;
                        Msg.UserImagem = user.ImagemLogin;
                        Msg.Produtos = _mapper.Map<ProdutosDtoBasic>(item.Produtos);
                        Msg.clienteUsuarioId = item.ClienteUsuarioId;
                        var UserCliente = await _repositoryUser.SelectAsync(item.ClienteUsuarioId);

                        if(UserCliente != null)
                        {
                            Msg.UserClienteName = UserCliente.Nome;
                            Msg.UserClienteImagem = UserCliente.ImagemLogin;
                            if (UserCliente.UserLogado != null)
                                Msg.UserClienteLogado = (DateTime)UserCliente.UserLogado;
                        }


                        var ListaDeDatos = dados.Where(p => p.ProdutosId == Msg.ProdutosId 
                                                            && p.Produtos.TipoServico.TipoCategoria == "Duvidas" 
                                                            && p.ClienteUsuarioId != new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                       
                        foreach (var ItemMsg in ListaDeDatos)
                        {

                            if (ItemMsg.Produtos == null)
                                ItemMsg.Produtos = await _repositoryProduto.SelectAsync(ItemMsg.ProdutosId);

                            var clienteId = ItemMsg.ClienteUsuarioId;
                            var userCliente = await _repositoryUser.SelectAsync(ItemMsg.ClienteUsuarioId);
                            MensagensPBasicoDto tbb = (MensagensPBasicoDto)ListMensagens.Where(p => p.Id == ItemMsg.Id).FirstOrDefault();

                            if (tbb == null)
                            {

                                if ( ItemMsg.UserId == Msg.Produtos.UserId || ItemMsg.ProdutosId == Msg.ProdutosId || ItemMsg.IdProdutoUsuarioTroca == Msg.ProdutosId )
                                {
                                    MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                    {
                                        Id = item.Id,
                                        UserName = ItemMsg?.User?.Nome,
                                        UserId = userCliente.Id,
                                        Mensagens = ItemMsg?.Mensagens,
                                        MensagemUserIdPrincipal = true,
                                        UrlImagem = userCliente.ImagemLogin,
                                        MensagenLida = ItemMsg.MensagenLida,
                                        CreateAt = (DateTime)ItemMsg?.CreateAt,
                                    };

                                    ListMensagens.Add(_dtoMsg);
                                }
                                else
                                {
                                    MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                    {
                                        Id = item.Id,
                                        UserName = ItemMsg?.User?.Nome,
                                        UserId = userCliente.Id,
                                        Mensagens = ItemMsg?.Mensagens,
                                        MensagemUserIdPrincipal = false,
                                        UrlImagem = userCliente.ImagemLogin,
                                        MensagenLida = ItemMsg.MensagenLida,
                                        CreateAt = (DateTime)ItemMsg?.CreateAt,
                                    };

                                    ListMensagens.Add(_dtoMsg);
                                }
                            }
                        }

                        Msg.MensagensP = ListMensagens.ToList();


                        Msg.CreateAt = (DateTime)item.CreateAt;

                        var f = new MensagensPPorUnicoUsuarioDto();
                        f = Msg;

                        resultMsg.Add(f);

                        MensagensPClienteUserProdutoUserDto listClient = new MensagensPClienteUserProdutoUserDto
                        {
                            UserId = Msg.UserId,
                            ProdutosId = Msg.ProdutosId,
                            clienteUsuarioId = Msg.clienteUsuarioId,
                            idProdutoUsuarioTroca = Msg.idProdutoUsuarioTroca,
                        };

                        ClientesMgs.Add(listClient);
                    }
                }
               
            }

            try
            {
  
                return _mapper.Map<IEnumerable<MensagensPPorUnicoUsuarioDto>>(resultMsg.ToList());
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro: {ex}");
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MensagensPPorUnicoUsuarioDto>> GetMensagensAllNoLida(Guid UserId)
        {
            _logge.Info($"Info { UserId}");
            List<MensagensPPorUnicoUsuarioDto> resultMsg = new List<MensagensPPorUnicoUsuarioDto>();
            List<MensagensPClienteUserProdutoUserDto> ClientesMgs = new List<MensagensPClienteUserProdutoUserDto>();

            List<MensagensPDto> mensagensP = new List<MensagensPDto>();

            var dados = await _repository.GetMensagensAllNoLida(UserId);

            List<MensagensPEntity> IdProdutos = new List<MensagensPEntity>();

            foreach (var item in dados)
            {
                if (IdProdutos.Count == 0)
                {
                    IdProdutos.Add(item);
                }
                else
                {
                    foreach (var itemProduto in IdProdutos)
                    {
                        if (itemProduto.ProdutosId != item.ProdutosId)
                        {
                            IdProdutos.Add(item);
                        }
                    }
                }

            }
 

            foreach (var item in IdProdutos)
            {
                MensagensPPorUnicoUsuarioDto Msg = new MensagensPPorUnicoUsuarioDto();
                List<MensagensPBasicoDto> ListMensagens = new List<MensagensPBasicoDto>();

                Msg.Id = item.Id;
                Msg.UserId = item.UserId;
                Msg.ProdutosId = item.ProdutosId;
                Msg.UserName = item.User.Nome;
                Msg.Categoria = item.Produtos.Categoria.TipoCategoria;
                Msg.TipoServico = item.Produtos.TipoServico.TipoCategoria;
                Msg.UserLogado = (DateTime)item.User.UserLogado;
                Msg.UserImagem = item.User.ImagemLogin;
                Msg.Produtos = _mapper.Map<ProdutosDtoBasic>(item.Produtos);
                Msg.clienteUsuarioId = item.ClienteUsuarioId;

                var UserCliente = await _repositoryUser.SelectAsync(item.ClienteUsuarioId);
                Msg.UserClienteName = UserCliente.Nome;
                Msg.UserClienteImagem = UserCliente.ImagemLogin;
                Msg.idProdutoUsuarioTroca = item.IdProdutoUsuarioTroca;
                Msg.UserClienteLogado = (DateTime)UserCliente.UserLogado;

                if (item.Produtos!.MensagensP.Count() > 0)
                    foreach (var ItemMsg in item.Produtos!.MensagensP)
                    {
                        bool MensagemUserIdPrincipal = false;

                        if (ItemMsg?.User?.Id == UserId)
                        {
                            MensagemUserIdPrincipal = true;
                        }

                        if (ItemMsg.User == null)
                        {
                            ItemMsg.User = await _repositoryUser.SelectAsync(ItemMsg.UserId);
                        }

                        MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                        {
                            Id = ItemMsg.Id,
                            UserName = ItemMsg?.User?.Nome,
                            UserId = (Guid)(ItemMsg?.User?.Id),
                            Mensagens = ItemMsg?.Mensagens,
                            UrlImagem = ItemMsg?.User.ImagemLogin,
                            MensagemUserIdPrincipal = MensagemUserIdPrincipal,
                            MensagenLida = ItemMsg.MensagenLida,
                            CreateAt = (DateTime)ItemMsg?.CreateAt,
                        };
                        ListMensagens.Add(_dtoMsg);
                    }

                Msg.MensagensP = ListMensagens.OrderBy(p => p.CreateAt);

                Msg.CreateAt = (DateTime)item.CreateAt;

                var f = new MensagensPPorUnicoUsuarioDto();
                f = Msg;

                resultMsg.Add(f);

                MensagensPClienteUserProdutoUserDto listClient = new MensagensPClienteUserProdutoUserDto
                {
                    UserId = Msg.UserId,
                    ProdutosId = Msg.ProdutosId,
                    clienteUsuarioId = Msg.clienteUsuarioId,
                    idProdutoUsuarioTroca = Msg.idProdutoUsuarioTroca,
                };

                ClientesMgs.Add(listClient);
            }



            try
            {

                return _mapper.Map<IEnumerable<MensagensPPorUnicoUsuarioDto>>(resultMsg.ToList());
            }
            catch (Exception ex)
            {
                _logge.Error($"Error { ex}");
                return null;
            }
        }


        /// <summary>
        ///Conceito de trocas
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>MensagensPClienteUserProdutoUserDto</returns>
        public async Task<IEnumerable<MensagensPPorUnicoUsuarioDto>> GetAllMensagensPGeneral(Guid UserId, int tipoServico)
        {
            try
            {
                List<MensagensPPorUnicoUsuarioDto> resultMsg = new List<MensagensPPorUnicoUsuarioDto>();
                List<MensagensPClienteUserProdutoUserDto> ClientesMgs = new List<MensagensPClienteUserProdutoUserDto>(); 

                List<MensagensPDto> mensagensP = new List<MensagensPDto>();
   
                var dados = await _repository.GetAllByMensagensPUser(UserId, tipoServico);

                foreach (var item in dados)
                {
                    MensagensPPorUnicoUsuarioDto Msg = new MensagensPPorUnicoUsuarioDto();
                    List<MensagensPBasicoDto> ListMensagens = new List<MensagensPBasicoDto>();

                    var UserCliente = await _repositoryUser.SelectAsync(item.ClienteUsuarioId);

                    if (UserCliente != null)
                    {
                        Msg.Id = item.Id;
                        Msg.UserId = item.UserId;
                        Msg.ProdutosId = item.ProdutosId;
                        Msg.UserName = item.User.Nome;
                        Msg.Categoria = item.Produtos.Categoria.TipoCategoria;
                        Msg.TipoServico = item.Produtos.TipoServico.TipoCategoria;
                        Msg.UserLogado = (DateTime)item.User.UserLogado;
                        Msg.UserImagem = item.User.ImagemLogin;
                        Msg.Produtos = _mapper.Map<ProdutosDtoBasic>(item.Produtos);
                        Msg.clienteUsuarioId = item.ClienteUsuarioId;


                        Msg.UserClienteName = UserCliente?.Nome;
                        Msg.UserClienteImagem = UserCliente?.ImagemLogin;
                        Msg.idProdutoUsuarioTroca = item.IdProdutoUsuarioTroca;
                        Msg.UserClienteLogado = (DateTime)UserCliente.UserLogado;

                        if (item.Produtos!.MensagensP.Count() > 0)
                            foreach (var ItemMsg in item.Produtos!.MensagensP)
                            {
                                bool MensagemUserIdPrincipal = false;

                                if (ItemMsg?.User?.Id == UserId)
                                {
                                    MensagemUserIdPrincipal = true;
                                }

                                if (ItemMsg.User == null)
                                {
                                    ItemMsg.User = await _repositoryUser.SelectAsync(ItemMsg.UserId);
                                }

                                MensagensPBasicoDto _dtoMsg = new MensagensPBasicoDto
                                {
                                    Id = ItemMsg.Id,
                                    UserName = ItemMsg?.User?.Nome,
                                    UserId = (Guid)(ItemMsg?.User?.Id),
                                    Mensagens = ItemMsg?.Mensagens,
                                    UrlImagem = ItemMsg?.User.ImagemLogin,
                                    MensagemUserIdPrincipal = MensagemUserIdPrincipal,
                                    MensagenLida = ItemMsg.MensagenLida,
                                    CreateAt = (DateTime)ItemMsg?.CreateAt,
                                };
                                ListMensagens.Add(_dtoMsg);
                            }

                        Msg.MensagensP = ListMensagens.OrderBy(p => p.CreateAt);

                        Msg.CreateAt = (DateTime)item.CreateAt;

                        var f = new MensagensPPorUnicoUsuarioDto();
                        f = Msg;

                        resultMsg.Add(f);

                        MensagensPClienteUserProdutoUserDto listClient = new MensagensPClienteUserProdutoUserDto
                        {
                            UserId = Msg.UserId,
                            ProdutosId = Msg.ProdutosId,
                            clienteUsuarioId = Msg.clienteUsuarioId,
                            idProdutoUsuarioTroca = Msg.idProdutoUsuarioTroca,
                        };

                        ClientesMgs.Add(listClient);
                    }
                   
                }
                return _mapper.Map<IEnumerable<MensagensPPorUnicoUsuarioDto>>(resultMsg.ToList());
            }
            catch( Exception ex)
            {
                _logge.Error($"Error { UserId}");
                return null;
            }
        }

        /// <summary>
        /// Contas quantos produtos existe sem ler
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<int> GetCountMensagensUnico(Guid UserId, int tipoServico)
        {
            return await _repository.GetCountMensagensUnico(UserId, tipoServico);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<int> GetCountMensagensAll(Guid UserId)
        {
            return await _repository.GetCountMensagensAll(UserId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produtosId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MensagensPDto>> GetCompleteByProdutos(Guid produtosId)
        {
            var listEntity = await _repository.GetCompleteByProdutos(produtosId);
            return _mapper.Map<IEnumerable<MensagensPDto>>(listEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<MensagensPDtoUpdateResult> PostMensagensPLida(MensagensPDtoUpdate Mensagens)
        {
            var MensagensP = await _repository.SelectAsync(Mensagens.Id); // para alutalizar as mensagens lidas que ñ me pertence.
            if (MensagensP != null)
            {
                var entity = _mapper.Map<MensagensPEntity>(MensagensP);        
     
                entity.MensagenLida = true;
                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<MensagensPDtoUpdateResult>(result);
            }
            return null;
        }

        /// <summary>
        /// Para enviar mensagens em privado e ñ ter um produto real 
        /// </summary>
        /// <param name="PostMensagensPrivadas"></param>
        /// <returns></returns>
        public async Task<MensagensPDtoCreateResult> PostMensagensPrivadas(MensagensPDtoCreate MensagensP)
        {

            var GetProduto = await _repositoryProduto.GetByMensagensPrivadas(MensagensP.UserId, MensagensP.ClienteUsuarioId);
            var produto = new ProdutosDtoCreateResult();
            if (GetProduto == null)
            {
                var Produtos = new ProdutosDtoCreate
                {
                    NomeProduto = "Msg_Privadas",
                    Descricao = "Msg_Privadas",
                    CategoriaId = new Guid("07799b22-e49f-425a-84f8-938d7a6dfd2a"), // Plantas
                    TipoServicoId = new Guid("3b2778ce-503d-4b49-b161-c54013d9d355"), // Duvidas
                    UserId = MensagensP.UserId,               
                    ClienteUsuarioId = MensagensP.ClienteUsuarioId
                };

                var entityP = _mapper.Map<ProdutosEntity>(Produtos);
                entityP.Ativo = false;
                entityP.Id = new Guid("7768ff25-0e5a-4738-ad07-1d7a21b82ccb");

                var resultP = await _repositoryProduto.InsertAsync(entityP);
                produto = _mapper.Map<ProdutosDtoCreateResult>(resultP);

                var entity_ = _mapper.Map<MensagensPEntity>(MensagensP);
                entity_.ProdutosId = produto.Id;
  
                var result_ = await _repository.InsertAsync(entity_);
                return _mapper.Map<MensagensPDtoCreateResult>(result_);
            }

            var entity = _mapper.Map<MensagensPEntity>(MensagensP);
            entity.ProdutosId = GetProduto.Id;

            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<MensagensPDtoCreateResult>(result);
        }


        /// <summary>
        /// get all todas as mensagens privadas que existe de uma conversa seguindo que existe um produto ñ ativo  
        /// </summary>
        /// <param name="PostMensagensPrivadas"></param>
        /// <returns></returns>
        public async Task<ProdutosDto> GetAllMensagensPrivadasProduto(Guid UserId,  Guid ClienteUsuarioId)
        {
            var result =  await _repositoryProduto.GetByMensagensPrivadas(UserId, ClienteUsuarioId);
            var produtos =  _mapper.Map<ProdutosDto>(result);
            int mensagensNaoLidas = 0;

            foreach (var item in produtos.MensagensP)
            {
                var userId = item.clienteUsuarioId;
                var UserCliente = await _repositoryUser.GetUserIdDadosBasicos(userId);
                item.UserCliente = _mapper.Map<UserGetDadosBasicosDto>(UserCliente);
                if (item.MensagenLida == false)
                {
                    mensagensNaoLidas = mensagensNaoLidas + 1;
                }
            }

            produtos.TotalMensagenNaoLida = mensagensNaoLidas;
            return produtos;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="MensagensP"></param>
        /// <returns></returns>
        public async Task<MensagensPDtoCreateResult> Post(MensagensPDtoCreate MensagensP)
        {
            _logge.Info($"UserId { MensagensP.UserId} ClienteUsuarioId { MensagensP.ClienteUsuarioId}");
            SendEmail email = new SendEmail(_configuration);
          

            var Produtos = await _repositoryProduto.GetCompleteByMensagensP(MensagensP.ProdutosId);
            var idProdutoUsuarioTroca = await _repositoryProduto.GetCompleteByMensagensP(MensagensP.IdProdutoUsuarioTroca);

            if (Produtos == null)
            {
                return null;
            }

            if (Produtos.Id != null)
            {
                var entity = _mapper.Map<MensagensPEntity>(MensagensP);
      
                var result = await _repository.InsertAsync(entity);


                MensagensUsuario = MensagensP.Mensagens;
                produtoEmailResponse = Produtos;
                ProdutoMensagem = Produtos.NomeProduto;


                bool MensagensPEMail = await GetAllBMensagensNaoLidas(MensagensP.ClienteUsuarioId);

                if (MensagensPEMail && MensagensP.ClienteUsuarioId != MensagensP.UserId)
                {

                    emailsNewsletterDto = (EmailsNewsletterDto)await GetByTipoNewsletter(3, result.User.Idioma); // Email de Mensagens de usuarios de troca ou doaçoes
                    userEmailResponse = await _repositoryUser.SelectAsync(Produtos.UserId);


                    Thread Email = new Thread(new ThreadStart(EmailsParaUsuarioDeProdutosNovosAsync));
                    Email.Name = "Secundária - ";
                    Email.Start();
                }

                return _mapper.Map<MensagensPDtoCreateResult>(result);
            }

            return null;

        }


        private async void EmailsParaUsuarioDeProdutosNovosAsync()
        {
            try
            {            

                emailsNewsletterDto.HTML = emailsNewsletterDto.HTML.Replace("#nomeUsario", userEmailResponse.Nome);
                emailsNewsletterDto.HTML = emailsNewsletterDto.HTML.Replace("#produto", ProdutoMensagem);

                var emailRequestDto = new EmailRequestDto
                {                
                    ToEmail = userEmailResponse.Email,
                    Subject = "nova menagem no seu produto: " + ProdutoMensagem,
                    Body = emailsNewsletterDto.HTML,
                    Nome = userEmailResponse.Nome,
                    CodigoUsuario = null,
                    HtmlExpansao = null

                };

                SendEmail email = new SendEmail(_configuration);

                var result = await email.SendEmailAsync(emailRequestDto);                

                
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro: {ex}");
            }


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="MensagensP"></param>
        /// <returns></returns>
        public async Task<MensagensPDtoUpdateResult> Put(MensagensPDtoUpdate MensagensP)
        {
            var ProdutosId = await _repositoryProduto.GetCompleteByMensagensP(MensagensP.ProdutosId);
            if (ProdutosId != null)
            {
                var entity = _mapper.Map<MensagensPEntity>(MensagensP);
  
                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<MensagensPDtoUpdateResult>(result);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }


        public async Task<EmailsNewsletterDto> GetByTipoNewsletter(int TipoNewsletter, string idioma)
        {
            var result = await _emailsNewsletterService.GetByTipoNewsletter(TipoNewsletter, idioma);
            return _mapper.Map<EmailsNewsletterDto>(result);

        }

        public async Task<bool> GetAllBMensagensNaoLidas(Guid UserId)
        {
            return await _repository.GetAllBMensagensNaoLidas(UserId);
        }
    }
}


