using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralActionsHistory
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? Remark { get; set; }
        public int? StepId { get; set; }
        public int? ActionId { get; set; }
        public string? ActionName { get; set; }
        public string? ActionByUserName { get; set; }
        public string? ActionByDisplayName { get; set; }
        public DateTime? ActionDateTime { get; set; }
        public string? UserActionGroup { get; set; }

    }
}
