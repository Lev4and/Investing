using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investing.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedDividendEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_dividends",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(name: "product_id", type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    yield = table.Column<decimal>(type: "numeric", nullable: true),
                    closeprice = table.Column<decimal>(name: "close_price", type: "numeric", nullable: false),
                    dividendvalue = table.Column<decimal>(name: "dividend_value", type: "numeric", nullable: false),
                    lastbuyday = table.Column<DateTime>(name: "last_buy_day", type: "timestamp with time zone", nullable: false),
                    closingdate = table.Column<DateTime>(name: "closing_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_dividends", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_dividends_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_close_price",
                table: "product_dividends",
                column: "close_price");

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_closing_date",
                table: "product_dividends",
                column: "closing_date");

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_dividend_value",
                table: "product_dividends",
                column: "dividend_value");

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_last_buy_day",
                table: "product_dividends",
                column: "last_buy_day");

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_product_id",
                table: "product_dividends",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_title",
                table: "product_dividends",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_product_dividends_yield",
                table: "product_dividends",
                column: "yield");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_dividends");
        }
    }
}
