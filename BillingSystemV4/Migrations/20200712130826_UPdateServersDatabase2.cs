using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingSystemV4.Migrations
{
    public partial class UPdateServersDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Server",
                table: "SubPhones",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ServerName",
                table: "SubPhones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerName",
                table: "recordsTables",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Server",
                table: "SubPhones");

            migrationBuilder.DropColumn(
                name: "ServerName",
                table: "SubPhones");

            migrationBuilder.DropColumn(
                name: "ServerName",
                table: "recordsTables");
        }
    }
}
