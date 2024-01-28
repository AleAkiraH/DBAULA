using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlite
{
    public class ModelAluno
    {
        // Define a classe Aluno
        public class Aluno
        {
            public string Nome { get; set; }
            public string DataNascimento { get; set; }
            public string Telefone { get; set; }
            public string Endereco { get; set; }
            public string Cep { get; set; }
        }

        public class RetornoAluno 
        {
            public long Id { get; set; }
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Telefone { get; set; }
            public string Endereco { get; set; }
            public string Cep { get; set; }
        }
    }
}
