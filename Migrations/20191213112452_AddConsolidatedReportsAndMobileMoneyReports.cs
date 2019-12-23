using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace mmbm.Migrations
{
    public partial class AddConsolidatedReportsAndMobileMoneyReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileMoneyReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OpeningEvalue = table.Column<double>(nullable: false),
                    OpeningCash = table.Column<double>(nullable: false),
                    SentInEvalue = table.Column<double>(nullable: false),
                    SentInCash = table.Column<double>(nullable: false),
                    SentOutEvalue = table.Column<double>(nullable: false),
                    SentOutCash = table.Column<double>(nullable: false),
                    ClosingEvalue = table.Column<double>(nullable: false),
                    ClosingCash = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileMoneyReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsolidatedReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    MoblileMoneyReportId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsolidatedReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsolidatedReport_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsolidatedReport_MobileMoneyReport_MoblileMoneyReportId",
                        column: x => x.MoblileMoneyReportId,
                        principalTable: "MobileMoneyReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReport_EmployeeId",
                table: "ConsolidatedReport",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReport_MoblileMoneyReportId",
                table: "ConsolidatedReport",
                column: "MoblileMoneyReportId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsolidatedReport");

            migrationBuilder.DropTable(
                name: "MobileMoneyReport");
        }
    }
}
