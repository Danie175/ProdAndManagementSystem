using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("MaterialMaster")]
public partial class MaterialMaster
{
    [Key]
    public int SrNo { get; set; }

    [StringLength(50)]
    public string? MaterialCategory { get; set; }

    public string MaterialName { get; set; } = null!;

    public int? DecimalPlaces { get; set; }

    [StringLength(20)]
    public string? Unit { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }
}
