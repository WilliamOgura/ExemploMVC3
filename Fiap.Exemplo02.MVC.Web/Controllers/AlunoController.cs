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
    }
}