using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralLookupsGroup
    {
        public int Gid { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Remark { get; set; }
        public string? CreatedByUserName { get; set; }
        public DateTime? CreatedDateTime { get; set; }

    }
}
