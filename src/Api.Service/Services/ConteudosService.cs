using Api.Domain.Dtos.ImagensP;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Categorias;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.Conteudo;
using Domain.Entities;
using NLog;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class ConteudosService : IConteudosService
    {
        private IUConteudosRepository _repository;
        private IUImagensConteudosRepository _repositoryImagensConteudos;
        private IUConteudoCategoriaRepository _repositoryCategoriaConteudos;
        private IUUserRepository _userRepositorio;
        private Guid IdConteudos;
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();

        private readonly IMapper _mapper;

        public ConteudosService(IUConteudosRepository repository
                                , IUUserRepository userRepositorio
                                , IUImagensConteudosRepository repositoryImagens
                                , IUConteudoCategoriaRepository repositoryCategoriaConteudos
                                , IMapper mapper)
        {
            _repository = repository;
            _repositoryImagensConteudos = repositoryImagens;
            _mapper = mapper;
            _repositoryCategoriaConteudos = repositoryCategoriaConteudos;
            _userRepositorio = userRepositorio;
        }

        public async Task<ConteudosDto> Get(Guid id , string idioma)
        {
            var translatorService = new TranslationService();

            var entity = await _repository.SelectAsync(id);
            if (entity == null)
                return null;

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(entity.Descricao);
            string textoPuro = htmlDoc.DocumentNode.InnerText;


            var descricao = System.Net.WebUtility.HtmlDecode(textoPuro);

            Guid valorEspecifico = new Guid("577513ab-678b-4f58-bb14-5544fbe781d4");

            if (entity.IdConteudoCategoria != valorEspecifico)
            {

                entity.Descricao = await translatorService.TranslateTextAsync(descricao, idioma);
                entity.NomeConteudo = await translatorService.TranslateTextAsync(entity.NomeConteudo, idioma);
                var ConteudoCategoria = await _repositoryCategoriaConteudos.SelectAsync(entity.IdConteudoCategoria);

                ConteudoCategoria.Nome = await translatorService.TranslateTextAsync(ConteudoCategoria.Nome, idioma);


                ConteudoCategoria.Tipo = await translatorService.TranslateTextAsync(ConteudoCategoria.Tipo, idioma);

                ConteudoCategoria.Descricao = await translatorService.TranslateTextAsync(ConteudoCategoria.Descricao, idioma);

                entity.ConteudoCategoria = ConteudoCategoria;
                await _repository.GetCompleteByImagensConteudos(id);
                await _userRepositorio.GetProdutoPorUserId(entity.UserId);
                return _mapper.Map<ConteudosDto>(entity);
            }


            await _repository.GetCompleteByImagensConteudos(id);
            await _userRepositorio.GetProdutoPorUserId(entity.UserId);
            return _mapper.Map<ConteudosDto>(entity);

        }

        public async Task<IEnumerable<ConteudosDto>> GetAll(string idioma, string tipo)
        {
            var translatorService = new TranslationService();
            //var listEntity = await _repository.GetTipoConteudos(tipo);

            var listEntity = await _repository.GetAllTipoConteudos();

            foreach (var item in listEntity)
            {
                item.NomeConteudo = await translatorService.TranslateTextAsync(item.NomeConteudo, idioma); 

                item.User =  await _userRepositorio.SelectAsync(item.UserId);
            }
  
            return _mapper.Map<IEnumerable<ConteudosDto>>(listEntity.AsQueryable().OrderByDescending(p => p.CreateAt).ToList());
        }

        public async Task<ConteudosDtoCreateResult> Post(ConteudosDtoCreate Conteudo)
        {
            var categoria = await _repositoryCategoriaConteudos.SelectAsync(Conteudo.IdConteudoCategoria);

            var user = await _userRepositorio.SelectAsync(Conteudo.UserId);
            if (user == null)
            {
                 throw new InvalidOperationException("Usuario não existe");
            }


            if (categoria != null)
            {
                var model = _mapper.Map<ConteudosEntity>(Conteudo);
  
                var result = await _repository.InsertAsync(model);
                result.User = user;

                result.ConteudoCategoria =  await _repositoryCategoriaConteudos.SelectAsync(result.IdConteudoCategoria);

                if (Conteudo.ImagensConteudos != null)
                    foreach (var item in Conteudo.ImagensConteudos)
                    {
                    
                        //Aqui subimos tudo para servidor Imgur nossas imagens e temos o retorno da url
                        var UrlImagens = await imgurUpload(item.UrlImagens);

                        var ImagensConteudosResponse = new ImagensConteudosDtoCreate
                        {
                            ConteudosId = result.Id,
                            UrlImagens = UrlImagens,
                            CodigoImagem = item.CodigoImagem
                        };                        

                        var modelImagensConteudos = _mapper.Map<ImagensConteudosEntity>(ImagensConteudosResponse);

                        await _repositoryImagensConteudos.InsertAsync(modelImagensConteudos);
                    }

                return _mapper.Map<ConteudosDtoCreateResult>(result);
            }
            return null;

        }

        public async Task<ConteudosDtoUpdateResult> Put(ConteudosDtoUpdate Conteudo)
        {

            var user = await _userRepositorio.SelectAsync(Conteudo.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("Usuario não existe");
            }

            var ConteudoCategoriaId = await _repository.SelectAsync(Conteudo.Id);
            if (ConteudoCategoriaId != null)
            {
                var model = _mapper.Map<ConteudosEntity>(Conteudo);       
                var result = await _repository.UpdateAsync(model);
                result.User = user;

                result.ConteudoCategoria = await _repositoryCategoriaConteudos.SelectAsync(result.IdConteudoCategoria);

                if (Conteudo.ImagensConteudos != null)
                    foreach (var item in Conteudo.ImagensConteudos)
                    {
                        var ImagensConteudosResponse = new ImagensConteudosDtoUpdate
                        {
                            Id = item.Id,
                            ConteudosId = item.ConteudosId,
                            UrlImagens = item.UrlImagens,
                            CodigoImagem = item.CodigoImagem
                        };

                        var modelImagensConteudos = _mapper.Map<ImagensConteudosEntity>(ImagensConteudosResponse);     
                        await _repositoryImagensConteudos.UpdateAsync(modelImagensConteudos);
                    }

                return _mapper.Map<ConteudosDtoUpdateResult>(result);
            }
            return null;
        }

        public async Task<string> imgurUpload(string base64String)
        {
            return Base64ToWebPConverter.ConvertBase64ToWebP(base64String);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }


    }
}
