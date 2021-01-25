using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class UpdateCaller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallerNumber",
                table: "recordsTables",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncomingPhone",
                table: "recordsTables",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallerNumber",
                table: "recordsTables");

            migrationBuilder.DropColumn(
                name: "IncomingPhone",
                table: "recordsTables");
        }
    }
}
