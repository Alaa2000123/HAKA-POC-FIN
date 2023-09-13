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
    public class RepositoryGeneralStep : IRepositoryGeneralStep
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGeneralStep(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GeneralStep Create(GeneralStep entity)
        {
            return _dbContext.GeneralSteps.Add(entity).Entity;
        }

        public bool Delete(GeneralStep Entity)
        {
            _dbContext.GeneralSteps.Remove(Entity);
            return true;
        }

        public IEnumerable<GeneralStep> Find(Expression<Func<GeneralStep, bool>> predicate)
        {
            return _dbContext.GeneralSteps.Where(predicate);
        }

        public IEnumerable<GeneralStep> GetAll()
        {
            return _dbContext.GeneralSteps.ToList();
        }

        public GeneralStep GetByID(int id)
        {
            return _dbContext.GeneralSteps.FirstOrDefault(e => e.Stid == id);
        }

        public GeneralStep Update(GeneralStep entity)
        {
            return _dbContext.GeneralSteps.Update(entity).Entity;
        }
    }
}
