using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreBanking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressAndDateOfBirthToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Customers",
                type: "date",
                maxLength: 10,
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("c3d4e5f6-3456-7890-cde1-345678901cde"),
                column: "DateOpened",
                value: new DateTime(2025, 10, 16, 1, 35, 32, 79, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a1b2c3d4-1234-5678-9abc-123456789abc"),
                columns: new[] { "Address", "DateCreated", "DateOfBirth" },
                values: new object[] { "no 6 alakija", new DateTime(2025, 10, 6, 1, 35, 32, 76, DateTimeKind.Utc).AddTicks(7823), new DateOnly(2025, 11, 17) });
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
                value: new DateTime(2025, 10, 15, 14, 13, 26, 846, DateTimeKind.Utc).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a1b2c3d4-1234-5678-9abc-123456789abc"),
                column: "DateCreated",
                value: new DateTime(2025, 10, 5, 14, 13, 26, 845, DateTimeKind.Utc).AddTicks(4852));
        }
    }
}
