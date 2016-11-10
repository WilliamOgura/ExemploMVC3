using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IProfessorRepository
    {
        void Cadastrar(Professor professor);
        void Atualizar(Professor professor);
        void Remover(int id);
        Professor BuscarPorId(int id);
        ICollection<Professor> Listar();
        ICollection<Professor> BuscarPor(Expression<Func<Professor, bool>> filtro);
    }
}
