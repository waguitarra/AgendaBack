using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NLog;


namespace Service.Services
{
    public class ImgurPOSTImagen
    {
        public IConfiguration _configuration { get; }
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();
        public ImgurPOSTImagen(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<string> imgurUpload(string base64String)
        {
            return Base64ToWebPConverter.ConvertBase64ToWebP(base64String);
        }



        public string ImageToBase64(string url)
        {
            StringBuilder sb = new StringBuilder();

            Byte[] datos = this.GetImage(url);

            sb.Append(Convert.ToBase64String(datos, 0, datos.Length));

            return sb.ToString();
        }


        private byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
                _logge.Error($"Erro: {exp}");
            }

            return (buf);
        }
    }
}
