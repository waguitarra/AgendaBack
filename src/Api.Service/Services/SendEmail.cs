using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.Dtos.EnviarEmailDto;
using Domain.Interfaces.Services.SendEmail;
using Microsoft.Extensions.Configuration;
using NLog;

namespace Service.Services
{
    public class SendEmail : ISendEmail
    {
        public IConfiguration Configuration { get; }

        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();

        public SendEmail(IConfiguration configuration)
        {
            Configuration = configuration;  
        }


        public async Task<bool> SendEmailAsync(EmailRequestDto mailRequest)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:DisplayName").Value);
                message.To.Add(new MailAddress(mailRequest.ToEmail));
                message.Subject = mailRequest.Nome.ToUpper() + ", " + mailRequest.Subject;
                string BodyResult = mailRequest.Body;
                BodyResult = BodyResult.Replace("#Nombre", mailRequest.Nome.ToUpper());
                BodyResult = BodyResult.Replace("#Rigador", mailRequest.CodigoUsuario);
                BodyResult = BodyResult.Replace("#TotalProdutos", mailRequest.HtmlExpansao);
                message.IsBodyHtml = true;
                message.Body = BodyResult;          
                smtp.Port = Convert.ToInt32(Configuration.GetSection("EmailSettings:Port").Value);
                smtp.Host = Configuration.GetSection("EmailSettings:Host").Value;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:Password").Value);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro: {ex}");
            }

            return false;

        }

        public async Task<bool> SendEmailReporte(string mailRequest)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
   
                message.From = new MailAddress(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:DisplayName").Value);
                message.To.Add(new MailAddress(Configuration.GetSection("emailsEmpresa:Mails").Value));
                message.Subject = "Usuarios novos ";

                string BodyResult = mailRequest;

                message.IsBodyHtml = true;
                message.Body = BodyResult;
                smtp.Port = Convert.ToInt32(Configuration.GetSection("EmailSettings:Port").Value);
                smtp.Host = Configuration.GetSection("EmailSettings:Host").Value;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:Password").Value);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                _ = EmailErros(ex.Message);
                _logge.Error($"Erro: {ex}");
                return false;
            }

        }


        public async Task<bool> EmailErros(string EmailReporte)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:DisplayName").Value);
            message.To.Add(new MailAddress(Configuration.GetSection("emailsEmpresa:Mails").Value));
            message.Subject = "Logs de Erros ";

            string BodyResult = EmailReporte;

            message.IsBodyHtml = true;
            message.Body = BodyResult;
            smtp.Port = Convert.ToInt32(Configuration.GetSection("EmailSettings:Port").Value);
            smtp.Host = Configuration.GetSection("EmailSettings:Host").Value;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:Password").Value);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
            return true;
        }


        public async Task<bool> UserLogado(string EmailReporte)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:DisplayName").Value);
                message.To.Add(new MailAddress(Configuration.GetSection("emailsEmpresa:Mails").Value));
                message.Subject = "Usuario logado ";

                string BodyResult = EmailReporte;

                message.IsBodyHtml = true;
                message.Body = BodyResult;
                smtp.Port = Convert.ToInt32(Configuration.GetSection("EmailSettings:Port").Value);
                smtp.Host = Configuration.GetSection("EmailSettings:Host").Value;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Configuration.GetSection("EmailSettings:Mail").Value, Configuration.GetSection("EmailSettings:Password").Value);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro: {ex}");
                return false;
            }

        }
    }
}
