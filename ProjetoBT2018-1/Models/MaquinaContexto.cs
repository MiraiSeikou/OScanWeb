using Newtonsoft.Json;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Repositorios;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Helpers;

namespace ProjetoBT2018_1.Models
{
    public class MaquinaContexto
    {
        public Maquina Maquina { get; set; }
        public Processador Processador { get; set; }
        public Memoria Memoria  { get; set; }
        public FileStore Disco { get; set; }

        public MaquinaContexto()
        {
            Maquina = new Maquina();
            Processador = new Processador();
            Memoria = new Memoria();
            Disco = new FileStore();
        }

        public List<Maquina> GetAllMachines(int idUsuario)
        {
            var response = new ApiRepositorio().Get(string.Format("api/Maquinas/IdUsuario/{0}", 1));
            return response.Content.ReadAsAsync<List<Maquina>>().Result;
        }

        public MaquinaContexto GetMachineContext(int idMaquina)
        {
            HttpResponseMessage[] response = {
                new ApiRepositorio().Get(string.Format("api/Maquinas/Id/{0}", idMaquina)),
                new ApiRepositorio().Get(string.Format("api/Processadors/Id/{0}",idMaquina)),
                new ApiRepositorio().Get(string.Format("api/Memorias/Id/{0}",idMaquina)),
                new ApiRepositorio().Get(string.Format("api/Discoes/Id/{0}",idMaquina)),
            };


            return new MaquinaContexto()
            {
                Maquina = response[0].Content.ReadAsAsync<Maquina>().Result,
                Processador = response[1].Content.ReadAsAsync<Processador>().Result,
                Memoria = response[2].Content.ReadAsAsync<Memoria>().Result,
                Disco = response[3].Content.ReadAsAsync<FileStore>().Result
            };
        }
    }
}
