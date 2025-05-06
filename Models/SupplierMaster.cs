using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("SupplierMaster")] 
public partial class SupplierMaster
{
    [Key]
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [StringLength(100)]
    public string SupplierName { get; set; } = null!;

    [StringLength(255)]
    public string? AddressLine1 { get; set; }

    [StringLength(255)]
    public string? AddressLine2 { get; set; }

    public double? PhoneNumber { get; set; }

    [Column("GSTNumber")]
    [StringLength(50)]
    public string? Gstnumber { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<MaterialInventory> MaterialInventories { get; set; } = new List<MaterialInventory>();
}