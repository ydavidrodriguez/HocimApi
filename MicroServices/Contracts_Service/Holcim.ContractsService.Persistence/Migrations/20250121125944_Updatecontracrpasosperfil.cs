using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updatecontracrpasosperfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnvioCorreo",
                table: "PasosPerfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FechaEnvioCorreo",
                table: "PasosPerfiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnvioCorreo",
                table: "PasosPerfiles");

            migrationBuilder.DropColumn(
                name: "FechaEnvioCorreo",
                table: "PasosPerfiles");
        }
    }
}
