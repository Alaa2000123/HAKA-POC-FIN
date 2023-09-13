using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralServiceType
    {
        public int Stid { get; set; }
        public string? ServiceTypeEn { get; set; }
        public string? ServiceTypeAr { get; set; }
        public int? Ordering { get; set; }
        public bool? Enabled { get; set; }
        public int? ServiceId { get; set; }
        public string? Erpcode { get; set; }

    }
}
