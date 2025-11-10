using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTrazabilidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "Subasta");

            migrationBuilder.CreateTable(
                name: "TrazabilidadSubasta",
                columns: table => new
                {
                    IdTrazabilidadSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotivoEstado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrazabilidadSubasta", x => x.IdTrazabilidadSubasta);
                    table.ForeignKey(
                        name: "FK_TrazabilidadSubasta_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrazabilidadSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadSubasta_EstadoId",
                table: "TrazabilidadSubasta",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadSubasta_SubastaId",
                table: "TrazabilidadSubasta",
                column: "SubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrazabilidadSubasta");

            migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "Subasta",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
