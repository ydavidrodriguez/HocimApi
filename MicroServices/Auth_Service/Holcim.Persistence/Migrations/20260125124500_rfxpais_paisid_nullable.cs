using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    public partial class rfxpais_paisid_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfxPais_Pais_PaisId",
                table: "RfxPais");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaisId",
                table: "RfxPais",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_RfxPais_Pais_PaisId",
                table: "RfxPais",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "IdPais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfxPais_Pais_PaisId",
                table: "RfxPais");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaisId",
                table: "RfxPais",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RfxPais_Pais_PaisId",
                table: "RfxPais",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "IdPais",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
