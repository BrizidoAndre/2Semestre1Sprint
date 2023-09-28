using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClinic_CodeFirst_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPerfil",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_IdPerfil",
                table: "Usuario",
                column: "IdPerfil",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_IdPerfil",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdPerfil",
                table: "Usuario");
        }
    }
}
