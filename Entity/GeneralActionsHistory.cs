using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_actionsHistory")]
public partial class GeneralActionsHistory : BaseGet
{
   

    [Column("RequestID")]
    public int? RequestId { get; set; }

    public string? Remark { get; set; }

    [Column("StepID")]
    public int? StepId { get; set; }

    [Column("ActionID")]
    public int? ActionId { get; set; }

    [StringLength(200)]
    public string? ActionName { get; set; }

    [StringLength(200)]
    public string? ActionByUserName { get; set; }

    [StringLength(200)]
    public string? ActionByDisplayName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActionDateTime { get; set; }

    [StringLength(50)]
    public string? UserActionGroup { get; set; }

    [ForeignKey("ActionId")]
    [InverseProperty("GeneralActionsHistories")]
    public virtual GeneralAction? Action { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("GeneralActionsHistories")]
    public virtual GeneralRequestsService? Request { get; set; }

    [ForeignKey("StepId")]
    [InverseProperty("GeneralActionsHistories")]
    public virtual GeneralStep? Step { get; set; }
}
