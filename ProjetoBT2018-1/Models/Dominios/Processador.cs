using System;

namespace ProjetoBT2018_1.Models.Dominios
{
    public class Processador
    {
        public int Id { get; set; }
        public int IdMaquina { get; set; }
        public DateTime Momentum { get; set; }
        public double Usage { get; set; }
    }
}