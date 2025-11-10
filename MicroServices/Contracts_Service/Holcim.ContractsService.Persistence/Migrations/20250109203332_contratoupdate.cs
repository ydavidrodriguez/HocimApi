using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.ContractsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class contratoupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Contrato",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Contrato");
        }
    }
}
