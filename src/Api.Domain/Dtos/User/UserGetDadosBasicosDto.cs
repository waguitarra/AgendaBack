using System;

namespace Api.Domain.Dtos.User
{
    public class UserGetDadosBasicosDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public string ImagemLogin { get; set; }
        public bool Ativo { get; set; }
        public bool ModuloEscuro { get; set; }
        public DateTime? UserLogado { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public bool EnviarEmail { get; set; }
        public bool TrocarSenha { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
    }
}
