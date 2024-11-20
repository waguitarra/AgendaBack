using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Paginations
{
    public class PaginationsDomain
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; }
    }
}
