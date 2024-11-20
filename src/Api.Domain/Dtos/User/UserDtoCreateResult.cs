using System;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        //public string Tipo { get; set; }
        public string ImagemLogin { get; set; }
        public bool Ativo { get; set; }
        public Guid TermosResponsabilidades { get; set; }

        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
    }
}
