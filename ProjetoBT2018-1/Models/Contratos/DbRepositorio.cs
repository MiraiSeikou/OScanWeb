using System.Collections.Generic;

namespace ProjetoBT2018_1.Models.Contratos
{
    public interface DbRepositorio<Entity> where Entity : class
    {
        void save(Entity entity);
        Entity SelectId(string email);
    }
}
