using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{
    public class RepositoryGeneralLookupsGroup : IRepositoryGeneralLookupsGroup
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGeneralLookupsGroup(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GeneralLookupsGroup Create(GeneralLookupsGroup entity)
        {
            return _dbContext.GeneralLookupsGroups.Add(entity).Entity;
        }

        public bool Delete(GeneralLookupsGroup Entity)
        {
            _dbContext.GeneralLookupsGroups.Remove(Entity);
            return true;
        }

        public IEnumerable<GeneralLookupsGroup> Find(Expression<Func<GeneralLookupsGroup, bool>> predicate)
        {
            return _dbContext.GeneralLookupsGroups.Where(predicate);
        }

        public IEnumerable<GeneralLookupsGroup> GetAll()
        {
            return _dbContext.GeneralLookupsGroups.ToList();
        }

        public GeneralLookupsGroup GetByID(int id)
        {
            return _dbContext.GeneralLookupsGroups.FirstOrDefault(e => e.Gid == id);
        }

        public GeneralLookupsGroup Update(GeneralLookupsGroup entity)
        {
            return _dbContext.GeneralLookupsGroups.Update(entity).Entity;
        }
    }
}
