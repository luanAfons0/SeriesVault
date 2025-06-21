using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeriesVault.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "id", "Platform", "Producer", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Netflix", "J. J. Abrams, Jeffrey Lieber, Damon Lindelof", "American Broadcasting Company", "Lost" },
                    { 2, "Netflix", "Michael C. Hall", "Showtime, CBS", "Dexter" },
                    { 3, "Netflix", "Helen Pai", "ABC in the United States", "The Rookie" },
                    { 4, "Amazon Prime", "Eric Kripke", "Dynamite Entertainment", "The Boys" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
