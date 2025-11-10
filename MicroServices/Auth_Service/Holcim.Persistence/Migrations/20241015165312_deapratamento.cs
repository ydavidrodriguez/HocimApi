using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deapratamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAdmin_Dependencia_DependenciaId",
                table: "CuentaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_CuentaAdmin_DependenciaId",
                table: "CuentaAdmin");

            migrationBuilder.DropColumn(
                name: "DependenciaId",
                table: "CuentaAdmin");

            migrationBuilder.RenameColumn(
                name: "IdDependencia",
                table: "Dependencia",
                newName: "IdDepartamento");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartamentoId",
                table: "CuentaAdmin",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAdmin_DepartamentoId",
                table: "CuentaAdmin",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAdmin_Dependencia_DepartamentoId",
                table: "CuentaAdmin",
                column: "DepartamentoId",
                principalTable: "Dependencia",
                principalColumn: "IdDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaAdmin_Dependencia_DepartamentoId",
                table: "CuentaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_CuentaAdmin_DepartamentoId",
                table: "CuentaAdmin");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "CuentaAdmin");

            migrationBuilder.RenameColumn(
                name: "IdDepartamento",
                table: "Dependencia",
                newName: "IdDependencia");

            migrationBuilder.AddColumn<Guid>(
                name: "DependenciaId",
                table: "CuentaAdmin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CuentaAdmin_DependenciaId",
                table: "CuentaAdmin",
                column: "DependenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaAdmin_Dependencia_DependenciaId",
                table: "CuentaAdmin",
                column: "DependenciaId",
                principalTable: "Dependencia",
                principalColumn: "IdDependencia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
