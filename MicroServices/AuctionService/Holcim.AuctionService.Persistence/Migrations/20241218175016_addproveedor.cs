using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addproveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ProveedorSubasta",
                columns: table => new
                {
                    IdProveedorSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorSubasta", x => x.IdProveedorSubasta);
                    table.ForeignKey(
                        name: "FK_ProveedorSubasta_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor");
                    table.ForeignKey(
                        name: "FK_ProveedorSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorSubasta_ProveedorId",
                table: "ProveedorSubasta",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorSubasta_SubastaId",
                table: "ProveedorSubasta",
                column: "SubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProveedorSubasta");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
