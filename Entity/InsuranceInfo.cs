using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("InsuranceInfo")]
public partial class InsuranceInfo : BaseGet
{
   

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [Column("InsuranceTypeID")]
    public int? InsuranceTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsuranceStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsuranceEndDate { get; set; }

    public string? Remark { get; set; }

    [Column("InsuranceCompanyTypeID")]
    public int? InsuranceCompanyTypeId { get; set; }

    [Column("RequestID")]
    public int? RequestId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("InsuranceInfos")]
    public virtual GeneralEmployee? Employee { get; set; }

    [ForeignKey("InsuranceCompanyTypeId")]
    [InverseProperty("InsuranceInfos")]
    public virtual InsuranceCompanyType? InsuranceCompanyType { get; set; }

    [ForeignKey("InsuranceTypeId")]
    [InverseProperty("InsuranceInfos")]
    public virtual GeneralLookup? InsuranceType { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("InsuranceInfos")]
    public virtual GeneralRequestsService? Request { get; set; }
}
