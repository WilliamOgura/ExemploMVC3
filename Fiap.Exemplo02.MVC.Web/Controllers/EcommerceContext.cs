﻿using Fiap.Exemplo02.Dominio.Models;
using System.Data.Entity;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class EcommerceContext : PortalContext
    {
        public DbSet<Aluno> Alunos { get; set; }
    }
}
