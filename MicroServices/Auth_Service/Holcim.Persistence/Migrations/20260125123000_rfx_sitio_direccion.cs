using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    public partial class rfx_sitio_direccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sitio",
                table: "Rfx",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionEntrega",
                table: "Rfx",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sitio",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "DireccionEntrega",
                table: "Rfx");
        }
    }
}
