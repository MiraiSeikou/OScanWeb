using ProjetoBT2018_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjetoBT2018_1.Controllers
{
    public class MaquinaController : Controller
    {
        // GET: Processor
        public double GetProcessor(int idMaquina)
        {
            return new BcMaquina().GetProcessor(idMaquina);
        }

        public ActionResult Relatorio (int idMaquina)
        {
            return View(new BcMaquina().GetRelatorio(idMaquina));
        }

        public string[,] GetMemorias(int idMaquina)
        {
            return new BcMaquina().GetMemoria(idMaquina);
        }

    }
}