using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class AddServers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ServerName = table.Column<string>(nullable: true),
                    ServerIP = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
