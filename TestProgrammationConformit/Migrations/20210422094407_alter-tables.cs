using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProgrammationConformit.Migrations
{
    public partial class altertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Evenements_EvenementId",
                table: "Commentaires");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Evenements_EvenementId",
                table: "Commentaires",
                column: "EvenementId",
                principalTable: "Evenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Evenements_EvenementId",
                table: "Commentaires");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Evenements_EvenementId",
                table: "Commentaires",
                column: "EvenementId",
                principalTable: "Evenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
