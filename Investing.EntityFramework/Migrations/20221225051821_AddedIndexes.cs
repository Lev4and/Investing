using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investing.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_sectors_title",
                table: "sectors",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_products_class_code",
                table: "products",
                column: "class_code");

            migrationBuilder.CreateIndex(
                name: "ix_products_issuer",
                table: "products",
                column: "issuer");

            migrationBuilder.CreateIndex(
                name: "ix_products_secur_code",
                table: "products",
                column: "secur_code");

            migrationBuilder.CreateIndex(
                name: "ix_product_prices_closed_at",
                table: "product_prices",
                column: "closed_at");

            migrationBuilder.CreateIndex(
                name: "ix_portfolios_title",
                table: "portfolios",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_exchanges_title",
                table: "exchanges",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_currencies_title",
                table: "currencies",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_bond_types_title",
                table: "bond_types",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_assets_title",
                table: "assets",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_sectors_title",
                table: "sectors");

            migrationBuilder.DropIndex(
                name: "ix_products_class_code",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_issuer",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_secur_code",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_product_prices_closed_at",
                table: "product_prices");

            migrationBuilder.DropIndex(
                name: "ix_portfolios_title",
                table: "portfolios");

            migrationBuilder.DropIndex(
                name: "ix_exchanges_title",
                table: "exchanges");

            migrationBuilder.DropIndex(
                name: "ix_currencies_title",
                table: "currencies");

            migrationBuilder.DropIndex(
                name: "ix_bond_types_title",
                table: "bond_types");

            migrationBuilder.DropIndex(
                name: "ix_assets_title",
                table: "assets");
        }
    }
}
