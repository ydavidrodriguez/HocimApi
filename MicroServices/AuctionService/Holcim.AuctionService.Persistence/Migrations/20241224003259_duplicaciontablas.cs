using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class duplicaciontablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorSubasta_Proveedor_ProveedorId",
                table: "ProveedorSubasta");

            migrationBuilder.DropForeignKey(
                name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                table: "Subasta");

            migrationBuilder.DropTable(
                name: "PreguntaSobreSubasta");

            migrationBuilder.DropIndex(
                name: "IX_Subasta_TipoPreciosId",
                table: "Subasta");

            migrationBuilder.DropIndex(
                name: "IX_ProveedorSubasta_ProveedorId",
                table: "ProveedorSubasta");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "ProveedorSubasta");

            migrationBuilder.RenameColumn(
                name: "IdTipoPrecios",
                table: "TipoPrecios",
                newName: "IdTipoOferta");

            migrationBuilder.AlterColumn<int>(
                name: "PrecioReferencia",
                table: "Subasta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "Subasta",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFin",
                table: "Subasta",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "Directo",
                table: "Subasta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MejorOferta",
                table: "Subasta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TipoOfertaId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));


            migrationBuilder.CreateIndex(
                name: "IX_Subasta_TipoOfertaId",
                table: "Subasta",
                column: "TipoOfertaId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropIndex(
                name: "IX_Subasta_TipoOfertaId",
                table: "Subasta");

            migrationBuilder.DropColumn(
                name: "Directo",
                table: "Subasta");

            migrationBuilder.DropColumn(
                name: "MejorOferta",
                table: "Subasta");

            migrationBuilder.DropColumn(
                name: "TipoOfertaId",
                table: "Subasta");

            migrationBuilder.RenameColumn(
                name: "IdTipoOferta",
                table: "TipoPrecios",
                newName: "IdTipoPrecios");

            migrationBuilder.AlterColumn<int>(
                name: "PrecioReferencia",
                table: "Subasta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "Subasta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFin",
                table: "Subasta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "ProveedorSubasta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_Subasta_TipoPreciosId",
                table: "Subasta",
                column: "TipoPreciosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorSubasta_ProveedorId",
                table: "ProveedorSubasta",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaSobreSubasta_SubastaId",
                table: "PreguntaSobreSubasta",
                column: "SubastaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorSubasta_Proveedor_ProveedorId",
                table: "ProveedorSubasta",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Subasta_TipoPrecios_TipoPreciosId",
                table: "Subasta",
                column: "TipoPreciosId",
                principalTable: "TipoPrecios",
                principalColumn: "IdTipoPrecios");
        }
    }
}
