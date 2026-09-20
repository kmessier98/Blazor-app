using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEstDisponibleFromLivre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstDisponible",
                table: "Livre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstDisponible",
                table: "Livre",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstDisponible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 2,
                column: "EstDisponible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 3,
                column: "EstDisponible",
                value: false);

            migrationBuilder.UpdateData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 4,
                column: "EstDisponible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Livre",
                keyColumn: "Id",
                keyValue: 5,
                column: "EstDisponible",
                value: true);
        }
    }
}
