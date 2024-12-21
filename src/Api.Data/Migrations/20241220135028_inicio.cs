using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgenteProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    AgenteId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenteProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    TipoCategoria = table.Column<string>(maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    UrlImagens = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: true),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    AgenteId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    json = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConteudoCategoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    UrlImagens = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteudoCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    TipoDenuncias = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailsNewsletter",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    TipoNewsletter = table.Column<int>(nullable: false),
                    DescricaoNewsletter = table.Column<string>(nullable: true),
                    HTML = table.Column<string>(maxLength: 5000, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsNewsletter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermosResponsabilidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Responsabilidades = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermosResponsabilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    TipoCategoria = table.Column<string>(maxLength: 40, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    UrlImagens = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Sexo = table.Column<string>(maxLength: 11, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    ImagemLogin = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    CodEstado = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    TokenRedes = table.Column<string>(nullable: true),
                    TokenCalendar = table.Column<string>(nullable: true),
                    EnviarEmail = table.Column<bool>(nullable: false),
                    Delete = table.Column<DateTime>(nullable: true),
                    UserLogado = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    TermosResponsabilidades = table.Column<Guid>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    TrocarSenha = table.Column<bool>(nullable: false),
                    Idioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    NomeEmpresa = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    TokenRedes = table.Column<string>(nullable: true),
                    CodRegistroEmpresas = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    CodEstado = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    LogoTipo = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true),
                    Delete = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conteudos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    NomeConteudo = table.Column<string>(nullable: true),
                    IdConteudoCategoria = table.Column<Guid>(nullable: false),
                    ConteudoCategoriaId = table.Column<Guid>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 5000, nullable: false),
                    Json = table.Column<string>(nullable: true),
                    TotalCurtidas = table.Column<int>(nullable: false),
                    IdImagensConteudos = table.Column<Guid>(nullable: false),
                    VideoRelacionado = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Idioma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conteudos_ConteudoCategoria_ConteudoCategoriaId",
                        column: x => x.ConteudoCategoriaId,
                        principalTable: "ConteudoCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conteudos_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControleRigadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mac = table.Column<string>(nullable: true),
                    Cabecario = table.Column<string>(nullable: true),
                    Humidade = table.Column<string>(nullable: true),
                    Temperatura = table.Column<string>(nullable: true),
                    StatusBomba1 = table.Column<string>(nullable: true),
                    StatusBomba2 = table.Column<string>(nullable: true),
                    NivelTanque1 = table.Column<string>(nullable: true),
                    NivelTanque2 = table.Column<string>(nullable: true),
                    Fonte1 = table.Column<string>(nullable: true),
                    Fonte2 = table.Column<string>(nullable: true),
                    IpPlaca = table.Column<string>(nullable: true),
                    stsRL_0 = table.Column<bool>(nullable: false),
                    stsRL_1 = table.Column<bool>(nullable: false),
                    stsRL_2 = table.Column<bool>(nullable: false),
                    stsRL_3 = table.Column<bool>(nullable: false),
                    stsRL_4 = table.Column<bool>(nullable: false),
                    temp_0 = table.Column<bool>(nullable: false),
                    umid_0 = table.Column<bool>(nullable: false),
                    sens_0 = table.Column<bool>(nullable: false),
                    sens_1 = table.Column<bool>(nullable: false),
                    sens_2 = table.Column<bool>(nullable: false),
                    sens_3 = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleRigadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleRigadores_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    NomeProduto = table.Column<string>(maxLength: 40, nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    ClienteUsuarioId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    TipoServicoId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 400, nullable: false),
                    KM = table.Column<double>(nullable: false),
                    Delete = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Idioma = table.Column<string>(nullable: true),
                    CurtidasTotal = table.Column<int>(nullable: false),
                    Mapa = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    NomeProdutoFornecedor = table.Column<string>(nullable: true),
                    UserFornecedorId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    KM = table.Column<double>(nullable: false),
                    MaxKM = table.Column<double>(nullable: false),
                    Delete = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    CurtidasTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorProdutos_UserFornecedor_UserFornecedorId",
                        column: x => x.UserFornecedorId,
                        principalTable: "UserFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurtidasConteudos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ConteudosId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Curtidas = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurtidasConteudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurtidasConteudos_Conteudos_ConteudosId",
                        column: x => x.ConteudosId,
                        principalTable: "Conteudos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurtidasConteudos_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensConteudos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UrlImagens = table.Column<string>(nullable: true),
                    ConteudosId = table.Column<Guid>(nullable: false),
                    CodigoImagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensConteudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensConteudos_Conteudos_ConteudosId",
                        column: x => x.ConteudosId,
                        principalTable: "Conteudos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Imagem = table.Column<string>(type: "MEDIUMTEXT", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agente_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Agente_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DenunciaProdutoUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ProdutosId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DenunciasId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenunciaProdutoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenunciaProdutoUsuario_Denuncias_DenunciasId",
                        column: x => x.DenunciasId,
                        principalTable: "Denuncias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DenunciaProdutoUsuario_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DenunciaProdutoUsuario_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UrlImagens = table.Column<string>(nullable: true),
                    ProdutosId = table.Column<Guid>(nullable: false),
                    CodigoImagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensP_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MensagensP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ProdutosId = table.Column<Guid>(nullable: false),
                    ClienteUsuarioId = table.Column<Guid>(nullable: false),
                    IdProdutoUsuarioTroca = table.Column<Guid>(nullable: false),
                    Mensagens = table.Column<string>(type: "varchar(500)", nullable: true),
                    Imagem = table.Column<string>(nullable: true),
                    MensagenLida = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagensP_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensagensP_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurtidasP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    ProdutosId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Curtidas = table.Column<bool>(nullable: false),
                    FornecedorProdutosId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurtidasP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurtidasP_FornecedorProdutos_FornecedorProdutosId",
                        column: x => x.FornecedorProdutosId,
                        principalTable: "FornecedorProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurtidasP_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurtidasP_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensF",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UrlImagens = table.Column<string>(nullable: true),
                    FornecedorProdutosId = table.Column<Guid>(nullable: false),
                    CodigoImagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensF_FornecedorProdutos_FornecedorProdutosId",
                        column: x => x.FornecedorProdutosId,
                        principalTable: "FornecedorProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agente_Ativo",
                table: "Agente",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_Descricao",
                table: "Agente",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_Email",
                table: "Agente",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_Nome",
                table: "Agente",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_ProdutoId",
                table: "Agente",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_UserId",
                table: "Agente",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgenteProduto_AgenteId",
                table: "AgenteProduto",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgenteProduto_ProdutoId",
                table: "AgenteProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Ativo",
                table: "Categoria",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Descricao",
                table: "Categoria",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Pais",
                table: "Categoria",
                column: "Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Tipo",
                table: "Categoria",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_TipoCategoria",
                table: "Categoria",
                column: "TipoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_UrlImagens",
                table: "Categoria",
                column: "UrlImagens");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Descricao",
                table: "Cliente",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Cliente",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                table: "Cliente",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Telefone",
                table: "Cliente",
                column: "Telefone");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoCategoria_Ativo",
                table: "ConteudoCategoria",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoCategoria_Descricao",
                table: "ConteudoCategoria",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoCategoria_Nome",
                table: "ConteudoCategoria",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoCategoria_Tipo",
                table: "ConteudoCategoria",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoCategoria_UrlImagens",
                table: "ConteudoCategoria",
                column: "UrlImagens");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_ConteudoCategoriaId",
                table: "Conteudos",
                column: "ConteudoCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_IdConteudoCategoria",
                table: "Conteudos",
                column: "IdConteudoCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_Json",
                table: "Conteudos",
                column: "Json");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_NomeConteudo",
                table: "Conteudos",
                column: "NomeConteudo");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_TotalCurtidas",
                table: "Conteudos",
                column: "TotalCurtidas");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_UserId",
                table: "Conteudos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_VideoRelacionado",
                table: "Conteudos",
                column: "VideoRelacionado");

            migrationBuilder.CreateIndex(
                name: "IX_ControleRigadores_UserId",
                table: "ControleRigadores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurtidasConteudos_ConteudosId",
                table: "CurtidasConteudos",
                column: "ConteudosId");

            migrationBuilder.CreateIndex(
                name: "IX_CurtidasConteudos_UserId",
                table: "CurtidasConteudos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurtidasP_FornecedorProdutosId",
                table: "CurtidasP",
                column: "FornecedorProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_CurtidasP_ProdutosId",
                table: "CurtidasP",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_CurtidasP_UserId",
                table: "CurtidasP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DenunciaProdutoUsuario_DenunciasId",
                table: "DenunciaProdutoUsuario",
                column: "DenunciasId");

            migrationBuilder.CreateIndex(
                name: "IX_DenunciaProdutoUsuario_ProdutosId",
                table: "DenunciaProdutoUsuario",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_DenunciaProdutoUsuario_UserId",
                table: "DenunciaProdutoUsuario",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_Descricao",
                table: "Denuncias",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_TipoDenuncias",
                table: "Denuncias",
                column: "TipoDenuncias");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsNewsletter_Ativo",
                table: "EmailsNewsletter",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsNewsletter_DescricaoNewsletter",
                table: "EmailsNewsletter",
                column: "DescricaoNewsletter");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsNewsletter_Nome",
                table: "EmailsNewsletter",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsNewsletter_Pais",
                table: "EmailsNewsletter",
                column: "Pais");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsNewsletter_TipoNewsletter",
                table: "EmailsNewsletter",
                column: "TipoNewsletter");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorProdutos_UserFornecedorId",
                table: "FornecedorProdutos",
                column: "UserFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensConteudos_CodigoImagem",
                table: "ImagensConteudos",
                column: "CodigoImagem");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensConteudos_ConteudosId",
                table: "ImagensConteudos",
                column: "ConteudosId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensF_CodigoImagem",
                table: "ImagensF",
                column: "CodigoImagem");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensF_FornecedorProdutosId",
                table: "ImagensF",
                column: "FornecedorProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensP_CodigoImagem",
                table: "ImagensP",
                column: "CodigoImagem");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensP_ProdutosId",
                table: "ImagensP",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensP_IdProdutoUsuarioTroca",
                table: "MensagensP",
                column: "IdProdutoUsuarioTroca");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensP_MensagenLida",
                table: "MensagensP",
                column: "MensagenLida");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensP_Mensagens",
                table: "MensagensP",
                column: "Mensagens");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensP_ProdutosId",
                table: "MensagensP",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensP_UserId",
                table: "MensagensP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoServicoId",
                table: "Produtos",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UserId",
                table: "Produtos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TermosResponsabilidades_Pais",
                table: "TermosResponsabilidades",
                column: "Pais");

            migrationBuilder.CreateIndex(
                name: "IX_TipoServico_Ativo",
                table: "TipoServico",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoServico_Pais",
                table: "TipoServico",
                column: "Pais");

            migrationBuilder.CreateIndex(
                name: "IX_TipoServico_Tipo",
                table: "TipoServico",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFornecedor_Email",
                table: "UserFornecedor",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agente");

            migrationBuilder.DropTable(
                name: "AgenteProduto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ControleRigadores");

            migrationBuilder.DropTable(
                name: "CurtidasConteudos");

            migrationBuilder.DropTable(
                name: "CurtidasP");

            migrationBuilder.DropTable(
                name: "DenunciaProdutoUsuario");

            migrationBuilder.DropTable(
                name: "EmailsNewsletter");

            migrationBuilder.DropTable(
                name: "ImagensConteudos");

            migrationBuilder.DropTable(
                name: "ImagensF");

            migrationBuilder.DropTable(
                name: "ImagensP");

            migrationBuilder.DropTable(
                name: "MensagensP");

            migrationBuilder.DropTable(
                name: "TermosResponsabilidades");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Conteudos");

            migrationBuilder.DropTable(
                name: "FornecedorProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ConteudoCategoria");

            migrationBuilder.DropTable(
                name: "UserFornecedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "TipoServico");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
