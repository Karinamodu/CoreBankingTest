using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreBanking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBvn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "BVN",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreditScore",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "BVN", "CreditScore", "DateCreated", "DateOfBirth" },
                values: new object[] { "123456789", 20, new DateTime(2025, 10, 7, 16, 1, 45, 114, DateTimeKind.Utc).AddTicks(8953), new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BVN",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditScore",
                table: "Customers");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Customers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                columns: new[] { "DateCreated", "DateOfBirth" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 19, 57, 966, DateTimeKind.Utc).AddTicks(2491), new DateOnly(2025, 11, 17) });
        }
    }
}
