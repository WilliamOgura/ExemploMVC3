﻿using Fiap.Exemplo02.Dominio.Models;
using Fiap.Exemplo02.MVC.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Persistencia.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private PortalContext _context = new PortalContext();

        // ALUNO
        private IGenericRepository<Aluno> _alunoRepository;

        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository;
            }
        }

        //GRUPO
        private IGenericRepository<Grupo> _grupoRepository;

        public IGenericRepository<Grupo> GrupoRepository
        {
            get
            {
                if (_grupoRepository == null)
                {
                    _grupoRepository = new GenericRepository<Grupo>(_context);
                }
                return _grupoRepository;
            }
        }
        //PROJETO
        private IGenericRepository<Projeto> _projetoRepository;

        public IGenericRepository<Projeto> ProjetoRepository
        {
            get
            {
                if (_projetoRepository == null)
                {
                    _projetoRepository = new GenericRepository<Projeto>(_context);
                }
                return _projetoRepository;
            }
        }

        private IProfessorRepository _professorRepository;
        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if(_professorRepository == null)
                {
                    _professorRepository = new ProfessorRepository(_context);
                }
                return _professorRepository;
            }
        }


        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
