using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralLookup
    {
        public int Gnid { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Code { get; set; }
        public int? GroupId { get; set; }
        public bool? Enabled { get; set; }
        public string? FilterParameter { get; set; }
        public int? Ordering { get; set; }
        public string? Remark { get; set; }
        public string? CreatedByUserName { get; set; }
        public DateTime? CreatedDateTime { get; set; }

    }
}
