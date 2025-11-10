using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class calificacion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Calificacion",
                table: "RespuestaPreguntaPorcentaje",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Calificacion",
                table: "RespuestaPreguntaPorcentaje",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
