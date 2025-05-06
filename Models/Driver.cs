using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("DRIVER")]
[Index("Drivername", Name = "IX_DRIVER_NAME")]
[Index("Driverid", Name = "UQ__DRIVER__5C38F30D294D6CDA", IsUnique = true)]
public partial class Driver
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("DRIVERID")]
    public int Driverid { get; set; }

    [Column("DRIVERNAME")]
    [StringLength(100)]
    public string Drivername { get; set; } = null!;

    [Column("DRIVERNUMBER")]
    [StringLength(50)]
    public string? Drivernumber { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }
}
