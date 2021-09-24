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

            query.Append("INSERT INTO informaçoes (titulo,categoria,processo,codigo) VALUES");
            query.Append("(@titulo,@categoria,@processo,@codigo)");

            MySqlCommand Comando = new MySqlCommand(query.ToString(), Conexao);

            Comando.Parameters.AddWithValue("@titulo", documents.titulo);
            Comando.Parameters.AddWithValue("@categoria", documents.categoria);
            Comando.Parameters.AddWithValue("@processo", documents.processo);
            Comando.Parameters.AddWithValue("@codigo", documents.codigo);
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
        public List<Documents> Lista()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM informaçoes ORDER BY titulo";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Documents> lista = new List<Documents>();

            while (Reader.Read())
            {

                Documents documentsEncontrado = new Documents();

                if (!Reader.IsDBNull(Reader.GetOrdinal("codigo")))
                    documentsEncontrado.codigo = Reader.GetInt32("codigo");

                if (!Reader.IsDBNull(Reader.GetOrdinal("titulo")))
                    documentsEncontrado.titulo = Reader.GetString("titulo");

                if (!Reader.IsDBNull(Reader.GetOrdinal("categoria")))
                    documentsEncontrado.categoria = Reader.GetString("categoria");

                if (!Reader.IsDBNull(Reader.GetOrdinal("processo")))
                    documentsEncontrado.processo = Reader.GetInt32("processo");

                lista.Add(documentsEncontrado);
            }

            Conexao.Close();
            return lista;
        }
        public void Editar(Documents documents)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "UPDATE informaçoes SET codigo=@codigo WHERE Id=@Id;";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@codigo", documents.codigo);

            Comando.ExecuteNonQuery();
            Conexao.Close();
        }


        public Documents buscarPorCodigo(int codigo)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM informaçoes WHERE codigo=@codigo";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@codigo", codigo);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Documents documentsEncontrado = new Documents();
            if (Reader.Read())
            {

                documentsEncontrado.codigo = Reader.GetInt32("codigo");
            }

            Conexao.Close();
            return documentsEncontrado;
        }



    }

}