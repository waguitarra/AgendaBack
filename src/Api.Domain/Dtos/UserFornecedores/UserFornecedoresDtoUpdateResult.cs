using System;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.UserFornecedor
{
    public class UserFornecedorDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string CodRegistroEmpresas { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public double Latitude { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public double Longitude { get; set; }
        public string logoTipo { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public DateTime? UpdateAt { get; set; }


    }
}
