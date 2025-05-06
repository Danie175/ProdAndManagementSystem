using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

public partial class MaterialInventoryDatum
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TxDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TxTime { get; set; }

    [StringLength(100)]
    public string? Agg1Name { get; set; }

    [StringLength(100)]
    public string? Agg2Name { get; set; }

    [StringLength(100)]
    public string? Agg3Name { get; set; }

    [StringLength(100)]
    public string? Agg4Name { get; set; }

    [StringLength(100)]
    public string? Cement1Name { get; set; }

    [StringLength(100)]
    public string? Cemen2Name { get; set; }

    [StringLength(100)]
    public string? Cemen3Name { get; set; }

    [StringLength(100)]
    public string? Cemen4Name { get; set; }

    [StringLength(100)]
    public string? Water1Name { get; set; }

    [StringLength(100)]
    public string? Water2Name { get; set; }

    [StringLength(100)]
    public string? Admix1Name { get; set; }

    [StringLength(100)]
    public string? Admix2Name { get; set; }

    [StringLength(100)]
    public string? Admix3Name { get; set; }

    [StringLength(100)]
    public string? Admix4Name { get; set; }

    public double? Agg1Receipt { get; set; }

    public double? Agg2Receipt { get; set; }

    public double? Agg3Receipt { get; set; }

    public double? Agg4Receipt { get; set; }

    public double? Cement1Receipt { get; set; }

    public double? Cemen2Receipt { get; set; }

    public double? Cemen3Receipt { get; set; }

    public double? Cemen4Receipt { get; set; }

    public double? Water1Receipt { get; set; }

    public double? Water2Receipt { get; set; }

    public double? Admix1Receipt { get; set; }

    public double? Admix2Receipt { get; set; }

    public double? Admix3Receipt { get; set; }

    public double? Admix4Receipt { get; set; }

    public double? Agg1Adjustment { get; set; }

    public double? Agg2Adjustment { get; set; }

    public double? Agg3Adjustment { get; set; }

    public double? Agg4Adjustment { get; set; }

    public double? Cement1Adjustment { get; set; }

    public double? Cemen2Adjustment { get; set; }

    public double? Cemen3Adjustment { get; set; }

    public double? Cemen4Adjustment { get; set; }

    public double? Water1Adjustment { get; set; }

    public double? Water2Adjustment { get; set; }

    public double? Admix1Adjustment { get; set; }

    public double? Admix2Adjustment { get; set; }

    public double? Admix3Adjustment { get; set; }

    public double? Admix4Adjustment { get; set; }

    [Column("SupplierID")]
    public double? SupplierId { get; set; }

    public double? InvoiceNumber { get; set; }

    [StringLength(50)]
    public string? DeliveryChalanNo { get; set; }

    [StringLength(50)]
    public string? TruckNumber { get; set; }

    [StringLength(100)]
    public string? DriverName { get; set; }

    public double? Rate { get; set; }

    public double? TotalCost { get; set; }

    [StringLength(255)]
    public string? Remark { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }
}
