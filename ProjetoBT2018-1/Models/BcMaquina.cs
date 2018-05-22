using ProjetoBT2018_1.Models.Dominios;
using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ProjetoBT2018_1.Models
{
    public class BcMaquina
    {
        ApiRepositorio api;
        
        public BcMaquina()
        {
            api = new ApiRepositorio();
        }

        public List<DominioMaquina> GetAllMachines(int idUsuario)
        {
            // valor da maquina esta setado!!
            var response = api.Get(string.Format("api/Maquinas/IdUsuario/{0}", 1));
            return response.Content.ReadAsAsync<List<DominioMaquina>>().Result;
        }

        public Maquina GetMachineContext(int idMaquina)
        {
            HttpResponseMessage[] responseHttp = {
                new ApiRepositorio().Get(string.Format("api/Maquinas/Id/{0}", idMaquina)),
                new ApiRepositorio().Get(string.Format("api/Processadors/Id/{0}",idMaquina)),
                new ApiRepositorio().Get(string.Format("api/Memorias/Id/{0}",idMaquina)),
                new ApiRepositorio().Get(string.Format("api/Discoes/Id/{0}",idMaquina)),
            };


            return new Maquina()
            {
                Dominio = responseHttp[0].Content.ReadAsAsync<DominioMaquina>().Result,
                Processador = responseHttp[1].Content.ReadAsAsync<Processador>().Result,
                Memoria = responseHttp[2].Content.ReadAsAsync<Memoria>().Result,
                Disco = responseHttp[3].Content.ReadAsAsync<FileStore>().Result
            };
        }

        // GET: Maquina
        public Maquina GetMachine(int idMaquina)
        {
            return new BcMaquina().GetMachineContext(idMaquina);
        }

        public double GetProcessor(int idMaquina)
        {
            var processador = new ApiRepositorio().Get(string.Format("api/Processadors/Id/{0}", idMaquina)).Content.ReadAsAsync<Processador>().Result;
            return double.Parse(string.Format("{0:0.00}", processador.Usage).Replace(',', '.'));
        }

        public string[,] GetMemoria(int idMaquina)
        {
            var memoria = new ApiRepositorio().Get(string.Format("api/Memorias/Id/{0}", idMaquina)).Content.ReadAsAsync<Memoria>().Result;
            double[] numbers = new double[]
            {
                memoria.Total - memoria.Available,
                memoria.SwapTotal - memoria.SwapAvailable
            };

            string[,] response = new string[2, 2];

            for (int indice = 0; indice < 2; indice++)
            {
                var bytes = numbers[indice];
                string[] suffix = { "B", "KB", "MB", "GB", "TB" };
                int i;
                double doubleBytes = 0;

                for (i = 0; (int)(bytes / 1024) > 0; i++, bytes /= 1024)
                {
                    doubleBytes = bytes / 1024.0;
                }

                response[indice, 0] = suffix[i];
                response[indice, 1] = string.Format("{0:0.00}", doubleBytes);
            }

            return response;
        }

        public Relatorio GetRelatorio(int idMaquina)
        {
            var processor = new ApiRepositorio().Get(string.Format("api/Processadors/{0}", idMaquina)).Content.ReadAsAsync<List<Processador>>().Result.Take(5);
            var memoria = new ApiRepositorio().Get(string.Format("api/Memorias/{0}", idMaquina)).Content.ReadAsAsync<List<Memoria>>().Result.Take(5);
            var disco = new ApiRepositorio().Get(string.Format("api/Discoes/{0}", idMaquina)).Content.ReadAsAsync<List<FileStore>>().Result.Take(5);

            return new Relatorio()
            {
                NomeMaquina = "teste",
                Processador = from item in processor select item.Usage,
                Disco = from item in disco select item.Total - item.Available,
                MemoriaRam = from item in memoria select item.Total - item.Available,
                MemoriaSwap = from item in memoria select item.SwapTotal - item.SwapAvailable,
                Momento = from item in processor select item.Momentum
            };
        }
    }
}
