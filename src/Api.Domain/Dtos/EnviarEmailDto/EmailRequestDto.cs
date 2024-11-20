using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Domain.Dtos.EnviarEmailDto
{
    public class EmailRequestDto
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Nome { get; set; }
        public string CodigoUsuario { get; set; }
        public string HtmlExpansao { get; set; }
    }
}
