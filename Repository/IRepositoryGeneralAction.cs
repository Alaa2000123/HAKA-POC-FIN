using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralAction 
    {
        IEnumerable<GeneralAction> GetAll();
        IEnumerable<GeneralAction> Find(Expression<Func<GeneralAction, bool>> predicate);
        bool Delete(GeneralAction Entity);
        GeneralAction GetByID(int id);
        GeneralAction Create(GeneralAction entity);
        GeneralAction Update(GeneralAction entity);
    }
}
