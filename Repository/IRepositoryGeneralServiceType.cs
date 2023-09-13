using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralServiceType
    {
        IEnumerable<GeneralServiceType> GetAll();
        IEnumerable<GeneralServiceType> Find(Expression<Func<GeneralServiceType, bool>> predicate);
        bool Delete(GeneralServiceType Entity);
        GeneralServiceType GetByID(int id);
        GeneralServiceType Create(GeneralServiceType entity);
        GeneralServiceType Update(GeneralServiceType entity);
    }
}
