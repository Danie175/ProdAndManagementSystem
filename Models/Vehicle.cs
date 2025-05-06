using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("Vehicle")]
[Index("Vehiclenumber", Name = "IX_VEHICLE_NUMBER")]
[Index("Vehicleid", Name = "UQ__VEHICLE__D4BD3E72156E0801", IsUnique = true)]
public partial class Vehicle
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("VEHICLEID")]
    public int Vehicleid { get; set; }

    [Column("VEHICLENUMBER")]
    [StringLength(50)]
    public string Vehiclenumber { get; set; } = null!;

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }
}
