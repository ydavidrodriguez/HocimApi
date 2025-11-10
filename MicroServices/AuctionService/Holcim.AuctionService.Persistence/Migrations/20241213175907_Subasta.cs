using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Subasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPrecios",
                columns: table => new
                {
                    IdTipoPrecios = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrecios", x => x.IdTipoPrecios);
                });

            migrationBuilder.CreateTable(
                name: "TipoSubasta",
                columns: table => new
                {
                    IdTipoSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSubasta", x => x.IdTipoSubasta);
                });

            migrationBuilder.CreateTable(
                name: "Subasta",
                columns: table => new
                {
                    IdSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoSubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorEstimado = table.Column<int>(type: "int", nullable: false),
                    PrecioReferencia = table.Column<int>(type: "int", nullable: false),
                    TipoPreciosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subasta", x => x.IdSubasta);
                    table.ForeignKey(
                        name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                        column: x => x.TipoPreciosId,
                        principalTable: "TipoPrecios",
                        principalColumn: "IdTipoPrecios",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subasta_TipoSubasta_TipoSubastaId",
                        column: x => x.TipoSubastaId,
                        principalTable: "TipoSubasta",
                        principalColumn: "IdTipoSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubasta",
                columns: table => new
                {
                    IdItemSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubasta", x => x.IdItemSubasta);
                    table.ForeignKey(
                        name: "FK_ItemSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionSubasta",
                columns: table => new
                {
                    IdRegionSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRegion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionSubasta", x => x.IdRegionSubasta);
                    table.ForeignKey(
                        name: "FK_RegionSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubasta_SubastaId",
                table: "ItemSubasta",
                column: "SubastaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionSubasta_SubastaId",
                table: "RegionSubasta",
                column: "SubastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subasta_TipoPreciosId",
                table: "Subasta",
                column: "TipoPreciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Subasta_TipoSubastaId",
                table: "Subasta",
                column: "TipoSubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSubasta");

            migrationBuilder.DropTable(
                name: "RegionSubasta");

            migrationBuilder.DropTable(
                name: "Subasta");

            migrationBuilder.DropTable(
                name: "TipoPrecios");

            migrationBuilder.DropTable(
                name: "TipoSubasta");
        }
    }
}
