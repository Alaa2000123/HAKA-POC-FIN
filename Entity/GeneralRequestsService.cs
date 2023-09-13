using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("general_requests_service")]
public partial class GeneralRequestsService
{
    [Key]
    [Column("RequestID")]
    public int RequestId { get; set; }

    public int? RequestNo { get; set; }

    [StringLength(11)]
    public string? EmpNumber { get; set; }

    [StringLength(200)]
    public string? EmpFullNameAr { get; set; }

    [StringLength(200)]
    public string? EmpFullNameEn { get; set; }

    [StringLength(100)]
    public string? EmpUserName { get; set; }

    [Column("ServiceTypeID")]
    public int? ServiceTypeId { get; set; }

    [Column("StepID")]
    public int? StepId { get; set; }

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [Column("ProcessID")]
    public long? ProcessId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActionLastDateTime { get; set; }

    public bool? OnBehalf { get; set; }

    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDateTime { get; set; }

    [InverseProperty("Request")]
    public virtual ICollection<FleetManagement> FleetManagements { get; set; } = new List<FleetManagement>();

    [InverseProperty("Request")]
    public virtual ICollection<GeneralActionsHistory> GeneralActionsHistories { get; set; } = new List<GeneralActionsHistory>();

    [InverseProperty("Request")]
    public virtual ICollection<GeneralEmployee> GeneralEmployees { get; set; } = new List<GeneralEmployee>();

    [InverseProperty("Request")]
    public virtual ICollection<InsuranceInfo> InsuranceInfos { get; set; } = new List<InsuranceInfo>();

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("GeneralRequestsServices")]
    public virtual GeneralServiceType? ServiceType { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("GeneralRequestsServices")]
    public virtual GenralStatus? Status { get; set; }

    [ForeignKey("StepId")]
    [InverseProperty("GeneralRequestsServices")]
    public virtual GeneralStep? Step { get; set; }
}
