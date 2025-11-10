using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rfid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RfxId",
                table: "AdjudicacionProveedor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AdjudicacionProveedor_RfxId",
                table: "AdjudicacionProveedor",
                column: "RfxId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdjudicacionProveedor_Rfx_RfxId",
                table: "AdjudicacionProveedor",
                column: "RfxId",
                principalTable: "Rfx",
                principalColumn: "IdRfx",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdjudicacionProveedor_Rfx_RfxId",
                table: "AdjudicacionProveedor");

            migrationBuilder.DropIndex(
                name: "IX_AdjudicacionProveedor_RfxId",
                table: "AdjudicacionProveedor");

            migrationBuilder.DropColumn(
                name: "RfxId",
                table: "AdjudicacionProveedor");
        }
    }
}
