using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClinic_CodeFirst_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Prontuario_IdProntuario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdProntuario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdProntuario",
                table: "Consulta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdProntuario",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdProntuario",
                table: "Consulta",
                column: "IdProntuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Prontuario_IdProntuario",
                table: "Consulta",
                column: "IdProntuario",
                principalTable: "Prontuario",
                principalColumn: "IdProntuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
