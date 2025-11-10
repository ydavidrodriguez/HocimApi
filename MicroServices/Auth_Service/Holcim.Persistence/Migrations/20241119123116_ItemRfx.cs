using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ItemRfx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Pscs_PscsId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_PscsId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PscsId",
                table: "Item");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActulizacion",
                table: "Rfx",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Rfx",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ItemDetalle",
                columns: table => new
                {
                    IdItemDetalle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadMedidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PscsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    valorUnidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetalle", x => x.IdItemDetalle);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_Pscs_PscsId",
                        column: x => x.PscsId,
                        principalTable: "Pscs",
                        principalColumn: "IdPscs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDetalle_UnidadMedida_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_ItemId",
                table: "ItemDetalle",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_PscsId",
                table: "ItemDetalle",
                column: "PscsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetalle_UnidadMedidaId",
                table: "ItemDetalle",
                column: "UnidadMedidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDetalle");

            migrationBuilder.DropColumn(
                name: "FechaActulizacion",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Rfx");

            migrationBuilder.AddColumn<Guid>(
                name: "PscsId",
                table: "Item",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Item_PscsId",
                table: "Item",
                column: "PscsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Pscs_PscsId",
                table: "Item",
                column: "PscsId",
                principalTable: "Pscs",
                principalColumn: "IdPscs",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
