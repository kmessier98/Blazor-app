using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteursId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livres_LivresId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_Livres_Editeurs_EditeurId",
                table: "Livres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilisateurs",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livres",
                table: "Livres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editeurs",
                table: "Editeurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs");

            migrationBuilder.RenameTable(
                name: "Utilisateurs",
                newName: "Utilisateur");

            migrationBuilder.RenameTable(
                name: "Livres",
                newName: "Livre");

            migrationBuilder.RenameTable(
                name: "Emprunts",
                newName: "Emprunt");

            migrationBuilder.RenameTable(
                name: "Editeurs",
                newName: "Editeur");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorie");

            migrationBuilder.RenameTable(
                name: "Auteurs",
                newName: "Auteur");

            migrationBuilder.RenameIndex(
                name: "IX_Livres_EditeurId",
                table: "Livre",
                newName: "IX_Livre_EditeurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilisateur",
                table: "Utilisateur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livre",
                table: "Livre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunt",
                table: "Emprunt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editeur",
                table: "Editeur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur",
                column: "Id");

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
                name: "FK_Livre_Editeur_EditeurId",
                table: "Livre",
                column: "EditeurId",
                principalTable: "Editeur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Auteur_AuteursId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_AuteurLivre_Livre_LivresId",
                table: "AuteurLivre");

            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Editeur_EditeurId",
                table: "Livre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilisateur",
                table: "Utilisateur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livre",
                table: "Livre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunt",
                table: "Emprunt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editeur",
                table: "Editeur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auteur",
                table: "Auteur");

            migrationBuilder.RenameTable(
                name: "Utilisateur",
                newName: "Utilisateurs");

            migrationBuilder.RenameTable(
                name: "Livre",
                newName: "Livres");

            migrationBuilder.RenameTable(
                name: "Emprunt",
                newName: "Emprunts");

            migrationBuilder.RenameTable(
                name: "Editeur",
                newName: "Editeurs");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Auteur",
                newName: "Auteurs");

            migrationBuilder.RenameIndex(
                name: "IX_Livre_EditeurId",
                table: "Livres",
                newName: "IX_Livres_EditeurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilisateurs",
                table: "Utilisateurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livres",
                table: "Livres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editeurs",
                table: "Editeurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auteurs",
                table: "Auteurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Auteurs_AuteursId",
                table: "AuteurLivre",
                column: "AuteursId",
                principalTable: "Auteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuteurLivre_Livres_LivresId",
                table: "AuteurLivre",
                column: "LivresId",
                principalTable: "Livres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livres_Editeurs_EditeurId",
                table: "Livres",
                column: "EditeurId",
                principalTable: "Editeurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
