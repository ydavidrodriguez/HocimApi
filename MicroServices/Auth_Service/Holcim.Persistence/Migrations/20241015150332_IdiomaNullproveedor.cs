using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IdiomaNullproveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Idioma_IdiomaId",
                table: "Proveedor");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdiomaId",
                table: "Proveedor",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Idioma_IdiomaId",
                table: "Proveedor",
                column: "IdiomaId",
                principalTable: "Idioma",
                principalColumn: "IdIdioma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Idioma_IdiomaId",
                table: "Proveedor");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdiomaId",
                table: "Proveedor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Idioma_IdiomaId",
                table: "Proveedor",
                column: "IdiomaId",
                principalTable: "Idioma",
                principalColumn: "IdIdioma",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
