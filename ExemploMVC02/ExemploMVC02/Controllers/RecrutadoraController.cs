using ExemploMVC02.Models;
using ExemploMVC02.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploMVC02.Controllers
{
    public class RecrutadoraController : Controller
    {
        // GET: Recrutadora
        [HttpGet]
        public ActionResult Index()
        {
            List<Recrutadora> recrutadoras = new RecrutadoraRepositorio().ObterTodos();
            ViewBag.Recrutadoras = recrutadoras;
            ViewBag.TitoloPagina = "Recrtadoras";
            return View();
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.TitoloPagina = "Recrtadoras-Cadastro";
            ViewBag.Recrutadora = new Recrutadora();
            return View();

        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.TitoloPagina = "Recrtadoras-Editar";
            Recrutadora recrutadora = new RecrutadoraRepositorio().ObterPeloId(id);
            ViewBag.Recrutadora = recrutadora;
            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            bool apagado = new RecrutadoraRepositorio().Excluir(id);
            return null;
        }

        [HttpPost]
        public ActionResult Store(Recrutadora recrutadora)
        {
            if (ModelState.IsValid)
            {
                recrutadora.CPF = recrutadora.CPF.Replace(".", "").Replace("-", "");
                int id = new RecrutadoraRepositorio().Cadastrar(recrutadora);
                return RedirectToAction("Editar", new { id = id });
            }
            ViewBag.recrutadora = recrutadora;
            return View("Cadastro");

        }

        [HttpPost]
        public ActionResult Update(Recrutadora recrutadora)
        {
            bool alterado = new RecrutadoraRepositorio().Alterar(recrutadora);

            return null;
        }

    }
}