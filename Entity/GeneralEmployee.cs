using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_employee")]
public partial class GeneralEmployee : BaseGet
{

    [StringLength(200)]
    public string? NameEn { get; set; }

    [StringLength(200)]
    public string? NameAr { get; set; }

    public bool? IsDeleted { get; set; }

    [Column("LookupID")]
    public int? LookupId { get; set; }

    [Column("RequestID")]
    public int? RequestId { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<FleetManagement> FleetManagements { get; set; } = new List<FleetManagement>();

    [InverseProperty("Employee")]
    public virtual ICollection<InsuranceInfo> InsuranceInfos { get; set; } = new List<InsuranceInfo>();

    [ForeignKey("LookupId")]
    [InverseProperty("GeneralEmployees")]
    public virtual GeneralLookup? Lookup { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("GeneralEmployees")]
    public virtual GeneralRequestsService? Request { get; set; }
}
