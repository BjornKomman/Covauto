using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Covauto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateRittenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ritten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    GebruikerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeginAdres = table.Column<string>(type: "TEXT", nullable: false),
                    EindAdres = table.Column<string>(type: "TEXT", nullable: false),
                    BeginKmStand = table.Column<int>(type: "INTEGER", nullable: false),
                    EindKmStand = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ritten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naamAuto = table.Column<string>(type: "TEXT", nullable: false),
                    kilometerstand = table.Column<int>(type: "INTEGER", nullable: false),
                    startAdres = table.Column<string>(type: "TEXT", nullable: false),
                    eindAdres = table.Column<string>(type: "TEXT", nullable: false),
                    beschikbaarheid = table.Column<bool>(type: "INTEGER", nullable: false),
                    publicatieJaar = table.Column<int>(type: "INTEGER", nullable: false),
                    GebruikerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gebruikers",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, "Mark J. Prijs" },
                    { 2, "Joseph Albahari" }
                });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id", "GebruikerId", "beschikbaarheid", "eindAdres", "kilometerstand", "naamAuto", "publicatieJaar", "startAdres" },
                values: new object[,]
                {
                    { 1, 1, true, "alweer koeweide", 2023, "BMW", 0, "Koeweide" },
                    { 2, 2, true, "alweer Schaapweide", 2022223, "BMW2", 0, "Schaapweide" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_GebruikerId",
                table: "Autos",
                column: "GebruikerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Ritten");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
