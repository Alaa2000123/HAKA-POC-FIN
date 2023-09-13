using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Unitofwork : IUnitofwork
    {
        private readonly MyDbContext _context;

        public IRepositoryFleetManagement FleetManagement { get; private set; }

        public IRepositoryGeneralActionsHistory GeneralActionsHistory { get; private set; }

        public IRepositoryGeneralEmployee GeneralEmployee { get; private set; }

        public IRepositoryGeneralLookup GeneralLookup { get; private set; }

        public IRepositoryGeneralLookupsGroup GeneralLookupsGroup { get; private set; }

        public IRepositoryGeneralRequestsService GeneralRequestsService { get; private set; }

        public IRepositoryGeneralServiceType ServiceType { get; private set; }

        public IRepositoryGeneralStep GeneralStep { get; private set; }

        public IRepositoryGenralService GenralService { get; private set; }

        public IRepositoryGenralStatus GeneralStatus { get; private set; }

        public IRepositoryInsuranceCompanyType InsuranceCompanyType { get; private set; }

        public IRepositoryInsuranceInfo InsuranceInfo { get; private set; }

        public IRepositoryGeneralAction GeneralAction { get; private set; }

        public Unitofwork(MyDbContext context)
        {
            _context = context;
            FleetManagement = new RepositoryFleetManagement(context);
            GeneralActionsHistory = new RepositoryGeneralActionsHistory(context);
            GeneralEmployee = new RepositoryGeneralEmployee(context);
            GeneralLookup = new RepositoryGeneralLookup(context);
            GeneralLookupsGroup = new RepositoryGeneralLookupsGroup(context);
            GeneralRequestsService=new RepositoryGeneralRequestsService(context);
            ServiceType = new RepositoryGeneralServiceType(context);
            GeneralStep = new RepositoryGeneralStep(context);
            GenralService = new RepositoryGenralService(context);
            GeneralStatus = new RepositoryGenralStatus(context);
            InsuranceCompanyType = new RepositoryInsuranceCompanyType(context);
            InsuranceInfo = new RepositoryInsuranceInfo(context);
            GeneralAction = new RepositoryGeneralAction(context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
