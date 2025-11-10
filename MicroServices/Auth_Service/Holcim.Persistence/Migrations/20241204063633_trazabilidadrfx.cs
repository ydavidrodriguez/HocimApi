using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class trazabilidadrfx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCreacion",
                table: "Rfx",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ArchivoSobreId",
                table: "PreguntaArchivo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivoSobre",
                columns: table => new
                {
                    IdArchivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    TipoArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoSobre", x => x.IdArchivo);
                    table.ForeignKey(
                        name: "FK_ArchivoSobre_TipoArchivo_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "TipoArchivo",
                        principalColumn: "IdTipoArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaSobreRfx",
                columns: table => new
                {
                    IdPreguntaSobreRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreguntaArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaSobreRfx", x => x.IdPreguntaSobreRfx);
                    table.ForeignKey(
                        name: "FK_PreguntaSobreRfx_PreguntaArchivo_PreguntaArchivoId",
                        column: x => x.PreguntaArchivoId,
                        principalTable: "PreguntaArchivo",
                        principalColumn: "IdPreguntaArchivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntaSobreRfx_Rfx_RfxId",
                        column: x => x.RfxId,
                        principalTable: "Rfx",
                        principalColumn: "IdRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrazabilidadRfx",
                columns: table => new
                {
                    IdTrazabilidadRfx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrazabilidadRfx", x => x.IdTrazabilidadRfx);
                    table.ForeignKey(
                        name: "FK_TrazabilidadRfx_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrazabilidadRfx_Rfx_RfxId",
                        column: x => x.RfxId,
                        principalTable: "Rfx",
                        principalColumn: "IdRfx",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrazabilidadRfx_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaArchivo_ArchivoSobreId",
                table: "PreguntaArchivo",
                column: "ArchivoSobreId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoSobre_TipoArchivoId",
                table: "ArchivoSobre",
                column: "TipoArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaSobreRfx_PreguntaArchivoId",
                table: "PreguntaSobreRfx",
                column: "PreguntaArchivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaSobreRfx_RfxId",
                table: "PreguntaSobreRfx",
                column: "RfxId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadRfx_EstadoId",
                table: "TrazabilidadRfx",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadRfx_RfxId",
                table: "TrazabilidadRfx",
                column: "RfxId");

            migrationBuilder.CreateIndex(
                name: "IX_TrazabilidadRfx_UsuarioId",
                table: "TrazabilidadRfx",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaArchivo_ArchivoSobre_ArchivoSobreId",
                table: "PreguntaArchivo",
                column: "ArchivoSobreId",
                principalTable: "ArchivoSobre",
                principalColumn: "IdArchivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaArchivo_ArchivoSobre_ArchivoSobreId",
                table: "PreguntaArchivo");

            migrationBuilder.DropTable(
                name: "ArchivoSobre");

            migrationBuilder.DropTable(
                name: "PreguntaSobreRfx");

            migrationBuilder.DropTable(
                name: "TrazabilidadRfx");

            migrationBuilder.DropIndex(
                name: "IX_PreguntaArchivo_ArchivoSobreId",
                table: "PreguntaArchivo");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "ArchivoSobreId",
                table: "PreguntaArchivo");

            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    IdArchivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.IdArchivo);
                    table.ForeignKey(
                        name: "FK_Archivo_TipoArchivo_TipoArchivoId",
                        column: x => x.TipoArchivoId,
                        principalTable: "TipoArchivo",
                        principalColumn: "IdTipoArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_TipoArchivoId",
                table: "Archivo",
                column: "TipoArchivoId");
        }
    }
}
