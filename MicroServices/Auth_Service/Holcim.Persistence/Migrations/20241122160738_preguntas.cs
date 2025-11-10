using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class preguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoDato",
                table: "ValoresArchivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "TipoDato",
                table: "ValoresArchivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
