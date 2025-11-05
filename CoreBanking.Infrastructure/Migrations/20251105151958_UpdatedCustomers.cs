using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreBanking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("c3d4e5f6-3456-7890-cde1-345678901cde"),
                column: "DateOpened",
                value: new DateTime(2025, 10, 16, 15, 19, 57, 967, DateTimeKind.Utc).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a1b2c3d4-1234-5678-9abc-123456789abc"),
                columns: new[] { "Address", "DateCreated", "DateOfBirth" },
                values: new object[] { "no 6 alakija", new DateTime(2025, 10, 6, 15, 19, 57, 966, DateTimeKind.Utc).AddTicks(2491), new DateOnly(2025, 11, 17) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("c3d4e5f6-3456-7890-cde1-345678901cde"),
                column: "DateOpened",
                value: new DateTime(2025, 10, 16, 14, 8, 40, 358, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a1b2c3d4-1234-5678-9abc-123456789abc"),
                column: "DateCreated",
                value: new DateTime(2025, 10, 6, 14, 8, 40, 356, DateTimeKind.Utc).AddTicks(1990));
        }
    }
}
