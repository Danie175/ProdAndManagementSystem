using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("ORDERTABLE")]
[Index("Orderid", Name = "IX_ORDER_ID")]
[Index("Orderid", Name = "UQ__ORDERTAB__491E4193020B7B61", IsUnique = true)]
public partial class Ordertable
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("ORDERID")]
    public double Orderid { get; set; }

    [Column("ORDERQUANTITY")]
    public double? Orderquantity { get; set; }

    [Column("CUSTOMERID")]
    public int? Customerid { get; set; }

    [Column("SITEID")]
    public int? Siteid { get; set; }

    [Column("CUSTOMERNAME")]
    [StringLength(100)]
    public string? Customername { get; set; }

    [Column("SITENAME")]
    [StringLength(100)]
    public string? Sitename { get; set; }

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

    [Column("CEMENT4NAME")]
    [StringLength(100)]
    public string? Cement4name { get; set; }

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

    [Column("ADMIXNEWNAME")]
    [StringLength(100)]
    public string? Admixnewname { get; set; }

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

    [Column("CEMENT4STP")]
    public double? Cement4stp { get; set; }

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

    [Column("ADMIXNEWSTP")]
    public double? Admixnewstp { get; set; }

    [Column("COMPLETEDQUANTITY")]
    public double? Completedquantity { get; set; }

    [Column("PENDINGQUANTITY")]
    public double? Pendingquantity { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Batchtable> Batchtables { get; set; } = new List<Batchtable>();

    [ForeignKey("Customerid")]
    [InverseProperty("Ordertables")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Cycledatum> Cycledata { get; set; } = new List<Cycledatum>();

    [ForeignKey("Recipeid")]
    [InverseProperty("Ordertables")]
    public virtual Recipe? Recipe { get; set; }

    [ForeignKey("Siteid")]
    [InverseProperty("Ordertables")]
    public virtual Site? Site { get; set; }
}
