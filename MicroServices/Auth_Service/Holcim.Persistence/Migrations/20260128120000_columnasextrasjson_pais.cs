using Holcim.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    [DbContext(typeof(DataBaseService))]
    [Migration("20260128120000_columnasextrasjson_pais")]
    public partial class columnasextrasjson_pais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColumnasExtrasJson",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnasExtrasJson",
                table: "Pais");
        }
    }
}
