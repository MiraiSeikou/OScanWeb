using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProjetoBT2018_1.Models.Dominio
{
    public class Maquina
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string MacAddr { get; set; }
        public string Nome { get; set; }
        public string OSName { get; set; }
        
        
        //public IEnumerable<Maquina> allMaquinas()
        //{
        //    var retorno = new Collection<Maquina>
        //    {
        //        new Maquina
        //        {
        //            Id = 1,
        //            NomePC = "PC 1",
        //            NomeSistemaPC = "Windows XP",
        //            Id = 2,
        //            processador = 
        //            {
        //                QtdNucleos = 4,
        //                MarcaProcessador = "Intel(R)",
        //                LinhaProcessador = "Core(TM)",
        //                ModeloProcessador = "i7-3632QM",
        //                ClockProcessador = "CPU @ 2.20GHz",
        //                VelocidadeBaseProcessador = "2,20 GHz",
        //                SocketsProcessador = 1,
        //                QtdNucleosFisicos = 2
        //            }
        //        },

        //        new Maquina
        //        {
        //            Id = 2,
        //            NomePC = "PC 2",
        //            NomeSistemaPC = "Windows 10",
        //            IdDominio = 2,
        //            processador =
        //            {
        //                QtdNucleos = 8,
        //                MarcaProcessador = "Intel(R)",
        //                LinhaProcessador = "Core(TM)",
        //                ModeloProcessador = "i7-3632QM",
        //                ClockProcessador = "CPU @ 2.20GHz",
        //                VelocidadeBaseProcessador = "2,20 GHz",
        //                SocketsProcessador = 1,
        //                QtdNucleosFisicos = 4
        //            }
        //        },

        //        new Maquina
        //        {
        //            Id = 3,
        //            NomePC = "PC 3",
        //            NomeSistemaPC = "Linux Ubuntu",
        //            IdDominio = 7,
        //            processador =
        //            {
        //                 QtdNucleos = 6,
        //                MarcaProcessador = "Intel(R)",
        //                LinhaProcessador = "Core(TM)",
        //                ModeloProcessador = "i7-3632QM",
        //                ClockProcessador = "CPU @ 2.20GHz",
        //                VelocidadeBaseProcessador = "2,20 GHz",
        //                SocketsProcessador = 1,
        //                QtdNucleosFisicos = 3
        //            }
        //        }
        //    };
        //    return retorno;
        //}
    }
}