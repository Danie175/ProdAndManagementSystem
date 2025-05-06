using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prod_ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSitenameFromCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMERID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CUSTOMERADD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CUSTOMERNUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SITENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CUSTOMER__A091E37AF17AA5C1", x => x.SRNO);
                    table.UniqueConstraint("AK_CUSTOMER_CUSTOMERID", x => x.CUSTOMERID);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DRIVERID = table.Column<int>(type: "int", nullable: false),
                    DRIVERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DRIVERNUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DRIVER__A091E37A33A84A48", x => x.SRNO);
                });

            migrationBuilder.CreateTable(
                name: "MaterialInventoryData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TxTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Agg1Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agg2Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agg3Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agg4Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cement1Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cemen2Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cemen3Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cemen4Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Water1Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Water2Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Admix1Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Admix2Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Admix3Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Admix4Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agg1Receipt = table.Column<double>(type: "float", nullable: true),
                    Agg2Receipt = table.Column<double>(type: "float", nullable: true),
                    Agg3Receipt = table.Column<double>(type: "float", nullable: true),
                    Agg4Receipt = table.Column<double>(type: "float", nullable: true),
                    Cement1Receipt = table.Column<double>(type: "float", nullable: true),
                    Cemen2Receipt = table.Column<double>(type: "float", nullable: true),
                    Cemen3Receipt = table.Column<double>(type: "float", nullable: true),
                    Cemen4Receipt = table.Column<double>(type: "float", nullable: true),
                    Water1Receipt = table.Column<double>(type: "float", nullable: true),
                    Water2Receipt = table.Column<double>(type: "float", nullable: true),
                    Admix1Receipt = table.Column<double>(type: "float", nullable: true),
                    Admix2Receipt = table.Column<double>(type: "float", nullable: true),
                    Admix3Receipt = table.Column<double>(type: "float", nullable: true),
                    Admix4Receipt = table.Column<double>(type: "float", nullable: true),
                    Agg1Adjustment = table.Column<double>(type: "float", nullable: true),
                    Agg2Adjustment = table.Column<double>(type: "float", nullable: true),
                    Agg3Adjustment = table.Column<double>(type: "float", nullable: true),
                    Agg4Adjustment = table.Column<double>(type: "float", nullable: true),
                    Cement1Adjustment = table.Column<double>(type: "float", nullable: true),
                    Cemen2Adjustment = table.Column<double>(type: "float", nullable: true),
                    Cemen3Adjustment = table.Column<double>(type: "float", nullable: true),
                    Cemen4Adjustment = table.Column<double>(type: "float", nullable: true),
                    Water1Adjustment = table.Column<double>(type: "float", nullable: true),
                    Water2Adjustment = table.Column<double>(type: "float", nullable: true),
                    Admix1Adjustment = table.Column<double>(type: "float", nullable: true),
                    Admix2Adjustment = table.Column<double>(type: "float", nullable: true),
                    Admix3Adjustment = table.Column<double>(type: "float", nullable: true),
                    Admix4Adjustment = table.Column<double>(type: "float", nullable: true),
                    SupplierID = table.Column<double>(type: "float", nullable: true),
                    InvoiceNumber = table.Column<double>(type: "float", nullable: true),
                    DeliveryChalanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TruckNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__3214EC279B874C12", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialMaster",
                columns: table => new
                {
                    SrNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: true, defaultValue: 2),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__C3A4D3AC4B56C676", x => x.SrNo);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    RECIPENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AGG1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG4NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT4NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WATER1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WATER2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIXNEWNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG1STP = table.Column<double>(type: "float", nullable: true),
                    AGG2STP = table.Column<double>(type: "float", nullable: true),
                    AGG3STP = table.Column<double>(type: "float", nullable: true),
                    AGG4STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT1STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT2STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT3STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT4STP = table.Column<double>(type: "float", nullable: true),
                    WATER1STP = table.Column<double>(type: "float", nullable: true),
                    WATER2STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX1STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX2STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX3STP = table.Column<double>(type: "float", nullable: true),
                    ADMIXNEWSTP = table.Column<double>(type: "float", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RECIPE__A091E37A4A6963AF", x => x.SRNO);
                    table.UniqueConstraint("AK_Recipe_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SITEID = table.Column<int>(type: "int", nullable: false),
                    SITENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SITEADD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SITENUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SITE__A091E37A0B0E37E6", x => x.SRNO);
                    table.UniqueConstraint("AK_Site_SITEID", x => x.SITEID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierMaster",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<double>(type: "float", nullable: true),
                    GSTNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supplier__4BE66694950A2EAE", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Table1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Table1__3214EC2778DAD650", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VEHICLEID = table.Column<int>(type: "int", nullable: false),
                    VEHICLENUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VEHICLE__A091E37A8A81D148", x => x.SRNO);
                });

            migrationBuilder.CreateTable(
                name: "ORDERTABLE",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDERID = table.Column<double>(type: "float", nullable: false),
                    ORDERQUANTITY = table.Column<double>(type: "float", nullable: true),
                    CUSTOMERID = table.Column<int>(type: "int", nullable: true),
                    SITEID = table.Column<int>(type: "int", nullable: true),
                    CUSTOMERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SITENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RECIPEID = table.Column<int>(type: "int", nullable: true),
                    RECIPENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG4NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT4NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WATER1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WATER2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIXNEWNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG1STP = table.Column<double>(type: "float", nullable: true),
                    AGG2STP = table.Column<double>(type: "float", nullable: true),
                    AGG3STP = table.Column<double>(type: "float", nullable: true),
                    AGG4STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT1STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT2STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT3STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT4STP = table.Column<double>(type: "float", nullable: true),
                    WATER1STP = table.Column<double>(type: "float", nullable: true),
                    WATER2STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX1STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX2STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX3STP = table.Column<double>(type: "float", nullable: true),
                    ADMIXNEWSTP = table.Column<double>(type: "float", nullable: true),
                    COMPLETEDQUANTITY = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    PENDINGQUANTITY = table.Column<double>(type: "float", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ORDERTAB__A091E37A6B59AAEE", x => x.SRNO);
                    table.UniqueConstraint("AK_ORDERTABLE_ORDERID", x => x.ORDERID);
                    table.ForeignKey(
                        name: "FK_ORDERTABLE_CUSTOMER",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMERID");
                    table.ForeignKey(
                        name: "FK_ORDERTABLE_RECIPE",
                        column: x => x.RECIPEID,
                        principalTable: "Recipe",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ORDERTABLE_SITE",
                        column: x => x.SITEID,
                        principalTable: "Site",
                        principalColumn: "SITEID");
                });

            migrationBuilder.CreateTable(
                name: "MaterialInventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TxTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeliveryChalanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TruckNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UPDATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__3214EC272C2AE1DA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialInventory_SupplierMaster",
                        column: x => x.SupplierID,
                        principalTable: "SupplierMaster",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "BATCHTABLE",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BATCHNUMBER = table.Column<double>(type: "float", nullable: false),
                    BATCHQUANTITY = table.Column<double>(type: "float", nullable: true),
                    CUSTOMERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SITENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DRIVERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VEHICLENUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PERCYCLEQUANTITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CYCLEDATE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RECIPENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MOISTUREENABLE = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    ORDERID = table.Column<double>(type: "float", nullable: true),
                    ORDERQUANTITY = table.Column<double>(type: "float", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BATCHTAB__A091E37A7DB06628", x => x.SRNO);
                    table.UniqueConstraint("AK_BATCHTABLE_BATCHNUMBER", x => x.BATCHNUMBER);
                    table.ForeignKey(
                        name: "FK_BATCHTABLE_ORDERTABLE",
                        column: x => x.ORDERID,
                        principalTable: "ORDERTABLE",
                        principalColumn: "ORDERID");
                });

            migrationBuilder.CreateTable(
                name: "CYCLEDATA",
                columns: table => new
                {
                    SRNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BATCHQUANTITY = table.Column<double>(type: "float", nullable: true),
                    CUSTOMERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SITENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DRIVERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VEHICLENUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PERCYCLEQUANTITY = table.Column<double>(type: "float", nullable: true),
                    BATCHNUMBER = table.Column<double>(type: "float", nullable: true),
                    CYCLEDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CYCLETIME = table.Column<DateTime>(type: "datetime", nullable: true),
                    CYCLENUMBER = table.Column<int>(type: "int", nullable: true),
                    SHIFTNUMBER = table.Column<int>(name: "SHIFT NUMBER", type: "int", nullable: true),
                    RECIPEID = table.Column<int>(type: "int", nullable: true),
                    RECIPENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG4NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WATER1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WATER2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX1NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX2NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIX3NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGG1TRG = table.Column<double>(type: "float", nullable: true),
                    AGG2TRG = table.Column<double>(type: "float", nullable: true),
                    AGG3TRG = table.Column<double>(type: "float", nullable: true),
                    AGG4TRG = table.Column<double>(type: "float", nullable: true),
                    CEMENT1TRG = table.Column<double>(type: "float", nullable: true),
                    CEMENT2TRG = table.Column<double>(type: "float", nullable: true),
                    CEMENT3TRG = table.Column<double>(type: "float", nullable: true),
                    WATER1TRG = table.Column<double>(type: "float", nullable: true),
                    WATER2TRG = table.Column<double>(type: "float", nullable: true),
                    ADMIX1TRG = table.Column<double>(type: "float", nullable: true),
                    ADMIX2TRG = table.Column<double>(type: "float", nullable: true),
                    ADMIX3TRG = table.Column<double>(type: "float", nullable: true),
                    TARGETTOTAL = table.Column<double>(type: "float", nullable: true),
                    AGG1STP = table.Column<double>(type: "float", nullable: true),
                    AGG2STP = table.Column<double>(type: "float", nullable: true),
                    AGG3STP = table.Column<double>(type: "float", nullable: true),
                    AGG4STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT1STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT2STP = table.Column<double>(type: "float", nullable: true),
                    CEMENT3STP = table.Column<double>(type: "float", nullable: true),
                    WATER1STP = table.Column<double>(type: "float", nullable: true),
                    WATER2STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX1STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX2STP = table.Column<double>(type: "float", nullable: true),
                    ADMIX3STP = table.Column<double>(type: "float", nullable: true),
                    SETTOTAL = table.Column<double>(type: "float", nullable: true),
                    AGG1ACHI = table.Column<double>(type: "float", nullable: true),
                    AGG2ACHI = table.Column<double>(type: "float", nullable: true),
                    AGG3ACHI = table.Column<double>(type: "float", nullable: true),
                    AGG4ACHI = table.Column<double>(type: "float", nullable: true),
                    CEMENT1ACHI = table.Column<double>(type: "float", nullable: true),
                    CEMENT2ACHI = table.Column<double>(type: "float", nullable: true),
                    CEMENT3ACHI = table.Column<double>(type: "float", nullable: true),
                    WATER1ACHI = table.Column<double>(type: "float", nullable: true),
                    WATER2ACHI = table.Column<double>(type: "float", nullable: true),
                    ADMIX1ACHI = table.Column<double>(type: "float", nullable: true),
                    ADMIX2ACHI = table.Column<double>(type: "float", nullable: true),
                    ADMIX3ACHI = table.Column<double>(type: "float", nullable: true),
                    CORRECTEDWATER = table.Column<double>(type: "float", nullable: true),
                    MOISTURECONTENT = table.Column<double>(type: "float", nullable: true),
                    CORRECTEDAGGREGATE = table.Column<double>(type: "float", nullable: true),
                    TOTAL = table.Column<double>(type: "float", nullable: true),
                    CEMENT4NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADMIXNEWNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEMENT4TRG = table.Column<double>(type: "float", nullable: true),
                    ADMIXNEWTRG = table.Column<double>(type: "float", nullable: true),
                    CEMENT4STP = table.Column<double>(type: "float", nullable: true),
                    ADMIXNEWSTP = table.Column<double>(type: "float", nullable: true),
                    CEMENT4ACHI = table.Column<double>(type: "float", nullable: true),
                    ADMIXNEWACHI = table.Column<double>(type: "float", nullable: true),
                    MOISTUREENABLE = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    ORDERID = table.Column<double>(type: "float", nullable: true),
                    ORDERQUANTITY = table.Column<double>(type: "float", nullable: true),
                    CUSTOMERADD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SITEADD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MOISTURECONTENTAGG1 = table.Column<double>(type: "float", nullable: true),
                    MOISTURECONTENTAGG3 = table.Column<double>(type: "float", nullable: true),
                    MOISTURECONTENTAGG4 = table.Column<double>(type: "float", nullable: true),
                    ABSORPTIONAGG1 = table.Column<double>(type: "float", nullable: true),
                    ABSORPTIONAGG2 = table.Column<double>(type: "float", nullable: true),
                    ABSORPTIONAGG3 = table.Column<double>(type: "float", nullable: true),
                    ABSORPTIONAGG4 = table.Column<double>(type: "float", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CYCLEDAT__A091E37A18889775", x => x.SRNO);
                    table.ForeignKey(
                        name: "FK_CYCLEDATA_BATCHTABLE",
                        column: x => x.BATCHNUMBER,
                        principalTable: "BATCHTABLE",
                        principalColumn: "BATCHNUMBER");
                    table.ForeignKey(
                        name: "FK_CYCLEDATA_ORDERTABLE",
                        column: x => x.ORDERID,
                        principalTable: "ORDERTABLE",
                        principalColumn: "ORDERID");
                    table.ForeignKey(
                        name: "FK_CYCLEDATA_RECIPE",
                        column: x => x.RECIPEID,
                        principalTable: "Recipe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BATCH_NUMBER",
                table: "BATCHTABLE",
                column: "BATCHNUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_BATCHTABLE_ORDERID",
                table: "BATCHTABLE",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "UQ__BATCHTAB__B56DDD5DC09213AD",
                table: "BATCHTABLE",
                column: "BATCHNUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_NAME",
                table: "CUSTOMER",
                column: "CUSTOMERNAME");

            migrationBuilder.CreateIndex(
                name: "UQ__CUSTOMER__61DBD789FDE27297",
                table: "CUSTOMER",
                column: "CUSTOMERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CYCLEDATA_BATCHNUMBER",
                table: "CYCLEDATA",
                column: "BATCHNUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_CYCLEDATA_ORDERID",
                table: "CYCLEDATA",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_CYCLEDATA_RECIPEID",
                table: "CYCLEDATA",
                column: "RECIPEID");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_NAME",
                table: "DRIVER",
                column: "DRIVERNAME");

            migrationBuilder.CreateIndex(
                name: "UQ__DRIVER__5C38F30D294D6CDA",
                table: "DRIVER",
                column: "DRIVERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialInventory_SupplierID",
                table: "MaterialInventory",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ID",
                table: "ORDERTABLE",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERTABLE_CUSTOMERID",
                table: "ORDERTABLE",
                column: "CUSTOMERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERTABLE_RECIPEID",
                table: "ORDERTABLE",
                column: "RECIPEID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERTABLE_SITEID",
                table: "ORDERTABLE",
                column: "SITEID");

            migrationBuilder.CreateIndex(
                name: "UQ__ORDERTAB__491E4193020B7B61",
                table: "ORDERTABLE",
                column: "ORDERID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_NAME",
                table: "Recipe",
                column: "RECIPENAME");

            migrationBuilder.CreateIndex(
                name: "UQ__RECIPE__3214EC2663A6E0D6",
                table: "Recipe",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SITE_NAME",
                table: "Site",
                column: "SITENAME");

            migrationBuilder.CreateIndex(
                name: "UQ__SITE__A496D1E2614BA488",
                table: "Site",
                column: "SITEID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_NUMBER",
                table: "Vehicle",
                column: "VEHICLENUMBER");

            migrationBuilder.CreateIndex(
                name: "UQ__VEHICLE__D4BD3E72156E0801",
                table: "Vehicle",
                column: "VEHICLEID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CYCLEDATA");

            migrationBuilder.DropTable(
                name: "DRIVER");

            migrationBuilder.DropTable(
                name: "MaterialInventory");

            migrationBuilder.DropTable(
                name: "MaterialInventoryData");

            migrationBuilder.DropTable(
                name: "MaterialMaster");

            migrationBuilder.DropTable(
                name: "Table1");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "BATCHTABLE");

            migrationBuilder.DropTable(
                name: "SupplierMaster");

            migrationBuilder.DropTable(
                name: "ORDERTABLE");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
