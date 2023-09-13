using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public class ClientGeneralRequestsService : Client<DTO.GeneralRequestsService>, IClientGeneralRequestsService
    {
        public ClientGeneralRequestsService(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext) : base(httpClient, serviceSetting, httpContext)
        {

        }

        public async Task<GeneralRequestsService> InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("GeneralRequestsService/InsertGeneralRequest?TableID=" + TableID + "&ServiceTypeID=" + ServiceTypeID + "&StepID=" + StepID);
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
                DTO.GeneralRequestsService Dept = JsonConvert.DeserializeObject<DTO.GeneralRequestsService>(Department);

                return Dept;
            }
            return null;
        }
    }
}
