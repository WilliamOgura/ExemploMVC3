using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
     public class AlunoRepository : IAlunoRepository
    {
        private PortalContext _context;

        public AlunoRepository(PortalContext context)
        {
            this._context = context;
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<Aluno> BuscarPor(Expression<Func<Aluno, bool>> filtro)
        {
            return _context.Aluno.Where(filtro).ToList();
        }

        public Aluno BuscarPorId(int id)
        {
            return _context.Aluno.Find(id);
        }

        public void Cadastrar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
        }

        public ICollection<Aluno> Listar()
        {
            return _context.Aluno.Include("Grupo").ToList();
        }

        public void Remover(int id)
        {
            var aluno = BuscarPorId(id);
            _context.Aluno.Remove(aluno);
        }
    }
}
