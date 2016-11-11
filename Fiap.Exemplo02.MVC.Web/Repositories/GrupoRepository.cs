using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class GrupoRepository: IGrupoRepository
    {
        private PortalContext _context;
        public GrupoRepository(PortalContext contenxt)
        {
            _context = contenxt;
        }

        public void Atualizar(Grupo grupo)
        {
            _context.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
        }

        public Grupo BuscarPorId(int id)
        {
            return _context.Grupo.Find(id);
        }

        public void Cadastrar(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
        }

        public ICollection<Grupo> Listar()
        {
            return _context.Grupo.ToList();
        }

        public void Remover(int id)
        {
            var grupo = BuscarPorId(id);
            _context.Grupo.Remove(grupo);
        }

       
    }
}
