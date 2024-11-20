using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Domain.Dtos.EnviarEmailDto;
using Domain.Interfaces.Services.SendEmail;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using NLog;

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
            InitializeGmailService();
        }

        // Inicializa o GmailService com autenticação
        private void InitializeGmailService()
        {
            if (_gmailService == null)
            {
                var clientId = Configuration["Google:ClientId"];
                var clientSecret = Configuration["Google:ClientSecret"];
                var userEmail = "wagner@macrosassessorias.com.br"; // E-mail fixo para autenticação

                var secrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                };

                var credPath = Path.Combine(AppContext.BaseDirectory, "token_wagner.json");

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    secrets,
                    new[] { GmailService.Scope.GmailSend },
                    userEmail,
                    System.Threading.CancellationToken.None,
                    new FileDataStore(credPath, true)
                ).Result;

                _gmailService = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });
            }
        }

        // Método para envio genérico
        private async Task<bool> SendEmailRawAsync(string toEmail, string subject, string body)
        {
            try
            {
                var message = new Message
                {
                    Raw = Base64UrlEncode(
                        $"From: {Configuration["EmailSettings:Mail"]}\r\n" +
                        $"To: {toEmail}\r\n" +
                        $"Subject: {subject}\r\n" +
                        $"Content-Type: text/html; charset=utf-8\r\n\r\n" +
                        body)
                };

                await _gmailService.Users.Messages.Send(message, "me").ExecuteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro ao enviar email para {toEmail}: {ex.Message}");
                return false;
            }
        }

        // Envia e-mail principal com template original
        public async Task<bool> SendEmailAsync(EmailRequestDto mailRequest)
        {
            try
            {
                string bodyResult = mailRequest.Body;
                bodyResult = bodyResult.Replace("#Nombre", mailRequest.Nome.ToUpper());
                bodyResult = bodyResult.Replace("#Rigador", mailRequest.CodigoUsuario);
                bodyResult = bodyResult.Replace("#TotalProdutos", mailRequest.HtmlExpansao);

                string subject = $"{mailRequest.Nome.ToUpper()}, {mailRequest.Subject}";

                return await SendEmailRawAsync(mailRequest.ToEmail, subject, bodyResult);
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro ao enviar email: {ex.Message}");
                return false;
            }
        }

        // Envia relatório de novos usuários
        public async Task<bool> SendEmailReporte(string mailRequest)
        {
            try
            {
                string subject = "Usuarios novos";
                return await SendEmailRawAsync(
                    Configuration["emailsEmpresa:Mails"],
                    subject,
                    mailRequest
                );
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro ao enviar email de relatório: {ex.Message}");
                return false;
            }
        }

        // Envia logs de erro
        public async Task<bool> EmailErros(string emailReporte)
        {
            try
            {
                string subject = "Logs de Erros";
                return await SendEmailRawAsync(
                    Configuration["emailsEmpresa:Mails"],
                    subject,
                    emailReporte
                );
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro ao enviar logs de erros: {ex.Message}");
                return false;
            }
        }

        // Envia informações de usuários logados
        public async Task<bool> UserLogado(string emailReporte)
        {
            try
            {
                string subject = "Usuario logado";
                return await SendEmailRawAsync(
                    Configuration["emailsEmpresa:Mails"],
                    subject,
                    emailReporte
                );
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro ao enviar email de usuario logado: {ex.Message}");
                return false;
            }
        }

        // Codifica o e-mail para o formato base64 exigido pelo Gmail API
        private static string Base64UrlEncode(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input))
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");
        }
    }
}
