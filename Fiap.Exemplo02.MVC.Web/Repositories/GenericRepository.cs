using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PortalContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(PortalContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Atualizar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).ToList();
        }

        public T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public ICollection<T> Listar()
        {
            if (_dbSet.ToString() == "Aluno")
            {
                return _dbSet.Include("Grupo").ToList();
            }

            return _dbSet.ToList();
        }

        public void Remover(int id)
        {
            var entity = BuscarPorId(id);
            _dbSet.Remove(entity);
        }
    }
}
