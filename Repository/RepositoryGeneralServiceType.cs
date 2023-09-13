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
    public class RepositoryGeneralServiceType : IRepositoryGeneralServiceType
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGeneralServiceType(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GeneralServiceType Create(GeneralServiceType entity)
        {
            return _dbContext.GeneralServiceTypes.Add(entity).Entity;
        }

        public bool Delete(GeneralServiceType Entity)
        {
            _dbContext.GeneralServiceTypes.Remove(Entity);
            return true;
        }

        public IEnumerable<GeneralServiceType> Find(Expression<Func<GeneralServiceType, bool>> predicate)
        {
            return _dbContext.GeneralServiceTypes.Where(predicate);
        }

        public IEnumerable<GeneralServiceType> GetAll()
        {
            return _dbContext.GeneralServiceTypes.ToList();
        }

        public GeneralServiceType GetByID(int id)
        {
            return _dbContext.GeneralServiceTypes.FirstOrDefault(e => e.Stid == id);
        }

        public GeneralServiceType Update(GeneralServiceType entity)
        {
            return _dbContext.GeneralServiceTypes.Update(entity).Entity;
        }
    }
}
