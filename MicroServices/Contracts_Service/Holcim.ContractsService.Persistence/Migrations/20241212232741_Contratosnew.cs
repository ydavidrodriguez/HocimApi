using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Contratosnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasoFlujo_CondicionDinero_CondicionDineroId",
                table: "PasoFlujo");

            migrationBuilder.DropTable(
                name: "CondicionDinero");

            migrationBuilder.DropIndex(
                name: "IX_PasoFlujo_CondicionDineroId",
                table: "PasoFlujo");

            migrationBuilder.RenameColumn(
                name: "CondicionDineroId",
                table: "PasoFlujo",
                newName: "TipoMonedaId");

            migrationBuilder.AddColumn<int>(
                name: "Maximo",
                table: "PasoFlujo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minimo",
                table: "PasoFlujo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "FlujoAprobacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TipoContratoId",
                table: "Contrato",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TipoContratoId",
                table: "Contrato",
                column: "TipoContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_TipoContrato_TipoContratoId",
                table: "Contrato",
                column: "TipoContratoId",
                principalTable: "TipoContrato",
                principalColumn: "IdTipoContrato",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_TipoContrato_TipoContratoId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_TipoContratoId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "Maximo",
                table: "PasoFlujo");

            migrationBuilder.DropColumn(
                name: "Minimo",
                table: "PasoFlujo");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "FlujoAprobacion");

            migrationBuilder.DropColumn(
                name: "TipoContratoId",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "TipoMonedaId",
                table: "PasoFlujo",
                newName: "CondicionDineroId");

            migrationBuilder.CreateTable(
                name: "CondicionDinero",
                columns: table => new
                {
                    IdCondicionDinero = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaActulizacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MontoMaximo = table.Column<int>(type: "int", nullable: false),
                    MontoMinimo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionDinero", x => x.IdCondicionDinero);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasoFlujo_CondicionDineroId",
                table: "PasoFlujo",
                column: "CondicionDineroId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasoFlujo_CondicionDinero_CondicionDineroId",
                table: "PasoFlujo",
                column: "CondicionDineroId",
                principalTable: "CondicionDinero",
                principalColumn: "IdCondicionDinero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
