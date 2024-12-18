using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPMS.Migrations
{
    /// <inheritdoc />
    public partial class FixingProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedMaterials",
                table: "ProductManagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedMaterials",
                table: "ProductManagement");
        }
    }
}
