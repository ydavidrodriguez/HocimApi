using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class createEstatusAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "InvitacionProveedorSubasta",
                columns: table => new
                {
                    IdInvitacionProveedorSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitacionProveedorSubasta", x => x.IdInvitacionProveedorSubasta);
                    table.ForeignKey(
                        name: "FK_InvitacionProveedorSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaSobreSubasta",
                columns: table => new
                {
                    IdPreguntaSobreSubasta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubastaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreguntaArchivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaSobreSubasta", x => x.IdPreguntaSobreSubasta);
                    table.ForeignKey(
                        name: "FK_PreguntaSobreSubasta_Subasta_SubastaId",
                        column: x => x.SubastaId,
                        principalTable: "Subasta",
                        principalColumn: "IdSubasta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitacionProveedorSubasta_SubastaId",
                table: "InvitacionProveedorSubasta",
                column: "SubastaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaSobreSubasta_SubastaId",
                table: "PreguntaSobreSubasta",
                column: "SubastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitacionProveedorSubasta");

            migrationBuilder.DropTable(
                name: "PreguntaSobreSubasta");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Subasta");
        }
    }
}
