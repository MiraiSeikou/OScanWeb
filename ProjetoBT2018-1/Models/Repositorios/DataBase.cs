using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoBT2018_1.Models.Repositorios
{
    public class DataBase : IDisposable 
    {
        private readonly SqlConnection conn;

        #region Configuração SQL
        // Aqui eu crio um construtor
        // Para que toda vez que a classe for chamada esse método execute
        public DataBase()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
            conn.Open();
        }

        // Aqui eu crio um comando do tipo execute Query
        // Configurei ele de forma padronizada
        public void exeQuery(string strQuery)
        {
            using (var cmd = new SqlCommand { CommandText = strQuery, CommandType = CommandType.Text, Connection = conn })
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Aqui eu crio um comando do tipo Execute Reader
        // Configurei ele de forma padronizada
        public SqlDataReader exeReader(string strQuery)
        {
            using (var cmd = new SqlCommand { CommandText = strQuery, CommandType = CommandType.Text, Connection = conn })
            {
                return cmd.ExecuteReader();
            }
        }

        // Aqui eu instanciei o metodo da interface que a minha classe ira precisar
        // Ela é responsavel por toda vez que a classe for chamada e a conexão com o DataBase for aberta
        // Ela interrompa ao final de cada execução.
        public void Dispose()
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        #endregion
    }
}
