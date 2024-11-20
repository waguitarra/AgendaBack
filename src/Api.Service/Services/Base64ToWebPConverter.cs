using System;
using System.Diagnostics;
using System.IO;
using NLog;

namespace Service.Services
{
    public class Base64ToWebPConverter
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public static string ConvertBase64ToWebP(string base64String)
        {
            try
            {
             
                string webRootPath;

                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {
                    // Caso Windows
                    webRootPath = @"D:\";
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
                {
                    // Caso Linux
                    webRootPath = "/var/";
                }
                else
                {
                    _logger.Error($"Sistema operacional não suportado");
                    throw new NotSupportedException("Sistema operacional não suportado");
                }

                string folderName = "imagens"; // Nome da pasta para armazenar as imagens
                string fileName = "trocadesemente.com.br_" + Guid.NewGuid().ToString() + ".jpeg"; // Gera um nome de arquivo aleatório e adiciona a extensão ".jpeg"

                string imagePath = Path.Combine(webRootPath, folderName, fileName);

                // Converte a imagem em Base64 para um array de bytes
                byte[] imageBytes = Convert.FromBase64String(base64String);

                // Grava os bytes da imagem no arquivo
                File.WriteAllBytes(imagePath, imageBytes);

                // Obtém o endereço completo da imagem
                string imageUrl = Path.Combine("https://trocadesemente.com.br", folderName, fileName);

                // Verifica se o imageUrl contém a extensão .jpeg
                if (imageUrl.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    // Modifica a extensão da URL para .webp
                    imageUrl = imageUrl.Replace(".jpeg", ".webp", StringComparison.OrdinalIgnoreCase);
                }

                // Executa o arquivo Python antes de retornar
                var scriptPath = $"/{webRootPath}/imagens/imagensReduz.py";

                _logger.Debug($"scriptPath:{scriptPath}");

                // create a process to execute the shell command
                try
                {
                    var process = new Process();
                    process.StartInfo.FileName = "/bin/bash";
                    process.StartInfo.Arguments = $"-c \"python3 {scriptPath}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                }
                catch (Exception ex)
                {
                    _logger.Error($"Erro python :{ex}");
                }


                return imageUrl;

            }
            catch (Exception e)
            {
                _logger.Error($"Erro: upload das imagens {e}");
            }
            return null;
            
        }
    }
}
