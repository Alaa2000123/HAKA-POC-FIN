using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InsuranceInfo
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? InsuranceTypeId { get; set; }
        public DateTime? InsuranceStartDate { get; set; }
        public DateTime? InsuranceEndDate { get; set; }
        public string? Remark { get; set; }
        public int? InsuranceCompanyTypeId { get; set; }
        public int? RequestId { get; set; }

    }
}
