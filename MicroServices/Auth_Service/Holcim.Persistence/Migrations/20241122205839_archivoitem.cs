using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class archivoitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Afirmacion",
                table: "PreguntaArchivo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RutaUrl",
                table: "PreguntaArchivo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValoresArchivoJson",
                table: "PreguntaArchivo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemPregunta",
                columns: table => new
                {
                    IdItemPregunta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    preguntaArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPregunta", x => x.IdItemPregunta);
                    table.ForeignKey(
                        name: "FK_ItemPregunta_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPregunta_PreguntaArchivo_preguntaArchivoId",
                        column: x => x.preguntaArchivoId,
                        principalTable: "PreguntaArchivo",
                        principalColumn: "IdPreguntaArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPregunta_ItemId",
                table: "ItemPregunta",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPregunta_preguntaArchivoId",
                table: "ItemPregunta",
                column: "preguntaArchivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPregunta");

            migrationBuilder.DropColumn(
                name: "Afirmacion",
                table: "PreguntaArchivo");

            migrationBuilder.DropColumn(
                name: "RutaUrl",
                table: "PreguntaArchivo");

            migrationBuilder.DropColumn(
                name: "ValoresArchivoJson",
                table: "PreguntaArchivo");
        }
    }
}
