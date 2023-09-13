using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Models
{
    public class ActionTake
    {
        public int folio { get; set; }
        public int EmpId { get; set; }
        public int ActionId { get; set; }

        public string Remark { get; set; }
    }
}
