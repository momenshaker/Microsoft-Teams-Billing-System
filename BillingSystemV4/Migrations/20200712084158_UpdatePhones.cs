using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class UpdatePhones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerMinuteOfSecund",
                table: "SubPhones");

            migrationBuilder.DropColumn(
                name: "PerMinuteOfSecund",
                table: "country");

            migrationBuilder.AddColumn<bool>(
                name: "PerMinute",
                table: "SubPhones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PerSecond",
                table: "SubPhones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PerMinute",
                table: "country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PerSecond",
                table: "country",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerMinute",
                table: "SubPhones");

            migrationBuilder.DropColumn(
                name: "PerSecond",
                table: "SubPhones");

            migrationBuilder.DropColumn(
                name: "PerMinute",
                table: "country");

            migrationBuilder.DropColumn(
                name: "PerSecond",
                table: "country");

            migrationBuilder.AddColumn<bool>(
                name: "PerMinuteOfSecund",
                table: "SubPhones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PerMinuteOfSecund",
                table: "country",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
