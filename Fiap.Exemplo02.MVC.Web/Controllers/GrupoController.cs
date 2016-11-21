using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        UnitOfWork _unit = new UnitOfWork();
        // GET: Grupo
        public ActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastro(Grupo grupo)
        {
            _unit.GrupoRepository.Cadastrar(grupo);
            _unit.Salvar();
            TempData["msg"] = "Grupo Cadastrado";
            return RedirectToAction("Cadastro");
        }

        public ActionResult Listar()
        {
            var lista = _unit.GrupoRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var grupo = _unit.GrupoRepository.BuscarPorId(id);
            return View(grupo);
        }
        [HttpPost]
        public ActionResult Editar(Grupo grupo)
        {
            _unit.GrupoRepository.Atualizar(grupo);
            _unit.ProjetoRepository.Atualizar(grupo.Projeto);
            _unit.Salvar();
            TempData["msg"] = "Grupo atualizado";
            return RedirectToAction("Listar");
        }


    }
}