using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGeneralAction : IRepositoryGeneralAction
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGeneralAction(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GeneralAction Create(GeneralAction entity)
        {
            return _dbContext.GeneralActions.Add(entity).Entity;
        }

        public bool Delete(GeneralAction Entity)
        {
            _dbContext.GeneralActions.Remove(Entity);
            return true;
        }

        public IEnumerable<GeneralAction> Find(Expression<Func<GeneralAction, bool>> predicate)
        {
            return _dbContext.GeneralActions.Where(predicate);
        }

        public IEnumerable<GeneralAction> GetAll()
        {
            return _dbContext.GeneralActions.ToList();
        }

        public GeneralAction GetByID(int id)
        {
            return _dbContext.GeneralActions.FirstOrDefault(e => e.Aid == id);
        }

        public GeneralAction Update(GeneralAction entity)
        {
            return _dbContext.GeneralActions.Update(entity).Entity;
        }
    }
}
