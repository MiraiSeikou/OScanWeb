using ProjetoBT2018_1.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBT2018_1.Models
{
    public class BcSistema
    {
        private DataBase db;

        // Aqui eu crio uma funcionalidade que faz uma validação de nv1 se o usuario existe na Base de Dados.
        public bool ValidaUser(string email)
        {
            return new DataBase().exeReader(string.Format("SELECT id FROM DcUsuario WHERE " +
               "email = '{0}'", email)).HasRows;
        }

        // Aqui eu crio uma funcionalidade que faz uma validação de nv2 para comprovar que o usuario é quem diz ser.
        public bool ValidaUser(string email, string senha)
        {
            return new DataBase().exeReader(string.Format("SELECT id FROM DcUsuario WHERE " +
                "email = '{0}' AND senha = '{1}'", email, senha)).HasRows;
        }

        // Aqui eu crio uma funcionalidade que traz todos os cadastros do DataBase.
        public List<Usuario> Read()
        {
            var usuarios = new List<Usuario>();

            using (db = new DataBase())
            {
                using (SqlDataReader read = db.exeReader("SELECT * FROM DcUsuario"))
                {
                    while (read.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = int.Parse(read["id"].ToString()),
                            Nome = read["nome"].ToString(),
                            Email = read["email"].ToString(),
                        });
                    }

                    return usuarios;
                }
            };
        }

        // Aqui eu crio uma funcionalidade que deleta o usuario informado
        public bool Delete(int id)
        {
            using (db = new DataBase())
            {
                string delete = string.Format("DELETE DcUsuario WHERE id = {0}", id);
                db.exeQuery(delete);

                return true;
            }
        }
    }
}
