using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralLookupsGroup
    {
        IEnumerable<GeneralLookupsGroup> GetAll();
        IEnumerable<GeneralLookupsGroup> Find(Expression<Func<GeneralLookupsGroup, bool>> predicate);
        bool Delete(GeneralLookupsGroup Entity);
        GeneralLookupsGroup GetByID(int id);
        GeneralLookupsGroup Create(GeneralLookupsGroup entity);
        GeneralLookupsGroup Update(GeneralLookupsGroup entity);
    }
}
