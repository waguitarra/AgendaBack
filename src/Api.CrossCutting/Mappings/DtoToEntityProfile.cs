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
using Domain.Dtos.AgenteProduto;
using Domain.Dtos.AgendaAgente;

namespace Api.CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        { 
            #region User
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreate, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
            CreateMap<UserGetDadosBasicosDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdate, UserEntity>();
            #endregion

            #region ImagensP
            CreateMap<ImagensPDto, ImagensPEntity>().ReverseMap();
            CreateMap<ImagensPDtoCreate, ImagensPEntity>().ReverseMap();
            CreateMap<ImagensPDtoCreateResult, ImagensPEntity>().ReverseMap();
            CreateMap<ImagensPDtoUpdateResult, ImagensPEntity>().ReverseMap();
            #endregion

            #region Produtos
            CreateMap<ProdutosDto, ProdutosEntity>().ReverseMap();
            CreateMap<ProdutosDtoCreate, ProdutosEntity>().ReverseMap();
            CreateMap<ProdutosDtoCreateResult, ProdutosEntity>().ReverseMap();
            CreateMap<ProdutosDtoUpdateResult, ProdutosEntity>().ReverseMap();
            CreateMap<ProdutosDtoUpdate, ProdutosEntity>().ReverseMap();
            CreateMap<ProdutosDtoBasic, ProdutosEntity>().ReverseMap();
            #endregion

            #region Categoria
            CreateMap<CategoriaDto, CategoriaEntity>().ReverseMap();
            CreateMap<CategoriaDtoCreate, CategoriaEntity>().ReverseMap();
            CreateMap<CategoriaDtoCreateResult, CategoriaEntity>().ReverseMap();
            CreateMap<CategoriaDtoUpdate, CategoriaEntity>().ReverseMap();
            CreateMap<CategoriaDtoUpdateResult, CategoriaEntity>().ReverseMap();
            #endregion

            #region Cliente
            CreateMap<ClienteDto, ClienteEntity>().ReverseMap();
            #endregion

            #region TipoServico
            CreateMap<TipoServicoDto, TipoServicoEntity>().ReverseMap();
            CreateMap<TipoServicoDtoCreate, TipoServicoEntity>().ReverseMap();
            CreateMap<TipoServicoDtoCreateResult, TipoServicoEntity>().ReverseMap();
            CreateMap<TipoServicoDtoUpdate, TipoServicoEntity>().ReverseMap();
            CreateMap<TipoServicoDtoUpdateResult, TipoServicoEntity>().ReverseMap();
            #endregion

            #region MensagensP
            CreateMap<MensagensPDto, MensagensPEntity>().ReverseMap();
            CreateMap<MensagensPDtoCreate, MensagensPEntity>().ReverseMap();
            CreateMap<MensagensPDtoCreateResult, MensagensPEntity>().ReverseMap();
            CreateMap<MensagensPDtoUpdate, MensagensPEntity>().ReverseMap();
            CreateMap<MensagensPDtoUpdateResult, MensagensPEntity>().ReverseMap();
            #endregion

            #region ControleRigadores
            CreateMap<ControleRigadoresDto, ControleRigadoresEntity>().ReverseMap();
            CreateMap<ControleRigadoresDtoCreate, ControleRigadoresEntity>().ReverseMap();
            CreateMap<ControleRigadoresDtoCreateResult, ControleRigadoresEntity>().ReverseMap();
            CreateMap<ControleRigaroresDtoUpdate, ControleRigadoresEntity>().ReverseMap();
            CreateMap<ControleRigaroresDtoUpdateResult, ControleRigadoresEntity>().ReverseMap();
            #endregion

            #region CurtidasP
            CreateMap<CurtidasPDto, CurtidasPEntity>().ReverseMap();
            CreateMap<CurtidasPDtoCreate, CurtidasPEntity>().ReverseMap();
            CreateMap<CurtidasPDtoCreateResult, CurtidasPEntity>().ReverseMap();
            CreateMap<CurtidasPDtoUpdate, CurtidasPEntity>().ReverseMap();
            CreateMap<CurtidasPDtoUpdateResult, CurtidasPEntity>().ReverseMap();
            #endregion

            #region Denuncias
            CreateMap<DenunciasDto, DenunciasEntity>().ReverseMap();
            CreateMap<DenunciasDtoCreate, DenunciasEntity>().ReverseMap();
            CreateMap<DenunciasDtoCreateResult, DenunciasEntity>().ReverseMap();
            CreateMap<DenunciasDtoUpdate, DenunciasEntity>().ReverseMap();
            CreateMap<DenunciasDtoUpdateResult, DenunciasEntity>().ReverseMap();
            #endregion

            #region UserFornecedor
            CreateMap<UserFornecedorDto, UserFornecedorEntity>().ReverseMap();
            CreateMap<UserFornecedorDtoCreate, UserFornecedorEntity>().ReverseMap();
            CreateMap<UserFornecedorDtoCreateResult, UserFornecedorEntity>().ReverseMap();
            CreateMap<UserFornecedorDtoUpdate, UserFornecedorEntity>().ReverseMap();
            CreateMap<UserFornecedorDtoUpdateResult, UserFornecedorEntity>().ReverseMap();
            #endregion

            #region DenunciaProdutoUsuario
            CreateMap<DenunciaProdutoUsuarioDto, DenunciaProdutoUsuarioEntity>().ReverseMap();
            CreateMap<DenunciaProdutoUsuarioDtoCreate, DenunciaProdutoUsuarioEntity>().ReverseMap();
            CreateMap<DenunciaProdutoUsuarioDtoCreateResult, DenunciaProdutoUsuarioEntity>().ReverseMap();
            CreateMap<DenunciaProdutoUsuarioDtoUpdate, DenunciaProdutoUsuarioEntity>().ReverseMap();
            CreateMap<DenunciaProdutoUsuarioDtoUpdateResult, DenunciaProdutoUsuarioEntity>().ReverseMap();
            #endregion

            #region FornecedorProdutos
            CreateMap<FornecedorProdutosDto, FornecedorProdutosEntity>().ReverseMap();
            CreateMap<FornecedorProdutosDtoCreate, FornecedorProdutosEntity>().ReverseMap();
            CreateMap<FornecedorProdutosDtoCreateResult, FornecedorProdutosEntity>().ReverseMap();
            CreateMap<FornecedorProdutosDtoUpdateResult, FornecedorProdutosEntity>().ReverseMap();
            CreateMap<FornecedorProdutosDtoUpdate, FornecedorProdutosEntity>().ReverseMap();
            #endregion

            #region ImagensF
            CreateMap<ImagensPDto, ImagensPEntity>().ReverseMap();
            CreateMap<ImagensPDtoCreate, ImagensPEntity>().ReverseMap();
            CreateMap<ImagensPDtoCreateResult, ImagensPEntity>().ReverseMap();
            CreateMap<ImagensPDtoUpdateResult, ImagensPEntity>().ReverseMap();
            CreateMap< ImagensPDtoUpdate, ImagensPEntity>().ReverseMap();
            #endregion

            #region ImagensF
            CreateMap<ImagensFDto, ImagensFEntity>().ReverseMap();
            CreateMap<ImagensFDtoCreate, ImagensFEntity>().ReverseMap();
            CreateMap<ImagensFDtoCreateResult, ImagensFEntity>().ReverseMap();
            CreateMap<ImagensFDtoUpdateResult, ImagensFEntity>().ReverseMap();
            #endregion

            #region TermosResponsabilidades
            CreateMap<TermosResponsabilidadesDto, TermosResponsabilidadesEntity>().ReverseMap();
            CreateMap<TermosResponsabilidadesDtoCreate, TermosResponsabilidadesEntity>().ReverseMap();
            CreateMap<TermosResponsabilidadesDtoCreateResult, TermosResponsabilidadesEntity>().ReverseMap();
            CreateMap<TermosResponsabilidadesDtoUpdateResult, TermosResponsabilidadesEntity>().ReverseMap();
            #endregion

            #region EmailsNewsletter
            CreateMap<EmailsNewsletterDto, EmailsNewsletterEntity>().ReverseMap();
            CreateMap<EmailsNewsletterDtoCreate, EmailsNewsletterEntity>().ReverseMap();
            CreateMap<EmailsNewsletterDtoCreateResult, EmailsNewsletterEntity>().ReverseMap();
            CreateMap<EmailsNewsletterDtoUpdateResult, EmailsNewsletterEntity>().ReverseMap();
            #endregion

            #region ConteudoCategoria
            CreateMap<ConteudoCategoriaDto, ConteudoCategoriaEntity>().ReverseMap();
            CreateMap<ConteudoCategoriaDtoCreate, ConteudoCategoriaEntity>().ReverseMap();
            CreateMap<ConteudoCategoriaDtoCreateResult, ConteudoCategoriaEntity>().ReverseMap();
            CreateMap<ConteudoCategoriaDtoUpdateResult, ConteudoCategoriaEntity>().ReverseMap();
            #endregion

            #region Conteudos
            CreateMap<ConteudosDto, ConteudosEntity>().ReverseMap();
            CreateMap<ConteudosDtoCreate, ConteudosEntity>().ReverseMap();
            CreateMap<ConteudosDtoCreateResult, ConteudosEntity>().ReverseMap();
            CreateMap<ConteudosDtoUpdateResult, ConteudosEntity>().ReverseMap();
            #endregion

            #region ImagensConteudos
            CreateMap<ImagensConteudosDto, ImagensConteudosEntity>().ReverseMap();
            CreateMap<ImagensConteudosDtoCreate, ImagensConteudosEntity>().ReverseMap();
            CreateMap<ImagensConteudosDtoCreateResult, ImagensConteudosEntity>().ReverseMap();
            CreateMap<ImagensConteudosDtoUpdateResult, ImagensConteudosEntity>().ReverseMap();
            #endregion

            #region CurtidasConteudos
            CreateMap<CurtidasConteudosDto, CurtidasConteudosEntity>().ReverseMap();
            CreateMap<CurtidasConteudosDtoCreate, CurtidasConteudosEntity>().ReverseMap();
            CreateMap<CurtidasConteudosDtoCreateResult, CurtidasConteudosEntity>().ReverseMap();
            CreateMap<CurtidasConteudosDtoUpdateResult, CurtidasConteudosEntity>().ReverseMap();
            #endregion

            #region Agente
            CreateMap<AgenteDto, AgenteEntity>().ReverseMap();
            #endregion

            #region AgenteProdutos
            CreateMap<AgentesProdutosDto, AgenteProdutosEntity>().ReverseMap();
            #endregion

            #region AgendaAgente
            CreateMap<AgendaAgenteDto, AgendaAgente>().ReverseMap();
            CreateMap<AgendaAgenteHorasDto, AgendaAgente>().ReverseMap();
            CreateMap<AgendaAgenteResultDto, AgendaAgente>().ReverseMap();
            CreateMap<AgendaAgenteResultDto, AgendaAgenteHorasDto>().ReverseMap();
            #endregion



        }
    }
}
