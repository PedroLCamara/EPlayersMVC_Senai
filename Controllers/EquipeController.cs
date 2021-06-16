using System;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersMVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe EquipeModel = new Equipe();

        [Route("Index")]
        public IActionResult Index() {
            ViewBag.Equipes = EquipeModel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection Form){
            Equipe NovaEquipe = new Equipe();
            NovaEquipe.IDEquipe = Int32.Parse(Form["IdEquipe"]);
            NovaEquipe.Nome = Form["Nome"];
            NovaEquipe.Imagem = Form["Imagem"];
            EquipeModel.Criar(NovaEquipe);
            ViewBag.Equipes = EquipeModel.LerTodas();

            return LocalRedirect("~/Equipe/Index");
        }
    }
}