﻿using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        private PortalContext _context = new PortalContext();
        // GET: Aluno
        public ActionResult Cadastro()
        {
            var lista = _context.Grupo.ToList();
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
            TempData["msg"] = "Aluno Cadastrado";
            return RedirectToAction("Cadastro");
        }

        public ActionResult Listar()
        {
            var lista = _context.Aluno.ToList();
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
    }
}