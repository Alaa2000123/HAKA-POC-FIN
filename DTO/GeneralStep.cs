using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralStep
    {
        public int Stid { get; set; }
        public string? StepNameEn { get; set; }
        public string? StepNameAr { get; set; }
        public bool? Enabled { get; set; }

    }
}
