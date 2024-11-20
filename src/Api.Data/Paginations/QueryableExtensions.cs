using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Paginations;

namespace Data.Paginations
{
    public static class QueryableExtensions
    {
        public  static IEnumerable<T> PaginarData<T>(this IEnumerable<T> queryable, PaginationsDomain paganacao) 
        {
            return queryable
                .Skip((paganacao.Pagina - 1) * paganacao.QuantidadePorPagina)
                .Take(paganacao.QuantidadePorPagina);
        } 
    }
       
}
