using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class reasignacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    IdMotivo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.IdMotivo);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioReasignacion",
                columns: table => new
                {
                    IdUsuarioReasignacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RfxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioOld = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioReasignacion", x => x.IdUsuarioReasignacion);
                    table.ForeignKey(
                        name: "FK_UsuarioReasignacion_Rfx_RfxId",
                        column: x => x.RfxId,
                        principalTable: "Rfx",
                        principalColumn: "IdRfx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioReasignacion_RfxId",
                table: "UsuarioReasignacion",
                column: "RfxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "UsuarioReasignacion");
        }
    }
}
