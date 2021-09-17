using System;
using System.Text;
using MySqlConnector;
using System.Collections.Generic;

namespace TesteCadastro.Models
{

    public class DocumentsRepository
    {

        private const string DadosConexao = "Database=documents;Data Source=localhost;User Id=root;Allow User Variables=true;";

        public void Cadastro(Documents documents)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            StringBuilder query = new StringBuilder();

            query.Append("INSERT INTO informaçoes (titulo,categoria,processo) VALUES");
            query.Append("(@titulo,@categoria,@processo)");

            MySqlCommand Comando = new MySqlCommand(query.ToString(), Conexao);

            Comando.Parameters.AddWithValue("@titulo", documents.titulo);
            Comando.Parameters.AddWithValue("@categoria", documents.categoria);
            Comando.Parameters.AddWithValue("@processo", documents.processo);
            Comando.ExecuteNonQuery();
            Conexao.Close();

        }
        public List<Processo> Listagem()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM processo";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Processo> listagem = new List<Processo>();

            while (Reader.Read())
            {

                Processo processoEncontrado = new Processo();

                if (!Reader.IsDBNull(Reader.GetOrdinal("id")))
                    processoEncontrado.id = Reader.GetInt32("id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("name")))
                    processoEncontrado.name = Reader.GetString("name");

                listagem.Add(processoEncontrado);
            }
            Conexao.Close();
            return listagem;
        }
    }
}