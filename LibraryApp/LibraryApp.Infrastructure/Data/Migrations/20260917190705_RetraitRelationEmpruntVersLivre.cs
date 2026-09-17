using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RetraitRelationEmpruntVersLivre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt");

            migrationBuilder.DropIndex(
                name: "IX_Emprunt_LivreId",
                table: "Emprunt");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Emprunt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivreId",
                table: "Emprunt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 1,
                column: "LivreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 2,
                column: "LivreId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 3,
                column: "LivreId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Emprunt_LivreId",
                table: "Emprunt",
                column: "LivreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
