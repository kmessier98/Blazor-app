using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExemplaireChangeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstDisponible",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exemplaire",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstDisponible",
                value: true);
        }
    }
}
