using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClinic_CodeFirst_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmacao",
                table: "Consulta",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmacao",
                table: "Consulta");
        }
    }
}
