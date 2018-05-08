using ProjetoBT2018_1.Models.Contratos;
using ProjetoBT2018_1.Models.Dominio;

namespace ProjetoBT2018_1.Models.Repositorios
{
    public class BcUsuarioADO : DbRepositorio<Usuario>
    {
        #region 1º versão
        // Aqui eu crio uma funcionalidade que faz uma validação de nv1 se o usuario existe na Base de Dados.
        //public bool ValidaUser(string email)
        //{
        //    return new DataBase().exeReader(string.Format("SELECT id FROM DcUsuario WHERE " +
        //       "email = '{0}'", email)).HasRows;
        //}

        //// Aqui eu crio uma funcionalidade que faz uma validação de nv2 para comprovar que o usuario é quem diz ser.
        //public bool ValidaUser(string email, string senha)
        //{
        //    return new DataBase().exeReader(string.Format("SELECT id FROM DcUsuario WHERE " +
        //        "email = '{0}' AND senha = '{1}'", email, senha)).HasRows;
        //}

        // Aqui eu crio uma funcionalidade que traz todos os cadastros do DataBase.
        //public List<Usuario> Read()
        //{
        //    var usuarios = new List<Usuario>();

        //    using (db = new DataBase())
        //    {
        //        using (SqlDataReader read = db.exeReader("SELECT * FROM DcUsuario"))
        //        {
        //            while (read.Read())
        //            {
        //                usuarios.Add(new Usuario
        //                {
        //                    Id = int.Parse(read["id"].ToString()),
        //                    Nome = read["nome"].ToString(),
        //                    Email = read["email"].ToString(),
        //                });
        //            }

        //            return usuarios;
        //        }
        //    };
        //}

        //// Aqui eu crio uma funcionalidade que deleta o usuario informado
        //public bool Delete(int id)
        //{
        //    using (db = new DataBase())
        //    {
        //        string delete = string.Format("DELETE DcUsuario WHERE id = {0}", id);
        //        db.exeQuery(delete);

        //        return true;
        //    }
        //}
        #endregion

        public static BcUsuario BcUsuarioConstrutor()
        {
            return new BcUsuario(new BcUsuarioADO());
        }

        public void Create(Usuario usuario)
        {
            string str = "INSERT INTO DcUsuario (nome, senha, email) VALUES " +
                string.Format("('{0}', '{1}', '{2}')", usuario.Nome, usuario.Senha, usuario.Email);

            using (DataBase Query = new DataBase())
            {
                Query.exeQuery(str);
            }
        }

        public void Update (Usuario usuario)
        {
            string str = string.Format("UPDATE DcUsuario SET nome = '{0}', senha = '{1}', email = '{2}' WHERE id = {3} ", 
                usuario.Nome, usuario.Senha, usuario.Email, usuario.Id);

            using (DataBase Query = new DataBase())
            {
                Query.exeQuery(str);
            }
        }

        public Usuario SelectId(string email)
        {
            Usuario usuario = new Usuario();

            using (var read = new DataBase().exeReader(string.Format("SELECT * FROM DcUsuario WHERE email = '{0}'", email)))
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        usuario.Id = int.Parse(read["id"].ToString());
                        usuario.Nome = read["nome"].ToString();
                        usuario.Email = read["email"].ToString();
                        usuario.Senha = read["senha"].ToString();
                    }
                }
            }

            return usuario;
        }

        public void save(Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                this.Update(usuario);
            }

            this.Create(usuario);
        }
    }
}
