using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ZonaHorario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZonaHorariaPaisId",
                table: "ZonaHorariaPais",
                newName: "IdZonaHorariaPais");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdZonaHorariaPais",
                table: "ZonaHorariaPais",
                newName: "ZonaHorariaPaisId");
        }
    }
}
