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
    public class RepositoryGeneralLookup : IRepositoryGeneralLookup
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGeneralLookup(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GeneralLookup> GetAll()
        {
            return _dbContext.GeneralLookups.ToList();
        }

        public IEnumerable<GeneralLookup> Find(Expression<Func<GeneralLookup, bool>> predicate)
        {
            return _dbContext.GeneralLookups.Where(predicate);
        }

        public bool Delete(GeneralLookup Entity)
        {
            _dbContext.GeneralLookups.Remove(Entity);
            return true;
        }

        public GeneralLookup GetByID(int id)
        {
            return _dbContext.GeneralLookups.FirstOrDefault(e => e.Gnid == id);
        }

        public GeneralLookup Create(GeneralLookup entity)
        {
            return _dbContext.GeneralLookups.Add(entity).Entity;
        }

        public GeneralLookup Update(GeneralLookup entity)
        {
            return _dbContext.GeneralLookups.Update(entity).Entity;
        }
    }
}
