using ProjetoBT2018_1.Models;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBT2018_1.Controllers
{
    public class HomeController : Controller
    {
        private BcUsuario bcUsuario = BcUsuarioADO.BcUsuarioConstrutor(); 
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
            Usuario usuarioTemp = bcUsuario.SelectId(usuario.Email);

            if (usuarioTemp.Id != 0)
            {
                if (usuario.Senha == usuarioTemp.Senha)
                {
                    usuario = usuarioTemp;
                    cookie = new HttpCookie("Login");
                    cookie.Expires = DateTime.Now.AddHours(0.30);
                    cookie.Values.Set("User", usuario.Email);
                    Response.SetCookie(cookie);

                    return RedirectToAction("Index", "Usuario");
                }
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
            if (ModelState.IsValid)
            {
                if (bcUsuario.SelectId(usuario.Email).Id == 0)
                {
                    if (usuario.Senha == usuario.ConfSenha)
                    {
                        bcUsuario.save(usuario);
                        return View("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("ConfSenha", "Senhas divergentes!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário já cadastrado!");
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
        //    return new BcSistema().ValidaUser(email, senha) ? "1" : "0";
        //}
    }
}