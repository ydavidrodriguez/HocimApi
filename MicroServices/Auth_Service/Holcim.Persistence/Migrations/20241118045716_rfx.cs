using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rfx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    IdEstado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActulizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    IdItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    PscsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActulizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Item_Pscs_PscsId",
                        column: x => x.PscsId,
                        principalTable: "Pscs",
                        principalColumn: "IdPscs",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoRfx",
                columns: table => new
                {
                    IdTipoRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActulizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRfx", x => x.IdTipoRfx);
                });

            migrationBuilder.CreateTable(
                name: "RfxItem",
                columns: table => new
                {
                    IdRfxItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PscsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfxItem", x => x.IdRfxItem);
                    table.ForeignKey(
                        name: "FK_RfxItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfxItem_Pscs_PscsId",
                        column: x => x.PscsId,
                        principalTable: "Pscs",
                        principalColumn: "IdPscs",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rfx",
                columns: table => new
                {
                    IdRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoRfx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoRfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rfx", x => x.IdRfx);
                    table.ForeignKey(
                        name: "FK_Rfx_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rfx_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rfx_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "IdRegion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rfx_TipoRfx_TipoRfxId",
                        column: x => x.TipoRfxId,
                        principalTable: "TipoRfx",
                        principalColumn: "IdTipoRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_PscsId",
                table: "Item",
                column: "PscsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfx_EstadoId",
                table: "Rfx",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfx_ItemId",
                table: "Rfx",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfx_RegionId",
                table: "Rfx",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rfx_TipoRfxId",
                table: "Rfx",
                column: "TipoRfxId");

            migrationBuilder.CreateIndex(
                name: "IX_RfxItem_ItemId",
                table: "RfxItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RfxItem_PscsId",
                table: "RfxItem",
                column: "PscsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rfx");

            migrationBuilder.DropTable(
                name: "RfxItem");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoRfx");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
