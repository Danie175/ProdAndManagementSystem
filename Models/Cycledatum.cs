using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("CYCLEDATA")]
public partial class Cycledatum
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("BATCHQUANTITY")]
    public double? Batchquantity { get; set; }

    [Column("CUSTOMERNAME")]
    [StringLength(100)]
    public string? Customername { get; set; }

    [Column("SITENAME")]
    [StringLength(100)]
    public string? Sitename { get; set; }

    [Column("DRIVERNAME")]
    [StringLength(100)]
    public string? Drivername { get; set; }

    [Column("VEHICLENUMBER")]
    [StringLength(50)]
    public string? Vehiclenumber { get; set; }

    [Column("PERCYCLEQUANTITY")]
    public double? Percyclequantity { get; set; }

    [Column("BATCHNUMBER")]
    public double? Batchnumber { get; set; }

    [Column("CYCLEDATE", TypeName = "datetime")]
    public DateTime? Cycledate { get; set; }

    [Column("CYCLETIME", TypeName = "datetime")]
    public DateTime? Cycletime { get; set; }

    [Column("CYCLENUMBER")]
    public int? Cyclenumber { get; set; }

    [Column("SHIFT NUMBER")]
    public int? ShiftNumber { get; set; }

    [Column("RECIPEID")]
    public string? Recipeid { get; set; }

    [Column("RECIPENAME")]
    [StringLength(100)]
    public string? Recipename { get; set; }

    [Column("AGG1NAME")]
    [StringLength(100)]
    public string? Agg1name { get; set; }

    [Column("AGG2NAME")]
    [StringLength(100)]
    public string? Agg2name { get; set; }

    [Column("AGG3NAME")]
    [StringLength(100)]
    public string? Agg3name { get; set; }

    [Column("AGG4NAME")]
    [StringLength(100)]
    public string? Agg4name { get; set; }

    [Column("CEMENT1NAME")]
    [StringLength(100)]
    public string? Cement1name { get; set; }

    [Column("CEMENT2NAME")]
    [StringLength(100)]
    public string? Cement2name { get; set; }

    [Column("CEMENT3NAME")]
    [StringLength(100)]
    public string? Cement3name { get; set; }

    [Column("WATER1NAME")]
    [StringLength(100)]
    public string? Water1name { get; set; }

    [Column("WATER2NAME")]
    [StringLength(100)]
    public string? Water2name { get; set; }

    [Column("ADMIX1NAME")]
    [StringLength(100)]
    public string? Admix1name { get; set; }

    [Column("ADMIX2NAME")]
    [StringLength(100)]
    public string? Admix2name { get; set; }

    [Column("ADMIX3NAME")]
    [StringLength(100)]
    public string? Admix3name { get; set; }

    [Column("AGG1TRG")]
    public double? Agg1trg { get; set; }

    [Column("AGG2TRG")]
    public double? Agg2trg { get; set; }

    [Column("AGG3TRG")]
    public double? Agg3trg { get; set; }

    [Column("AGG4TRG")]
    public double? Agg4trg { get; set; }

    [Column("CEMENT1TRG")]
    public double? Cement1trg { get; set; }

    [Column("CEMENT2TRG")]
    public double? Cement2trg { get; set; }

    [Column("CEMENT3TRG")]
    public double? Cement3trg { get; set; }

    [Column("WATER1TRG")]
    public double? Water1trg { get; set; }

    [Column("WATER2TRG")]
    public double? Water2trg { get; set; }

    [Column("ADMIX1TRG")]
    public double? Admix1trg { get; set; }

    [Column("ADMIX2TRG")]
    public double? Admix2trg { get; set; }

    [Column("ADMIX3TRG")]
    public double? Admix3trg { get; set; }

    [Column("TARGETTOTAL")]
    public double? Targettotal { get; set; }

    [Column("AGG1STP")]
    public double? Agg1stp { get; set; }

    [Column("AGG2STP")]
    public double? Agg2stp { get; set; }

    [Column("AGG3STP")]
    public double? Agg3stp { get; set; }

    [Column("AGG4STP")]
    public double? Agg4stp { get; set; }

    [Column("CEMENT1STP")]
    public double? Cement1stp { get; set; }

    [Column("CEMENT2STP")]
    public double? Cement2stp { get; set; }

    [Column("CEMENT3STP")]
    public double? Cement3stp { get; set; }

    [Column("WATER1STP")]
    public double? Water1stp { get; set; }

    [Column("WATER2STP")]
    public double? Water2stp { get; set; }

    [Column("ADMIX1STP")]
    public double? Admix1stp { get; set; }

    [Column("ADMIX2STP")]
    public double? Admix2stp { get; set; }

    [Column("ADMIX3STP")]
    public double? Admix3stp { get; set; }

    [Column("SETTOTAL")]
    public double? Settotal { get; set; }

    [Column("AGG1ACHI")]
    public double? Agg1achi { get; set; }

    [Column("AGG2ACHI")]
    public double? Agg2achi { get; set; }

    [Column("AGG3ACHI")]
    public double? Agg3achi { get; set; }

    [Column("AGG4ACHI")]
    public double? Agg4achi { get; set; }

    [Column("CEMENT1ACHI")]
    public double? Cement1achi { get; set; }

    [Column("CEMENT2ACHI")]
    public double? Cement2achi { get; set; }

    [Column("CEMENT3ACHI")]
    public double? Cement3achi { get; set; }

    [Column("WATER1ACHI")]
    public double? Water1achi { get; set; }

    [Column("WATER2ACHI")]
    public double? Water2achi { get; set; }

    [Column("ADMIX1ACHI")]
    public double? Admix1achi { get; set; }

    [Column("ADMIX2ACHI")]
    public double? Admix2achi { get; set; }

    [Column("ADMIX3ACHI")]
    public double? Admix3achi { get; set; }

    [Column("CORRECTEDWATER")]
    public double? Correctedwater { get; set; }

    [Column("MOISTURECONTENT")]
    public double? Moisturecontent { get; set; }

    [Column("CORRECTEDAGGREGATE")]
    public double? Correctedaggregate { get; set; }

    [Column("TOTAL")]
    public double? Total { get; set; }

    [Column("CEMENT4NAME")]
    [StringLength(100)]
    public string? Cement4name { get; set; }

    [Column("ADMIXNEWNAME")]
    [StringLength(100)]
    public string? Admixnewname { get; set; }

    [Column("CEMENT4TRG")]
    public double? Cement4trg { get; set; }

    [Column("ADMIXNEWTRG")]
    public double? Admixnewtrg { get; set; }

    [Column("CEMENT4STP")]
    public double? Cement4stp { get; set; }

    [Column("ADMIXNEWSTP")]
    public double? Admixnewstp { get; set; }

    [Column("CEMENT4ACHI")]
    public double? Cement4achi { get; set; }

    [Column("ADMIXNEWACHI")]
    public double? Admixnewachi { get; set; }

    [Column("MOISTUREENABLE")]
    public double? Moistureenable { get; set; }

    [Column("ORDERID")]
    public double? Orderid { get; set; }

    [Column("ORDERQUANTITY")]
    public double? Orderquantity { get; set; }

    [Column("CUSTOMERADD")]
    [StringLength(255)]
    public string? Customeradd { get; set; }

    [Column("SITEADD")]
    [StringLength(255)]
    public string? Siteadd { get; set; }

    [Column("MOISTURECONTENTAGG1")]
    public double? Moisturecontentagg1 { get; set; }

    [Column("MOISTURECONTENTAGG3")]
    public double? Moisturecontentagg3 { get; set; }

    [Column("MOISTURECONTENTAGG4")]
    public double? Moisturecontentagg4 { get; set; }

    [Column("ABSORPTIONAGG1")]
    public double? Absorptionagg1 { get; set; }

    [Column("ABSORPTIONAGG2")]
    public double? Absorptionagg2 { get; set; }

    [Column("ABSORPTIONAGG3")]
    public double? Absorptionagg3 { get; set; }

    [Column("ABSORPTIONAGG4")]
    public double? Absorptionagg4 { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [ForeignKey("Batchnumber")]
    [InverseProperty("Cycledata")]
    public virtual Batchtable? BatchnumberNavigation { get; set; }

    [ForeignKey("Orderid")]
    [InverseProperty("Cycledata")]
    public virtual Ordertable? Order { get; set; }

    [ForeignKey("Recipeid")]
    [InverseProperty("Cycledata")]
    public virtual Recipe? Recipe { get; set; }
}
