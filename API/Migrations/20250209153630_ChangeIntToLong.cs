using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ChangeIntToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(8049),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(8867));

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                schema: "dbo",
                table: "Recipes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(6708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(7665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RecipeItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(7399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(5170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(6016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(4503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(5054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(3787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(4105));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(8867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(8049));

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                schema: "dbo",
                table: "Recipes",
                type: "real",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(7665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(6708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RecipeItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(8365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(7399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(6065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(6783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(5054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 8, 35, 11, 68, DateTimeKind.Utc).AddTicks(4105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 36, 30, 664, DateTimeKind.Utc).AddTicks(3787));
        }
    }
}
