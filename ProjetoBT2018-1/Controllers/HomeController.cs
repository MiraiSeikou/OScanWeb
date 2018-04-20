using System.Web.Mvc;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models;
using System.Threading;
using System.Web;
using System;

namespace ProjetoBT2018_1.Controllers
{
    public class HomeController : Controller
    {
        HttpCookie cookie;

        // Aqui eu criei uma action que redireciona o usuario para tela de login.
        // Essa Action esta configurada como rota default caso o usuario não especifique o caminho na url.
        public ActionResult Login()
        {
            if (Request.Cookies["Login"] != null)
            {
                return RedirectToAction("Index", "Usuario");
            }

            Usuario usuario = new Usuario();
            return View(usuario);
        }

        // Aqui eu crei uma action que ira receber os valores digitados pelo usuario no Form de login 
        // Essa action ira realizar a autenticação do usuario conforme nossa base de dados
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (new BcSistema().ValidaUser(usuario.Email, usuario.Senha))
            {
                cookie = new HttpCookie("Login", "User");
                cookie.Expires = DateTime.Now.AddHours(0.30);
                Response.SetCookie(cookie);

                return RedirectToAction("Index", "Usuario");
            }

            ModelState.AddModelError("", "E-mail e/ou senha invalida!");

            return View();
        }

        public ActionResult Cadastrar()
        {
            if(Request.Cookies["Login"] != null)
            {
                return RedirectToAction("Index", "Usuario");
            }

            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            BcSistema bcSistema = new BcSistema();

            if (ModelState.IsValid)
            {
                if (usuario.Senha == usuario.ConfSenha)
                {
                    if (!bcSistema.ValidaUser(usuario.Email))
                    {
                        new BcUsuario().Create(usuario);
                        return View("Login");
                    }

                    ModelState.AddModelError("", "Usuário já cadastrado!");
                }
                else
                {
                    ModelState.AddModelError("ConfSenha", "Senhas divergentes!");
                }
            }

            return View(usuario);
        }

        public ActionResult Logout()
        {
            cookie = Request.Cookies["Login"];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddHours(-0.30);
                Response.SetCookie(cookie);
            }

            return View("Login");
        }

        //public string ValidateUser(string email, string senha)
        //{
        //    if (new BcSistema().ValidaUser(email,senha))
        //    {
        //        return "1";
        //    }

        //    return "0";
        //}
        
    }
}