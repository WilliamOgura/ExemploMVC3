using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.ViewModels;
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

        #region GET
        [HttpGet]
        public ActionResult Cadastro()
        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos()
            };
            
            return View(viewModel);
        }

        private SelectList ListarGrupos()
        {
            var lista = _unit.GrupoRepository.Listar();
            return new SelectList(lista, "Id", "Nome");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //Include -> Busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            var lista = _unit.AlunoRepository.Listar();
            CarregarComboGrupo();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var lista = _unit.GrupoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");
            //Buscar o objeto (aluno no banco
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            // manda o aluno para a view
            return View(aluno);
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? idGrupo)
        {
            ICollection<Aluno> lista;
            if (idGrupo == null)
            {
                //Busca O aluno no banco por parte do nome
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca)).ToList();
            }
            else
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && a.GrupoId == idGrupo);
            }
            CarregarComboGrupo();

            //retorna para a view Listar com a lista
            return View("Listar", lista);
        }

        #endregion


        #region POST
        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {

            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno Cadastrado";
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Excluir(int AlunoId)
        {
            _unit.AlunoRepository.Remover(AlunoId);
            TempData["msg"] = "Aluno excluido";
            _unit.Salvar();
            return RedirectToAction("Listar");
        }

        #endregion

        #region DISPOSE
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region FUNCTION
        private void CarregarComboGrupo()
        {
            //envia para a tela os grupos para o select
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        #endregion







    }
}