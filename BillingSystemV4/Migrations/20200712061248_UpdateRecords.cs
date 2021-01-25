using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class UpdateRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReflexiveIPAddress",
                table: "recordsTables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dnsSuffix",
                table: "recordsTables",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PerMinuteOfSecund",
                table: "country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubPhones",
                table: "country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubPhones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(nullable: false),
                    ProviderName = table.Column<string>(nullable: true),
                    phonecode = table.Column<int>(nullable: true),
                    CostPerMinute = table.Column<double>(nullable: true),
                    PerMinuteOfSecund = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPhones", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubPhones");

            migrationBuilder.DropColumn(
                name: "ReflexiveIPAddress",
                table: "recordsTables");

            migrationBuilder.DropColumn(
                name: "dnsSuffix",
                table: "recordsTables");

            migrationBuilder.DropColumn(
                name: "PerMinuteOfSecund",
                table: "country");

            migrationBuilder.DropColumn(
                name: "SubPhones",
                table: "country");
        }
    }
}
