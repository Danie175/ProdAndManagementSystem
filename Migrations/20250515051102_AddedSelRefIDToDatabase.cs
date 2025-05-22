using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prod_ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedSelRefIDToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serial Ref ID",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial Ref ID",
                table: "Recipe");
        }
    }
}
