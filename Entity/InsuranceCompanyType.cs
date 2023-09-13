using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity;

[Table("InsuranceCompanyType")]
public partial class InsuranceCompanyType : BaseGet
{
   

    [StringLength(200)]
    public string? NameAr { get; set; }

    [StringLength(200)]
    public string? NameEn { get; set; }

    [Column("RequestID")]
    public int? RequestId { get; set; }

    [InverseProperty("InsuranceCompanyType")]
    public virtual ICollection<InsuranceInfo> InsuranceInfos { get; set; } = new List<InsuranceInfo>();
}
