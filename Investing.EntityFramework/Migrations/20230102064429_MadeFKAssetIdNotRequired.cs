using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investing.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MadeFKAssetIdNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_assets_asset_id",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "asset_id",
                table: "products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_products_assets_asset_id",
                table: "products",
                column: "asset_id",
                principalTable: "assets",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_assets_asset_id",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "asset_id",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_products_assets_asset_id",
                table: "products",
                column: "asset_id",
                principalTable: "assets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
