using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingPortal.Migrations
{
    public partial class Export2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ExportedFiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ExportedFiles");
        }
    }
}
