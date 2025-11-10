using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class idioma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdiomaId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdiomaId",
                table: "Usuario",
                column: "IdiomaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Idioma_IdiomaId",
                table: "Usuario",
                column: "IdiomaId",
                principalTable: "Idioma",
                principalColumn: "IdIdioma",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Idioma_IdiomaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdiomaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdiomaId",
                table: "Usuario");
        }
    }
}
