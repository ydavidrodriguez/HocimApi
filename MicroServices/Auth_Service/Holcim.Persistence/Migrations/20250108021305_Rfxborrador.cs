using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Rfxborrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetalleUrl",
                table: "Rfx");

            migrationBuilder.CreateTable(
                name: "RfxTemporal",
                columns: table => new
                {
                    IdRfxTemporal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JsonRfx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfxTemporal", x => x.IdRfxTemporal);
                    table.ForeignKey(
                        name: "FK_RfxTemporal_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfxTemporal_EstadoId",
                table: "RfxTemporal",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfxTemporal");

            migrationBuilder.AddColumn<string>(
                name: "DetalleUrl",
                table: "Rfx",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
