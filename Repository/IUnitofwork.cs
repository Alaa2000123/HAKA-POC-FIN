using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitofwork : IDisposable
    {
        IRepositoryFleetManagement FleetManagement { get; }
        IRepositoryGeneralAction GeneralAction { get; }
        IRepositoryGeneralActionsHistory GeneralActionsHistory { get; }
        IRepositoryGeneralEmployee GeneralEmployee { get; }
        IRepositoryGeneralLookup GeneralLookup { get; }
        IRepositoryGeneralLookupsGroup GeneralLookupsGroup { get; }
        IRepositoryGeneralRequestsService GeneralRequestsService { get; }
        IRepositoryGeneralServiceType ServiceType { get; }
        IRepositoryGeneralStep GeneralStep { get; }
        IRepositoryGenralService GenralService { get; }
        IRepositoryGenralStatus GeneralStatus { get; }
        IRepositoryInsuranceCompanyType InsuranceCompanyType { get; }
        IRepositoryInsuranceInfo InsuranceInfo { get; }

        void Complete();
    }
}
