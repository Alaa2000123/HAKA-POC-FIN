using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGenralService
    {
        IEnumerable<GenralService> GetAll();
        IEnumerable<GenralService> Find(Expression<Func<GenralService, bool>> predicate);
        bool Delete(GenralService Entity);
        GenralService GetByID(int id);
        GenralService Create(GenralService entity);
        GenralService Update(GenralService entity);
    }
}
