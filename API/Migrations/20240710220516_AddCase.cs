using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__AuditLog",
                schema: "dbo",
                table: "Defendants");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Defendant",
                schema: "dbo",
                table: "Defendants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cases",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Case", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Defendant",
                schema: "dbo",
                table: "Defendants");

            migrationBuilder.AddPrimaryKey(
                name: "PK__AuditLog",
                schema: "dbo",
                table: "Defendants",
                column: "Id");
        }
    }
}
