using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Rfxnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rfx_Region_RegionId",
                table: "Rfx");

            migrationBuilder.DropIndex(
                name: "IX_Rfx_RegionId",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Rfx");

            migrationBuilder.RenameColumn(
                name: "PrecioReferencia",
                table: "Rfx",
                newName: "ValorReferencia");

            migrationBuilder.AddColumn<int>(
                name: "Consecutivo",
                table: "Rfx",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Prueba",
                table: "Rfx",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RfxPais",
                columns: table => new
                {
                    IdRfxPais = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfxPais", x => x.IdRfxPais);
                    table.ForeignKey(
                        name: "FK_RfxPais_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfxPais_Rfx_RfxId",
                        column: x => x.RfxId,
                        principalTable: "Rfx",
                        principalColumn: "IdRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfxPais_PaisId",
                table: "RfxPais",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_RfxPais_RfxId",
                table: "RfxPais",
                column: "RfxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfxPais");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "Prueba",
                table: "Rfx");

            migrationBuilder.RenameColumn(
                name: "ValorReferencia",
                table: "Rfx",
                newName: "PrecioReferencia");

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Rfx",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rfx_RegionId",
                table: "Rfx",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rfx_Region_RegionId",
                table: "Rfx",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "IdRegion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
