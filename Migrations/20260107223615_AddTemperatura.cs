using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARinspection.Migrations
{
    /// <inheritdoc />
    public partial class AddTemperatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Temperatura",
                table: "people",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "people");
        }
    }
}
