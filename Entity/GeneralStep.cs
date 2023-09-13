using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_steps")]
public partial class GeneralStep
{
    [Key]
    [Column("STID")]
    public int Stid { get; set; }

    [StringLength(200)]
    public string? StepNameEn { get; set; }

    [Column("StepNameAR")]
    [StringLength(100)]
    public string? StepNameAr { get; set; }

    public bool? Enabled { get; set; }

    [InverseProperty("Step")]
    public virtual ICollection<GeneralActionsHistory> GeneralActionsHistories { get; set; } = new List<GeneralActionsHistory>();

    [InverseProperty("Step")]
    public virtual ICollection<GeneralRequestsService> GeneralRequestsServices { get; set; } = new List<GeneralRequestsService>();
}
