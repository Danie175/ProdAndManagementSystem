using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("CUSTOMER")]
[Index("Customername", Name = "IX_CUSTOMER_NAME")]
[Index("Customerid", Name = "UQ__CUSTOMER__61DBD789FDE27297", IsUnique = true)]
public partial class Customer
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("CUSTOMERID")]
    public int Customerid { get; set; }

    [Column("CUSTOMERNAME")]
    [StringLength(100)]
    public string Customername { get; set; } = null!;

    [Column("CUSTOMERADD")]
    [StringLength(255)]
    public string? Customeradd { get; set; }

    [Column("CUSTOMERNUMBER")]
    [StringLength(50)]
    public string? Customernumber { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Ordertable> Ordertables { get; set; } = new List<Ordertable>();
}
