using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

namespace Api.Domain.Dtos.UserFornecedor
{
    public class UserFornecedorDtoUpdate
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string NomeEmpresa { get; set; }
        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Password deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }
        public string TokenRedes { get; set; }
        public string CodRegistroEmpresas { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string logoTipo { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }


    }
}
