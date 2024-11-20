using System;

namespace Api.Domain.Dtos.ControleRigadores
{
    public class ControleRigadoresDto
    {
        public Guid Id { get; set; }
        public string Mac { get; set; }
        public string Cabecario { get; set; }
        public string Humidade { get; set; }
        public string Temperatura { get; set; }
        public string StatusBomba1 { get; set; }
        public string StatusBomba2 { get; set; }
        public string NivelTanque1 { get; set; }
        public string NivelTanque2 { get; set; }
        public string Fonte1 { get; set; }
        public string Fonte2 { get; set; }
        public string IpPlaca { get; set; }

        public bool stsRL_0 { get; set; }
        public bool stsRL_1 { get; set; }
        public bool stsRL_2 { get; set; }
        public bool stsRL_3 { get; set; }
        public bool stsRL_4 { get; set; }

        public bool temp_0 { get; set; }
        public bool umid_0 { get; set; }

        public bool sens_0 { get; set; }
        public bool sens_1 { get; set; }
        public bool sens_2 { get; set; }
        public bool sens_3 { get; set; }

        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }

    }
}

