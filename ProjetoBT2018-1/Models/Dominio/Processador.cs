using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBT2018_1.Models.Dominio
{
    public class Processador
    {
        public int Id { get; set; }
        public int IdMaquina { get; set; }
        public DateTime Momentum { get; set; }
        public double Usage { get; set; }
    }
}