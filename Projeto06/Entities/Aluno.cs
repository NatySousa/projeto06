using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto06.Entities
{
    public class Aluno
    {
        public Guid IdAluno { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }

       
    }
}
