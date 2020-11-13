using Microsoft.EntityFrameworkCore.Migrations;

namespace mmbm.Migrations
{
    public partial class FixConsolidatedReportMobileMoneyReportRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReport_MobileMoneyReport_MoblileMoneyReportId",
                table: "ConsolidatedReport");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReport_MoblileMoneyReportId",
                table: "ConsolidatedReport");

            migrationBuilder.DropColumn(
                name: "MoblileMoneyReportId",
                table: "ConsolidatedReport");

            migrationBuilder.AddColumn<int>(
                name: "ConsolidatedReportId",
                table: "MobileMoneyReport",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MobileMoneyReport_ConsolidatedReportId",
                table: "MobileMoneyReport",
                column: "ConsolidatedReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileMoneyReport_ConsolidatedReport_ConsolidatedReportId",
                table: "MobileMoneyReport",
                column: "ConsolidatedReportId",
                principalTable: "ConsolidatedReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileMoneyReport_ConsolidatedReport_ConsolidatedReportId",
                table: "MobileMoneyReport");

            migrationBuilder.DropIndex(
                name: "IX_MobileMoneyReport_ConsolidatedReportId",
                table: "MobileMoneyReport");

            migrationBuilder.DropColumn(
                name: "ConsolidatedReportId",
                table: "MobileMoneyReport");

            migrationBuilder.AddColumn<int>(
                name: "MoblileMoneyReportId",
                table: "ConsolidatedReport",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReport_MoblileMoneyReportId",
                table: "ConsolidatedReport",
                column: "MoblileMoneyReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReport_MobileMoneyReport_MoblileMoneyReportId",
                table: "ConsolidatedReport",
                column: "MoblileMoneyReportId",
                principalTable: "MobileMoneyReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
