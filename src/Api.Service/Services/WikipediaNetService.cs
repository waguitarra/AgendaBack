using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Interfaces.Services;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System.Linq;


namespace Service.Services
{
    public class WikipediaNetService 
    {

        private readonly string _language;
        private readonly HttpClient _httpClient;
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();

        public WikipediaNetService(string language)
        {
            _language = language;
            _httpClient = new HttpClient { BaseAddress = new Uri($"https://{language}.wikipedia.org/w/") };
        }



        public async Task<WikipediaDto> Gettexto(string texto, string pais)
        {

            _logge.Info($"texto: {texto}");
            var wikipedia = new WikipediaNetService(pais);
            var titulo = await BuscarArtigo(wikipedia, texto);
            var resultado = new WikipediaDto();

            if (titulo != null)
            {
                var pagina = await wikipedia.LoadPage(titulo);
                if (pagina != null)
                {
                    // Criar uma lista de URLs de imagens
                    List<string> imagensUrls = new List<string>();
                    if (pagina.Images != null)
                    {
                        using (var client = new HttpClient())
                        {
                            var response = await client.GetAsync($"https://pt.wikipedia.org/w/api.php?action=query&prop=imageinfo&format=json&titles={texto}&iiprop=url&generator=images&gimlimit=10");

                            response.EnsureSuccessStatusCode();

                            var responseBody = await response.Content.ReadAsStringAsync();

                            var parsedResponse = JObject.Parse(responseBody);

                            if (parsedResponse.ToString().Length < 50)
                            {
                                string searchTerm = $"{texto} vegetales, planta, árbol, cultivo, hojas -comida -producto -receta -vendas -personas -animal -animales -porco -granja -criadouro";
                                string url = $"https://www.bing.com/images/search?q={searchTerm}";

                                using (HttpClient client_ = new HttpClient())
                                {
                                    try
                                    {
                                        string htmlContent = await client_.GetStringAsync(url);
                                        var htmlDocument = new HtmlDocument();
                                        htmlDocument.LoadHtml(htmlContent);

                                        // Ajuste en la consulta XPath
                                        var imageNodes = htmlDocument.DocumentNode.SelectNodes("//div[not(contains(@class,'adDivClass'))]//img[@class='mimg']");

                                        if (imageNodes != null)
                                        {
                                            int count = 0;
                                            foreach (var img in imageNodes)
                                            {
                                                if (count >= 20) break;

                                                string imgUrl = img.GetAttributeValue("src", string.Empty);
                                                if (!string.IsNullOrEmpty(imgUrl))
                                                {
                                                    imagensUrls.Add(imgUrl);
                                                    count++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No se encontraron imágenes.");
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine($"Error: {e.Message}");
                                    }
                                }

                                if (imagensUrls.Count() > 0)
                                    return resultado = new WikipediaDto()
                                    {
                                        Titulo = texto,
                                        URL = "",
                                        Conteudo = "",
                                        Imagens = imagensUrls
                                    };
                                else
                                    return null;

                            }


                            var pages = parsedResponse["query"]["pages"];

                            var urls = new List<string>();

                            foreach (var page in pages)
                            {
                                if (page.First["imageinfo"] != null)
                                {
                                    foreach (var imageInfo in page.First["imageinfo"])
                                    {
                                        if (imageInfo["url"].ToString() != null
                                         && imageInfo["url"].ToString() != null
                                         && !imageInfo["url"].ToString().Contains("Information")
                                         && !imageInfo["url"].ToString().Contains("Wikispecies")
                                         && !imageInfo["url"].ToString().Contains("Disambig")
                                         && !imageInfo["url"].ToString().Contains("Question")
                                         && !imageInfo["url"].ToString().Contains("Flag_of")
                                         && !imageInfo["url"].ToString().Contains("icon")
                                         && !imageInfo["url"].ToString().Contains("logo")
                                         && !imageInfo["url"].ToString().Contains("regions")


                                         )
                                            urls.Add(imageInfo["url"].ToString());
                                    }
                                }
                            }

                            imagensUrls = urls;
                        }
                    }


                    var body = pagina.Content.Split("\n");

                    string bodytexto = "";

                    foreach (var item in body)
                    {
                        if (!item.Contains("\t"))
                            if (item.Contains("=="))
                            {
                                bodytexto = bodytexto + "<h3>" + item + "</h3>"; //==
                            }
                            else if (item.Contains("==="))
                            {

                                bodytexto = bodytexto + "<h4>" + item + "</h4>"; //===
                            }
                            else if (item.Contains(":"))
                            {
                                if (item.Contains(":)") || item.Length > 10)
                                {
                                    bodytexto = bodytexto + item;
                                }
                                else
                                    bodytexto = bodytexto + "<h4>" + item + "</h4>";
                            }
                            else
                                bodytexto = bodytexto + "<p>" + item + "</p>";
                    }

                    resultado = new WikipediaDto()
                    {
                        Titulo = "<h2>" + pagina.Title + "</h2>",
                        URL = "<a>" + pagina.FullUrl + "</a>",
                        Conteudo = bodytexto,
                        Imagens = imagensUrls
                    };
                }
            }

            string json = JsonConvert.SerializeObject(resultado, Formatting.Indented);
   

            return resultado;
        }        

        static async Task<string> BuscarArtigo(WikipediaNetService wikipedia, string query)
        {
            var resultados = await wikipedia.Search(query);

            if (resultados.Count > 0)
            {
                return resultados[0].Title;
            }

            return null;
        }




        public async Task<List<WikipediaSearchResult>> Search(string query)
        {
            _logge.Info($"query: {query}");
            var response = await _httpClient.GetAsync($"api.php?action=query&list=search&format=json&srsearch={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WikipediaSearchResponse>(responseContent);
            return result.Query.Search;
        }

        public async Task<WikipediaPage> LoadPage(string title)
        {
            _logge.Info($"title: {title}");
            var response = await _httpClient.GetAsync($"api.php?action=query&prop=info|extracts|images&format=json&exlimit=max&explaintext=&inprop=url&iiprop=url&iilimit=max&iilang={_language}&titles={Uri.EscapeDataString(title)}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WikipediaPageResponse>(responseContent);
            var page = result.Query.Pages.Values.GetEnumerator();
            if (page.MoveNext())
            {
                return page.Current;
            }

            return null;
        }

       


    }


    public class WikipediaSearchResponse
    {
        [JsonProperty("query")]
        public WikipediaSearchQuery Query { get; set; }
    }

    public class WikipediaSearchQuery
    {
        [JsonProperty("search")]
        public List<WikipediaSearchResult> Search { get; set; }
    }

    public class WikipediaSearchResult
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class WikipediaPageResponse
    {
        [JsonProperty("query")]
        public WikipediaPageQuery Query { get; set; }
    }

    public class WikipediaPageQuery
    {
        [JsonProperty("pages")]
        public Dictionary<string, WikipediaPage> Pages { get; set; }
    }

    public class WikipediaPage
    {
        [JsonProperty("pageid")]
        public int PageId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("extract")]
        public string Content { get; set; }

        [JsonProperty("fullurl")]
        public string FullUrl { get; set; }

        [JsonProperty("images")]
        public List<WikipediaImage> Images { get; set; }
    }

    public class WikipediaImage
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        public string SourceUrl { get; set; }
    }

}
