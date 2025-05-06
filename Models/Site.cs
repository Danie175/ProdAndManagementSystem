using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("Site")]
[Index("Sitename", Name = "IX_SITE_NAME")]
[Index("Siteid", Name = "UQ__SITE__A496D1E2614BA488", IsUnique = true)]
public partial class Site
{
    [Key]
    [Column("SRNO")]
    public int Srno { get; set; }

    [Column("SITEID")]
    public int Siteid { get; set; }

    [Column("SITENAME")]
    [StringLength(100)]
    public string Sitename { get; set; } = null!;

    [Column("SITEADD")]
    [StringLength(255)]
    public string? Siteadd { get; set; }

    [Column("SITENUMBER")]
    [StringLength(50)]
    public string? Sitenumber { get; set; }

    [Column("UPDATEDATE", TypeName = "datetime")]
    public DateTime? Updatedate { get; set; }

    [Column("CREATEDATE", TypeName = "datetime")]
    public DateTime? Createdate { get; set; }

    [InverseProperty("Site")]
    public virtual ICollection<Ordertable> Ordertables { get; set; } = new List<Ordertable>();
}
