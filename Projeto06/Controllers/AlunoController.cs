using Projeto06.Entities;
using Projeto06.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projeto06.Controllers
{
    public class AlunoController
    {

        //atributo para armazenar a connectionstring do banco de dados
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProjeto06;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //método para executar a gravação de Aluno no banco
        public void CadastrarAluno()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE ALUNO***\n");

                var aluno = new Aluno();

                Console.Write("\nInforme o nome do aluno....: ");
                aluno.Nome = Console.ReadLine();

                Console.Write("\nInforme o cpf do aluno....: ");
                aluno.CPF = Console.ReadLine();

                Console.Write("\nInforme a matrícula do aluno....: ");
                aluno.Matricula = Console.ReadLine();


                Console.Write("\nInforme a data de nascimento do aluno....: ");
                aluno.DataNascimento = DateTime.Parse(Console.ReadLine());


                var alunoRepository = new AlunoRepository();

                alunoRepository.ConnectionString = connectionString;
                alunoRepository.Inserir(aluno);

                Console.WriteLine("\nAluno cadastrado com sucesso!");
            }
            catch (SqlException e) //somente para erros de SQL (banco)
            {
                Console.WriteLine("\nNão foi possível realizar o cadastro do aluno.");
                Console.WriteLine("Código do erro: " + e.Number);

                if (e.Number == 8152)
                {
                    Console.WriteLine("O limite de caracteres permitido para um campo foi excedido.");
                }
            }
            catch (Exception e) //qualquer outro tipo de erro
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }


        //método para executar a atualização de uma aluno no banco
        public void AtualizarAluno()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DO ALUNO\n");

                Console.Write("Informe o ID do aluno: ");
                var idAluno = Guid.Parse(Console.ReadLine());

                //instanciando a classe alunoRepository
                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                //buscar a aluno no banco de dados atraves do ID..
                var aluno = alunoRepository.ObterPorId(idAluno);

                //verificar se a aluno foi encontrada..
                if (aluno != null)
                {
                    Console.Write("\nInforme o nome do aluno....: ");
                    aluno.Nome = Console.ReadLine();

                    Console.Write("\nInforme a matrícula do aluno....: ");
                    aluno.Matricula = Console.ReadLine();

                    Console.Write("\nInforme o cpf do aluno....: ");
                    aluno.CPF = Console.ReadLine();

                    Console.Write("\nInforme a data de nascimento do aluno....: ");
                    aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

                    //atualizando os dados da aluno
                    alunoRepository.Atualizar(aluno);
                    Console.WriteLine("\nAluno atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nAluno não encontrado.Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a exclusão de uma aluno no banco
        public void ExcluirAluno()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE ALUNO\n");

                Console.Write("Informe o ID do aluno: ");
                var idaluno = Guid.Parse(Console.ReadLine());

                //instanciando a classe alunoRepository
                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                //buscar a aluno no banco de dados atraves do ID..
                var aluno = alunoRepository.ObterPorId(idaluno);

                //verificar se a aluno foi encontrada..
                if (aluno != null)
                {
                    //excluindo a aluno
                    alunoRepository.Excluir(aluno);

                    Console.WriteLine("\nAluno excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nAluno não encontrado.Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a consulta de aluno
        public void ConsultarAlunos()
        {
            try
            {
                //executando a consulta de alunos
                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterTodos();

                foreach (var item in aluno)
                {
                    Console.Write("\nId do aluno.......................: " + item.IdAluno);
                    Console.Write("\nNome do aluno.....................: " + item.Nome);
                    Console.Write("\nMatrícula do aluno................: " + item.Matricula);
                    Console.Write("\nCpf do aluno......................: " + item.CPF);
                    Console.Write("\nData de Nasciemnto................: " + item.DataNascimento);
                    Console.WriteLine("\n---");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }
    }
}