using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBT2018_1.Models.Dominio
{
    public class MaquinaContexto
    {
        private static Maquina maquina = new Maquina();
        private static Processador processador = new Processador();

        public static Maquina Maquina { get => maquina; set => maquina = value; }
        public static Processador Processador { get => processador; set => processador = value; }

        public MaquinaContexto GetMaquinaContexto(int id)
        {
            maquina = new ApiRepositorio().GetAllForId()
            }
    }
}
}