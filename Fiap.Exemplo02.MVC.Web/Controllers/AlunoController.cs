﻿using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        // private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.grupos = new SelectList(_unit.AlunoRepository.Listar(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {

            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno Cadastrado";
            return RedirectToAction("Cadastro");
        }

        public ActionResult Listar()
        {
            //Include -> Busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            var lista = _context.Aluno.Include("Grupo").ToList();

            _unit.AlunoRepository.Listar();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {   //Buscar o objeto (aluno no banco
            var aluno = _context.Aluno.Find(id);
            // manda o aluno para a view
            return View(aluno);
        }
        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Excluir(int AlunoId)
        {
            var aluno = _context.Aluno.Find(AlunoId);
            _context.Aluno.Remove(aluno);
            _context.SaveChanges();
            TempData["msg"] = "Aluno excluido";
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            //Busca O aluno no banco por parte do nome
            var lista = _context.Aluno.Where(a => a.Nome.Contains(nomeBusca)).ToList();
            //retorna para a view Listar com a lista
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {   
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}