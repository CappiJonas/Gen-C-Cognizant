using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;

namespace Request
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Variavel para guardar a string HTML
            string pagina;

            #region Metodo Antigo

            //Cria a request
            //A request deve ser recriada a cada requisição
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.google.com.br/search?q=cognizant+brasil");
            //"                                                       sxsrf=ALeKk01Fe-RHXKs_ELLAeiVKJ_4o65fwiQ%3A1586283312414" +
            //                                                        "&source=hp" +
            //                                                        "&ei=MMOMXu_9Fsa85OUP9oeRgAY" +
            //                                                        "&q=cognizant+brasil" +
            //                                                        "&oq=" +
            //                                                        "&gs_lcp=CgZwc3ktYWIQARgAMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnMgcIIxDqAhAnUABYAGD2E2gCcAB4AIABAIgBAJIBAJgBAKoBB2d3cy13aXqwAQo" +
            //                                                        "&sclient=psy-ab");

            //Define a codificação da request
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            //Define os dados utilizados pela request
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.Headers.Add("Accept-Encoding: gzip, deflate, br");
            request.Headers.Add("Accept-Language: pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,und;q=0.6");
            request.ContentType = "";
            request.Referer = "";

            //Define o método usado pela request
            request.Method = "GET";

            //Executa a request
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //Coleta a resposta da request
            using (Stream stream = response.GetResponseStream())
            //Lê o conteudo da resposta
            using (StreamReader reader = new StreamReader(stream))
            {
                //Atribui o conteudo à variavel
                pagina = reader.ReadToEnd();
            }

            #endregion Metodo Antigo

            #region Metodo Novo

            //Cria o handler do client, onde definimos configurações essenciais
            var clientHandler = new HttpClientHandler()
            {
                //Permite ou não o redirecionamento automatico
                AllowAutoRedirect = false,

                //Define os métodos de descompressão
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli,

                //Define os métodos de segurança
                SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12,

                //Define o uso de proxy
                UseProxy = false
            };

            //Inicia o client
            //O client deve ser iniciado uma única vez durante a execução da aplicação/automação
            var client = new HttpClient(clientHandler);

            //Define os Headers
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,und;q=0.6");

            //Faz uma requisição do tipo GET Assincrona
            var taskGet = client.GetAsync("https://www.google.com.br/search?q=cognizant+brasil");

            //Aguarda a requisição finalizar
            taskGet.Wait();

            //Pega o conteudo da requisição
            var getResponse = taskGet.Result.Content;

            //Inicia a leitura do conteudo
            var taskReader = getResponse.ReadAsStringAsync();

            //Aguarda a leitura
            taskReader.Wait();

            //Atribui à variavel o conteudo da leitura
            pagina = taskReader.Result;

            #endregion Metodo Novo

            //Cria um HtmlDocument do AgilityPack
            var documentoPagina = new HtmlDocument();

            //Carrega o conteúdo da request no HTML
            documentoPagina.LoadHtml(HttpUtility.HtmlDecode(pagina));

            //Nome da tag do elemento ou *
            var tagName = "*";

            //Nome da classe do elemento
            var classeElemento = "rc";

            //Pesquisa o um elemento que atende ao XPath
            var campoPesquisa = documentoPagina.DocumentNode.SelectSingleNode($"//{tagName}[@class='{classeElemento}']");

            //Coleta o texto do elemento anterior
            var primeiroResultado = campoPesquisa.SelectSingleNode(".//*[@class='st']").InnerText;
        }
    }
}