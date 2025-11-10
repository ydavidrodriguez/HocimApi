using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class observacionitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "ItemDetalle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvitacionProveedorRfx",
                columns: table => new
                {
                    IdInvitacionProveedorRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitacionProveedorRfx", x => x.IdInvitacionProveedorRfx);
                    table.ForeignKey(
                        name: "FK_InvitacionProveedorRfx_Rfx_RfxId",
                        column: x => x.RfxId,
                        principalTable: "Rfx",
                        principalColumn: "IdRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitacionProveedorRfx_RfxId",
                table: "InvitacionProveedorRfx",
                column: "RfxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitacionProveedorRfx");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "ItemDetalle");
        }
    }
}
