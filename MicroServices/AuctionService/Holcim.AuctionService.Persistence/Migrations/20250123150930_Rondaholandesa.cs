using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Rondaholandesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RondaHolandesa",
                columns: table => new
                {
                    IdRondaHolandesa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioInicial = table.Column<long>(type: "bigint", nullable: false),
                    DescuentoAumento = table.Column<long>(type: "bigint", nullable: false),
                    LimiteOferta = table.Column<long>(type: "bigint", nullable: false),
                    Oferta = table.Column<long>(type: "bigint", nullable: false),
                    IdSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tiempo = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RondaHolandesa", x => x.IdRondaHolandesa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RondaHolandesa");
        }
    }
}
