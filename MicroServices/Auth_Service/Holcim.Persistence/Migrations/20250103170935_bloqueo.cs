using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bloqueo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaBloqueo",
                table: "Usuario");

            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "Usuario");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBloqueo",
                table: "Usuario",
                type: "datetime2",
                nullable: true);
        }
    }
}
