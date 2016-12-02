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
    [EnableCors(origins:"*",headers:"*",methods:"*")]
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

        public IHttpActionResult Post(Aluno aluno)
        {
            if (ModelState.IsValid) {
                _unit.AlunoRepository.Cadastrar(aluno);
                _unit.Salvar();
                var uri = Url.Link("DefaultApi", new { id = aluno.Id });
                return Created<Aluno>(new Uri(uri), aluno);
            }
            else { }
            // manda o aluno para a view
            return BadRequest(ModelState);
        }
        public IHttpActionResult put(int id,Aluno aluno)
        {
            if(ModelState.IsValid)
            {
                aluno.Id = id;
                _unit.AlunoRepository.Atualizar(aluno);
                _unit.Salvar();
                return Ok(aluno);
            }else
            {
                return BadRequest(ModelState);
            }
        }
        public void Delete(int id)
        {
            _unit.AlunoRepository.Remover(id);
            _unit.Salvar();
        }
    }
}
