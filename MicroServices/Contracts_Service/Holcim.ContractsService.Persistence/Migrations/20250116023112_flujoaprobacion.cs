using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class flujoaprobacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Minimo",
                table: "PasoFlujo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Maximo",
                table: "PasoFlujo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "FlujoContrato",
                columns: table => new
                {
                    IdFlujoContrato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlujoAprobacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlujoContrato", x => x.IdFlujoContrato);
                    table.ForeignKey(
                        name: "FK_FlujoContrato_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlujoContrato_FlujoAprobacion_FlujoAprobacionId",
                        column: x => x.FlujoAprobacionId,
                        principalTable: "FlujoAprobacion",
                        principalColumn: "IdFlujoAprobacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlujoContrato_ContratoId",
                table: "FlujoContrato",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoContrato_FlujoAprobacionId",
                table: "FlujoContrato",
                column: "FlujoAprobacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlujoContrato");

            migrationBuilder.AlterColumn<int>(
                name: "Minimo",
                table: "PasoFlujo",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Maximo",
                table: "PasoFlujo",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
