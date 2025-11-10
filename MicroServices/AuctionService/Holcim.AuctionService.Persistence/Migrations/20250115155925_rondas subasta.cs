using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rondassubasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsRonda",
                columns: table => new
                {
                    IdItemsRonda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<long>(type: "bigint", nullable: false),
                    valorUnidad = table.Column<long>(type: "bigint", nullable: true),
                    RondaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsRonda", x => x.IdItemsRonda);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaRonda",
                columns: table => new
                {
                    RespuestaRondaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsRondaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioRondaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Respuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaRonda", x => x.RespuestaRondaId);
                });

            migrationBuilder.CreateTable(
                name: "Ronda",
                columns: table => new
                {
                    IdRonda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tiempo = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ronda", x => x.IdRonda);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRonda",
                columns: table => new
                {
                    IdIUsuarioRonda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RondaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRonda", x => x.IdIUsuarioRonda);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsRonda");

            migrationBuilder.DropTable(
                name: "RespuestaRonda");

            migrationBuilder.DropTable(
                name: "Ronda");

            migrationBuilder.DropTable(
                name: "UsuarioRonda");
        }
    }
}
