using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralEmployee
    {
        public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public bool? IsDeleted { get; set; }
        public int? LookupId { get; set; }
        public int? RequestId { get; set; }

    }
}
