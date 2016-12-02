using Fiap.Exemplo03.UI.Console.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AlunoDTO aluno = new AlunoDTO();

            System.Console.WriteLine("Escolha opção :(1- cadas / 2-li )");
            int opcion = Convert.ToInt32(System.Console.ReadLine());
      
           

            switch (opcion)
            {
                case 1:
                    System.Console.WriteLine("Escreva nome:");
                    System.Console.ReadLine();
                    break;
                case 2:
                    System.Console.WriteLine(aluno.Nome+"/n"+aluno.Bolsa+""+aluno.DataNascimento);
                    break;
            }
        }
    }
}
