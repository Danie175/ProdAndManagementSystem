using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("MaterialInventory")]
public partial class MaterialInventory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TxDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TxTime { get; set; }

    [StringLength(50)]
    public string? TransactionType { get; set; }

    [StringLength(50)]
    public string? Category { get; set; }

    [StringLength(100)]
    public string? MaterialName { get; set; }

    public double? Quantity { get; set; }

    [Column("SupplierID")]
    public int? SupplierId { get; set; }

    [StringLength(50)]
    public string? InvoiceNumber { get; set; }

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

    [ForeignKey("SupplierId")]
    [InverseProperty("MaterialInventories")]
    public virtual SupplierMaster? Supplier { get; set; }
}
