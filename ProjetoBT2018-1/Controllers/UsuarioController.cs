using Newtonsoft.Json;
using ProjetoBT2018_1.Models;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBT2018_1.Controllers
{
    public class UsuarioController : Controller
    {
        private BcUsuario bcUsuario = BcUsuarioADO.BcUsuarioConstrutor();
        private HttpCookie cookie;

        // GET: Usuario
        public ActionResult Index()
        {
            cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                Usuario usuario = bcUsuario.SelectId(cookie.Values["User"]);

                var maquinas = new ApiRepositorio().GetAllForIdAsync(usuario.Id);
                return View(maquinas);
            }

            return RedirectToAction("Login", "Home");
        }

        //public ActionResult Maquina(int idMaquina)
        //{
        //    //cookie = Request.Cookies["Login"];
        //    //cookie.Values.Set("Maquina", idMaquina.ToString());
        //    //Response.Cookies.Set(cookie);
        //    ////return View(new Maquina().allMaquinas().FirstOrDefault(item => item.Id == idMaquina));
        //}

        //public string Valores()
        //{
        //    //cookie = Request.Cookies["Login"];
        //    //List<int> retorno = new List<int>();
        //    ////Maquina maquina = new Maquina().allMaquinas().FirstOrDefault(item => item.Id == int.Parse(cookie.Values["Maquina"]));
        //    //Random rnd = new Random();

        //    //for (int i = 0; i < maquina.processador.QtdNucleos; i++)
        //    //{
        //    //    retorno.Add(rnd.Next(0, 101));
        //    //}

        //    //return JsonConvert.SerializeObject(retorno);
        //}
    }
}