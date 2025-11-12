using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreBanking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("c3d4e5f6-3456-7890-cde1-345678901cde"),
                column: "DateOpened",
                value: new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a1b2c3d4-1234-5678-9abc-123456789abc"),
                columns: new[] { "Address", "BVN", "CreditScore", "DateCreated", "DateOfBirth" },
                values: new object[] { "10 town planning way", "20000000009", 40, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("c3d4e5f6-3456-7890-cde1-345678901cde"),
                column: "DateOpened",
                value: new DateTime(2025, 10, 17, 16, 1, 45, 115, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("a1b2c3d4-1234-5678-9abc-123456789abc"),
                columns: new[] { "Address", "BVN", "CreditScore", "DateCreated", "DateOfBirth" },
                values: new object[] { "no 6 alakija", "123456789", 20, new DateTime(2025, 10, 7, 16, 1, 45, 114, DateTimeKind.Utc).AddTicks(8953), new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
