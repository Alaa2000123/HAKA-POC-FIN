using Entity;
using Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{
    public class RepositoryGeneralRequestsService : IRepositoryGeneralRequestsService
    {
        public MyDbContext _dbContext { get; set; }
        public RepositoryGeneralRequestsService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GeneralRequestsService> GetAll()
        {
            return _dbContext.GeneralRequestsServices.ToList();
        }

        public IEnumerable<GeneralRequestsService> Find(Expression<Func<GeneralRequestsService, bool>> predicate)
        {
            return _dbContext.GeneralRequestsServices.Where(predicate);
        }

        public bool Delete(GeneralRequestsService Entity)
        {
            _dbContext.GeneralRequestsServices.Remove(Entity);
            return true;
        }

        public GeneralRequestsService GetByID(int id)
        {
            return _dbContext.GeneralRequestsServices.FirstOrDefault(e => e.RequestId == id);
        }

        public GeneralRequestsService Create(GeneralRequestsService entity)
        {
            return _dbContext.GeneralRequestsServices.Add(entity).Entity;
        }

        public GeneralRequestsService Update(GeneralRequestsService entity)
        {
            return _dbContext.GeneralRequestsServices.Update(entity).Entity;
        }

        public long NewProcessID()
        {
            var SelectedGeneralRequest = _dbContext.GeneralRequestsServices.OrderByDescending(e => e.ProcessId).FirstOrDefault();
            if (SelectedGeneralRequest == null)
                return 1;
            else
                return SelectedGeneralRequest.ProcessId.Value + 1;
        }

        public GeneralRequestsService InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID)
        {
            var emp = _dbContext.GeneralEmployees.FirstOrDefault(e => e.Id == 1);
            Entity.GeneralRequestsService generalRequest = new Entity.GeneralRequestsService
            {
                RequestNo = TableID,
                EmpUserName = emp.NameEn,
                EmpFullNameAr = emp.NameAr,
                EmpFullNameEn = emp.NameEn,
                EmpNumber = (emp.Id).ToString(),
                ActionLastDateTime = DateTime.Now,
                CreatedBy = emp.NameEn,
                CreatedDateTime = DateTime.Now,
                OnBehalf = false,
                ServiceTypeId = ServiceTypeID,
                StatusId = 1,
                StepId = StepID,
                ProcessId = null// _GeneralRequest.NewProcessID(),
            };


            _dbContext.GeneralRequestsServices.Add(generalRequest);
            _dbContext.SaveChanges();

            return generalRequest;
        }
    }
}
