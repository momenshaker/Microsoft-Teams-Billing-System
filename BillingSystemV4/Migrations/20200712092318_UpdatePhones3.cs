using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class UpdatePhones3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubPhones",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
                    ProviderName = table.Column<string>(nullable: true),
                    phonecode = table.Column<int>(nullable: true),
                    CostPerMinute = table.Column<double>(nullable: true),
                    PerMinute = table.Column<bool>(nullable: false),
                    PerSecond = table.Column<bool>(nullable: false)
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
        }
    }
}
