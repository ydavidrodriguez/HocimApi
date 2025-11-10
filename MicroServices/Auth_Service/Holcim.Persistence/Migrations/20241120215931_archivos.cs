using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class archivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoArchivo",
                columns: table => new
                {
                    IdTipoArchivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoRfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArchivo", x => x.IdTipoArchivo);
                    table.ForeignKey(
                        name: "FK_TipoArchivo_TipoRfx_TipoRfxId",
                        column: x => x.TipoRfxId,
                        principalTable: "TipoRfx",
                        principalColumn: "IdTipoRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValoresArchivo",
                columns: table => new
                {
                    IdValoresArchivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresArchivo", x => x.IdValoresArchivo);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    IdArchivos = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreArchivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.IdArchivos);
                    table.ForeignKey(
                        name: "FK_Archivos_TipoArchivo_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "TipoArchivo",
                        principalColumn: "IdTipoArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaArchivo",
                columns: table => new
                {
                    IdPreguntaArchivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValoresArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Requerido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaArchivo", x => x.IdPreguntaArchivo);
                    table.ForeignKey(
                        name: "FK_PreguntaArchivo_ValoresArchivo_ValoresArchivoId",
                        column: x => x.ValoresArchivoId,
                        principalTable: "ValoresArchivo",
                        principalColumn: "IdValoresArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_TipoArchivoId",
                table: "Archivos",
                column: "TipoArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaArchivo_ValoresArchivoId",
                table: "PreguntaArchivo",
                column: "ValoresArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoArchivo_TipoRfxId",
                table: "TipoArchivo",
                column: "TipoRfxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "PreguntaArchivo");

            migrationBuilder.DropTable(
                name: "TipoArchivo");

            migrationBuilder.DropTable(
                name: "ValoresArchivo");
        }
    }
}
