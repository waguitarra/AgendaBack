using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.Dtos.EnviarEmailDto;
using Domain.Interfaces.Services.SendEmail;
using Microsoft.Extensions.Configuration;
using NLog;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Util.Store;
using System.IO;


namespace Service.Services
{
    public class SendEmail : ISendEmail
    {
        public IConfiguration Configuration { get; }

        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();
        private GmailService _gmailService;
        private const string ApplicationName = "Google Email API Service";

        public SendEmail(IConfiguration configuration)
        {
            Configuration = configuration;  
        }
        private GmailService AuthenticateGmailService()
        {
            var clientId = Configuration["Google:ClientId"];
            var clientSecret = Configuration["Google:ClientSecret"];
            var userEmail = "wagner@macrosassessorias.com.br"; // Email fixo para autenticação

            var secrets = new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            // Caminho para salvar o token de autenticação
            var credPath = Path.Combine(AppContext.BaseDirectory, "token_wagner.json");

            // Autenticação com armazenamento do token
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                new[] { GmailService.Scope.GmailSend },
                userEmail, // Sempre usa este e-mail para autenticação
                System.Threading.CancellationToken.None,
                new FileDataStore(credPath, true) // Salva o token neste caminho
            ).Result;

            return new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Seu Aplicativo"
            });
        }





        public async Task<bool> SendEmailAsync(EmailRequestDto mailRequest)
        {
            try
            {
                // Autenticar o Gmail Service
                var gmailService = AuthenticateGmailService();

                // Substituições no corpo do e-mail
                string bodyResult = mailRequest.Body;
                bodyResult = bodyResult.Replace("#Nombre", mailRequest.Nome.ToUpper());
                bodyResult = bodyResult.Replace("#Rigador", mailRequest.CodigoUsuario);
                bodyResult = bodyResult.Replace("#TotalProdutos", mailRequest.HtmlExpansao);

                // Montar a mensagem no formato RAW
                var message = new Message
                {
                    Raw = Base64UrlEncode(
                        $"From: {Configuration.GetSection("EmailSettings:Mail").Value}\r\n" +
                        $"To: {mailRequest.ToEmail}\r\n" +
                        $"Subject: {mailRequest.Nome.ToUpper()}, {mailRequest.Subject}\r\n" +
                        $"Content-Type: text/html; charset=utf-8\r\n\r\n" +
                        bodyResult)
                };

                // Enviar o e-mail
                await gmailService.Users.Messages.Send(message, "me").ExecuteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro ao enviar email: {ex.Message}");
            }

            return false;
        }

        private static string Base64UrlEncode(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input))
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");
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
