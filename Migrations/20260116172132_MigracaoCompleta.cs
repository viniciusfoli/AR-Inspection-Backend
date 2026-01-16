using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARinspection.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Temperatura = table.Column<double>(type: "REAL", nullable: false),
                    Vibracao = table.Column<double>(type: "REAL", nullable: false),
                    Instrucao = table.Column<string>(type: "TEXT", nullable: true),
                    HistoricoJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
