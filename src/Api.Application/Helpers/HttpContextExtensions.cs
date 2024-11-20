using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Domain.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task InsertarParametrosPaginacaoEmResposta<T>(this HttpContext context, 
             IEnumerable<T> queryable, int quantidadeRegistroAmostrar)
        {
        
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double conte = queryable.Count();
            double totalPaginas = Math.Ceiling(conte / quantidadeRegistroAmostrar);
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
        }
    }
}
