using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestrictDeleteOnEmprunt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Membre_MembreId",
                table: "Emprunt");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Membre_MembreId",
                table: "Emprunt",
                column: "MembreId",
                principalTable: "Membre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Membre_MembreId",
                table: "Emprunt");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Membre_MembreId",
                table: "Emprunt",
                column: "MembreId",
                principalTable: "Membre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
