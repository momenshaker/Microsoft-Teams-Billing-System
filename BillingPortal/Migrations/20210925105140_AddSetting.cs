using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingPortal.Migrations
{
    public partial class AddSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionChecker");

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    TID = table.Column<string>(nullable: true),
                    OID = table.Column<string>(nullable: true),
                    Sec = table.Column<string>(nullable: true),
                    AID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.CreateTable(
                name: "SubscriptionChecker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CheckedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidateToken = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionChecker", x => x.Id);
                });
        }
    }
}
