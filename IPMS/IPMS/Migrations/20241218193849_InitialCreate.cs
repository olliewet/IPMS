using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "BillOfMaterials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "BillOfMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
