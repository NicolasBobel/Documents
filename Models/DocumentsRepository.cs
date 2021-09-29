using System;
using System.Text;
using MySqlConnector;
using System.Collections.Generic;

namespace RegisterDocuments.Models
{

    public class DocumentsRepository
    {

        private const string ConnectionOptions = "Database=documents;Data Source=localhost;User Id=root;Allow User Variables=true;";

        public void InsertDocument(Documents documents)
        {

            MySqlConnection Connection = new MySqlConnection(ConnectionOptions);
            Connection.Open();

            StringBuilder query = new StringBuilder();

            query.Append("INSERT INTO informaçoes (titulo,categoria,processo,codigo) VALUES");
            query.Append("(@titulo,@categoria,@processo,@codigo)");

            MySqlCommand Comand = new MySqlCommand(query.ToString(), Connection);

            Comand.Parameters.AddWithValue("@titulo", documents.title);
            Comand.Parameters.AddWithValue("@categoria", documents.category);
            Comand.Parameters.AddWithValue("@processo", documents.process);
            Comand.Parameters.AddWithValue("@codigo", documents.code);
            Comand.ExecuteNonQuery();
            Connection.Close();

        }
        public List<Process> ProcessList()
        {
            MySqlConnection Connection = new MySqlConnection(ConnectionOptions);

            Connection.Open();

            String Query = "SELECT * FROM processo";

            MySqlCommand Comand = new MySqlCommand(Query, Connection);
            MySqlDataReader Reader = Comand.ExecuteReader();

            List<Process> processList = new List<Process>();

            while (Reader.Read())
            {

                Process process = new Process();

                if (!Reader.IsDBNull(Reader.GetOrdinal("id")))
                    process.id = Reader.GetString("id");


                if (!Reader.IsDBNull(Reader.GetOrdinal("name")))
                    process.name = Reader.GetString("name");

                processList.Add(process);
            }

            Connection.Close();

            return processList;
        }

        public List<Category> FindCategoryListByProcessId(string idProcesso)
        {

            MySqlConnection Connection = new MySqlConnection(ConnectionOptions);
            Connection.Open();

            String Query = $"SELECT * FROM categoria WHERE idProcesso={idProcesso}";
            MySqlCommand Comand = new MySqlCommand(Query, Connection);
            MySqlDataReader Reader = Comand.ExecuteReader();

            List<Category> categoryList = new List<Category>();

            while (Reader.Read())
            {

                Category category = new Category();

                if (!Reader.IsDBNull(Reader.GetOrdinal("id")))
                    category.id = Reader.GetString("id");


                if (!Reader.IsDBNull(Reader.GetOrdinal("name")))
                    category.name = Reader.GetString("name");


                if (!Reader.IsDBNull(Reader.GetOrdinal("idProcesso")))
                    category.processId = Reader.GetString("idProcesso");

                categoryList.Add(category);
            }
            Connection.Close();

            return categoryList;
        }
        public List<Documents> ListOrderByTitle()
        {
            MySqlConnection Connection = new MySqlConnection(ConnectionOptions);
            Connection.Open();

            String Query = "SELECT * FROM informaçoes ORDER BY titulo";

            MySqlCommand Comand = new MySqlCommand(Query, Connection);
            MySqlDataReader Reader = Comand.ExecuteReader();

            List<Documents> documentList = new List<Documents>();

            while (Reader.Read())
            {

                Documents documents = new Documents();

                if (!Reader.IsDBNull(Reader.GetOrdinal("codigo")))
                    documents.code = Reader.GetInt32("codigo");

                if (!Reader.IsDBNull(Reader.GetOrdinal("titulo")))
                    documents.title = Reader.GetString("titulo");

                if (!Reader.IsDBNull(Reader.GetOrdinal("categoria")))
                    documents.category = Reader.GetString("categoria");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Processo")))
                    documents.process = Reader.GetString("Processo");

                documentList.Add(documents);
            }

            Connection.Close();

            return documentList;
        }

    }

}