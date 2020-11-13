using Microsoft.EntityFrameworkCore.Migrations;

namespace mmbm.Migrations
{
    public partial class AddConsolidatedReportToKiosk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KioskId",
                table: "ConsolidatedReport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReport_KioskId",
                table: "ConsolidatedReport",
                column: "KioskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReport_Kiosks_KioskId",
                table: "ConsolidatedReport",
                column: "KioskId",
                principalTable: "Kiosks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReport_Kiosks_KioskId",
                table: "ConsolidatedReport");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReport_KioskId",
                table: "ConsolidatedReport");

            migrationBuilder.DropColumn(
                name: "KioskId",
                table: "ConsolidatedReport");
        }
    }
}
