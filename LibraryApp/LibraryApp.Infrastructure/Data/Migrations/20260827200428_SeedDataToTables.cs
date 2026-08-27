using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteursId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livre_LivresId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorieLivre_Categorie_CategoriesId",
                table: "CategorieLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorieLivre_Livre_LivresId",
                table: "CategorieLivre");

            migrationBuilder.RenameColumn(
                name: "LivresId",
                table: "CategorieLivre",
                newName: "LivreId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategorieLivre",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorieLivre_LivresId",
                table: "CategorieLivre",
                newName: "IX_CategorieLivre_LivreId");

            migrationBuilder.RenameColumn(
                name: "LivresId",
                table: "AuteurLivre",
                newName: "LivreId");

            migrationBuilder.RenameColumn(
                name: "AuteursId",
                table: "AuteurLivre",
                newName: "AuteurId");

            migrationBuilder.RenameIndex(
                name: "IX_AuteurLivre_LivresId",
                table: "AuteurLivre",
                newName: "IX_AuteurLivre_LivreId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetour",
                table: "Emprunt",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Auteur",
                columns: new[] { "Id", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "Herbert", "Frank" },
                    { 2, "Asimov", "Isaac" },
                    { 3, "Gibson", "William" },
                    { 4, "Camus", "Albert" }
                });

            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Science-fiction" },
                    { 2, "Classique" },
                    { 3, "Cyberpunk" }
                });

            migrationBuilder.InsertData(
                table: "Editeur",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Éditions Robert Laffont" },
                    { 2, "Éditions J'ai lu" },
                    { 3, "Éditions Gallimard" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Courriel", "Nom" },
                values: new object[,]
                {
                    { 1, "marc.tremblay@example.com", "Marc Tremblay" },
                    { 2, "julie.bouchard@example.com", "Julie Bouchard" }
                });

            migrationBuilder.InsertData(
                table: "Livre",
                columns: new[] { "Id", "EditeurId", "EstDisponible", "Titre" },
                values: new object[,]
                {
                    { 1, 1, true, "Dune" },
                    { 2, 1, true, "Le Messie de Dune" },
                    { 3, 2, false, "Fondation" },
                    { 4, 2, true, "Neuromancien" },
                    { 5, 3, true, "L'Étranger" }
                });

            migrationBuilder.InsertData(
                table: "AuteurLivre",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "CategorieLivre",
                columns: new[] { "CategorieId", "LivreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Emprunt",
                columns: new[] { "Id", "DateEmprunt", "DateRetour", "LivreId", "UtilisateurId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteurId",
                table: "AuteurLivre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Livre_LivreId",
                table: "AuteurLivre",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorieLivre_Categorie_CategorieId",
                table: "CategorieLivre",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorieLivre_Livre_LivreId",
                table: "CategorieLivre",
                column: "LivreId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteurId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livre_LivreId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorieLivre_Categorie_CategorieId",
                table: "CategorieLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorieLivre_Livre_LivreId",
                table: "CategorieLivre");

            migrationBuilder.DeleteData(
                table: "AuteurLivre",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuteurLivre",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AuteurLivre",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AuteurLivre",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AuteurLivre",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CategorieLivre",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategorieLivre",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategorieLivre",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategorieLivre",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategorieLivre",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CategorieLivre",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auteur",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auteur",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auteur",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auteur",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Editeur",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Editeur",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Editeur",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "LivreId",
                table: "CategorieLivre",
                newName: "LivresId");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "CategorieLivre",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategorieLivre_LivreId",
                table: "CategorieLivre",
                newName: "IX_CategorieLivre_LivresId");

            migrationBuilder.RenameColumn(
                name: "LivreId",
                table: "AuteurLivre",
                newName: "LivresId");

            migrationBuilder.RenameColumn(
                name: "AuteurId",
                table: "AuteurLivre",
                newName: "AuteursId");

            migrationBuilder.RenameIndex(
                name: "IX_AuteurLivre_LivreId",
                table: "AuteurLivre",
                newName: "IX_AuteurLivre_LivresId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetour",
                table: "Emprunt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteursId",
                table: "AuteurLivre",
                column: "AuteursId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Livre_LivresId",
                table: "AuteurLivre",
                column: "LivresId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorieLivre_Categorie_CategoriesId",
                table: "CategorieLivre",
                column: "CategoriesId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorieLivre_Livre_LivresId",
                table: "CategorieLivre",
                column: "LivresId",
                principalTable: "Livre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
