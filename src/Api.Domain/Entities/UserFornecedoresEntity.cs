using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class UserFornecedorEntity : BaseEntity
    {
        public string NomeEmpresa { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TokenRedes { get; set; }
        public string CodRegistroEmpresas { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public string Numero { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LogoTipo { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public DateTime Delete { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<FornecedorProdutosEntity> FornecedorProdutos { get; set; }
        //public IEnumerable<MensagensPEntity> MensagensP { get; set; }

    }
}
