using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClinic_CodeFirst_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPaciente",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Consulta");
        }
    }
}
