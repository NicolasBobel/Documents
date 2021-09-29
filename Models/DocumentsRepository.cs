using System;
using System.Text;
using MySqlConnector;
using System.Collections.Generic;

namespace RegisterDocuments.Models
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
                    processoEncontrado.id = Reader.GetString("id");


                if (!Reader.IsDBNull(Reader.GetOrdinal("name")))
                    processoEncontrado.name = Reader.GetString("name");

                listagem.Add(processoEncontrado);
            }
            Conexao.Close();
            return listagem;
        }

        public List<categoria> ListarCategoriaPorIdProcesso(string idProcesso)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = $"SELECT * FROM categoria WHERE idProcesso={idProcesso}";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<categoria> ListarCategoriaPorIdProcesso = new List<categoria>();

            while (Reader.Read())
            {

                categoria IdProcessoEncontrado = new categoria();
                if (!Reader.IsDBNull(Reader.GetOrdinal("id")))
                    IdProcessoEncontrado.id = Reader.GetString("id");


                if (!Reader.IsDBNull(Reader.GetOrdinal("name")))
                    IdProcessoEncontrado.name = Reader.GetString("name");


                if (!Reader.IsDBNull(Reader.GetOrdinal("idProcesso")))
                    IdProcessoEncontrado.idProcesso = Reader.GetString("idProcesso");

                ListarCategoriaPorIdProcesso.Add(IdProcessoEncontrado);
            }
            Conexao.Close();
            return ListarCategoriaPorIdProcesso;
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
                    documentsEncontrado.processo = Reader.GetString("processo");

                lista.Add(documentsEncontrado);
            }

            Conexao.Close();
            return lista;
        }



    }

}