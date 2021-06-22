using System;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EPlayersMVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador JogadorModel = new Jogador();

        [Route("Index")]
        public IActionResult Index(){
            ViewBag.Jogadores = JogadorModel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection Form){
            Jogador NovoJogador = new Jogador();
            NovoJogador.IDJogador = Int32.Parse(Form["IdJogador"]);
            NovoJogador.Nome = Form["Nome"];
            NovoJogador.IDEquipe = Int32.Parse(Form["IdEquipe"]);
            NovoJogador.Nome = Form["Email"];
            NovoJogador.Nome = Form["Senha"];
            JogadorModel.Criar(NovoJogador);
            ViewBag.Jogadores = JogadorModel.LerTodas();

            return LocalRedirect("~/Jogador/Index");
        }
    }
}