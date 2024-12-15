using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionBibilotheque.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DatePub", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", new DateOnly(2008, 8, 1), "Clean Code" },
                    { 2, "Andrew Hunt, David Thomas", new DateOnly(1999, 10, 20), "The Pragmatic Programmer" },
                    { 3, "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", new DateOnly(1994, 10, 31), "Design Patterns" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
