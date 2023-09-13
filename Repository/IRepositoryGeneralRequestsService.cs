using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralRequestsService
    {
        public Int64 NewProcessID();
        public Entity.GeneralRequestsService InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID);
        IEnumerable<GeneralRequestsService> GetAll();
        IEnumerable<GeneralRequestsService> Find(Expression<Func<GeneralRequestsService, bool>> predicate);
        bool Delete(GeneralRequestsService Entity);
        GeneralRequestsService GetByID(int id);
        GeneralRequestsService Create(GeneralRequestsService entity);
        GeneralRequestsService Update(GeneralRequestsService entity);

    }
}
