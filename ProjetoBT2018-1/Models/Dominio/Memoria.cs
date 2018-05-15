using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBT2018_1.Models.Dominio
{
    public class Memoria
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public double Available { get; set; }
        public double SwapTotal { get; set; }
        public double SwapAvailable { get; set; }
        public DateTime Momentum { get; set; }
        public int IdMaquina { get; set; }
    }
}