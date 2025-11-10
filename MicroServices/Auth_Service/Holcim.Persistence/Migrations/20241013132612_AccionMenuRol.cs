using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AccionMenuRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RolId",
                table: "AccionesMenu",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMenu_RolId",
                table: "AccionesMenu",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccionesMenu_Rol_RolId",
                table: "AccionesMenu",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccionesMenu_Rol_RolId",
                table: "AccionesMenu");

            migrationBuilder.DropIndex(
                name: "IX_AccionesMenu_RolId",
                table: "AccionesMenu");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "AccionesMenu");
        }
    }
}
