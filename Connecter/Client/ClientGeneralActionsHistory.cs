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
    public class ClientGeneralActionsHistory : Client<DTO.GeneralActionsHistory>, IClientGeneralActionsHistory
    {
        public ClientGeneralActionsHistory(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext) : base(httpClient, serviceSetting, httpContext)
        {

        }
        public async Task<GeneralActionsHistory> InsertGeneralActionHistory(int GeneralRequestID)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("GeneralActionsHistory/InsertGeneralActionHistory?GeneralRequestID=" + GeneralRequestID);
            if (response.IsSuccessStatusCode)
            {
                var Department = await response.Content.ReadAsStringAsync();
                DTO.GeneralActionsHistory Dept = JsonConvert.DeserializeObject<DTO.GeneralActionsHistory>(Department);

                return Dept;
            }
            return null;
        }
    }
}
