using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_lookups")]
public partial class GeneralLookup
{
    [Key]
    [Column("GNID")]
    public int Gnid { get; set; }

    [StringLength(200)]
    public string? NameEn { get; set; }

    [StringLength(200)]
    public string? NameAr { get; set; }

    [StringLength(30)]
    public string? Code { get; set; }

    public int? GroupId { get; set; }

    public bool? Enabled { get; set; }

    [Column("filterParameter")]
    [StringLength(30)]
    public string? FilterParameter { get; set; }

    public int? Ordering { get; set; }

    public string? Remark { get; set; }

    [StringLength(50)]
    public string? CreatedByUserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime { get; set; }

    [InverseProperty("FleetManagementType")]
    public virtual ICollection<FleetManagement> FleetManagements { get; set; } = new List<FleetManagement>();

    [InverseProperty("Lookup")]
    public virtual ICollection<GeneralEmployee> GeneralEmployees { get; set; } = new List<GeneralEmployee>();

    [ForeignKey("GroupId")]
    [InverseProperty("GeneralLookups")]
    public virtual GeneralLookupsGroup? Group { get; set; }

    [InverseProperty("InsuranceType")]
    public virtual ICollection<InsuranceInfo> InsuranceInfos { get; set; } = new List<InsuranceInfo>();
}
