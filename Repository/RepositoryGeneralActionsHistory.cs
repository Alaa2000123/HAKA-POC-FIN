using Classes;
using Entity;
using Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryGeneralActionsHistory : Repository<GeneralActionsHistory>, IRepositoryGeneralActionsHistory
    {
        public RepositoryGeneralActionsHistory(MyDbContext dbContext)
        : base(dbContext)
        {
        }

        public GeneralActionsHistory GetLastActionHistory(long RequestID)
        {
            return _dbContext.GeneralActionsHistories.Where(e => e.RequestId == RequestID).OrderByDescending(e => e.Id).FirstOrDefault();
        }

        public GeneralActionsHistory InsertGeneralActionHistory(int GeneralRequestID)
        {
            var emp = _dbContext.GeneralEmployees.FirstOrDefault(e => e.Id == 1);
            Entity.GeneralActionsHistory GeneralActionsHistory = new Entity.GeneralActionsHistory
            {
                RequestId = GeneralRequestID,
                StepId = (int)Steps.Requester,
                ActionId = (int)Classes.Actions.Completed,
                ActionName = Classes.Actions.Completed.ToString(),
                ActionByUserName = emp.NameEn,
                ActionDateTime = DateTime.Now,
                UserActionGroup = Classes.Constants.UserGroup
            };
            
            _dbContext.GeneralActionsHistories.Add(GeneralActionsHistory);
            _dbContext.SaveChanges();

            return GeneralActionsHistory;
        }
    }
}
