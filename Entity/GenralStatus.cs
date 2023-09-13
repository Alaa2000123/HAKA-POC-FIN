using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("genral_status")]
public partial class GenralStatus :BaseGet
{

    [StringLength(50)]
    public string? Name { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<GeneralRequestsService> GeneralRequestsServices { get; set; } = new List<GeneralRequestsService>();
}
