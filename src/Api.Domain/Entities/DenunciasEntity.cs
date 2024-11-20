using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Api.Domain.Entities
{
    public class DenunciasEntity : BaseEntity
    {
        public string TipoDenuncias { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<DenunciaProdutoUsuarioEntity> DenunciaProdutoUsuario { get; set; }

    }
}
