using System.Text;
using System.Threading;
using AutoMapper.Configuration;
using MySql.Data.MySqlClient;
using NLog;
using NLog.LayoutRenderers;
using Microsoft.Extensions.Configuration;
using IConfiguration = AutoMapper.Configuration.IConfiguration;
using Config = Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace Service.Services
{
    [LayoutRenderer("LogsSistema")]
    public class LogSistema : LayoutRenderer 
    {
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            try
            {
                // Acessa os valores dos parâmetros da mensagem de log
                //string timestamp = logEvent.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss");
                //string level = logEvent.Level.ToString();
                //string callsite = logEvent.LoggerName;
                //string parameterName = logEvent.CallerMemberName;
                //string message = logEvent.Message;

                //// Imprime os valores dos parâmetros
                //Console.WriteLine($"Argumentos recebidos: {timestamp}, {level}, {callsite}, {parameterName}, {message}");

                //// Chama o método que deseja executar, passando os parâmetros
                //var scriptPath = "//var/www/estudo_cshatp_ddd_1/src/LogSistema.py";
                //var arguments = $"{timestamp} {level} {callsite} {parameterName} {message}";

                // create a process to execute the shell command
                //var process = new Process();
                //process.StartInfo.FileName = "/bin/bash";
                //process.StartInfo.Arguments = $"-c \"python3 {scriptPath} {arguments}\"";
                //process.StartInfo.UseShellExecute = false;
                //process.StartInfo.RedirectStandardOutput = true;
                //process.Start();


                 //scriptPath = "//var/imagens/imagensReduz.py";

                // create a process to execute the shell command      
                //process = new Process();
                //process.StartInfo.FileName = "/bin/bash";
                //process.StartInfo.Arguments = $"-c \"python3 {scriptPath}\"";
                //process.StartInfo.UseShellExecute = false;
                //process.StartInfo.RedirectStandardOutput = true;
                //process.Start();
                
        

                // read the output of the script
                //var output = process.StandardOutput.ReadToEnd();

                //// wait for the process to exit
                //process.WaitForExit();

                //// display the output of the script
                //Console.WriteLine(output);

                //// adiciona a mensagem de log ao StringBuilder
                //builder.Append(logEvent.FormattedMessage);
            }
            catch 
            {
                //throw new Exception($"Ocorreu um erro ao processar a mensagem de log. {ex}");

            }

        }
    }
}
