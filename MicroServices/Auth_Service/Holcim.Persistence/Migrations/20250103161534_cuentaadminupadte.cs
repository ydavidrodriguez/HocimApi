using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cuentaadminupadte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAdmin_Cargo_CargoId",
                table: "CuentaAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAdmin_Dependencia_DepartamentoId",
                table: "CuentaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_CuentaAdmin_CargoId",
                table: "CuentaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_CuentaAdmin_DepartamentoId",
                table: "CuentaAdmin");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "CuentaAdmin");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "CuentaAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CargoId",
                table: "CuentaAdmin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartamentoId",
                table: "CuentaAdmin",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAdmin_CargoId",
                table: "CuentaAdmin",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAdmin_DepartamentoId",
                table: "CuentaAdmin",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAdmin_Cargo_CargoId",
                table: "CuentaAdmin",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "IdCargo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAdmin_Dependencia_DepartamentoId",
                table: "CuentaAdmin",
                column: "DepartamentoId",
                principalTable: "Dependencia",
                principalColumn: "IdDepartamento");
        }
    }
}
