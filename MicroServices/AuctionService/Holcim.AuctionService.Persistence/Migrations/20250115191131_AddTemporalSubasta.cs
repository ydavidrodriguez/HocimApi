using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTemporalSubasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prueba",
                table: "Subasta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubastaTemporal",
                columns: table => new
                {
                    IdSubastaTemporal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JsonSubasta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubastaTemporal", x => x.IdSubastaTemporal);
                    table.ForeignKey(
                        name: "FK_SubastaTemporal_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubastaTemporal_EstadoId",
                table: "SubastaTemporal",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubastaTemporal");

            migrationBuilder.DropColumn(
                name: "Prueba",
                table: "Subasta");
        }
    }
}
