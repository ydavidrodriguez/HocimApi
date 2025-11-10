using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MonedaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rfx_Item_ItemId",
                table: "Rfx");

            migrationBuilder.DropForeignKey(
                name: "FK_RfxItem_Pscs_PscsId",
                table: "RfxItem");

            migrationBuilder.DropColumn(
                name: "CodigoRfx",
                table: "Rfx");

            migrationBuilder.RenameColumn(
                name: "PscsId",
                table: "RfxItem",
                newName: "RfxId");

            migrationBuilder.RenameIndex(
                name: "IX_RfxItem_PscsId",
                table: "RfxItem",
                newName: "IX_RfxItem_RfxId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Rfx",
                newName: "MonedaId");

            migrationBuilder.RenameIndex(
                name: "IX_Rfx_ItemId",
                table: "Rfx",
                newName: "IX_Rfx_MonedaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rfx_Moneda_MonedaId",
                table: "Rfx",
                column: "MonedaId",
                principalTable: "Moneda",
                principalColumn: "IdMoneda",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RfxItem_Rfx_RfxId",
                table: "RfxItem",
                column: "RfxId",
                principalTable: "Rfx",
                principalColumn: "IdRfx",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rfx_Moneda_MonedaId",
                table: "Rfx");

            migrationBuilder.DropForeignKey(
                name: "FK_RfxItem_Rfx_RfxId",
                table: "RfxItem");

            migrationBuilder.RenameColumn(
                name: "RfxId",
                table: "RfxItem",
                newName: "PscsId");

            migrationBuilder.RenameIndex(
                name: "IX_RfxItem_RfxId",
                table: "RfxItem",
                newName: "IX_RfxItem_PscsId");

            migrationBuilder.RenameColumn(
                name: "MonedaId",
                table: "Rfx",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Rfx_MonedaId",
                table: "Rfx",
                newName: "IX_Rfx_ItemId");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRfx",
                table: "Rfx",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rfx_Item_ItemId",
                table: "Rfx",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "IdItem",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RfxItem_Pscs_PscsId",
                table: "RfxItem",
                column: "PscsId",
                principalTable: "Pscs",
                principalColumn: "IdPscs",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
