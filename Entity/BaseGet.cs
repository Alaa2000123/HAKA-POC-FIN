using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BaseGet : IBaseGet
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}
