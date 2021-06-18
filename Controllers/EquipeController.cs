using System;
using System.IO;
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
            // NovaEquipe.Imagem = Form["Imagem"];
            if (Form.Files.Count > 0)
            {
                var Arquivo = Form.Files[0];
                var Pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Equipes");
                if (!Directory.Exists(Pasta))
                {
                    Directory.CreateDirectory(Pasta);
                }
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Equipes", Arquivo.FileName);
                using (var Stream = new FileStream(caminho, FileMode.Create))
                {
                    Arquivo.CopyTo(Stream);
                }
                NovaEquipe.Imagem = Arquivo.FileName;
            }
            else
            {
                NovaEquipe.Imagem = "padrao.png";
            }
            EquipeModel.Criar(NovaEquipe);
            ViewBag.Equipes = EquipeModel.LerTodas();

            return LocalRedirect("~/Equipe/Index");
        }
    }
}