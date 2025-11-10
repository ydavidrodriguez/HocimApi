using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class proveedorrfx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProveedorRfx",
                columns: table => new
                {
                    IdProveedorRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorRfx", x => x.IdProveedorRfx);
                    table.ForeignKey(
                        name: "FK_ProveedorRfx_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProveedorRfx_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProveedorRfx_Rfx_RfxId",
                        column: x => x.RfxId,
                        principalTable: "Rfx",
                        principalColumn: "IdRfx",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorRfx_EstadoId",
                table: "ProveedorRfx",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorRfx_ProveedorId",
                table: "ProveedorRfx",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorRfx_RfxId",
                table: "ProveedorRfx",
                column: "RfxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProveedorRfx");
        }
    }
}
