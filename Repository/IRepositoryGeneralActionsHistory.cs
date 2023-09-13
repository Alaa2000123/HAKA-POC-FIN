using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryGeneralActionsHistory : IRepository<GeneralActionsHistory>
    {
        public Entity.GeneralActionsHistory InsertGeneralActionHistory(int GeneralRequestID);
        public Entity.GeneralActionsHistory GetLastActionHistory(Int64 RequestID);
    }
}
