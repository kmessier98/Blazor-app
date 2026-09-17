using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationExemplaireEmprunt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExemplaireId",
                table: "Emprunt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExemplaireId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExemplaireId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emprunt",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExemplaireId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Exemplaire",
                columns: new[] { "Id", "CodeBarre", "EstDisponible", "LivreId" },
                values: new object[,]
                {
                    { 1, "DUNE-001", true, 1 },
                    { 2, "DUNE-002", true, 1 },
                    { 3, "MESSIE-001", true, 2 },
                    { 4, "FONDATION-001", false, 3 },
                    { 5, "NEURO-001", true, 4 },
                    { 6, "ETRANGER-001", true, 5 }
                });

            // Rattache les emprunts créés manuellement en dev (hors les 3 lignes seedées ci-dessus)
            // à un exemplaire du même livre, sinon la contrainte FK ci-dessous échoue.
            migrationBuilder.Sql(@"
                UPDATE e
                SET e.ExemplaireId = (SELECT TOP 1 ex.Id FROM Exemplaire ex WHERE ex.LivreId = e.LivreId)
                FROM Emprunt e
                WHERE NOT EXISTS (SELECT 1 FROM Exemplaire ex WHERE ex.Id = e.ExemplaireId);
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunt_ExemplaireId",
                table: "Emprunt",
                column: "ExemplaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Exemplaire_ExemplaireId",
                table: "Emprunt",
                column: "ExemplaireId",
                principalTable: "Exemplaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Exemplaire_ExemplaireId",
                table: "Emprunt");

            migrationBuilder.DropIndex(
                name: "IX_Emprunt_ExemplaireId",
                table: "Emprunt");

            migrationBuilder.DeleteData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ExemplaireId",
                table: "Emprunt");
        }
    }
}
