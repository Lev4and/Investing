using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investing.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdditionalIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_products_capitalization",
                table: "products",
                column: "capitalization");

            migrationBuilder.CreateIndex(
                name: "ix_product_prices_high",
                table: "product_prices",
                column: "high");

            migrationBuilder.CreateIndex(
                name: "ix_product_prices_low",
                table: "product_prices",
                column: "low");

            migrationBuilder.CreateIndex(
                name: "ix_product_prices_open",
                table: "product_prices",
                column: "open");

            migrationBuilder.CreateIndex(
                name: "ix_product_prices_volume",
                table: "product_prices",
                column: "volume");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_products_capitalization",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_product_prices_high",
                table: "product_prices");

            migrationBuilder.DropIndex(
                name: "ix_product_prices_low",
                table: "product_prices");

            migrationBuilder.DropIndex(
                name: "ix_product_prices_open",
                table: "product_prices");

            migrationBuilder.DropIndex(
                name: "ix_product_prices_volume",
                table: "product_prices");
        }
    }
}
