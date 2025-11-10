using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rondaholanadesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RondaHolandesa");

            migrationBuilder.CreateTable(
                name: "RondaHolandesaItem",
                columns: table => new
                {
                    IdRondaHolandesaItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioInicial = table.Column<long>(type: "bigint", nullable: false),
                    DescuentoAumento = table.Column<long>(type: "bigint", nullable: false),
                    LimiteOferta = table.Column<long>(type: "bigint", nullable: false),
                    Oferta = table.Column<long>(type: "bigint", nullable: false),
                    RondaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RondaHolandesaItem", x => x.IdRondaHolandesaItem);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RondaHolandesaItem");

            migrationBuilder.CreateTable(
                name: "RondaHolandesa",
                columns: table => new
                {
                    IdRondaHolandesa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescuentoAumento = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LimiteOferta = table.Column<long>(type: "bigint", nullable: false),
                    Oferta = table.Column<long>(type: "bigint", nullable: false),
                    PrecioInicial = table.Column<long>(type: "bigint", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Tiempo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RondaHolandesa", x => x.IdRondaHolandesa);
                });
        }
    }
}
