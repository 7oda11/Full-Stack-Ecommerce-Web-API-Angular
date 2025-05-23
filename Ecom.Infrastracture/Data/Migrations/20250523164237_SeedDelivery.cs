using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Infrastracture.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "DeliveryTime", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Only a week", "The first delivery in the world", "DHL", 15m },
                    { 2, "2-3 business days", "Fast and reliable", "FedEx", 20m },
                    { 3, "Next day delivery", "Lightning fast delivery", "UPS", 25m },
                    { 4, "3-5 business days", "Economical shipping", "USPS", 10m },
                    { 5, "Same day delivery", "Express service", "Amazon Prime", 30m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
