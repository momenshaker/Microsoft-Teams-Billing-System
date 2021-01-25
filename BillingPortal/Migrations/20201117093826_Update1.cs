using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingPortal.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SubscriptionChecker");
        }
    }
}
