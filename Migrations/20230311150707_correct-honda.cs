using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsApi.Migrations
{
    /// <inheritdoc />
    public partial class correcthonda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "color", "make", "model" },
                values: new object[] { "Red", "Honda", "Civic" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "color", "make", "model" },
                values: new object[] { "Civic", "Toyota", "Honda" });
        }
    }
}
