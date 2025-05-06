using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProdAndManagementSystem.Models;

namespace ProdAndManagementSystem.Data;

public partial class JustDbContext : DbContext
{
    public JustDbContext()
    {
    }

    public JustDbContext(DbContextOptions<JustDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Batchtable> Batchtables { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Cycledatum> Cycledata { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<MaterialInventory> MaterialInventories { get; set; }

    public virtual DbSet<MaterialInventoryDatum> MaterialInventoryData { get; set; }

    public virtual DbSet<MaterialMaster> MaterialMasters { get; set; }

    public virtual DbSet<Ordertable> Ordertables { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<SupplierMaster> SupplierMasters { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\VILLAGERBANK;Database=DiamondMine;User Id=sa;Password=Daniel@11;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Batchtable>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__BATCHTAB__A091E37A7DB06628");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Moistureenable).HasDefaultValue(0.0);

            entity.HasOne(d => d.Order).WithMany(p => p.Batchtables)
                .HasPrincipalKey(p => p.Orderid)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_BATCHTABLE_ORDERTABLE");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__CUSTOMER__A091E37AF17AA5C1");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Cycledatum>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__CYCLEDAT__A091E37A18889775");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Moistureenable).HasDefaultValue(0.0);

            entity.HasOne(d => d.BatchnumberNavigation).WithMany(p => p.Cycledata)
                .HasPrincipalKey(p => p.Batchnumber)
                .HasForeignKey(d => d.Batchnumber)
                .HasConstraintName("FK_CYCLEDATA_BATCHTABLE");

            entity.HasOne(d => d.Order).WithMany(p => p.Cycledata)
                .HasPrincipalKey(p => p.Orderid)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_CYCLEDATA_ORDERTABLE");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Cycledata)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("FK_CYCLEDATA_RECIPE");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__DRIVER__A091E37A33A84A48");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MaterialInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3214EC272C2AE1DA");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Supplier).WithMany(p => p.MaterialInventories).HasConstraintName("FK_MaterialInventory_SupplierMaster");
        });

        modelBuilder.Entity<MaterialInventoryDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Material__3214EC279B874C12");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MaterialMaster>(entity =>
        {
            entity.HasKey(e => e.SrNo).HasName("PK__Material__C3A4D3AC4B56C676");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DecimalPlaces).HasDefaultValue(2);
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Ordertable>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__ORDERTAB__A091E37A6B59AAEE");

            entity.Property(e => e.Completedquantity).HasDefaultValue(0.0);
            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ordertables)
                .HasPrincipalKey(p => p.Customerid)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FK_ORDERTABLE_CUSTOMER");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Ordertables)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("FK_ORDERTABLE_RECIPE");

            entity.HasOne(d => d.Site).WithMany(p => p.Ordertables)
                .HasPrincipalKey(p => p.Siteid)
                .HasForeignKey(d => d.Siteid)
                .HasConstraintName("FK_ORDERTABLE_SITE");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__RECIPE__A091E37A4A6963AF");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__SITE__A091E37A0B0E37E6");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SupplierMaster>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694950A2EAE");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table1__3214EC2778DAD650");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Srno).HasName("PK__VEHICLE__A091E37A8A81D148");

            entity.Property(e => e.Createdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Updatedate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
