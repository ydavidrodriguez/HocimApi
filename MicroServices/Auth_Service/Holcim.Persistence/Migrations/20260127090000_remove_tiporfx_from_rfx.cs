using System;
using Holcim.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    [DbContext(typeof(DataBaseService))]
    [Migration("20260127090000_remove_tiporfx_from_rfx")]
    public partial class remove_tiporfx_from_rfx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rfx_TipoRfx_TipoRfxId",
                table: "Rfx");

            migrationBuilder.DropIndex(
                name: "IX_Rfx_TipoRfxId",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "TipoRfxId",
                table: "Rfx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoRfxId",
                table: "Rfx",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rfx_TipoRfxId",
                table: "Rfx",
                column: "TipoRfxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rfx_TipoRfx_TipoRfxId",
                table: "Rfx",
                column: "TipoRfxId",
                principalTable: "TipoRfx",
                principalColumn: "IdTipoRfx",
                onDelete: ReferentialAction.Cascade);
        }
    }
}