using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClinic_CodeFirst_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioEncerramento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioEncerramento",
                table: "Clinica",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");
        }
    }
}
