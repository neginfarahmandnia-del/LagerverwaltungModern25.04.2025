using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagerverwaltungModern25._04._2025.Migrations
{
    /// <inheritdoc />
    public partial class AddWarenausgangCleaned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warenausgänge_Artikel_ArtikelId",
                table: "Warenausgänge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warenausgänge",
                table: "Warenausgänge");

            migrationBuilder.RenameTable(
                name: "Warenausgänge",
                newName: "Warenausgaenge");

            migrationBuilder.RenameIndex(
                name: "IX_Warenausgänge_ArtikelId",
                table: "Warenausgaenge",
                newName: "IX_Warenausgaenge_ArtikelId");

            migrationBuilder.AddColumn<int>(
                name: "Mindestbestand",
                table: "Artikel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Ausgangsdatum",
                table: "Warenausgaenge",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BenutzerId",
                table: "Warenausgaenge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kommentar",
                table: "Warenausgaenge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warenausgaenge",
                table: "Warenausgaenge",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warenausgaenge_BenutzerId",
                table: "Warenausgaenge",
                column: "BenutzerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warenausgaenge_Artikel_ArtikelId",
                table: "Warenausgaenge",
                column: "ArtikelId",
                principalTable: "Artikel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warenausgaenge_Benutzer_BenutzerId",
                table: "Warenausgaenge",
                column: "BenutzerId",
                principalTable: "Benutzer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warenausgaenge_Artikel_ArtikelId",
                table: "Warenausgaenge");

            migrationBuilder.DropForeignKey(
                name: "FK_Warenausgaenge_Benutzer_BenutzerId",
                table: "Warenausgaenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warenausgaenge",
                table: "Warenausgaenge");

            migrationBuilder.DropIndex(
                name: "IX_Warenausgaenge_BenutzerId",
                table: "Warenausgaenge");

            migrationBuilder.DropColumn(
                name: "Mindestbestand",
                table: "Artikel");

            migrationBuilder.DropColumn(
                name: "Ausgangsdatum",
                table: "Warenausgaenge");

            migrationBuilder.DropColumn(
                name: "BenutzerId",
                table: "Warenausgaenge");

            migrationBuilder.DropColumn(
                name: "Kommentar",
                table: "Warenausgaenge");

            migrationBuilder.RenameTable(
                name: "Warenausgaenge",
                newName: "Warenausgänge");

            migrationBuilder.RenameIndex(
                name: "IX_Warenausgaenge_ArtikelId",
                table: "Warenausgänge",
                newName: "IX_Warenausgänge_ArtikelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warenausgänge",
                table: "Warenausgänge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warenausgänge_Artikel_ArtikelId",
                table: "Warenausgänge",
                column: "ArtikelId",
                principalTable: "Artikel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
