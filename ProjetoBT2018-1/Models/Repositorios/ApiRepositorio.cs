using ProjetoBT2018_1.Models.Dominio;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjetoBT2018_1.Models.Repositorios
{
    public class ApiRepositorio
    {
        HttpClient client;

        public ApiRepositorio()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("http://oscanwebapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Get(string endPoint)
        {
            using (client)
            {
                return client.GetAsync(endPoint).Result;
            }
        }
    }
}