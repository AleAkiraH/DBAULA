using System.Data.SQLite;
using static DBlite.ModelAluno;
using static Program;

namespace DBlite.DB
{
    public class ModelDBClass
    {
        string connectionString = "Data Source=C:\\Users\\alexs\\source\\repos\\DBlite\\DBlite\\DB\\DBAcademia.db;Version=3;";

        public void cadastroNovoAluno(Aluno aluno)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                // Abre a conexão
                connection.Open();

                // Cria um comando para inserir dados
                using (var command = new SQLiteCommand(connection))
                {
                    // Define o texto do comando
                    command.CommandText = "INSERT INTO alunos (nome, data_nascimento, telefone, endereco, cep) VALUES (@nome, @data_nascimento, @telefone, @endereco, @cep)";

                    // Adiciona os parâmetros
                    command.Parameters.AddWithValue("@nome", aluno.Nome);
                    command.Parameters.AddWithValue("@data_nascimento", aluno.DataNascimento);
                    command.Parameters.AddWithValue("@telefone", aluno.Telefone);
                    command.Parameters.AddWithValue("@endereco", aluno.Endereco);
                    command.Parameters.AddWithValue("@cep", aluno.Cep);

                    // Executa o comando
                    command.ExecuteNonQuery();
                }

                // Fecha a conexão
                connection.Close();
            }
        }

        public RetornoAluno buscaAlunoAcademia(string nomeAluno)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                // Abre a conexão 
                connection.Open();

                // Cria um comando para executar a consulta 
                var command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM alunos WHERE nome LIKE '%"+nomeAluno+"%'";

                // Executa a consulta e obtém os resultados 
                var reader = command.ExecuteReader();

                // Lê os resultados e cria um objeto  Aluno  
                RetornoAluno aluno = null;
                if (reader.Read())
                {
                    aluno = new RetornoAluno
                    {
                        Id = (Int64)reader["id"],
                        Nome = (string)reader["nome"],
                        DataNascimento = (DateTime)reader["data_nascimento"],
                        Telefone = (string)reader["telefone"],
                        Endereco = (string)reader["endereco"],
                        Cep = (string)reader["cep"]
                    };
                }

                // Fecha o leitor 
                reader.Close();

                // Fecha a conexão 
                connection.Close();

                // Retorna o objeto  Aluno  
                return aluno;
            }
        }
    }
}
