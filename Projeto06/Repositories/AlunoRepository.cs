using Dapper;
using Projeto06.Entities;
using Projeto06.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto06.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
            //prop + 2x[tab]
            public string ConnectionString { get; set; }

            public void Inserir(Aluno aluno)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("SP_INSERIRALUNO",
                        new
                        {
                            @NOME = aluno.Nome,
                            @CPF = aluno.CPF,
                            @MATRICULA = aluno.Matricula,
                            @DATANASCIMENTO = aluno.DataNascimento
                        },
                        commandType: CommandType.StoredProcedure);
                }
            }


            public void Atualizar(Aluno aluno)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("SP_ATUALIZARALUNO",
                        new
                        {
                            @IDALUNO = aluno.IdAluno,
                            @NOME = aluno.Nome,
                            @CPF = aluno.CPF,
                            @MATRICULA = aluno.Matricula,
                            @DATANASCIMENTO = aluno.DataNascimento
                        },
                        commandType: CommandType.StoredProcedure);
                }
            }

            public void Excluir(Aluno aluno) 
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("SP_EXCLUIRALUNO",
                        new
                        {
                            @IDALUNO = aluno.IdAluno
                        },
                        commandType: CommandType.StoredProcedure);
                }
            }

            public List<Aluno> ObterTodos()
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    return connection.Query<Aluno>("SP_OBTERALUNOS",
                        commandType: CommandType.StoredProcedure)
                        .ToList();
                }
            }

            public Aluno ObterPorId(Guid idaluno)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    return connection.Query<Aluno>("SP_OBTERALUNOPORID",
                        new
                        {
                            @IDALUNO = idaluno
                        },
                        commandType: CommandType.StoredProcedure)
                        .FirstOrDefault();
                }
            }
        }
    }
