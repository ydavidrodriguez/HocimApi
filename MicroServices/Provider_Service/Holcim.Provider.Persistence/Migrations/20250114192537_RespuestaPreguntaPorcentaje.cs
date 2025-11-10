using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Provider.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RespuestaPreguntaPorcentaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespuestaPreguntaPorcentaje",
                columns: table => new
                {
                    IdRespuestaPreguntaPorcentaje = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Calificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaPreguntaPorcentaje", x => x.IdRespuestaPreguntaPorcentaje);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespuestaPreguntaPorcentaje");
        }
    }
}
