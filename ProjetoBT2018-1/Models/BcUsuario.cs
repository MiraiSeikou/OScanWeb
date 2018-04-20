using ProjetoBT2018_1.Models.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBT2018_1.Models
{
    public class BcUsuario
    {
        DataBase db;

        // Aqui eu crio uma Business Cliente
        // Que é responsável po criar um usuario novo
        public void Create(Usuario usuario)
        {
            string insert = "INSERT INTO DcUsuario (nome, senha, email) VALUES ";
            insert += string.Format("('{0}',{1},'{2}')", usuario.Nome, usuario.Senha, usuario.Email);

            using (db = new DataBase())
            {
                db.exeQuery(insert);
            }
        }

        // Aqui eu crio uma Business Cliente 
        // Que é responsável por atualizar as informações do usuario
        public bool Update(Usuario usuario)
        {
            using (db = new DataBase())
            {
                string update = "UPDATE DcUsuario SET ";
                update += string.Format("nome = '{0}', senha = '{1}', email = '{2}' ", usuario.Nome, usuario.Senha, usuario.Email);
                update += string.Format("WHERE id = {0}", usuario.Id);

                db.exeQuery(update);
                return true;
            }
        }
    }
}
