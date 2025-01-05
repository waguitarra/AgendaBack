using Api.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ClienteEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid AgenteId { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid UserId { get; set; }
        public string json { get; set;}
        public List<AgendaAgenteEntity> AgendaAgente { get; set; }
    }


}
