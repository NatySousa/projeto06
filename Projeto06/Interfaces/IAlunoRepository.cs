using Projeto06.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto06.Interfaces
{
    interface IAlunoRepository
    {
        void Inserir(Aluno aluno);

        void Atualizar(Aluno aluno);

        void Excluir(Aluno aluno);

        List<Aluno> ObterTodos();

        Aluno ObterPorId(Guid idAluno);

    }
}
