using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RecipeItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 12, 43, 21, 766, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 12, 43, 21, 766, DateTimeKind.Utc).AddTicks(4944));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(5424))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Setting", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { new Guid("a74feeb4-f3e5-4b85-aef9-6b6b9e482a1f"), "Current Menu", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RecipeItems",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 12, 43, 21, 766, DateTimeKind.Utc).AddTicks(4431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 20, 12, 43, 21, 766, DateTimeKind.Utc).AddTicks(4944),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2129));
        }
    }
}
