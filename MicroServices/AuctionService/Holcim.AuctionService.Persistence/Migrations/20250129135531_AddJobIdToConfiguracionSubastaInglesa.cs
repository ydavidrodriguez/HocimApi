using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddJobIdToConfiguracionSubastaInglesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobIdFin",
                table: "ConfiguracionSubastaInglesa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobIdInicio",
                table: "ConfiguracionSubastaInglesa",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobIdFin",
                table: "ConfiguracionSubastaInglesa");

            migrationBuilder.DropColumn(
                name: "JobIdInicio",
                table: "ConfiguracionSubastaInglesa");
        }
    }
}
