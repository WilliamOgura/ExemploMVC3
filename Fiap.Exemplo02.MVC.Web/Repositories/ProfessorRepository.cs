using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private PortalContext _context;

        public ProfessorRepository(PortalContext context)
        {
            _context = context;
        }

        public void Atualizar(Professor professor)
        {
            _context.Entry(professor).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<Professor> BuscarPor(Expression<Func<Professor, bool>> filtro)
        {
            return _context.Professor.Where(filtro).ToList();
        }

        public Professor BuscarPorId(int id)
        {
            return _context.Professor.Find(id);
        }

        public void Cadastrar(Professor professor)
        {
            _context.Professor.Add(professor);
        }

        public ICollection<Professor> Listar()
        {
            return _context.Professor.ToList();
        }

        public void Remover(int id)
        {
            var professor = BuscarPorId(id);
            _context.Professor.Remove(professor);
        }
    }
}