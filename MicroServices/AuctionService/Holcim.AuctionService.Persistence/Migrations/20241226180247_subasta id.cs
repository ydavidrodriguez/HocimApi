using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.AuctionService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class subastaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPreciosId",
                table: "Subasta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TipoPreciosId",
                table: "Subasta",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
