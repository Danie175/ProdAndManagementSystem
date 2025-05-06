using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("BATCHTABLE")]
[Index("Batchnumber", Name = "IX_BATCH_NUMBER")]
[Index("Batchnumber", Name = "UQ__BATCHTAB__B56DDD5DC09213AD", IsUnique = true)]
public partial class Batchtable
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("BATCHNUMBER")]
    public double Batchnumber { get; set; }

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
    [StringLength(50)]
    public string? Percyclequantity { get; set; }

    [Column("CYCLEDATE")]
    [StringLength(50)]
    public string? Cycledate { get; set; }

    [Column("RECIPENAME")]
    [StringLength(100)]
    public string? Recipename { get; set; }

    [Column("MOISTUREENABLE")]
    public double? Moistureenable { get; set; }

    [Column("ORDERID")]
    public double? Orderid { get; set; }

    [Column("ORDERQUANTITY")]
    public double? Orderquantity { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [InverseProperty("BatchnumberNavigation")]
    public virtual ICollection<Cycledatum> Cycledata { get; set; } = new List<Cycledatum>();

    [ForeignKey("Orderid")]
    [InverseProperty("Batchtables")]
    public virtual Ordertable? Order { get; set; }
}
