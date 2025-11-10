using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tipoestado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoEstadoId",
                table: "Estado",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TipoEstado",
                columns: table => new
                {
                    IdTipoEstado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstado", x => x.IdTipoEstado);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estado_TipoEstadoId",
                table: "Estado",
                column: "TipoEstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_TipoEstado_TipoEstadoId",
                table: "Estado",
                column: "TipoEstadoId",
                principalTable: "TipoEstado",
                principalColumn: "IdTipoEstado",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estado_TipoEstado_TipoEstadoId",
                table: "Estado");

            migrationBuilder.DropTable(
                name: "TipoEstado");

            migrationBuilder.DropIndex(
                name: "IX_Estado_TipoEstadoId",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "TipoEstadoId",
                table: "Estado");
        }
    }
}
