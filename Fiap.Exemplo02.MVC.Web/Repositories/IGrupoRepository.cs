﻿using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IGrupoRepository
    {
        ICollection<Grupo> Listar();
        void Cadastrar(Grupo grupo);
        void Atualizar(Grupo grupo);
        void Remover(int id);
        Grupo BuscarPorId(int id);
    }
}
