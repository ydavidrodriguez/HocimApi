using Holcim.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    [DbContext(typeof(DataBaseService))]
    [Migration("20260125123000_rfx_sitio_direccion")]
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
