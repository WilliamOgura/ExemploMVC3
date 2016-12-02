using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.Repositories
{
    interface IGenericRepository<AlunoDTO>
    {
        void Cadastrar(AlunoDTO entidade);
        void Atualizar(AlunoDTO entidade);
        void Remover(int id);
        ICollection<AlunoDTO> Listar();
    }
}
