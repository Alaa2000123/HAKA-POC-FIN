using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientGeneralRequestsService : IClient<GeneralRequestsService>
    {
        public Task<GeneralRequestsService> InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID);

    }
}
