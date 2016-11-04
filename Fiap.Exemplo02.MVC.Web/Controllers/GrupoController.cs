using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        private PortalContext _context = new PortalContext();
        // GET: Grupo
        public ActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastro(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
            _context.SaveChanges();
            TempData["msg"] = "Grupo Cadastrado";
            return RedirectToAction("Cadastro");
        }

        public ActionResult Listar()
        {
            var lista = _context.Grupo.ToList();
            return View(lista);
        }
    }
}