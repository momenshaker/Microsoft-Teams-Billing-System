using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingPortal.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyServers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ServerName = table.Column<string>(nullable: true),
                    ServerIP = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    iso = table.Column<string>(nullable: true),
                    countryname = table.Column<string>(nullable: true),
                    nicename = table.Column<string>(nullable: true),
                    iso3 = table.Column<string>(nullable: true),
                    numcode = table.Column<int>(nullable: true),
                    phonecode = table.Column<int>(nullable: true),
                    SubPhones = table.Column<bool>(nullable: false),
                    CostPerMinute = table.Column<double>(nullable: true),
                    PerMinute = table.Column<bool>(nullable: false),
                    PerSecond = table.Column<bool>(nullable: false)
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
                    IncomingPhone = table.Column<bool>(nullable: false),
                    CallerId = table.Column<Guid>(nullable: false),
                    CallerName = table.Column<string>(nullable: true),
                    CallerTanent = table.Column<Guid>(nullable: false),
                    CallerNumber = table.Column<string>(nullable: true),
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
                    Country = table.Column<string>(nullable: true),
                    TotalCost = table.Column<double>(nullable: true),
                    ReflexiveIPAddress = table.Column<string>(nullable: true),
                    dnsSuffix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordsTables", x => x.ID);
                });

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
                    PerSecond = table.Column<bool>(nullable: false),
                    Server = table.Column<Guid>(nullable: false),
                    ServerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPhones", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyServers");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "recordsTables");

            migrationBuilder.DropTable(
                name: "SubPhones");
        }
    }
}
