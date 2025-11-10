using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deletecampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "TipoPrecios");

            migrationBuilder.DropIndex(
                name: "IX_Subasta_TipoOfertaId",
                table: "Subasta");

            migrationBuilder.DropColumn(
                name: "TipoOfertaId",
                table: "Subasta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoOfertaId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TipoPrecios",
                columns: table => new
                {
                    IdTipoOferta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrecios", x => x.IdTipoOferta);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subasta_TipoOfertaId",
                table: "Subasta",
                column: "TipoOfertaId");

        }
    }
}
