using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LagerverwaltungModern25._04._2025.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OberkategorieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategorien_Kategorien_OberkategorieId",
                        column: x => x.OberkategorieId,
                        principalTable: "Kategorien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rollen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bestand = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    KategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artikel_Kategorien_KategorieId",
                        column: x => x.KategorieId,
                        principalTable: "Kategorien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Benutzername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benutzer_Rollen_RolleId",
                        column: x => x.RolleId,
                        principalTable: "Rollen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warenausgänge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warenausgänge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warenausgänge_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestellungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    Bestelldatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestellungen_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bestellungen_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorien",
                columns: new[] { "Id", "Name", "OberkategorieId" },
                values: new object[,]
                {
                    { 1, "Elektronik", null },
                    { 2, "Werkzeuge", null }
                });

            migrationBuilder.InsertData(
                table: "Rollen",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Manager" },
                    { 3, "Mitarbeiter" },
                    { 4, "Lagerleiter" },
                    { 5, "Buchhaltung" },
                    { 6, "Gast" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_KategorieId",
                table: "Artikel",
                column: "KategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Benutzer_RolleId",
                table: "Benutzer",
                column: "RolleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellungen_ArtikelId",
                table: "Bestellungen",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellungen_BenutzerId",
                table: "Bestellungen",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorien_OberkategorieId",
                table: "Kategorien",
                column: "OberkategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Warenausgänge_ArtikelId",
                table: "Warenausgänge",
                column: "ArtikelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellungen");

            migrationBuilder.DropTable(
                name: "Warenausgänge");

            migrationBuilder.DropTable(
                name: "Benutzer");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Rollen");

            migrationBuilder.DropTable(
                name: "Kategorien");
        }
    }
}
