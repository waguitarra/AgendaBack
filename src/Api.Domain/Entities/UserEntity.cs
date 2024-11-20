using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Tipo { get; set; }
        public string ImagemLogin { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public string Pais { get; set; }
        public string TokenRedes { get; set; }
        public string TokenCalendar { get; set; }
        public bool EnviarEmail { get; set; }
        public DateTime? Delete { get; set; }
        public DateTime? UserLogado { get; set; }
        public bool Ativo { get; set; }
        public Guid TermosResponsabilidades { get; set; }
        public string Endereco { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public bool TrocarSenha { get; set; }
        public string Idioma { get; set; }
        public IEnumerable<ProdutosEntity> Produtos { get; set; }
        public IEnumerable<AgenteEntity> Agente { get; set; }
        public IEnumerable<MensagensPEntity> MensagensP { get; set; }
        public IEnumerable<ControleRigadoresEntity> ControleRigadores { get; set; }
        public IEnumerable<CurtidasPEntity> CurtidasP { get; set; }
        public IEnumerable<CurtidasConteudosEntity> CurtidasConteudos { get; set; }
        public IEnumerable<ConteudosEntity> Conteudos { get; set; }
        public IEnumerable<DenunciaProdutoUsuarioEntity> DenunciaProdutoUsuario { get; set; }
    }
}
