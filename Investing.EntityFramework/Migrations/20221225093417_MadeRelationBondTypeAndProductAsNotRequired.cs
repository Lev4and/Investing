using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investing.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MadeRelationBondTypeAndProductAsNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_bond_types_bond_type_id",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "bond_type_id",
                table: "products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_products_bond_types_bond_type_id",
                table: "products",
                column: "bond_type_id",
                principalTable: "bond_types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_bond_types_bond_type_id",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "bond_type_id",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_products_bond_types_bond_type_id",
                table: "products",
                column: "bond_type_id",
                principalTable: "bond_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
