using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    public partial class columnasextrasjson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColumnasExtrasJson",
                table: "Moneda",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnasExtrasJson",
                table: "Pscs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnasExtrasJson",
                table: "UnidadMedida",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnasExtrasJson",
                table: "GrupoPsc",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnasExtrasJson",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "ColumnasExtrasJson",
                table: "Pscs");

            migrationBuilder.DropColumn(
                name: "ColumnasExtrasJson",
                table: "UnidadMedida");

            migrationBuilder.DropColumn(
                name: "ColumnasExtrasJson",
                table: "GrupoPsc");
        }
    }
}
