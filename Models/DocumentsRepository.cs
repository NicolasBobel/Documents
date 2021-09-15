using System;
using MySqlConnector;
using System.Collections.Generic;


namespace TesteCadastro.Models
{

    public class DocumentsRepository
    {

        private const string DadosConexao = "Database=documentos;Data Source=localhost;User Id=root;Allow User Variables=true;";

        public void Cadastro(Documents documents)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "INSERT INTO documentos (codigo,titulo,processo,categoria) VALUES ";
            Query = Query + "(@codigo,@titulo,@processo,@categoria)";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@codigo", documents.codigo);
            Comando.Parameters.AddWithValue("@titulo", documents.titulo);
            //Comando.Parameters.AddWithValue("@processo", documents.processo);
            Comando.Parameters.AddWithValue("@categoria", documents.categoria);
            Comando.ExecuteNonQuery();
            Conexao.Close();

        }






    }
}