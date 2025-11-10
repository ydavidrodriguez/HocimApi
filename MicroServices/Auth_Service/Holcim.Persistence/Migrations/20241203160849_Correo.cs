using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Correo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetalle_PreguntaArchivo_PreguntaArchivoId",
                table: "ItemDetalle");

            migrationBuilder.DropIndex(
                name: "IX_ItemDetalle_PreguntaArchivoId",
                table: "ItemDetalle");

            migrationBuilder.DropColumn(
                name: "PreguntaArchivoId",
                table: "ItemDetalle");

            migrationBuilder.CreateTable(
                name: "Correo",
                columns: table => new
                {
                    IdCorreo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correo", x => x.IdCorreo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correo");

            migrationBuilder.AddColumn<Guid>(
                name: "PreguntaArchivoId",
                table: "ItemDetalle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_PreguntaArchivoId",
                table: "ItemDetalle",
                column: "PreguntaArchivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetalle_PreguntaArchivo_PreguntaArchivoId",
                table: "ItemDetalle",
                column: "PreguntaArchivoId",
                principalTable: "PreguntaArchivo",
                principalColumn: "IdPreguntaArchivo");
        }
    }
}
