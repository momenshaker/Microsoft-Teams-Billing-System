using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class UpdateRecordCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "recordsTables",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "recordsTables");
        }
    }
}
