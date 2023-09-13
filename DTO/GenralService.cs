using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GenralService
    {
        public int Sid { get; set; }
        public string? ServiceNameEn { get; set; }
        public string? ServiceNameAr { get; set; }
        public string? Department { get; set; }
        public string? RequestFormUrl { get; set; }
        public string? DetailsFormUrl { get; set; }
        public string? K2designerFolderName { get; set; }
        public string? K2workflowName { get; set; }
        public bool? Enabled { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? SecurityDetailsRoleName1 { get; set; }
        public string? SecurityDetailsRoleName2 { get; set; }
        public string? SecurityDetailsRoleName3 { get; set; }

    }
}
