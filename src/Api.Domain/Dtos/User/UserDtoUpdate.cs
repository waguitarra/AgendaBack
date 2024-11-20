using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "Email é um campo obrigatório")]
        //[EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        //[StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        //public string Email { get; set; }


        //[Required(ErrorMessage = "Password é um campo obrigatório")]
        //[StringLength(60, ErrorMessage = "Password deve ter no máximo {8} caracteres.")]
        //public string Password { get; set; }

        [Required(ErrorMessage = "Código postal facilita sua busca de pessoas mais proxima de sua casa")]
        [StringLength(60, ErrorMessage = "Código postal deve ter no máximo {5} caracteres.")]

        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public string Tipo { get; set; }
        public string ImagemLogin { get; set; }
        //public string TokenRedes { get; set; }
        public DateTime? Delete { get; set; }
        public bool Ativo { get; set; }
        public DateTime? UserLogado { get; set; }
        public bool ModuloEscuro { get; set; }
        public Guid TermosResponsabilidades { get; set; }

        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public bool EnviarEmail { get; set; }
        public bool TrocarSenha { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }


    }
}
