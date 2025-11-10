using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addZonaHoraria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                table: "Subasta");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoPreciosId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCreacionId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ZonaHorariaId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                table: "Subasta",
                column: "TipoPreciosId",
                principalTable: "TipoPrecios",
                principalColumn: "IdTipoPrecios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                table: "Subasta");


            migrationBuilder.DropColumn(
                name: "UsuarioCreacionId",
                table: "Subasta");

            migrationBuilder.DropColumn(
                name: "ZonaHorariaId",
                table: "Subasta");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoPreciosId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                table: "Subasta",
                column: "TipoPreciosId",
                principalTable: "TipoPrecios",
                principalColumn: "IdTipoPrecios",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
