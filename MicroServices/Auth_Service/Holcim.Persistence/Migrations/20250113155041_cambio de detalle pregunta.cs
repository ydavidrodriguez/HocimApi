using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cambiodedetallepregunta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "ArchivoSobre");

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "PreguntaArchivo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "PreguntaArchivo");

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "ArchivoSobre",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
