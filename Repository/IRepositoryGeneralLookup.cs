using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralLookup 
    {
        IEnumerable<Entity.GeneralLookup> GetAll();
        IEnumerable<Entity.GeneralLookup> Find(Expression<Func<Entity.GeneralLookup, bool>> predicate);
        bool Delete(Entity.GeneralLookup Entity);
        Entity.GeneralLookup GetByID(int id);
        Entity.GeneralLookup Create(Entity.GeneralLookup entity);
        Entity.GeneralLookup Update(Entity.GeneralLookup entity);
    }
}
