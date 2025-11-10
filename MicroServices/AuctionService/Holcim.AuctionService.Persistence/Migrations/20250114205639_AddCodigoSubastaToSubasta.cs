using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoSubastaToSubasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionSubasta");

            migrationBuilder.AddColumn<int>(
                name: "CodigoSubasta",
                table: "Subasta",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "PaisSubasta",
                columns: table => new
                {
                    IdPaisSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPais = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisSubasta", x => x.IdPaisSubasta);
                    table.ForeignKey(
                        name: "FK_PaisSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaisSubasta_SubastaId",
                table: "PaisSubasta",
                column: "SubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaisSubasta");

            migrationBuilder.DropColumn(
                name: "CodigoSubasta",
                table: "Subasta");

            migrationBuilder.CreateTable(
                name: "RegionSubasta",
                columns: table => new
                {
                    IdRegionSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRegion = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionSubasta", x => x.IdRegionSubasta);
                    table.ForeignKey(
                        name: "FK_RegionSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionSubasta_SubastaId",
                table: "RegionSubasta",
                column: "SubastaId");
        }
    }
}
