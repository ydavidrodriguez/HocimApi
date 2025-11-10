using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PrecioReferencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioOferta",
                table: "ItemDetalle");

            migrationBuilder.AddColumn<int>(
                name: "PrecioReferencia",
                table: "Rfx",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "valorUnidad",
                table: "ItemDetalle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "VisualizacionPrecioProveedor",
                table: "ItemDetalle",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioReferencia",
                table: "Rfx");

            migrationBuilder.DropColumn(
                name: "VisualizacionPrecioProveedor",
                table: "ItemDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "valorUnidad",
                table: "ItemDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrecioOferta",
                table: "ItemDetalle",
                type: "int",
                nullable: true);
        }
    }
}
