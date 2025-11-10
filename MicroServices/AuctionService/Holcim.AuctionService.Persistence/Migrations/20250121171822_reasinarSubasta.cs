using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class reasinarSubasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioEncargadoSubasta",
                columns: table => new
                {
                    IdUsuarioEncargadoSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEncargadoSubasta", x => x.IdUsuarioEncargadoSubasta);
                    table.ForeignKey(
                        name: "FK_UsuarioEncargadoSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioReasignacionSubasta",
                columns: table => new
                {
                    IdUsuarioReasignacionSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioOld = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MotivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioReasignacionSubasta", x => x.IdUsuarioReasignacionSubasta);
                    table.ForeignKey(
                        name: "FK_UsuarioReasignacionSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEncargadoSubasta_SubastaId",
                table: "UsuarioEncargadoSubasta",
                column: "SubastaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioReasignacionSubasta_SubastaId",
                table: "UsuarioReasignacionSubasta",
                column: "SubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEncargadoSubasta");

            migrationBuilder.DropTable(
                name: "UsuarioReasignacionSubasta");
        }
    }
}
