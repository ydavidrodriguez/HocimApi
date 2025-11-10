using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class archivos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoArchivo_TipoRfx_TipoRfxId",
                table: "TipoArchivo");

            migrationBuilder.DropIndex(
                name: "IX_TipoArchivo_TipoRfxId",
                table: "TipoArchivo");

            migrationBuilder.DropColumn(
                name: "TipoRfxId",
                table: "TipoArchivo");

            migrationBuilder.RenameColumn(
                name: "IdArchivos",
                table: "Archivos",
                newName: "IdArchivo");

            migrationBuilder.CreateTable(
                name: "TipoArchivoRfx",
                columns: table => new
                {
                    IdTipoArchivoRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoRfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArchivoRfx", x => x.IdTipoArchivoRfx);
                    table.ForeignKey(
                        name: "FK_TipoArchivoRfx_TipoArchivo_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "TipoArchivo",
                        principalColumn: "IdTipoArchivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoArchivoRfx_TipoRfx_TipoRfxId",
                        column: x => x.TipoRfxId,
                        principalTable: "TipoRfx",
                        principalColumn: "IdTipoRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoArchivoRfx_TipoArchivoId",
                table: "TipoArchivoRfx",
                column: "TipoArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoArchivoRfx_TipoRfxId",
                table: "TipoArchivoRfx",
                column: "TipoRfxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoArchivoRfx");

            migrationBuilder.RenameColumn(
                name: "IdArchivo",
                table: "Archivos",
                newName: "IdArchivos");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoRfxId",
                table: "TipoArchivo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TipoArchivo_TipoRfxId",
                table: "TipoArchivo",
                column: "TipoRfxId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoArchivo_TipoRfx_TipoRfxId",
                table: "TipoArchivo",
                column: "TipoRfxId",
                principalTable: "TipoRfx",
                principalColumn: "IdTipoRfx",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
