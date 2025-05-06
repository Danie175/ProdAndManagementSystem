using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Models;

[Table("Table1")]
public partial class Table1
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }
}
