using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_lookupsGroups")]
public partial class GeneralLookupsGroup
{
    [Key]
    [Column("GID")]
    public int Gid { get; set; }

    [StringLength(200)]
    public string? NameEn { get; set; }

    [StringLength(200)]
    public string? NameAr { get; set; }

    public string? Remark { get; set; }

    [StringLength(50)]
    public string? CreatedByUserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<GeneralLookup> GeneralLookups { get; set; } = new List<GeneralLookup>();
}
