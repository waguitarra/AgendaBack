using System;

namespace Domain.Dtos.Agente
{
    public class AgentesProdutosDto
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public Guid AgenteId { get; set; }
        public Guid? ProdutoId { get; set; }
    }
}


