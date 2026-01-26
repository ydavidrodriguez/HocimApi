using System;
using Holcim.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holcim.Persistence.Migrations
{
    [DbContext(typeof(DataBaseService))]
    [Migration("20260125130000_usuariootp_2fa")]
    public partial class usuariootp_2fa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioOtp",
                columns: table => new
                {
                    IdUsuarioOtp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOtp", x => x.IdUsuarioOtp);
                    table.ForeignKey(
                        name: "FK_UsuarioOtp_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOtp_UsuarioId",
                table: "UsuarioOtp",
                column: "UsuarioId");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM Correo WHERE Descripcion = '2FA')
BEGIN
    INSERT INTO Correo (IdCorreo, Descripcion, Html, Estado)
    VALUES (NEWID(), '2FA', '<h3>Código de verificación</h3><p>Hola {NOMBRE},</p><p>Tu código es: <strong>{CODE}</strong></p><p>Este código vence en 10 minutos.</p>', 1)
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Correo WHERE Descripcion = '2FA'");

            migrationBuilder.DropTable(
                name: "UsuarioOtp");
        }
    }
}
