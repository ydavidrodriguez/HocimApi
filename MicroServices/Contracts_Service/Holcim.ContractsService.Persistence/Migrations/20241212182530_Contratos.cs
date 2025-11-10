using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Contratos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicionDinero",
                columns: table => new
                {
                    IdCondicionDinero = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MontoMaximo = table.Column<int>(type: "int", nullable: false),
                    MontoMinimo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaActulizacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionDinero", x => x.IdCondicionDinero);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    IdContrato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    MonedaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActulizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.IdContrato);
                });

            migrationBuilder.CreateTable(
                name: "FlujoAprobacion",
                columns: table => new
                {
                    IdFlujoAprobacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlujoAprobacion", x => x.IdFlujoAprobacion);
                });

            migrationBuilder.CreateTable(
                name: "TipoContrato",
                columns: table => new
                {
                    IdTipoContrato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContrato", x => x.IdTipoContrato);
                });

            migrationBuilder.CreateTable(
                name: "PasoFlujo",
                columns: table => new
                {
                    IdPasoFlujo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondicionDineroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FlujoAprobacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasoFlujo", x => x.IdPasoFlujo);
                    table.ForeignKey(
                        name: "FK_PasoFlujo_CondicionDinero_CondicionDineroId",
                        column: x => x.CondicionDineroId,
                        principalTable: "CondicionDinero",
                        principalColumn: "IdCondicionDinero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PasoFlujo_FlujoAprobacion_FlujoAprobacionId",
                        column: x => x.FlujoAprobacionId,
                        principalTable: "FlujoAprobacion",
                        principalColumn: "IdFlujoAprobacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasosPerfiles",
                columns: table => new
                {
                    IdPasosPerfiles = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasoFlujoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasosPerfiles", x => x.IdPasosPerfiles);
                    table.ForeignKey(
                        name: "FK_PasosPerfiles_PasoFlujo_PasoFlujoId",
                        column: x => x.PasoFlujoId,
                        principalTable: "PasoFlujo",
                        principalColumn: "IdPasoFlujo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasosTipoContrato",
                columns: table => new
                {
                    IdPasosTipoContrato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasoFlujoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoContratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasosTipoContrato", x => x.IdPasosTipoContrato);
                    table.ForeignKey(
                        name: "FK_PasosTipoContrato_PasoFlujo_PasoFlujoId",
                        column: x => x.PasoFlujoId,
                        principalTable: "PasoFlujo",
                        principalColumn: "IdPasoFlujo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PasosTipoContrato_TipoContrato_TipoContratoId",
                        column: x => x.TipoContratoId,
                        principalTable: "TipoContrato",
                        principalColumn: "IdTipoContrato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasoFlujo_CondicionDineroId",
                table: "PasoFlujo",
                column: "CondicionDineroId");

            migrationBuilder.CreateIndex(
                name: "IX_PasoFlujo_FlujoAprobacionId",
                table: "PasoFlujo",
                column: "FlujoAprobacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PasosPerfiles_PasoFlujoId",
                table: "PasosPerfiles",
                column: "PasoFlujoId");

            migrationBuilder.CreateIndex(
                name: "IX_PasosTipoContrato_PasoFlujoId",
                table: "PasosTipoContrato",
                column: "PasoFlujoId");

            migrationBuilder.CreateIndex(
                name: "IX_PasosTipoContrato_TipoContratoId",
                table: "PasosTipoContrato",
                column: "TipoContratoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "PasosPerfiles");

            migrationBuilder.DropTable(
                name: "PasosTipoContrato");

            migrationBuilder.DropTable(
                name: "PasoFlujo");

            migrationBuilder.DropTable(
                name: "TipoContrato");

            migrationBuilder.DropTable(
                name: "CondicionDinero");

            migrationBuilder.DropTable(
                name: "FlujoAprobacion");
        }
    }
}
