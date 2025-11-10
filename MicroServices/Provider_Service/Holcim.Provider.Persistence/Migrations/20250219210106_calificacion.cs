using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class calificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Calificacion",
                table: "RespuestaPreguntaPorcentaje",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Calificacion",
                table: "RespuestaPreguntaPorcentaje",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
