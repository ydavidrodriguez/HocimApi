using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TipoPais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoPaisId",
                table: "Pais",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TipoPais",
                columns: table => new
                {
                    IdTipoPais = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPais", x => x.IdTipoPais);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pais_TipoPaisId",
                table: "Pais",
                column: "TipoPaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pais_TipoPais_TipoPaisId",
                table: "Pais",
                column: "TipoPaisId",
                principalTable: "TipoPais",
                principalColumn: "IdTipoPais",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pais_TipoPais_TipoPaisId",
                table: "Pais");

            migrationBuilder.DropTable(
                name: "TipoPais");

            migrationBuilder.DropIndex(
                name: "IX_Pais_TipoPaisId",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "TipoPaisId",
                table: "Pais");
        }
    }
}
