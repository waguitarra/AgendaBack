

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

public class TranslationService
{

    public async Task<string> TranslateTextAsync(string inputText, string targetLanguage = "pt")
    {
        try
        {
            using var httpClient = new HttpClient();

            // Determine a linguagem de origem com base na linguagem de destino
            string sourceLanguage = (targetLanguage == "pt") ? "es" : "pt";

            // Construir a URL
            string baseUrl = "https://translate.google.com/m?hl=en&sl=" + sourceLanguage + "&tl=" + targetLanguage + "&ie=UTF-8&prev=_m&q=" + System.Net.WebUtility.UrlEncode(RemoverAspas(inputText));

            // Obter a página
            var response = await httpClient.GetStringAsync(baseUrl);

            // Tentativa de encontrar o conteúdo usando a técnica de manipulação de strings
            string startTag = "<div class=\"result-container\">";
            string endTag = "</div>";

            int startIndex = response.IndexOf(startTag) + startTag.Length;
            int endIndex = response.IndexOf(endTag, startIndex);

            if (startIndex > -1 && endIndex > -1)
            {
                string resultado = response.Substring(startIndex, endIndex - startIndex).Trim();
                return resultado;
            }
            else
            {
                return inputText;
            }
        }
        catch 
        {
            return inputText;
        }

    }

    private string RemoverAspas(string input)
    {
        if (input.Contains("\""))
        {
            return input.Replace("\"", "-");
        }
        else
        {
            return input;
        }
    }


}
