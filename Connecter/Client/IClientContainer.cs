using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientContainer
    {
        IClient<DTO.FleetManagement> FleetManagement { get; }
        IClient<DTO.GeneralAction> GeneralAction { get; }
        IClientGeneralActionsHistory GeneralActionsHistory { get; }
        IClient<DTO.GeneralEmployee> GeneralEmployee { get; }
        IClient<DTO.GeneralLookup> GeneralLookup { get; }
        IClient<DTO.GeneralLookupsGroup> GeneralLookupsGroups { get; }
        IClientGeneralRequestsService GeneralRequestsService { get; }
        IClient<DTO.GeneralServiceType> GeneralServiceType { get; }
        IClient<DTO.GeneralStep> GeneralStep { get; }
        IClient<DTO.GenralService> GenralService { get; }
        IClient<DTO.GenralStatus> GenralStatus { get; }
        IClient<DTO.InsuranceCompanyType> InsuranceCompanyType { get; }
        IClient<DTO.InsuranceInfo> InsuranceInfo { get; }
        ServiceSetting ServiceSetting { get; }
    }
}
