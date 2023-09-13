using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("fleetManagement")]
public partial class FleetManagement: BaseGet
{


    [StringLength(30)]
    public string? CarNumber { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [Column("RequestID")]
    public int? RequestId { get; set; }

    [StringLength(100)]
    public string? Long { get; set; }

    [StringLength(100)]
    public string? Lat { get; set; }

    public string? Remark { get; set; }

    [Column("FleetManagementTypeID")]
    public int? FleetManagementTypeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("FleetManagements")]
    public virtual GeneralEmployee? Employee { get; set; }

    [ForeignKey("FleetManagementTypeId")]
    [InverseProperty("FleetManagements")]
    public virtual GeneralLookup? FleetManagementType { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("FleetManagements")]
    public virtual GeneralRequestsService? Request { get; set; }
}
