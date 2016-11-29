using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.MVC.Persistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fiap.Exemplo02.Service.Controllers
{
    public class AlunoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        //GET api/aluno
        public ICollection<Aluno> Get()
        {
            return _unit.AlunoRepository.Listar();
        }

        //Get api/aluno/{id}
        public Aluno Get(int id)
        {
            return _unit.AlunoRepository.BuscarPorId(id);
        }

        public IHttpActionResult Cadastro(Aluno aluno)
        {
            if (ModelState.IsValid) {
                _unit.AlunoRepository.Cadastrar(aluno);
                _unit.Salvar();
                var uri = Url.Link("http://localhost:51102/api/aluno", new { id = aluno.Id });
                return Created<Aluno>(new Uri(uri), aluno);
            }
            else { }
            // manda o aluno para a view
            return BadRequest(ModelState);
        }
    }
}
