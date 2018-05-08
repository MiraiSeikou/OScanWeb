using ProjetoBT2018_1.Models.Dominio;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjetoBT2018_1.Models.Repositorios
{
    public class ApiRepositorio
    {
        HttpClient client;

        public List<Maquina> GetAllForIdAsync(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                List<Maquina> maquinas = new List<Maquina>();

                client.BaseAddress = new System.Uri("http://oscanwebapi.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(string.Format("api/Maquinas/{0}",1)).Result;
                if (response.IsSuccessStatusCode)
                {
                    maquinas = response.Content.ReadAsAsync<List<Maquina>>().Result;
                }

                return maquinas;
            }
        }

        //public async Task<Processador> GetProcessador(int idMaquina)
        //{
        //    Processador processador = new Processador();

        //    client.BaseAddress = new System.Uri("http://");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await client.GetAsync("api/produtos/");

        //    if (response.IsSuccessStatusCode)
        //}
    }
}