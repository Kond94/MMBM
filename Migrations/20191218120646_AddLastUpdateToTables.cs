using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mmbm.Migrations
{
    public partial class AddLastUpdateToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Simcards",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Shops",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "MobileMoneyReports",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ConsolidatedReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Simcards");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "MobileMoneyReports");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ConsolidatedReports");
        }
    }
}
