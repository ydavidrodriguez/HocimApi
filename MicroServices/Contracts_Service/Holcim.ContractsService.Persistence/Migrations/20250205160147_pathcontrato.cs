using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class pathcontrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Contrato",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Contrato");
        }
    }
}
