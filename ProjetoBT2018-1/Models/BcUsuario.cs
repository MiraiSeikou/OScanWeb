using ProjetoBT2018_1.Models.Contratos;
using ProjetoBT2018_1.Models.Dominio;

namespace ProjetoBT2018_1.Models
{
    public class BcUsuario : DbRepositorio<Usuario>
    {
        private readonly DbRepositorio<Usuario> repositorio;

        public BcUsuario(DbRepositorio<Usuario> dbRepositorio)
        {
            repositorio = dbRepositorio;
        }

        public void save(Usuario usuario)
        {
            repositorio.save(usuario);
        }

        public Usuario SelectId(string email)
        {
            return repositorio.SelectId(email);
        }
    }
}