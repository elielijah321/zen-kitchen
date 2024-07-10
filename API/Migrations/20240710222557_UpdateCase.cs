using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "dbo",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Address_Line1",
                schema: "dbo",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                schema: "dbo",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Cases",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "dbo",
                table: "Cases",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "dbo",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line1",
                schema: "dbo",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                schema: "dbo",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
