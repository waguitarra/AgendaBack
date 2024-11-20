using System;

namespace Api.Domain.Dtos.User
{
    public class UserLatLogDtoUpdate
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid TermosResponsabilidades { get; set; }


        public bool EnviarEmail { get; set; }
        public bool TrocarSenha { get; set; }
        public string Idioma { get; set; }
        public string Pais { get; set; }
        public string CodEstado { get; set; }
        public string Estado { get; set; }

        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }

    }
}
