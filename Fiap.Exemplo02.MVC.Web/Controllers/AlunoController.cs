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
        public ActionResult Cadastro(string msg)
        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Mensagem = msg
                
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
            var viewModel = new AlunoViewModel()
            {
                Alunos = _unit.AlunoRepository.Listar(),
                ListaGrupo = ListarGrupos()
                
            };
            CarregarComboGrupo();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //Buscar o objeto (aluno no banco
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Nome = aluno.Nome,
                Bolsa = aluno.Bolsa,
                Desconto = aluno.Desconto,
                Id = aluno.Id,
                DataNascimento = aluno.DataNascimento,
                GrupoId = aluno.GrupoId
             };
             // manda o aluno para a view
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? IdBusca)
        {
            ICollection<Aluno> lista;
           
                lista = _unit.AlunoRepository.BuscarPor(a => 
                a.Nome.Contains(nomeBusca) && (a.GrupoId == IdBusca ||   IdBusca == null));
            
            CarregarComboGrupo();
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Alunos = lista
            };
            //retorna para a view Listar com a lista
            return View("Listar", viewModel);
        }

        #endregion


        #region POST
        [HttpPost]
        public ActionResult Cadastro(AlunoViewModel alunoViewModel)
        {
            //automap
            if (ModelState.IsValid)
            {
                var aluno = new Aluno()
                {
                    Nome = alunoViewModel.Nome,
                    DataNascimento = alunoViewModel.DataNascimento,
                    Bolsa = alunoViewModel.Bolsa,
                    Desconto = alunoViewModel.Desconto,
                    GrupoId = alunoViewModel.GrupoId,
                    Id = alunoViewModel.Id,


                };
                _unit.AlunoRepository.Cadastrar(aluno);
                _unit.Salvar();
                return RedirectToAction("Cadastro", new { msg = "Aluno Cadastrado" });
            }
            else
            {
                alunoViewModel.ListaGrupo = ListarGrupos();
                return View(alunoViewModel);
            }
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();
            return RedirectToAction("Listar", new { msg = "Aluno Editado"});
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