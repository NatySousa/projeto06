using Projeto06.Controllers;
using System;

namespace Projeto06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE ALUNOS\n");


            var alunoController = new AlunoController();
            
            Console.WriteLine("(1) Cadastrar aluno");
            Console.WriteLine("(2) Atualizar aluno");
            Console.WriteLine("(3) Excluir aluno");
            Console.WriteLine("(4) Consultar alunos");
            Console.WriteLine("(0) Sair");

            try
            {
                Console.Write("\nEscolha a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        alunoController.CadastrarAluno();
                        Main(args); //recursividade
                        break;

                    case 2:
                        alunoController.AtualizarAluno();
                        Main(args); //recursividade
                        break;

                    case 3:
                        alunoController.ExcluirAluno();
                        Main(args); //recursividade
                        break;

                    case 4:
                        alunoController.ConsultarAlunos();
                        Main(args); //recursividade
                        break;              

                    case 0:
                        Console.WriteLine("\nFIM DO PROGRAMA!");
                        break;
                       
                    default: //usado para quando nenhum dos case forem acionados
                        Console.WriteLine("\nOpção inválida, por favor informe uma opção válida");
                        Main(args);
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }

    }

}

