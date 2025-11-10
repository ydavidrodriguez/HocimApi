using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguracionSubastaIngles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfiguracionSubastaInglesa",
                columns: table => new
                {
                    IdConfiguracionSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MostrarMejorOferta = table.Column<bool>(type: "bit", nullable: false),
                    MostrarPosicion = table.Column<bool>(type: "bit", nullable: false),
                    MejorarPropiaPosicion = table.Column<bool>(type: "bit", nullable: false),
                    PosicionAMejorar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionSubastaInglesa", x => x.IdConfiguracionSubasta);
                    table.ForeignKey(
                        name: "FK_ConfiguracionSubastaInglesa_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionSubastaInglesa_SubastaId",
                table: "ConfiguracionSubastaInglesa",
                column: "SubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracionSubastaInglesa");
        }
    }
}
