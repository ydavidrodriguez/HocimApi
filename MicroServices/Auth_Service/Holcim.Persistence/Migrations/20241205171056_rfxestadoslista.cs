using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rfxestadoslista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MotivoId",
                table: "UsuarioReasignacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "MotivoEstado",
                table: "TrazabilidadRfx",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioReasignacion_MotivoId",
                table: "UsuarioReasignacion",
                column: "MotivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioReasignacion_Motivo_MotivoId",
                table: "UsuarioReasignacion",
                column: "MotivoId",
                principalTable: "Motivo",
                principalColumn: "IdMotivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioReasignacion_Motivo_MotivoId",
                table: "UsuarioReasignacion");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioReasignacion_MotivoId",
                table: "UsuarioReasignacion");

            migrationBuilder.DropColumn(
                name: "MotivoId",
                table: "UsuarioReasignacion");

            migrationBuilder.DropColumn(
                name: "MotivoEstado",
                table: "TrazabilidadRfx");
        }
    }
}
