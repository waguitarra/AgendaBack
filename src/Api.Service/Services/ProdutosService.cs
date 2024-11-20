using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.MensagensP;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.EmailsNewsletter;
using Domain.Dtos.EnviarEmailDto;
using Domain.Entities;
using Domain.Interfaces.Services.EmailsNewsletter;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using NLog;
using NsfwSpyNS;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Service.Services
{

    public class ProdutosService : IProdutosService
    {
        static Object obj = new Object();
        private IUProdutosRepository _repository;
        private IUImagensPRepository _imagensPRepositorio;
        private IUUserRepository _userRepositorio;
        private IUDenunciaProdutoUsuarioRepository _DenunciaProUsuario;
        private IUAgenteRepository _uagenteRepository;
        private IMapper _mapper;
        private IMensagensPService _mensagensP;
        private IEmailsNewsletterService _emailsNewsletterService;
        private Guid IdProduto;
        private static IEnumerable<UserEntity> userEmailResponse;
        private static IEnumerable<ProdutosEntity> produtoEmailResponse;
        private static EmailsNewsletterDto emailsNewsletterDto;
        private HttpClient client;
        private static string _urlBase;
        public IConfiguration _configuration { get; }
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();


        public ProdutosService(IUProdutosRepository repository
                            , IMapper mapper
                            , IUImagensPRepository imagensPRepositorio
                            , IUUserRepository userRepositorio
                            , IUDenunciaProdutoUsuarioRepository DenunciaProUsuario
                            , IMensagensPService mensagensP
                            , IEmailsNewsletterService emailsNewsletterService
                            , IConfiguration configuration
                            , IUAgenteRepository uagenteRepository
                            )
        {
            _repository = repository;
            _mapper = mapper;
            _imagensPRepositorio = imagensPRepositorio;
            _userRepositorio = userRepositorio;
            _DenunciaProUsuario = DenunciaProUsuario;
            _mensagensP = mensagensP;
            _emailsNewsletterService = emailsNewsletterService;
            _configuration = configuration;
            _uagenteRepository = uagenteRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutosDto>> GetAllMyProduto(Guid userId)
        {
            var response = await  _repository.GetAllMyProduto(userId);
            return _mapper.Map<IEnumerable<ProdutosDto>>(response);
        }

        public async Task<ProdutosDto> Get(Guid id, Guid? userId, double lat, double longi, string idioma)
        {
            var translatorService = new TranslationService();

            var listEntity = await _repository.GetPesquisaProduto(id);

            if (userId != null)
            {
                Guid _userId = (Guid)userId;
                var denuncias = await _DenunciaProUsuario.GetUserProdutos(_userId, id);

                if (denuncias != null)
                {
                    return null;
                }

                if (listEntity != null)
                {

                    if (listEntity.MensagensP != null)
                        foreach (var item in listEntity.MensagensP)
                        {
                            await _userRepositorio.GetCurtidasPPorUserId(item.UserId);
                        }

                    listEntity.MensagensP = listEntity.MensagensP.OrderBy(p => p.CreateAt);
      
                    await _repository.GetCompleteByUser(listEntity.UserId);

                    if (listEntity.CurtidasP != null)
                    {
                        listEntity.CurtidasP = listEntity.CurtidasP.AsQueryable().Where(p => p.Curtidas == true).ToList();
                        listEntity.CurtidasTotal = listEntity.CurtidasP.Count();
                    }
                    else
                    {
                        listEntity.CurtidasTotal = 0;
                    }

                    if (userId != null)
                    {
                        var userLogado = await _userRepositorio.GetProdutoPorUserId((Guid)userId);
                        var UserProduto = await _userRepositorio.GetProdutoPorUserId(listEntity.UserId);

                        if (userLogado == null)
                        {
                            if (lat != 0 && longi != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                            {
                                var kilometros = ObtenerDistancia(lat, longi, UserProduto.Latitude, UserProduto.Longitude);
                                listEntity.KM = kilometros;
                            }
                        }

                        else if (userLogado.Latitude != 0 && userLogado.Longitude != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                        {
                            var kilometros = ObtenerDistancia(userLogado.Latitude, userLogado.Longitude, UserProduto.Latitude, UserProduto.Longitude);
                            listEntity.KM = kilometros;
                        }
                    }
                }

                if (idioma != listEntity.Idioma)
                {
                    listEntity.Descricao = await translatorService.TranslateTextAsync(listEntity.Descricao, idioma);
                    listEntity.NomeProduto = await translatorService.TranslateTextAsync(listEntity.NomeProduto, idioma);

                    foreach (var item in listEntity.MensagensP)
                    {
                        item.Mensagens = await translatorService.TranslateTextAsync(item.Mensagens, idioma);
                    }
                }



                return _mapper.Map<ProdutosDto>(listEntity);
            }
            else if (listEntity != null)
                return _mapper.Map<ProdutosDto>(listEntity);

            return null;
        }

        public async Task<IEnumerable<ProdutosDto>> GetAll(Guid userId)
        {
            var listEntity = await _repository.SelectAsync();

            //Ordenar a lista de produto e somente pode trazer produtos ativos
            listEntity = listEntity.AsQueryable().OrderBy(p => p.CreateAt).ToList().Where(a => a.Ativo == true).ToList();
            var userLogado = await _userRepositorio.GetProdutoPorUserId(userId);


            // caso usuario nao tem registro ñ deve apresentar nenhuma informaçao.
            if (userLogado != null)
            {
                foreach (var item in listEntity)
                {
                    var denuncias = await _DenunciaProUsuario.GetUserProdutos(userId, item.Id);
                    if (item.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000") && denuncias == null)
                    {
                        await _repository.GetCompleteByCategoria(item.CategoriaId);
                        await _repository.GetCompleteByTipoServico(item.TipoServicoId);
                        await _repository.GetCompleteByImagensP(item.Id);
                        await _repository.GetCompleteByMensagensP(item.Id);

                        if (item.MensagensP.Count() > 0)
                            foreach (var msg in item.MensagensP)
                            {
                                if (msg.IdProdutoUsuarioTroca != new Guid("00000000-0000-0000-0000-000000000000"))
                                {
                                    msg.Produtos = await _repository.SelectAsync(msg.IdProdutoUsuarioTroca);
                                }

                                item.MensagensP.OrderBy(p => p.CreateAt).ToList();

                            }

                        var user = await _repository.GetCompleteByUser(item.UserId);
                        var curtidasProdutos = await _repository.GetCompleteByCurtidasP(item.Id);

                        //Trazendo somente as curtidas que está como true.
                        if (curtidasProdutos.CurtidasP != null)
                        {
                            curtidasProdutos.CurtidasP = curtidasProdutos.CurtidasP.AsQueryable().Where(p => p.Curtidas == true).ToList();
                            item.CurtidasTotal = curtidasProdutos.CurtidasP.Count();
                        }
                        else
                        {
                            item.CurtidasTotal = 0;
                        }

                        var UserProduto = await _userRepositorio.GetProdutoPorUserId(item.UserId);

                        if (userLogado.Latitude != 0 && userLogado.Longitude != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                        {
                            var kilometros = ObtenerDistancia(userLogado.Latitude, userLogado.Longitude, UserProduto.Latitude, UserProduto.Longitude);
                            item.KM = kilometros;
                        }
                    }


                }
                //Somente usuario ativo podem entrar na lista

                listEntity = listEntity.Where(p => p.DenunciaProdutoUsuario.Any(p => p.UserId != userId)).ToList();

                listEntity = listEntity.AsQueryable().Where(c => c.Categoria != null && c.User.Ativo == true).OrderByDescending(p => p.CreateAt).ToList();
                return _mapper.Map<IEnumerable<ProdutosDto>>(listEntity);
            }

            return null;

        }

        public async Task<IEnumerable<ProdutosDto>> GetAllMeusProdutos(Guid userId)
        {

            try
            {
                var listEntity = await _repository.SelectAsync();
                var userLogado = await _userRepositorio.GetProdutoPorUserId(userId);

                if (userLogado == null)
                {
                    return null;
                }

                var dadosLista = listEntity.AsQueryable().Where(p => p.Ativo == true && p.UserId == userLogado.Id && p.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();


                // somente dados do usuario logado
                if (userLogado != null)
                {
                    foreach (var item in dadosLista)
                    {
                        if (item.UserId == userLogado.Id)
                        {
                            await _repository.GetCompleteByCategoria(item.CategoriaId);
                            await _repository.GetCompleteByTipoServico(item.TipoServicoId);
                            await _repository.GetCompleteByImagensP(item.Id);

                            //caso Produto já tenha vinculo com um usuario de troca todas as demais msg ñ será mais nescessaria.
                            if (item.ClienteUsuarioId != new Guid("00000000-0000-0000-0000-000000000000"))
                                await _repository.GetCompleteByMensagensP(item.ClienteUsuarioId);
                            else
                                await _repository.GetCompleteByMensagensP(item.Id);

                            await _repository.GetCompleteByMensagensP(item.Id);
                            await _repository.GetCompleteByUser(item.UserId);
                            var curtidasProdutos = await _repository.GetCompleteByCurtidasP(item.Id);

                            //Trasendo somente as curtidas que está como true.
                            if (curtidasProdutos.CurtidasP != null)
                            {
                                curtidasProdutos.CurtidasP = curtidasProdutos.CurtidasP.AsQueryable().Where(p => p.Curtidas == true).ToList();
                                item.CurtidasTotal = curtidasProdutos.CurtidasP.Count();
                            }
                            else
                            {
                                item.CurtidasTotal = 0;
                            }

                            var UserProduto = await _userRepositorio.GetProdutoPorUserId(item.UserId);

                            if (userLogado.Latitude != 0 && userLogado.Longitude != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                            {
                                var kilometros = ObtenerDistancia(userLogado.Latitude, userLogado.Longitude, UserProduto.Latitude, UserProduto.Longitude);
                                item.KM = kilometros;
                            }

                            item.MensagensP.OrderBy(p => p.CreateAt).ToList();
                        }

                    }

                    dadosLista.AsQueryable().OrderBy(p => p.CreateAt).ToList();

                    return _mapper.Map<IEnumerable<ProdutosDto>>(dadosLista);
                }


            }
            catch (Exception ex)
            {
                ErroDeCadastroDeProduto(ex.ToString());
                _logge.Error($"Erro: {ex}");
                return null;
            }

        

            return null;

        }

        public async Task<ProdutosDtoCreateResult> Post(ProdutosDtoCreate Produtos)
        {
            // Verifica se o usuário está logado e se há imagens para processar
            var userLogado = await _userRepositorio.GetProdutoPorUserId(Produtos.UserId);
            if (userLogado != null && Produtos.ImagensP.Any())
            {
                // Mapeia o produto e insere apenas uma vez no banco de dados
                var model = _mapper.Map<ProdutosEntity>(Produtos);
                model.ImagensP = new List<ImagensPEntity>();
                model.Agente = new List<AgenteEntity>();
                model.Ativo = true;

                // Insere o produto uma única vez e obtém o ID do produto
                var produtoEntity = await _repository.InsertAsync(model);
                var produtoResultado = _mapper.Map<ProdutosDtoCreateResult>(produtoEntity);

                // Define o ID do produto no objeto que será retornado
                produtoResultado.Id = produtoEntity.Id;

                List<ImagensPEntity> imagensList = new List<ImagensPEntity>();

                // Processa cada imagem na lista de imagens do produto sem duplicar o produto
                foreach (var item in Produtos.ImagensP)
                {
                    var modelImagensP = _mapper.Map<ImagensPEntity>(item);
                    modelImagensP.ProdutosId = produtoEntity.Id;

                    // Define a URL da imagem (a linha de upload pode ser descomentada para upload real)
                    modelImagensP.UrlImagens = "data:image/jpeg;base64," + item.UrlImagens;

                    // Insere a imagem apenas se tiver um conteúdo válido
                    if (!string.IsNullOrEmpty(modelImagensP.UrlImagens))
                    {
                        var resultImagensP = await _imagensPRepositorio.InsertAsync(modelImagensP);
                        imagensList.Add(resultImagensP);
                    }
                }

                // Se nenhuma imagem foi adicionada, exclui o produto e lança uma exceção
                if (!imagensList.Any())
                {
                    await Delete(produtoEntity.Id);
                    throw new ArgumentException("Não foi possível continuar com a Postagem no Imgur.");
                }

                foreach (var agente in Produtos.Agente)
                {
                    var agenteEntity = _mapper.Map<AgenteEntity>(agente);
                    agenteEntity.ProdutoId = produtoEntity.Id;

                    // Gera um novo ID para evitar duplicações se o ID não for auto-incremento
                    agenteEntity.Id = Guid.NewGuid();

                    await _uagenteRepository.InsertAsync(agenteEntity);
                }

                // Retorna apenas o produto inserido uma vez, sem informações de imagens
                return produtoResultado;
            }

            return null;
        }


        public async Task<ProdutosDtoCreateResult> EmailAllNewProduct(string idioma)
        {
            
                userEmailResponse = await _userRepositorio.SelectAsync();
                produtoEmailResponse = await _repository.SelectAsync();
                emailsNewsletterDto = (EmailsNewsletterDto)await GetByTipoNewsletter(2, idioma);
                Thread Email = new Thread(new ThreadStart(EmailsParaUsuarioDeProdutosNovosAsync));
                Email.Name = "Secundária - ";
                Email.Start();

            return null;
        }

        private async void  EmailsParaUsuarioDeProdutosNovosAsync()
        {
            try
            {

                //var HtmlExpresao = "<p style='text-align:justify'><span style='font-size:18px'><span style='font-family:Tahoma,Geneva,sans-serif'><span style='color:#2c3e50'>Total de produtos disponíveis hoje: </span><strong><span style='color:#006633'>#HtmlExpresao</span></strong><span style='color:#2c3e50'><strong>.</strong></span></span></span></p>";
                //await SendEmailPorTipoAsync(2, "wagner@macrosassessorias.com.br", "wagner", null, HtmlExpresao);
                int totalProduto = produtoEmailResponse.Where(p => p.Ativo == true && p.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000")).Count();
                foreach (var item in userEmailResponse)
                {
                    var HtmlExpresao = "<p style='text-align:justify'><span style='font-size:18px'><span style='font-family:Tahoma,Geneva,sans-serif'>Total de produtos disponiveis hoje: <span style='color:#006600'><strong>#TotalProdutos.</strong></span></span></span></p>";

                    HtmlExpresao = HtmlExpresao.Replace("#TotalProdutos", totalProduto.ToString());

                    var emailRequestDto = new EmailRequestDto
                    {
                   
                        ToEmail = item.Email,
                        Subject = emailsNewsletterDto.Nome,
                        Body = emailsNewsletterDto.HTML,
                        Nome = item.Nome,
                        CodigoUsuario = null,
                        HtmlExpansao = HtmlExpresao

                    };

                    SendEmail email = new SendEmail(_configuration);

                    var result = await email.SendEmailAsync(emailRequestDto);
           
                    Thread.Sleep(3033);               

                }
            }
            catch (Exception ex)
            {
                _logge.Error($"errod: {ex}");
            }


        }

        private async void ErroDeCadastroDeProduto( string ex)
        {
            try
            {

                //var HtmlExpresao = "<p style='text-align:justify'><span style='font-size:18px'><span style='font-family:Tahoma,Geneva,sans-serif'><span style='color:#2c3e50'>Total de produtos disponíveis hoje: </span><strong><span style='color:#006633'>#HtmlExpresao</span></strong><span style='color:#2c3e50'><strong>.</strong></span></span></span></p>";
                //await SendEmailPorTipoAsync(2, "wagner@macrosassessorias.com.br", "wagner", null, HtmlExpresao);
                int totalProduto = produtoEmailResponse.Where(p => p.Ativo == true && p.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000")).Count();
     
             
                    SendEmail email = new SendEmail(_configuration);
                    var result = await email.EmailErros(ex);
                    Thread.Sleep(3033);
            }
            catch (Exception e)
            {
                _logge.Error($"errod: {e}");
            }


        }


        public async Task<ProdutosDtoUpdateResult> Put(ProdutosDtoUpdate Produtos)
        {
            var userLogado = await _userRepositorio.GetProdutoPorUserId(Produtos.UserId);
            if (userLogado != null)
            {          
                var entity = _mapper.Map<ProdutosEntity>(Produtos);
                var result = await _repository.UpdateAsync(entity);
                var produtos = _mapper.Map<ProdutosDtoUpdateResult>(result);

                var ImagensP = Produtos.ImagensP;
                foreach (var item in ImagensP)
                {               
                    var entityImagensP = _mapper.Map<ImagensPEntity>(item);
                    await _imagensPRepositorio.UpdateAsync(entityImagensP);

                }

                await _repository.GetCompleteByCategoria(Produtos.CategoriaId);
                await _repository.GetCompleteByTipoServico(Produtos.TipoServicoId);

                return _mapper.Map<ProdutosDtoUpdateResult>(result);
            }
            return null;

        }

        public async Task<ProdutosDtoUpdateResult> PutServiceClienteUsuarioId(Guid id, Guid clienteUsuarioId)
        {
            var listEntity = await _repository.SelectAsync(id);

            listEntity.ClienteUsuarioId = clienteUsuarioId;

            if (listEntity != null)
            {        
                var entity = _mapper.Map<ProdutosEntity>(listEntity);
                var result = await _repository.UpdateAsync(entity);

                return _mapper.Map<ProdutosDtoUpdateResult>(result);
            }
            return null;
        }


        public async Task<IEnumerable<ProdutosDto>> PesquisaPorNomeMaxKm(ProdutosDtoPesquisaCategoriasTipoServicos listaCategoriasServico, Guid userId)
        {
            // Establecer el valor mínimo de km a 40440 si es 0
            if (listaCategoriasServico.km == 0)
                listaCategoriasServico.km = 40440;

            var listEntity = await _repository.GetAllPesquisaIdioma(userId);
            List<ProdutosEntity> ListResult = new List<ProdutosEntity>();

            // Filtro por TipoServicoId
            if (listaCategoriasServico.TipoServicoIdLista.Any())
            {
                foreach (var item in listEntity)
                {
                    foreach (var guidLis in listaCategoriasServico.TipoServicoIdLista)
                    {
                        if (item.TipoServico.Tipo == guidLis)
                        {
                            ListResult.Add(item);
                            break;
                        }
                    }
                }
                listEntity = ListResult;
            }

            // Reset ListResult y filtrar por CategoriaId
            ListResult = new List<ProdutosEntity>();
            if (listaCategoriasServico.CategoriaIdLista.Any())
            {
                foreach (var item in listEntity)
                {
                    foreach (var guidLis in listaCategoriasServico.CategoriaIdLista)
                    {
                        if (item.Categoria.Tipo == guidLis)
                        {
                            ListResult.Add(item);
                            break;
                        }
                    }
                }
                listEntity = ListResult;
            }

            // Filtro de búsqueda
            if (!string.IsNullOrEmpty(listaCategoriasServico.pesquisa))
            {
                listEntity = listEntity
                    .Where(a => a.NomeProduto.ToUpper().Contains(listaCategoriasServico.pesquisa.ToUpper())
                                && a.Ativo
                                && a.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000"))
                    .OrderBy(p => p.CreateAt).ToList();
            }
            else
            {
                listEntity = listEntity
                    .Where(a => a.Ativo
                                && a.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000"))
                    .OrderBy(p => p.CreateAt).ToList();
            }

            var userLogado = listaCategoriasServico.userId.HasValue
                             ? await _userRepositorio.GetProdutoPorUserId(listaCategoriasServico.userId.Value)
                             : new UserEntity();

            ListResult = new List<ProdutosEntity>();

            foreach (var item in listEntity)
            {


                var currentItem = item;

                foreach (var denuncia in item.DenunciaProdutoUsuario)
                {
                    if (denuncia.UserId == listaCategoriasServico.userId)
                    {
                        currentItem = new ProdutosEntity();
                    }
                }

                if (currentItem.NomeProduto != null)
                {
                    double kilometros = 0;
                    var UserProduto = await _userRepositorio.GetProdutoPorUserId(item.UserId);


                    if (userLogado.Nome == null)
                    {
                        kilometros = ObtenerDistancia(listaCategoriasServico.Lat, listaCategoriasServico.Long, UserProduto.Latitude, UserProduto.Longitude);

                    }
                    else

                    if (userLogado.Nome != null && userLogado.Latitude != 0 && userLogado.Longitude != 0 && UserProduto.Latitude != 0 && UserProduto.Longitude != 0)
                    {
                        kilometros = ObtenerDistancia(userLogado.Latitude, userLogado.Longitude, UserProduto.Latitude, UserProduto.Longitude);
                    }

                    item.KM = kilometros;

                    //var translatorService = new TranslationService();

                    //if (listaCategoriasServico.Idioma != item.Idioma)
                    //{
                    //    item.Descricao = await translatorService.TranslateTextAsync(item.Descricao, listaCategoriasServico.Idioma);
                    //    item.NomeProduto = await translatorService.TranslateTextAsync(item.NomeProduto, listaCategoriasServico.Idioma);
                    //}

                    // Ordenar mensajes si hay alguno
                    if (item.MensagensP != null && item.MensagensP.Any())
                    {
                        foreach (var msg in item.MensagensP)
                        {
                            msg.Produtos = await _repository.SelectAsync(msg.IdProdutoUsuarioTroca);
                        }
                        item.MensagensP.OrderBy(p => p.CreateAt).ToList();
                    }

                    await _repository.GetCompleteByUser(item.UserId);
                    var curtidasProdutos = await _repository.GetCompleteByCurtidasP(item.Id);

                    // Obtener solo las curtidas que están marcadas como verdaderas
                    if (curtidasProdutos.CurtidasP != null)
                    {
                        curtidasProdutos.CurtidasP = curtidasProdutos.CurtidasP.Where(p => p.Curtidas).ToList();
                        item.CurtidasTotal = curtidasProdutos.CurtidasP.Count();
                    }

                    ListResult.Add(item);
                }


              
            }

            if (listaCategoriasServico.km != 0)
            {
                listEntity = ListResult
                    .Where(c => c.Ativo && c.User.Ativo && c.KM <= listaCategoriasServico.km)
                    .OrderByDescending(p => p.CreateAt)
                    .ToList();
            }
            else
            {
                listEntity = ListResult
                    .Where(c => c.Ativo && c.User.Ativo)
                    .OrderByDescending(p => p.CreateAt)
                    .ToList();
            }


            return _mapper.Map<IEnumerable<ProdutosDto>>(listEntity.Where(p => p.ImagensP.Any()));
        }

        public async Task<ProdutosDtoUpdateResult> PutDeleteProduto(Guid id)
        {
            var listEntity = await _repository.SelectAsync(id);

            if (listEntity != null)
            {
                var entity = _mapper.Map<ProdutosEntity>(listEntity);
                entity.Delete = DateTime.Now;
                entity.Ativo = false;
    
                var result = await _repository.UpdateAsync(entity);

                return _mapper.Map<ProdutosDtoUpdateResult>(result);
            }
            return null;
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

            return Math.Round(distance, 0);
        }

        private bool ImagensValidacoes(string imagem)
        {
            try
            {
                NsfwSpy _nsfwSpy = new NsfwSpy();
                byte[] bytes = System.Convert.FromBase64String(imagem);
                var result = _nsfwSpy.ClassifyImage(bytes);


                return result.IsNsfw;
            }
            catch (Exception ex)
            {
                _ = Delete(IdProduto);
                _logge.Error($"Não foi possivel seguir com ImagensValidacoes: {ex}");
                throw new ArgumentException("Não foi possivel seguir com ImagensValidacoes.", ex); ;
            }

        }

        public async Task<string> imgurUpload(string base64String)
        {
            return Base64ToWebPConverter.ConvertBase64ToWebP(base64String);
        }

        public async Task<EmailsNewsletterDto> GetByTipoNewsletter(int TipoNewsletter, string idioma)
        {
            var result = await _emailsNewsletterService.GetByTipoNewsletter(TipoNewsletter, idioma);
            return _mapper.Map<EmailsNewsletterDto>(result);

        }

        public async Task<int> GetQtdProdutosFinalizados(Guid userId)
        {
            return await _repository.GetQtdProdutosFinalizados(userId);    
        }

        public async Task<IEnumerable<ProdutosDto>> GetAllMensagensPrivadas(Guid userId)
        {
            var result = await _repository.GetAllMensagensPrivadas(userId);
            var produtos =  _mapper.Map<IEnumerable<ProdutosDto>>(result);

            foreach (var item in produtos)
            {
                int TotalMensagenNaoLida = 0;
                foreach (var itemMsg in item.MensagensP)
                {
                    var UserCliente = await _userRepositorio.GetUserId(itemMsg.clienteUsuarioId);
                    itemMsg.UserCliente = _mapper.Map<UserGetDadosBasicosDto>(UserCliente);
                    if (itemMsg.MensagenLida == false && itemMsg.UserId != userId)
                    {
                        TotalMensagenNaoLida = TotalMensagenNaoLida + 1;
                    }
                }
                item.TotalMensagenNaoLida = TotalMensagenNaoLida;
                item.ultimaMensagem = item.MensagensP.Max(p => p.CreateAt);
            }

            try
            {
                foreach (var item in produtos)
                {
                    var cliente = _userRepositorio.GetUserId(item.ClienteUsuarioId);
                    item.ClienteUser = _mapper.Map<UserGetDadosBasicosDto>(cliente.Result);
                }
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro: {ex}");
                return null;
            }

            var resultOrdem =   produtos.OrderByDescending(p => p.ultimaMensagem).ToList();
            return resultOrdem;
        }

        public async Task<IEnumerable<ProdutosDto>> GetAllAssuntosLivres(Guid userId)
        {
            var result =  await _repository.GetAllAssuntosLivres(userId);
            return _mapper.Map<IEnumerable<ProdutosDto>>(result);
        }


    }
}
