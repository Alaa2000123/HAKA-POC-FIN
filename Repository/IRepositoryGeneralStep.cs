using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralStep
    {
        IEnumerable<GeneralStep> GetAll();
        IEnumerable<GeneralStep> Find(Expression<Func<GeneralStep, bool>> predicate);
        bool Delete(GeneralStep Entity);
        GeneralStep GetByID(int id);
        GeneralStep Create(GeneralStep entity);
        GeneralStep Update(GeneralStep entity);
    }
}
