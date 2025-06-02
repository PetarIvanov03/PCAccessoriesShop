﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCAccessoriesShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceAtPurchase",
                table: "OrderItems",
                newName: "UnitPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderItems",
                newName: "PriceAtPurchase");
        }
    }
}
