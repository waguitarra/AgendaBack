using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Client
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid AgenteId { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid UserId { get; set; }
        public string json { get; set; }
    }
}
