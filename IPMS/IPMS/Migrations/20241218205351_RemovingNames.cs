using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPMS.Migrations
{
    /// <inheritdoc />
    public partial class RemovingNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedMaterials",
                table: "ProductManagement");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductManagement");

            migrationBuilder.RenameTable(
                name: "BillOfMaterials",
                newName: "BomManagement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "BomManagement",
                newName: "BillOfMaterials");

            migrationBuilder.AddColumn<string>(
                name: "LinkedMaterials",
                table: "ProductManagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductManagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
