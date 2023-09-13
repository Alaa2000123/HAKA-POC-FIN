using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralRequestsService
    {
        public int RequestId { get; set; }
        public int? RequestNo { get; set; }
        public string? EmpNumber { get; set; }
        public string? EmpFullNameAr { get; set; }
        public string? EmpFullNameEn { get; set; }
        public string? EmpUserName { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? StepId { get; set; }
        public int? StatusId { get; set; }
        public long? ProcessId { get; set; }
        public DateTime? ActionLastDateTime { get; set; }
        public bool? OnBehalf { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }

    }
}
