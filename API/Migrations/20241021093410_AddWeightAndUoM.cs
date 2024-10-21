using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddWeightAndUoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(2276),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(1269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RecipeItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(1787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 791, DateTimeKind.Utc).AddTicks(9583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasureMent",
                schema: "dbo",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                schema: "dbo",
                table: "Ingredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 791, DateTimeKind.Utc).AddTicks(9059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2129));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeasureMent",
                schema: "dbo",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "dbo",
                table: "Ingredients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(5424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RecipeItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 792, DateTimeKind.Utc).AddTicks(727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 791, DateTimeKind.Utc).AddTicks(9583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 9, 34, 10, 791, DateTimeKind.Utc).AddTicks(9059));
        }
    }
}
