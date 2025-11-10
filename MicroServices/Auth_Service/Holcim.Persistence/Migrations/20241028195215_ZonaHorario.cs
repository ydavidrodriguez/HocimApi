using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ZonaHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ZonaHorariaId",
                table: "Proveedor",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ZonaHoraria",
                columns: table => new
                {
                    IdZonaHoraria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActulizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaHoraria", x => x.IdZonaHoraria);
                });

            migrationBuilder.CreateTable(
                name: "ZonaHorariaPais",
                columns: table => new
                {
                    ZonaHorariaPaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZonaHorariaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaHorariaPais", x => x.ZonaHorariaPaisId);
                    table.ForeignKey(
                        name: "FK_ZonaHorariaPais_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZonaHorariaPais_ZonaHoraria_ZonaHorariaId",
                        column: x => x.ZonaHorariaId,
                        principalTable: "ZonaHoraria",
                        principalColumn: "IdZonaHoraria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_ZonaHorariaId",
                table: "Proveedor",
                column: "ZonaHorariaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaHorariaPais_PaisId",
                table: "ZonaHorariaPais",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaHorariaPais_ZonaHorariaId",
                table: "ZonaHorariaPais",
                column: "ZonaHorariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_ZonaHoraria_ZonaHorariaId",
                table: "Proveedor",
                column: "ZonaHorariaId",
                principalTable: "ZonaHoraria",
                principalColumn: "IdZonaHoraria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_ZonaHoraria_ZonaHorariaId",
                table: "Proveedor");

            migrationBuilder.DropTable(
                name: "ZonaHorariaPais");

            migrationBuilder.DropTable(
                name: "ZonaHoraria");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_ZonaHorariaId",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "ZonaHorariaId",
                table: "Proveedor");
        }
    }
}
