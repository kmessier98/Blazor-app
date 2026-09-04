using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameUtilisateurToMembre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Utilisateur_UtilisateurId",
                table: "Emprunt");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "Emprunt",
                newName: "MembreId");

            migrationBuilder.RenameIndex(
                name: "IX_Emprunt_UtilisateurId",
                table: "Emprunt",
                newName: "IX_Emprunt_MembreId");

            migrationBuilder.CreateTable(
                name: "Membre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membre", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Membre",
                columns: new[] { "Id", "Courriel", "Nom" },
                values: new object[,]
                {
                    { 1, "marc.tremblay@example.com", "Marc Tremblay" },
                    { 2, "julie.bouchard@example.com", "Julie Bouchard" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Membre_MembreId",
                table: "Emprunt",
                column: "MembreId",
                principalTable: "Membre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Membre_MembreId",
                table: "Emprunt");

            migrationBuilder.DropTable(
                name: "Membre");

            migrationBuilder.RenameColumn(
                name: "MembreId",
                table: "Emprunt",
                newName: "UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Emprunt_MembreId",
                table: "Emprunt",
                newName: "IX_Emprunt_UtilisateurId");

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Courriel", "Nom" },
                values: new object[,]
                {
                    { 1, "marc.tremblay@example.com", "Marc Tremblay" },
                    { 2, "julie.bouchard@example.com", "Julie Bouchard" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Utilisateur_UtilisateurId",
                table: "Emprunt",
                column: "UtilisateurId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
