using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nulopscid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetalle_Pscs_PscsId",
                table: "ItemDetalle");

            migrationBuilder.AlterColumn<Guid>(
                name: "PscsId",
                table: "ItemDetalle",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetalle_Pscs_PscsId",
                table: "ItemDetalle",
                column: "PscsId",
                principalTable: "Pscs",
                principalColumn: "IdPscs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetalle_Pscs_PscsId",
                table: "ItemDetalle");

            migrationBuilder.AlterColumn<Guid>(
                name: "PscsId",
                table: "ItemDetalle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetalle_Pscs_PscsId",
                table: "ItemDetalle",
                column: "PscsId",
                principalTable: "Pscs",
                principalColumn: "IdPscs",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
