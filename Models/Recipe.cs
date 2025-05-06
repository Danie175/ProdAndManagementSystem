 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("Recipe")]
[Index("Recipename", Name = "IX_RECIPE_NAME")]
[Index("Id", Name = "UQ__RECIPE__3214EC2663A6E0D6", IsUnique = true)]
public partial class Recipe
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("ID")]
    public int Id { get; set; }

    [Column("RECIPENAME")]
    [StringLength(100)]
    public string Recipename { get; set; } = null!;

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

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }

    [InverseProperty("Recipe")]
    public virtual ICollection<Cycledatum> Cycledata { get; set; } = new List<Cycledatum>();

    [InverseProperty("Recipe")]
    public virtual ICollection<Ordertable> Ordertables { get; set; } = new List<Ordertable>();
}
