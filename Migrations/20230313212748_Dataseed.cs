using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsApi.Migrations
{
    /// <inheritdoc />
    public partial class Dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "color", "make", "model", "price", "year" },
                values: new object[,]
                {
                    { 5, "Bronze", "Mazda", "mazda-2", 150000.0, 2015 },
                    { 6, "Yellow", "Toyota", "Campry", 50000.0, 2002 },
                    { 7, "Red", "BMW", "X6", 500000.0, 2019 },
                    { 8, "White", "Mercedes", "A200", 900000.0, 2020 },
                    { 9, "Grey", "Audi", "A3", 500000.0, 2019 },
                    { 10, "Blue", "Audi", "S3", 1500000.0, 2023 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "color", "make", "model", "price", "year" },
                values: new object[,]
                {
                    { 1, "Silver", "Toyota", "Yaris", 250000.0, 2023 },
                    { 2, "Red", "Honda", "Civic", 500000.0, 2019 }
                });
        }
    }
}
