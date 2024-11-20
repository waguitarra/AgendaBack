using Api.Domain.Dtos.Categorias;
using Api.Domain.Dtos.ControleRigadores;
using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Dtos.Denuncias;
using Api.Domain.Dtos.ImagensP;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos;
using Api.Domain.Dtos.TipoServico;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.UserFornecedor;
using Api.Domain.Entities;
using AutoMapper;
using Domain.Dtos.DenunciaProdutoUsuario;
using Domain.Entities;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Dtos.TermosResponsabilidades;
using Domain.Dtos.EmailsNewsletter;
using Domain.Dtos.ConteudoCategoria;
using Domain.Dtos.Conteudo;
using Api.Domain.Dtos.CurtidasConteudosP;
using Domain.Dtos.Client;
using Domain.Dtos.Agente;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserEntity, UserDto>()
               .ReverseMap();
            CreateMap<UserEntity, UserDtoCreateResult>()
               .ReverseMap();
            CreateMap<UserEntity, UserDtoUpdateResult>()
                .ReverseMap();
            CreateMap<UserEntity, UserGetDadosBasicosDto>()
               .ReverseMap();

            #endregion

            #region  ImagensP
            CreateMap<ImagensPEntity, ImagensPDto>()
                .ReverseMap();
            CreateMap<ImagensPEntity, ImagensPDtoCreate>()
               .ReverseMap();
            CreateMap<ImagensPEntity, ImagensPDtoCreateResult>()
               .ReverseMap();
            CreateMap<ImagensPEntity, ImagensPDtoUpdateResult>()
               .ReverseMap();
            CreateMap<ImagensPEntity, ImagensPDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  Produtos 
            CreateMap<ProdutosEntity, ProdutosDto>()
                .ReverseMap();
            CreateMap<ProdutosEntity, ProdutosDtoCreate>()
               .ReverseMap();
            CreateMap<ProdutosEntity, ProdutosDtoCreateResult>()
               .ReverseMap();
            CreateMap<ProdutosEntity, ProdutosDtoUpdateResult>()
               .ReverseMap();
            CreateMap<ProdutosEntity, ProdutosDtoUpdate>()
                .ReverseMap();
            CreateMap<ProdutosEntity, ProdutosDtoBasic>()
                .ReverseMap();
            #endregion

            #region  Categoria
            CreateMap<CategoriaEntity, CategoriaDto>()
               .ReverseMap();
            CreateMap<CategoriaEntity, CategoriaDtoCreate>()
               .ReverseMap();
            CreateMap<CategoriaEntity, CategoriaDtoCreateResult>()
                .ReverseMap();
            CreateMap<CategoriaEntity, CategoriaDtoUpdate>()
                .ReverseMap();
            CreateMap<CategoriaEntity, CategoriaDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  Cliente
            CreateMap<ClienteEntity, ClienteDto>()
               .ReverseMap();

            #endregion

            #region  TipoServico
            CreateMap<TipoServicoEntity, TipoServicoDto>()
               .ReverseMap();
            CreateMap<TipoServicoEntity, TipoServicoDtoCreate>()
                .ReverseMap();
            CreateMap<TipoServicoEntity, TipoServicoDtoCreateResult>()
                .ReverseMap();
            CreateMap<TipoServicoEntity, TipoServicoDtoUpdate>()
                .ReverseMap();
            CreateMap<TipoServicoEntity, TipoServicoDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  MensagensP
            CreateMap<MensagensPEntity, MensagensPDto>()
               .ReverseMap();
            CreateMap<MensagensPEntity, MensagensPDtoCreate>()
               .ReverseMap();
            CreateMap<MensagensPEntity, MensagensPDtoCreateResult>()
               .ReverseMap();
            CreateMap<MensagensPEntity, MensagensPDtoUpdate>()
               .ReverseMap();
            CreateMap<MensagensPEntity, MensagensPDtoUpdateResult>()
               .ReverseMap();
            #endregion

            #region  ControleRigadores
            CreateMap<ControleRigadoresEntity, ControleRigadoresDto>()
               .ReverseMap();
            CreateMap<ControleRigadoresEntity, ControleRigadoresDtoCreate>()
               .ReverseMap();
            CreateMap<ControleRigadoresEntity, ControleRigadoresDtoCreateResult>()
               .ReverseMap();
            CreateMap<ControleRigadoresEntity, ControleRigaroresDtoUpdate>()
                .ReverseMap();
            CreateMap<ControleRigadoresEntity, ControleRigaroresDtoUpdateResult>()
               .ReverseMap();
            #endregion

            #region  CurtidasP
            CreateMap<CurtidasPEntity, CurtidasPDto>()
                .ReverseMap();
            CreateMap<CurtidasPEntity, CurtidasPDtoCreate>()
                .ReverseMap();
            CreateMap<CurtidasPEntity, CurtidasPDtoCreateResult>()
                .ReverseMap();
            CreateMap<CurtidasPEntity, CurtidasPDtoUpdate>()
                .ReverseMap();
            CreateMap<CurtidasPEntity, CurtidasPDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  Denuncias
            CreateMap<DenunciasEntity, DenunciasDto>()
               .ReverseMap();
            CreateMap<DenunciasEntity, DenunciasDtoCreate>()
               .ReverseMap();
            CreateMap<DenunciasEntity, DenunciasDtoCreateResult>()
                .ReverseMap();
            CreateMap<DenunciasEntity, DenunciasDtoUpdate>()
                .ReverseMap();
            CreateMap<DenunciasEntity, DenunciasDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region UserFornecedor
            CreateMap<UserFornecedorEntity, UserFornecedorDto>()
               .ReverseMap();
            CreateMap<UserFornecedorEntity, UserFornecedorDtoCreate>()
               .ReverseMap();
            CreateMap<UserFornecedorEntity, UserFornecedorDtoCreateResult>()
               .ReverseMap();
            CreateMap<UserFornecedorEntity, UserFornecedorDtoUpdate>()
               .ReverseMap();
            CreateMap<UserFornecedorEntity, UserFornecedorDtoUpdateResult>()
               .ReverseMap();
            #endregion

            #region DenunciaProdutoUsuario
            CreateMap<DenunciaProdutoUsuarioEntity, DenunciaProdutoUsuarioDto>()
               .ReverseMap();
            CreateMap<DenunciaProdutoUsuarioEntity, DenunciaProdutoUsuarioDtoCreate>()
                .ReverseMap();
            CreateMap<DenunciaProdutoUsuarioEntity, DenunciaProdutoUsuarioDtoCreateResult>()
               .ReverseMap();
            CreateMap<DenunciaProdutoUsuarioEntity, DenunciaProdutoUsuarioDtoUpdate>()
                .ReverseMap();
            CreateMap<DenunciaProdutoUsuarioEntity, DenunciaProdutoUsuarioDtoUpdateResult>()
               .ReverseMap();
            #endregion

            #region  FornecedorProdutos 
            CreateMap<FornecedorProdutosEntity, FornecedorProdutosDto>()
                .ReverseMap();
            CreateMap<FornecedorProdutosEntity, FornecedorProdutosDtoCreate>()
               .ReverseMap();
            CreateMap<FornecedorProdutosEntity, FornecedorProdutosDtoCreateResult>()
               .ReverseMap();
            CreateMap<FornecedorProdutosEntity, FornecedorProdutosDtoUpdateResult>()
               .ReverseMap();
            CreateMap<FornecedorProdutosEntity, FornecedorProdutosDtoUpdate>()
                .ReverseMap();

            #endregion

            #region  ImagensF
            CreateMap<ImagensFEntity, ImagensFDto>()
                .ReverseMap();
            CreateMap<ImagensFEntity, ImagensFDtoCreate>()
               .ReverseMap();
            CreateMap<ImagensFEntity, ImagensFDtoCreateResult>()
               .ReverseMap();
            CreateMap<ImagensFEntity, ImagensFDtoUpdateResult>()
               .ReverseMap();
            CreateMap<ImagensFEntity, ImagensFDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  TermosResponsabilidades
            CreateMap<TermosResponsabilidadesEntity, TermosResponsabilidadesDto>()
                .ReverseMap();
            CreateMap<TermosResponsabilidadesEntity, TermosResponsabilidadesDtoCreate>()
               .ReverseMap();
            CreateMap<TermosResponsabilidadesEntity, TermosResponsabilidadesDtoCreateResult>()
               .ReverseMap();
            CreateMap<TermosResponsabilidadesEntity, TermosResponsabilidadesDtoUpdateResult>()
               .ReverseMap();
            CreateMap<TermosResponsabilidadesEntity, TermosResponsabilidadesDtoUpdateResult>()
                .ReverseMap();
            #endregion              

            #region  EmailsNewsletter
            CreateMap<EmailsNewsletterEntity, EmailsNewsletterDto>()
                .ReverseMap();
            CreateMap<EmailsNewsletterEntity, EmailsNewsletterDtoCreate>()
               .ReverseMap();
            CreateMap<EmailsNewsletterEntity, EmailsNewsletterDtoCreateResult>()
               .ReverseMap();
            CreateMap<EmailsNewsletterEntity, EmailsNewsletterDtoUpdateResult>()
               .ReverseMap();
            CreateMap<EmailsNewsletterEntity, EmailsNewsletterDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  ConteudoCategoria
            CreateMap<ConteudoCategoriaEntity, ConteudoCategoriaDto>()
                .ReverseMap();
            CreateMap<ConteudoCategoriaEntity, ConteudoCategoriaDtoCreate>()
               .ReverseMap();
            CreateMap<ConteudoCategoriaEntity, ConteudoCategoriaDtoCreateResult>()
               .ReverseMap();
            CreateMap<ConteudoCategoriaEntity, ConteudoCategoriaDtoUpdateResult>()
               .ReverseMap();
            CreateMap<ConteudoCategoriaEntity, ConteudoCategoriaDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  Conteudos
            CreateMap<ConteudosEntity, ConteudosDto>()
                .ReverseMap();
            CreateMap<ConteudosEntity, ConteudosDtoCreate>()
               .ReverseMap();
            CreateMap<ConteudosEntity, ConteudosDtoCreateResult>()
               .ReverseMap();
            CreateMap<ConteudosEntity, ConteudosDtoUpdateResult>()
               .ReverseMap();
            CreateMap<ConteudosEntity, ConteudosDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  ImagensConteudos
            CreateMap<ImagensConteudosEntity, ImagensConteudosDto>()
                .ReverseMap();
            CreateMap<ImagensConteudosEntity, ImagensConteudosDtoCreate>()
               .ReverseMap();
            CreateMap<ImagensConteudosEntity, ImagensConteudosDtoCreateResult>()
               .ReverseMap();
            CreateMap<ImagensConteudosEntity, ImagensConteudosDtoUpdateResult>()
               .ReverseMap();
            CreateMap<ImagensConteudosEntity, ImagensConteudosDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region  CurtidasConteudos
            CreateMap<CurtidasConteudosEntity, CurtidasConteudosDto>()
                .ReverseMap();
            CreateMap<CurtidasConteudosEntity, CurtidasConteudosDtoCreate>()
               .ReverseMap();
            CreateMap<CurtidasConteudosEntity, CurtidasConteudosDtoCreateResult>()
               .ReverseMap();
            CreateMap<CurtidasConteudosEntity, CurtidasConteudosDtoUpdateResult>()
               .ReverseMap();
            CreateMap<CurtidasConteudosEntity, CurtidasConteudosDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region Agente
            CreateMap<AgenteEntity, AgenteDto>().ReverseMap();
            #endregion
        }
    }
}
