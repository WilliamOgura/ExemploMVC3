using Fiap.Exemplo03.UI.Console.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.Repositories
{

    public class GenericRepository<AlunoDTO> : IGenericRepository<AlunoDTO>
    { 

        public void Atualizar(AlunoDTO entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AlunoDTO entidade)
        {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:22345/");
            var cli = new aluno() { Nome = "Thiago"};
            HttpResponseMessage response =
            client.PostAsJsonAsync("api/cliente", cli).Result;
            if (response.IsSuccessStatusCode)
            {
                Uri uri = response.Headers.Location;
            }
        }
    }

        public ICollection<AlunoDTO> Listar(AlunoDTO aluno)
        {
            using (var alunos = new HttpClient())
            {
                alunos.BaseAddress = new Uri("http://localhost:22345/");
                alunos.DefaultRequestHeaders.Accept.Clear();
                alunos.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = alunos.GetAsync("api/cliente").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<AlunoDTO> a = null;
                    a = response.Content.ReadAsAsync < IEnumerable<AlunoDTO>>().Result;
                }
            }
            }
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }

