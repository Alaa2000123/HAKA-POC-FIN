using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_actions")]
public partial class GeneralAction
{
    [Key]
    [Column("AID")]
    public int Aid { get; set; }

    [StringLength(50)]
    public string? ActionNameAr { get; set; }

    [StringLength(50)]
    public string? ActionNameEn { get; set; }

    [StringLength(50)]
    public string? ActionNameWorkflow { get; set; }

    [InverseProperty("Action")]
    public virtual ICollection<GeneralActionsHistory> GeneralActionsHistories { get; set; } = new List<GeneralActionsHistory>();
}
