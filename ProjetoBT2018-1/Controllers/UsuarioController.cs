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
        private BcUsuario bcUsuario = UsuarioADO.BcUsuarioConstrutor();
        private HttpCookie cookie;

        // GET: Usuario
        public ActionResult Index()
        {
            cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                Usuario usuario = bcUsuario.SelectId(cookie.Values["User"]);
                return View(new BcMaquina().GetAllMachines(usuario.Id));
            }

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Maquina(int idMaquina)
        {
            cookie = Request.Cookies["Login"];
            cookie.Values.Set("Maquina", idMaquina.ToString());
            Response.Cookies.Set(cookie);

            return View(new BcMaquina().GetMachine(idMaquina));
        }
    }
}