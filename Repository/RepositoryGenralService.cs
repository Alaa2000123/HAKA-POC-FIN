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
    public class RepositoryGenralService : IRepositoryGenralService
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGenralService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GenralService> GetAll()
        {
            return _dbContext.GenralServices.ToList();
        }

        public IEnumerable<GenralService> Find(Expression<Func<GenralService, bool>> predicate)
        {
            return _dbContext.GenralServices.Where(predicate);
        }

        public bool Delete(GenralService Entity)
        {
            _dbContext.GenralServices.Remove(Entity);
            return true;
        }

        public GenralService GetByID(int id)
        {
            return _dbContext.GenralServices.FirstOrDefault(e => e.Sid == id);
        }

        public GenralService Create(GenralService entity)
        {
            return _dbContext.GenralServices.Add(entity).Entity;
        }

        public GenralService Update(GenralService entity)
        {
            return _dbContext.GenralServices.Update(entity).Entity;
        }
    }
}
