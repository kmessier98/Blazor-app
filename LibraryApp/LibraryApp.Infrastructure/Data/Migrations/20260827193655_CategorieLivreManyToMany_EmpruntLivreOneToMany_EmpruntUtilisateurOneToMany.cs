using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategorieLivreManyToMany_EmpruntLivreOneToMany_EmpruntUtilisateurOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEmprunt",
                table: "Emprunt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRetour",
                table: "Emprunt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LivreId",
                table: "Emprunt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId",
                table: "Emprunt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CategorieLivre",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    LivresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieLivre", x => new { x.CategoriesId, x.LivresId });
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Categorie_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieLivre_Livre_LivresId",
                        column: x => x.LivresId,
                        principalTable: "Livre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprunt_LivreId",
                table: "Emprunt",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunt_UtilisateurId",
                table: "Emprunt",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieLivre_LivresId",
                table: "CategorieLivre",
                column: "LivresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Utilisateur_UtilisateurId",
                table: "Emprunt",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Livre_LivreId",
                table: "Emprunt");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Utilisateur_UtilisateurId",
                table: "Emprunt");

            migrationBuilder.DropTable(
                name: "CategorieLivre");

            migrationBuilder.DropIndex(
                name: "IX_Emprunt_LivreId",
                table: "Emprunt");

            migrationBuilder.DropIndex(
                name: "IX_Emprunt_UtilisateurId",
                table: "Emprunt");

            migrationBuilder.DropColumn(
                name: "DateEmprunt",
                table: "Emprunt");

            migrationBuilder.DropColumn(
                name: "DateRetour",
                table: "Emprunt");

            migrationBuilder.DropColumn(
                name: "LivreId",
                table: "Emprunt");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "Emprunt");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Categorie");
        }
    }
}
