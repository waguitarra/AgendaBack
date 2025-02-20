﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.ConteudoCategoria
{
    public class ConteudoCategoriaDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }      
        public string Descricao { get; set; }
        public string UrlImagens { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
