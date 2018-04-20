using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBT2018_1.Models.Dominio;

namespace ProjetoBT2018_1.Controllers
{
    public class UsuarioController : Controller
    {
        HttpCookie cookie;

        // GET: Usuario
        public ActionResult Index()
        {
            cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
        }
    }
}