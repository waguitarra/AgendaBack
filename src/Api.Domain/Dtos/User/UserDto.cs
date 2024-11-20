using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Protudos;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public IEnumerable<ProdutosDto> Produtos { get; set; }
        public DateTime CreateAt { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public string Tipo { get; set; }
        public string ImagemLogin { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public bool Ativo { get; set; }
        public DateTime Delete { get; set; }
        public DateTime UserLogado { get; set; }
        public bool EnviarEmail { get; set; }
        public bool TrocarSenha { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public Guid TermosResponsabilidades { get; set; }



    }
}
