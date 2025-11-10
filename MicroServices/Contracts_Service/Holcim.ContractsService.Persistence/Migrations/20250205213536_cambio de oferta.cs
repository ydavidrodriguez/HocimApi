using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cambiodeoferta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Monto",
                table: "Contrato",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Monto",
                table: "Contrato",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
