using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Professor
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Professor professor)
        {
            _unit.ProfessorRepository.Cadastrar(professor);
            _unit.Salvar();
            TempData["msg"] = "Professor Cadastrado";
            return RedirectToAction("Cadastro");
        }
        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.ProfessorRepository.Listar();
            return View(lista);
        }
    }
}