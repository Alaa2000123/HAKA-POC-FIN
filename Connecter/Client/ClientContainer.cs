using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public class ClientContainer : IClientContainer
    {
        public IClient<FleetManagement> FleetManagement { get; private set; }

        public IClient<GeneralAction> GeneralAction { get; private set; }

        public IClientGeneralActionsHistory GeneralActionsHistory { get; private set; }

        public IClient<GeneralEmployee> GeneralEmployee{ get; private set; }

        public IClient<GeneralLookup> GeneralLookup { get; private set; }

        public IClient<GeneralLookupsGroup> GeneralLookupsGroups { get; private set; }

        public IClientGeneralRequestsService GeneralRequestsService { get; private set; }

        public IClient<GeneralServiceType> GeneralServiceType { get; private set; }

        public IClient<GeneralStep> GeneralStep { get; private set; }

        public IClient<GenralService> GenralService { get; private set; }

        public IClient<GenralStatus> GenralStatus { get; private set; }

        public IClient<InsuranceCompanyType> InsuranceCompanyType { get; private set; }

        public IClient<InsuranceInfo> InsuranceInfo { get; private set; }

        public ServiceSetting ServiceSetting { get; private set; }
        public ClientContainer(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext)
        {
            ServiceSetting = serviceSetting.Value;
            FleetManagement = new Client<FleetManagement>(httpClient, serviceSetting, httpContext);
            GeneralAction = new Client<GeneralAction>(httpClient, serviceSetting, httpContext);
            GeneralActionsHistory = new ClientGeneralActionsHistory(httpClient, serviceSetting, httpContext);
            GeneralEmployee = new Client<GeneralEmployee>(httpClient, serviceSetting, httpContext);
            GeneralLookup = new Client<GeneralLookup>(httpClient, serviceSetting, httpContext);
            GeneralLookupsGroups = new Client<GeneralLookupsGroup>(httpClient, serviceSetting, httpContext);
            GeneralRequestsService = new ClientGeneralRequestsService(httpClient, serviceSetting, httpContext);
            GeneralServiceType = new Client<GeneralServiceType>(httpClient, serviceSetting, httpContext);
            GeneralStep = new Client<GeneralStep>(httpClient, serviceSetting, httpContext);
            GenralService = new Client<GenralService>(httpClient, serviceSetting, httpContext);
            GenralStatus = new Client<GenralStatus>(httpClient, serviceSetting, httpContext);
            InsuranceCompanyType = new Client<InsuranceCompanyType>(httpClient, serviceSetting, httpContext);   
            InsuranceInfo = new Client<InsuranceInfo>(httpClient, serviceSetting, httpContext);

        }
    }
}
