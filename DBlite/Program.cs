using DBlite.DB;
using System.Text.Json;
using static DBlite.ModelAluno;

class Program
{
    static void Main()
    {
        ModelDBClass mdb = new ModelDBClass();

        if (true)
        {
            var exemploJsonObject = @"{
          ""Nome"": ""Alexsander de Souza Ferreira"",
          ""DataNascimento"": ""1990-10-18"",
          ""Telefone"": ""(11) 99999-9999"",
          ""Endereco"": ""Av Joao Caiafa, 40"",
          ""Cep"": ""05742-100""
        }";

            //var exemploJsonObject = @"{
            //  ""Nome"": ""Ivani de Souza Ferreira"",
            //  ""DataNascimento"": ""1960-11-22"",
            //  ""Telefone"": ""(11) 99999-9999"",
            //  ""Endereco"": ""Sitio Angatuba"",
            //  ""Cep"": ""05742-120""
            //}";

            // Converte a string JSON para um objeto
            Aluno aluno = JsonSerializer.Deserialize<Aluno>(exemploJsonObject);

            mdb.cadastroNovoAluno(aluno);

        }
        else
        {
            var resultadoDB = mdb.buscaAlunoAcademia("sander");
        }

        var a = "";
    }
}