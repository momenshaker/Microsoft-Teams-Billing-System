using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso = table.Column<string>(nullable: true),
                    countryname = table.Column<string>(nullable: true),
                    nicename = table.Column<string>(nullable: true),
                    iso3 = table.Column<string>(nullable: true),
                    numcode = table.Column<int>(nullable: false),
                    phonecode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recordsTables",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RecoredId = table.Column<Guid>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    startDateTime = table.Column<DateTimeOffset>(nullable: false),
                    endDateTime = table.Column<DateTimeOffset>(nullable: false),
                    CallerId = table.Column<Guid>(nullable: false),
                    CallerName = table.Column<string>(nullable: true),
                    CallerTanent = table.Column<Guid>(nullable: false),
                    Phone = table.Column<bool>(nullable: false),
                    CalleeNumber = table.Column<string>(nullable: true),
                    CalleeId = table.Column<Guid>(nullable: false),
                    CalleeName = table.Column<string>(nullable: true),
                    CalleeTanent = table.Column<Guid>(nullable: false),
                    SessionCallerPlatform = table.Column<string>(nullable: true),
                    SessionCallerProductFamily = table.Column<string>(nullable: true),
                    SessionCalleePlatform = table.Column<string>(nullable: true),
                    SessionCalleeProductFamily = table.Column<string>(nullable: true),
                    TotalTime = table.Column<double>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordsTables", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionChecker",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValidateToken = table.Column<string>(nullable: true),
                    CheckedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionChecker", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "recordsTables");

            migrationBuilder.DropTable(
                name: "SubscriptionChecker");
        }
    }
}
