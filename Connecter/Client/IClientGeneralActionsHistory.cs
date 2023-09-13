using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientGeneralActionsHistory : IClient<GeneralActionsHistory>
    {
        public Task<GeneralActionsHistory> InsertGeneralActionHistory(int GeneralRequestID);
    }
}
