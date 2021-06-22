using System.Collections.Generic;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersMVC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        Jogador JogadorModel = new Jogador();

        [TempData]
        public string Mensagem { get; set; }

        [Route("Index")]
        public IActionResult Index(){
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection Form){
            List<string> JogadoresCSV = JogadorModel.LerTodasLinhasCSV("Database/jogador.csv");
            var Logado = JogadoresCSV.Find(
                x =>
                x.Split(";")[3] == Form["Email"] &&
                x.Split(";")[4] == Form["Senha"]
            );

            if (Logado != null)
            {
                HttpContext.Session.SetString("Username", Logado.Split(";")[1]);

                return LocalRedirect("~/");
            }
            else
            {
                Mensagem = "Dados incorretos, tente novamente...";
                return LocalRedirect("~/Login/Index");
            }
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("Username");
            return LocalRedirect("~/");
        }
    }
}