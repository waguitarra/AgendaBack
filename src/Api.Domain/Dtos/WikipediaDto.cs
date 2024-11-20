using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class WikipediaDto
    {
        public string Titulo { get; set; }
        public string URL { get; set; }
        public string Conteudo { get; set; }
        public List<string> Imagens { get; set; }
    }
}

