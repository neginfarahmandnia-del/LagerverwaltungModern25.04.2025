using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagerverwaltungModern25._04._2025.Migrations
{
    /// <inheritdoc />
    public partial class AddMindestbestandToArtikel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warenausgaenge_Benutzer_BenutzerId",
                table: "Warenausgaenge");

            migrationBuilder.AlterColumn<int>(
                name: "BenutzerId",
                table: "Warenausgaenge",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Warenausgaenge_Benutzer_BenutzerId",
                table: "Warenausgaenge",
                column: "BenutzerId",
                principalTable: "Benutzer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warenausgaenge_Benutzer_BenutzerId",
                table: "Warenausgaenge");

            migrationBuilder.AlterColumn<int>(
                name: "BenutzerId",
                table: "Warenausgaenge",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Warenausgaenge_Benutzer_BenutzerId",
                table: "Warenausgaenge",
                column: "BenutzerId",
                principalTable: "Benutzer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
