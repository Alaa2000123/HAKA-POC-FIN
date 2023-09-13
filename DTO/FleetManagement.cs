using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FleetManagement
    {
        public int Id { get; set; }
        public string? CarNumber { get; set; }
        public int? EmployeeId { get; set; }
        public int? RequestId { get; set; }
        public string? Long { get; set; }
        public string? Lat { get; set; }
        public string? Remark { get; set; }
        public int? FleetManagementTypeId { get; set; }
    }
}
